using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DesktopControl;
using System.Configuration;
using System.Diagnostics;

namespace _25_PUNTOS
{
    public partial class Form1 : Form
    {

        SqlConnection conexion;
        Conexion dirCon = new Conexion();
        NotifyIcon NotifyIcon1 = new NotifyIcon();
        ContextMenu ContextMenu1 = new ContextMenu();
        public int apl=1, MAbiertas = 1;

        KunLibertad_DesktopControl Desk = new KunLibertad_DesktopControl();

        public string Inicio = ConfigurationManager.AppSettings.Get("Inicio");
        public string Fin = ConfigurationManager.AppSettings.Get("Fin");

        private Timer timer;

        public Form1()
        {
            if (getPrevInstance())
            {
                this.Close();
                Application.Exit();
                Application.ExitThread();
            }

            InitializeComponent();
            
            //OCULTAR DE BARRA DE TAREAS ICONO
            this.ShowInTaskbar = false;

            if (ConfigurationManager.AppSettings["status"] == "True")
            {
                conexion = dirCon.crearConexion();
                AsignaIntervalo();
                // Configura el Timer
                timer = new Timer();
                timer.Interval = 60000; // Establece el intervalo en milisegundos (cada minuto)
                timer.Tick += Timer_Tick;

                // Inicia el Timer
                timer.Start();
            }
        }

        private static bool getPrevInstance()
        {
            //get the name of current process, i,e the process 
            //name of this current application

            string currPrsName = Process.GetCurrentProcess().ProcessName;

            //Get the name of all processes having the 
            //same name as this process name 
            Process[] allProcessWithThisName
                         = Process.GetProcessesByName(currPrsName);

            //if more than one process is running return true.
            //which means already previous instance of the application 
            //is running
            if (allProcessWithThisName.Length > 1)
            {
                MessageBox.Show("YA SE ESTA EJECUTANDO");

                return true; // Yes Previous Instance Exist
            }
            else
            {
                return false; //No Prev Instance Running
            }
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            // Verifica si es 11 AM
            if (DateTime.Now.Hour == 11 && DateTime.Now.Minute == 0)
            {
                // Ejecuta tu método
                InsertTest();
            }
        }
        private void InsertTest()
        {
            conexion.Open();

            SqlCommand command = new SqlCommand("INSERT INTO TAYC25 (FECHAINI, SALA, MESA, TOTAL_AYC, COBROS, COBROS_MINIMOS, DIFERENCIA, JUSTIFICACION, USUARIO) VALUES (@Fecha, @Sala, @Mesa, @TotalAYC, @Cobros, @CobrosMin, @Diferencia, @Justificacion, @Usu)", conexion);

            command.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = DateTime.Now;
            command.Parameters.Add("@Sala", SqlDbType.SmallInt).Value = 0;
            command.Parameters.Add("@Mesa", SqlDbType.SmallInt).Value = 0;
            command.Parameters.Add("@TotalAYC", SqlDbType.Int).Value = 0;
            command.Parameters.Add("@Cobros", SqlDbType.Int).Value = 0;
            command.Parameters.Add("@CobrosMin", SqlDbType.Int).Value = 0;
            command.Parameters.Add("@Diferencia", SqlDbType.Int).Value = 0;
            command.Parameters.Add("@Justificacion", SqlDbType.NVarChar).Value = "prueba";
            command.Parameters.Add("@Usu", SqlDbType.NVarChar).Value = "prueba";


            try
            {

                command.ExecuteNonQuery();
                //MessageBox.Show("Guardado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                conexion.Close();



            }
            catch
            {
                conexion.Close();
                //MessageBox.Show("Guardado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void AsignaIntervalo() {
            int Segundos = int.Parse(ConfigurationManager.AppSettings.Get("Fin"));
            timerAbiertas.Interval = Segundos * 1000;
        }

        private void CerrarSesion() {

            DGVMesas.Enabled = false;
            TBUsuario.Enabled = true;
            TBPassword.Enabled = true;
            BTLogin.Enabled = true;
            TBJustificacion.Enabled = false;
            LBMesa.Text = "0000";
            LBSala.Text = "0000";
            LBNombre.Text = "NOMBRE";
            BTConfig.Visible = false;
            BTCerrar.Visible = false;
        }
        Boolean estadoN = false;
        Boolean estadoM = false;
        public void BuscarMesas(object sender, EventArgs e) {
            string Consulta = "DECLARE @PTSXCOBRO INT = 25 SELECT C.FECHAINI,C.SALA, C.MESA ,SUM(L.UNIDADES * ISNULL(ACC.VALOR_AYC, 0)) AS TOTAL_AYC, SUM(L.UNIDADES * CASE WHEN A.DESCRIPCION LIKE '%($)%' AND(A.DESCATALOGADO = 'F' OR DESCATALOGADO IS NULL) THEN 1  ELSE 0 END) AS TOTAL_COBROS, CEILING(SUM(L.UNIDADES * ISNULL(ACC.VALOR_AYC, 0)) / @PTSXCOBRO) AS COBROS_MINIMOS,(SUM(L.UNIDADES * CASE WHEN A.DESCRIPCION LIKE '%($)%' AND(A.DESCATALOGADO = 'F' OR DESCATALOGADO IS NULL) THEN 1  ELSE 0 END) - CEILING(SUM(L.UNIDADES * ISNULL(ACC.VALOR_AYC, 0)) / @PTSXCOBRO)) AS DIFERENCIA_COBROS FROM MINUTASCAB  C WITH(NOLOCK) INNER JOIN MINUTASLIN L WITH(NOLOCK) ON L.SALA = C.SALA AND L.MESA = C.MESA INNER JOIN ARTICULOS A WITH(NOLOCK) ON A.CODARTICULO = L.CODARTICULO INNER JOIN ARTICULOSCAMPOSLIBRES ACC WITH(NOLOCK) ON ACC.CODARTICULO = A.CODARTICULO WHERE (CONSUBTOTAL = 'F') AND (C.FECHAINI NOT IN (SELECT FECHAINI FROM TAYC25)) GROUP BY C.SALA, C.MESA, C.FECHAINI HAVING ((SUM(L.UNIDADES * CASE WHEN A.DESCRIPCION LIKE '%($)%' AND (A.DESCATALOGADO='F' OR DESCATALOGADO IS NULL) THEN 1  ELSE 0 END)-CEILING(SUM(L.UNIDADES * ISNULL(ACC.VALOR_AYC,0))/@PTSXCOBRO))) < 0 ORDER BY C.SALA, C.MESA, C.FECHAINI";

            try
            {

                conexion.Open();
                SqlDataAdapter datos = new SqlDataAdapter("" + Consulta, conexion);
                DataSet data = new DataSet();

                datos.Fill(data);

                if (data.Tables[0].Rows.Count > 0) {
                    MAbiertas = 2;
                    DGVMesas.DataSource = data.Tables[0];
                    conexion.Close();
                    Restaurar_Click(sender, e);
                    estadoM = false;
                    BTSalir.Enabled = false;
                    if (estadoN == false)
                    {
                        Show();
                        this.WindowState = FormWindowState.Normal;
                    }
                    



                }
                else {
                    MAbiertas = 1;
                    DGVMesas.DataSource = data.Tables[0];
                    conexion.Close();
                    
                    estadoN = false;
                    BTSalir.Enabled = true;

                    //Minimiza cuando esta en 0 las mesas abiertas
                    if (estadoM == false)
                    {
                        if (this.WindowState == FormWindowState.Minimized)
                            this.Visible = false;
                    }

                    
                }

            }
            catch
            {
                conexion.Close();
                MessageBox.Show("ERROR BUSCAR MESAS", "ERROR");
            }

        }

        private void BTLogin_Click(object sender, EventArgs e)
        {
            if (TBUsuario.Text == "SISTEMAS" && TBPassword.Text == "172106") {

                BTConfig.Visible = true; BTCerrar.Visible = true;
                Limpiar();

            }
            else {
                if (ConfigurationManager.AppSettings["status"] == "True")
                {
                    Verifica();
                }
                else { MessageBox.Show("CONFIGURA SERVIDOR", "CONEXION"); }
            }
        }

        private void Verifica()
        {

            conexion.Open();

            SqlDataAdapter consulta = new SqlDataAdapter();
            DataSet datos = new DataSet();
            consulta.SelectCommand = new SqlCommand("select	* from TUsuarios where Nombre = '" + TBUsuario.Text + "' and Contraseña = '" + TBPassword.Text + "'", conexion);
            consulta.Fill(datos);


            try
            {

                string acesso, status, Usuario;
                acesso = datos.Tables[0].Rows[0][3].ToString();
                status = datos.Tables[0].Rows[0][4].ToString();
                Usuario = datos.Tables[0].Rows[0][1].ToString();//recupero el nombre de mi tabla usuario
                // codigo para asignar foto en variable...

                //Foto = datos.Tables[0].Rows[0][4].ToString();

                conexion.Close();
                if (status == "1")
                {
                    if (acesso == "2")
                    {

                        LBNombre.Text = ""+TBUsuario.Text;
                        
                        Limpiar();
                        Muestra(acesso);
                    }
                    else
                    {
                        if (acesso == "1")
                        {
                            LBNombre.Text = "" + TBUsuario.Text;
                            
                            Limpiar();
                            Muestra(acesso);
                        }


                    }
                }
                

            }
            catch
            {
                conexion.Close();
                MessageBox.Show("Verifica el Usuario o la Contraseña", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                Limpiar();
            }
        }

        private void Muestra(string accs) {
            DGVMesas.Enabled = true;
            TBUsuario.Enabled = false;
            TBPassword.Enabled = false;
            BTLogin.Enabled = false;
            TBJustificacion.Enabled = true;
            
            if (accs == "2") { BTConfig.Visible = true; BTCerrar.Visible = true; }

        }
        private void Limpiar(){
            TBUsuario.Clear();
            TBPassword.Clear();
            
        }

        public string Fecha, Sala, Mesa, TotalAYC, TotalCB, TotalMIN, Diferencia;

        private void Button1_Click(object sender, EventArgs e)
        {
            MuestraBitacora(dateTimePicker1.Value);
            
        }

        private void DGVBitacora_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TBBitacora.Text = DataGridViewSeleccion.GetValorCelda(DGVBitacora, 7);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //' Asignar los submenús del ContextMenu
            //'
            //' Añadimos la opción Restaurar, que será el elemento predeterminado
            MenuItem tMenu = new MenuItem("&ABRIR", new EventHandler(this.Restaurar_Click));
            tMenu.DefaultItem = true;
            ContextMenu1.MenuItems.Add(tMenu);
            //
            //' Esto también se puede hacer así:
            //ContextMenu1.MenuItems.Add("&Restaurar", new EventHandler(this.Restaurar_Click));
            //ContextMenu1.MenuItems[0].DefaultItem = true;
            ////'
            ////' Añadimos un separador
            //ContextMenu1.MenuItems.Add("-");
            ////' Añadimos el elemento Acerca de...
            //ContextMenu1.MenuItems.Add("&Acerca de...", new EventHandler(this.AcercaDe_Click));
            ////' Añadimos otro separador
            //ContextMenu1.MenuItems.Add("-");
            ////' Añadimos la opción de salir
            //ContextMenu1.MenuItems.Add("&Salir", new EventHandler(this.Salir_Click));
            //'
            //' Asignar los valores para el NotifyIcon
            NotifyIcon1.Icon = this.Icon;
            NotifyIcon1.ContextMenu = this.ContextMenu1;
            NotifyIcon1.Text = Application.ProductName;
            NotifyIcon1.Visible = true;
            NotifyIcon1.BalloonTipTitle = "25 puntos";
            //NotifyIcon1.BalloonTipText = "Configura IP Servidor";
            //
            // Asignamos los otros eventos al formulario
            this.Resize += new EventHandler(this.Form1_Resize);
            this.Activated += new EventHandler(this.Form1_Activated);
            this.Closing += new CancelEventHandler(this.Form1_Closing);

            // Asignamos el evento DoubleClick del NotifyIcon
            // this.NotifyIcon1.DoubleClick += new EventHandler(this.Restaurar_Click);

            if (ConfigurationManager.AppSettings["status"] == "True")
            {

                Valida prueba = new Valida();
                if (prueba.VerifyConnection())
                {
                    //MessageBox.Show("CONEXION EXITOSA", "CONEXION");
                    TimerAbiertas_Tick(sender,e);
                    BuscarMesas(sender, e);
                }
                else
                {
                    MessageBox.Show("CONEXION FALLIDA", "CONEXION");
                    timerAbiertas.Stop();
                }
            }
            else {
                MessageBox.Show("CONFIGURA SERVIDOR", "CONEXION");
                timerAbiertas.Stop();
            }
            tamaño = this.PointToScreen(new Point());
        }

        private void Salir_Click(object sender, System.EventArgs e)
        {
            //' Este procedimiento se usa para cerrar el formulario,
            //' se usará como procedimiento de eventos, en principio usado por el botón Salir
            this.Close();
            Application.Exit();
            Application.ExitThread();
            // Cuando se va a cerrar el formulario...
            // eliminar el objeto de la barra de tareas
            this.NotifyIcon1.Visible = false;
            // esto es necesario, para que no se quede el icono en la barra de tareas
            // (el cual se quita al pasar el ratón por encima)
            this.NotifyIcon1 = null;
            // de paso eliminamos el menú contextual
            this.ContextMenu1 = null;
        }

        public void ResetApp() {
            this.Close();
            Application.Exit();
            Application.ExitThread();
            // Cuando se va a cerrar el formulario...
            // eliminar el objeto de la barra de tareas
            this.NotifyIcon1.Visible = false;
            // esto es necesario, para que no se quede el icono en la barra de tareas
            // (el cual se quita al pasar el ratón por encima)
            this.NotifyIcon1 = null;
            // de paso eliminamos el menú contextual
            this.ContextMenu1 = null;
            Application.Restart();

        }

        
        private void Restaurar_Click(object sender, System.EventArgs e)
        {
            //' Restaurar por si se minimizó
            //' Este evento manejará tanto los menús Restaurar como el NotifyIcon.DoubleClick
            Show();
            WindowState = FormWindowState.Normal;
            Activate();
            apl = 0;
            Desk.SpecialKeyButtons(false);
            Captura();
            

        }
        
        private void Captura() {

            if (apl == 0 ) {
                //BLOQUE Y PONE LIMITES DEL CURSOR
                Cursor.Clip = this.Bounds;

            }
        }

        private void AcercaDe_Click(object sender, System.EventArgs e)
        {
            //' Mostrar la información del autor, versión, etc.
            MessageBox.Show(Application.ProductName + " v" + Application.ProductVersion, "Prueba 2 de NotifyIcon en C#");
        }
        private void Form1_Resize(object sender, System.EventArgs e)
        {
            //' Cuando se minimice, ocultarla, se quedará disponible en la barra de tareas
            if (this.WindowState == FormWindowState.Minimized)
                this.Visible = false;

        }

        // la declaramos fuera de la función, para que mantenga su valor
        Boolean PrimeraVez = true;
        //
        private void Form1_Activated(object sender, System.EventArgs e)
        {
            // En C# no se puede usar static para hacer que una variable mantenga su valor
            // en C/C++ sí que se puede
            //static Boolean PrimeraVez = true;
            //
            //' La primera vez que se active, ocultar el form,
            //' es una chapuza, pero el formulario no permite que se oculte en el Form_Load
            //if (PrimeraVez)
            //{
            //    PrimeraVez = false;
            //    Visible = false;
            //}
        }

        private void Form1_Closing(object sender, CancelEventArgs e)
        {
            if (ModifierKeys == Keys.Alt || ModifierKeys == Keys.F4)
            {
                e.Cancel = true;
                
            }
            else
            {
                
            }
            
        }

        private void TimerAbiertas_Tick(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["status"] == "True") {
                if (int.Parse(DateTime.Now.Hour.ToString()) >= int.Parse(Inicio) && int.Parse(DateTime.Now.Hour.ToString()) <= int.Parse(Fin))
                {
                    BuscarMesas(sender, e);
                }
                else {
                    ActualizaJustificacionAutomatico();
                }
            }
        }

        private void BTSalir_Click(object sender, EventArgs e)
        {
            apl = 1;
            Visible = false;
            this.WindowState = FormWindowState.Minimized;
            Desk.SpecialKeyButtons(true);
            CerrarSesion();

            //LIBERA LIMITES DE PANTALLA CURSOR
            Cursor.Clip = Rectangle.Empty;
        }

        private void Label9_Click(object sender, EventArgs e)
        {

        }

        private void MuestraBitacora(DateTime FechaFiltro) {
            string Consulta = "SELECT  TOP (200) FECHAINI, SALA, MESA, TOTAL_AYC, COBROS, COBROS_MINIMOS, DIFERENCIA, JUSTIFICACION, USUARIO FROM TAYC25 WHERE (CONVERT(VARCHAR(10),FECHAINI,111) = '"+FechaFiltro.ToString("yyyy/MM/dd") + "')";

            try
            {

                conexion.Open();
                SqlDataAdapter datos = new SqlDataAdapter("" + Consulta, conexion);
                DataSet data = new DataSet();

                datos.Fill(data);

                if (data.Tables[0].Rows.Count > 0)
                {
                    DGVBitacora.DataSource = data.Tables[0];
                    conexion.Close();
                    LBBitacora.Text = ""+data.Tables[0].Rows.Count;
                }
                else
                {
                    DGVBitacora.DataSource = data.Tables[0];
                    conexion.Close();
                    LBBitacora.Text = "0000";
                }

            }
            catch(SqlException ex)
            {
                conexion.Close();
                MessageBox.Show("SE PERDIO CONEXION M"+ex, "CONEXION");
            }
        }

        private void TabControl1_Click(object sender, EventArgs e)
        {
            string Consulta = "SELECT * FROM TAYC25 ORDER BY FECHAINI DESC";

            try
            {

                conexion.Open();
                SqlDataAdapter datos = new SqlDataAdapter("" + Consulta, conexion);
                DataSet data = new DataSet();

                datos.Fill(data);

                if (data.Tables[0].Rows.Count > 0)
                {
                    DGVBitacora.DataSource = data.Tables[0];
                    conexion.Close();
                    LBBitacora.Text = "" + data.Tables[0].Rows.Count;
                }
                else
                {
                    DGVBitacora.DataSource = data.Tables[0];
                    conexion.Close();
                    LBBitacora.Text = "0000";
                }

            }
            catch
            {
                conexion.Close();
                MessageBox.Show("SE PERDIO CONEXION TAB", "CONEXION");
            }
            
        }

        private void DGVMesas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Fecha = DataGridViewSeleccion.GetValorCelda(DGVMesas, 0);
            Sala = DataGridViewSeleccion.GetValorCelda(DGVMesas, 1);
            Mesa = DataGridViewSeleccion.GetValorCelda(DGVMesas, 2);
            TotalAYC = DataGridViewSeleccion.GetValorCelda(DGVMesas, 3);
            TotalCB = DataGridViewSeleccion.GetValorCelda(DGVMesas, 4);
            TotalMIN = DataGridViewSeleccion.GetValorCelda(DGVMesas, 5);
            Diferencia = DataGridViewSeleccion.GetValorCelda(DGVMesas, 6);

            LBMesa.Text = DataGridViewSeleccion.GetValorCelda(DGVMesas, 2);
            LBSala.Text = DataGridViewSeleccion.GetValorCelda(DGVMesas, 1);
            LBCobros.Text = DataGridViewSeleccion.GetValorCelda(DGVMesas, 4);
            LBRestan.Text = DataGridViewSeleccion.GetValorCelda(DGVMesas, 6);
            LBPts.Text = DataGridViewSeleccion.GetValorCelda(DGVMesas, 3);
            BTGuardar.Enabled = true;
            
        }
        public Point tamaño = new Point();
        

        private void TabControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            
        }

        private void BTConfig_Click(object sender, EventArgs e)
        {
            ConexServ frm = new ConexServ();
            frm.Show(this);
            
            BTSalir_Click(sender, e);
            this.Hide();
            
        }

        private void TimerCursor_Tick(object sender, EventArgs e)
        {
            


            if (apl == 0)
            {

                if (Cursor.Position.X > tamaño.X-1 && Cursor.Position.X < tamaño.X + 901 && Cursor.Position.Y > tamaño.Y-1 && Cursor.Position.Y < tamaño.Y + 563)
                {

                    
                }
                else
                {

                    Captura();

                }
               
            }
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            //if (apl == 0) {
            //    Point tamaño = this.PointToScreen(new Point());
            //    int tamañox = 1129;
            //    int tamañoy = 108;

            //    Class2.ejecuta(tamañox,tamañoy);
            //}
            
            
        }

        private void BTGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TBJustificacion.Text)) {
                MessageBox.Show("Debes agregar una Justificacion", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else {
                ActualizaJustificacion();
                TBJustificacion.Clear();
                BuscarMesas(sender, e);
                LimpiarLabel();
                BTGuardar.Enabled = false;
            }
            
        }
        private void LimpiarLabel() {
            LBMesa.Text = "0000";
            LBSala.Text = "0000";
            LBCobros.Text = "0000";
            LBRestan.Text = "0000";
            LBPts.Text = "0000";
        }

        private void ActualizaJustificacion() {

            
            conexion.Open();
            
            SqlCommand command = new SqlCommand("INSERT INTO TAYC25 (FECHAINI, SALA, MESA, TOTAL_AYC, COBROS, COBROS_MINIMOS, DIFERENCIA, JUSTIFICACION, USUARIO) VALUES (@Fecha, @Sala, @Mesa, @TotalAYC, @Cobros, @CobrosMin, @Diferencia, @Justificacion, @Usu)", conexion);
            
            command.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = DateTime.Parse(Fecha);
            command.Parameters.Add("@Sala", SqlDbType.SmallInt).Value = int.Parse(Sala);
            command.Parameters.Add("@Mesa", SqlDbType.SmallInt).Value = int.Parse(Mesa);
            command.Parameters.Add("@TotalAYC", SqlDbType.Int).Value = int.Parse(TotalAYC);
            command.Parameters.Add("@Cobros", SqlDbType.Int).Value = int.Parse(TotalCB);
            command.Parameters.Add("@CobrosMin", SqlDbType.Int).Value = int.Parse(TotalMIN);
            command.Parameters.Add("@Diferencia", SqlDbType.Int).Value =int.Parse(Diferencia);
            command.Parameters.Add("@Justificacion", SqlDbType.NVarChar).Value = TBJustificacion.Text;
            command.Parameters.Add("@Usu", SqlDbType.NVarChar).Value = LBNombre.Text;




            try
            {

                command.ExecuteNonQuery();
                //MessageBox.Show("Guardado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                conexion.Close();



            }
            catch
            {
                conexion.Close();
                //MessageBox.Show("Guardado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void ActualizaJustificacionAutomatico()
        {
            string Consulta = "DECLARE @PTSXCOBRO INT = 25 SELECT C.FECHAINI,C.SALA, C.MESA ,SUM(L.UNIDADES * ISNULL(ACC.VALOR_AYC, 0)) AS TOTAL_AYC, SUM(L.UNIDADES * CASE WHEN A.DESCRIPCION LIKE '%($)%' AND(A.DESCATALOGADO = 'F' OR DESCATALOGADO IS NULL) THEN 1  ELSE 0 END) AS TOTAL_COBROS, CEILING(SUM(L.UNIDADES * ISNULL(ACC.VALOR_AYC, 0)) / @PTSXCOBRO) AS COBROS_MINIMOS,(SUM(L.UNIDADES * CASE WHEN A.DESCRIPCION LIKE '%($)%' AND(A.DESCATALOGADO = 'F' OR DESCATALOGADO IS NULL) THEN 1  ELSE 0 END) - CEILING(SUM(L.UNIDADES * ISNULL(ACC.VALOR_AYC, 0)) / @PTSXCOBRO)) AS DIFERENCIA_COBROS FROM MINUTASCAB  C WITH(NOLOCK) INNER JOIN MINUTASLIN L WITH(NOLOCK) ON L.SALA = C.SALA AND L.MESA = C.MESA INNER JOIN ARTICULOS A WITH(NOLOCK) ON A.CODARTICULO = L.CODARTICULO INNER JOIN ARTICULOSCAMPOSLIBRES ACC WITH(NOLOCK) ON ACC.CODARTICULO = A.CODARTICULO WHERE (CONSUBTOTAL = 'F') AND (C.FECHAINI NOT IN (SELECT FECHAINI FROM TAYC25)) GROUP BY C.SALA, C.MESA, C.FECHAINI HAVING ((SUM(L.UNIDADES * CASE WHEN A.DESCRIPCION LIKE '%($)%' AND (A.DESCATALOGADO='F' OR DESCATALOGADO IS NULL) THEN 1  ELSE 0 END)-CEILING(SUM(L.UNIDADES * ISNULL(ACC.VALOR_AYC,0))/@PTSXCOBRO))) < 0 ORDER BY C.SALA, C.MESA, C.FECHAINI";

            conexion.Open();
                SqlDataAdapter datos = new SqlDataAdapter("" + Consulta, conexion);
                DataSet data = new DataSet();

                datos.Fill(data);
            conexion.Close();
            if (data.Tables[0].Rows.Count > 0)
            {
                conexion.Open();
                SqlCommand command = new SqlCommand("DECLARE @PTSXCOBRO INT = 25, @JUS nvarchar(max) = 'INCIDENCIA FUERA DE HORARIO DEL SUPERVISOR', @USU NVARCHAR(50)= 'CAJERO' INSERT INTO TAYC25 (FECHAINI, SALA, MESA, TOTAL_AYC, COBROS, COBROS_MINIMOS, DIFERENCIA, JUSTIFICACION, USUARIO) SELECT C.FECHAINI,C.SALA, C.MESA ,SUM(L.UNIDADES * ISNULL(ACC.VALOR_AYC, 0)) AS TOTAL_AYC, SUM(L.UNIDADES * CASE WHEN A.DESCRIPCION LIKE '%($)%' AND(A.DESCATALOGADO = 'F' OR DESCATALOGADO IS NULL) THEN 1  ELSE 0 END) AS TOTAL_COBROS, CEILING(SUM(L.UNIDADES * ISNULL(ACC.VALOR_AYC, 0)) / @PTSXCOBRO) AS COBROS_MINIMOS,(SUM(L.UNIDADES * CASE WHEN A.DESCRIPCION LIKE '%($)%' AND(A.DESCATALOGADO = 'F' OR DESCATALOGADO IS NULL) THEN 1  ELSE 0 END) - CEILING(SUM(L.UNIDADES * ISNULL(ACC.VALOR_AYC, 0)) / @PTSXCOBRO)) AS DIFERENCIA_COBROS,@JUS,@USU FROM MINUTASCAB  C WITH(NOLOCK) INNER JOIN MINUTASLIN L WITH(NOLOCK) ON L.SALA = C.SALA AND L.MESA = C.MESA INNER JOIN ARTICULOS A WITH(NOLOCK) ON A.CODARTICULO = L.CODARTICULO INNER JOIN ARTICULOSCAMPOSLIBRES ACC WITH(NOLOCK) ON ACC.CODARTICULO = A.CODARTICULO WHERE (CONSUBTOTAL = 'F') AND (C.FECHAINI NOT IN (SELECT FECHAINI FROM TAYC25)) GROUP BY C.SALA, C.MESA, C.FECHAINI HAVING ((SUM(L.UNIDADES * CASE WHEN A.DESCRIPCION LIKE '%($)%' AND (A.DESCATALOGADO='F' OR DESCATALOGADO IS NULL) THEN 1  ELSE 0 END)-CEILING(SUM(L.UNIDADES * ISNULL(ACC.VALOR_AYC,0))/@PTSXCOBRO))) < 0 ORDER BY C.SALA, C.MESA, C.FECHAINI", conexion);

                try
                {

                    command.ExecuteNonQuery();
                    //MessageBox.Show("Guardado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    conexion.Close();



                }
                catch
                {
                    conexion.Close();
                    //MessageBox.Show("Guardado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        public class DataGridViewSeleccion
        {

            public static string GetValorCelda(DataGridView dgv, int num)
            {

                string valor = "";
                try
                {
                    valor = dgv.Rows[dgv.CurrentRow.Index].Cells[num].Value.ToString();
                    return valor;
                }
                catch { return valor; }

            }

        }



        private void DGVMesas_Click(object sender, EventArgs e)
        {
            
        }

        protected override void WndProc(ref Message message)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MOVE = 0xF010;

            switch (message.Msg)
            {
                case WM_SYSCOMMAND:
                    int command = message.WParam.ToInt32() & 0xfff0;
                    if (command == SC_MOVE)
                        return;
                    break;
            }

            base.WndProc(ref message);
        }
    }
}
