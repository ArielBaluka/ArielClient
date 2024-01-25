using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for UpcomingGameUC.xaml
    /// </summary>
    public partial class UpcomingGameUC : UserControl
    {
        Game match;
        APLService.ServiceBaseClient serviceClient;
        User client;
        public UpcomingGameUC(Game game, User user)
        {
            InitializeComponent();

            string HName = game.HOMETEAM.GroupName;
            string AName = game.AWAYTEAM.GroupName;
            int Hscore = game.HOMESCORE;
            int Ascore = game.AWAYSCORE;
            string Hpath = "pack://application:,,,/WpfClient;component/pictures/groups/" + (game.HOMETEAM.ID - 1).ToString() + ".png";
            string Apath = "pack://application:,,,/WpfClient;component/pictures/groups/" + (game.AWAYTEAM.ID - 1).ToString() + ".png";
            hgroupPic.Source = new BitmapImage(new Uri(Hpath));
            agroupPic.Source = new BitmapImage(new Uri(Apath));
            serviceClient = new APLService.ServiceBaseClient();
            GropABtn.Content = HName;
            GroupBBtn.Content = AName;
            DateTxT.Text = game.Date.ToShortDateString();
            match = game;
            client = user;
        }

        private void Guess_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            string buttonContent = clickedButton.Content.ToString();
            
            Group group =buttonContent.Equals(match.AWAYTEAM.GroupName)? match.AWAYTEAM: match.HOMETEAM;
            Guess guess = new Guess();
            guess.ISCORRECT = false;
            guess.GAME = match;
            guess.USER = client;
            guess.ISDRAW = buttonContent == "Draw";
            if (!guess.ISDRAW)
                guess.TEAMGUESSED = group;
            else
                guess.TEAMGUESSED = null;


            serviceClient.DeleteGuess(guess);
            serviceClient.InsertGuess(guess);
        }
    }
}
