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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfClient.APLService;

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for AdminUserStatus.xaml
    /// </summary>
    public partial class AdminUserStatus : UserControl
    {
        APLService.ServiceBaseClient serviceClient;
        User clickedUser;
        private AdminPage page;
        public AdminUserStatus(User user, AdminPage page)
        {
            InitializeComponent();
            serviceClient = new APLService.ServiceBaseClient();
            userItem.Header = user.UserName;
            clickedUser = user;
            this.page = page;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            serviceClient.DeleteUser(clickedUser);
            page.ShowUsers_Selected();

        }
    }
}
