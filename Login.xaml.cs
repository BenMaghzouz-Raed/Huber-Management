using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Data.SqlClient;

namespace Huber_Management
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_btn_Click(object sender, RoutedEventArgs e)
        {
            String user_input = user_name.Text.ToString();
            String pass_input = password.Password.ToString();

            DataTable Result = users_c.Get_by_name(user_input);

            if (Result.Rows.Count != 1)
            {
                // CREATE AN ERROR
                MessageBox.Show("This Username doesn't exist !", "wrong username", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                if (pass_input != Result.Rows[0]["User_password"].ToString())
                {
                    // CREATE AN ERROR
                    MessageBox.Show("Wrong Password ! please try again", "wrong password", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {   // CREATE A SUCCESS
                    SqlConnection conn = Database_c.Get_DB_Connection();
                    string UpdateQuery = "UPDATE Users SET isConnected = 1 WHERE User_name = @User_name ";

                    SqlCommand command = new SqlCommand(UpdateQuery, conn);
                    command.Parameters.Add(new SqlParameter("@User_name", user_input));
                    command.ExecuteNonQuery();

                    // SELECT CONNECTED USER INFORMATIONS
                    string Selectquery = "SELECT * FROM Users, Privileges WHERE User_name = '" + user_input + "' AND Users.Privileges_id = Privileges.Privilege_name ";
                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(Selectquery, conn);
                    adapter.Fill(table);

                    users_c connected_user = new users_c
                    {
                        user_name = table.Rows[0]["User_name"].ToString(),
                        user_fullName = table.Rows[0]["User_fullname"].ToString(),
                        privileges_id = table.Rows[0]["Privileges_id"].ToString(),
                        IsAdmin = bool.Parse(table.Rows[0]["IsAdmin"].ToString()),
                        canDelete = bool.Parse(table.Rows[0]["canDelete"].ToString()),
                        canEdit = bool.Parse(table.Rows[0]["canEdit"].ToString()),
                        canAdd = bool.Parse(table.Rows[0]["canAdd"].ToString()),
                        canReception = bool.Parse(table.Rows[0]["canReception"].ToString()),
                        canCheckout = bool.Parse(table.Rows[0]["canCheckout"].ToString()),
                        canPurchaseOrder = bool.Parse(table.Rows[0]["canPurchaseOrder"].ToString()),
                    };

                    MainWindow MainWindow = new MainWindow();
                    MainWindow.Connected_user = connected_user;
                    MainWindow.Show();

                    Database_c.Close_DB_Connection();
                    this.Close();

                }
            }
        }
    }
}
