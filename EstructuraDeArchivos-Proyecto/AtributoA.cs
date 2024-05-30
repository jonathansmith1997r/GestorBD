using System;
using System.Windows.Forms;

namespace Proyecto_Estructura_de_Archivos
{
    public partial class AtributoA : Form
    {
        private Inicio Principal;
        private Entidad EntSeleccion = null;
        private Entidad EntidadF = null;
        public AtributoA(Inicio Ini)
        {
            InitializeComponent();
            this.Principal = Ini;
            foreach (Entidad entidad in Ini.Entidades)
            {
                listBoxEntidades.Items.Add(entidad.Nombre);
            }
            textBox1.CharacterCasing = CharacterCasing.Lower;
        }

        /// <summary>
        /// 
        /// Muestra las Tablas con claves primarias.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                claveForaneaGroup.Enabled = true;
                Nuevo.Enabled = true;
            }
            else
            {
                claveForaneaGroup.Enabled = false;
                Nuevo.Enabled = false;
            }
        }

        private void ListBoxEntidadesForaneas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxEntidadesForaneas.SelectedIndex >= 0)
            {
                listBoxAtributosForaneos.Items.Clear();
                foreach (Entidad entidad in Principal.Entidades)
                    if (entidad.Nombre.CompareTo(listBoxEntidadesForaneas.SelectedItem) == 0)
                        EntidadF = entidad;
                if (EntidadF != null)
                    if (EntidadF.ClavePrimaria != null)
                        foreach (Atributo atributo in EntidadF.Atributos)
                            listBoxAtributosForaneos.Items.Add(atributo.Nombre);
                    else
                        listBoxAtributosForaneos.Items.Add("No tiene clave primaria");
            }
        }

        private void ListBoxEntidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxEntidades.SelectedIndex >= 0)
            {
                listBoxEntidadesForaneas.Items.Clear();
                EntSeleccion = Principal.Entidades[listBoxEntidades.SelectedIndex];
                if (EntSeleccion != null)
                    foreach (Entidad unaEntidad in Principal.Entidades)
                    {
                        if (unaEntidad != EntSeleccion)
                            listBoxEntidadesForaneas.Items.Add(unaEntidad.Nombre);
                    }
            }
        }

        private void RadioBotonEntero_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBotonEntero.Checked)
            {
                numericTamaño.Value = 4;
                numericTamaño.Enabled = false;
            }
            else
            {
                numericTamaño.Enabled = true;
            }
        }

        private void BotonAceptar_Click(object sender, EventArgs e)
        {
            if (EntSeleccion != null && textBox1.Text.Length > 0)
            {
                char tipo1;
                if (radioBotonEntero.Checked)
                    tipo1 = 'E';
                else if (radioBotonCadena.Checked)
                    tipo1 = 'C';
                else
                    tipo1 = 'D';


                int tipoIndice = -1;

                if (radioButton0.Checked)
                    tipoIndice = 0;
                else if (radioButton1.Checked)
                    tipoIndice = 1;
                else if (radioButton2.Checked)
                {
                    tipoIndice = 2;
                }
                else if (radioButton3.Checked)
                    tipoIndice = 3;

                int tamaño = Decimal.ToInt16(numericTamaño.Value);
                int respuesta = Principal.AgregarAtributo(textBox1.Text.Replace(" ", "_"), EntSeleccion, tipo1, tamaño, tipoIndice, EntidadF);
                if (respuesta == 0)
                    this.Close();
                else if (respuesta == 1)
                    MessageBox.Show("Ya existe un atributo con el mismo nombre");
                else if (respuesta == 2)
                    MessageBox.Show("Ya existe un atributo con esa clave primaria");
                else if (respuesta == 3)
                    MessageBox.Show("La entidad foranea no tiene clave primaria");
                else if (respuesta == 4)
                    MessageBox.Show("La clave foranea necesita el mismo tamaño (" + EntidadF.ClavePrimaria.Size + ")");
                else if (respuesta == 5)
                    MessageBox.Show("Selecciona una entidad para la entidad foranea");
                else if (respuesta == 6)
                    MessageBox.Show("El tipo debe ser el mismo que la llave primaria de la entidad foranea");
                else if (respuesta == 9)
                    MessageBox.Show("Error de Integridad - No se puede agregar un atributo a una entidad con datos.");
            }
        }

        /// <summary>
        /// 
        /// Cancela la agregacion del atributo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BotonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 
        /// Controlador de estado si es Decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBotonDecimal.Checked)
            {
                numericTamaño.Value = 8;
                numericTamaño.Enabled = false;
            }
            else
            {
                numericTamaño.Enabled = true;
            }
        }
    }
}
