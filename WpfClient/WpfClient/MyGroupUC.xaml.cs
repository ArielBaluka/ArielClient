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
    /// Interaction logic for MyGroupUC.xaml
    /// </summary>
    public partial class MyGroupUC : UserControl
    {
        public MyGroupUC(User user)
        {
            InitializeComponent();
            DecoratePage(user);
        }

        private void DecoratePage(User user)
        {
            string GName = user.FAVORITEGROUP.GroupName;
            string path = "pack://application:,,,/WpfClient;component/pictures/groups/" + (user.FAVORITEGROUP.ID-1).ToString() + ".png";
            NameTxt.Text = Name;
            groupPic.Source = new BitmapImage(new Uri(path));

            if(GName == "Arsenal" || GName == "Bournemouth" || GName == "Liverpool" || 
                GName == "Manchester United" || GName == "Nottingham Forest" || GName == "Sheffield United")
            {
                GroupRow.Background = Brushes.Red;
            }
            if(GName == "Aston Villa" || GName == "Burnley" || GName == "West Ham United")
            {
                GroupRow.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#5F021F"));
            }
            if (GName == "Manchester City" || GName == "Newcastle United")
            {
                GroupRow.Background = Brushes.LightBlue;
            }
            if (GName == "Brighton" || GName == "Crystal Palace" || GName == "Everton")
            {
                GroupRow.Background = Brushes.Blue;
            }
            switch (user.FAVORITEGROUP.GroupName)
            {
                case "Chelsea":
                    GroupRow.Background = Brushes.DarkBlue;
                    break;
                case "Fulham":
                    GroupRow.Background = Brushes.White;
                    break;
                case "Luton Town":
                    GroupRow.Background = Brushes.Orange;
                    break;
                case "Tottenham Hotspur":
                    GroupRow.Background = Brushes.Gray;
                    break;
                case "Wolverhampton Wanderers":
                    GroupRow.Background = Brushes.Yellow;
                    break;
                default:
                    break;

            }


            ServiceBaseClient service = new ServiceBaseClient();
            dataTxT.Text = service.GetGroupData(user.FAVORITEGROUP);


        }
    }
}
