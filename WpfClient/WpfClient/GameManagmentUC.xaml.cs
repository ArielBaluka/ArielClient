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
    /// Interaction logic for GameManagmentUC.xaml
    /// </summary>
    public partial class GameManagmentUC : UserControl
    {
        GameList gameLst;
        int gamesDisplayed;
        public GameManagmentUC(GameList games)
        {
            InitializeComponent();
            ServiceBaseClient client = new ServiceBaseClient();
            gameLst = games;
            for (int i = gameLst.Count() - 1; i > gameLst.Count() - 10; i--)
            {
                GamesSP.Children.Add(new GameResultUC(gameLst[i]));
            }
            gamesDisplayed = 10;
        }
        private void loadMoreBtn_Click(object sender, RoutedEventArgs e)
        {
            if(GroupTxt.Text == "")
            {
                int gamesToShow = gameLst.Count() - gamesDisplayed;
                int addedCount = 0;
                if (gamesToShow > 0)
                {
                    for (int i = gameLst.Count() - gamesDisplayed; i > gameLst.Count() - gamesDisplayed - Math.Min(gamesToShow, 10); i--)
                    {
                        GamesSP.Children.Add(new GameResultUC(gameLst[i]));
                        addedCount++;
                    }
                }
                gamesDisplayed += addedCount;
            }
            //else
            //{
            //    LoadFilterGames
            //}
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
                // Add MiniExerciseUC controls to the collection
                foreach (var game in xlist)
                {
                    if(count < lim)
                        GamesSP.Children.Add(new GameResultUC(game));
                    count++;
                }
            }
        }

        private void GroupTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Game> list = gameLst.FindAll(game => game.AWAYTEAM.GroupName.ToUpper().Contains(GroupTxt.Text.ToUpper().Trim()) ||
            game.HOMETEAM.GroupName.ToUpper().Contains(GroupTxt.Text.ToUpper().Trim()));

            LoadFilterGames(null, list, 10);

        }
    }
}
