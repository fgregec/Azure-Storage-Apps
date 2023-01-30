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
using System.Windows.Shapes;
using V03.Models;
using V03.ViewModel;

namespace V03
{
    /// <summary>
    /// Interaction logic for EditSubjectPage.xaml
    /// </summary>
    public partial class EditSubjectPage : FramedPage
    {
        private readonly Subject _subject;

        public EditSubjectPage(SubjectViewModel subjectViewModel, Subject subject = null) : base(subjectViewModel)
        {
            InitializeComponent();
            _subject = subject ?? new Subject();
            DataContext = _subject;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.NavigationService.GoBack();
        }

        private void BtnCommit_Click(object sender, RoutedEventArgs e)
        {
            if (FormValid())
            {
                _subject.Name = TbName.Text.Trim();
                Frame.NavigationService.GoBack();

                if (_subject.IDSubject == 0)
                {
                    SubjectViewModel.Subjects.Add(_subject);
                }
                else
                {
                    SubjectViewModel.Update(_subject);
                }


            }
        }

        private bool FormValid()
        {
            bool valid = true;

            GridContainer.Children.OfType<TextBox>().ToList().ForEach(e =>
            {
                if (string.IsNullOrEmpty(e.Text.Trim()))
                {
                    e.Background = Brushes.LightCoral;
                    valid = false;
                }
                else
                {
                    e.Background = Brushes.White;
                }
            });

            return valid;
        }

        
    }
}

