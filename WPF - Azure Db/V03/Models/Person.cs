using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using V03.Utils;

namespace V03.Models
{
    public class Person
    {
        public int IDPerson { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public byte[] Picture { get; set; }

        public int SubjectID { get; set; }
        public BitmapImage Image { 
            get => ImageUtils.ByteArrayToBitmapImage(Picture);
        }
    }
}
