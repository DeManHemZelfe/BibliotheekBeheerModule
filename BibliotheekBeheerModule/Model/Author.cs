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
using System.ComponentModel.DataAnnotations;

namespace BibliotheekBeheerModule.Model
{
    public partial class Author
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Infix { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return $"{FirstName} {Infix} {LastName}"; } // retourneer de volledige naam als een string
        }

        public ObservableCollection<Item> Items { get; set; }
        public Author()
        {
            Items = new ObservableCollection<Item>();
        }
        // public event PropertyChangedEventHandler PropertyChanged;
    }
}
