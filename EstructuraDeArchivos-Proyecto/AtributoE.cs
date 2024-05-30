using System;
using System.Windows.Forms;

namespace Proyecto_Estructura_de_Archivos
{
    public partial class AtributoE : Form
    {
        Inicio principal;
        Entidad AuxEnt = null;
        Atributo AuxAt = null;
        public AtributoE(Inicio Prin)
        {
            InitializeComponent();
            principal = Prin;
            foreach (Entidad entidad in principal.Entidades)
                listBoxEntidades.Items.Add(entidad.Nombre);
        }

        private void ListBoxEntidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxEntidades.SelectedIndex >= 0)
            {
                listBoxAtributos.Items.Clear();
                foreach (Atributo atributo in principal.Entidades[listBoxEntidades.SelectedIndex].Atributos)
                    listBoxAtributos.Items.Add(atributo.Nombre);
                AuxAt = null;
                AuxEnt = principal.Entidades[listBoxEntidades.SelectedIndex]; //Almaceno la entidad de donde elimino el atributo
            }
        }

        private void ListBoxAtributos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxAtributos.SelectedIndex >= 0)
                AuxAt = AuxEnt.Atributos[listBoxAtributos.SelectedIndex]; //Almacena el atributo a eliminar.
        }

        private void ButtonEliminar_Click(object sender, EventArgs e)
        {
            int resultado = principal.EliminarAtributo(AuxEnt, AuxAt);
            if (resultado == 0)
                this.Close();
            else if (resultado == 1)
                MessageBox.Show("Selecciona una entidad");
            else if (resultado == 2)
                MessageBox.Show("Selecciona un atributo");
            else if (resultado == 4)
                MessageBox.Show("Error de Integridad - No debe de existir datos en la Tabla.");
        }

        private void ButtonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
