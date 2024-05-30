using System;
using System.Windows.Forms;

namespace Proyecto_Estructura_de_Archivos
{
    public partial class AtributoM : Form
    {
        private Inicio principal = null;
        private Entidad SelectEnt = null;
        private Atributo SelectAt = null;
        private Entidad EntForNew = null;
        public AtributoM(Inicio Prim)
        { 
            InitializeComponent();
            principal = Prim;
            foreach (Entidad entidad in principal.Entidades)
                listBoxEntidad.Items.Add(entidad.Nombre);
        }

        private void ButtonModificar_Click(object sender, EventArgs e)
        {
            char tipo;
            if (radioButtonEntero.Checked)
                tipo = 'E';
            else if (radioButtonCadena.Checked)
                tipo = 'C';
            else if (radioButtonDecimal.Checked)
                tipo = 'D';
            else
                tipo = 'D';

            int tipoIndice = -1;
            if (radioButton0.Checked)
                tipoIndice = 0;
            else if (radioButton1.Checked)
                tipoIndice = 1;
            else if (radioButton2.Checked)
                tipoIndice = 2;
            else if (radioButton3.Checked)
            {

                tipoIndice = 3;
            }

            int tamaño = Decimal.ToInt16(numericUpDown1.Value);
            int respuesta = principal.ModificarAtributo(SelectEnt, SelectAt, textBox1.Text.Replace(" ", "_"), tipo, tamaño, tipoIndice, EntForNew);
            if (respuesta == 0)
                this.Close();
            else if (respuesta == 6)
                MessageBox.Show("Ya existe un atributo con el mismo nombre");
            else if (respuesta == 7)
                MessageBox.Show("Ya existe un atributo con la misma clave primaria");
            else if (respuesta == 3)
                MessageBox.Show("La entidad foranea no tiene clave primaria");
            else if (respuesta == 5)
                MessageBox.Show("La clave foranea necesita el mismo tamaño (" + EntForNew.ClavePrimaria.Size + ")");
            else if (respuesta == 2)
                MessageBox.Show("Selecciona una entidad para la entidad foranea");
            else if (respuesta == 4)
                MessageBox.Show("El tipo debe ser el mismo que la llave primaria de la entidad foranea");
            else if (respuesta == 8)
            {
                MessageBox.Show("Error de Integridad - La tabla aun tiene datos");
            }
        }

        private void ListBoxEntidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxEntidad.SelectedIndex >= 0)
            {
                SelectEnt = principal.Entidades[listBoxEntidad.SelectedIndex];
                listBoxAtributo.Items.Clear();
                foreach (Atributo atributo in SelectEnt.Atributos)
                    listBoxAtributo.Items.Add(atributo.Nombre);
                groupBoxAtributo.Enabled = groupBoxEntidadForanea.Enabled = flowLayoutPanel1.Enabled = buttonModificar.Enabled = false;
            }
        }

        private void ListBoxAtributo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxAtributo.SelectedIndex >= 0)
            {
                groupBoxAtributo.Enabled = flowLayoutPanel1.Enabled = buttonModificar.Enabled = true;
                SelectAt = SelectEnt.Atributos[listBoxAtributo.SelectedIndex];
                textBox1.Text = "";
                listBoxEntidadForanea.Items.Clear();
                textBox1.Text = SelectAt.Nombre.Trim();
                foreach (Entidad EntDif in principal.Entidades)
                {
                    if (EntDif != SelectEnt)
                        listBoxEntidadForanea.Items.Add(EntDif.Nombre);
                }
                if (SelectAt.Tipo == 'E')
                {
                    radioButtonEntero.Checked = true;
                    numericUpDown1.Value = 4;
                }
                else if (SelectAt.Tipo == 'C')
                {
                    radioButtonCadena.Checked = true;
                    numericUpDown1.Value = SelectAt.Size;
                }
                else
                {
                    radioButtonDecimal.Checked = true;
                    numericUpDown1.Value = 4;
                }

                switch (SelectAt.TPC)
                {
                    case 0:
                        radioButton0.Checked = true;
                        break;
                    case 1:
                        radioButton1.Checked = true;
                        break;
                    case 2:
                        radioButton2.Checked = true;
                        break;
                    case 3:
                        radioButton3.Checked = true;
                        groupBoxEntidadForanea.Enabled = true;

                        foreach (Entidad EntAux2 in principal.Entidades)
                        {
                            if (EntAux2.Direccion == SelectAt.DDI)
                            {
                                listBoxEntidadForanea.SelectedItem = EntAux2.Nombre;
                                EntForNew = EntAux2;
                            }
                        }
                        break;
                }
            }
        }

        private void RadioButtonCadena_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCadena.Checked)
            {
                numericUpDown1.Enabled = true;
            }
            else
            {
                numericUpDown1.Value = 4;
                numericUpDown1.Enabled = false;
            }

        }


        private void ButtonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// 
        /// Determina la nueva entidad foranea
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBoxEntidadForanea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxEntidadForanea.SelectedIndex >= 0)
            {
                foreach (Entidad entidad in principal.Entidades)
                {
                    if (entidad.Nombre.CompareTo(listBoxEntidadForanea.SelectedItem) == 0)
                        EntForNew = entidad;
                }
            }
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
                groupBoxEntidadForanea.Enabled = true;
            else
                groupBoxEntidadForanea.Enabled = false;
        }
    }
}
