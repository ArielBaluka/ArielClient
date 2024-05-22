using System;
using System.Collections.Generic;
using System.Data;
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
using WpfClient.ClientNewsService;

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for AddPlayerUC.xaml
    /// </summary>
    public partial class AddPlayerUC : UserControl
    {
        APLService.ServiceBaseClient serviceClient;
        private GroupList groups = new GroupList();
        Player player;
        PlayerUC playerUC;
        public AddPlayerUC()
        {
            InitializeComponent();
            serviceClient = new APLService.ServiceBaseClient();
            player = new Player { FirstName = "", LastName = "", IsCaptain = false, Number = 1 };
            this.DataContext = player;
            groups = serviceClient.GetAllGroups();
            playerUC = new PlayerUC(player);
            playercard.Children.Add(playerUC);
            addGroups();
        }
        public void addGroups()
        {
            GroupComboBox.Items.Clear();
            GroupComboBox.DisplayMemberPath = "GroupName";
            GroupComboBox.ItemsSource = groups;
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void AddPlayerBtn_Click(object sender, RoutedEventArgs e)
        {
            Player player = new Player();
            player.FirstName = tbFN.Text;
            player.LastName = tbLN.Text;
            player.IsCaptain = (bool)yesNoCheckBox.IsChecked;
            player.PlayerGroup = (Group)GroupComboBox.SelectedItem;
            player.Number = int.Parse(tbNUM.Text);
            if(!serviceClient.DoesPlayerExist(player))
            {
                serviceClient.InsertPlayer(player);
            }
            else
            {
                MessageBox.Show("this player already exist :(");
            }
        }

        private void GroupComboBox_Selected(object sender, RoutedEventArgs e)
        {
            Group g = (Group)GroupComboBox.SelectedItem;
            playerUC.DecorateShirt(g);

        }
        
        private void tbNUM_TextChanged(object sender, TextChangedEventArgs e)
        {
            playerUC.ChangerNumber(tbNUM.Text);
        }

        private void tbLN_TextChanged(object sender, TextChangedEventArgs e)
        {
            playerUC.ChangeName(tbLN.Text);
        }
    }
}
