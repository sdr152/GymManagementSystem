using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace GymManagementSystem
{
    public partial class NewCustomerForm : Form
    {
        private NewCustomerObject newCustomer;
        public NewCustomerForm()
        {
            InitializeComponent();
            newCustomer = new NewCustomerObject();
        }

        // Editar No. Identidad
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            newCustomer.customerId = textBox1.Text;
        }

        // Editar Nombre Completo
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            newCustomer.name = textBox2.Text;
        }

        // Editar Telefono
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            newCustomer.phonenumber = textBox3.Text;
        }

        // Editar genero
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            newCustomer.gender = comboBox1.Text;
        }

        // Editar Tipo de Membresia
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            newCustomer.tipo_memb = comboBox2.Text;
        }

        // Edit Payment date
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            newCustomer.fecha_pago = dateTimePicker1.Text;
            newCustomer.dias_mora = "0";
        }

        // Edit Button
        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=C:\\Users\\Samuel Ramos\\CSharp\\GymManagementSystem\\GymDatabase.db;Version=3;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = $"INSERT INTO Clientes (Identidad, NombreCompleto, Status, TipoMembresia, FechaPago, DiasMora) VALUES ({newCustomer.customerId}, '{newCustomer.name}', 'Activo', '{newCustomer.tipo_memb}', '{newCustomer.fecha_pago}', {newCustomer.dias_mora})";
                    command.ExecuteNonQuery();
                }
            }
            Close();
        }
    }
    public class NewCustomerObject
    {
        public string customerId { get; set; }
        public string name { get; set; }
        public string phonenumber { get; set; }
        public string status { get; set; }
        public string gender { get; set; }
        public string tipo_memb { get; set; }
        public string fecha_pago { get; set; }
        public string dias_mora = "0";

    }
}
