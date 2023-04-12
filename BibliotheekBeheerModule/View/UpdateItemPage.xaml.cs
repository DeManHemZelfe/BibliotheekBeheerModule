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

        public void Init()
        {
            TableDbContext tableDbContext = new TableDbContext();
            Items = new ObservableCollection<Item>(tableDbContext.Items);
            Authors = new ObservableCollection<Author>(tableDbContext.Authors);
            Types = new ObservableCollection<Type>(tableDbContext.Types);
        }

        public void GetItemToUpdate(Guid ItemId)
        {
            using (var db = new TableDbContext())
            {
                var itemToUpdate = db.Items.Find(ItemId);
                ItemTitle.Text = itemToUpdate.Name;
                ItemType.Text = itemToUpdate.Type;
                ItemDescription.Text = itemToUpdate.Description;
                ItemAuthor.Text = itemToUpdate.Author;
                ItemUpdateButton.Tag = ItemId;
            }
        }

        private void UpdateItem(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Guid ItemId = new Guid(btn.Tag.ToString());

            using (var db = new TableDbContext())
            {
                var itemToUpdate = db.Items.Find(ItemId);
                if (itemToUpdate != null)
                {
                    itemToUpdate.Name = ItemTitle.Text;
                    itemToUpdate.Type = ItemType.Text;
                    itemToUpdate.Description = ItemDescription.Text;
                    itemToUpdate.Author = ItemAuthor.Text;
                    db.SaveChanges();
                }
            }
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
