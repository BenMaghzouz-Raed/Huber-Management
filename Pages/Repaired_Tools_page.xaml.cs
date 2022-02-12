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
    /// Interaction logic for Repaired_Tools_page.xaml
    /// </summary>
    public partial class Repaired_Tools_page : Page
    {
        public Repaired_Tools_page()
        {
            InitializeComponent();
        }

        void Load(object sender, RoutedEventArgs e)
        {

            // INITIALIZE BY WHO COMBOBOX
            SqlConnection conn = Database_c.Get_DB_Connection();
            DataTable by_who_table = new DataTable();
            string query = "SELECT DISTINCT(Repaired_by) as results FROM Repaired_Tools";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            adapter.Fill(by_who_table);
            foreach (DataRow row in by_who_table.Rows)
            {
                if (row["results"].ToString() != "")
                {
                    ComboBoxItem newItem = new ComboBoxItem();
                    newItem.Content = row["results"].ToString();
                    by_who_combobox.Items.Add(newItem);
                }
            }
            Database_c.Close_DB_Connection();

            date.tableHeader_Label.Content = date.Tag.ToString();
            serial_id.tableHeader_Label.Content = serial_id.Tag.ToString();
            quantity.tableHeader_Label.Content = quantity.Tag.ToString();
            total_price.tableHeader_Label.Content = total_price.Tag.ToString();
            repaired_by.tableHeader_Label.Content = repaired_by.Tag.ToString();
            duration.tableHeader_Label.Content = duration.Tag.ToString();

            date.tableHeader_Label.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            serial_id.tableHeader_Label.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            quantity.tableHeader_Label.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            total_price.tableHeader_Label.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            repaired_by.tableHeader_Label.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            duration.tableHeader_Label.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");

            date.tableHeader_ToggleBtn.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            serial_id.tableHeader_ToggleBtn.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            quantity.tableHeader_ToggleBtn.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            total_price.tableHeader_ToggleBtn.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            repaired_by.tableHeader_ToggleBtn.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
            duration.tableHeader_ToggleBtn.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");

            InitializeAllData();
        }
        public Controls.TableHeader_RadioBtn Selected_sort_by { get; set; } = null;

        public async void InitializeAllData(string when = "", string who = "", string filter = "", string sort_by = "", bool DESC = true, string _search_text = "")
        {
            if (LoadingIcon != null && DataScrollViewer != null)
            {
                LoadingIcon.Visibility = Visibility.Visible;
                DataScrollViewer.Visibility = Visibility.Collapsed;
            }

            SqlConnection conn = Database_c.Get_DB_Connection();
            DataTable all_data = new DataTable();

            string query = "Select * FROM Repaired_Tools LEFT JOIN Tools ON (Repaired_Tools.Tool_serial_id = Tools.Tool_serial_id) ";

            // FILTER CONVERTER
            switch (filter)
            {
                case "Serial Number":
                    filter = "Repaired_Tools.Tool_serial_id";
                    break;
                case "Drawing":
                    filter = "Tool_drawing";
                    break;
                case "Supplier":
                    filter = "Tool_supplier";
                    break;
                case "Position":
                    filter = "Tool_position";
                    break;
                default:
                    filter = "Repaired_Tools.Tool_serial_id";
                    break;
            }

            // SEARCH CONVERTER
            if (_search_text != "" && _search_text.Length > 0)
            {
                query += " WHERE " + filter + " LIKE '%" + _search_text + "%' ";
            }
            else
            {
                query += " WHERE Repaired_Tools.Tool_serial_id LIKE '%%' ";
            }

            // WHEN CONVERTER
            switch (when)
            {
                case "This Month":
                    when = " AND ( MONTH(repaired_date)=MONTH(GETDATE()) and YEAR(repaired_date)=YEAR(GETDATE()) ) ";
                    break;
                case "Last Month":
                    when = " AND ( MONTH(repaired_date)<=( MONTH(GETDATE()) - 1 ) and YEAR(repaired_date)=YEAR(GETDATE()) ) ";
                    break;
                case "Last Year":
                    when = " AND ( YEAR(repaired_date)=(YEAR(GETDATE()) - 1) ) ";
                    break;
                case "This Year":
                    when = " AND ( YEAR(repaired_date)=YEAR(GETDATE()) ) ";
                    break;
                case "All":
                    when = "";
                    break;
                default:
                    when = " AND ( MONTH(repaired_date)=MONTH(GETDATE()) and YEAR(repaired_date)=YEAR(GETDATE()) ) ";
                    break;
            }
            query += when;

            // BY WHO CONVERTER
            if (who != "Any" && who != "")
            {
                query += " AND ( Repaired_by = '" + who + "' ) ";
            }

            // SORT BY CONVERTER
            switch (sort_by)
            {
                case "serial_id":
                    sort_by = "Repaired_Tools.Tool_serial_id";
                    DESC = !DESC;
                    break;
                case "date":
                    sort_by = "repaired_date";
                    break;
                case "quantity":
                    sort_by = "Repaired_quantity";
                    break;
                case "faulty_by":
                    sort_by = "Repaired_by";
                    DESC = !DESC;
                    break;
                case "total_price":
                    sort_by = "Tool_price * Repaired_quantity";
                    break;
                default:
                    sort_by = "repaired_date";
                    break;
            }
            query += " Order by " + sort_by;

            // DSEC or ASC CONVERTER
            if (DESC)
            {
                query += " DESC";
            }

            // EXECUTE QUERY
            try
            {
                SqlDataAdapter adapter = await Task.Run(() => new SqlDataAdapter(query, conn));
                adapter.Fill(all_data);

                if (Repaired_rows_panel != null && all_data.Rows.Count > 0)
                {
                    Repaired_rows_panel.Children.Clear();
                    foreach (DataRow row in all_data.Rows)
                    {

                        Tools_c newTool = new Tools_c
                        {
                            Tool_serial_id = row["Tool_serial_id"].ToString(),
                            Tool_designation = row["Tool_designation"].ToString(),
                            Tool_drawing = row["Tool_drawing"].ToString(),
                            Tool_project = row["Tool_project"].ToString(),
                            Tool_process = row["Tool_process"].ToString(),
                            Tool_division = row["Tool_division"].ToString(),
                            Tool_position = row["Tool_position"].ToString(),
                            Tool_supplier = row["Tool_supplier"].ToString(),
                            Tool_stock_mini = int.Parse(row["Tool_stock_mini"].ToString()),
                            Tool_stock_max = int.Parse(row["Tool_stock_max"].ToString()),
                            Tool_actual_stock = int.Parse(row["Tool_actual_stock"].ToString()),
                            Tool_price = decimal.Parse(row["Tool_price"].ToString()),
                            Tool_image_path = row["Tool_image_path"].ToString()
                        };

                        Controls.Repaired_tool_row new_repaired_row = new Controls.Repaired_tool_row
                            (
                            newTool,
                            row["Repaired_tool_id"].ToString(),
                            row["Tasks_description"].ToString(),
                            row["repaired_date"].ToString(),
                            row["Repaired_quantity"].ToString(),
                            row["Repaired_by"].ToString()
                            );
                        Repaired_rows_panel.Children.Add(new_repaired_row);
                    }
                }
                else
                {
                    Repaired_rows_panel.Children.Clear();
                    Repaired_rows_panel.Children.Add(this.noDataFound);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            Database_c.Close_DB_Connection();

            if (LoadingIcon != null && DataScrollViewer != null)
            {
                LoadingIcon.Visibility = Visibility.Collapsed;
                DataScrollViewer.Visibility = Visibility.Visible;
            }

        }

        private void Viewbox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (this.NavigationService != null)
            {
                this.NavigationService.Refresh();
            }
        }

        public void InitializeAllData_Filters(object sender, EventArgs e)
        {
            if (search_filter != null && Nav_search_box != null && when_combobox != null && by_who_combobox != null)
            {
                try
                {
                    string _when = ((ComboBoxItem)when_combobox.SelectedItem).Content.ToString();
                    string _who = ((ComboBoxItem)by_who_combobox.SelectedItem).Content.ToString();
                    string _filter = ((ComboBoxItem)search_filter.SelectedItem).Content.ToString();
                    string _text = ((TextBox)Nav_search_box).Text.ToString();

                    if (Selected_sort_by != null)
                    {
                        bool DSEC = Selected_sort_by.RadioBtn_invisible_Down.IsChecked.Value;

                        string _sort_by = Selected_sort_by.Name.ToString();
                        InitializeAllData(_when, _who, _filter, _sort_by, DSEC, _text);
                    }
                    else
                    {
                        InitializeAllData(_when, _who, _filter, "", true, _text);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        private void sort_by_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Selected_sort_by = (Controls.TableHeader_RadioBtn)(sender);
            InitializeAllData_Filters(sender, e);
        }

        private void Add_repaired_tool_Click(object sender, RoutedEventArgs e)
        {
            Controls.Add_repaired_tool_window new_repaired = new Controls.Add_repaired_tool_window();
            new_repaired.Show();
        }
    }
}
