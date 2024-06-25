namespace _25_PUNTOS
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BTCerrar = new System.Windows.Forms.Button();
            this.BTConfig = new System.Windows.Forms.Button();
            this.LBPts = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.LBRestan = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.LBCobros = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BTSalir = new System.Windows.Forms.Button();
            this.BTGuardar = new System.Windows.Forms.Button();
            this.LBNombre = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.BTLogin = new System.Windows.Forms.Button();
            this.TBPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TBUsuario = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TBJustificacion = new System.Windows.Forms.TextBox();
            this.LBSala = new System.Windows.Forms.Label();
            this.LBMesa = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DGVMesas = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TBBitacora = new System.Windows.Forms.TextBox();
            this.LBBitacora = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.DGVBitacora = new System.Windows.Forms.DataGridView();
            this.timerAbiertas = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVMesas)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVBitacora)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(2, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(898, 524);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Click += new System.EventHandler(this.TabControl1_Click);
            this.tabControl1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TabControl1_KeyPress);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.BTCerrar);
            this.tabPage1.Controls.Add(this.BTConfig);
            this.tabPage1.Controls.Add(this.LBPts);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.LBRestan);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.LBCobros);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.BTSalir);
            this.tabPage1.Controls.Add(this.BTGuardar);
            this.tabPage1.Controls.Add(this.LBNombre);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.BTLogin);
            this.tabPage1.Controls.Add(this.TBPassword);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.TBUsuario);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.LBSala);
            this.tabPage1.Controls.Add(this.LBMesa);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.DGVMesas);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(890, 498);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "AUDITORIA MESAS";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(788, 68);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 41;
            this.label9.Text = "V3.0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(241, 24);
            this.label2.TabIndex = 40;
            this.label2.Text = "SELECCIONA LA MESA:";
            // 
            // BTCerrar
            // 
            this.BTCerrar.Location = new System.Drawing.Point(638, 34);
            this.BTCerrar.Name = "BTCerrar";
            this.BTCerrar.Size = new System.Drawing.Size(101, 23);
            this.BTCerrar.TabIndex = 39;
            this.BTCerrar.Text = "CERRAR";
            this.BTCerrar.UseVisualStyleBackColor = true;
            this.BTCerrar.Visible = false;
            this.BTCerrar.Click += new System.EventHandler(this.Salir_Click);
            // 
            // BTConfig
            // 
            this.BTConfig.Location = new System.Drawing.Point(638, 6);
            this.BTConfig.Name = "BTConfig";
            this.BTConfig.Size = new System.Drawing.Size(101, 23);
            this.BTConfig.TabIndex = 38;
            this.BTConfig.Text = "CONFIGURAR";
            this.BTConfig.UseVisualStyleBackColor = true;
            this.BTConfig.Visible = false;
            this.BTConfig.Click += new System.EventHandler(this.BTConfig_Click);
            // 
            // LBPts
            // 
            this.LBPts.AutoSize = true;
            this.LBPts.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBPts.Location = new System.Drawing.Point(110, 468);
            this.LBPts.Name = "LBPts";
            this.LBPts.Size = new System.Drawing.Size(54, 24);
            this.LBPts.TabIndex = 37;
            this.LBPts.Text = "0000";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(14, 468);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 24);
            this.label12.TabIndex = 36;
            this.label12.Text = "PUNTOS:";
            // 
            // LBRestan
            // 
            this.LBRestan.AutoSize = true;
            this.LBRestan.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBRestan.ForeColor = System.Drawing.Color.Red;
            this.LBRestan.Location = new System.Drawing.Point(110, 441);
            this.LBRestan.Name = "LBRestan";
            this.LBRestan.Size = new System.Drawing.Size(54, 24);
            this.LBRestan.TabIndex = 35;
            this.LBRestan.Text = "0000";
            this.LBRestan.Click += new System.EventHandler(this.Label9_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(16, 441);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 24);
            this.label10.TabIndex = 34;
            this.label10.Text = "RESTAN:";
            // 
            // LBCobros
            // 
            this.LBCobros.AutoSize = true;
            this.LBCobros.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBCobros.Location = new System.Drawing.Point(110, 411);
            this.LBCobros.Name = "LBCobros";
            this.LBCobros.Size = new System.Drawing.Size(54, 24);
            this.LBCobros.TabIndex = 33;
            this.LBCobros.Text = "0000";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 411);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 24);
            this.label8.TabIndex = 32;
            this.label8.Text = "COBROS:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::_25_PUNTOS.Properties.Resources.REBEL;
            this.pictureBox1.Location = new System.Drawing.Point(760, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // BTSalir
            // 
            this.BTSalir.Enabled = false;
            this.BTSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.BTSalir.Location = new System.Drawing.Point(608, 445);
            this.BTSalir.Name = "BTSalir";
            this.BTSalir.Size = new System.Drawing.Size(261, 32);
            this.BTSalir.TabIndex = 30;
            this.BTSalir.Text = "SALIR";
            this.BTSalir.UseVisualStyleBackColor = true;
            this.BTSalir.Click += new System.EventHandler(this.BTSalir_Click);
            // 
            // BTGuardar
            // 
            this.BTGuardar.Enabled = false;
            this.BTGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.BTGuardar.Location = new System.Drawing.Point(608, 407);
            this.BTGuardar.Name = "BTGuardar";
            this.BTGuardar.Size = new System.Drawing.Size(261, 32);
            this.BTGuardar.TabIndex = 29;
            this.BTGuardar.Text = "GUARDAR";
            this.BTGuardar.UseVisualStyleBackColor = true;
            this.BTGuardar.Click += new System.EventHandler(this.BTGuardar_Click);
            // 
            // LBNombre
            // 
            this.LBNombre.AutoSize = true;
            this.LBNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBNombre.ForeColor = System.Drawing.SystemColors.Desktop;
            this.LBNombre.Location = new System.Drawing.Point(604, 380);
            this.LBNombre.Name = "LBNombre";
            this.LBNombre.Size = new System.Drawing.Size(99, 24);
            this.LBNombre.TabIndex = 28;
            this.LBNombre.Text = "NOMBRE";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(604, 356);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 24);
            this.label7.TabIndex = 27;
            this.label7.Text = "USUARIO:";
            // 
            // BTLogin
            // 
            this.BTLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.BTLogin.Location = new System.Drawing.Point(588, 15);
            this.BTLogin.Name = "BTLogin";
            this.BTLogin.Size = new System.Drawing.Size(34, 29);
            this.BTLogin.TabIndex = 26;
            this.BTLogin.Text = ">";
            this.BTLogin.UseVisualStyleBackColor = true;
            this.BTLogin.Click += new System.EventHandler(this.BTLogin_Click);
            // 
            // TBPassword
            // 
            this.TBPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.TBPassword.Location = new System.Drawing.Point(435, 15);
            this.TBPassword.Name = "TBPassword";
            this.TBPassword.PasswordChar = '*';
            this.TBPassword.Size = new System.Drawing.Size(144, 29);
            this.TBPassword.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(279, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 24);
            this.label6.TabIndex = 24;
            this.label6.Text = "CONTRASEÑA:";
            // 
            // TBUsuario
            // 
            this.TBUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.TBUsuario.Location = new System.Drawing.Point(124, 15);
            this.TBUsuario.Name = "TBUsuario";
            this.TBUsuario.PasswordChar = '*';
            this.TBUsuario.Size = new System.Drawing.Size(146, 29);
            this.TBUsuario.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 24);
            this.label5.TabIndex = 22;
            this.label5.Text = "USUARIO:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TBJustificacion);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(181, 356);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(417, 133);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "JUSTIFICACION";
            // 
            // TBJustificacion
            // 
            this.TBJustificacion.Enabled = false;
            this.TBJustificacion.Location = new System.Drawing.Point(6, 28);
            this.TBJustificacion.Multiline = true;
            this.TBJustificacion.Name = "TBJustificacion";
            this.TBJustificacion.Size = new System.Drawing.Size(405, 89);
            this.TBJustificacion.TabIndex = 0;
            // 
            // LBSala
            // 
            this.LBSala.AutoSize = true;
            this.LBSala.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBSala.Location = new System.Drawing.Point(110, 356);
            this.LBSala.Name = "LBSala";
            this.LBSala.Size = new System.Drawing.Size(54, 24);
            this.LBSala.TabIndex = 20;
            this.LBSala.Text = "0000";
            // 
            // LBMesa
            // 
            this.LBMesa.AutoSize = true;
            this.LBMesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBMesa.Location = new System.Drawing.Point(110, 383);
            this.LBMesa.Name = "LBMesa";
            this.LBMesa.Size = new System.Drawing.Size(54, 24);
            this.LBMesa.TabIndex = 19;
            this.LBMesa.Text = "0000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(47, 356);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 24);
            this.label3.TabIndex = 18;
            this.label3.Text = "SALA:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 383);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 24);
            this.label1.TabIndex = 17;
            this.label1.Text = "MESA:";
            // 
            // DGVMesas
            // 
            this.DGVMesas.AllowUserToAddRows = false;
            this.DGVMesas.AllowUserToDeleteRows = false;
            this.DGVMesas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVMesas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGVMesas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVMesas.Enabled = false;
            this.DGVMesas.Location = new System.Drawing.Point(12, 95);
            this.DGVMesas.Name = "DGVMesas";
            this.DGVMesas.ReadOnly = true;
            this.DGVMesas.RowHeadersVisible = false;
            this.DGVMesas.RowHeadersWidth = 51;
            this.DGVMesas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVMesas.Size = new System.Drawing.Size(865, 243);
            this.DGVMesas.TabIndex = 16;
            this.DGVMesas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVMesas_CellClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pictureBox2);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.LBBitacora);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.dateTimePicker1);
            this.tabPage2.Controls.Add(this.DGVBitacora);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(890, 498);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "BITACORA";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::_25_PUNTOS.Properties.Resources.REBEL;
            this.pictureBox2.Location = new System.Drawing.Point(36, 376);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(174, 97);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 32;
            this.pictureBox2.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TBBitacora);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.Red;
            this.groupBox2.Location = new System.Drawing.Point(262, 356);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(417, 133);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "JUSTIFICACION";
            // 
            // TBBitacora
            // 
            this.TBBitacora.Enabled = false;
            this.TBBitacora.Location = new System.Drawing.Point(6, 28);
            this.TBBitacora.Multiline = true;
            this.TBBitacora.Name = "TBBitacora";
            this.TBBitacora.ReadOnly = true;
            this.TBBitacora.Size = new System.Drawing.Size(405, 89);
            this.TBBitacora.TabIndex = 0;
            // 
            // LBBitacora
            // 
            this.LBBitacora.AutoSize = true;
            this.LBBitacora.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBBitacora.ForeColor = System.Drawing.Color.Red;
            this.LBBitacora.Location = new System.Drawing.Point(784, 16);
            this.LBBitacora.Name = "LBBitacora";
            this.LBBitacora.Size = new System.Drawing.Size(54, 24);
            this.LBBitacora.TabIndex = 21;
            this.LBBitacora.Text = "0000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(517, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(274, 24);
            this.label4.TabIndex = 20;
            this.label4.Text = "NUMERO DE INCIDENCIAS:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(117, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "FILTRAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(6, 17);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(96, 20);
            this.dateTimePicker1.TabIndex = 18;
            // 
            // DGVBitacora
            // 
            this.DGVBitacora.AllowUserToAddRows = false;
            this.DGVBitacora.AllowUserToDeleteRows = false;
            this.DGVBitacora.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVBitacora.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGVBitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVBitacora.Location = new System.Drawing.Point(6, 53);
            this.DGVBitacora.Name = "DGVBitacora";
            this.DGVBitacora.ReadOnly = true;
            this.DGVBitacora.RowHeadersVisible = false;
            this.DGVBitacora.RowHeadersWidth = 51;
            this.DGVBitacora.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVBitacora.Size = new System.Drawing.Size(865, 294);
            this.DGVBitacora.TabIndex = 17;
            this.DGVBitacora.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVBitacora_CellClick);
            // 
            // timerAbiertas
            // 
            this.timerAbiertas.Enabled = true;
            this.timerAbiertas.Interval = 15000;
            this.timerAbiertas.Tick += new System.EventHandler(this.TimerAbiertas_Tick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.TimerCursor_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(901, 563);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(901, 563);
            this.MinimumSize = new System.Drawing.Size(901, 563);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "25 PUNTOS";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVMesas)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVBitacora)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button BTSalir;
        private System.Windows.Forms.Button BTGuardar;
        private System.Windows.Forms.Label LBNombre;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BTLogin;
        private System.Windows.Forms.TextBox TBPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TBUsuario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TBJustificacion;
        private System.Windows.Forms.Label LBSala;
        private System.Windows.Forms.Label LBMesa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DGVMesas;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label LBBitacora;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView DGVBitacora;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TBBitacora;
        private System.Windows.Forms.Timer timerAbiertas;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label LBPts;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label LBRestan;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label LBCobros;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button BTConfig;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button BTCerrar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
    }
}

