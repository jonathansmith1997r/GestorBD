using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace Proyecto_Estructura_de_Archivos
{
    public partial class RegistroA : Form
    {
        Inicio InicioF = null;
        Entidad entidad = null;
        string DirArchivo;
        string DirDiccionario;
        bool CvePrimaria = false;
        bool CveForanea = false;
        List<int> IndiceF;
        int IndiceP = 0;

        /// <summary>
        /// 
        /// Integridad Referencial completada
        /// </summary>
        /// <param name="prim"></param>
        /// <param name="EE"></param>
        /// <param name="dr"></param>
        /// <param name="drdd"></param>
        public RegistroA(Inicio prim, Entidad EE, string dr, string drdd)
        {
            InitializeComponent();
            IndiceF = new List<int>();
            InicioF = prim;
            entidad = EE;
            foreach (Atributo Atr in entidad.Atributos)
            {
                GroupBox GBox = new GroupBox();
                GBox.AutoSize = true;
                GBox.Text = Atr.Nombre;
                Label label = new Label();
                GBox.ForeColor = Color.White;
                if (Atr.TPC == 3)
                {
                    ListBox listBox = new ListBox();
                    listBox.Top = 15;
                    listBox.Width = 150;
                    GBox.Controls.Add(listBox);
                }
                else if (Atr.Tipo == 'E')
                {
                    NumericUpDown numeric = new NumericUpDown();
                    numeric.ThousandsSeparator = true;
                    numeric.Minimum = int.MinValue;
                    numeric.Maximum = int.MaxValue;
                    numeric.Top = 15;
                    numeric.Width = 150;
                    GBox.Controls.Add(numeric);
                }
                else if(Atr.Tipo == 'C')
                {
                    TextBox textBox = new TextBox();
                    textBox.MaxLength = Atr.Size;
                    textBox.Top = 15;
                    textBox.Width = 150;
                    GBox.Controls.Add(textBox);
                }else if(Atr.Tipo == 'D')
                {
                    TextBox textBox = new TextBox();
                    textBox.MaxLength = int.MaxValue;
                    textBox.Top = 15;
                    textBox.Width = 150;
                    GBox.Controls.Add(textBox);
                }

                flowLayoutPanel1.Controls.Add(GBox);
                switch (Atr.TPC)
                {
                    case 1:
                        //CB = true;
                        break;
                    case 2:
                        CvePrimaria = true;
                        IndiceP = entidad.Atributos.IndexOf(Atr);
                        break;
                    case 3:
                        CveForanea = true;
                        IndiceF.Add(entidad.Atributos.IndexOf(Atr));
                        break;
                }
            }
            flowLayoutPanel1.BackColor = Color.Transparent;
            DirArchivo = dr;
            DirDiccionario = drdd;
        }

        /// <summary>
        /// 
        /// Si es una tabla con claves foraneas, verifica que tengan datos las entidades referenciadas.
        /// </summary>
        public void Verifica()
        {
            if (CveForanea)
            {
                foreach (Entidad EntI in InicioF.Entidades)
                {
                    foreach(int atrb in IndiceF)
                    {
                        if (EntI.Direccion == entidad.Atributos[atrb].DDI)
                        {
                            FileInfo fileInfo = new FileInfo(DirArchivo + "//" + EntI.Nombre + ".dat");
                            if (fileInfo.Exists)
                            {
                                if (fileInfo.Length == 0)
                                {
                                    MessageBox.Show("No tiene datos la entidad foranea");
                                    this.Close();
                                }
                                else
                                {

                                    List<string> cve = EntI.ObtClave(DirArchivo, 2,EntI.Atributos[0].Direccion);
                                    try
                                    {

                                        foreach (string c in cve)
                                        {
                                            (flowLayoutPanel1.Controls[atrb].Controls[0] as ListBox).Items.Add(c);
                                        }
                                        (flowLayoutPanel1.Controls[atrb].Controls[0] as ListBox).SelectedIndex = 0;
                                    }
                                    catch (Exception)
                                    {
                                        MessageBox.Show("La entidad foranea no tiene datos");
                                        this.Close();
                                    }
                                }
                            }
                        }
                    }
                    
                }
            }
        }

        /// <summary>
        /// 
        /// Modificar para que agregue los registros en Decimal <--------------
        /// Listo Modificacion 1
        /// </summary>
        /// <returns></returns>
        public int AgregarDatos()
        {
            if (CPRepetida() == 1)
            {
                MessageBox.Show("Clave Repetida");
                return 1;
            }
            long posicion = -1;
            long siguienteP = -1;
            int IndiceDat = 0;
            long DirDato = 0;
            string RT = DirArchivo + "/" + entidad.Nombre + ".dat";

            siguienteP = entidad.PD;
            
            if (CvePrimaria || !RegistroRepetido())
            {
                FileStream info;
                try
                {
                    info = new FileStream(RT, FileMode.OpenOrCreate);

                }
                catch (Exception)
                {
                    MessageBox.Show("intenta de nuevo");
                    return 0;
                }
                if (siguienteP != -1)
                {

                    BinaryReader LeerDatos = new BinaryReader(info);
                    int DistanciaCve = 0;
                    int IndiceAtrb = 0;
                    foreach (Atributo Atr in entidad.Atributos)
                    {
                        if (entidad.Orden == TOrden.Secuencial)
                            if (Atr.TPC == 2 || Atr.TPC == 3)
                                break;
                      
                        DistanciaCve = Atr.Size;
                        IndiceAtrb++;
                    }
                    while (siguienteP != -1)
                    {
                        info.Seek(siguienteP + DistanciaCve, SeekOrigin.Begin);
                        if (entidad.Atributos[IndiceAtrb].Tipo == 'E')
                        {
                            if (entidad.Atributos[IndiceAtrb].TPC == 3)
                            {
                                int DatoAux = LeerDatos.ReadInt32();
                                int DatoActual = Convert.ToInt32((flowLayoutPanel1.Controls[IndiceAtrb].Controls[0] as ListBox).SelectedItem);
                                if (DatoActual < DatoAux)
                                {
                                    break;
                                }
                                else
                                {
                                    posicion = siguienteP;
                                    info.Seek(siguienteP + entidad.SizeD() + 8, SeekOrigin.Begin);
                                    siguienteP = LeerDatos.ReadInt64();
                                    IndiceDat++;
                                }
                            }
                            else
                            {
                                int DatoAux = LeerDatos.ReadInt32();
                                int DatoActual = (int)(flowLayoutPanel1.Controls[IndiceAtrb].Controls[0] as NumericUpDown).Value;
                                if (DatoActual < DatoAux)
                                {
                                    break;
                                }
                                else
                                {
                                    posicion = siguienteP;
                                    info.Seek(siguienteP + entidad.SizeD() + 8, SeekOrigin.Begin);
                                    siguienteP = LeerDatos.ReadInt64();
                                    IndiceDat++;
                                }
                            }

                        }
                        else if (entidad.Atributos[IndiceAtrb].Tipo == 'C')
                        {
                            string DTAux = Operaciones.Lee(LeerDatos, entidad.Atributos[IndiceAtrb].Size);
                            string DTact = (flowLayoutPanel1.Controls[IndiceAtrb].Controls[0] as TextBox).Text.Trim();
                            if (DTact.CompareTo(DTAux) == -1)
                            {
                                break;
                            }
                            else
                            {
                                posicion = siguienteP;
                                info.Seek(siguienteP + entidad.SizeD() + 8, SeekOrigin.Begin);
                                siguienteP = LeerDatos.ReadInt64();
                                IndiceDat++;
                            }
                        }
                        else if (entidad.Atributos[IndiceAtrb].Tipo == 'D')
                        {
                            double DTAux = LeerDatos.ReadDouble();
                            double DTact = Convert.ToDouble((flowLayoutPanel1.Controls[IndiceAtrb].Controls[0] as TextBox).Text);
                            if (DTact < DTAux)
                            {
                                break;
                            }
                            else
                            {
                                posicion = siguienteP;
                                info.Seek(siguienteP + entidad.SizeD() + 8, SeekOrigin.Begin);
                                siguienteP = LeerDatos.ReadInt64();
                                IndiceDat++;
                            }
                        }
                    }

                    LeerDatos.Close();
                }
                info.Close();

                FileStream RDAT = new FileStream(RT, FileMode.Open);
                BinaryWriter EscribirDatos = new BinaryWriter(RDAT);
                DirDato = RDAT.Seek(0, SeekOrigin.End);
                int aux = 0;
                foreach (Control C in flowLayoutPanel1.Controls)
                {
                    if (entidad.Atributos[aux].TPC == 3)
                    {
                        string auxst = (string)(C.Controls[0] as ListBox).SelectedItem;
                        if (entidad.Atributos[aux].Tipo == 'E')
                        {
                            EscribirDatos.Write(Int32.Parse(auxst));
                        }
                        else if (entidad.Atributos[aux].Tipo == 'C')
                        {
                            Operaciones.Escribe(EscribirDatos, auxst, entidad.Atributos[aux].Size);
                        }
                        else if (entidad.Atributos[aux].Tipo == 'D')
                        {
                            EscribirDatos.Write(double.Parse(auxst));
                        }
                    }
                    else
                    if (C.Controls[0].GetType().ToString().Equals("System.Windows.Forms.NumericUpDown"))
                    {
                        NumericUpDown numericUp = (C.Controls[0] as NumericUpDown);
                        EscribirDatos.Write((int)numericUp.Value);
                        numericUp.Value = 0;

                    }
                    else
                    {
                        if (entidad.Atributos[aux].Tipo == 'D')
                        {
                            double dat = Convert.ToDouble((C.Controls[0] as TextBox).Text);
                            EscribirDatos.Write(dat);
                            (C.Controls[0] as TextBox).Text = "";
                        }
                        else
                        {
                            Operaciones.Escribe(EscribirDatos, (C.Controls[0] as TextBox).Text, entidad.Atributos[aux].Size);
                            (C.Controls[0] as TextBox).Text = "";

                        }
                    }
                    aux++;
                }
                EscribirDatos.Write(DirDato);
                EscribirDatos.Write(siguienteP);

                if (IndiceDat == 0)
                {
                    FileStream rdat = new FileStream(DirDiccionario, FileMode.Open);
                    BinaryWriter WDDAT = new BinaryWriter(rdat);
                    rdat.Seek(entidad.Direccion + 46, SeekOrigin.Begin);
                    WDDAT.Write(DirDato);
                    rdat.Close();
                    WDDAT.Close();
                    entidad.PD = DirDato;
                }
                else if (posicion != -1)
                {
                    RDAT.Seek(posicion + entidad.SizeD() + 8, SeekOrigin.Begin);
                    EscribirDatos.Write(DirDato);
                    RDAT.Close();
                    EscribirDatos.Close();
                }
                EscribirDatos.Close();
                RDAT.Close();
                InicioF.Recargar();
                MessageBox.Show("Añadido");
            }
            else {
                MessageBox.Show("Error de redundancia - Registro ya existente");
            }
            return 0;
        }
        private void ButtonAgregar_Click(object sender, EventArgs e)
        {
            int regreso = AgregarDatos();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 
        /// Verifica que si la tabla no tiene una clave primaria que los registros no se repitan.
        /// </summary>
        /// <returns></returns>
        private bool RegistroRepetido()
        {
            bool Norepetido = true;
            if (!CvePrimaria)
            {
                int idx = 0;
                List<List<string>> ListaCveAtributos = new List<List<string>>();
                List<string> CveAtributos = new List<string>();
                
                if (entidad.PD != -1)
                {
                    //MessageBox.Show("Entre");
                    foreach (Atributo atr in entidad.Atributos)
                    {
                        CveAtributos = entidad.ObtClave(DirArchivo, atr.TPC, atr.Direccion);
                        ListaCveAtributos.Add(CveAtributos);
                        //MessageBox.Show("El numero de elementos del atributo son: " + CveAtributos.Count);
                        //CveAtributos.Clear();
                    }
                    int aux = 0;
                    string concatenado = "";
                    foreach (Control C in flowLayoutPanel1.Controls)
                    {
                        if (entidad.Atributos[aux].TPC == 3)
                        {
                            concatenado += (string)(C.Controls[0] as ListBox).SelectedItem;
                        }
                        else
                        if (C.Controls[0].GetType().ToString().Equals("System.Windows.Forms.NumericUpDown"))
                        {
                            NumericUpDown numericUp = (C.Controls[0] as NumericUpDown);
                            int numero = (int)numericUp.Value;
                            concatenado += numero;
                        }
                        else
                        {
                            if (entidad.Atributos[aux].Tipo == 'D')
                            {
                                float dat = Convert.ToSingle((C.Controls[0] as TextBox).Text);
                                concatenado += dat;
                            }
                            else
                            {
                                string cadena = (C.Controls[0] as TextBox).Text;
                                concatenado += cadena; 
                            }
                        }
                        aux++;
                    }
                    //MessageBox.Show(concatenado + "   " + ListaCveAtributos[1].Count);
                    List<string> ConcatenadoCve = new List<string>();
                    for(int i = 0; i < ListaCveAtributos[0].Count; i++)
                    {
                        string auxcve = "";
                        foreach (List<string> ls in ListaCveAtributos)
                        {
                            auxcve += ls[i];
                        }
                        ConcatenadoCve.Add(auxcve);
                        //MessageBox.Show(auxcve + "---->" + concatenado);
                    }
                   if(ConcatenadoCve.Contains(concatenado))
                    {
                        Norepetido = true;
                    }else
                    {
                        Norepetido = false;
                    }

                }
                else
                {
                    Norepetido = false;
                }

            }
            return Norepetido;
        }

        /// <summary>
        /// 
        /// verifica que la clave primaria no este repetida
        /// modificar para el caso de que sea decimal
        /// </summary>
        /// <returns></returns>
        private int CPRepetida()
        {
            int idx = 0;
            foreach (Atributo Atr in entidad.Atributos)
            {
                if (Atr.TPC == 2)
                {
                    break;
                }
                idx++;
            }
            if (idx != entidad.Atributos.Count)
            {
                ////<---------------------------
                if (entidad.Atributos[idx].Tipo == 'E')
                {
                        if (entidad.ObtClave(DirArchivo, 2,entidad.Atributos[0].Direccion).Contains((flowLayoutPanel1.Controls[idx].Controls[0] as NumericUpDown).Value.ToString()))
                        {
                            return 1;
                        }
                }
                else if (entidad.Atributos[idx].Tipo == 'C')
                {
                    foreach (string cad in entidad.ObtClave(DirArchivo, 2,entidad.Atributos[0].Direccion))
                        if (cad.Contains((flowLayoutPanel1.Controls[idx].Controls[0] as TextBox).Text))
                        {
                            return 1;
                        }
                } else if (entidad.Atributos[idx].Tipo == 'D')
                {
                    foreach (string cad in entidad.ObtClave(DirArchivo, 2, entidad.Atributos[0].Direccion))
                        if (cad.Contains((flowLayoutPanel1.Controls[idx].Controls[0] as TextBox).Text))
                        {
                            return 1;
                        }
                }
            }
            return 0;
        }

    }
}
