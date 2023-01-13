using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace ElcorteCheco
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string namepage = tabControl1.SelectedTab.Name;
            if (namepage == "tabPage1".ToString())
            {
 
                SqlConnection conexion = new SqlConnection("server=T4IPC02\\SQLEXPRESS; database = elcortecheco; integrated security = true");
                conexion.Open();
                string id = textBox1.Text;
                string cadena = " select id , marca, precio, hz from monitores where id = " + id;
                SqlCommand comando = new SqlCommand(cadena, conexion);
                SqlDataReader registro = comando.ExecuteReader();
                if (registro.Read())
                {
                    textBox2.Text = registro["marca"].ToString();
                    textBox4.Text = registro["precio"].ToString();
                    textBox3.Text = registro["hz"].ToString();
                }
                else
                {
                    MessageBox.Show(" No existe un artículo con el código introducido ");
                    conexion.Close();
                
            }


        }
            else if (namepage == "tabPage2".ToString())
            {
                SqlConnection conexion = new SqlConnection("server=T4IPC02\\SQLEXPRESS; database = elcortecheco; integrated security = true");
                conexion.Open();
                string id = textBox8.Text;
                string cadena = " select id , marca, precio, procesador from ordenadores where id = " + id;
                SqlCommand comando = new SqlCommand(cadena, conexion);
                SqlDataReader registro = comando.ExecuteReader();
                if (registro.Read())
                {
                    textBox7.Text = registro["marca"].ToString();
                    textBox5.Text = registro["precio"].ToString();
                    textBox6.Text = registro["procesador"].ToString();
                }
                else
                {
                    MessageBox.Show(" No existe un artículo con el código introducido ");
                    conexion.Close();

                }

            }else if(namepage == "tabPage3".ToString())
            {
                SqlConnection conexion = new SqlConnection("server=T4IPC02\\SQLEXPRESS; database = elcortecheco; integrated security = true");
                conexion.Open();
                string id = textBox12.Text;
                string cadena = " select id , marca, precio, tipo from discoduro where id = " + id;
                SqlCommand comando = new SqlCommand(cadena, conexion);
                SqlDataReader registro = comando.ExecuteReader();
                if (registro.Read())
                {
                    textBox11.Text = registro["marca"].ToString();
                    textBox9.Text = registro["precio"].ToString();
                    textBox10.Text = registro["tipo"].ToString();
                }
                else
                {
                    MessageBox.Show(" No existe un artículo con el código introducido ");
                    conexion.Close();

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string namepage = tabControl1.SelectedTab.Name;
            if (namepage == "tabPage1".ToString())
            {
                SqlConnection conexion = new SqlConnection("server=T4IPC02\\SQLEXPRESS; database = elcortecheco; integrated security = true");
                conexion.Open();
                string id = textBox1.Text;
                string marca = textBox2.Text;
                string precio = textBox4.Text;
                string hz = textBox3.Text;
                string cadena = "insert into monitores ( id, marca, precio, hz) values ( " + id + " , '" + marca + "' , '" + precio + "','" + hz +"') ";
                SqlCommand comando = new SqlCommand(cadena, conexion);
                comando.ExecuteNonQuery();
                MessageBox.Show(" Los datos se guardaron correctamente ");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                conexion.Close();

            }
            else if (namepage == "tabPage2".ToString())
            {
                SqlConnection conexion = new SqlConnection("server=T4IPC02\\SQLEXPRESS; database = elcortecheco; integrated security = true");
                conexion.Open();
                string id = textBox8.Text;
                string marca = textBox7.Text;
                string precio = textBox5.Text;
                string procesador = textBox6.Text;
                string cadena = "insert into ordenadores ( id, marca, precio, procesador) values ( " + id + " , '" + marca + "' , '" + precio + "','" + procesador + "') ";
                SqlCommand comando = new SqlCommand(cadena, conexion);
                comando.ExecuteNonQuery();
                MessageBox.Show(" Los datos se guardaron correctamente ");
                textBox8.Text = "";
                textBox5.Text = "";
                textBox7.Text = "";
                textBox6.Text = "";
                conexion.Close();
            }else if(namepage == "tabPage3".ToString())
            {
                SqlConnection conexion = new SqlConnection("server=T4IPC02\\SQLEXPRESS; database = elcortecheco; integrated security = true");
                conexion.Open();
                string id = textBox12.Text;
                string marca = textBox11.Text;
                string precio = textBox9.Text;
                string tipo = textBox10.Text;
                string cadena = "insert into discoduro ( id, marca, precio, tipo) values ( " + id + " , '" + marca + "' , '" + precio + "','" + tipo + "') ";
                SqlCommand comando = new SqlCommand(cadena, conexion);
                comando.ExecuteNonQuery();
                MessageBox.Show(" Los datos se guardaron correctamente ");
                textBox12.Text = "";
                textBox11.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                conexion.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string namepage = tabControl1.SelectedTab.Name;
            if (namepage == "tabPage1".ToString())
            {
                SqlConnection conexion = new SqlConnection("server=T4IPC02\\SQLEXPRESS; database = elcortecheco; integrated security = true");
                conexion.Open();
                string id = textBox1.Text;
                string marca = textBox2.Text;
                string precio = textBox4.Text;
                string hz = textBox3.Text;
                string cadena = "UPDATE monitores set marca = '" + marca + "', precio= " + precio +  ", hz = " + hz + " where  id = " + id; 
                SqlCommand comando = new SqlCommand(cadena, conexion);
                comando.ExecuteNonQuery();
                MessageBox.Show(" Los datos se guardaron correctamente ");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                conexion.Close();

            }
            else if (namepage == "tabPage2".ToString())
            {
                SqlConnection conexion = new SqlConnection("server=T4IPC02\\SQLEXPRESS; database = elcortecheco; integrated security = true");
                conexion.Open();
                string id = textBox8.Text;
                string marca = textBox7.Text;
                string precio = textBox5.Text;
                string procesador = textBox6.Text;
                string cadena = "UPDATE ordenadores set marca = '" + marca + "', precio= " + precio + ", procesador = " + procesador + " where  id = " + id;
                SqlCommand comando = new SqlCommand(cadena, conexion);
                comando.ExecuteNonQuery();
                MessageBox.Show(" Los datos se guardaron correctamente ");
                textBox8.Text = "";
                textBox7.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                conexion.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox8.Text = "";
            textBox7.Text = "";
            textBox5.Text = "";
            textBox12.Text = "";
            textBox11.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox6.Text = "";

        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}



