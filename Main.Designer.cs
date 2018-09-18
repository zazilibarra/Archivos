namespace Archivos
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.gridEntidad = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dir_Entidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dir_Atributo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dir_Datos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dir_Sig_Entidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAtributos = new System.Windows.Forms.DataGridView();
            this.Nombre_Attr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dir_Atr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo_dato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Longitud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo_indice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dir_indice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dir_Sig_Atr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cabeceraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtCabecera = new System.Windows.Forms.ToolStripTextBox();
            this.txtEntidad = new System.Windows.Forms.TextBox();
            this.btnCrearEntidad = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridEntidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAtributos)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridEntidad
            // 
            this.gridEntidad.AllowUserToAddRows = false;
            this.gridEntidad.AllowUserToDeleteRows = false;
            this.gridEntidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEntidad.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Dir_Entidad,
            this.Dir_Atributo,
            this.Dir_Datos,
            this.Dir_Sig_Entidad});
            this.gridEntidad.Location = new System.Drawing.Point(12, 127);
            this.gridEntidad.Name = "gridEntidad";
            this.gridEntidad.ReadOnly = true;
            this.gridEntidad.RowTemplate.Height = 24;
            this.gridEntidad.Size = new System.Drawing.Size(543, 527);
            this.gridEntidad.TabIndex = 0;
            this.gridEntidad.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridEntidad_CellClick);
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Dir_Entidad
            // 
            this.Dir_Entidad.HeaderText = "Dir. Entidad";
            this.Dir_Entidad.Name = "Dir_Entidad";
            this.Dir_Entidad.ReadOnly = true;
            // 
            // Dir_Atributo
            // 
            this.Dir_Atributo.HeaderText = "Dir. Atributo";
            this.Dir_Atributo.Name = "Dir_Atributo";
            this.Dir_Atributo.ReadOnly = true;
            // 
            // Dir_Datos
            // 
            this.Dir_Datos.HeaderText = "Dir. Datos";
            this.Dir_Datos.Name = "Dir_Datos";
            this.Dir_Datos.ReadOnly = true;
            // 
            // Dir_Sig_Entidad
            // 
            this.Dir_Sig_Entidad.HeaderText = "Dir. Sig. Entidad";
            this.Dir_Sig_Entidad.Name = "Dir_Sig_Entidad";
            this.Dir_Sig_Entidad.ReadOnly = true;
            // 
            // gridAtributos
            // 
            this.gridAtributos.AllowUserToAddRows = false;
            this.gridAtributos.AllowUserToDeleteRows = false;
            this.gridAtributos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAtributos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre_Attr,
            this.Dir_Atr,
            this.Tipo_dato,
            this.Longitud,
            this.Tipo_indice,
            this.Dir_indice,
            this.Dir_Sig_Atr});
            this.gridAtributos.Location = new System.Drawing.Point(561, 127);
            this.gridAtributos.Name = "gridAtributos";
            this.gridAtributos.ReadOnly = true;
            this.gridAtributos.RowTemplate.Height = 24;
            this.gridAtributos.Size = new System.Drawing.Size(743, 527);
            this.gridAtributos.TabIndex = 1;
            // 
            // Nombre_Attr
            // 
            this.Nombre_Attr.HeaderText = "Nombre";
            this.Nombre_Attr.Name = "Nombre_Attr";
            this.Nombre_Attr.ReadOnly = true;
            // 
            // Dir_Atr
            // 
            this.Dir_Atr.HeaderText = "Dir. Atributo";
            this.Dir_Atr.Name = "Dir_Atr";
            this.Dir_Atr.ReadOnly = true;
            // 
            // Tipo_dato
            // 
            this.Tipo_dato.HeaderText = "Tipo Dato";
            this.Tipo_dato.Name = "Tipo_dato";
            this.Tipo_dato.ReadOnly = true;
            // 
            // Longitud
            // 
            this.Longitud.HeaderText = "Longitud";
            this.Longitud.Name = "Longitud";
            this.Longitud.ReadOnly = true;
            // 
            // Tipo_indice
            // 
            this.Tipo_indice.HeaderText = "Tipo Indice";
            this.Tipo_indice.Name = "Tipo_indice";
            this.Tipo_indice.ReadOnly = true;
            // 
            // Dir_indice
            // 
            this.Dir_indice.HeaderText = "Dir. Indice";
            this.Dir_indice.Name = "Dir_indice";
            this.Dir_indice.ReadOnly = true;
            // 
            // Dir_Sig_Atr
            // 
            this.Dir_Sig_Atr.HeaderText = "Dir. Sig. Atr.";
            this.Dir_Sig_Atr.Name = "Dir_Sig_Atr";
            this.Dir_Sig_Atr.ReadOnly = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.verToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1311, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.salirToolStripMenuItem.Text = "Salir";
            // 
            // verToolStripMenuItem
            // 
            this.verToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cabeceraToolStripMenuItem});
            this.verToolStripMenuItem.Name = "verToolStripMenuItem";
            this.verToolStripMenuItem.Size = new System.Drawing.Size(42, 24);
            this.verToolStripMenuItem.Text = "Ver";
            // 
            // cabeceraToolStripMenuItem
            // 
            this.cabeceraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtCabecera});
            this.cabeceraToolStripMenuItem.Name = "cabeceraToolStripMenuItem";
            this.cabeceraToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.cabeceraToolStripMenuItem.Text = "Cabecera";
            // 
            // txtCabecera
            // 
            this.txtCabecera.Name = "txtCabecera";
            this.txtCabecera.ReadOnly = true;
            this.txtCabecera.Size = new System.Drawing.Size(100, 27);
            // 
            // txtEntidad
            // 
            this.txtEntidad.Location = new System.Drawing.Point(6, 21);
            this.txtEntidad.Name = "txtEntidad";
            this.txtEntidad.Size = new System.Drawing.Size(288, 22);
            this.txtEntidad.TabIndex = 3;
            // 
            // btnCrearEntidad
            // 
            this.btnCrearEntidad.Location = new System.Drawing.Point(300, 21);
            this.btnCrearEntidad.Name = "btnCrearEntidad";
            this.btnCrearEntidad.Size = new System.Drawing.Size(75, 23);
            this.btnCrearEntidad.TabIndex = 4;
            this.btnCrearEntidad.Text = "Crear";
            this.btnCrearEntidad.UseVisualStyleBackColor = true;
            this.btnCrearEntidad.Click += new System.EventHandler(this.btnCrearEntidad_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(381, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Modificar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.txtEntidad);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.btnCrearEntidad);
            this.groupBox1.Location = new System.Drawing.Point(12, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(543, 62);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Entidad";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(462, 21);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 6;
            this.button5.Text = "Eliminar";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Location = new System.Drawing.Point(561, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(505, 62);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Atributo";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(417, 21);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 7;
            this.button6.Text = "Eliminar";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(336, 21);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Modificar";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(255, 21);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Crear";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1311, 666);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gridAtributos);
            this.Controls.Add(this.gridEntidad);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Archivos";
            ((System.ComponentModel.ISupportInitialize)(this.gridEntidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAtributos)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridEntidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dir_Entidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dir_Atributo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dir_Datos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dir_Sig_Entidad;
        private System.Windows.Forms.DataGridView gridAtributos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre_Attr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dir_Atr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo_dato;
        private System.Windows.Forms.DataGridViewTextBoxColumn Longitud;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo_indice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dir_indice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dir_Sig_Atr;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.TextBox txtEntidad;
        private System.Windows.Forms.Button btnCrearEntidad;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ToolStripMenuItem verToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cabeceraToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox txtCabecera;
    }
}

