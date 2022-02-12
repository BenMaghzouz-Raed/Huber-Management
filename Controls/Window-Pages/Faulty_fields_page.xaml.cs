using System;
using System.Collections.Generic;
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
    /// Interaction logic for Faulty_fields_page.xaml
    /// </summary>
    public partial class Faulty_fields_page : Page
    {
        public Faulty_fields_page(Tools_c Faulty_tool)
        {
            InitializeComponent();
            //date_add.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            InitializeData(Faulty_tool);
        }

        private void InitializeData(Tools_c Faulty_tool)
        {
            //supplier_code_add.Text = Faulty_tool.Tool_supplier_code;
            price_add.Text = Faulty_tool.Tool_price.ToString();

            serial_nb_detail.Text = Faulty_tool.Tool_serial_id;
            if (Faulty_tool.Tool_project != "")
            {
                project_detail.Text = Faulty_tool.Tool_project;
            }
            if (Faulty_tool.Tool_designation != "")
            {
                designation_detail.Text = Faulty_tool.Tool_designation;
            }

            actual_stock_detail.Text = Faulty_tool.Tool_actual_stock.ToString() + " Available";

            if (Faulty_tool.Tool_stock_mini > Faulty_tool.Tool_actual_stock)
            {
                actual_stock_detail.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FAE7E6");
                actual_stock_detail.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#A20000");
            }

            string image_path = Faulty_tool.Tool_image_path;
            if (image_path != "")
            {
                image_detail.Source = new BitmapImage(new Uri(image_path));
            }
        }
    }
}
