namespace Archivos
{
    partial class Nuevo_Atributo
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
            this.txtAtributo = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboTipoIindice = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLong = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboEntidades = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtAtributo
            // 
            this.txtAtributo.Enabled = false;
            this.txtAtributo.Location = new System.Drawing.Point(76, 48);
            this.txtAtributo.Name = "txtAtributo";
            this.txtAtributo.Size = new System.Drawing.Size(248, 22);
            this.txtAtributo.TabIndex = 0;
            this.txtAtributo.TextChanged += new System.EventHandler(this.txtAtributo_TextChanged);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(124, 179);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Crear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tipo";
            // 
            // cboTipo
            // 
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.Enabled = false;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Items.AddRange(new object[] {
            "E",
            "C"});
            this.cboTipo.Location = new System.Drawing.Point(76, 86);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(68, 24);
            this.cboTipo.TabIndex = 4;
            this.cboTipo.SelectedIndexChanged += new System.EventHandler(this.cboTipo_SelectedIndexChanged);
            this.cboTipo.SelectedValueChanged += new System.EventHandler(this.cboTipo_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tipo de Indice";
            // 
            // cboTipoIindice
            // 
            this.cboTipoIindice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoIindice.Enabled = false;
            this.cboTipoIindice.FormattingEnabled = true;
            this.cboTipoIindice.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.cboTipoIindice.Location = new System.Drawing.Point(115, 129);
            this.cboTipoIindice.Name = "cboTipoIindice";
            this.cboTipoIindice.Size = new System.Drawing.Size(73, 24);
            this.cboTipoIindice.TabIndex = 6;
            this.cboTipoIindice.SelectedValueChanged += new System.EventHandler(this.cboTipoIindice_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(173, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Longitud";
            // 
            // txtLong
            // 
            this.txtLong.Enabled = false;
            this.txtLong.Location = new System.Drawing.Point(248, 86);
            this.txtLong.Name = "txtLong";
            this.txtLong.Size = new System.Drawing.Size(76, 22);
            this.txtLong.TabIndex = 8;
            this.txtLong.TextChanged += new System.EventHandler(this.txtLong_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Entidad";
            // 
            // cboEntidades
            // 
            this.cboEntidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEntidades.FormattingEnabled = true;
            this.cboEntidades.Location = new System.Drawing.Point(76, 17);
            this.cboEntidades.Name = "cboEntidades";
            this.cboEntidades.Size = new System.Drawing.Size(248, 24);
            this.cboEntidades.TabIndex = 10;
            this.cboEntidades.SelectedValueChanged += new System.EventHandler(this.cboEntidades_SelectedValueChanged);
            // 
            // Nuevo_Atributo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 214);
            this.Controls.Add(this.cboEntidades);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtLong);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboTipoIindice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboTipo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtAtributo);
            this.Name = "Nuevo_Atributo";
            this.Text = "Nuevo Atributo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAtributo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboTipoIindice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLong;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboEntidades;
    }
}