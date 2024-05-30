namespace Proyecto_Estructura_de_Archivos
{
    partial class Inicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.MenuArchivo = new System.Windows.Forms.ToolStripDropDownButton();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminaBDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Entidad = new System.Windows.Forms.ToolStripDropDownButton();
            this.agregaentidadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.modificaentidadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminaentidadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Atributos = new System.Windows.Forms.ToolStripDropDownButton();
            this.agregaatributoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificaatributoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminaatributoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAyuda = new System.Windows.Forms.ToolStripDropDownButton();
            this.actualizaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.agregarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Tabla = new System.Windows.Forms.TabControl();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnaNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaAtributos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaDatos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaSigEntidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb = new System.Windows.Forms.Label();
            this.consultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuArchivo,
            this.Menu_Entidad,
            this.Menu_Atributos,
            this.MenuAyuda,
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(765, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // MenuArchivo
            // 
            this.MenuArchivo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.MenuArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.abrirToolStripMenuItem,
            this.cerrarToolStripMenuItem,
            this.eliminaBDToolStripMenuItem});
            this.MenuArchivo.Image = ((System.Drawing.Image)(resources.GetObject("MenuArchivo.Image")));
            this.MenuArchivo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuArchivo.Name = "MenuArchivo";
            this.MenuArchivo.Size = new System.Drawing.Size(93, 22);
            this.MenuArchivo.Text = "Base de Datos";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.nuevoToolStripMenuItem.Text = "Nueva - BD";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.NuevoToolStripMenuItem_Click);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.abrirToolStripMenuItem.Text = "Abrir - BD";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.AbrirToolStripMenuItem_Click);
            // 
            // cerrarToolStripMenuItem
            // 
            this.cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            this.cerrarToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.cerrarToolStripMenuItem.Text = "Cerrar - BD";
            this.cerrarToolStripMenuItem.Click += new System.EventHandler(this.CerrarToolStripMenuItem_Click);
            // 
            // eliminaBDToolStripMenuItem
            // 
            this.eliminaBDToolStripMenuItem.Name = "eliminaBDToolStripMenuItem";
            this.eliminaBDToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.eliminaBDToolStripMenuItem.Text = "Elimina - BD";
            this.eliminaBDToolStripMenuItem.Click += new System.EventHandler(this.eliminaBDToolStripMenuItem_Click);
            // 
            // Menu_Entidad
            // 
            this.Menu_Entidad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Menu_Entidad.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregaentidadToolStripMenuItem1,
            this.modificaentidadToolStripMenuItem1,
            this.eliminaentidadToolStripMenuItem1});
            this.Menu_Entidad.Image = ((System.Drawing.Image)(resources.GetObject("Menu_Entidad.Image")));
            this.Menu_Entidad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Menu_Entidad.Name = "Menu_Entidad";
            this.Menu_Entidad.Size = new System.Drawing.Size(52, 22);
            this.Menu_Entidad.Text = "Tablas";
            // 
            // agregaentidadToolStripMenuItem1
            // 
            this.agregaentidadToolStripMenuItem1.Name = "agregaentidadToolStripMenuItem1";
            this.agregaentidadToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.agregaentidadToolStripMenuItem1.Text = "Agregar";
            this.agregaentidadToolStripMenuItem1.Click += new System.EventHandler(this.agregaentidadToolStripMenuItem1_Click);
            // 
            // modificaentidadToolStripMenuItem1
            // 
            this.modificaentidadToolStripMenuItem1.Name = "modificaentidadToolStripMenuItem1";
            this.modificaentidadToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.modificaentidadToolStripMenuItem1.Text = "Modificar";
            this.modificaentidadToolStripMenuItem1.Click += new System.EventHandler(this.modificaentidadToolStripMenuItem1_Click);
            // 
            // eliminaentidadToolStripMenuItem1
            // 
            this.eliminaentidadToolStripMenuItem1.Name = "eliminaentidadToolStripMenuItem1";
            this.eliminaentidadToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.eliminaentidadToolStripMenuItem1.Text = "Eliminar";
            this.eliminaentidadToolStripMenuItem1.Click += new System.EventHandler(this.eliminaentidadToolStripMenuItem1_Click);
            // 
            // Menu_Atributos
            // 
            this.Menu_Atributos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Menu_Atributos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregaatributoToolStripMenuItem,
            this.modificaatributoToolStripMenuItem,
            this.eliminaatributoToolStripMenuItem});
            this.Menu_Atributos.Image = ((System.Drawing.Image)(resources.GetObject("Menu_Atributos.Image")));
            this.Menu_Atributos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Menu_Atributos.Name = "Menu_Atributos";
            this.Menu_Atributos.Size = new System.Drawing.Size(69, 22);
            this.Menu_Atributos.Text = "Atributos";
            // 
            // agregaatributoToolStripMenuItem
            // 
            this.agregaatributoToolStripMenuItem.Name = "agregaatributoToolStripMenuItem";
            this.agregaatributoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.agregaatributoToolStripMenuItem.Text = "Agregar";
            this.agregaatributoToolStripMenuItem.Click += new System.EventHandler(this.agregaatributoToolStripMenuItem_Click);
            // 
            // modificaatributoToolStripMenuItem
            // 
            this.modificaatributoToolStripMenuItem.Name = "modificaatributoToolStripMenuItem";
            this.modificaatributoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.modificaatributoToolStripMenuItem.Text = "Modificar";
            this.modificaatributoToolStripMenuItem.Click += new System.EventHandler(this.modificaatributoToolStripMenuItem_Click);
            // 
            // eliminaatributoToolStripMenuItem
            // 
            this.eliminaatributoToolStripMenuItem.Name = "eliminaatributoToolStripMenuItem";
            this.eliminaatributoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.eliminaatributoToolStripMenuItem.Text = "Eliminar";
            this.eliminaatributoToolStripMenuItem.Click += new System.EventHandler(this.eliminaatributoToolStripMenuItem_Click);
            // 
            // MenuAyuda
            // 
            this.MenuAyuda.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.MenuAyuda.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actualizaToolStripMenuItem,
            this.consultasToolStripMenuItem});
            this.MenuAyuda.Image = ((System.Drawing.Image)(resources.GetObject("MenuAyuda.Image")));
            this.MenuAyuda.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuAyuda.Name = "MenuAyuda";
            this.MenuAyuda.Size = new System.Drawing.Size(70, 22);
            this.MenuAyuda.Text = "Opciones";
            // 
            // actualizaToolStripMenuItem
            // 
            this.actualizaToolStripMenuItem.Name = "actualizaToolStripMenuItem";
            this.actualizaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.actualizaToolStripMenuItem.Text = "Actualiza";
            this.actualizaToolStripMenuItem.Click += new System.EventHandler(this.actualizaToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarToolStripMenuItem,
            this.modificarToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(68, 22);
            this.toolStripDropDownButton1.Text = "Registros";
            // 
            // agregarToolStripMenuItem
            // 
            this.agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            this.agregarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.agregarToolStripMenuItem.Text = "Agregar";
            this.agregarToolStripMenuItem.Click += new System.EventHandler(this.agregarToolStripMenuItem_Click);
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.modificarToolStripMenuItem.Text = "Modificar";
            this.modificarToolStripMenuItem.Click += new System.EventHandler(this.modificarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // Tabla
            // 
            this.Tabla.Location = new System.Drawing.Point(13, 402);
            this.Tabla.Name = "Tabla";
            this.Tabla.SelectedIndex = 0;
            this.Tabla.Size = new System.Drawing.Size(740, 276);
            this.Tabla.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnaNombre,
            this.Column1,
            this.Column2,
            this.ColumnaDireccion,
            this.ColumnaAtributos,
            this.ColumnaDatos,
            this.ColumnaSigEntidad});
            this.dataGridView1.Location = new System.Drawing.Point(12, 57);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.ShowCellErrors = false;
            this.dataGridView1.ShowCellToolTips = false;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.ShowRowErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(741, 295);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            // 
            // ColumnaNombre
            // 
            this.ColumnaNombre.FillWeight = 284.2639F;
            this.ColumnaNombre.HeaderText = "Nombre";
            this.ColumnaNombre.Name = "ColumnaNombre";
            this.ColumnaNombre.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 69.28934F;
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 69.28934F;
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // ColumnaDireccion
            // 
            this.ColumnaDireccion.FillWeight = 69.28934F;
            this.ColumnaDireccion.HeaderText = "Direccion";
            this.ColumnaDireccion.Name = "ColumnaDireccion";
            this.ColumnaDireccion.ReadOnly = true;
            this.ColumnaDireccion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // ColumnaAtributos
            // 
            this.ColumnaAtributos.FillWeight = 69.28934F;
            this.ColumnaAtributos.HeaderText = "Primer Atributo";
            this.ColumnaAtributos.Name = "ColumnaAtributos";
            this.ColumnaAtributos.ReadOnly = true;
            // 
            // ColumnaDatos
            // 
            this.ColumnaDatos.FillWeight = 69.28934F;
            this.ColumnaDatos.HeaderText = "Primer Dato";
            this.ColumnaDatos.Name = "ColumnaDatos";
            this.ColumnaDatos.ReadOnly = true;
            // 
            // ColumnaSigEntidad
            // 
            this.ColumnaSigEntidad.FillWeight = 69.28934F;
            this.ColumnaSigEntidad.HeaderText = "SiguienteEntidad";
            this.ColumnaSigEntidad.Name = "ColumnaSigEntidad";
            this.ColumnaSigEntidad.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Base de Datos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 374);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Atributos";
            // 
            // cb
            // 
            this.cb.AutoSize = true;
            this.cb.BackColor = System.Drawing.Color.Transparent;
            this.cb.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb.ForeColor = System.Drawing.Color.White;
            this.cb.Location = new System.Drawing.Point(667, 29);
            this.cb.Name = "cb";
            this.cb.Size = new System.Drawing.Size(32, 25);
            this.cb.TabIndex = 11;
            this.cb.Text = "-1";
            this.cb.Visible = false;
            // 
            // consultasToolStripMenuItem
            // 
            this.consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            this.consultasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.consultasToolStripMenuItem.Text = "Consultas";
            this.consultasToolStripMenuItem.Click += new System.EventHandler(this.consultasToolStripMenuItem_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(765, 690);
            this.Controls.Add(this.cb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Tabla);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Base de Datos";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton MenuArchivo;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.TabControl Tabla;
        private System.Windows.Forms.ToolStripDropDownButton MenuAyuda;
        private System.Windows.Forms.ToolStripMenuItem cerrarToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaAtributos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaSigEntidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label cb;
        private System.Windows.Forms.ToolStripDropDownButton Menu_Entidad;
        private System.Windows.Forms.ToolStripMenuItem agregaentidadToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem modificaentidadToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem eliminaentidadToolStripMenuItem1;
        private System.Windows.Forms.ToolStripDropDownButton Menu_Atributos;
        private System.Windows.Forms.ToolStripMenuItem agregaatributoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificaatributoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminaatributoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actualizaToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminaBDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem;
    }
}

