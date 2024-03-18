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
using WpfClient.APLService;

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        Client c;
        APLService.ServiceBaseClient serviceClient;
        private GroupList groups = new GroupList();
        public Login()
        {
            InitializeComponent();
            serviceClient = new APLService.ServiceBaseClient();
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

        private void tbxPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ValidPassword valid = new ValidPassword();
            ValidationResult result = valid.Validate(tbxPassword.Password, null);

            if (!result.IsValid)
            {
                tbxPassword.BorderBrush = Brushes.Red;
                tbxPassword.BorderThickness = new Thickness(1);
                tbxPassword.ToolTip = result.ErrorContent;
            }
            else
            {
                tbxPassword.ToolTip = null;
                tbxPassword.ClearValue(Border.BorderBrushProperty);
            }
        }
        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            user.PassWord = tbxPassword.Password;
            user.UserName = tbUN.Text;
            User loggedUser = serviceClient.Login(user);
            if(loggedUser != null)
            {
                if(loggedUser.ISADMIN)
                {
                    AdminPage adminPage = new AdminPage();
                    this.Close();
                    adminPage.ShowDialog();
                }
                else
                {
                    HomePage homePage = new HomePage(loggedUser);
                    this.Close();
                    homePage.ShowDialog();
                } 
            }
            else
                MessageBox.Show("Unable to login!", "Error");

        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            SignUp signUp = new SignUp();
            this.Close();
            signUp.ShowDialog();
        }
    }
}
