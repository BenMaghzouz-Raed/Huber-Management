using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for xaml
    /// </summary>
    public partial class Single_tool_Window : Window
    {
        public Single_tool_Window(string serial_id)
        {
            InitializeComponent();
            SqlConnection conn = Database_c.Get_DB_Connection();
            InitializeData(serial_id, conn);
            Database_c.Get_DB_Connection();
        }

        public async void InitializeData(string serial_id, SqlConnection conn)
        {
            bool isExist = Tools_c.isExist_serial_id(serial_id, conn);
            serial_nb_detail.Text = serial_id.ToString();
            if (isExist)
            {
                // PRIVILEGES SETTINGS
                if (!MainWindow.Connected_user.canDelete)
                {
                    MenuItem_Delete.Visibility = Visibility.Collapsed;
                }
                if (!MainWindow.Connected_user.canEdit)
                {
                    MenuItem_modify.IsEnabled = false;
                }
                if (!MainWindow.Connected_user.canReception)
                {
                    Add_reception_tool.IsEnabled = false;
                }
                if (!MainWindow.Connected_user.canCheckout)
                {
                    Add_output_tool.IsEnabled = false;
                }

                // INITIALIZEDATA
                DataTable result = await Task.Run(() => Tools_c.Get_by_serial_id(serial_id, conn));
                designation_detail.Text = result.Rows[0]["Tool_designation"].ToString();

                int actual_stock = 0;
                int.TryParse(result.Rows[0]["Tool_actual_stock"].ToString(), out actual_stock);

                int stock_min = 0;
                int.TryParse(result.Rows[0]["Tool_stock_mini"].ToString(), out stock_min);

                actual_stock_detail.Text = actual_stock.ToString() + " Available";

                if ( stock_min > actual_stock)
                {
                    actual_stock_detail.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FAE7E6");
                    actual_stock_detail.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#A20000");
                }

                string image_path = result.Rows[0]["Tool_image_path"].ToString();
                if (image_path != "")
                {
                    image_detail.Source = new BitmapImage(new Uri(image_path));
                }

                if (Single_tool_section != null)
                {
                    Single_tool_details_page page = new Single_tool_details_page(serial_nb_detail.Text.ToString());
                    Single_tool_section.Content = page;
                }

                // Defective Quantity
                DataTable defective_data = new DataTable();
                string query2 = "Select SUM(Faulty_quantity) as quantity FROM Faulty_Tools WHERE (Faulty_Tools.Tool_serial_id = '" + serial_id + "') AND Faulty_quantity > 0 Group By (Faulty_Tools.Tool_serial_id) ";
                SqlDataAdapter adapter2 = await Task.Run(() => new SqlDataAdapter(query2, conn));
                adapter2.Fill(defective_data);

                if (defective_data.Rows.Count > 0)
                {
                    defective_detail.Text = defective_data.Rows[0]["quantity"].ToString();
                }

            }
            else
            {
                this.Close();
            }

        }

        private void MenuItem_Delete_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = Database_c.Get_DB_Connection();
            string serial_id = this.serial_nb_detail.Text.ToString();
            MessageBoxResult dialogResult = MessageBox.Show("Are you sure that you want to permanently Delete " + serial_id + " from the database ?", "Delete " + serial_id + " ?", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (dialogResult == MessageBoxResult.Yes)
            {
                Tools_c.Delete_by_serial_id(serial_id, conn);
            }
            Database_c.Close_DB_Connection();
        }

        private void MenuItem_modify_Click(object sender, RoutedEventArgs e)
        {
            Modify_tool_Window Modify_window = new Modify_tool_Window(serial_nb_detail.Text.ToString());
            Modify_window.Show();
            this.Close();
        }

        private void Add_output_tool_Click(object sender, RoutedEventArgs e)
        {
            Controls.Add_new_output_Window new_output = new Controls.Add_new_output_Window(serial_nb_detail.Text.ToString());
            new_output.Show();
            this.Close();
        }

        private void Add_reception_tool_Click(object sender, RoutedEventArgs e)
        {
            Controls.Add_new_reception_Window new_reception = new Controls.Add_new_reception_Window(serial_nb_detail.Text.ToString());
            new_reception.Show();
            this.Close();
        }

        private void image_detail_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            if (e.ClickCount == 2)
            {
                Open_image_window big_image = new Open_image_window(image_detail.Source, serial_nb_detail.Text.ToString());
                big_image.Show();
            }

        }

        private void details_button_Checked(object sender, RoutedEventArgs e)
        {
            if(Single_tool_section != null)
            {
                Single_tool_details_page page = new Single_tool_details_page(serial_nb_detail.Text.ToString());
                Single_tool_section.Content = page;
            }
        }

        private void history_button_Checked(object sender, RoutedEventArgs e)
        {
            if (Single_tool_section != null)
            {
                Single_tool_history_page page = new Single_tool_history_page(serial_nb_detail.Text.ToString());
                Single_tool_section.Content = page;
            }
        }
    }
}
