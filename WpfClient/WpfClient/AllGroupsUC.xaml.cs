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
    /// Interaction logic for AllGroupsUC.xaml
    /// </summary>
    public partial class AllGroupsUC : UserControl
    {
        APLService.ServiceBaseClient serviceClient;
        private GroupList groups = new GroupList();
        public AllGroupsUC()
        {
            InitializeComponent();
            serviceClient = new APLService.ServiceBaseClient();
            groups = serviceClient.GetAllGroupsByPoints();
            Groups.ItemsSource = groups;
        }
    }
}
