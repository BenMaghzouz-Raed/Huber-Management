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
    /// Interaction logic for Single_Tool_Transactions_Row.xaml
    /// </summary>
    public partial class Single_Tool_Transactions_Row : UserControl
    {
        public Single_Tool_Transactions_Row(
            string transaction_date, 
            string transaction_time,
            string transaction_type,
            string transaction_quantity,
            string Transaction_requester,
            string Transaction_by,
            string Transaction_comment)
        {
            InitializeComponent();
            this.transaction_date.Content = transaction_date;
            this.transaction_time.Content = transaction_time;
            this.transaction_type.Content = transaction_type;
            this.transaction_quantity.Content = transaction_quantity;
            this.Transaction_requester.Text = Transaction_requester;
            this.Transaction_by.Text = Transaction_by;
            this.Transaction_comment.Text = Transaction_comment;

            if(transaction_type == "OUT")
            {
                this.transaction_type.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FAE7E6");
                this.transaction_type.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#A20000");
            }
        }
    }
}
