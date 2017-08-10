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
    /// Interaction logic for ListOfBooks.xaml
    /// </summary>
    public partial class ListOfBooks : Window
    {
        IEnumerable<Book> displayedCollection;
        JSONBaseHandler db;
        public ListOfBooks(JSONBaseHandler database, IEnumerable<Book> toDisplay)
        {
            InitializeComponent();
            displayedCollection = toDisplay;
            db = database;
            FillListView();
        }
        public void FillListView()
        {
            
            booksListView.Items.Clear();
            foreach (var book in displayedCollection)
            {
                booksListView.Items.Add(book);
            }
        }
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (booksListView.SelectedIndex == -1)
            {
                MessageBox.Show("Please select book!");
                return;
            }
            Book toDelete = displayedCollection.ElementAt(booksListView.SelectedIndex);
            if (MessageBox.Show(string.Format("Do you want to delete book \"{0}\"?", toDelete.title), "Caution!" , MessageBoxButton.YesNo) ==  MessageBoxResult.Yes )
            {
                displayedCollection = displayedCollection.Where(book => book.id != toDelete.id);
                FillListView();
                db.DeleteBook(toDelete);
            }
        }
    }
}
