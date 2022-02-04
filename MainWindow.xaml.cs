using System;
using System.Collections.Generic;
using System.Data;
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
        public MainWindow()
        {
            InitializeComponent();
            Main_container.Content = new Pages.Dashboard_page();
        }

        private void Logout_btn_Checked(object sender, RoutedEventArgs e)
        {
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
    }
}
