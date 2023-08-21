using System.Data;
using System.Data.SQLite;


namespace GymManagementSystem
{
    public partial class LoginForm : Form
    {
        string dbPath = "C:\\Users\\Samuel Ramos\\CSharp\\GymManagementSystem\\GymDatabase.db";
        string tableName = "Empleados";
        SQLiteConnection connection;
        DateTime dateTime = DateTime.Now.AddMilliseconds(1000);

        public LoginForm()
        {
            InitializeComponent();
            //label3.Text = dateTime.ToString();
            // Connect to DB
            string connectionString = $"Data Source={dbPath};Version=3;";
            connection = new SQLiteConnection(connectionString);
            connect_to_sqlite(connection, tableName);
            
        }
        private void connect_to_sqlite(SQLiteConnection connection, string tableName)
        {
            connection.Open();
            string query = $"SELECT name FROM sqlite_master WHERE type='table' AND name='{tableName}'";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            object result = command.ExecuteScalar();
            if (result == null)
            {
                command.CommandText = $"CREATE TABLE {tableName} (Identidad VARCHAR, PrimerNombre TEXT, SegundoNombre TEXT, PrimerApellido TEXT, SegundoApellido TEXT, Contra VARCHAR)";
                command.ExecuteNonQuery();
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