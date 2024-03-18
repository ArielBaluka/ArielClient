using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Window
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void closeMenu()
        {
            ButtonAutomationPeer peer = new ButtonAutomationPeer(ButtonClose);
            IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
            invokeProv.Invoke();
            GridMain.Children.Clear();
        }
        private void ShowUsers_Selected(object sender, RoutedEventArgs e)
        {
            closeMenu();
            AllUsersUC UsersUC = new AllUsersUC();
            GridMain.Children.Add(UsersUC);
            GridMain.Visibility = Visibility.Visible;
        }

        private void InsertGameResults_Selected(object sender, RoutedEventArgs e)
        {
            
        }
        private void InsertGuesses_Selected(object sender, RoutedEventArgs e)
        {
            closeMenu();
            InsertGuessesUC UCGuess = new InsertGuessesUC();
            GridMain.Children.Add(UCGuess);
            GridMain.Visibility = Visibility.Visible;
        }
        private void Players_Selected(object sender, RoutedEventArgs e)
        {
            closeMenu();
            AddPlayerUC Player = new AddPlayerUC();
            Player.Height = 300;
            Player.Width = 800;
            GridMain.Children.Add(Player);
            GridMain.Visibility = Visibility.Visible;
            welcomeTxt.Text = "selected Players";
        }
        private void ButtonCloseApp_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
