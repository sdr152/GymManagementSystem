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
                // Perform db operations here
                string query = $"SELECT name FROM sqlite_master WHERE type='table' AND name='{tableName}'";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        // Table exists
                        Console.WriteLine("Table already exists!");
                    }
                    else
                    {
                        // Table does not exists
                        Console.WriteLine("Table does not exists!");
                        command.CommandText = $"CREATE TABLE {tableName} (Identidad INTEGER, NombreCompleto TEXT, Status TEXT, TipoMembresia TEXT, FechaPago DATE, DiasMora INTEGER )";
                        command.ExecuteNonQuery();
                    }
                    
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