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
    public partial class NewUserForm : Form
    {
        string tableName = "Empleados";
        private NewUserObject newUser;
        public NewUserForm()
        {
            InitializeComponent();
            newUser = new NewUserObject();
            
        }

        // Editar No. Identidad
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            newUser.userId = textBox1.Text;
        }

        // Editar Primer Nombre
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            newUser.fname = textBox2.Text;
        }

        // Editar Middle Name
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            newUser.mname = textBox3.Text;
        }

        // Editar Primer Apellido
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            newUser.lname = textBox4.Text;
        }

        // Editar Segundo Apellido
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            newUser.slname = textBox5.Text;
        }

        // Editar genero
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            newUser.gender = comboBox1.Text;
        }

        // Editar numero de telefono
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            newUser.phonenumber = textBox6.Text;
        }

        // input user
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            newUser.username = textBox7.Text;
        }
        // input password
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            newUser.contra = textBox8.Text;
        }
        // Edit Button
        private void button1_Click_1(object sender, EventArgs e)
        {
            string connectionString = "Data Source=C:\\Users\\Samuel Ramos\\CSharp\\GymManagementSystem\\GymDatabase.db;Version=3;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = $"INSERT INTO {tableName} (Identidad, PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido, Genero, Telefono, Usuario, contra) VALUES ('{newUser.userId}', '{newUser.fname}', '{newUser.mname}', '{newUser.lname}', '{newUser.slname}', '{newUser.gender}', '{newUser.phonenumber}', '{newUser.username}', '{newUser.contra}')";
                    command.ExecuteNonQuery();
                }
            }
            Close();
        }
        
    }
    public class NewUserObject
    {
        public string userId { get; set; }
        public string fname { get; set; }
        public string mname { get; set; }
        public string lname { get; set; }
        public string slname { get; set; }
        public string phonenumber { get; set; }
        public string gender { get; set; }
        public string username { get; set; }
        public string contra { get; set; }
       

    }
}
