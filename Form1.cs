using System.Data;
using System.Data.SQLite;


namespace GymManagementSystem
{
    public partial class Form1 : Form
    {
        string dbPath = "C:\\Users\\Samuel Ramos\\CSharp\\GymManagementSystem\\GymDatabase.db";
        string tableName = "Clientes";
        public Form1()
        {
            InitializeComponent();

            // Connect to DB
            string connectionString = $"Data Source={dbPath};Version=3;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            {
                connection.Open();
                string query = $"SELECT name FROM sqlite_master WHERE type='table' AND name='{tableName}'";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    object result = command.ExecuteScalar();
                    if (result == null)
                    {
                        // Table does not exist.
                        Console.WriteLine("Table does not exists!");
                        command.CommandText = $"CREATE TABLE {tableName} (Identidad INTEGER, NombreCompleto TEXT, Status TEXT, TipoMembresia TEXT, FechaPago DATE, DiasMora INTEGER )";
                        command.ExecuteNonQuery();
                    }
                    // Retrieve data from sqlite DB
                    string query2 = $"SELECT * FROM {tableName}";
                    SQLiteCommand command2 = new SQLiteCommand(query2, connection);
                    SQLiteDataReader reader = command2.ExecuteReader();

                    // Create a DataTable to store the results
                    DataTable dataTable = new DataTable();

                    // Define columns in the dataTable
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
            }

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
    }
}