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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Huber_Management.Controls
{
    /// <summary>
    /// Interaction logic for output_fields_page.xaml
    /// </summary>
    public partial class output_fields_page : Page
    {
        public output_fields_page(string serial_id)
        {
            InitializeComponent();
            SQLiteConnection conn = Database_c.Get_DB_Connection();
            InitializeData(serial_id, conn);
            Database_c.Get_DB_Connection();
        }

        private async void InitializeData(string serial_id, SQLiteConnection conn)
        {
            DataTable result = await Task.Run(() => Tools_c.Get_by_serial_id(serial_id, conn));
            price_add.Text = result.Rows[0]["Tool_price"].ToString();

            serial_nb_detail.Text = serial_id;
            project_detail.Text = result.Rows[0]["Tool_project"].ToString();
            designation_detail.Text = result.Rows[0]["Tool_designation"].ToString();

            int actual_stock = 0;
            int.TryParse(result.Rows[0]["Tool_actual_stock"].ToString(), out actual_stock);

            int stock_min = 0;
            int.TryParse(result.Rows[0]["Tool_stock_mini"].ToString(), out stock_min);

            actual_stock_detail.Text = actual_stock.ToString() + " Available";
            if (stock_min > actual_stock)
            {
                actual_stock_detail.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FAE7E6");
                actual_stock_detail.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#A20000");
            }

            InitializeComboBox("Output_requester", requester_add_combobox, conn);

            string image_path = result.Rows[0]["Tool_image_path"].ToString();
            if (image_path != "")
            {
                image_detail.Source = new BitmapImage(new Uri(image_path));
            }
        }

        private async void InitializeComboBox(string Tool_column_name, ComboBox combobox_name, SQLiteConnection conn)
        {
            DataTable InitializeData = new DataTable();
            string query = "SELECT DISTINCT " + Tool_column_name + " as results FROM Transactions WHERE Transaction_type = 'OUT' GROUP BY (" + Tool_column_name + ") Order By " + Tool_column_name + " ";
            SQLiteDataAdapter adapter = await Task.Run(() => new SQLiteDataAdapter(query, conn));
            adapter.Fill(InitializeData);
            foreach (DataRow row in InitializeData.Rows)
            {
                if (row["results"].ToString() != "")
                {
                    ComboBoxItem newItem = new ComboBoxItem();
                    newItem.Content = row["results"].ToString();
                    combobox_name.Items.Add(newItem);
                }
            }
        }

        private void new_process_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            requester_add_combobox.Visibility = Visibility.Collapsed;
            requester_add.Visibility = Visibility.Visible;
        }
    }
}
