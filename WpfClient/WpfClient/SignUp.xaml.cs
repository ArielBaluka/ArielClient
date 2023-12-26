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
using System.Windows.Shapes;
using WpfClient.APLService;

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>

    public partial class SignUp : Window
    {
        APLService.ServiceBaseClient serviceClient;
        private GroupList groups = new GroupList();
        Client c;
        public SignUp()
        {
            InitializeComponent();
            serviceClient = new APLService.ServiceBaseClient();
            c = new Client { BirthDate = DateTime.Parse("1/1/2006"), FirstName = "", LastName = "",
                UserName = "", Password = "", PhoneNumber = "", Email = ""};
            this.DataContext = c;
            groups = serviceClient.GetAllGroups();
            addGroups();
        }

        private void tbxPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ValidPassword valid = new ValidPassword();
            ValidationResult result = valid.Validate(tbxPassword.Password, null);

            if(!result.IsValid)
            {
                tbxPassword.BorderBrush = Brushes.Red;
                tbxPassword.BorderThickness = new Thickness(1);
                tbxPassword.ToolTip = result.ErrorContent;
            }
            else
            {
                tbxPassword.ToolTip = null;
                tbxPassword.ClearValue(Border.BorderBrushProperty);
            }
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ValidBirthDate valid = new ValidBirthDate();
            ValidationResult result = valid.Validate(SelDate.SelectedDate, null);
            if (!result.IsValid)
            {
                SelDate.ToolTip = result.ErrorContent;
                SelDate.BorderBrush = Brushes.Red;
            }
            else
            {
                SelDate.ToolTip = null;
                SelDate.ClearValue(Border.BorderBrushProperty);
            }
        }

        public void addGroups()
        {
            GroupComboBox.Items.Clear();
            GroupComboBox.DisplayMemberPath = "GroupName";
            GroupComboBox.ItemsSource = groups;
        }

        private void ClrBtn_Click(object sender, RoutedEventArgs e)
        {
            SelDate.SelectedDate = DateTime.Now;
            genderComboBox.SelectedValue = GroupComboBox.SelectedValue = " ";
            tbEM.Text = tbFN.Text = tbLN.Text = tbPN.Text = tbUN.Text = "";
            tbxPassword.Password = "";
        }

        private void SignUpBtn_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            user.PassWord = tbxPassword.Password;
            user.UserName = tbUN.Text;
            user.FirstName = tbFN.Text;
            user.LastName = tbLN.Text;
            user.EMAIL = tbEM.Text;
            user.BIRTHDATE = DateTime.Parse(SelDate.SelectedDate.ToString());
            user.Gender = ((string)((ComboBoxItem)genderComboBox.SelectedItem).Content == "Male");// male - true 
            user.FAVORITEGROUP = (Group)GroupComboBox.SelectedItem;
            if(serviceClient.InsertUser(user) == 1)
            {
                HomePage homePage = new HomePage();
                this.Close();
                homePage.ShowDialog();
            }
        }
        public Group FindGroupByName(string name)
        {
            foreach(Group grp in groups)
            {
                if (grp.GroupName == name) return grp;
            }
            return null;
        }

    }
}
