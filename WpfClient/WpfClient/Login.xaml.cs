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
using System.Windows.Shapes;

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        Client c;
        public Login()
        {
            InitializeComponent();
            c = new Client
            {
                BirthDate = DateTime.Parse("1/1/2006"),
                FirstName = "",
                LastName = "",
                UserName = "",
                Password = "",
                PhoneNumber = "",
                Email = ""
            };
            this.DataContext = c;
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            SignUp signUp = new SignUp();
            this.Close();
            signUp.ShowDialog();
        }
    }
}