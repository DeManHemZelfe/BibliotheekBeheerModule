﻿using BibliotheekBeheerModule.DbContexts;
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
        // Import all authors from database
        private void Init()
        {
            TableDbContext tableDbContext = new TableDbContext();
            Authors = new ObservableCollection<Author>(tableDbContext.Authors);
        }
        private void UpdateRow(object sender, RoutedEventArgs e)
        {
            // Get that row that contains the clicked update button
            var Button = (Button)sender;
            var Row = FindVisualParent<DataGridRow>(Button);
            var Author = (Author)Row.DataContext;

            // Open update author window
            UpdateAuthorPage updateWindow = new UpdateAuthorPage();
            updateWindow.Show();
            updateWindow.GetAuthorToUpdate(Author.Id);
            this.Close();
        }
        private void DeleteRow(object sender, RoutedEventArgs e)
        {
            // Get that row that contains the clicked delete button
            var Button = (Button)sender;
            var Row = FindVisualParent<DataGridRow>(Button);
            var Author = (Author)Row.DataContext;

            // Find author in database and delete it
            using (var db = new TableDbContext())
            {
                var authorToDelete = db.Authors.Find(Author.Id);
                if (authorToDelete != null)
                {
                    db.Authors.Attach(authorToDelete);
                    db.Authors.Remove(authorToDelete);
                    db.SaveChanges();
                }
                Authors.Remove(Author);
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
