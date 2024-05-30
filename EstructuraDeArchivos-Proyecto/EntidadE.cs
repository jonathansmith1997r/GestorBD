using System;
using System.IO;
using System.Windows.Forms;

namespace Proyecto_Estructura_de_Archivos
{
    public partial class EntidadE : Form
    {
        Inicio PT;
        Entidad Ent = null;
        int IdxSelec = -1;
        public EntidadE(Inicio prim)
        {
            InitializeComponent();
            PT = prim;

            foreach (Entidad entidad in PT.Entidades)
                listBox1.Items.Add(entidad.Nombre);
        }

        private void Buttoneliminar_Click(object sender, EventArgs e)
        {
            if (IdxSelec >= 0)
                Ent = PT.Entidades[IdxSelec];
            int res = PT.EliminarEntidad(Ent);
            if (res == 0)
            {
                if (File.Exists(Directory.GetCurrentDirectory() + "\\" + Ent.Nombre + ".dat"))
                    File.Delete(Directory.GetCurrentDirectory() + "\\" + Ent.Nombre + ".dat");
                this.Close();
            }
            else if (res == 1)
                MessageBox.Show("Selecciona una entidad");
            else if (res == 2)
                MessageBox.Show("Elimina primero los datos de la entidad");
        }

        private void Buttoncancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                IdxSelec = listBox1.SelectedIndex;
            }
        }
    }
}
