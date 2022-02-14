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
    /// Interaction logic for Single_tool_details_page.xaml
    /// </summary>
    public partial class Single_tool_details_page : Page
    {
        public Single_tool_details_page(string serial_id)
        {
            InitializeComponent();
            SQLiteConnection conn = Database_c.Get_DB_Connection();
            InitializeData(serial_id, conn);
            Database_c.Get_DB_Connection();
        }

        public async void InitializeData(string serial_id, SQLiteConnection conn)
        {
            DataTable result = await Task.Run(() => Tools_c.Get_by_serial_id(serial_id, conn));

            drawing.Text = result.Rows[0]["Tool_drawing"].ToString() != "" ? result.Rows[0]["Tool_drawing"].ToString() : "-";
            project.Text = result.Rows[0]["Tool_project"].ToString() != "" ? result.Rows[0]["Tool_project"].ToString() : "-";
            process.Text = result.Rows[0]["Tool_process"].ToString() != "" ? result.Rows[0]["Tool_process"].ToString() : "-";
            division.Text = result.Rows[0]["Tool_division"].ToString() != "" ? result.Rows[0]["Tool_division"].ToString() : "-";
            position.Text = result.Rows[0]["Tool_position"].ToString() != "" ? result.Rows[0]["Tool_position"].ToString() : "-";
            min.Text = result.Rows[0]["Tool_stock_mini"].ToString();
            max.Text = result.Rows[0]["Tool_stock_max"].ToString();

            // UNIT PRICE EN EURO
            string unit_euro_price = result.Rows[0]["Tool_price"].ToString();
            decimal price = decimal.Parse(unit_euro_price);
            string price_c = price.ToString("C");
            unit_price.Text = price_c;

            // UNIT PRICE EN DT
            decimal dt_value = MainWindow.Default_settings == null ? (decimal)3.25 : MainWindow.Default_settings.Euro_to_dt_value;
            string price_dt_c = (price * dt_value).ToString("C").Remove(0, 1);
            unit_price.ToolTip = price_dt_c + " DT";

            // TOTAL PRICE EN EURO
            decimal total_price = int.Parse(result.Rows[0]["Tool_actual_stock"].ToString()) * price;
            string total_price_c = total_price.ToString("C");
            this.total_price.Text = total_price_c;

            // TOTAL PRICE EN DT
            decimal total_price_dt = int.Parse(result.Rows[0]["Tool_actual_stock"].ToString()) * price * dt_value;
            string total_price_dt_c = total_price_dt.ToString("C").Remove(0, 1);
            this.total_price.ToolTip = total_price_dt_c + " DT";


            supplier.Text = result.Rows[0]["Tool_supplier"].ToString() != "" ? result.Rows[0]["Tool_supplier"].ToString() : "-";
            supplier_code.Text = result.Rows[0]["Tool_supplier_code"].ToString() != "" ? result.Rows[0]["Tool_supplier_code"].ToString() : "-";
            string[] date = result.Rows[0]["Tool_date_added"].ToString().Split(null);
            string[] time = date[1].Split(":");
            added_date.Text = date[0] + " " + time[0] + ":" + time[1];

            int criticlity = 0;
            int.TryParse(result.Rows[0]["Tool_criticality"].ToString(), out criticlity);
            criticality_converter(criticlity);

        }

        public void criticality_converter(int criticality_val)
        {
            string converted_value = "A";

            int A_value = MainWindow.Default_settings.Criticality_A_value;
            int B_value = MainWindow.Default_settings.Criticality_B_value;
            int C_value = MainWindow.Default_settings.Criticality_C_value;
            if(criticality_val == 0)
            {
                tool_criticality.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#fff");
                tool_criticality.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#000");
                converted_value = "0";
            }
            else if (criticality_val <= C_value)
            {
                tool_criticality.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#005596");
                converted_value = "C";
            }
            else if (criticality_val <= B_value && criticality_val > C_value)
            {
                tool_criticality.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#DF781C");
                converted_value = "B";
            }
            else if (criticality_val <= A_value && criticality_val > B_value)
            {
                converted_value = "A";
            }

            tool_criticality.Text = converted_value;
            tool_criticality.ToolTip = "Lead time = " + criticality_val.ToString() + " Days";
        }
    }
}
