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

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for InsertGuessesUC.xaml
    /// </summary>
    public partial class InsertGuessesUC : UserControl
    {
        APLService.ServiceBaseClient serviceClient;
        public InsertGuessesUC()
        {
            InitializeComponent();
            serviceClient = new APLService.ServiceBaseClient();
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            int days = int.Parse((string)((ComboBoxItem)DaysCMB.SelectedItem).Content);
            serviceClient.InsertNewGames(days);
            MessageBox.Show("Added games successfuly", "Good Job");
        }
    }
}
