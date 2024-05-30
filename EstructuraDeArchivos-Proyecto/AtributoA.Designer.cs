namespace Proyecto_Estructura_de_Archivos
{
    partial class AtributoA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AtributoA));
            this.nombreAtributo = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listBoxEntidades = new System.Windows.Forms.ListBox();
            this.tipoDeAtributoLabel = new System.Windows.Forms.Label();
            this.radioBotonEntero = new System.Windows.Forms.RadioButton();
            this.radioBotonCadena = new System.Windows.Forms.RadioButton();
            this.tamaño = new System.Windows.Forms.Label();
            this.numericTamaño = new System.Windows.Forms.NumericUpDown();
            this.labelEntidad = new System.Windows.Forms.Label();
            this.TipoDeIndice = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButton0 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.botonAceptar = new System.Windows.Forms.Button();
            this.botonCancelar = new System.Windows.Forms.Button();
            this.claveForaneaGroup = new System.Windows.Forms.GroupBox();
            this.listBoxEntidadesForaneas = new System.Windows.Forms.ListBox();
            this.listBoxAtributosForaneos = new System.Windows.Forms.ListBox();
            this.Nuevo = new System.Windows.Forms.GroupBox();
            this.radioBotonDecimal = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.numericTamaño)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.claveForaneaGroup.SuspendLayout();
            this.Nuevo.SuspendLayout();
            this.SuspendLayout();
            // 
            // nombreAtributo
            // 
            this.nombreAtributo.AutoSize = true;
            this.nombreAtributo.BackColor = System.Drawing.Color.Transparent;
            this.nombreAtributo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreAtributo.ForeColor = System.Drawing.Color.White;
            this.nombreAtributo.Location = new System.Drawing.Point(13, 13);
            this.nombreAtributo.Name = "nombreAtributo";
            this.nombreAtributo.Size = new System.Drawing.Size(195, 24);
            this.nombreAtributo.TabIndex = 0;
            this.nombreAtributo.Text = "Nombre del atributo";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(214, 17);
            this.textBox1.MaxLength = 30;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(257, 20);
            this.textBox1.TabIndex = 1;
            // 
            // listBoxEntidades
            // 
            this.listBoxEntidades.FormattingEnabled = true;
            this.listBoxEntidades.Location = new System.Drawing.Point(12, 66);
            this.listBoxEntidades.Name = "listBoxEntidades";
            this.listBoxEntidades.ScrollAlwaysVisible = true;
            this.listBoxEntidades.Size = new System.Drawing.Size(194, 121);
            this.listBoxEntidades.TabIndex = 3;
            this.listBoxEntidades.SelectedIndexChanged += new System.EventHandler(this.ListBoxEntidades_SelectedIndexChanged);
            // 
            // tipoDeAtributoLabel
            // 
            this.tipoDeAtributoLabel.AutoSize = true;
            this.tipoDeAtributoLabel.BackColor = System.Drawing.Color.Transparent;
            this.tipoDeAtributoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipoDeAtributoLabel.ForeColor = System.Drawing.Color.White;
            this.tipoDeAtributoLabel.Location = new System.Drawing.Point(489, 13);
            this.tipoDeAtributoLabel.Name = "tipoDeAtributoLabel";
            this.tipoDeAtributoLabel.Size = new System.Drawing.Size(157, 24);
            this.tipoDeAtributoLabel.TabIndex = 4;
            this.tipoDeAtributoLabel.Text = "Tipo de atributo";
            // 
            // radioBotonEntero
            // 
            this.radioBotonEntero.AutoSize = true;
            this.radioBotonEntero.BackColor = System.Drawing.Color.Transparent;
            this.radioBotonEntero.Checked = true;
            this.radioBotonEntero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBotonEntero.ForeColor = System.Drawing.Color.White;
            this.radioBotonEntero.Location = new System.Drawing.Point(675, 17);
            this.radioBotonEntero.Name = "radioBotonEntero";
            this.radioBotonEntero.Size = new System.Drawing.Size(71, 20);
            this.radioBotonEntero.TabIndex = 5;
            this.radioBotonEntero.TabStop = true;
            this.radioBotonEntero.Text = "Entero";
            this.radioBotonEntero.UseVisualStyleBackColor = false;
            this.radioBotonEntero.CheckedChanged += new System.EventHandler(this.RadioBotonEntero_CheckedChanged);
            // 
            // radioBotonCadena
            // 
            this.radioBotonCadena.AutoSize = true;
            this.radioBotonCadena.BackColor = System.Drawing.Color.Transparent;
            this.radioBotonCadena.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBotonCadena.ForeColor = System.Drawing.Color.White;
            this.radioBotonCadena.Location = new System.Drawing.Point(748, 18);
            this.radioBotonCadena.Name = "radioBotonCadena";
            this.radioBotonCadena.Size = new System.Drawing.Size(80, 20);
            this.radioBotonCadena.TabIndex = 6;
            this.radioBotonCadena.Text = "Cadena";
            this.radioBotonCadena.UseVisualStyleBackColor = false;
            // 
            // tamaño
            // 
            this.tamaño.AutoSize = true;
            this.tamaño.BackColor = System.Drawing.Color.Transparent;
            this.tamaño.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tamaño.ForeColor = System.Drawing.Color.White;
            this.tamaño.Location = new System.Drawing.Point(924, 1);
            this.tamaño.Name = "tamaño";
            this.tamaño.Size = new System.Drawing.Size(65, 16);
            this.tamaño.TabIndex = 7;
            this.tamaño.Text = "Tamaño";
            // 
            // numericTamaño
            // 
            this.numericTamaño.Enabled = false;
            this.numericTamaño.Location = new System.Drawing.Point(924, 20);
            this.numericTamaño.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericTamaño.Name = "numericTamaño";
            this.numericTamaño.Size = new System.Drawing.Size(74, 20);
            this.numericTamaño.TabIndex = 8;
            this.numericTamaño.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // labelEntidad
            // 
            this.labelEntidad.AutoSize = true;
            this.labelEntidad.BackColor = System.Drawing.Color.Transparent;
            this.labelEntidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEntidad.ForeColor = System.Drawing.Color.White;
            this.labelEntidad.Location = new System.Drawing.Point(14, 47);
            this.labelEntidad.Name = "labelEntidad";
            this.labelEntidad.Size = new System.Drawing.Size(49, 16);
            this.labelEntidad.TabIndex = 9;
            this.labelEntidad.Text = "Tabla";
            // 
            // TipoDeIndice
            // 
            this.TipoDeIndice.AutoSize = true;
            this.TipoDeIndice.BackColor = System.Drawing.Color.Transparent;
            this.TipoDeIndice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TipoDeIndice.ForeColor = System.Drawing.Color.White;
            this.TipoDeIndice.Location = new System.Drawing.Point(489, 39);
            this.TipoDeIndice.Name = "TipoDeIndice";
            this.TipoDeIndice.Size = new System.Drawing.Size(145, 24);
            this.TipoDeIndice.TabIndex = 10;
            this.TipoDeIndice.Text = "Tipo de indice";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.radioButton0);
            this.flowLayoutPanel1.Controls.Add(this.radioButton1);
            this.flowLayoutPanel1.Controls.Add(this.radioButton2);
            this.flowLayoutPanel1.Controls.Add(this.radioButton3);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(656, 47);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(361, 59);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // radioButton0
            // 
            this.radioButton0.AutoSize = true;
            this.radioButton0.Checked = true;
            this.radioButton0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton0.ForeColor = System.Drawing.Color.White;
            this.radioButton0.Location = new System.Drawing.Point(3, 3);
            this.radioButton0.Name = "radioButton0";
            this.radioButton0.Size = new System.Drawing.Size(90, 20);
            this.radioButton0.TabIndex = 0;
            this.radioButton0.TabStop = true;
            this.radioButton0.Text = "Sin clave";
            this.radioButton0.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.ForeColor = System.Drawing.Color.White;
            this.radioButton1.Location = new System.Drawing.Point(99, 3);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(161, 20);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.Text = "Clave de busqueda";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Visible = false;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.ForeColor = System.Drawing.Color.White;
            this.radioButton2.Location = new System.Drawing.Point(3, 29);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(127, 20);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.Text = "Clave primaria";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton3.ForeColor = System.Drawing.Color.White;
            this.radioButton3.Location = new System.Drawing.Point(136, 29);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(123, 20);
            this.radioButton3.TabIndex = 3;
            this.radioButton3.Text = "Clave foranea";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.RadioButton3_CheckedChanged);
            // 
            // botonAceptar
            // 
            this.botonAceptar.Location = new System.Drawing.Point(671, 123);
            this.botonAceptar.Name = "botonAceptar";
            this.botonAceptar.Size = new System.Drawing.Size(75, 23);
            this.botonAceptar.TabIndex = 12;
            this.botonAceptar.Text = "Aceptar";
            this.botonAceptar.UseVisualStyleBackColor = true;
            this.botonAceptar.Click += new System.EventHandler(this.BotonAceptar_Click);
            // 
            // botonCancelar
            // 
            this.botonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.botonCancelar.Location = new System.Drawing.Point(887, 123);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(75, 23);
            this.botonCancelar.TabIndex = 13;
            this.botonCancelar.Text = "Cancelar";
            this.botonCancelar.UseVisualStyleBackColor = true;
            this.botonCancelar.Click += new System.EventHandler(this.BotonCancelar_Click);
            // 
            // claveForaneaGroup
            // 
            this.claveForaneaGroup.BackColor = System.Drawing.Color.Transparent;
            this.claveForaneaGroup.Controls.Add(this.listBoxEntidadesForaneas);
            this.claveForaneaGroup.Enabled = false;
            this.claveForaneaGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.claveForaneaGroup.ForeColor = System.Drawing.Color.White;
            this.claveForaneaGroup.Location = new System.Drawing.Point(224, 76);
            this.claveForaneaGroup.Name = "claveForaneaGroup";
            this.claveForaneaGroup.Size = new System.Drawing.Size(209, 111);
            this.claveForaneaGroup.TabIndex = 14;
            this.claveForaneaGroup.TabStop = false;
            this.claveForaneaGroup.Text = "Clave foranea";
            // 
            // listBoxEntidadesForaneas
            // 
            this.listBoxEntidadesForaneas.BackColor = System.Drawing.SystemColors.Control;
            this.listBoxEntidadesForaneas.FormattingEnabled = true;
            this.listBoxEntidadesForaneas.Location = new System.Drawing.Point(10, 19);
            this.listBoxEntidadesForaneas.Name = "listBoxEntidadesForaneas";
            this.listBoxEntidadesForaneas.Size = new System.Drawing.Size(187, 69);
            this.listBoxEntidadesForaneas.TabIndex = 0;
            this.listBoxEntidadesForaneas.SelectedIndexChanged += new System.EventHandler(this.ListBoxEntidadesForaneas_SelectedIndexChanged);
            // 
            // listBoxAtributosForaneos
            // 
            this.listBoxAtributosForaneos.BackColor = System.Drawing.SystemColors.Control;
            this.listBoxAtributosForaneos.FormattingEnabled = true;
            this.listBoxAtributosForaneos.Location = new System.Drawing.Point(6, 19);
            this.listBoxAtributosForaneos.Name = "listBoxAtributosForaneos";
            this.listBoxAtributosForaneos.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxAtributosForaneos.Size = new System.Drawing.Size(187, 69);
            this.listBoxAtributosForaneos.TabIndex = 2;
            // 
            // Nuevo
            // 
            this.Nuevo.BackColor = System.Drawing.Color.Transparent;
            this.Nuevo.Controls.Add(this.listBoxAtributosForaneos);
            this.Nuevo.Enabled = false;
            this.Nuevo.ForeColor = System.Drawing.Color.White;
            this.Nuevo.Location = new System.Drawing.Point(446, 76);
            this.Nuevo.Name = "Nuevo";
            this.Nuevo.Size = new System.Drawing.Size(200, 111);
            this.Nuevo.TabIndex = 15;
            this.Nuevo.TabStop = false;
            this.Nuevo.Text = "Atributo Foraneo";
            // 
            // radioBotonDecimal
            // 
            this.radioBotonDecimal.AutoSize = true;
            this.radioBotonDecimal.BackColor = System.Drawing.Color.Transparent;
            this.radioBotonDecimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBotonDecimal.ForeColor = System.Drawing.Color.White;
            this.radioBotonDecimal.Location = new System.Drawing.Point(835, 19);
            this.radioBotonDecimal.Name = "radioBotonDecimal";
            this.radioBotonDecimal.Size = new System.Drawing.Size(83, 20);
            this.radioBotonDecimal.TabIndex = 16;
            this.radioBotonDecimal.Text = "Decimal";
            this.radioBotonDecimal.UseVisualStyleBackColor = false;
            this.radioBotonDecimal.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // AtributoA
            // 
            this.AcceptButton = this.botonAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.CancelButton = this.botonCancelar;
            this.ClientSize = new System.Drawing.Size(1038, 197);
            this.Controls.Add(this.radioBotonDecimal);
            this.Controls.Add(this.Nuevo);
            this.Controls.Add(this.claveForaneaGroup);
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.botonAceptar);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.TipoDeIndice);
            this.Controls.Add(this.labelEntidad);
            this.Controls.Add(this.numericTamaño);
            this.Controls.Add(this.tamaño);
            this.Controls.Add(this.radioBotonCadena);
            this.Controls.Add(this.radioBotonEntero);
            this.Controls.Add(this.tipoDeAtributoLabel);
            this.Controls.Add(this.listBoxEntidades);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.nombreAtributo);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AtributoA";
            this.ShowInTaskbar = false;
            this.Text = "Atributo";
            ((System.ComponentModel.ISupportInitialize)(this.numericTamaño)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.claveForaneaGroup.ResumeLayout(false);
            this.Nuevo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nombreAtributo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox listBoxEntidades;
        private System.Windows.Forms.Label tipoDeAtributoLabel;
        private System.Windows.Forms.RadioButton radioBotonEntero;
        private System.Windows.Forms.RadioButton radioBotonCadena;
        private System.Windows.Forms.Label tamaño;
        private System.Windows.Forms.NumericUpDown numericTamaño;
        private System.Windows.Forms.Label labelEntidad;
        private System.Windows.Forms.Label TipoDeIndice;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton radioButton0;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Button botonAceptar;
        private System.Windows.Forms.Button botonCancelar;
        private System.Windows.Forms.GroupBox claveForaneaGroup;
        private System.Windows.Forms.ListBox listBoxAtributosForaneos;
        private System.Windows.Forms.ListBox listBoxEntidadesForaneas;
        private System.Windows.Forms.GroupBox Nuevo;
        private System.Windows.Forms.RadioButton radioBotonDecimal;
    }
}