using BibliotheekBeheerModule.DbContexts;
using BibliotheekBeheerModule.Model;
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
using Type = BibliotheekBeheerModule.Model.Type;

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

        private void AddNewItem(object sender, RoutedEventArgs e)
        {
            using (var db = new TableDbContext())
            {
                foreach (var author in Authors) 
                {
                    if (author.FullName == itemAuthor.Text)
                    {
                        var item = new Item
                        {
                            Id = Guid.NewGuid(),
                            Name = itemTitle.Text.ToString(),
                            Type = itemType.Text.ToString().Length < 1 ? "CD" : itemType.Text.ToString(),
                            Description = itemDescription.Text.ToString(),
                            Author = author.FullName,
                        };
                        db.Items.Add(item);
                        db.SaveChanges();
                    }
                    else 
                    {
                        // er is geen juiste author geset dus mag hij niet opslaan.
                    }
                }
            }
            BackToMainMenu();
        }

        private void PrevPage(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void BackToMainMenu()
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
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
    }
}
