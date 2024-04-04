using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfClient.APLService;
using MessageBox = System.Windows.Forms.MessageBox;
using UserControl = System.Windows.Controls.UserControl;

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for UserSettingsUC.xaml
    /// </summary>
    public partial class UserSettingsUC : UserControl
    {
        private User dataUser;
        private User saveUser;
        private HomePage parent;
        APLService.ServiceBaseClient serviceClient;

       public UserSettingsUC(User user, HomePage home)
        {
            InitializeComponent();
            parent = home;
            this.dataUser = user;
            this.DataContext = dataUser;
            serviceClient = new APLService.ServiceBaseClient();
            saveUser = new User { UserName = user.UserName, PassWord = user.PassWord, EMAIL = user.EMAIL};   
        }

        private void ClrBtn_Click(object sender, RoutedEventArgs e)
        {
            dataUser.UserName = saveUser.UserName;
            dataUser.PassWord = saveUser.PassWord;
            dataUser.EMAIL = saveUser.EMAIL;
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (dataUser.UserName != saveUser.UserName && dataUser.PassWord != saveUser.PassWord
                && dataUser.EMAIL != dataUser.EMAIL)
            {
                serviceClient.UpdateUser(dataUser);
                MessageBox.Show("user updated!");
            }
            else
            {
                MessageBox.Show("nothing has changed");
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = (MessageBoxResult)MessageBox.Show("Are you sure that you want to delete the account?", "Confirmation", MessageBoxButtons.YesNo);
            if(res == MessageBoxResult.Yes)
            {
                serviceClient.DeleteUser(dataUser);
                parent.GoToHomePage();
            }
        }
    }
}
