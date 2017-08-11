using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Library
{
    public class JSONBaseHandler
    {
        List<Book> _booksBase;
        string _filePath;
        int _maxIdxValue;
        public event EventHandler BaseUpdated;
        public JSONBaseHandler(string path)
        {
            _filePath = path;
            _booksBase = new List<Book>();
            _DownloadBase();
        }
        void _DownloadBase()
        {
            string json = File.ReadAllLines(_filePath).Aggregate((i, j) => i + "\n" + j);
            _booksBase = JsonConvert.DeserializeObject<List<Book>>(json);
            _maxIdxValue = (_booksBase.Select(book => book.id)).Max();
        }
        void _UploadBase()
        {
            string json = JsonConvert.SerializeObject(_booksBase, Formatting.Indented);
            File.WriteAllText(_filePath, json);
            BaseUpdated.Invoke(this, EventArgs.Empty);

        }
        public void AddBook(string author, string title, string year)
        {
            _booksBase.Add(new Book(title, author, year, "0" ,++_maxIdxValue));
            _UploadBase();
        }
        public void DeleteBook(Book toDelete)
        {
            _booksBase = _booksBase.Where(book => book != toDelete).ToList();
            _UploadBase();
        }
        public bool BorrowBook(string id, string borrower)
        {
            int incomingId;
            try
            {
                incomingId = Convert.ToInt32(id);
            }
            catch (Exception)
            {
                return false;
            }
            var releasedBook = _booksBase.Where(book => book.id == incomingId);
            if (releasedBook.Count() != 1) return false;
            if (releasedBook.ElementAt(0).borrowedBy != "0") return false;
            releasedBook.ElementAt(0).borrowedBy = borrower;
            _UploadBase();
            return true;
        }
        public bool ReleaseBook(string id)
        {
            int incomingId;
            try
            {
                incomingId = Convert.ToInt32(id);
            }
            catch(Exception)
            {
                return false;
            }
            var releasedBook = _booksBase.Where(book => book.id == incomingId);
            if(releasedBook.Count() != 1) return false;
            releasedBook.ElementAt(0).borrowedBy = "0";
            _UploadBase();
            return true;

        }
        public IEnumerable<Book> FindBook(string author, string title, string year)
        {
           return _booksBase.Where(book =>
                (author == "" || book.author == author) && (title == "" || book.title == title)
                && (year == "" || book.year == year));
        }
        public IEnumerable<Book> GetBooksBorrowedBy(string id)
        {
            return _booksBase.Where(book => book.borrowedBy == id);
        }
    }
}
