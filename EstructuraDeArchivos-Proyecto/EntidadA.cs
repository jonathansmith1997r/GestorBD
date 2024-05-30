using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Proyecto_Estructura_de_Archivos
{
    public partial class EntidadA : Form
    {
        private Inicio PT;
        public EntidadA(Inicio P)
        {
            InitializeComponent();
            this.PT = P;
        }

        private void BotonAceptar_Click(object sender, EventArgs e)
        {
            if (entradaNombre.TextLength > 0 && entradaNombre.TextLength <= 30)
            {
                string Fort = "";
                Fort += Char.ToUpper(entradaNombre.Text.First());
                Fort += entradaNombre.Text.Substring(1, entradaNombre.Text.Length - 1);
                string nombre = Fort.Replace(" ", "_");
                foreach (char CHE in Path.GetInvalidPathChars())
                {
                    if (nombre.Contains(CHE))
                    {
                        MessageBox.Show(nombre.Length + "");
                    }
                }
                int Torden = 0;
                if (radioButtonSecuencial.Checked)
                    Torden = 0;
                else if (radioButtonSecIndex.Checked)
                    Torden = 1;
                else if (radioButtonHash.Checked)
                    Torden = 2;

                int res = PT.AgregarEntidad(nombre, Torden);
                if (res == 0)
                {
                    this.Close();
                    FileStream fs = new FileStream(nombre + ".dat", FileMode.Create);
                    BinaryWriter bw = new BinaryWriter(fs);
                    if (Torden == 1 || Torden == 2)
                    {
                        FileStream fis = new FileStream(nombre + ".idx", FileMode.Create);
                        BinaryWriter biw = new BinaryWriter(fs);
                        fis.Close();
                        bw.Close();
                    }
                    fs.Close();
                    bw.Close();
                }
                else
                    MessageBox.Show("Ya existe una entidad con el mismo nombre");
            }
        }

        private void BotonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
