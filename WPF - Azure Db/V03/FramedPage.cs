using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using V03.ViewModel;

namespace V03
{
    public class FramedPage : Page
    {
        public FramedPage(PersonViewModel personViewModel)
        {
            PersonViewModel = personViewModel;
        }

        public FramedPage(SubjectViewModel subjectViewModel)
        {
            SubjectViewModel = subjectViewModel;
        }

        public PersonViewModel PersonViewModel{ get;}
        public SubjectViewModel SubjectViewModel{ get;}
        public Frame Frame { get; set; }
    }
}
