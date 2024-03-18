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
    /// Interaction logic for UserSettingsUC.xaml
    /// </summary>
    public partial class UserSettingsUC : UserControl
    {
        private User dataUser;
        private User saveUser;
        public UserSettingsUC(User user)
        {
            InitializeComponent();
            this.dataUser = user;
            this.DataContext = dataUser;

            saveUser = new User { UserName = user.UserName, PassWord = user.PassWord, EMAIL = user.EMAIL};   
        }

        private void ClrBtn_Click(object sender, RoutedEventArgs e)
        {
            dataUser.UserName = saveUser.UserName;
            dataUser.PassWord = saveUser.PassWord;
            dataUser.EMAIL = saveUser.EMAIL;
        }
    }
}
