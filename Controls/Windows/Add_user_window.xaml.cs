using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace Huber_Management.Controls
{
    /// <summary>
    /// Interaction logic for Add_user_window.xaml
    /// </summary>
    public partial class Add_user_window : Window
    {
        public Add_user_window()
        {
            InitializeComponent();
        }

        private static string SelectedPrivilege { get; set; }
        /// <summary>
        /// Confirm the adding of one tool
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Add_new_user_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection conn = Database_c.Get_DB_Connection();
            string userName = string.Join(" ", user_name_add.Text.ToString().Split().Where(x => x != ""));

            if (userName == "")
            {
                MessageBox.Show("The User Name field is empty!", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (users_c.isExist_user_name(userName, conn))
            {
                MessageBox.Show("This User Name '" + userName + "' already exist!", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                string password = password_add.Password.ToString();

                if ( password.Length < 6)
                {
                    MessageBox.Show("Your password is too short! you need at least 6 characters", "Error Password", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (password != password_confirm_add.Password.ToString())
                {
                    MessageBox.Show("Check your password again!", "Error Password", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {

                    if (SelectedPrivilege == null || SelectedPrivilege == "")
                    {
                        MessageBox.Show("Please select a privilege for the new user !", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    else
                    {
                        try
                        {
                            // Add user to Users database
                            string Query = "INSERT INTO Users (User_name, User_fullname, User_password, IsAdmin, Privileges_id, User_added_date, last_login) " +
                                           "VALUES (@User_name, @User_fullname, @User_password, @IsAdmin, @Privileges_id, DATETIME('now', 'localtime'), DATETIME('now', 'localtime') )";

                            SQLiteCommand command = new SQLiteCommand(Query, conn);

                            command.Parameters.AddWithValue("@User_name", userName);

                            command.Parameters.AddWithValue("@User_fullname", full_name_add.Text.ToString());

                            command.Parameters.AddWithValue("@User_password", password_add.Password.ToString());

                            bool isAdmin = SelectedPrivilege == "Admin";
                            command.Parameters.AddWithValue("@IsAdmin", isAdmin);

                            command.Parameters.AddWithValue("@Privileges_id", SelectedPrivilege);

                            await Task.Run(() => command.ExecuteNonQuery());
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                            Database_c.Close_DB_Connection();
                            return;
                        }
                        Database_c.Close_DB_Connection();
                        MessageBox.Show(SelectedPrivilege + " Account with the UserName: '" + userName + "' Created successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        if (MainWindow._Settings_page != null)
                        {
                            MainWindow._Settings_page.NavigationService.Refresh();
                        }
                        this.Close();
                    }

                }
            }
            Database_c.Close_DB_Connection();
        }

        private void Cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void setSelectedPrivilege(object sender, RoutedEventArgs e)
        {
            SelectedPrivilege = ((RadioButton)sender).Name.ToString();
        }
    }
}
