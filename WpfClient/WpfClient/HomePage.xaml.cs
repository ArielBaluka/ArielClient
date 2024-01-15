using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Window
    {
        User client;
        APLService.ServiceBaseClient serviceClient;

        public HomePage(User user)
        {
            client = user;
            InitializeComponent();
            this.DataContext = user;
            welcomeTxt.Text += " " + user.UserName + "!";
            serviceClient = new APLService.ServiceBaseClient();

        }

        private void ButtonCloseApp_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void closeMenu()
        {
            ButtonAutomationPeer peer = new ButtonAutomationPeer(ButtonClose);
            IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
            invokeProv.Invoke();
            GridMain.Children.Clear();
        }
        private void RecentGames_Selected(object sender, RoutedEventArgs e)
        {
            ServiceBaseClient client = new ServiceBaseClient();
            GameList games = serviceClient.GetAllGames();
            closeMenu();
            for (int i = games.Count() -6; i < games.Count()-1; i++)
            {
                ItemsSP.Children.Add(new GameResultUC(games[i]));
            }
            welcomeTxt.Text = "RecentGames";
        }

        private void LeaderBoard_Selected(object sender, RoutedEventArgs e)
        {
            closeMenu();
            welcomeTxt.Text = "selected leaderboard";
        }

        private void MyGroup_Selected(object sender, RoutedEventArgs e)
        {
            closeMenu();
            GridMain.Children.Add(new MyGroupUC(client));
            GridMain.Visibility = Visibility.Visible;
            welcomeTxt.Text = "selected my group";
        }

        private void TopGuessers_Selected(object sender, RoutedEventArgs e)
        {
            closeMenu();
            welcomeTxt.Text = "selected top guessers";
        }

        private void Settings_Selected(object sender, RoutedEventArgs e)
        {
            closeMenu();

            welcomeTxt.Text = "selected settings";
        }

        private void UpcomingGames_Selected(object sender, RoutedEventArgs e)
        {
            closeMenu();
            GridMain.Children.Add(new UpcomingGameUC());
            GridMain.Visibility = Visibility.Visible;
            welcomeTxt.Text = "upcoming games";
        }
    }
}
