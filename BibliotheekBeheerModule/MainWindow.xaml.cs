using BibliotheekBeheerModule.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BibliotheekBeheerModule
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowAllItemsWindow(object sender, RoutedEventArgs e)
        {
            AllItems window = new AllItems();
            window.Show();
            this.Close();
        }
        private void ShowAllAuthorsWindow(object sender, RoutedEventArgs e)
        {
            AllAuthors window = new AllAuthors();
            window.Show();
            this.Close();
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {

        }
        private void AddNewItemsPage(object sender, RoutedEventArgs e)
        {
            NewItemPage window = new NewItemPage();
            window.Show();
            this.Close();
        }
        private void AddNewAuthorPage(object sender, RoutedEventArgs e)
        {
            AddNewAuthor window = new AddNewAuthor();
            window.Show();
            this.Close();
        }

        private void ExitProgram(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
