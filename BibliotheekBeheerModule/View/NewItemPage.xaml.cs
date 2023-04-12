using BibliotheekBeheerModule.DbContexts;
using BibliotheekBeheerModule.Model;
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

namespace BibliotheekBeheerModule.View
{
    /// <summary>
    /// Interaction logic for NewItemPage.xaml
    /// </summary>
    public partial class NewItemPage : Window
    {
        public NewItemPage()
        {
            InitializeComponent();
        }
        private void AddBook()
        {
            using (var context = new TableDbContext())
            {
                var item = new Item
                {
                    Name = "Dave is een pannenkoek",
                    Type = "Boek",
                    Author = "Rene van der gijp",
                };
                try
                {
                    context.Items.Add(item);
                    context.SaveChanges();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
        }
    }
}
