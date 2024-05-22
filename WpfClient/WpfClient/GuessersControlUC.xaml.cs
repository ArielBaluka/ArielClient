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
    /// Interaction logic for GuessersControlUC.xaml
    /// </summary>
    public partial class GuessersControlUC : UserControl
    {
        APLService.ServiceBaseClient serviceClient;
        UserList users;
        public GuessersControlUC()
        {
            InitializeComponent();
            ServiceBaseClient client = new ServiceBaseClient();
            Dictionary<User, int> userScore = new Dictionary<User, int>();
            serviceClient = new APLService.ServiceBaseClient();
            users = client.GetAllUsers();
            foreach (User u in users)
            {
                int points = serviceClient.CalculateUserPoint(u);
                userScore.Add(u, points);
            }
            Dictionary<User, int> SortedUserScore = SortDictionaryByValue(userScore);//משתמש ונקודות
            int count = 0;
            foreach(var uscore in SortedUserScore)
            {
                if(count < 3)
                    GuesserSP.Children.Add(new UserGuessUC(uscore.Key, uscore.Value, true));
                else
                    GuesserSP.Children.Add(new UserGuessUC(uscore.Key, uscore.Value, false));
                count++;
            }
        }

        static Dictionary<User, int> SortDictionaryByValue(Dictionary<User, int> dictionary)
        {
            // Convert the dictionary to a list of key-value pairs
            var list = dictionary.ToList();

            // Sort the list based on the values
            list.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));

            // Create a new dictionary from the sorted list
            Dictionary<User, int> sortedDictionary = new Dictionary<User, int>();
            foreach (var pair in list)
            {
                sortedDictionary.Add(pair.Key, pair.Value);
            }

            return sortedDictionary;
        }

    }
}
