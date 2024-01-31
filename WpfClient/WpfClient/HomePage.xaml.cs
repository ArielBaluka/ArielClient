using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        GameList gameResults;
        GameList futureGames;
        GameList games;
        public HomePage(User user)
        {
            client = user;
            InitializeComponent();
            this.DataContext = user;
            welcomeTxt.Text += " " + user.UserName + "!";
            serviceClient = new APLService.ServiceBaseClient();
            games = serviceClient.GetAllGames();

            gameResults = GetGameResults();
            futureGames = GetGuessGames();
        }

        public GameList GetGameResults()
        {
            GameList gameres = new GameList();
            foreach (Game game in games)
            {
                if(game.AWAYSCORE != -1)
                {
                    gameres.Add(game);
                }
            }
            return gameres;
        }

        public GameList GetGuessGames()
        {
            GameList gameres = new GameList();
            foreach (Game game in games)
            {
                if (game.AWAYSCORE == -1)
                {
                    gameres.Add(game);
                }
            }
            return gameres;
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

            closeMenu();
            GridMain.Children.Add(new GameManagmentUC(gameResults));
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
            MyGroupUC myGroupUC = new MyGroupUC(client);
            myGroupUC.Height = ActualHeight * 0.9;
            GridMain.Children.Add(myGroupUC);
            GridMain.Visibility = Visibility.Visible;
            welcomeTxt.Text = "selected my group";
        }


        private void TopGuessers_Selected(object sender, RoutedEventArgs e)
        {
            closeMenu();

            GridMain.Children.Add(new GuessersControlUC());
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

            GridMain.Children.Add(new GuessManegmentUC(futureGames, client));
            GridMain.Visibility = Visibility.Visible;

            welcomeTxt.Text = "upcoming games";
        }
    }
}
