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
    /// Interaction logic for AddNewAuthor.xaml
    /// </summary>
    public partial class AddNewAuthor : Window
    {
        public AddNewAuthor()
        {
            InitializeComponent();
            Init();
            DataContext = this;
        }

        // Importing tables from database
        public void Init()
        {
            TableDbContext tableDbContext = new TableDbContext();
            Items = new ObservableCollection<Item>(tableDbContext.Items);
            Authors = new ObservableCollection<Author>(tableDbContext.Authors);
            Types = new ObservableCollection<Type>(tableDbContext.Types);
        }
        // Adding a new Author 
        private void AddAuthor(object sender, RoutedEventArgs e)
        {
            using (var db = new TableDbContext())
            {
                var author = new Author
                {
                    Id = Guid.NewGuid(),
                    FirstName = authorFirstname.Text.ToString().Trim(),
                    Infix = authorInfix.Text.ToString().Trim(),
                    LastName = authorLastname.Text.ToString().Trim(),
                };
                db.Authors.Add(author);
                // Saves the new state of the database after adding a new author.
                db.SaveChanges();
            }
            BackToMainMenu();
        }

        // Navigates the user to the main window whenever it clicks the back button 
        private void PrevPage(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }
        // Navigates the user to the main window whenever it creates a new author
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
