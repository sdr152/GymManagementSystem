using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymManagementSystem
{
    public partial class EditCustomerForm : Form
    {
        string dbPath = "C:\\Users\\Samuel Ramos\\CSharp\\GymManagementSystem\\GymDatabase.db";
        string tableName = "Clientes";
        SQLiteConnection connection;

        public EditCustomerForm()
        {
            InitializeComponent();
            string connectionString = $"Data Source={dbPath};Version=3;";
            connection = new SQLiteConnection(connectionString);
            connection.Open();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                return;
            }
            long id = Convert.ToInt64(textBox2.Text);

            string query = $"SELECT * FROM {tableName} WHERE Identidad={id};";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            SQLiteDataReader reader = command.ExecuteReader();

            DataTable dt = new DataTable();
            for (int i=0; i<reader.FieldCount; i++)
            {
                string columnName = reader.GetName(i);
                Type columnType = reader.GetFieldType(i);
                dt.Columns.Add(columnName, columnType);
            }
            while (reader.Read())
            {
                DataRow dr = dt.NewRow();
                for (int i = 0; i<reader.FieldCount; i++)
                {
                    if (reader.IsDBNull(i))
                    {
                        dr[i] = DBNull.Value;
                    }
                    else
                    {
                        if (dt.Columns[i].DataType == typeof(DateTime))
                        {
                            string dateString = reader.GetString(i);
                            if (DateTime.TryParseExact(dateString, "M/d/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dateValue))
                            {
                                dr[i] = dateValue;
                            }
                            else
                            {
                                dr[i] = DBNull.Value;
                            }
                        }
                        else
                        {
                            dr[i] = reader.GetValue(i);
                        }
                    }
                }
                dt.Rows.Add(dr);
            }
            dataGridView1.DataSource = dt;
        }
    }
}
