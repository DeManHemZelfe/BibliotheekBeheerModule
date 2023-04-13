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

        public void Init()
        {
            TableDbContext tableDbContext = new TableDbContext();
            Items = new ObservableCollection<Item>(tableDbContext.Items);
            Authors = new ObservableCollection<Author>(tableDbContext.Authors);
        }

        public void GetAuthorToUpdate(Guid AuthorId)
        {
            using (var db = new TableDbContext())
            {
                var authorToUpdate = db.Authors.Find(AuthorId);
                authorFirstname.Text = authorToUpdate.FirstName;
                authorInfix.Text = authorToUpdate.Infix;
                authorLastname.Text = authorToUpdate.LastName;
                AuthorUpdateButton.Tag = AuthorId;
            }
        }

        private void UpdateAuthor(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Guid AuthorId = new Guid(btn.Tag.ToString());

            using (var db = new TableDbContext())
            {
                var authorToUpdate = db.Authors.Find(AuthorId);
                var oldAuthor = authorToUpdate.FullName;
                if (authorToUpdate != null)
                {
                    authorToUpdate.FirstName = authorFirstname.Text;
                    authorToUpdate.Infix = authorInfix.Text;
                    authorToUpdate.LastName = authorLastname.Text;
                    db.SaveChanges();
                    foreach (var item in Items) 
                        if(item.Author == oldAuthor)
                        {
                            item.Author = authorToUpdate.FullName;
                            db.SaveChanges();
                        }
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