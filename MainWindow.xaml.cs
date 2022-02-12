using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using ExcelDataReader;
using Microsoft.Win32;

namespace Huber_Management
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static users_c Connected_user { get; set; } = null;
        public static App_settings_c Default_settings { get; set; } = null;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Logout()
        {
            SqlConnection conn = Database_c.Get_DB_Connection();

            string Query = "UPDATE Users SET last_login = getdate(), isConnected = 0 WHERE User_name = '" + Connected_user.user_name + "' ";
            SqlCommand command = new SqlCommand(Query, conn);
            command.ExecuteNonQuery();

            Database_c.Close_DB_Connection();
        }

        private void Logout_btn_Checked(object sender, RoutedEventArgs e)
        {
            Logout();
            Login Login_w = new Login();
            Login_w.Show();
            this.Close();
        }

        private void SideBar_checkbox_Click(object sender, RoutedEventArgs e)
        {
            RadioButton ClickedButton = sender as RadioButton;

            if( Main_container != null)
            {
                Uri myUri = new Uri(ClickedButton.Uid, UriKind.Relative);
                Main_container.NavigationService.Navigate(myUri);
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Main_container.Content = new Pages.Dashboard_page();
            if(Connected_user == null)
            {
                Logout_btn_Checked(sender, e);
            }
            else
            {
                user_full_name.Text = Connected_user.user_fullName;
                if (Connected_user.IsAdmin)
                {
                    Privilege.Content = "Admin";
                }
                else
                {
                    Privilege.Content = Connected_user.privileges_id;
                    settings_button.IsEnabled = false;
                    settings_button.Visibility = Visibility.Collapsed;
                }

            }
            SqlConnection conn = Database_c.Get_DB_Connection();
            DataTable app_settings_table = App_settings_c.getAllDefaultSettings(conn);

            App_settings_c default_settings = new App_settings_c
            {
                Euro_to_dt_value = decimal.Parse(app_settings_table.Rows[0]["Euro_to_dt_value"].ToString()),
                Criticality_A_value = int.Parse(app_settings_table.Rows[0]["Criticality_A_value"].ToString()),
                Criticality_B_value = int.Parse(app_settings_table.Rows[0]["Criticality_B_value"].ToString()),
                Criticality_C_value = int.Parse(app_settings_table.Rows[0]["Criticality_C_value"].ToString()),
            };
            MainWindow.Default_settings = default_settings;
            Database_c.Close_DB_Connection();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Logout();
            this.Close();
        }
    }
}
