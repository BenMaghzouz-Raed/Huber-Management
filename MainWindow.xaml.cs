using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;


namespace Huber_Management
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static users_c Connected_user { get; set; } = null;
        public static App_settings_c Default_settings { get; set; } = null;
        public static Pages.All_tools_page _All_tools_page { get; set; } = null;
        public static Pages.Faulty_Tools_page _Faulty_Tools_page { get; set; } = null;
        public static Pages.Output_page _Output_page { get; set; } = null;
        public static Pages.Purchase_order_page _Purchase_order_page { get; set; } = null;
        public static Pages.Reception_page _Reception_page { get; set; } = null;
        public static Pages.Repaired_Tools_page _Repaired_Tools_page { get; set; } = null;
        public static Pages.Settings_page _Settings_page { get; set; } = null;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Logout()
        {
            SQLiteConnection conn = Database_c.Get_DB_Connection();

            string Query = "UPDATE Users SET last_login = DATETIME('now', 'localtime'), isConnected = 0 WHERE User_name = '" + Connected_user.user_name + "' ";
            SQLiteCommand command = new SQLiteCommand(Query, conn);
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

        private void SideBar_checkbox_Click_2(object sender, RoutedEventArgs e)
        {
            RadioButton ClickedButton = sender as RadioButton;

            if (Main_container != null)
            {
                Uri myUri = new Uri(ClickedButton.Uid, UriKind.Relative);
                Main_container.NavigationService.Navigate(myUri);
            }
        }

        private void SideBar_checkbox_Click(object sender, RoutedEventArgs e)
        {
            RadioButton PageRadioButton = sender as RadioButton;
            string PageName = PageRadioButton.Content.ToString();
            _All_tools_page = null;
            _Faulty_Tools_page = null;
            _Output_page = null;
            _Purchase_order_page = null;
            _Reception_page = null;
            _Repaired_Tools_page = null;
            _Settings_page = null;

            if (Main_container != null)
            {
                switch (PageName)
                {
                    case "All Tools":
                        _All_tools_page = new Pages.All_tools_page();
                        Main_container.Content = _All_tools_page;
                        break;
                    case "Reception":
                        _Reception_page = new Pages.Reception_page();
                        Main_container.Content = _Reception_page;
                        break;
                    case "Output":
                        _Output_page = new Pages.Output_page();
                        Main_container.Content = _Output_page;
                        break;
                    case "Purchase Order":
                        _Purchase_order_page = new Pages.Purchase_order_page();
                        Main_container.Content = _Purchase_order_page;
                        break;
                    case "Defective Tools":
                        _Faulty_Tools_page = new Pages.Faulty_Tools_page();
                        Main_container.Content = _Faulty_Tools_page;
                        break;
                    case "Repaired Tools":
                        _Repaired_Tools_page = new Pages.Repaired_Tools_page();
                        Main_container.Content = _Repaired_Tools_page;
                        break;
                    case "Settings":
                        _Settings_page = new Pages.Settings_page();
                        Main_container.Content = _Settings_page;
                        break;
                    default:
                        break;
                }
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
            SQLiteConnection conn = Database_c.Get_DB_Connection();
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
