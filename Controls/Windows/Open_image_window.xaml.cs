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
using System.Windows.Shapes;

namespace Huber_Management.Controls
{
    /// <summary>
    /// Interaction logic for Open_image_window.xaml
    /// </summary>
    public partial class Open_image_window : Window
    {
        public Open_image_window(ImageSource image_source, string Tool_serial_id = "")
        {
            InitializeComponent();
            image_window_source.Source = image_source;
            this.Title = Tool_serial_id + " Image";
        }
    }
}
