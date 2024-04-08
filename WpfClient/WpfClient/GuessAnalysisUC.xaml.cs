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
    /// Interaction logic for GuessAnalysisUC.xaml
    /// </summary>
    public partial class GuessAnalysisUC : UserControl
    {
        public GuessAnalysisUC(Game game)
        {
            InitializeComponent();
            ServiceBaseClient service = new ServiceBaseClient();
            GuessList guesses = service.GetGuessesByGame(game);
            int total = guesses.Count;
            int drawCount = 0, HomeCount = 0, AwayCount = 0;
            int drawHeight = 0, HomeHeight = 0, AwayHeight = 0;

            foreach (Guess gue in guesses)
            {
                if (gue.ISDRAW)
                    drawCount++;
                if (gue.TEAMGUESSED.ID == game.HOMETEAM.ID)
                    HomeCount++;
                if (gue.TEAMGUESSED.ID == game.AWAYTEAM.ID)
                    AwayCount++;
            }

            if (drawCount > 0)
                drawHeight = (int)((drawCount*1.0 / total) * 100);
            else
                drawHeight = 1;
            if (HomeCount > 0)
                HomeHeight = (int)((HomeCount*1.0 / total) * 100);
            else
                HomeHeight = 1;
            if (AwayCount > 0)
                AwayHeight = (int)((AwayCount*1.0 / total) * 100);
            else
                AwayHeight = 1;

            HomeRec.Height = HomeHeight;
            AwayRec.Height = AwayHeight;
            DrawRec.Height = drawHeight;

            Teams.Text = game.HOMETEAM.GroupName + " VS " + game.AWAYTEAM.GroupName;

            HomeTxt.Text = game.HOMETEAM.GroupShortcut;
            AwayTxt.Text = game.AWAYTEAM.GroupShortcut;
        }
    }
}
