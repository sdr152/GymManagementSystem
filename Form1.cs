using System.Data;
using System.Data.SQLite;


namespace GymManagementSystem
{
    public partial class Form1 : Form
    {
        string dbPath = "C:\\Users\\Samuel Ramos\\CSharp\\GymManagementSystem\\GymDatabase.db";
        string tableName = "Clientes";
        SQLiteConnection connection;
        public Form1()
        {
            InitializeComponent();

            // Connect to DB
            string connectionString = $"Data Source={dbPath};Version=3;";
            connection = new SQLiteConnection(connectionString);
            connect_to_sqlite(connection, tableName);
            update_dataGrid1(tableName, connection);
        }
        private void connect_to_sqlite(SQLiteConnection connection, string tableName)
        {
            connection.Open();
            string query = $"SELECT name FROM sqlite_master WHERE type='table' AND name='{tableName}'";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            object result = command.ExecuteScalar();
            if (result == null)
            {
                command.CommandText = $"CREATE TABLE {tableName} (Identidad INTEGER, NombreCompleto TEXT, Status TEXT, TipoMembresia TEXT, FechaPago DATE, DiasMora INTEGER )";
                command.ExecuteNonQuery();
            }

        }

        private void update_dataGrid1(string tableName, SQLiteConnection connection)
        {
            string query = $"SELECT * FROM {tableName};";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            SQLiteDataReader reader = command.ExecuteReader();

            DataTable dataTable = new DataTable();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                string columnName = reader.GetName(i);
                Type columnType = reader.GetFieldType(i);
                dataTable.Columns.Add(columnName, columnType);
            }

            while (reader.Read())
            {
                DataRow row = dataTable.NewRow();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    if (reader.IsDBNull(i))
                    {
                        row[i] = DBNull.Value;
                    }
                    else
                    {
                        if (dataTable.Columns[i].DataType == typeof(DateTime))
                        {
                            string dateString = reader.GetString(i);
                            if (DateTime.TryParseExact(dateString, "M/d/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dateValue))
                            {
                                row[i] = dateValue;
                            }
                            else
                            {
                                row[i] = DBNull.Value;
                            }

                        }
                        else
                        {
                            row[i] = reader.GetValue(i);
                        }
                    }
                }
                dataTable.Rows.Add(row);
            }
            dataGridView1.DataSource = dataTable;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewCustomerForm newcustomer = new NewCustomerForm();
            newcustomer.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            CheckinForm checkin = new CheckinForm();
            checkin.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EditCustomerForm editCustomer = new EditCustomerForm();
            editCustomer.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            update_dataGrid1(tableName, connection);
        }
    }
}