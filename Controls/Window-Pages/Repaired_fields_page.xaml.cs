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
    /// Interaction logic for Repaired_fields_page.xaml
    /// </summary>
    public partial class Repaired_fields_page : Page
    {
        public Repaired_fields_page(Tools_c repaired_tool, string faulty_id, string faulty_quantity)
        {
            InitializeComponent();
            //date_add.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            InitializeData(repaired_tool, faulty_id, faulty_quantity);
        }

        private void InitializeData(Tools_c repaired_tool, string faulty_id, string faulty_quantity)
        {
            //supplier_code_add.Text = reception_tool.Tool_supplier_code;
            faulty_serial_id.Text = faulty_id;
            price_add.Text = repaired_tool.Tool_price.ToString();

            serial_nb_detail.Text = repaired_tool.Tool_serial_id;
            if (repaired_tool.Tool_project != "")
            {
                project_detail.Text = repaired_tool.Tool_project;
            }
            if (repaired_tool.Tool_designation != "")
            {
                designation_detail.Text = repaired_tool.Tool_designation;
            }

            actual_stock_detail.Text = repaired_tool.Tool_actual_stock.ToString() + " Available";

            if (repaired_tool.Tool_stock_mini > repaired_tool.Tool_actual_stock)
            {
                actual_stock_detail.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FAE7E6");
                actual_stock_detail.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#A20000");
            }
            defective_detail.Text = faulty_quantity;

            string image_path = repaired_tool.Tool_image_path;
            if (image_path != "")
            {
                image_detail.Source = new BitmapImage(new Uri(image_path));
            }
        }
    }
}
