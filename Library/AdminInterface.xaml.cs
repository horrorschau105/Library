using System;
using System.Collections.Generic;
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

namespace Library
{
    /// <summary>
    /// Interaction logic for AdminInterface.xaml
    /// </summary>
    public partial class AdminInterface : Window
    {
        JSONBaseHandler db;
        public AdminInterface()
        {
            InitializeComponent();
             db = new JSONBaseHandler("booksBase.json");
        }
        private void addBookButton_Click(object sender, RoutedEventArgs e)
        {
            if (yearTextBox.Text == "" || authorTextBox.Text == "" || titleTextBox.Text == "")
            {
                MessageBox.Show("Fill all textboxes!");
            }
            else
            {
                db.AddBook(authorTextBox.Text, titleTextBox.Text, yearTextBox.Text);
                MessageBox.Show("Book added!");
            }
        }

        private void findBookButton_Click(object sender, RoutedEventArgs e)
        {
            var result = db.FindBook(authorTextBox.Text, titleTextBox.Text, yearTextBox.Text);
            ListOfBooks ls = new ListOfBooks(db, result);
            ls.Show();
        }

        private void borrowButton_Click(object sender, RoutedEventArgs e)
        {
            if (idTextBox.Text == "" || borrowerTextBox.Text == "" || borrowerTextBox.Text == "0")
            {
                MessageBox.Show("Put book ID and borrower ID!");
                return;
            }
            if (db.BorrowBook(idTextBox.Text, borrowerTextBox.Text))
            {
                MessageBox.Show("Book borrowed correctly!");
            }
            else
            {
                MessageBox.Show("Book couldn't be borrowed");
            }
        }

        private void releaseButton_Click(object sender, RoutedEventArgs e)
        {
            if (idTextBox.Text == "")
            {
                MessageBox.Show("Put book ID!");
                return;
            }
            if (db.ReleaseBook(idTextBox.Text))
            {
                MessageBox.Show("Book released!");
            }
            else
            {
                MessageBox.Show("Book doesn't exist in base!");
            }
        }

        
    }
}

