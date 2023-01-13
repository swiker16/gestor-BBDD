using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;

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
                SqlConnection conexionImagen = new SqlConnection("server=T4IPC02\\SQLEXPRESS; database = elcortecheco; integrated security = true");
                string cadenaImagen = "select Imagen from monitores where id=" + textBox1.Text;
                SqlCommand comandoImagen = new SqlCommand(cadenaImagen, conexionImagen);
                conexionImagen.Open();
                SqlDataAdapter da = new SqlDataAdapter(comandoImagen);
                DataSet ds = new DataSet();
                da.Fill(ds, "monitores");//mete la tabla inventario en el dataset ds

                int c = ds.Tables["monitores"].Rows.Count;//mira el numero de filas que ha recibido para la tabla inventario
                if (!Convert.IsDBNull(ds.Tables["monitores"].Rows[c - 1]["imagen"]))
                {//se evalua si se ha obtenido imagen.
                    Byte[] byteImagen = new Byte[0];
                    byteImagen = (Byte[])(ds.Tables["monitores"].Rows[c - 1]["imagen"]);
                    MemoryStream stmBLOBData = new MemoryStream(byteImagen);
                    pictureBox1.Image = Image.FromStream(stmBLOBData);
                }
                else
                {
                    pictureBox1.Image = null;
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
                SqlConnection conexionImagen = new SqlConnection("server=T4IPC02\\SQLEXPRESS; database = elcortecheco; integrated security = true");
                string cadenaImagen = "select Imagen from ordenadores where id=" + textBox8.Text;
                SqlCommand comandoImagen = new SqlCommand(cadenaImagen, conexionImagen);
                conexionImagen.Open();
                SqlDataAdapter da = new SqlDataAdapter(comandoImagen);
                DataSet ds = new DataSet();
                da.Fill(ds, "ordenadores");//mete la tabla inventario en el dataset ds

                int c = ds.Tables["ordenadores"].Rows.Count;//mira el numero de filas que ha recibido para la tabla inventario
                if (!Convert.IsDBNull(ds.Tables["ordenadores"].Rows[c - 1]["imagen"]))
                {//se evalua si se ha obtenido imagen.
                    Byte[] byteImagen = new Byte[0];
                    byteImagen = (Byte[])(ds.Tables["ordenadores"].Rows[c - 1]["imagen"]);
                    MemoryStream stmBLOBData = new MemoryStream(byteImagen);
                    pictureBox2.Image = Image.FromStream(stmBLOBData);
                }
                else
                {
                    pictureBox2.Image = null;
                }
            }
            else if (namepage == "tabPage3".ToString())
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
                SqlConnection conexionImagen = new SqlConnection("server=T4IPC02\\SQLEXPRESS; database = elcortecheco; integrated security = true");
                string cadenaImagen = "select Imagen from discoduro where id=" + textBox12.Text;
                SqlCommand comandoImagen = new SqlCommand(cadenaImagen, conexionImagen);
                conexionImagen.Open();
                SqlDataAdapter da = new SqlDataAdapter(comandoImagen);
                DataSet ds = new DataSet();
                da.Fill(ds, "discoduro");//mete la tabla inventario en el dataset ds

                int c = ds.Tables["discoduro"].Rows.Count;//mira el numero de filas que ha recibido para la tabla inventario
                if (!Convert.IsDBNull(ds.Tables["discoduro"].Rows[c - 1]["imagen"]))
                {//se evalua si se ha obtenido imagen.
                    Byte[] byteImagen = new Byte[0];
                    byteImagen = (Byte[])(ds.Tables["discoduro"].Rows[c - 1]["imagen"]);
                    MemoryStream stmBLOBData = new MemoryStream(byteImagen);
                    pictureBox3.Image = Image.FromStream(stmBLOBData);
                }
                else
                {
                    pictureBox3.Image = null;
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
                String precio = textBox4.Text.Replace(',', '.');
                string hz = textBox3.Text;
                string cadena = "insert into monitores ( id, marca, precio, hz) values ( " + id + " , '" + marca + "' , '" + precio + "','" + hz + "') ";
                SqlCommand comando = new SqlCommand(cadena, conexion);
                comando.ExecuteNonQuery();
                MessageBox.Show(" Los datos se guardaron correctamente ");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                if (pictureBox1.Image != null)
                {

                    SqlCommand comandoMeterImagen = new SqlCommand();

                    comandoMeterImagen.Connection = conexion;
                    comandoMeterImagen.CommandText = "Update monitores Set Imagen=@Foto where id='" + id + "'";
                    comandoMeterImagen.Parameters.Add("@Foto", System.Data.SqlDbType.Image);

                    //Imagen
                    MemoryStream stream = new MemoryStream();
                    pictureBox1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

                    comandoMeterImagen.Parameters["@Foto"].Value = stream.GetBuffer();
                    comandoMeterImagen.ExecuteNonQuery();
                    conexion.Close();
                }
                pictureBox1.Image = null;

                conexion.Close();

            }
            else if (namepage == "tabPage2".ToString())
            {
                SqlConnection conexion = new SqlConnection("server=T4IPC02\\SQLEXPRESS; database = elcortecheco; integrated security = true");
                conexion.Open();
                string id = textBox8.Text;
                string marca = textBox7.Text;
                string precio = textBox5.Text.Replace(',', '.'); 
                string procesador = textBox6.Text;
                string cadena = "insert into ordenadores ( id, marca, precio, procesador) values ( " + id + " , '" + marca + "' , '" + precio + "','" + procesador + "') ";
                SqlCommand comando = new SqlCommand(cadena, conexion);
                comando.ExecuteNonQuery();
                MessageBox.Show(" Los datos se guardaron correctamente ");
                textBox8.Text = "";
                textBox7.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                if (pictureBox2.Image != null)
                {

                    SqlCommand comandoMeterImagen = new SqlCommand();

                    comandoMeterImagen.Connection = conexion;
                    comandoMeterImagen.CommandText = "Update ordenadores Set Imagen=@Foto where id='" + id + "'";
                    comandoMeterImagen.Parameters.Add("@Foto", System.Data.SqlDbType.Image);

                    //Imagen
                    MemoryStream stream = new MemoryStream();
                    pictureBox2.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

                    comandoMeterImagen.Parameters["@Foto"].Value = stream.GetBuffer();
                    comandoMeterImagen.ExecuteNonQuery();
                    conexion.Close();
                }

                pictureBox2.Image = null;
                conexion.Close();
                conexion.Close();
            }
            else if (namepage == "tabPage3".ToString())
            {
                SqlConnection conexion = new SqlConnection("server=T4IPC02\\SQLEXPRESS; database = elcortecheco; integrated security = true");
                conexion.Open();
                string id = textBox12.Text;
                string marca = textBox11.Text;
                string precio = textBox9.Text.Replace(',', '.');
                string tipo = textBox10.Text;
                string cadena = "insert into discoduro ( id, marca, precio, tipo) values ( " + id + " , '" + marca + "' , '" + precio + "','" + tipo + "') ";
                SqlCommand comando = new SqlCommand(cadena, conexion);
                comando.ExecuteNonQuery();
                MessageBox.Show(" Los datos se guardaron correctamente ");
                textBox12.Text = "";
                textBox11.Text = "";
                textBox10.Text = "";
                textBox9.Text = "";
                if (pictureBox3.Image != null)
                {

                    SqlCommand comandoMeterImagen = new SqlCommand();

                    comandoMeterImagen.Connection = conexion;
                    comandoMeterImagen.CommandText = "Update discoduro Set Imagen=@Foto where id='" + id + "'";
                    comandoMeterImagen.Parameters.Add("@Foto", System.Data.SqlDbType.Image);

                    //Imagen
                    MemoryStream stream = new MemoryStream();
                    pictureBox3.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

                    comandoMeterImagen.Parameters["@Foto"].Value = stream.GetBuffer();
                    comandoMeterImagen.ExecuteNonQuery();
                    conexion.Close();
                }

                pictureBox3.Image = null;
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
                string precio = textBox4.Text.Replace(',', '.');
                string hz = textBox3.Text;
                string cadena = "UPDATE monitores set marca = '" + marca + "', precio= '" + precio + "', hz = '" + hz + "', imagen = null where  id = " + id;
                SqlCommand comando = new SqlCommand(cadena, conexion);
                comando.ExecuteNonQuery();
                MessageBox.Show(" Los datos se guardaron correctamente ");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";


      
                    if (pictureBox1.Image != null)
                {

                    SqlCommand comandoMeterImagen = new SqlCommand();

                    comandoMeterImagen.Connection = conexion;
                    comandoMeterImagen.CommandText = "Update monitores Set Imagen=@Foto where id='" + id + "'";
                    comandoMeterImagen.Parameters.Add("@Foto", System.Data.SqlDbType.Image);

                    //Imagen
                    MemoryStream stream = new MemoryStream();
                    pictureBox1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

                    comandoMeterImagen.Parameters["@Foto"].Value = stream.GetBuffer();
                    comandoMeterImagen.ExecuteNonQuery();
                    conexion.Close();
                }
                pictureBox1.Image = null;

                 conexion.Close();

            }
            else if (namepage == "tabPage2".ToString())
            {
                SqlConnection conexion = new SqlConnection("server=T4IPC02\\SQLEXPRESS; database = elcortecheco; integrated security = true");
                conexion.Open();
                string id = textBox8.Text;
                string marca = textBox7.Text;
                string precio = textBox5.Text.Replace(',', '.');
                string procesador = textBox6.Text;
                string cadena = "UPDATE ordenadores set marca = '" + marca + "', precio= '" + precio + "', procesador = '" + procesador + "', imagen = null  where  id = " + id;
                SqlCommand comando = new SqlCommand(cadena, conexion);
                comando.ExecuteNonQuery();
                MessageBox.Show(" Los datos se guardaron correctamente ");
                textBox8.Text = "";
                textBox7.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";


                if (pictureBox2.Image != null)
                {

                    SqlCommand comandoMeterImagen = new SqlCommand();

                    comandoMeterImagen.Connection = conexion;
                    comandoMeterImagen.CommandText = "Update ordenadores Set Imagen=@Foto where id='" + id + "'";
                    comandoMeterImagen.Parameters.Add("@Foto", System.Data.SqlDbType.Image);

                    //Imagen
                    MemoryStream stream = new MemoryStream();
                    pictureBox1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

                    comandoMeterImagen.Parameters["@Foto"].Value = stream.GetBuffer();
                    comandoMeterImagen.ExecuteNonQuery();
                    conexion.Close();

                }

                pictureBox2.Image = null;
                conexion.Close();

            }
            else if (namepage == "tabPage3".ToString())
            {
                SqlConnection conexion = new SqlConnection("server=T4IPC02\\SQLEXPRESS; database = elcortecheco; integrated security = true");
                conexion.Open();
                string id = textBox12.Text;
                string marca = textBox11.Text;
                string precio = textBox9.Text.Replace(',', '.');
                string tipo = textBox10.Text;
                string cadena = "UPDATE discoduro set marca = '" + marca + "', precio= '" + precio + "', tipo = '" + tipo + "' , imagen = null  where  id = " + id;
                SqlCommand comando = new SqlCommand(cadena, conexion);
                comando.ExecuteNonQuery();
                MessageBox.Show(" Los datos se guardaron correctamente ");
                textBox12.Text = "";
                textBox11.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";



                if (pictureBox3.Image != null)
                {

                    SqlCommand comandoMeterImagen = new SqlCommand();

                    comandoMeterImagen.Connection = conexion;
                    comandoMeterImagen.CommandText = "Update discoduro Set Imagen=@Foto where id='" + id + "'";
                    comandoMeterImagen.Parameters.Add("@Foto", System.Data.SqlDbType.Image);

                    //Imagen
                    MemoryStream stream = new MemoryStream();
                    pictureBox3.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

                    comandoMeterImagen.Parameters["@Foto"].Value = stream.GetBuffer();
                    comandoMeterImagen.ExecuteNonQuery();
                    conexion.Close();
                }
                pictureBox3.Image = null;
                conexion.Close();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string namepage = tabControl1.SelectedTab.Name;
            if (namepage == "tabPage1".ToString())
            {
                SqlConnection conexion = new SqlConnection("server=T4IPC02\\SQLEXPRESS; database = elcortecheco; integrated security = true");
                conexion.Open();
                string id = textBox1.Text;
                string marca = textBox2.Text;
                string precio = textBox3.Text;
                string hz = textBox4.Text;
                string cadena = "DELETE from monitores where id = " + id;
                SqlCommand comando = new SqlCommand(cadena, conexion);
                comando.ExecuteNonQuery();
                MessageBox.Show("El registro se ha borrado");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                pictureBox1.Image = null;
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
                string cadena = "DELETE from ordenadores where id = " + id;
                SqlCommand comando = new SqlCommand(cadena, conexion);
                comando.ExecuteNonQuery();
                MessageBox.Show("El registro se ha borrado");
                textBox8.Text = "";
                textBox7.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                pictureBox2.Image = null;
                conexion.Close();

            }
            else if (namepage == "tabPage3".ToString())
            {
                SqlConnection conexion = new SqlConnection("server=T4IPC02\\SQLEXPRESS; database = elcortecheco; integrated security = true");
                conexion.Open();
                string id = textBox12.Text;
                string marca = textBox11.Text;
                string precio = textBox9.Text;
                string tipo = textBox10.Text;
                string cadena = "DELETE from discoduro where id = " + id;
                SqlCommand comando = new SqlCommand(cadena, conexion);
                comando.ExecuteNonQuery();
                MessageBox.Show("El registro se ha borrado");
                textBox12.Text = "";
                textBox11.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                pictureBox3.Image = null;
                conexion.Close();

            }


        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            pictureBox1.Image = null;
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            textBox8.Text = "";
            textBox7.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            pictureBox2.Image = null;
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            textBox12.Text = "";
            textBox11.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            pictureBox3.Image = null;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form2 formulario = new Form2();
            formulario.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {

            Form4 formulario = new Form4();
            formulario.Show();

        }

        private void button14_Click(object sender, EventArgs e)
        {
            Form5 formulario = new Form5();
            formulario.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog()== DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(openFileDialog2.FileName);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = null;
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (openFileDialog3.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.Image = Image.FromFile(openFileDialog3
                    
                    
                    
                    .FileName);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}



