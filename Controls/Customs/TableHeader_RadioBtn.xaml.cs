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
    /// Interaction logic for TableHeader_RadioBtn.xaml
    /// </summary>
    public partial class TableHeader_RadioBtn : UserControl
    {
        public TableHeader_RadioBtn()
        {
            InitializeComponent();
        }

        private void RadioBtn_border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (this.RadioBtn_invisible_Down.IsChecked.Value)
            {
                this.RadioBtn_invisible_Down.IsChecked = false;
                this.RadioBtn_invisible_Up.IsChecked = true;
            }
            else
            {
                this.RadioBtn_invisible_Down.IsChecked = true;
                this.RadioBtn_invisible_Up.IsChecked = false;
            }

        }

        private void RadioBtn_invisible_up_Checked(object sender, RoutedEventArgs e)
        {
            this.tableHeader_ToggleBtn.IsChecked = true;
            RadioBtn_border.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFC8C8C8");
        }

        private void RadioBtn_invisible_down_Checked(object sender, RoutedEventArgs e)
        {
            this.tableHeader_ToggleBtn.IsChecked = false;
            RadioBtn_border.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFC8C8C8");
        }

        private void RadioBtn_invisible_Unchecked(object sender, RoutedEventArgs e)
        {
            if(this.RadioBtn_invisible_Down.IsChecked == false && this.RadioBtn_invisible_Down.IsChecked == false)
            {
                this.tableHeader_ToggleBtn.IsChecked = false;
                RadioBtn_border.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#00FFFFFF");
            }
        }
    }
}
