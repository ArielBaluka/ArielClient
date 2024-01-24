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
    /// Interaction logic for UpcomingGameUC.xaml
    /// </summary>
    public partial class UpcomingGameUC : UserControl
    {
        public UpcomingGameUC(Game game)
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

            GropABtn.Content = HName;
            GroupBBtn.Content = AName;
            DateTxT.Text = game.Date.ToShortDateString();
        }
    }
}
