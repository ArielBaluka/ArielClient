using System;
using System.Collections;
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
    /// Interaction logic for GameManagmentUC.xaml
    /// </summary>
    public partial class GameManagmentUC : UserControl
    {

        GameList gameLst;
        GameList DisplayLst;
        int gamesDisplayed;
        public GameManagmentUC(GameList games)
        {
            InitializeComponent();
            games = OrderGamesByDateDec(games);
            ServiceBaseClient client = new ServiceBaseClient();
            DisplayLst = new GameList();
            gameLst = games;
            gamesDisplayed = 10;
            for (int i = 0; i < gamesDisplayed; i++)
                DisplayLst.Add(games[games.Count() - 1 - i]);

            foreach (Game game in DisplayLst)
            {
                GameResultUC match = new GameResultUC(game);
                match.MouseUp += Match_MouseUp;
                GamesSP.Children.Add(match);
            }
        }

        private void Match_MouseUp(object sender, MouseButtonEventArgs e)
        {///////////////////////////////////////////////////////////////////
            GameResultUC match = sender as GameResultUC;
             //match.gameID;
            MessageBox.Show("clicked a game");
        }

        private void loadMoreBtn_Click(object sender, RoutedEventArgs e)
        {
            if(GroupTxt.Text == "")
            {
                showGames(gameLst);
            }
            else
            {
                showGames(DisplayLst);
            }
        }

        private void showGames(GameList lst)
        {
            int gamesToShow = lst.Count() - gamesDisplayed;
            int addedCount = 0;
            if (gamesToShow > 0)
            {
                for (int i = lst.Count() - gamesDisplayed - 1; i > lst.Count() - gamesDisplayed - Math.Min(gamesToShow, 10) - 1; i--)
                {
                    GamesSP.Children.Add(new GameResultUC(lst[i]));
                    addedCount++;
                }
            }
            gamesDisplayed += addedCount;
        }

        private void LoadFilterGames(GameList list, List<Game> xlist, int lim)
        {
            GamesSP.Children.Clear();
            if (list != null)
            {
                // Add MiniExerciseUC controls to the collection
                foreach (var game in list)
                    GamesSP.Children.Add(new GameResultUC(game));
            }
            if (xlist != null)
            {
                int count = 0;
                DisplayLst = new GameList();
                foreach (var x in xlist)
                {
                    DisplayLst.Add(x);
                }
                for (int i = xlist.Count - 1; i >= 0; i--)
                {
                    Game game = xlist[i];
                    if (count < lim)
                    {
                        GamesSP.Children.Add(new GameResultUC(game));
                        count++;
                    }
                }
                gamesDisplayed = 10;
            }
        }

        private void GroupTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Game> list = gameLst.FindAll(game => game.AWAYTEAM.GroupName.ToUpper().Contains(GroupTxt.Text.ToUpper().Trim()) ||
            game.HOMETEAM.GroupName.ToUpper().Contains(GroupTxt.Text.ToUpper().Trim()));
            gamesDisplayed = 0; // reset games displayed to minimum value
            LoadFilterGames(null, list, 10);

        }

        private GameList OrderGamesByDateDec(GameList games)
        {
            List<Game> xlist = new List<Game>();
            foreach (var x in games)
            {
                xlist.Add(x);
            }
            var orderedList = xlist.OrderBy(obj => obj.Date).ToList();
            games = new GameList();
            foreach (var x in orderedList)
            {
                games.Add(x);
            }
            return games;
        }

    }
}
