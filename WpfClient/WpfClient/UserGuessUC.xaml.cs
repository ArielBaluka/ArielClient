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
    /// Interaction logic for UserGuessUC.xaml
    /// </summary>
    public partial class UserGuessUC : UserControl
    {
        APLService.ServiceBaseClient serviceClient;
        User client;
        public UserGuessUC(User user, int score, bool isTop)
        {
            InitializeComponent();
            string path = "pack://application:,,,/WpfClient;component/pictures/groups/" + (user.FAVORITEGROUP.ID - 1).ToString() + ".png";
            groupPic.Source = new BitmapImage(new Uri(path));
            userTxT.Text += user.UserName;            
            pointsTxT.Text += score.ToString();

            if (!isTop || score ==0)
                SetNonTopBackground();
        }
        private void SetNonTopBackground()
        {
            // Create a LinearGradientBrush
            LinearGradientBrush gradientBrush = new LinearGradientBrush();

            // Set StartPoint and EndPoint
            gradientBrush.StartPoint = new Point(0, 0);
            gradientBrush.EndPoint = new Point(1, 1);

            // Add GradientStops
            gradientBrush.GradientStops.Add(new GradientStop(Color.FromRgb(192, 192, 192), 0.9)); // Silver
            gradientBrush.GradientStops.Add(new GradientStop(Color.FromRgb(128, 128, 128), 0.3)); // Grey
            gradientBrush.GradientStops.Add(new GradientStop(Color.FromRgb(192, 192, 192), 0.1)); // Silver

            // Set the Background of your Grid to the LinearGradientBrush
            GridUser.Background = gradientBrush;
        }
    }
}
