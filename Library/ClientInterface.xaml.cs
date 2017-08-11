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
    /// Interaction logic for ClientInterface.xaml
    /// </summary>
    public partial class ClientInterface : Window
    {
        JSONBaseHandler db;
        string clientID;
        public ClientInterface(JSONBaseHandler db, string id)
        {
            InitializeComponent();
            this.db = db;
            clientID = id;
            ShowBooks();
            db.BaseUpdated += ShowBooks;
        }
        void ShowBooks(object o, EventArgs e)
        {
            ShowBooks();
        }
        void ShowBooks()
        {
            var toDisplay = db.GetBooksBorrowedBy(clientID);
            this.booksListView.Items.Clear();
            foreach(var book in toDisplay)
            {
                booksListView.Items.Add(book);
            }
        }
    }
}
