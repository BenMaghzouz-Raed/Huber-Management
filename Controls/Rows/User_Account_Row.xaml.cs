using System;
using System.Collections.Generic;
using System.Data.SQLite;
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

namespace Huber_Management.Controls
{
    /// <summary>
    /// Interaction logic for User_Account_Row.xaml
    /// </summary>
    public partial class User_Account_Row : UserControl
    {
        public User_Account_Row(users_c user)
        {
            InitializeComponent();
            InitializeOneRow(user);
        }

        public void InitializeOneRow(users_c user)
        {
            this.user_name.Content = user.user_name;
            this.user_fullname.Content = user.user_fullName;

            string[] date = user.user_added_date.ToString().Split(null);
            this.user_added_time.Content = date[0];

            if(user.user_added_date == user.last_login)
            {
                this.user_last_login_date.Content = "Never Logged In";
                this.user_last_login_time.Content = "-";
            }
            else
            {
                string[] Logindate = user.last_login.ToString().Split(null);
                this.user_last_login_date.Content = Logindate[0];
                this.user_last_login_time.Content = Logindate[1];
            }

            if (!user.IsAdmin)
            {
                privilege_text.Content = user.privileges_id;
                privilege_icon.Data = Geometry.Parse("M12,4A4,4 0 0,1 16,8A4,4 0 0,1 12,12A4,4 0 0,1 8,8A4,4 0 0,1 12,4M12,14C16.42,14 20,15.79 20,18V20H4V18C4,15.79 7.58,14 12,14Z");
                privilege_icon.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom("#91A6B1");
            }

            if (user.isConnected)
            {
                is_connected.Visibility = Visibility.Visible;
                user_last_login.Visibility = Visibility.Collapsed;
            }
        }

        public void Tool_row_element_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                return;
            }
            return;
        }

        private void MenuItem_Delete_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection conn = Database_c.Get_DB_Connection();
            string user_name = this.user_name.Content.ToString();
            MessageBoxResult dialogResult = MessageBox.Show("Are you sure that you want to permanently Delete " + user_name + " account ?", "Delete " + user_name + " ?", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            
            if (dialogResult == MessageBoxResult.Yes)
            {
                users_c.Delete_by_user_name(user_name, conn);

            }
            Database_c.Close_DB_Connection();
        }

        private void MenuItem_EditUser_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
