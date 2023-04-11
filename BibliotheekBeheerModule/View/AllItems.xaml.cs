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
            DataContext = this;
            Init();
            ObservableCollection<Author> AllAuthors = new ObservableCollection<Author>();
            FillItems();
        }

        private void Init()
        {
            AllItemsGrid = new ObservableCollection<Item>();
            

    }
    private void FillItems() 
        {
            Author author = new Author()
            {
                FirstName = "Vincent",
                Infix = "van",
                LastName = "Gogh",
            };

            Item item = new Item()
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


            AllItemsGrid.Add(item);
            AllItemsGrid.Add(item2);
            AllItemsGrid.Add(item3);
        }

        public ObservableCollection<Item> AllItemsGrid
        {
            get { return (ObservableCollection<Item>)GetValue(AllItemsProperty); }
            set { SetValue(AllItemsProperty, value); }
        }

        public static DependencyProperty AllItemsProperty =
            DependencyProperty.Register("AllItemsGrid", typeof(ObservableCollection<Item>), typeof(AllItems), new PropertyMetadata(null));
    }
}
