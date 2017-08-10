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
        }
        public void AddBook(string author, string title, string year)
        {
            _booksBase.Add(new Book(title, author, year, ++_maxIdxValue));
            _UploadBase();
        }
        public void DeleteBook(Book toDelete)
        {
            _booksBase = _booksBase.Where(book => book != toDelete).ToList();
            _UploadBase();
        }
        public IEnumerable<Book> FindBook(string author, string title, string year)
        {
           return _booksBase.Where(book =>
                (author == "" || book.author == author) && (title == "" || book.title == title)
                && (year == "" || book.year == year));
            

        }
    }
}
