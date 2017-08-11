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

        private void loginClientButton_Click(object sender, RoutedEventArgs e)
        {
            ClientInterface client = new ClientInterface(db, loginTextBox.Text);
            client.Show();
        }

        private void loginAdminButton_Click(object sender, RoutedEventArgs e)
        {
            AdminInterface admin = new AdminInterface(db);
            admin.Show();
        }
    }
}