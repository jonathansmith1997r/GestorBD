using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Globalization;

namespace Proyecto_Estructura_de_Archivos
{
    public partial class RegistroM : Form
    {
        Inicio InicioF = null;
        Entidad entidadR = null;
        Entidad aux = null;
        List<string> auxclave;
        string DirArchivo;
        string DirDiccionario;

        /// <summary>
        /// 
        /// Integridad Referencial completada.
        /// </summary>
        /// <param name="Prim"></param>
        /// <param name="EntExt"></param>
        /// <param name="dr"></param>
        /// <param name="drdd"></param>
        public RegistroM(Inicio Prim, Entidad EntExt, string dr, string drdd)
        {
            InitializeComponent();
            InicioF = Prim;
            entidadR = EntExt;
            DirArchivo = dr;
            DirDiccionario = drdd;
            auxclave = new List<string>();
            int tipoDatoReg = VerificarTipoReg();
            auxclave = entidadR.ObtClave(dr, tipoDatoReg, entidadR.Atributos[0].Direccion);
            if (entidadR.Orden == TOrden.Secuencial)
                foreach (string c in auxclave)
                {
                    listBox1.Items.Add(c);
                }

            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("No existen datos");
                this.Close();
            }
            foreach (Atributo atr in entidadR.Atributos)
            {
                comboBox1.Items.Add(atr.Nombre);
            }
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            Editar();
            this.Close();
        }

        /// <summary>
        /// 
        /// Verifica si el registro a Modificar tiene un atributo de tipo clave primaria
        /// Si no cuenta con clave primaria, manda el tipo de clave del primer atributo.
        /// </summary>
        /// <returns></returns>
        private int VerificarTipoReg()
        {
            bool TieneClavePrimaria = false;
            foreach (Atributo atrb in entidadR.Atributos)
            {
                if (atrb.TPC == 2)
                {
                    TieneClavePrimaria = true;
                    break;
                }
            }
            if (!TieneClavePrimaria)
            {
                return entidadR.Atributos[0].TPC;
            }
            else
                return 2;
        }

        /// <summary>
        /// 
        /// Verifica que el atributo a modificar si es clave primaria no este vinculado con otra tabla por referencia
        /// </summary>
        /// <param name="atributoM"></param>
        /// <returns></returns>
        private bool IntegridadModAtributo(int indice)
        {
            bool Integridad = true;

            List<List<string>> ClavesForaneasE = new List<List<string>>();
            List<string> auxCve = new List<string>();
            string DirDat = "";

            foreach (Entidad enti in InicioF.Entidades)
            {
                foreach (Atributo atrb in enti.Atributos)
                {
                    if (atrb.TPC == 3)
                    {
                        if (entidadR.Direccion == atrb.DDI)
                        {

                            DirDat = DirArchivo + "//" + enti.Nombre + ".dat";
                            auxCve = enti.ObtClave(DirDat, 3, atrb.Direccion);
                            ClavesForaneasE.Add(auxCve);
                        }

                    }
                }
            }

            foreach (List<string> op in ClavesForaneasE)
            {
                foreach (string ui in op)
                {
                    if (auxclave[indice].CompareTo(ui) == 0)
                    {
                        Integridad = false;
                    }
                    MessageBox.Show(ui + ' ' + auxclave[indice] + op.Count);
                }
            }
            return Integridad;
        }

        /// <summary>
        /// 
        /// Se modifica el registro respetando los datos que no esten referenciados
        /// </summary>
        /// <returns></returns>
        private int Editar()
        {
            if (listBox1.SelectedIndex >= 0 && comboBox1.SelectedIndex >= 0)
            {
                string DirDat = DirArchivo + "//" + entidadR.Nombre + ".dat";
                List<long> DirDato;
                List<long> DirSigDato;
                using (BinaryReader Leer = new BinaryReader(new FileStream(DirDat, FileMode.Open)))
                {

                    DirDato = entidadR.RegDir(Leer, listBox1.SelectedIndex);
                }

                if ((entidadR.Atributos[comboBox1.SelectedIndex].TPC == 2 && entidadR.Orden == TOrden.Secuencial))
                {

                    List<string> Cves = entidadR.ObtClave(DirDat, entidadR.Atributos[comboBox1.SelectedIndex].TPC,entidadR.Atributos[0].Direccion);
                    Cves.RemoveAt(listBox1.SelectedIndex);
                    int Indice = 0;

                    //////////// Aqui verifica que no se repita el registro en la misma Tabla <----------
                    foreach (string c in Cves)
                    {
                        if (entidadR.Atributos[comboBox1.SelectedIndex].Tipo == 'C')
                        {
                            int com = (groupBox1.Controls[0] as TextBox).Text.TrimEnd(' ').CompareTo(c);
                            if (com == 0)
                            {
                                MessageBox.Show("Clave repetida");
                                return 1;
                            }
                            else if (com == -1)
                                break;
                            else
                                Indice++;
                        }
                        else if (entidadR.Atributos[comboBox1.SelectedIndex].Tipo == 'E')
                        {
                            int val = (int)(groupBox1.Controls[0] as NumericUpDown).Value;
                            if (val > Int32.Parse(c.TrimEnd(' ')))
                                Indice++;
                            else if (val == Int32.Parse(c.TrimEnd(' ')))
                            {
                                MessageBox.Show("Clave repetida");
                                return 1;
                            }
                            else
                                break;
                        }
                        else if (entidadR.Atributos[comboBox1.SelectedIndex].Tipo == 'D')
                        {
                            float val = Convert.ToSingle((groupBox1.Controls[0] as TextBox).Text);
                            if (val > float.Parse(c.TrimEnd(' ')))
                                Indice++;
                            else if (val == float.Parse(c.TrimEnd(' ')))
                            {
                                MessageBox.Show("Clave repetida");
                                return 1;
                            }
                            else
                                break;
                        }
                    }

                    /////Aqui ya modifica los archivos <--------------------
                    if ((entidadR.Atributos[comboBox1.SelectedIndex].TPC == 2 && entidadR.Orden == TOrden.Secuencial) && IntegridadModAtributo(listBox1.SelectedIndex))
                    {

                        if (DirDato[0] == -1)
                            using (BinaryWriter w = new BinaryWriter(new FileStream(DirDiccionario, FileMode.Open)))
                            {
                                w.BaseStream.Seek(entidadR.Direccion + 46, SeekOrigin.Begin);
                                w.Write(DirDato[2]);
                                entidadR.PD = DirDato[2];
                            }
                        else
                            using (BinaryWriter w = new BinaryWriter(new FileStream(DirArchivo + "//" + entidadR.Nombre + ".dat", FileMode.Open)))
                            {
                                w.BaseStream.Seek(DirDato[0] + entidadR.SizeD() + 8, SeekOrigin.Begin);
                                w.Write(DirDato[2]);
                            }
                        using (BinaryReader r = new BinaryReader(new FileStream(DirDat, FileMode.Open)))
                        {
                            DirSigDato = entidadR.RegDir(r, Indice);
                        }
                        if (DirSigDato[0] == -1)
                            using (BinaryWriter w = new BinaryWriter(new FileStream(DirDiccionario, FileMode.Open)))
                            {
                                w.BaseStream.Seek(entidadR.Direccion + 46, SeekOrigin.Begin);
                                w.Write(DirDato[1]);
                                entidadR.PD = DirDato[1];
                            }
                        else
                            using (BinaryWriter w = new BinaryWriter(new FileStream(DirArchivo + "//" + entidadR.Nombre + ".dat", FileMode.Open)))
                            {
                                w.BaseStream.Seek(DirSigDato[0] + entidadR.SizeD() + 8, SeekOrigin.Begin);
                                w.Write(DirDato[1]);
                            }

                        using (BinaryWriter w = new BinaryWriter(new FileStream(DirArchivo + "//" + entidadR.Nombre + ".dat", FileMode.Open)))
                        {
                            w.BaseStream.Seek(DirDato[1] + entidadR.SizeD() + 8, SeekOrigin.Begin);
                            w.Write(DirSigDato[1]);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error de Integridad - Dato referenciado en otra Tabla");
                        return 1;
                    }
                }

                //////Aqui solo modifico el dato si no es clave primaria.
                if (entidadR.Atributos[comboBox1.SelectedIndex].TPC != 3)
                {
                    long dist = 0;
                    foreach (Atributo atr in entidadR.Atributos)
                        if (entidadR.Atributos.IndexOf(atr) < comboBox1.SelectedIndex)
                            dist += atr.Size;
                    using (BinaryWriter w = new BinaryWriter(new FileStream(DirArchivo + "//" + entidadR.Nombre + ".dat", FileMode.Open)))
                    {
                        w.BaseStream.Seek(DirDato[1] + dist, SeekOrigin.Begin);
                        if (entidadR.Atributos[comboBox1.SelectedIndex].Tipo == 'E')
                        {
                            w.Write((int)(groupBox1.Controls[0] as NumericUpDown).Value);
                        }
                        else if (entidadR.Atributos[comboBox1.SelectedIndex].Tipo == 'C')
                        {
                            Operaciones.Escribe(w, (groupBox1.Controls[0] as TextBox).Text, entidadR.Atributos[comboBox1.SelectedIndex].Size);
                        }
                        else if (entidadR.Atributos[comboBox1.SelectedIndex].Tipo == 'D')
                        {
                            w.Write(Convert.ToDouble((groupBox1.Controls[0] as TextBox).Text));
                        }
                    }
                }else
                    MessageBox.Show("No puedes modificar un dato referenciado.");
            }
            else
            {
                MessageBox.Show("Selecciona un atributo");
            }

            return 0;
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                comboBox1.Enabled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {
                groupBox1.Controls.Clear();
                if (entidadR.Atributos[comboBox1.SelectedIndex].Tipo == 'E')
                {
                    NumericUpDown num = new NumericUpDown();
                    num.ThousandsSeparator = true;
                    num.Minimum = int.MinValue;
                    num.Maximum = int.MaxValue;
                    num.Top = 15;
                    num.Width = 150;
                    groupBox1.Controls.Add(num);
                }
                else if(entidadR.Atributos[comboBox1.SelectedIndex].Tipo == 'C')
                {
                    TextBox TextB = new TextBox();
                    TextB.MaxLength = entidadR.Atributos[comboBox1.SelectedIndex].Size;
                    TextB.Top = 15;
                    TextB.Width = 150;
                    groupBox1.Controls.Add(TextB);
                }else if(entidadR.Atributos[comboBox1.SelectedIndex].Tipo == 'D')
                {
                    TextBox TextB = new TextBox();
                    TextB.MaxLength = int.MaxValue;
                    TextB.Top = 15;
                    TextB.Width = 150;
                    groupBox1.Controls.Add(TextB);
                }
            }
        }

    }
}
