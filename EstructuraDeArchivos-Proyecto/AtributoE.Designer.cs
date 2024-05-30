namespace Proyecto_Estructura_de_Archivos
{
    partial class AtributoE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AtributoE));
            this.listBoxEntidades = new System.Windows.Forms.ListBox();
            this.Entidadlabel = new System.Windows.Forms.Label();
            this.AtributoLabel = new System.Windows.Forms.Label();
            this.listBoxAtributos = new System.Windows.Forms.ListBox();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxEntidades
            // 
            this.listBoxEntidades.FormattingEnabled = true;
            this.listBoxEntidades.Location = new System.Drawing.Point(41, 115);
            this.listBoxEntidades.Name = "listBoxEntidades";
            this.listBoxEntidades.Size = new System.Drawing.Size(120, 134);
            this.listBoxEntidades.TabIndex = 0;
            this.listBoxEntidades.SelectedIndexChanged += new System.EventHandler(this.ListBoxEntidades_SelectedIndexChanged);
            // 
            // Entidadlabel
            // 
            this.Entidadlabel.AutoSize = true;
            this.Entidadlabel.BackColor = System.Drawing.Color.Transparent;
            this.Entidadlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Entidadlabel.ForeColor = System.Drawing.Color.White;
            this.Entidadlabel.Location = new System.Drawing.Point(76, 99);
            this.Entidadlabel.Name = "Entidadlabel";
            this.Entidadlabel.Size = new System.Drawing.Size(45, 13);
            this.Entidadlabel.TabIndex = 1;
            this.Entidadlabel.Text = "Tablas";
            // 
            // AtributoLabel
            // 
            this.AtributoLabel.AutoSize = true;
            this.AtributoLabel.BackColor = System.Drawing.Color.Transparent;
            this.AtributoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AtributoLabel.ForeColor = System.Drawing.Color.White;
            this.AtributoLabel.Location = new System.Drawing.Point(263, 99);
            this.AtributoLabel.Name = "AtributoLabel";
            this.AtributoLabel.Size = new System.Drawing.Size(51, 13);
            this.AtributoLabel.TabIndex = 2;
            this.AtributoLabel.Text = "Atributo";
            // 
            // listBoxAtributos
            // 
            this.listBoxAtributos.FormattingEnabled = true;
            this.listBoxAtributos.Location = new System.Drawing.Point(225, 115);
            this.listBoxAtributos.Name = "listBoxAtributos";
            this.listBoxAtributos.Size = new System.Drawing.Size(120, 134);
            this.listBoxAtributos.TabIndex = 3;
            this.listBoxAtributos.SelectedIndexChanged += new System.EventHandler(this.ListBoxAtributos_SelectedIndexChanged);
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Location = new System.Drawing.Point(62, 255);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(75, 23);
            this.buttonEliminar.TabIndex = 4;
            this.buttonEliminar.Text = "Eliminar";
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Click += new System.EventHandler(this.ButtonEliminar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelar.Location = new System.Drawing.Point(249, 255);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 5;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.ButtonCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(89, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Seleccione la Tabla";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(179, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(46, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(278, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = " Su Atributo correspondiente";
            // 
            // AtributoE
            // 
            this.AcceptButton = this.buttonEliminar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.CancelButton = this.buttonCancelar;
            this.ClientSize = new System.Drawing.Size(378, 290);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.listBoxAtributos);
            this.Controls.Add(this.AtributoLabel);
            this.Controls.Add(this.Entidadlabel);
            this.Controls.Add(this.listBoxEntidades);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AtributoE";
            this.ShowInTaskbar = false;
            this.Text = "Eliminacion de Atributo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxEntidades;
        private System.Windows.Forms.Label Entidadlabel;
        private System.Windows.Forms.Label AtributoLabel;
        private System.Windows.Forms.ListBox listBoxAtributos;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}