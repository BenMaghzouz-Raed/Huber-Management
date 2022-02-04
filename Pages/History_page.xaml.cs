using LiveCharts;
using LiveCharts.Wpf;
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

namespace Huber_Management.Pages
{
    /// <summary>
    /// Interaction logic for History_page.xaml
    /// </summary>
    public partial class History_page : Page
    {
        public History_page()
        {
            InitializeComponent();
            InitializeChart_outputs();
            InitializeChart_inputs();
            
        }

        // OUTPUT CAHRT DATA
        public SeriesCollection SeriesCollectionOutput { get; set; }
        public string[] LabelsOutput { get; set; }
        public Func<double, string> FormatterOutput { get; set; }

        private async void InitializeChart_outputs()
        {
            SqlConnection conn = Database_c.Get_DB_Connection();
            DataTable chart_data = new DataTable();

            ChartValues<int> output_quantity = new ChartValues<int>();
            List<string> days = new List<string>();

            string query = "SELECT SUM(Transaction_quantity) as Total_quantity, Transaction_date FROM Transactions WHERE (Transaction_type = 'OUT') Group by (Transaction_date) " +
                "Order By Transaction_date";

            SqlDataAdapter adapter = await Task.Run(() => new SqlDataAdapter(query, conn));
            await Task.Run(() => adapter.Fill(chart_data));

            foreach (DataRow row in chart_data.Rows)
            {
                output_quantity.Add(int.Parse(row["Total_quantity"].ToString()));
                string[] date = row["Transaction_date"].ToString().Split(null);
                days.Add(date[0]);
            }


            //adding series and update the chart
            SeriesCollectionOutput = new SeriesCollection();
            SeriesCollectionOutput.Add(new ColumnSeries
            {
                Title = "Output",
                Values = output_quantity
            });

            LabelsOutput = days.ToArray();
            outputschart.DataContext = this;
            conn.Close();

        }

        // RECEPTION CAHRT DATA
        public SeriesCollection SeriesCollectionInputs { get; set; }
        public string[] LabelsInput { get; set; }
        public Func<double, string> FormatterInputs { get; set; }

        // CHART 
        private async void InitializeChart_inputs()
        {
            SqlConnection conn = Database_c.Get_DB_Connection();
            DataTable chart_data = new DataTable();

            ChartValues<int> reception_quantity = new ChartValues<int>();
            List<string> days = new List<string>();

            string query = "Select SUM(Transaction_quantity) as Total_quantity, Transaction_date FROM Transactions WHERE (Transaction_type = 'IN') Group by (Transaction_date) " +
                "Order By Transaction_date";

            SqlDataAdapter adapter = await Task.Run(() => new SqlDataAdapter(query, conn));
            await Task.Run(() => adapter.Fill(chart_data));

            foreach (DataRow row in chart_data.Rows)
            {
                reception_quantity.Add(int.Parse(row["Total_quantity"].ToString()));
                string[] date = row["Transaction_date"].ToString().Split("/");
                days.Add(date[0] + "/" + date[1]);
            }


            //adding series and update the chart
            SeriesCollectionInputs = new SeriesCollection();
            SeriesCollectionInputs.Add(new ColumnSeries
            {
                Title = "Reception",
                Values = reception_quantity
            });

            LabelsInput = days.ToArray();
            inputschart.DataContext = this;
            conn.Close();

        }
    }
}
