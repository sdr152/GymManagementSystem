using System.Data;
using System.Data.SQLite;


namespace GymManagementSystem
{
    public partial class LoginForm : Form
    {
        string dbPath = "C:\\Users\\Samuel Ramos\\CSharp\\GymManagementSystem\\GymDatabase.db";
        string[] tableNames = { "Empleados", "Clientes" };
        SQLiteConnection connection;
        DateTime dateTime = DateTime.Now.AddMilliseconds(1000);

        public LoginForm()
        {
            InitializeComponent();
                        
            // Connect to DB
            string connectionString = $"Data Source={dbPath};Version=3;";
            connection = new SQLiteConnection(connectionString);
            connect_to_sqlite(connection, tableNames);
        }

        private void connect_to_sqlite(SQLiteConnection connection, string[] tableNames)
        {
            connection.Open();
            string query = $"SELECT name FROM sqlite_master WHERE type='table' AND name='{tableNames[0]}'";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            object result = command.ExecuteScalar();
            if (result == null)
            {
                command.CommandText = $"CREATE TABLE {tableNames[0]} (Identidad VARCHAR, PrimerNombre TEXT, SegundoNombre TEXT, PrimerApellido TEXT, SegundoApellido TEXT, Genero VARCHAR, Telefono VARCHAR, Contra VARCHAR)";
                command.ExecuteNonQuery();
            }

            string query2 = $"SELECT name FROM sqlite_master WHERE type='table' AND name = '{tableNames[1]}'";
            SQLiteCommand command2 = new SQLiteCommand(query2, connection);
            object result2 = command2.ExecuteScalar();
            if (result2 == null)
            {
                command2.CommandText = $"CREATE TABLE {tableNames[1]} (Identidad VARCHAR, NombreCompleto TEXT, Status VARCHAR, TipoMembresia VARCHAR, FechaPago DATE, DiasMora INTEGER )";
                command2.ExecuteNonQuery();
            }
        }

        // User entry
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // Password entry
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        // Sign in button
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "manager" && textBox2.Text == "manager")
            {
                new Form1().Show();
            }
        }
    }
}