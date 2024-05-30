using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Proyecto_Estructura_de_Archivos
{
    public partial class EntidadM : Form
    {
        Inicio PT;
        Entidad Ent = null;
        int IdxSelec = -1;
        public EntidadM(Inicio prim)
        {
            InitializeComponent();
            PT = prim;

            foreach (Entidad entidad in PT.Entidades)
                listBox1.Items.Add(entidad.Nombre);
        }

        private void ButtonAceptar_Click(object sender, EventArgs e)
        {
            string Fort = "";
            string OldName = "";
            Fort += Char.ToUpper(textBox1.Text.First());
            Fort += textBox1.Text.Substring(1, textBox1.Text.Length - 1);
            string NewName = Fort.Replace(" ", "_");
            if (IdxSelec >= 0)
            {
                Ent = PT.Entidades[IdxSelec];
                OldName = PT.Entidades[IdxSelec].Nombre;
            }
            int res = PT.ModificarEntidad(Ent, NewName);
            if (res == 0)
            {
                string New = Directory.GetCurrentDirectory() + "\\" + NewName + ".dat";
                File.Move(Directory.GetCurrentDirectory() + "\\" + OldName + ".dat", New);

                this.Close();
            }
            else if (res == 1)
                MessageBox.Show("Selecciona una entidad");
            else if (res == 2)
                MessageBox.Show("Ya existe una entidad con el mismo nombre");
            else if (res == 3)
                MessageBox.Show("No se puede insertar una cadena vacia");
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                textBox1.Text = PT.Entidades[listBox1.SelectedIndex].Nombre.Trim();
                IdxSelec = listBox1.SelectedIndex;
            }
        }

        private void ButtonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
