namespace Proyecto_Estructura_de_Archivos
{
    partial class EntidadA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntidadA));
            this.nombreEntidad = new System.Windows.Forms.Label();
            this.entradaNombre = new System.Windows.Forms.TextBox();
            this.botonAceptar = new System.Windows.Forms.Button();
            this.botonCancelar = new System.Windows.Forms.Button();
            this.radioButtonSecuencial = new System.Windows.Forms.RadioButton();
            this.radioButtonSecIndex = new System.Windows.Forms.RadioButton();
            this.radioButtonHash = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // nombreEntidad
            // 
            this.nombreEntidad.AutoSize = true;
            this.nombreEntidad.BackColor = System.Drawing.Color.Transparent;
            this.nombreEntidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreEntidad.ForeColor = System.Drawing.Color.White;
            this.nombreEntidad.Location = new System.Drawing.Point(0, 9);
            this.nombreEntidad.Name = "nombreEntidad";
            this.nombreEntidad.Size = new System.Drawing.Size(214, 25);
            this.nombreEntidad.TabIndex = 0;
            this.nombreEntidad.Text = "Nombre de la Tabla :";
            // 
            // entradaNombre
            // 
            this.entradaNombre.Location = new System.Drawing.Point(5, 37);
            this.entradaNombre.MaxLength = 30;
            this.entradaNombre.Name = "entradaNombre";
            this.entradaNombre.Size = new System.Drawing.Size(228, 20);
            this.entradaNombre.TabIndex = 1;
            // 
            // botonAceptar
            // 
            this.botonAceptar.Location = new System.Drawing.Point(246, 75);
            this.botonAceptar.Name = "botonAceptar";
            this.botonAceptar.Size = new System.Drawing.Size(94, 23);
            this.botonAceptar.TabIndex = 2;
            this.botonAceptar.Text = "Aceptar";
            this.botonAceptar.UseVisualStyleBackColor = true;
            this.botonAceptar.Click += new System.EventHandler(this.BotonAceptar_Click);
            // 
            // botonCancelar
            // 
            this.botonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.botonCancelar.Location = new System.Drawing.Point(246, 37);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(94, 23);
            this.botonCancelar.TabIndex = 3;
            this.botonCancelar.Text = "Cancelar";
            this.botonCancelar.UseVisualStyleBackColor = true;
            this.botonCancelar.Click += new System.EventHandler(this.BotonCancelar_Click);
            // 
            // radioButtonSecuencial
            // 
            this.radioButtonSecuencial.AutoSize = true;
            this.radioButtonSecuencial.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonSecuencial.Checked = true;
            this.radioButtonSecuencial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonSecuencial.ForeColor = System.Drawing.Color.White;
            this.radioButtonSecuencial.Location = new System.Drawing.Point(5, 63);
            this.radioButtonSecuencial.Name = "radioButtonSecuencial";
            this.radioButtonSecuencial.Size = new System.Drawing.Size(103, 20);
            this.radioButtonSecuencial.TabIndex = 4;
            this.radioButtonSecuencial.TabStop = true;
            this.radioButtonSecuencial.Text = "Secuencial";
            this.radioButtonSecuencial.UseVisualStyleBackColor = false;
            this.radioButtonSecuencial.Visible = false;
            // 
            // radioButtonSecIndex
            // 
            this.radioButtonSecIndex.AutoSize = true;
            this.radioButtonSecIndex.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonSecIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonSecIndex.ForeColor = System.Drawing.Color.White;
            this.radioButtonSecIndex.Location = new System.Drawing.Point(5, 115);
            this.radioButtonSecIndex.Name = "radioButtonSecIndex";
            this.radioButtonSecIndex.Size = new System.Drawing.Size(171, 20);
            this.radioButtonSecIndex.TabIndex = 5;
            this.radioButtonSecIndex.Text = "Secuencial indexado";
            this.radioButtonSecIndex.UseVisualStyleBackColor = false;
            this.radioButtonSecIndex.Visible = false;
            // 
            // radioButtonHash
            // 
            this.radioButtonHash.AutoSize = true;
            this.radioButtonHash.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonHash.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonHash.ForeColor = System.Drawing.Color.White;
            this.radioButtonHash.Location = new System.Drawing.Point(5, 89);
            this.radioButtonHash.Name = "radioButtonHash";
            this.radioButtonHash.Size = new System.Drawing.Size(121, 20);
            this.radioButtonHash.TabIndex = 6;
            this.radioButtonHash.Text = "Hash estatico";
            this.radioButtonHash.UseVisualStyleBackColor = false;
            this.radioButtonHash.Visible = false;
            // 
            // EntidadA
            // 
            this.AcceptButton = this.botonAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.CancelButton = this.botonCancelar;
            this.ClientSize = new System.Drawing.Size(346, 146);
            this.Controls.Add(this.radioButtonHash);
            this.Controls.Add(this.radioButtonSecIndex);
            this.Controls.Add(this.radioButtonSecuencial);
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.botonAceptar);
            this.Controls.Add(this.entradaNombre);
            this.Controls.Add(this.nombreEntidad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EntidadA";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tabla";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nombreEntidad;
        private System.Windows.Forms.TextBox entradaNombre;
        private System.Windows.Forms.Button botonAceptar;
        private System.Windows.Forms.Button botonCancelar;
        private System.Windows.Forms.RadioButton radioButtonSecuencial;
        private System.Windows.Forms.RadioButton radioButtonSecIndex;
        private System.Windows.Forms.RadioButton radioButtonHash;
    }
}