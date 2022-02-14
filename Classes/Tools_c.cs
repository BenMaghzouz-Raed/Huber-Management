using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using System.Data.SQLite;    //*local DB
using System.Data;
using System.Diagnostics;
using System.IO;

namespace Huber_Management
{
    public class Tools_c
    {
        public string Tool_serial_id { get; set; }
        public string Tool_designation { get; set; } = "";
        public string Tool_drawing { get; set; } = "";
        public string Tool_project { get; set; } = "";
        public string Tool_process { get; set; } = "";
        public string Tool_division { get; set; } = "";
        public string Tool_position { get; set; } = "";
        public int Tool_stock_mini { get; set; }
        public int Tool_stock_max { get; set; }
        public int Tool_actual_stock { get; set; }
        public string Tool_supplier { get; set; } = "";
        public string Tool_supplier_code { get; set; } = "";
        public decimal Tool_price { get; set; }
        public string Tool_status { get; set; } = "OK";
        public int Tool_criticality { get; set; }
        public string Tool_date_added { get; set; }
        public string Tool_image_path { get; set; } = "";
        public string Tool_image_name { get; set; } = "";


        public static DataTable Get_all(SQLiteConnection con)
        {
            DataTable table = new DataTable();

            string Query = "SELECT * FROM Tools Order by Tool_date_added DESC ";

            SQLiteDataAdapter adapter = new SQLiteDataAdapter(Query, con);
            adapter.Fill(table);

            return table;
        }

        public static DataTable Get_by_serial_id(string _serial_id, SQLiteConnection con)
        {
            DataTable table = new DataTable();

            string Query = "SELECT * FROM Tools WHERE Tool_serial_id = @serial_id";

            SQLiteCommand command = new SQLiteCommand(Query, con);
            command.Parameters.AddWithValue("@serial_id", _serial_id);

            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            adapter.Fill(table);

            return table;
        }

        public static bool isExist_serial_id(string _serial_id, SQLiteConnection con)
        {
            DataTable table = new DataTable();

            string Query = "SELECT COUNT(Tool_serial_id) as count_id FROM Tools WHERE Tool_serial_id = @serial_id";

            SQLiteCommand command = new SQLiteCommand(Query, con);
            command.Parameters.AddWithValue("@serial_id", _serial_id);

            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            adapter.Fill(table);
            int number = int.Parse(table.Rows[0]["count_id"].ToString());
            bool test = ( number == 0) ? false : true;

            return test;
        }

        public static void Delete_by_serial_id(string _serial_id, SQLiteConnection con)
        {
            try
            {
            string Query = "Delete FROM Tools WHERE Tool_serial_id = @serial_id";
            SQLiteCommand command = new SQLiteCommand(Query, con);
            command.Parameters.AddWithValue("@serial_id", _serial_id);
            command.ExecuteNonQuery();

            string Query2 = "Delete FROM Transactions WHERE Transaction_tool_serial_id = @serial_id";
            SQLiteCommand command2 = new SQLiteCommand(Query2, con);
            command2.Parameters.AddWithValue("@serial_id", _serial_id);
            command2.ExecuteNonQuery();

            string Query3 = "Delete FROM Faulty_Tools WHERE Tool_serial_id = @serial_id";
            SQLiteCommand command3 = new SQLiteCommand(Query3, con);
            command3.Parameters.AddWithValue("@serial_id", _serial_id);
            command3.ExecuteNonQuery();

            string Query4 = "Delete FROM Repaired_Tools WHERE Tool_serial_id = @serial_id";
            SQLiteCommand command4 = new SQLiteCommand(Query4, con);
            command4.Parameters.AddWithValue("@serial_id", _serial_id);
            command4.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            finally
            {
                MainWindow._All_tools_page.InitializeAllData_Filters_Function();
            }
            return;
        }

        public static bool Delete_all(SQLiteConnection con)
        {
            bool deleted = false;
            try
            {
                string Query = "Delete FROM Tools";
                SQLiteCommand command = new SQLiteCommand(Query, con);
                command.ExecuteNonQuery();

                string Query1 = "Delete FROM Transactions";
                SQLiteCommand command1 = new SQLiteCommand(Query1, con);
                command1.ExecuteNonQuery();

                string Query2 = "Delete FROM Faulty_Tools";
                SQLiteCommand command2 = new SQLiteCommand(Query2, con);
                command2.ExecuteNonQuery();

                string Query3 = "Delete FROM Repaired_Tools";
                SQLiteCommand command3 = new SQLiteCommand(Query3, con);
                command3.ExecuteNonQuery();
                deleted = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return deleted;
        }

        /// <summary>
        /// ADD NEW TOOL
        /// </summary>
        /// <param name="Tool"></param>
        /// <param name="con"></param>
        /// <returns></returns>
        public static bool Add_single_tool(Tools_c Tool, SQLiteConnection con)
        {
            if (isExist_serial_id(Tool.Tool_serial_id, con))
            {
                return false;
            }
            else
            {
              string Query = "INSERT INTO Tools (Tool_serial_id, Tool_designation, Tool_drawing, Tool_project, Tool_process, Tool_division, " +
              "Tool_position, Tool_stock_mini, Tool_stock_max, Tool_actual_stock, Tool_supplier, Tool_supplier_code, Tool_price, " +
              "Tool_status, Tool_criticality, Tool_image_path, Tool_image_name, Tool_date_added)" +
              "VALUES (@Tool_serial_id, @Tool_designation, @Tool_drawing, @Tool_project, @Tool_process, @Tool_division, " +
              "@Tool_position, @Tool_stock_mini, @Tool_stock_max, @Tool_actual_stock, @Tool_supplier, @Tool_supplier_code, " +
              "@Tool_price, @Tool_status, @Tool_criticality, @Tool_image_path, @Tool_image_name, DATETIME('now', 'localtime'))";

                SQLiteCommand command = new SQLiteCommand(Query, con);
                try
                {
                    string tool_serial_id = string.Join(" ", Tool.Tool_serial_id.ToString().Split().Where(x => x != ""));
                    command.Parameters.AddWithValue("@Tool_serial_id", tool_serial_id);

                    command.Parameters.AddWithValue("@Tool_designation", Tool.Tool_designation);

                    command.Parameters.AddWithValue("@Tool_drawing", Tool.Tool_drawing);

                    command.Parameters.AddWithValue("@Tool_project", Tool.Tool_project);

                    command.Parameters.AddWithValue("@Tool_process", Tool.Tool_process);

                    command.Parameters.AddWithValue("@Tool_division", Tool.Tool_division);

                    command.Parameters.AddWithValue("@Tool_position", Tool.Tool_position);

                    command.Parameters.AddWithValue("@Tool_stock_mini", Tool.Tool_stock_mini);
                    command.Parameters.AddWithValue("@Tool_stock_max", Tool.Tool_stock_max);
                    command.Parameters.AddWithValue("@Tool_actual_stock", Tool.Tool_actual_stock);
                    command.Parameters.AddWithValue("@Tool_price", Tool.Tool_price);

                    command.Parameters.AddWithValue("@Tool_supplier", Tool.Tool_supplier);
                    command.Parameters.AddWithValue("@Tool_supplier_code", Tool.Tool_supplier_code);
                    
                    command.Parameters.AddWithValue("@Tool_criticality", Tool.Tool_criticality);
                    command.Parameters.AddWithValue("@Tool_status", Tool.Tool_status);
                    command.Parameters.AddWithValue("@Tool_image_path", Tool.Tool_image_path);
                    command.Parameters.AddWithValue("@Tool_image_name", Tool.Tool_image_name);

                    if (Tool.Tool_image_path != "")
                    {
                        SaveImageToFolder(Tool.Tool_image_path, Tool.Tool_image_name);
                    }
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }

                return true;
            }
        }

        /// <summary>
        /// UPDATE SINGLE TOOL
        /// </summary>
        /// <param name="Tool"></param>
        /// <param name="con"></param>
        /// <returns></returns>
        public static bool Update_single_tool(Tools_c Tool, SQLiteConnection con)
        {
            string Query = "UPDATE Tools SET Tool_designation = @Tool_designation, Tool_drawing = @Tool_drawing, Tool_project = @Tool_project, " +
                    "Tool_process = @Tool_process, Tool_division =  @Tool_division, Tool_position = @Tool_position, " +
                    "Tool_stock_mini = @Tool_stock_mini, Tool_stock_max = @Tool_stock_max, Tool_actual_stock = @Tool_actual_stock, " +
                    "Tool_supplier = @Tool_supplier, Tool_supplier_code =  @Tool_supplier_code, Tool_price = @Tool_price, " +
                    "Tool_status = @Tool_status, Tool_image_path = @Tool_image_path, Tool_image_name = @Tool_image_name, Tool_criticality = @Tool_criticality " +
                    "WHERE Tool_serial_id = @Tool_serial_id";

            SQLiteCommand command = new SQLiteCommand(Query, con);
            try
            {
                command.Parameters.AddWithValue("@Tool_serial_id", Tool.Tool_serial_id);
                command.Parameters.AddWithValue("@Tool_designation", Tool.Tool_designation);
                command.Parameters.AddWithValue("@Tool_drawing", Tool.Tool_drawing);
                command.Parameters.AddWithValue("@Tool_project", Tool.Tool_project);
 
                command.Parameters.AddWithValue("@Tool_stock_mini", Tool.Tool_stock_mini);
                command.Parameters.AddWithValue("@Tool_stock_max", Tool.Tool_stock_max);
                command.Parameters.AddWithValue("@Tool_actual_stock", Tool.Tool_actual_stock);
                command.Parameters.AddWithValue("@Tool_price", Tool.Tool_price);

                command.Parameters.AddWithValue("@Tool_supplier", Tool.Tool_supplier);
                command.Parameters.AddWithValue("@Tool_process", Tool.Tool_process);
                command.Parameters.AddWithValue("@Tool_division", Tool.Tool_division);
                command.Parameters.AddWithValue("@Tool_position", Tool.Tool_position);
                command.Parameters.AddWithValue("@Tool_supplier_code", Tool.Tool_supplier_code);

                command.Parameters.AddWithValue("@Tool_criticality", Tool.Tool_criticality);
                command.Parameters.AddWithValue("@Tool_status", Tool.Tool_status);
                command.Parameters.AddWithValue("@Tool_image_path", Tool.Tool_image_path);
                command.Parameters.AddWithValue("@Tool_image_name", Tool.Tool_image_name);

                if (Tool.Tool_image_path != "")
                {
                    SaveImageToFolder(Tool.Tool_image_path, Tool.Tool_image_name);
                }

                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// SAVE IMAGE IN THE db_images FOLDER
        /// </summary>
        /// <param name="_image_path"></param>
        /// <param name="_image_name"></param>
        private static string SaveImageToFolder(string _image_path ,string _image_name)
        {
            // Get Desitination Path
            string path = Path.Combine(Environment.CurrentDirectory, @"Database\db_images\", _image_name).ToString();
            try
            {
                // Create the folder
                System.IO.Directory.CreateDirectory(@".\Database\db_images");
                // Copy the Image
                File.Copy(_image_path, path, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return path;
        }
    
    }
}
