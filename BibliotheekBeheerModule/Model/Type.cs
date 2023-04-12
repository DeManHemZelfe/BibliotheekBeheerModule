using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotheekBeheerModule.Model
{
    public class Type
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
