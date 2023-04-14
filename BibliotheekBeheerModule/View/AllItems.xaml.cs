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
using System.Windows.Navigation;

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
            Init();
            DataContext = this;
        }

        // Import all items and authors
        private void Init()
        {
            TableDbContext tableDbContext = new TableDbContext();
            Items = new ObservableCollection<Item>(tableDbContext.Items);
            Authors = new ObservableCollection<Author>(tableDbContext.Authors);
        }

        // Function for the searchbar that filters items based in text input
        private void SearchItem(object sender, RoutedEventArgs e)
        {

            string SearchTerm = ItemSearch.Text;
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                var FilteredItems = Items.Where(item =>
                item.Name.ToLower().Contains(SearchTerm.ToLower()) ||
                item.Type.ToLower().Contains(SearchTerm.ToLower()) ||
                item.Description.ToLower().Contains(SearchTerm.ToLower()) ||
                item.Author.FullName.Contains(SearchTerm.ToLower()));
                ItemList.ItemsSource = FilteredItems;
            } else
            {
               // When the filter is empty show all items
               ItemList.ItemsSource = Items;
            }

           
        } 

        private void UpdateRow(object sender, RoutedEventArgs e)
        {
            // Get row to update 
            var Button = (Button)sender;
            var Row = FindVisualParent<DataGridRow>(Button);
            var Item = (Item)Row.DataContext;

            // Open update window
            UpdateItemPage updateWindow = new UpdateItemPage();
            updateWindow.Show();
            updateWindow.GetItemToUpdate(Item.Id);
            this.Close();
        }

        private void DeleteRow(object sender, RoutedEventArgs e)
        {
            // Get row to delete
            var Button = (Button)sender;
            var Row = FindVisualParent<DataGridRow>(Button);
            var Item = (Item)Row.DataContext;

            // Delete row 
            using (var db = new TableDbContext())
            {
                var itemToDelete = db.Items.Find(Item.Id);
                if (itemToDelete != null)
                {
                    db.Items.Attach(itemToDelete);
                    db.Items.Remove(itemToDelete);
                    db.SaveChanges();
                }
                Items.Remove(Item);
            }

        }

        // Navigate to previous page
        private void PrevPage(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }


        // Function that returns the parent row as a datagridrow
        private DataGridRow FindVisualParent<DataGridRow>(DependencyObject obj) where DataGridRow : DependencyObject
        {
            DependencyObject parent = VisualTreeHelper.GetParent(obj);

            while (parent != null && !(parent is DataGridRow))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }

            return parent as DataGridRow;
        }

        // Define an ObservableCollection with the name of the generic type.
        // Define a public property with the same type name.
        // Getter of the property that returns _.
        // Setter of the property that assigns the value of 'value' to _.
        // And then calls OnPropertyChanged with the name of the property.

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
        private ObservableCollection<Author> _authors;

        public ObservableCollection<Author> Authors
        {
            get { return _authors; }
            set
            {
                _authors = value;
                OnPropertyChanged(nameof(Authors));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
