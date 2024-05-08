using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
using WpfClient.APLService;

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for AllUsersUC.xaml
    /// </summary>
    public partial class AllUsersUC : UserControl
    {
        APLService.ServiceBaseClient serviceClient;
        private UserList users = new UserList();
        private AdminPage page;

        public AllUsersUC(AdminPage page)
        {
            InitializeComponent();
            serviceClient = new APLService.ServiceBaseClient();
            users = serviceClient.GetAllUsers();
            Users.ItemsSource = users;
            this.page = page;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            User user = (sender as Button).Tag as User;
            if (user != null)
            {
                if (MessageBox.Show($"Delete {user.FirstName} {user.LastName}?", "😱", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    serviceClient.DeleteUser(user);
                    users = serviceClient.GetAllUsers();
                    Users.ItemsSource = users;
                }
            }
        }
    }
}

