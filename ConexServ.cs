using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml;
using System.Reflection;

namespace _25_PUNTOS
{
    public partial class ConexServ : Form
    {
        SqlConnection con;
        Conexion dirCon = new Conexion();
        public string Conexion, Minutos, MaxMin, Segundos;
        public int statusCon = 0;
        public ConexServ()
        {
            InitializeComponent();

            if (ConfigurationManager.AppSettings["status"] == "True")
            {
                carga();
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (statusCon == 1)
            {
                Xmlsave();
                creaTabla();
            }
            else {

                if (statusCon == 2) {

                    Xmlsave();
                }
            }

            Form1 frm = new Form1();
            frm.ResetApp();
            this.Hide();

        }

        private void creaTabla() {

            dirCon = new Conexion();
            //con = dirCon.crearConexion();
            //SqlDataAdapter query = new SqlDataAdapter();
            //query. = new SqlCommand("USE ["+textBase.Text+"] GO SET ANSI_NULLS ON GO SET QUOTED_IDENTIFIER ON GO CREATE TABLE [dbo].[TAYC25]([FECHAINI] [dbo].[DDATE] NULL,[SALA] [dbo].[DSMALLINT] NOT NULL,[MESA] [dbo].[DSMALLINT] NOT NULL,[TOTAL_AYC] [int] NULL,[COBROS] [int] NULL,[COBROS_MINIMOS] [int] NULL,[DIFERENCIA] [int] NOT NULL,[JUSTIFICACION] [nvarchar](max) NOT NULL,[USUARIO] [nvarchar](50) NULL) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY] GO", con);
            try
            {
                using (var conexion = dirCon.crearConexion())
                {
                    conexion.Open();
                    using (var comando = new SqlCommand())
                    {
                        comando.Connection = conexion;
                        comando.CommandText = "CREATE TABLE [TAYC25]([FECHAINI] [dbo].[DDATE] NULL,[SALA] [dbo].[DSMALLINT] NOT NULL,[MESA] [dbo].[DSMALLINT] NOT NULL,[TOTAL_AYC] [int] NULL,[COBROS] [int] NULL,[COBROS_MINIMOS] [int] NULL,[DIFERENCIA] [int] NOT NULL,[JUSTIFICACION] [nvarchar](max) NOT NULL,[USUARIO] [nvarchar](50) NULL, [ENVIADO] [varchar](20) NULL,[VENDEDOR] [varchar](500) NULL) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]";
                        comando.CommandType = CommandType.Text;
                        comando.ExecuteNonQuery();
                    }
                }

            MessageBox.Show("Se Creo Tabla ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch {
                using (var conexion = dirCon.crearConexion())
                {
                    conexion.Open();
                    using (var comando = new SqlCommand())
                    {
                        comando.Connection = conexion;
                        comando.CommandText = "IF NOT EXISTS ( SELECT 1  FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'TAYC25' AND COLUMN_NAME = 'VENDEDOR') BEGIN ALTER TABLE TAYC25 ADD VENDEDOR NVARCHAR(500); END";
                        comando.CommandType = CommandType.Text;
                        comando.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Ya existe la Tabla ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void carga() {

            var builder = new SqlConnectionStringBuilder(ConfigurationManager.AppSettings["conexion"]);
            textServidor.Text = builder.DataSource;
            textBase.Text = builder.InitialCatalog;
            textUsuario.Text = builder.UserID;
            textContraseña.Text = builder.Password;
            textMinHot.Text = ConfigurationManager.AppSettings["Inicio"];
            textMaxMin.Text = ConfigurationManager.AppSettings["Fin"];
            textBoxSegundos.Text = ConfigurationManager.AppSettings["Tiempo"];
            statusCon = 2;
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {

            Conexion = "Data Source=" + textServidor.Text + ";Initial Catalog=" + textBase.Text + ";User Id=" + textUsuario.Text + ";Password=" + textContraseña.Text + "";
            Minutos = textMinHot.Text; MaxMin = textMaxMin.Text; Segundos = textBoxSegundos.Text;
            ConfigurationManager.AppSettings["conexion"] = Conexion;

            if (textMaxMin.Text != "" && textMinHot.Text != "")
            {
                try
                {

                    dirCon = new Conexion();
                    con = dirCon.crearConexion();
                    SqlDataAdapter query = new SqlDataAdapter();
                    SqlDataAdapter consulta = new SqlDataAdapter();
                    DataSet datos = new DataSet();
                    consulta.SelectCommand = new SqlCommand("select	* from TUsuarios ", con);
                    consulta.Fill(datos);
                    string Usuario = datos.Tables[0].Rows[0][1].ToString();
                    MessageBox.Show("Conexion Exitosa ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ConfigurationManager.AppSettings["status"] = "True";
                    textBase.Enabled = false;
                    textServidor.Enabled = false;
                    textUsuario.Enabled = false;
                    textContraseña.Enabled = false;
                    button2.Enabled = false;
                    textMaxMin.Enabled = false;
                    textMinHot.Enabled = false;
                    textBoxSegundos.Enabled = false;
                    if (statusCon == 0) {
                        statusCon = 1;
                    }

                }
                catch
                {
                    MessageBox.Show("Conexion no Exitosa ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    statusCon = 0;
                }
            }
            else { MessageBox.Show("Llena todos los Campos ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }
        private void Xmlsave()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string path = assembly.Location;

            Configuration config = ConfigurationManager.OpenExeConfiguration(path);
            
            config.Save(ConfigurationSaveMode.Modified);


            //


            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            foreach (XmlElement element in XmlDoc.DocumentElement)
            {
                if (element.Name.Equals("appSettings"))
                {

                    foreach (XmlNode node in element.ChildNodes)
                    {

                        if (node.Attributes[0].Value == "status")
                        {
                            node.Attributes[1].Value = "True";
                        }
                        if (node.Attributes[0].Value == "conexion")
                        {
                            node.Attributes[1].Value = Conexion;
                        }
                        if (node.Attributes[0].Value == "Inicio")
                        {
                            node.Attributes[1].Value = Minutos;
                        }
                        if (node.Attributes[0].Value == "Fin")
                        {
                            node.Attributes[1].Value = MaxMin;
                        }
                        if (node.Attributes[0].Value == "Tiempo")
                        {
                            node.Attributes[1].Value = Segundos;
                        }

                    }

                }






            }
            XmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            ConfigurationManager.RefreshSection("appSettings");
            ConfigurationManager.RefreshSection("connectionStrings");

        }
    }
}
