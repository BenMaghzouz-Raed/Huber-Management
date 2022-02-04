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
    /// Interaction logic for reception_fields_page.xaml
    /// </summary>
    public partial class reception_fields_page : Page
    {
        public reception_fields_page(Tools_c reception_tool)
        {
            InitializeComponent();
            date_add.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            InitializeData(reception_tool);
        }

        private void InitializeData(Tools_c reception_tool)
        {
            supplier_code_add.Text = reception_tool.Tool_supplier_code;
            price_add.Text = reception_tool.Tool_price.ToString();

            serial_nb_detail.Text = reception_tool.Tool_serial_id;
            project_detail.Text = reception_tool.Tool_project;
            designation_detail.Text = reception_tool.Tool_designation;

            string image_path = reception_tool.Tool_image_path;
            if (image_path != "")
            {
                image_detail.Source = new BitmapImage(new Uri(image_path));
            }
        }
    }
}
