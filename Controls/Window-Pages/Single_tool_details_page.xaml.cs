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
            SqlConnection conn = Database_c.Get_DB_Connection();
            InitializeData(serial_id, conn);
            Database_c.Get_DB_Connection();
        }

        public async void InitializeData(string serial_id, SqlConnection conn)
        {
            DataTable result = await Task.Run(() => Tools_c.Get_by_serial_id(serial_id, conn));

            drawing.Text = result.Rows[0]["Tool_drawing"].ToString() == "" ? result.Rows[0]["Tool_drawing"].ToString() : "-";
            project.Text = result.Rows[0]["Tool_project"].ToString() == "" ? result.Rows[0]["Tool_project"].ToString() : "-";
            process.Text = result.Rows[0]["Tool_process"].ToString() == "" ? result.Rows[0]["Tool_process"].ToString() : "-";
            division.Text = result.Rows[0]["Tool_division"].ToString() == "" ? result.Rows[0]["Tool_division"].ToString() : "-";
            position.Text = result.Rows[0]["Tool_position"].ToString() == "" ? result.Rows[0]["Tool_position"].ToString() : "-";
            min.Text = result.Rows[0]["Tool_stock_mini"].ToString();
            max.Text = result.Rows[0]["Tool_stock_max"].ToString();

            // UNIT PRICE EN EURO
            string unit_euro_price = result.Rows[0]["Tool_price"].ToString();
            decimal price = 0;
            decimal.TryParse(unit_euro_price, out price);
            string price_c = price.ToString("C").Remove(0, 1);
            unit_price.Text = price_c + " €";

            // UNIT PRICE EN DT
            string price_dt_c = (price * 3).ToString("C").Remove(0, 1);
            unit_price.ToolTip = price_dt_c + " DT";

            // TOTAL PRICE EN EURO
            decimal total_price = (int)result.Rows[0]["Tool_actual_stock"] * price;
            string total_price_c = total_price.ToString("C").Remove(0, 1);
            this.total_price.Text = total_price_c + " €";

            // TOTAL PRICE EN DT
            decimal total_price_dt = (int)result.Rows[0]["Tool_actual_stock"] * price * 3;
            string total_price_dt_c = total_price_dt.ToString("C").Remove(0, 1);
            this.total_price.ToolTip = total_price_dt_c + " DT";


            supplier.Text = result.Rows[0]["Tool_supplier"].ToString() == "" ? result.Rows[0]["Tool_supplier"].ToString() : "-";
            supplier_code.Text = result.Rows[0]["Tool_supplier_code"].ToString() == "" ? result.Rows[0]["Tool_supplier_code"].ToString() : "-";
            string[] date = result.Rows[0]["Tool_date_added"].ToString().Split(null);
            string[] time = date[1].Split(":");
            added_date.Text = date[0] + " " + time[0] + ":" + time[1];

        }
    }
}
