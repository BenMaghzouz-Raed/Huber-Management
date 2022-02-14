using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Huber_Management
{
    public class App_settings_c
    {
        public decimal Euro_to_dt_value { get; set; } = 3;
        public int Criticality_A_value { get; set; } = 90;
        public int Criticality_B_value { get; set; } = 60;
        public int Criticality_C_value { get; set; } = 15;


        public static int getDefaultSettings_id(SQLiteConnection conn)
        {
            string query = "SELECT Settings_id FROM App_settings WHERE isDefault = 1";
            DataTable table = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn);
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return int.Parse(table.Rows[0]["Settings_id"].ToString());
            }
            else
            {
                return -1;
            }

        }

        public static bool updateDefaultSettings(SQLiteConnection conn, App_settings_c database_settings)
        {
            int settings_id_default = getDefaultSettings_id(conn);

            string query;

            if(settings_id_default == -1)
            {
                query = "INSERT INTO App_settings (Euro_to_dt_value, Criticality_A_value, Criticality_B_value, Criticality_C_value) " +
             "VALUES (@Euro_to_dt_value, @Criticality_A_value, @Criticality_B_value, @Criticality_C_value) ";

            }
            else
            {
                query = "UPDATE App_settings SET Euro_to_dt_value = @Euro_to_dt_value, " +
                "Criticality_A_value = @Criticality_A_value, Criticality_B_value = @Criticality_B_value, " +
                "Criticality_C_value = @Criticality_C_value WHERE Settings_id = " + settings_id_default + " ";
            }

            try
            {
                SQLiteCommand command = new SQLiteCommand(query, conn);

                command.Parameters.AddWithValue("@Euro_to_dt_value", database_settings.Euro_to_dt_value);
                command.Parameters.AddWithValue("@Criticality_A_value", database_settings.Criticality_A_value);
                command.Parameters.AddWithValue("@Criticality_B_value", database_settings.Criticality_B_value);
                command.Parameters.AddWithValue("@Criticality_C_value", database_settings.Criticality_C_value);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;

        }

        public static DataTable getAllDefaultSettings(SQLiteConnection conn)
        {
            string query = "SELECT * FROM App_settings WHERE isDefault = 1";
            DataTable table = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn);

            adapter.Fill(table);
            return table;

        }
    }
}
