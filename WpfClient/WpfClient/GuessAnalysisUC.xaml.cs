using LiveCharts.Wpf;
using LiveCharts;
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

            foreach (Guess gue in guesses)
            {
                if (gue.ISDRAW)
                    drawCount++;
                if (gue.TEAMGUESSED.ID == game.HOMETEAM.ID)
                    HomeCount++;
                if (gue.TEAMGUESSED.ID == game.AWAYTEAM.ID)
                    AwayCount++;
            }
            Home.Values = new ChartValues<int> { HomeCount };
            Away.Values = new ChartValues<int> { AwayCount };
            Draw.Values = new ChartValues<int> { drawCount };
            Home.Title = game.HOMETEAM.GroupShortcut;
            Away.Title = game.AWAYTEAM.GroupShortcut;
            Teams.Text = game.HOMETEAM.GroupName + " VS " + game.AWAYTEAM.GroupName;
            PointLabel = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            DataContext = this;

        }

        public Func<ChartPoint, string> PointLabel { get; set; }

        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

            //clear selected slice.
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }
    }
}
