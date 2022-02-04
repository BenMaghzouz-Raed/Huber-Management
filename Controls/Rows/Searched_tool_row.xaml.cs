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
    /// Interaction logic for Searched_tool_row.xaml
    /// </summary>
    public partial class Searched_tool_row : UserControl
    {
        public Searched_tool_row(
            string tool_serial_id,
            string tool_image_path,
            string tool_designation,
            bool isSelected = false)
        {
            InitializeComponent();
            if (tool_image_path != "")
            {
                try
                {
                    this.tool_image.Source = new BitmapImage(new Uri(tool_image_path));
                }
                catch (Exception)
                {
                    throw;
                }
            }
            this.tool_serial_id.Content = tool_serial_id;
            this.tool_designation.Text = tool_designation;
            tool_radio_btn.IsChecked = isSelected;
        }

        private void Tool_row_element_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.tool_radio_btn.IsChecked = true;
        }

        private void tool_radio_btn_Checked(object sender, RoutedEventArgs e)
        {
            Tool_row_element.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#DFEDF7");
        }

        private void tool_radio_btn_Unchecked(object sender, RoutedEventArgs e)
        {
            Tool_row_element.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
        }
    }
}
