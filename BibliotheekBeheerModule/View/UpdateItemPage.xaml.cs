using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Navigation;
using BibliotheekBeheerModule.DbContexts;
using BibliotheekBeheerModule.Model;
using Type = BibliotheekBeheerModule.Model.Type;

namespace BibliotheekBeheerModule.View
{
    /// <summary>
    /// Interaction logic for UpdateItem.xaml
    /// </summary>
    public partial class UpdateItemPage : Window
    {
        public UpdateItemPage()
        {
            InitializeComponent();
            Init();
            DataContext = this;
        }

        // Import data from database
        public void Init()
        {
            TableDbContext tableDbContext = new TableDbContext();
            Items = new ObservableCollection<Item>(tableDbContext.Items);
            Authors = new ObservableCollection<Author>(tableDbContext.Authors);
            Types = new ObservableCollection<Type>(tableDbContext.Types);
        }

        // Get author and item data and place it inside the fields
        public void GetItemToUpdate(Guid ItemId)
        {
            using (var db = new TableDbContext())
            {
                var ItemToUpdate = db.Items.Find(ItemId);
                var AuthorToUpdate = db.Authors.Find(ItemToUpdate.AuthorId);
                ItemTitle.Text = ItemToUpdate.Name;
                ItemType.Text = ItemToUpdate.Type;
                ItemDescription.Text = ItemToUpdate.Description;
                ItemAuthor.Text = AuthorToUpdate.FullName;
                ItemUpdateButton.Tag = ItemId;
            }
        }

        // Update item
        private void UpdateItem(object sender, RoutedEventArgs e)
        {
            // Get item id from button tag
            Button Btn = sender as Button;
            Guid ItemId = new Guid(Btn.Tag.ToString());

            // Get author id by full name match
            Author matchingAuthor = Authors.FirstOrDefault(a => a.FullName == ItemAuthor.Text.ToString());

            using (var db = new TableDbContext())
            {
                var ItemToUpdate = db.Items.Find(ItemId); // Get item to update using item id
                if (ItemToUpdate != null)
                {
                    ItemToUpdate.Name = ItemTitle.Text.Trim();
                    ItemToUpdate.Type = ItemType.Text.Trim();
                    ItemToUpdate.Description = ItemDescription.Text.Trim();
                    ItemToUpdate.AuthorId = matchingAuthor.Id; // Use author id as foreign key to refer to item object
                    db.SaveChanges();
                }
            }
            BackToAllAllItemsFunction();
        }

        private ObservableCollection<Type> _types;
        public ObservableCollection<Type> Types
        {
            get { return _types; }
            set
            {
                _types = value;
                OnPropertyChanged(nameof(Types));
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

        private void BackToAllItems(object sender, RoutedEventArgs e)
        {
            AllItems window = new AllItems();
            window.Show();
            this.Close();
        }
        private void BackToAllAllItemsFunction()
        {
            AllItems window = new AllItems();
            window.Show();
            this.Close();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
