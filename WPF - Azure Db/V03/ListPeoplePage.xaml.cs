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
using V03.ViewModel;

namespace V03
{

    public partial class ListPeoplePage : FramedPage
    {
        public ListPeoplePage(PersonViewModel personViewModel) : base(personViewModel)
        {
            InitializeComponent();
            LvPeople.ItemsSource = personViewModel.People;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new EditPersonPage(PersonViewModel) { Frame = Frame});
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if(LvPeople.SelectedItem != null)
            {
                Frame.Navigate(new EditPersonPage(PersonViewModel, LvPeople.SelectedItem as Person) { Frame = Frame});
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (LvPeople.SelectedItem != null)
            {
                PersonViewModel.People.Remove(LvPeople.SelectedItem as Person);
            }
        }

        private void BtnSubject_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new ListSubjectPage(new ViewModel.SubjectViewModel()) { Frame = Frame });
        }
    }
}
