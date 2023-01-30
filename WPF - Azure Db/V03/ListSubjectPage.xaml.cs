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

    public partial class ListSubjectPage : FramedPage
    {
        public ListSubjectPage(SubjectViewModel subjectViewModel) : base(subjectViewModel)
        {
            InitializeComponent();
            LvSubject.ItemsSource = subjectViewModel.Subjects;
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new EditSubjectPage(SubjectViewModel) { Frame = Frame });
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (LvSubject.SelectedItem != null)
            {
                Frame.Navigate(new EditSubjectPage(SubjectViewModel, LvSubject.SelectedItem as Subject) { Frame = Frame });
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (LvSubject.SelectedItem != null)
                {
                    SubjectViewModel.Subjects.Remove(LvSubject.SelectedItem as Subject);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Subject is in use! Remove the person first!");
            }
        }

        private void BtnSubject_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new ListPeoplePage(new ViewModel.PersonViewModel()) { Frame = Frame });
        }

    }
}
