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
using System.Windows.Navigation;

namespace BibliotheekBeheerModule.View
{
    /// <summary>
    /// Interaction logic for AllAuthors.xaml
    /// </summary>
    public partial class AllAuthors : Window
    {
        public AllAuthors()
        {
            InitializeComponent();
            Init();
            DataContext = this;
        }
        private void Init()
        {
            TableDbContext tableDbContext = new TableDbContext();
            Authors = new ObservableCollection<Author>(tableDbContext.Authors);
        }
        private void UpdateRow(object sender, RoutedEventArgs e)
        {
            var Button = (Button)sender;
            var Row = FindVisualParent<DataGridRow>(Button);
            var Author = (Author)Row.DataContext;

            UpdateAuthorPage updateWindow = new UpdateAuthorPage();
            updateWindow.Show();
            updateWindow.GetAuthorToUpdate(Author.Id);
            this.Close();
        }

        private void DeleteRow(object sender, RoutedEventArgs e)
        {
            var Button = (Button)sender;
            var Row = FindVisualParent<DataGridRow>(Button);
            var Author = (Author)Row.DataContext;

            using (var db = new TableDbContext())
            {
                var authorToDelete = db.Authors.Find(Author.Id);
                if (authorToDelete != null)
                {
                    db.Authors.Attach(authorToDelete);
                    db.Authors.Remove(authorToDelete);
                    db.SaveChanges();
                }
                Console.WriteLine(Author.FullName + " Removed");
                Authors.Remove(Author);
            }
        }
        private void PrevPage(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }
        private DataGridRow FindVisualParent<DataGridRow>(DependencyObject obj) where DataGridRow : DependencyObject
        {
            DependencyObject parent = VisualTreeHelper.GetParent(obj);

            while (parent != null && !(parent is DataGridRow))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }

            return parent as DataGridRow;
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
