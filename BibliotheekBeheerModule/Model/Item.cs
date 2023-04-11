using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BibliotheekBeheerModule.Model
{
    public partial class Item
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Author { get; set; }

        // public event PropertyChangedEventHandler PropertyChanged;
    }
}
