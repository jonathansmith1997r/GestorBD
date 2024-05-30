namespace Proyecto_Estructura_de_Archivos
{
    partial class AtributoM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AtributoM));
            this.listBoxEntidad = new System.Windows.Forms.ListBox();
            this.listBoxAtributo = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxAtributo = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.radioButtonCadena = new System.Windows.Forms.RadioButton();
            this.radioButtonEntero = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBoxEntidadForanea = new System.Windows.Forms.GroupBox();
            this.listBoxEntidadForanea = new System.Windows.Forms.ListBox();
            this.buttonModificar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButton0 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButtonDecimal = new System.Windows.Forms.RadioButton();
            this.groupBoxAtributo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBoxEntidadForanea.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxEntidad
            // 
            this.listBoxEntidad.FormattingEnabled = true;
            this.listBoxEntidad.Location = new System.Drawing.Point(12, 25);
            this.listBoxEntidad.Name = "listBoxEntidad";
            this.listBoxEntidad.Size = new System.Drawing.Size(120, 121);
            this.listBoxEntidad.TabIndex = 0;
            this.listBoxEntidad.SelectedIndexChanged += new System.EventHandler(this.ListBoxEntidad_SelectedIndexChanged);
            // 
            // listBoxAtributo
            // 
            this.listBoxAtributo.FormattingEnabled = true;
            this.listBoxAtributo.Location = new System.Drawing.Point(138, 25);
            this.listBoxAtributo.Name = "listBoxAtributo";
            this.listBoxAtributo.Size = new System.Drawing.Size(120, 121);
            this.listBoxAtributo.TabIndex = 1;
            this.listBoxAtributo.SelectedIndexChanged += new System.EventHandler(this.ListBoxAtributo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tablas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(138, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Atributo";
            // 
            // groupBoxAtributo
            // 
            this.groupBoxAtributo.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxAtributo.Controls.Add(this.radioButtonDecimal);
            this.groupBoxAtributo.Controls.Add(this.label4);
            this.groupBoxAtributo.Controls.Add(this.numericUpDown1);
            this.groupBoxAtributo.Controls.Add(this.radioButtonCadena);
            this.groupBoxAtributo.Controls.Add(this.radioButtonEntero);
            this.groupBoxAtributo.Controls.Add(this.textBox1);
            this.groupBoxAtributo.Controls.Add(this.label3);
            this.groupBoxAtributo.Enabled = false;
            this.groupBoxAtributo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxAtributo.ForeColor = System.Drawing.Color.White;
            this.groupBoxAtributo.Location = new System.Drawing.Point(264, 9);
            this.groupBoxAtributo.Name = "groupBoxAtributo";
            this.groupBoxAtributo.Size = new System.Drawing.Size(337, 98);
            this.groupBoxAtributo.TabIndex = 4;
            this.groupBoxAtributo.TabStop = false;
            this.groupBoxAtributo.Text = "Atributo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Tamaño";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Enabled = false;
            this.numericUpDown1.Location = new System.Drawing.Point(65, 64);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(62, 20);
            this.numericUpDown1.TabIndex = 4;
            this.numericUpDown1.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // radioButtonCadena
            // 
            this.radioButtonCadena.AutoSize = true;
            this.radioButtonCadena.Location = new System.Drawing.Point(242, 34);
            this.radioButtonCadena.Name = "radioButtonCadena";
            this.radioButtonCadena.Size = new System.Drawing.Size(68, 17);
            this.radioButtonCadena.TabIndex = 3;
            this.radioButtonCadena.Text = "Cadena";
            this.radioButtonCadena.UseVisualStyleBackColor = true;
            this.radioButtonCadena.CheckedChanged += new System.EventHandler(this.RadioButtonCadena_CheckedChanged);
            // 
            // radioButtonEntero
            // 
            this.radioButtonEntero.AutoSize = true;
            this.radioButtonEntero.Checked = true;
            this.radioButtonEntero.Location = new System.Drawing.Point(174, 34);
            this.radioButtonEntero.Name = "radioButtonEntero";
            this.radioButtonEntero.Size = new System.Drawing.Size(62, 17);
            this.radioButtonEntero.TabIndex = 2;
            this.radioButtonEntero.TabStop = true;
            this.radioButtonEntero.Text = "Entero";
            this.radioButtonEntero.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(7, 33);
            this.textBox1.MaxLength = 30;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(161, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nombre";
            // 
            // groupBoxEntidadForanea
            // 
            this.groupBoxEntidadForanea.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxEntidadForanea.Controls.Add(this.listBoxEntidadForanea);
            this.groupBoxEntidadForanea.Enabled = false;
            this.groupBoxEntidadForanea.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxEntidadForanea.ForeColor = System.Drawing.Color.White;
            this.groupBoxEntidadForanea.Location = new System.Drawing.Point(607, 9);
            this.groupBoxEntidadForanea.Name = "groupBoxEntidadForanea";
            this.groupBoxEntidadForanea.Size = new System.Drawing.Size(139, 136);
            this.groupBoxEntidadForanea.TabIndex = 5;
            this.groupBoxEntidadForanea.TabStop = false;
            this.groupBoxEntidadForanea.Text = "Entidades";
            // 
            // listBoxEntidadForanea
            // 
            this.listBoxEntidadForanea.FormattingEnabled = true;
            this.listBoxEntidadForanea.Location = new System.Drawing.Point(7, 20);
            this.listBoxEntidadForanea.Name = "listBoxEntidadForanea";
            this.listBoxEntidadForanea.Size = new System.Drawing.Size(120, 95);
            this.listBoxEntidadForanea.TabIndex = 0;
            this.listBoxEntidadForanea.SelectedIndexChanged += new System.EventHandler(this.ListBoxEntidadForanea_SelectedIndexChanged);
            // 
            // buttonModificar
            // 
            this.buttonModificar.Location = new System.Drawing.Point(33, 151);
            this.buttonModificar.Name = "buttonModificar";
            this.buttonModificar.Size = new System.Drawing.Size(75, 23);
            this.buttonModificar.TabIndex = 6;
            this.buttonModificar.Text = "Modificar";
            this.buttonModificar.UseVisualStyleBackColor = true;
            this.buttonModificar.Click += new System.EventHandler(this.ButtonModificar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelar.Location = new System.Drawing.Point(162, 152);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 7;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.ButtonCancelar_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.radioButton0);
            this.flowLayoutPanel1.Controls.Add(this.radioButton3);
            this.flowLayoutPanel1.Controls.Add(this.radioButton1);
            this.flowLayoutPanel1.Controls.Add(this.radioButton2);
            this.flowLayoutPanel1.Enabled = false;
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel1.ForeColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(264, 113);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(337, 61);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // radioButton0
            // 
            this.radioButton0.AutoSize = true;
            this.radioButton0.Checked = true;
            this.radioButton0.ForeColor = System.Drawing.Color.White;
            this.radioButton0.Location = new System.Drawing.Point(3, 3);
            this.radioButton0.Name = "radioButton0";
            this.radioButton0.Size = new System.Drawing.Size(78, 17);
            this.radioButton0.TabIndex = 0;
            this.radioButton0.TabStop = true;
            this.radioButton0.Text = "Sin clave";
            this.radioButton0.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.ForeColor = System.Drawing.Color.White;
            this.radioButton3.Location = new System.Drawing.Point(87, 3);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(104, 17);
            this.radioButton3.TabIndex = 3;
            this.radioButton3.Text = "Clave foranea";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.RadioButton3_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.ForeColor = System.Drawing.Color.White;
            this.radioButton1.Location = new System.Drawing.Point(197, 3);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(134, 17);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.Text = "Clave de busqueda";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Visible = false;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.ForeColor = System.Drawing.Color.White;
            this.radioButton2.Location = new System.Drawing.Point(3, 26);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(106, 17);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.Text = "Clave Primaria";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButtonDecimal
            // 
            this.radioButtonDecimal.AutoSize = true;
            this.radioButtonDecimal.Location = new System.Drawing.Point(197, 62);
            this.radioButtonDecimal.Name = "radioButtonDecimal";
            this.radioButtonDecimal.Size = new System.Drawing.Size(70, 17);
            this.radioButtonDecimal.TabIndex = 6;
            this.radioButtonDecimal.Text = "Decimal";
            this.radioButtonDecimal.UseVisualStyleBackColor = true;
            // 
            // AtributoM
            // 
            this.AcceptButton = this.buttonModificar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.CancelButton = this.buttonCancelar;
            this.ClientSize = new System.Drawing.Size(767, 186);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonModificar);
            this.Controls.Add(this.groupBoxEntidadForanea);
            this.Controls.Add(this.groupBoxAtributo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxAtributo);
            this.Controls.Add(this.listBoxEntidad);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AtributoM";
            this.ShowInTaskbar = false;
            this.Text = "Modificacion de Atributo";
            this.groupBoxAtributo.ResumeLayout(false);
            this.groupBoxAtributo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBoxEntidadForanea.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxEntidad;
        private System.Windows.Forms.ListBox listBoxAtributo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBoxAtributo;
        private System.Windows.Forms.GroupBox groupBoxEntidadForanea;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonModificar;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton radioButtonEntero;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.RadioButton radioButtonCadena;
        private System.Windows.Forms.ListBox listBoxEntidadForanea;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton radioButton0;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButtonDecimal;
    }
}