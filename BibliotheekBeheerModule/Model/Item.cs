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
        public string name { get; set; }
        public string type { get; set; }
        public string author { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
