using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using V03.Models;
using V03.Utils;
using V03.ViewModel;

namespace V03
{
    public partial class EditPersonPage : FramedPage
    {
        private readonly Person _person;
        private const string Filter = "All supported graphics|*.jpg;*.jpeg;*.png|JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|Portable Network Graphic (*.png)|*.png";


        public EditPersonPage(PersonViewModel personViewModel, Person person = null) : base(personViewModel)
        {
            InitializeComponent();
            LoadSubjects();
            _person = person ?? new Person();
            DataContext = _person;
        }

        private void LoadSubjects()
        {
            CbSubject.ItemsSource = new List<Subject>(new SubjectViewModel().Subjects);
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new ListPeoplePage(new ViewModel.PersonViewModel()) { Frame = Frame });
        }

        private void BtnCommit_Click(object sender, RoutedEventArgs e)
        {
            if (FormValid())
            {
                _person.Age = int.Parse(TbAge.Text.Trim());
                _person.Email = TbEmail.Text.Trim();
                _person.FirstName = TbFirstName.Text.Trim();
                _person.LastName = TbLastName.Text.Trim();
                _person.Picture = ImageUtils.BitmapImageToByteArray(Picture.Source as BitmapImage);
                _person.SubjectID = (CbSubject.SelectedItem as Subject).IDSubject;
                Frame.Navigate(new ListPeoplePage(new ViewModel.PersonViewModel()) { Frame = Frame });


                if (_person.IDPerson == 0)
                {
                    PersonViewModel.People.Add(_person);
                }
                else
                {
                    PersonViewModel.Update(_person);
                }


            }
        }

        private bool FormValid()
        {
            bool valid = true;

            GridContainer.Children.OfType<TextBox>().ToList().ForEach(e =>
            {
                if (string.IsNullOrEmpty(e.Text.Trim()) 
                || "Int".Equals(e.Tag) && !int.TryParse(e.Text.Trim(), out int r)
                || "Email".Equals(e.Tag) && !ValidationUtils.isValidEmail(e.Text.Trim()))
                {
                    e.Background = Brushes.LightCoral;
                    valid = false;
                }
                else
                {
                    e.Background = Brushes.White;
                }
            });

            if(Picture.Source == null)
            {
                PictureBorder.BorderBrush = Brushes.LightCoral;
                valid = false;
            }
            else
            {
                PictureBorder.BorderBrush = Brushes.White;
            }

            if(CbSubject.SelectedItem == null)
            {
                valid = false;
            }

            return valid;
        }

        private void BtnUpload_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = Filter
            };
            if(dialog.ShowDialog() == true)
            {
                Picture.Source = new BitmapImage(new Uri(dialog.FileName));
            }
        
        }
    }
}
