using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
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
    /// Interaction logic for PlayersUC.xaml
    /// </summary>
    public partial class PlayersUC : UserControl
    {
        APLService.ServiceBaseClient serviceClient;

        public PlayersUC(Group group)
        {
            InitializeComponent();
            serviceClient = new APLService.ServiceBaseClient();
            PlayerList players = serviceClient.GetPlayersByGroup(group);

            foreach(Player p in players)
            {
                PlayersSP.Children.Add(new PlayerUC(p));
            }
        }

        public PlayersUC(User user)
        {
            InitializeComponent();
            serviceClient = new APLService.ServiceBaseClient();
            PlayerList players = serviceClient.GetPlayersByUser(user);

            foreach (Player p in players)
            {
                PlayersSP.Children.Add(new PlayerUC(p));
            }
        }
    }
}
