using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;

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

        // Get Current Active Window 
        MainWindow Main_W { get => Application.Current.MainWindow as MainWindow; }

        private void Login_btn_Click(object sender, RoutedEventArgs e)
        {
            String user_input = user_name.Text.ToString();
            String pass_input = password.Password.ToString();

            DataTable Result = users_c.Get_by_name(user_input);

            if( Result.Rows.Count != 1)
            {
                // CREATE AN ERROR
                MessageBox.Show("This Username doesn't exist !", "wrong username", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                if(pass_input != Result.Rows[0]["User_password"].ToString())
                {
                    // CREATE AN ERROR
                    MessageBox.Show("Wrong Password ! please try again", "wrong password", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    // CREATE A SUCCESS
                    MainWindow MainWindow = new MainWindow();
                    MainWindow.Show();
                    this.Close();

                }
            }
        }
    }
}
