/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package hr.algebra.controller;

import hr.algebra.PersonManagerApplication;
import hr.algebra.dao.RepositoryFactory;
import hr.algebra.model.Subject;
import hr.algebra.utilities.FileUtils;
import hr.algebra.utilities.ImageUtils;
import hr.algebra.utilities.ValidationUtils;
import hr.algebra.viewmodel.PersonViewModel;
import hr.algebra.viewmodel.SubjectViewModel;
import java.io.ByteArrayInputStream;
import java.io.File;
import java.io.IOException;
import java.net.URL;
import java.util.AbstractMap;
import java.util.Map;
import java.util.ResourceBundle;
import java.util.concurrent.atomic.AtomicBoolean;
import java.util.function.Predicate;
import java.util.function.UnaryOperator;
import java.util.logging.Level;
import java.util.logging.Logger;
import java.util.stream.Collectors;
import java.util.stream.Stream;
import javafx.collections.FXCollections;
import javafx.collections.ListChangeListener;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Node;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Alert;
import javafx.scene.control.Alert.AlertType;
import javafx.scene.control.ButtonType;
import javafx.scene.control.ComboBox;
import javafx.scene.control.Label;
import javafx.scene.control.Tab;
import javafx.scene.control.TabPane;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.TextField;
import javafx.scene.control.TextFormatter;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.stage.Stage;
import javafx.util.converter.IntegerStringConverter;

/**
 * FXML Controller class
 *
 * @author daniel.bele
 */
public class PeopleController implements Initializable {

    private Map<TextField, Label> validationMap;

    private final ObservableList<PersonViewModel> people = FXCollections.observableArrayList();

    private PersonViewModel selectedPersonViewModel;

    private Tab previousTab;

    @FXML
    private TabPane tpContent;
    @FXML
    private Tab tabEdit;
    @FXML
    private Tab tabList;
    @FXML
    private ImageView ivPerson;
    @FXML
    private TableView<PersonViewModel> tvPeople;
    @FXML
    private TableColumn<PersonViewModel, String> tcFirstName, tcLastName, tcEmail;
    @FXML
    private TableColumn<PersonViewModel, Integer> tcAge, tcSubject;
    @FXML
    private TextField tfFirstName, tfLastName, tfAge, tfEmail;
    @FXML
    private Label lbFirstNameError, lbLastNameError, lbAgeError, lbEmailError, lbIconError;

    //subject
    
    private SubjectViewModel selectedSubjectViewModel;
    private final ObservableList<SubjectViewModel> subjects = FXCollections.observableArrayList();
    @FXML
    private Tab tabListSubjects;
    @FXML
    private TableView<SubjectViewModel> tvSubjects;
    @FXML
    private TableColumn<SubjectViewModel,  Integer> tcSubjectID;
    @FXML
    private TableColumn<SubjectViewModel, String> tcSubjectName;
    @FXML
    private Tab tabEditSubject;
    @FXML
    private TextField tfSubjectName;
    @FXML
    private Label lbSubjectNameError;
    @FXML
    private ComboBox cbSubjects;
    
    
    
    /**
     * Initializes the controller class.
     */

@Override
    public void initialize(URL url, ResourceBundle rb) {
        initValidation();
        initPeople();
        initTable();
        
        initSubjects();
        initSubjectTable();
        
        addIntegerMask(tfAge);
        setupListeners();
    }

    private void initValidation() {
        validationMap = Stream.of(
                new AbstractMap.SimpleImmutableEntry<>(tfFirstName, lbFirstNameError),
                new AbstractMap.SimpleImmutableEntry<>(tfLastName, lbLastNameError),
                new AbstractMap.SimpleImmutableEntry<>(tfAge, lbAgeError),
                new AbstractMap.SimpleImmutableEntry<>(tfEmail, lbEmailError))
                .collect(Collectors.toMap(Map.Entry::getKey, Map.Entry::getValue));
    }

    private void initPeople() {
        try {
            RepositoryFactory.getRepository().getPeople().forEach(person -> people.add(new PersonViewModel(person)));
        } catch (Exception ex) {
            Logger.getLogger(PeopleController.class.getName()).log(Level.SEVERE, null, ex);
            new Alert(Alert.AlertType.ERROR, "Unable to load the form. Exiting...").show();
        }
    }

    private void initTable() {
        tcFirstName.setCellValueFactory(person -> person.getValue().getFirstNameProperty());
        tcLastName.setCellValueFactory(person -> person.getValue().getLastNameProperty());
        tcAge.setCellValueFactory(person -> person.getValue().getAgeProperty().asObject());
        tcEmail.setCellValueFactory(person -> person.getValue().getEmailProperty());
        tcSubject.setCellValueFactory(person -> person.getValue().getSubjectProperty().asObject());
        tvPeople.setItems(people);
        cbSubjects.setItems(subjects);
        cbSubjects.getSelectionModel().selectFirst();
    }

    private void addIntegerMask(TextField tf) {
        UnaryOperator<TextFormatter.Change> integerFilter = change -> {
            String input = change.getText();
            if (input.matches("\\d*")) {
                return change;
            }
            return null;
        };
        // first we must convert integer to string, and then we apply filter
        tf.setTextFormatter(new TextFormatter<>(new IntegerStringConverter(), 0, integerFilter));
    }

    private void setupListeners() {
        tpContent.setOnMouseClicked(event -> {
            if (tpContent.getSelectionModel().getSelectedItem().equals(tabEdit) && !tabEdit.equals(previousTab)) {
                bindPerson(null);
            }
            if(tpContent.getSelectionModel().getSelectedItem().equals(tabEditSubject) && !tabEditSubject.equals(previousTab)){
                bindSubject(null);
            }
            previousTab = tpContent.getSelectionModel().getSelectedItem();
        });

        
        
        people.addListener((ListChangeListener.Change<? extends PersonViewModel> change) -> {
            if (change.next()) {
                if (change.wasRemoved()) {
                    change.getRemoved().forEach(pvm -> {
                        try {
                            RepositoryFactory.getRepository().deletePerson(pvm.getPerson());
                        } catch (Exception ex) {
                            Logger.getLogger(PeopleController.class.getName()).log(Level.SEVERE, null, ex);
                        }
                    });
                } else if (change.wasAdded()) {
                    change.getAddedSubList().forEach(pvm -> {
                        try {
                            int idPerson = RepositoryFactory.getRepository().addPerson(pvm.getPerson());
                            pvm.getPerson().setIDPerson(idPerson);
                        } catch (Exception ex) {
                            Logger.getLogger(PeopleController.class.getName()).log(Level.SEVERE, null, ex);
                        }
                    });
                }
            }
        });
        
        subjects.addListener((ListChangeListener.Change<? extends SubjectViewModel> change) -> {
            if (change.next()) {
                if (change.wasRemoved()) {
                    change.getRemoved().forEach(svm -> {
                        try {
                            RepositoryFactory.getRepository().deleteSubject(svm.getSubject());
                        } catch (Exception ex) {
                            Logger.getLogger(PeopleController.class.getName()).log(Level.SEVERE, null, ex);
                        }
                    });
                } else if (change.wasAdded()) {
                    change.getAddedSubList().forEach(svm -> {
                        try {
                            int idSubject = RepositoryFactory.getRepository().addSubject(svm.getSubject());
                            svm.getSubject().setIDSubject(idSubject);
                        } catch (Exception ex) {
                            Logger.getLogger(PeopleController.class.getName()).log(Level.SEVERE, null, ex);
                        }
                    });
                }
            }
        });
        
        
    }

    @FXML
    public void delete(ActionEvent event) {
        if (tvPeople.getSelectionModel().getSelectedItem() != null) {
            people.remove(tvPeople.getSelectionModel().getSelectedItem());
        }
    }

    @FXML
    public void edit(ActionEvent event) {
        if (tvPeople.getSelectionModel().getSelectedItem() != null) {
            bindPerson(tvPeople.getSelectionModel().getSelectedItem());            
            tpContent.getSelectionModel().select(tabEdit);       
            previousTab = tabEdit;
        }
    }

    private void bindPerson(PersonViewModel viewModel) {
        resetForm();

        selectedPersonViewModel = viewModel != null ? viewModel : new PersonViewModel(null);
        tfFirstName.setText(selectedPersonViewModel.getFirstNameProperty().get());
        tfLastName.setText(selectedPersonViewModel.getLastNameProperty().get());
        tfAge.setText(String.valueOf(selectedPersonViewModel.getAgeProperty().get()));
        tfEmail.setText(selectedPersonViewModel.getEmailProperty().get());
        ivPerson.setImage(selectedPersonViewModel.getPictureProperty().get() != null ? new Image(new ByteArrayInputStream(selectedPersonViewModel.getPictureProperty().get())) : new Image(new File("src/assets/no_image.png").toURI().toString()));
    }

    private void resetForm() {
        validationMap.values().forEach(lb -> lb.setVisible(false));
        cbSubjects.getSelectionModel().selectFirst();
        lbIconError.setVisible(false);
    }

    @FXML
    private void uploadImage(ActionEvent event) {
        File file = FileUtils.uploadFileDialog(tfAge.getScene().getWindow(), "jpg", "jpeg", "png");
        if (file != null) {
            Image image = new Image(file.toURI().toString());
            try {
                String ext = file.getName().substring(file.getName().lastIndexOf(".") + 1);
                selectedPersonViewModel.getPerson().setPicture(ImageUtils.imageToByteArray(image, ext));
                ivPerson.setImage(image);
            } catch (Exception ex) {
                Logger.getLogger(PeopleController.class.getName()).log(Level.SEVERE, null, ex);
            }
        }
    }

    @FXML
    private void commit(ActionEvent event) {
        if (formValid()) {
            selectedPersonViewModel.getPerson().setFirstName(tfFirstName.getText().trim());
            selectedPersonViewModel.getPerson().setLastName(tfLastName.getText().trim());
            selectedPersonViewModel.getPerson().setAge(Integer.valueOf(tfAge.getText().trim()));
            SubjectViewModel tempSubject = (SubjectViewModel)cbSubjects.getValue();
            selectedPersonViewModel.getPerson().setSubjectID(tempSubject.getIdSubjectProperty().getValue());
            selectedPersonViewModel.getPerson().setEmail(tfEmail.getText().trim());
            if (selectedPersonViewModel.getPerson().getIDPerson() == 0) {
                people.add(selectedPersonViewModel);
            } else {
                try {
                    // we cannot listen to the upates
                    RepositoryFactory.getRepository().updatePerson(selectedPersonViewModel.getPerson());
                    tvPeople.refresh();
                } catch (Exception ex) {
                    Logger.getLogger(PeopleController.class.getName()).log(Level.SEVERE, null, ex);
                }
            }
            selectedPersonViewModel = null;
            tpContent.getSelectionModel().select(tabList);
            resetForm();
        }
    }

    private boolean formValid() {
        // discouraged but ok!
        final AtomicBoolean ok = new AtomicBoolean(true);
        validationMap.keySet().forEach(tf -> {
            if (tf.getText().trim().isEmpty() || tf.getId().contains("Email") && !ValidationUtils.isValidEmail(tf.getText().trim())) {
                validationMap.get(tf).setVisible(true);
                ok.set(false);
            } else {
                validationMap.get(tf).setVisible(false);
            }
        });

        if (selectedPersonViewModel.getPictureProperty().get() == null) {
            lbIconError.setVisible(true);
            ok.set(false);
        } else {
            lbIconError.setVisible(false);
        }
        return ok.get();
    }



    public void initSubjects() {
        try {
            RepositoryFactory.getRepository().getSubjects().forEach(subject -> subjects.add(new SubjectViewModel(subject)));
        } catch (Exception ex) {
            Logger.getLogger(PeopleController.class.getName()).log(Level.SEVERE, null, ex);
            new Alert(Alert.AlertType.ERROR, "Unable to load the form. Exiting...").show();
        }    }

    public void initSubjectTable() {
        tcSubjectName.setCellValueFactory(subject -> subject.getValue().getNameProperty());
        tcSubjectID.setCellValueFactory(subject -> subject.getValue().getIdSubjectProperty().asObject());
        tvSubjects.setItems(subjects);
        
    }

    public void addSubject(ActionEvent event){
            if (subjectFormValid()) {
            selectedSubjectViewModel.getSubject().setName(tfSubjectName.getText().trim());
            if (selectedSubjectViewModel.getSubject().getIDSubject()== 0) {
                subjects.add(selectedSubjectViewModel);
            } else {
                try {
                    // we cannot listen to the upates
                    RepositoryFactory.getRepository().updateSubject(selectedSubjectViewModel.getSubject());
                    tvSubjects.refresh();
                } catch (Exception ex) {
                    Logger.getLogger(PeopleController.class.getName()).log(Level.SEVERE, null, ex);
                }
            }
            selectedSubjectViewModel = null;
            tpContent.getSelectionModel().select(tabListSubjects);
            resetForm();
        }
    }

    public boolean subjectFormValid() {
        final AtomicBoolean ok = new AtomicBoolean(true);
        if(tfSubjectName.getText().trim().isEmpty()){
            lbSubjectNameError.setVisible(true);
            ok.set(false);
        }
        return ok.get();
    }

    public void deleteSubject(){
           if (tvSubjects.getSelectionModel().getSelectedItem() != null) {
               for (PersonViewModel personViewModel : people) {
                   if(personViewModel.getSubjectProperty().get() == tvSubjects.getSelectionModel().getSelectedItem().getIdSubjectProperty().get()){
                        Alert alert = new Alert(AlertType.INFORMATION);
                        alert.setTitle("Error!");
                        alert.setHeaderText("No can do");
                        alert.setContentText("Subject in use! First delete the person who is using it!");
                        alert.showAndWait();
                       return;
                   }
               }
            subjects.remove(tvSubjects.getSelectionModel().getSelectedItem());
            }
    }

    
    
    @FXML
    public void editSubject(ActionEvent event) {
        if (tvSubjects.getSelectionModel().getSelectedItem() != null) {
            bindSubject(tvSubjects.getSelectionModel().getSelectedItem());
            tpContent.getSelectionModel().select(tabEditSubject);
            previousTab = tabEditSubject;
        }
    }

    public void bindSubject(SubjectViewModel viewModel) {
        resetForm();
        selectedSubjectViewModel = viewModel != null ? viewModel : new SubjectViewModel(null);
        tfSubjectName.setText(selectedSubjectViewModel.getNameProperty().get());
    }
    
    
}
