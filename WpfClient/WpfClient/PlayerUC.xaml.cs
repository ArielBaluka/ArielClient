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
    /// Interaction logic for Player.xaml
    /// </summary>
    public partial class PlayerUC : UserControl
    {
        public PlayerUC(Player player)
        {
            InitializeComponent();
            numDec.Text = player.Number.ToString();
            if(player.PlayerGroup != null)
            {
                DecorateShirt(player.PlayerGroup);
                ChangerNumber(player.Number.ToString());
                ChangeName(player.LastName);
            }
        }

        public void ChangerNumber(string number)
        {
            numDec.Text = number;    
        }
        public void ChangeName(string name)
        {
            playerName.Text = name;
        }

        public void DecorateShirt(Group g)
        {
            string path = "pack://application:,,,/WpfClient;component/pictures/groups/" + (g.ID - 1).ToString() + ".png";
            groupPic.Source = new BitmapImage(new Uri(path));
            string GName = g.GroupName;
            if (GName == "Arsenal" || GName == "Bournemouth" || GName == "Liverpool" ||
                GName == "Manchester United" || GName == "Nottingham Forest" || GName == "Sheffield United")
            {
                Shirt1.Background = Brushes.Red;
                Shirt2.Fill = Brushes.Red;
                Shirt3.Fill = Brushes.Red;
            }
            if (GName == "Aston Villa" || GName == "Burnley" || GName == "West Ham United")
            {
                Shirt1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#5F021F"));
                Shirt2.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#5F021F"));
                Shirt3.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#5F021F"));
            }
            if (GName == "Manchester City" || GName == "Newcastle United")
            {
                Shirt1.Background = Brushes.LightBlue;
                Shirt2.Fill = Brushes.LightBlue;
                Shirt3.Fill = Brushes.LightBlue;
            }
            if (GName == "Brighton" || GName == "Crystal Palace" || GName == "Everton")
            {
                Shirt1.Background = Brushes.Blue;
                Shirt2.Fill = Brushes.Blue;
                Shirt3.Fill = Brushes.Blue;
            }
            switch (GName)
            {
                case "Chelsea":
                    Shirt1.Background = Brushes.DarkBlue;
                    Shirt2.Fill = Brushes.DarkBlue;
                    Shirt3.Fill = Brushes.DarkBlue;
                    break;
                case "Fulham":
                    Shirt1.Background = Brushes.White;
                    Shirt2.Fill = Brushes.White;
                    Shirt3.Fill = Brushes.White;
                    break;
                case "Luton Town":
                    Shirt1.Background = Brushes.Orange;
                    Shirt2.Fill = Brushes.Orange;
                    Shirt3.Fill = Brushes.Orange;
                    break;
                case "Tottenham Hotspur":
                    Shirt1.Background = Brushes.Gray;
                    Shirt2.Fill = Brushes.Gray;
                    Shirt3.Fill = Brushes.Gray;
                    break;
                case "Wolverhampton Wanderers":
                    Shirt1.Background = Brushes.Yellow;
                    Shirt2.Fill = Brushes.Yellow;
                    Shirt3.Fill = Brushes.Yellow;
                    break;
                default:
                    break;
            }
        }
    }
}
