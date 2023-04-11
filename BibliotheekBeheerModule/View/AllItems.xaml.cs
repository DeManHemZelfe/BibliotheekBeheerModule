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
using System.Collections.ObjectModel;
using BibliotheekBeheerModule.Model;
using BibliotheekBeheerModule.DbContexts;
using System.ComponentModel;

namespace BibliotheekBeheerModule.View
{
    /// <summary>
    /// Interaction logic for AllItems.xaml
    /// </summary>
    public partial class AllItems : Window
    {
        public AllItems()
        {
            InitializeComponent();
            ItemDbContext itemDbContext = new ItemDbContext();
            var items = itemDbContext.Items.ToList();
            Init();
            FillItems();
            DataContext = this;
        }

        private void Init()
        {

            

    }
    private void FillItems() 
        {
            Author author = new Author()
            {
                FirstName = "Vincent",
                Infix = "van",
                LastName = "Gogh",
            };

            Item item4 = new Item()
            {
                Name = "Dave in het donker",
                Type = "CD",
                Author = author.FullName,
            };
            Item item2 = new Item()
            {
                Name = "Dave in het licht",
                Type = "CD",
                Author = author.FullName,
            };

            Item item3 = new Item()
            {
                Name = "Dave en Niels op avontuut",
                Type = "DVD",
                Author = author.FullName,
            };
            using (var context = new ItemDbContext())
            {
                var item = new Item
                {
                    Name = "Nieuw item",
                    Type = "Boek",
                    Author = "Johan",
                };

                context.Items.Add(item);
                try 
                {

                    context.SaveChanges();
                } catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
      
            }
        }
        private ObservableCollection<Item> _items;

        public ObservableCollection<Item> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
