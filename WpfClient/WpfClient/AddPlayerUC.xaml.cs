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
    /// Interaction logic for AddPlayerUC.xaml
    /// </summary>
    public partial class AddPlayerUC : UserControl
    {
        APLService.ServiceBaseClient serviceClient;
        private GroupList groups = new GroupList();
        Player player;

        public AddPlayerUC()
        {
            InitializeComponent();
            serviceClient = new APLService.ServiceBaseClient();
            player = new Player { FirstName = "", LastName = "", IsCaptain = false, Number = 1 };
            this.DataContext = player;
            groups = serviceClient.GetAllGroups();
            addGroups();
        }
        public void addGroups()
        {
            GroupComboBox.Items.Clear();
            GroupComboBox.DisplayMemberPath = "GroupName";
            GroupComboBox.ItemsSource = groups;
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void AddPlayerBtn_Click(object sender, RoutedEventArgs e)
        {
            Player player = new Player();
            player.FirstName = tbFN.Text;
            player.LastName = tbLN.Text;
            player.IsCaptain = (bool)yesNoCheckBox.IsChecked;
            player.PlayerGroup = (Group)GroupComboBox.SelectedItem;
            player.Number = int.Parse(tbNUM.Text);
            if(!serviceClient.DoesPlayerExist(player))
            {
                serviceClient.InsertPlayer(player);
            }
            else
            {
                MessageBox.Show("this player already exist :(");
            }
        }

        private void GroupComboBox_Selected(object sender, RoutedEventArgs e)
        {
            Group g = (Group)GroupComboBox.SelectedItem;
            DecorateShirt(g);

        }
        private void DecorateShirt(Group g)
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

        private void tbNUM_TextChanged(object sender, TextChangedEventArgs e)
        {
            numDec.Text = tbNUM.Text;
        }
    }
}
