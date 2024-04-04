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
    /// Interaction logic for AllUsersUC.xaml
    /// </summary>
    public partial class AllUsersUC : UserControl
    {
        APLService.ServiceBaseClient serviceClient;
        private UserList users = new UserList();

        public AllUsersUC()
        {
            InitializeComponent();
            serviceClient = new APLService.ServiceBaseClient();
            users = serviceClient.GetAllUsers();
            //foreach(User user in users)
            //{
            //    user.BIRTHDATE = DateTime.Parse(user.BIRTHDATE.ToString("dd-MM-yyyy"));
            //}
            Users.ItemsSource = users;
        }
    }
}
