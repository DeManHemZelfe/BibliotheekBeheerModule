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
        public void Init()
        {
            TableDbContext tableDbContext = new TableDbContext();
            Items = new ObservableCollection<Item>(tableDbContext.Items);
            Authors = new ObservableCollection<Author>(tableDbContext.Authors);
            Types = new ObservableCollection<Type>(tableDbContext.Types);
        }
        private void AddAuthor(object sender, RoutedEventArgs e)
        {
            using (var db = new TableDbContext())
            {
                var item = new Author
                {
                    Id = Guid.NewGuid(),
                    FirstName = authorFirstname.Text.ToString(),
                    Infix = authorInfix.Text.ToString(),
                    LastName = authorLastname.Text.ToString(),
                };
                db.Authors.Add(item);
                db.SaveChanges();
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
