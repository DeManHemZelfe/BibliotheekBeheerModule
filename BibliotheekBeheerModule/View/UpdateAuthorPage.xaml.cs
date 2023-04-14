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
    /// Interaction logic for UpdateAuthorPage.xaml
    /// </summary>
    public partial class UpdateAuthorPage : Window
    {
        public UpdateAuthorPage()
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
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            // Trigger the validation of the text boxes
            var bindingExpression = AuthorFirstname.GetBindingExpression(TextBox.TextProperty);
            bindingExpression?.UpdateSource();

            bindingExpression = AuthorLastname.GetBindingExpression(TextBox.TextProperty);
            bindingExpression?.UpdateSource();
        }


        private string _authorFirstNameInput;
        public string AuthorFirstNameInput
        {
            get { return _authorFirstNameInput; }
            set
            {
                _authorFirstNameInput = value;
                OnPropertyChanged(nameof(Types));
            }
        }

        private string _authorLastNameInput;
        public string AuthorLastNameInput
        {
            get { return _authorLastNameInput; }
            set
            {
                _authorLastNameInput = value;
                OnPropertyChanged(nameof(Types));
            }
        }

        // This gets the author that the user wants to update and places the data inside the fields 
        public void GetAuthorToUpdate(Guid AuthorId)
        {
            using (var db = new TableDbContext())
            {
                var AuthorToUpdate = db.Authors.Find(AuthorId);
                AuthorFirstname.Text = AuthorToUpdate.FirstName;
                AuthorInfix.Text = AuthorToUpdate.Infix;
                AuthorLastname.Text = AuthorToUpdate.LastName;
                AuthorUpdateButton.Tag = AuthorId; // Author.Id will be in the button tag
            }
        }

        // Updates the author  
        private void UpdateAuthor(object sender, RoutedEventArgs e)
        {
            // Get author.id from button tag
            Button Btn = sender as Button;
            Guid AuthorId = new Guid(Btn.Tag.ToString());

            using (var db = new TableDbContext())
            {
                var AuthorToUpdate = db.Authors.Find(AuthorId);
                if (AuthorToUpdate != null)
                {
                    AuthorToUpdate.FirstName = AuthorFirstname.Text.Trim();
                    AuthorToUpdate.Infix = AuthorInfix.Text.Trim();
                    AuthorToUpdate.LastName = AuthorLastname.Text.Trim();
                    db.SaveChanges();
                }
            }
            BackToAllAuthorsFunction();
        }
        private void BackToAllAuthors(object sender, RoutedEventArgs e)
        {
            AllAuthors window = new AllAuthors();
            window.Show();
            this.Close();
        }
        private void BackToAllAuthorsFunction()
        {
            AllAuthors window = new AllAuthors();
            window.Show();
            this.Close();
        }

        // Define an ObservableCollection with the name of the generic type.
        // Define a public property with the same type name.
        // Getter of the property that returns _.
        // Setter of the property that assigns the value of 'value' to _.
        // And then calls OnPropertyChanged with the name of the property.
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
