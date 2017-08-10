﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;

namespace Library
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        JSONBaseHandler db;
        public MainWindow()
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
            ListOfBooks ls = new ListOfBooks();
            foreach(var book in result)
            {
                ls.booksListView.Items.Add(book);
            }
            ls.Show();
        }
    }
}
