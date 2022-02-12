using ClosedXML.Excel;
using ExcelDataReader;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace Huber_Management.Pages
{
    /// <summary>
    /// Interaction logic for Settings_page.xaml
    /// </summary>
    public partial class Settings_page : Page
    {
        public Settings_page()
        {
            InitializeComponent();
        }
        void Page_Loaded(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = Database_c.Get_DB_Connection();
            InitializeUsers(conn);
            InitializeSettings(conn);
            Database_c.Close_DB_Connection();
        }

        /// <summary>
        /// Import Data Base
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Import_excel_btn_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog() { Filter = "Excel|*.xlsx|*.xls|*.xlsm", Multiselect = false };
            Nullable<bool> returned = openDialog.ShowDialog();

            if (returned == true)
            {
                SqlConnection conn = Database_c.Get_DB_Connection();
                int count_tools = 0;
                int count_tools_failed = 0;
                int count_transactions = 0;
                int count_transactions_failed = 0;
                try
                {
                    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                    FileStream FS = new FileStream(openDialog.FileName, FileMode.Open);
                    IExcelDataReader ExcelReader = ExcelReaderFactory.CreateOpenXmlReader(FS);
                    DataSet result = await Task.Run(() => ExcelReader.AsDataSet());

                    // Import Data for Tools database
                    DataTable Table1 = result.Tables[0];
                    // Remove Header
                    DataRow row = Table1.Rows[0];
                    Table1.Rows.Remove(row);
                    foreach (DataRow Row in Table1.Rows)
                    {
                        // ADD TOOL FROM EXCEL
                        decimal price = 0;
                        decimal.TryParse(Row[16].ToString(), out price);

                        int actual_stock = 1;
                        int.TryParse(Row[11].ToString(), out actual_stock);

                        int min_stock = 0;
                        int.TryParse(Row[10].ToString(), out min_stock);

                        int max_stock = 0;
                        //int.TryParse(Row[11].ToString(), out min_stock);

                        string tool_serial_id = string.Join(" ", Row[2].ToString().Split().Where(x => x != ""));
                        string tool_supplier = string.Join(" ", Row[0].ToString().Split().Where(x => x != ""));

                        int criticality = 0;
                        int.TryParse(Row[22].ToString(), out criticality);

                        Tools_c NewTool = new Tools_c
                        {
                            Tool_serial_id = tool_serial_id,
                            Tool_supplier_code = string.Join(" ", Row[1].ToString().Split().Where(x => x != "")),
                            Tool_supplier = tool_supplier.ToUpper(),

                            Tool_image_path = "",

                            Tool_designation = string.Join(" ", Row[4].ToString().Split().Where(x => x != "")),
                            Tool_drawing = string.Join(" ", Row[5].ToString().Split().Where(x => x != "")),
                            Tool_project = string.Join(" ", Row[6].ToString().Split().Where(x => x != "")),
                            Tool_process = string.Join(" ", Row[7].ToString().Split().Where(x => x != "")),
                            Tool_division = string.Join(" ", Row[8].ToString().Split().Where(x => x != "")),
                            Tool_position = string.Join(" ", Row[9].ToString().Split().Where(x => x != "")),

                            Tool_stock_mini = min_stock,
                            Tool_stock_max = max_stock,
                            Tool_actual_stock = actual_stock,
                            Tool_price = price,
                            Tool_criticality = criticality,

                        };
                        bool Tool_isAdded = await Task.Run(() => Tools_c.Add_single_tool(NewTool, conn));
                        if (Tool_isAdded)
                        {
                            count_tools++;
                        }
                        else 
                        { 
                            count_tools_failed++; 
                        }

                    }

                    // Import Transactions for Receptions and Output
                    DataTable Table2 = result.Tables[1];
                    // Remove Header
                    DataRow row1 = Table2.Rows[0];
                    Table2.Rows.Remove(row1);
                    bool reception_isAdded = false;
                    bool output_isAdded = false;
                    foreach (DataRow Row in Table2.Rows)
                    {
                        int quantity_reception = 0;
                        int.TryParse(Row[5].ToString(), out quantity_reception);

                        string Transaction_serial_id = string.Join(" ", Row[3].ToString().Split().Where(x => x != ""));
                        if (quantity_reception > 0)
                        {
                            // ADD FOR RECEPTION
                            Transactions_c newReception = new Transactions_c
                            {
                                Transaction_type = "IN",
                                Transaction_quantity = quantity_reception,
                                Transaction_tool_serial_id = Transaction_serial_id,
                                Transaction_by = string.Join(" ", Row[2].ToString().Split().Where(x => x != "")),
                                Transaction_comment = string.Join(" ", Row[13].ToString().Split().Where(x => x != "")),
                                Transaction_date = Row[1].ToString()
                            };
                            reception_isAdded = await Task.Run(() => Transactions_c.Add_single_Transaction(newReception, conn));
                        }

                        int quantity_output = 0;
                        int.TryParse(Row[6].ToString(), out quantity_output);
                        if (quantity_output > 0)
                        {
                            // ADD FOR OUTPUT
                            Transactions_c newOutput = new Transactions_c
                            {
                                Transaction_type = "OUT",
                                Transaction_quantity = quantity_output,
                                Transaction_tool_serial_id = Transaction_serial_id,
                                Transaction_req_prov = string.Join(" ", Row[12].ToString().Split().Where(x => x != "")),
                                Transaction_by = string.Join(" ", Row[2].ToString().Split().Where(x => x != "")),
                                Transaction_comment = string.Join(" ", Row[13].ToString().Split().Where(x => x != "")),
                                Transaction_date = Row[1].ToString()
                            };
                            output_isAdded = await Task.Run(() => Transactions_c.Add_single_Transaction(newOutput, conn));
                        }

                        if (output_isAdded) { count_transactions++; output_isAdded = false; }
                        else if (reception_isAdded) { count_transactions++; reception_isAdded = false; }
                        else { count_transactions_failed++; }

                        // ADD TRANSACTION TO DDB IF IT DOESN'T ESXIST
                        if(!Tools_c.isExist_serial_id(Transaction_serial_id, conn))
                        {
                            decimal price = 0;
                            decimal.TryParse(Row[8].ToString(), out price);
                            Tools_c NewTool = new Tools_c
                            {
                                Tool_serial_id = string.Join(" ", Row[3].ToString().Split().Where(x => x != "")),
                                Tool_designation = string.Join(" ", Row[4].ToString().Split().Where(x => x != "")),
                                Tool_price = price,
                                Tool_project = string.Join(" ", Row[14].ToString().Split().Where(x => x != "")),
                                Tool_division = string.Join(" ", Row[15].ToString().Split().Where(x => x != "")),
                            };
                            bool Tool_isAdded = await Task.Run(() => Tools_c.Add_single_tool(NewTool, conn));
                            if (Tool_isAdded) 
                            { 
                                count_tools++; 
                            } 
                            else
                            {
                                count_tools_failed++;
                            }
                        }
                    }
                    
                    FS.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    // SHOW SUCCESS
                    MessageBox.Show(count_tools + " Tools With " + count_tools_failed + " Failure & " + count_transactions + " Transactions With " + count_transactions_failed + " Failure added Successfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                Database_c.Close_DB_Connection();
            }
        }


        /// <summary>
        /// Export Data Base
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Export_excel_btn_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SaveFileDialog SaveDialog = new SaveFileDialog() { Filter = "Excel|*.xlsx|*.xls|*.xlsm" };
            Nullable<bool> returned = SaveDialog.ShowDialog();

            if (returned == true)
            {
                try
                {
                    SqlConnection conn = Database_c.Get_DB_Connection();
                    string query = "SELECT Tool_supplier as Supplier, Tool_supplier_code as Supplier_Code_article, " +
                        "Tool_serial_id as Serial_NB, Tool_image_name as Photo, Tool_designation as Designation, " +
                        "Tool_drawing as Drawing, Tool_project as project, Tool_process as Process, Tool_division as Division, " +
                        "Tool_position as Position, Tool_stock_mini as Stock_Mini, Tool_stock_max as Stock_Maxi, " +
                        "Tool_actual_stock as Actual_Stock, Tool_price as Price_euro " +
                        "FROM Tools Order By Tool_date_added DESC";

                    SqlDataAdapter adapter = await Task.Run(() => new SqlDataAdapter(query, conn));
                    DataTable Tools_Table = new DataTable();
                    adapter.Fill(Tools_Table);

                    XLWorkbook book = new XLWorkbook();
                    book.Worksheets.Add(Tools_Table, "Tools Database");

                    string query1 = "SELECT Transaction_date as Date, Transaction_by as Who, " +
                        "Transaction_tool_serial_id as Serial_NB, Transaction_type as Type, Transaction_quantity as Quantity, " +
                        "Transaction_req_prov as Requester, Transaction_comment as Comment " +
                        "FROM Transactions Order By Transaction_date DESC";

                    SqlDataAdapter adapter1 = await Task.Run(() => new SqlDataAdapter(query1, conn));
                    DataTable Transactions_Table = new DataTable();
                    adapter1.Fill(Transactions_Table);

                    book.Worksheets.Add(Transactions_Table, "Transactions");

                    book.SaveAs(SaveDialog.FileName);

                    // SUCCESS
                    MessageBox.Show(SaveDialog.FileName + " is saved successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    Database_c.Close_DB_Connection();
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                    Database_c.Close_DB_Connection();
                    return;
                }

            }
        }


        /// <summary>
        /// Delete All the Data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Delete_excel_btn_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MessageBoxResult dialogResult = MessageBox.Show("Do you really want to delete all the data of this Application !?", "Delete all data", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (dialogResult == MessageBoxResult.Yes)
            {
                bool tools_delete;
                bool transactions_delete;
                SqlConnection conn = Database_c.Get_DB_Connection();

                tools_delete = await Task.Run(() => Tools_c.Delete_all(conn));
                transactions_delete = await Task.Run(() => Transactions_c.Delete_all(conn));

                if (transactions_delete && tools_delete)
                {
                    MessageBox.Show("All data deleted succesfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Something went wrong! please try again.", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                Database_c.Close_DB_Connection();
            }
            else
            {
                return;
            }
        }
    
        private void InitializeUsers(SqlConnection conn)
        {
            DataTable UsersTable = new DataTable();
            users_rows_panel.Children.Clear();
            string query = "SELECT * FROM Users ";

            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            adapter.Fill(UsersTable);

            foreach (DataRow row in UsersTable.Rows)
            {
                try
                {
                    users_c newUser = new users_c
                    {
                        user_name = row["User_name"].ToString(),
                        user_fullName = row["User_fullname"].ToString(),
                        last_login = row["Last_login"].ToString(),
                        IsAdmin = bool.Parse(row["IsAdmin"].ToString()),
                        user_added_date = row["User_added_date"].ToString(),
                        privileges_id = row["Privileges_id"].ToString(),
                        isConnected = bool.Parse(row["isConnected"].ToString()),
                    };

                    users_rows_panel.Children.Add(new Controls.User_Account_Row(newUser));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void InitializeSettings(SqlConnection conn)
        {
            DataTable SettingsTable = new DataTable();
            string query = "SELECT * FROM App_settings WHERE isDefault = 1 ";
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(SettingsTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if(SettingsTable.Rows.Count > 0)
            {
                price_convert_value.Text = SettingsTable.Rows[0]["Euro_to_dt_value"].ToString();
                criticality_a.Text = SettingsTable.Rows[0]["Criticality_A_value"].ToString();
                criticality_b.Text = SettingsTable.Rows[0]["Criticality_B_value"].ToString();
                criticality_c.Text = SettingsTable.Rows[0]["Criticality_C_value"].ToString();
            }
        }

        private void Add_new_user_Click(object sender, RoutedEventArgs e)
        {
            Controls.Add_user_window new_user = new Controls.Add_user_window();
            new_user.Show();
            return;
        }

        private void Edit_settings_Click(object sender, RoutedEventArgs e)
        {
            Save_changes.Visibility = Visibility.Visible;
            Edit_settings.Visibility = Visibility.Collapsed;
            price_convert_value.IsEnabled = true;
            criticality_a.IsEnabled = true;
            criticality_b.IsEnabled = true;
            criticality_c.IsEnabled = true;
        }

        private void Save_changes_Click(object sender, RoutedEventArgs e)
        {

            SqlConnection conn = Database_c.Get_DB_Connection();

            decimal Euro_to_dt_value;
            decimal.TryParse(price_convert_value.Text.ToString(), out Euro_to_dt_value);

            int Criticality_A_value;
            int.TryParse(criticality_a.Text.ToString(), out Criticality_A_value);

            int Criticality_B_value;
            int.TryParse(criticality_b.Text.ToString(), out Criticality_B_value);

            int Criticality_C_value;
            int.TryParse(criticality_c.Text.ToString(), out Criticality_C_value);

            App_settings_c update_settings = new App_settings_c
            {
                Euro_to_dt_value = Euro_to_dt_value,
                Criticality_A_value = Criticality_A_value,
                Criticality_B_value = Criticality_B_value,
                Criticality_C_value = Criticality_C_value
            };

            MainWindow.Default_settings = update_settings;

            bool Updated = App_settings_c.updateDefaultSettings(conn, update_settings);

            if (Updated)
            {
                Edit_settings.Visibility = Visibility.Visible;
                Save_changes.Visibility = Visibility.Collapsed;
                price_convert_value.IsEnabled = false;
                criticality_a.IsEnabled = false;
                criticality_b.IsEnabled = false;
                criticality_c.IsEnabled = false;
            }

            Database_c.Close_DB_Connection();

        }
    }
}
