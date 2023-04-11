using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using BibliotheekBeheerModule.Model;
using System.ComponentModel;

namespace BibliotheekBeheerModule.Model
{
    public partial class Author
    {
        public string firstName { get; set; }
        public string infix { get; set; }
        public string lastName { get; set; }
        public string FullName
        {
            get { return $"{firstName} {infix} {lastName}"; } // retourneer de volledige naam als een string
        }
        public ObservableCollection<Item> Items { get; set; }
        public Author()
        {
            Items = new ObservableCollection<Item>();
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
