using System;
using System.Collections.Generic;
using System.Drawing;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Proyecto_Estructura_de_Archivos
{

    public partial class Inicio : Form
    {
        public bool prefix;
        public List<byte> index;
        public string RTA = "";
        public string ArchA = "";
        private bool act = false;
        public long cbr = 0;
        private List<Entidad> entidades;
        public FileStream fs;
        public StreamWriter sw;
        public long DrSS = -1;

        

        public Inicio()
        {
            InitializeComponent();
            prefix = false;
            index = new List<byte>();
            if (!Directory.Exists(Directory.GetCurrentDirectory() + "/Files"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/Files");
            }
            RTA = Directory.GetCurrentDirectory() + "/Files";
            Directory.SetCurrentDirectory(RTA);
            CEC();
            entidades = new List<Entidad>();
            CEAtributos();
        }


        /// <summary>
        /// Modificacion / Base de Datos   ok
        /// Actualiza los atributos de las tablas.
        /// </summary>
        public void RecargaTabla()
        {
            cb.Text = entidades[0].Direccion.ToString();
            Tabla.TabPages.Clear();
            foreach (Entidad ent in entidades)
            {
                TabPage NewP = new TabPage(ent.Nombre);
                DataGridView newDG = new DataGridView();
                newDG.AutoSize = true;
                newDG.Dock = DockStyle.Fill;
                newDG.AllowUserToAddRows = false;
                foreach (Atributo ATR in ent.Atributos)
                {
                    newDG.Columns.Add("texto", ATR.Nombre);
                }
                //Primer cambio para que no aparaesca en los registros 
                //Necesita existir si no marca error.
                newDG.Columns.Add("direccion", ""); 
                newDG.Columns.Add("direccion", "");

                Tabla.TabPages.Add(NewP);
                NewP.Controls.Add(newDG);
            }
        }

        /// <summary>
        /// Modificacion / Base de Datos
        /// Imprime el diccionario de datos que en este caso seria la estructura de la BD
        /// </summary>
        public void ImpDD()
        {
            dataGridView1.Rows.Clear();
            Stream fs = new FileStream(ArchA, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            long SgEnt;
            string nombre;
            long dr;
            long drd;
            long SgAtr;
            long Patr;
            string NomAtr;
            long drAtr;
            char tipo;
            int Size;
            int TI;
            long DrIdx;

            SgEnt = br.ReadInt64();
            int fila = dataGridView1.Rows.Add();
            dataGridView1.Rows[fila].Cells[0].Value = SgEnt;
            dataGridView1.Rows[fila].Cells[0].Style.BackColor = Color.Black;
            while (SgEnt != -1)
            {
                fs.Position = SgEnt;
                nombre = Operaciones.Lee(br, 30);
                dr = br.ReadInt64();
                SgAtr = br.ReadInt64();
                Patr = SgAtr;
                drd = br.ReadInt64();
                SgEnt = br.ReadInt64();
                //---¬ Data Grid View
                fila = dataGridView1.Rows.Add();
                dataGridView1.Rows[fila].Cells[0].Value = nombre;
                dataGridView1.Rows[fila].Cells[1].Value = "";
                dataGridView1.Rows[fila].Cells[2].Value = "";
                dataGridView1.Rows[fila].Cells[3].Value = drd;
                dataGridView1.Rows[fila].Cells[4].Value = "";
                //---
                while (SgAtr != -1)
                {
                    fs.Position = SgAtr;
                    NomAtr = Operaciones.Lee(br, 30);///
                    drAtr = br.ReadInt64();
                    tipo = br.ReadChar();
                    Size = br.ReadInt32();
                    TI = br.ReadInt32();
                    DrIdx = br.ReadInt64();
                    SgAtr = br.ReadInt64();
                    //---¬ Data Grid View
                    fila = dataGridView1.Rows.Add();
                    dataGridView1.Rows[fila].Cells[0].Value = "         "+ NomAtr;
                    dataGridView1.Rows[fila].Cells[1].Value = "";
                    ///Modificacion para que imprima los datos correctos de BD
                    if(tipo == 'E')
                        dataGridView1.Rows[fila].Cells[2].Value = "Entero";
                    else if(tipo == 'C')
                        dataGridView1.Rows[fila].Cells[2].Value = "Cadena";
                    else if(tipo == 'D')
                        dataGridView1.Rows[fila].Cells[2].Value = "Decimal";

                    dataGridView1.Rows[fila].Cells[3].Value = Size;

                    if (TI == 0)
                        dataGridView1.Rows[fila].Cells[4].Value = "Sin Llave";
                    else if (TI == 2)
                        dataGridView1.Rows[fila].Cells[4].Value = "Clave Primaria";
                    else if (TI == 3)
                        dataGridView1.Rows[fila].Cells[4].Value = "Clave Foranea";
                    //////////////////////////////////////////////////////////////
                    if (TI == 3 && DrSS != -1)
                        dataGridView1.Rows[fila].Cells[5].Value = "";
                    else
                        dataGridView1.Rows[fila].Cells[5].Value = "";
                    dataGridView1.Rows[fila].Cells[6].Value = "";
                    //---
                }
            }
            fs.Close();
            br.Close();
            //dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
        }

        /// <summary>
        /// Agrega una nueva entidad
        /// </summary>
        /// <param name="NomEnt"></param>
        /// <param name="TO"></param>
        /// <returns></returns>
        public int AgregarEntidad(string NomEnt, int TO)
        {
            int IdxAux = 0;
            foreach (Entidad Ent in entidades)
            {
                if (Ent.Nombre.CompareTo(NomEnt) == -1)
                {
                    IdxAux = entidades.IndexOf(Ent) + 1;
                }
                if (Ent.Nombre.CompareTo(NomEnt) == 0)
                    return 1;
            }

            FileStream fs = new FileStream(ArchA, FileMode.Open);
            BinaryWriter w = new BinaryWriter(fs);

            w.Seek(0, SeekOrigin.End);
            long dr = fs.Position;
            long drs = -1;
            if (IdxAux != entidades.Count)
            {
                drs = entidades[IdxAux].Direccion;
            }
            if (IdxAux > 0)
            {
                entidades[IdxAux - 1].SiguienteEntidad = dr;
                w.Seek((int)entidades[IdxAux - 1].Direccion + 54, SeekOrigin.Begin);
                w.Write(dr);
            }

            Entidad NewEnt = new Entidad(dr, NomEnt, drs, TO);
            entidades.Insert(IdxAux, NewEnt);
            NewEnt.Orden = (TOrden)TO;

            w.Seek(0, SeekOrigin.End);
            Operaciones.Escribe(w, NomEnt, 30);
            w.Write(dr);
            w.Write((long)-1);
            w.Write((long)-1);
            w.Write(drs);

            w.Seek(0, SeekOrigin.Begin);
            w.Write(entidades[0].Direccion);
            w.Close();
            fs.Close();
            RecargaTabla();
            CEAtributos();
            return 0;
        }

        /// <summary>
        /// Modifica una entidad
        /// </summary>
        /// <param name="SelecEnt"></param>
        /// <param name="NewN"></param>
        /// <returns></returns>
        public int ModificarEntidad(Entidad SelecEnt, string NewN)
        {
            int beforeAux;
            int IdxNEW = 0;

            if (SelecEnt == null)
                return 1;
            foreach (Entidad ent in Entidades)
                if (ent.Nombre.CompareTo(NewN) == 0)
                    return 2;

            if (NewN == "")
                return 3;

            beforeAux = entidades.IndexOf(SelecEnt);
            entidades.RemoveAt(beforeAux);


            foreach (Entidad ent in entidades)
            {
                if (ent.Nombre.CompareTo(NewN) == -1)
                {
                    IdxNEW = entidades.IndexOf(ent) + 1;
                }
            }

            FileStream fs = new FileStream(ArchA, FileMode.Open);
            BinaryWriter w = new BinaryWriter(fs);

            if (beforeAux > 0)
            {
                entidades[beforeAux - 1].SiguienteEntidad = SelecEnt.SiguienteEntidad;
                w.Seek((int)entidades[beforeAux - 1].Direccion + 54, SeekOrigin.Begin);
                w.Write(SelecEnt.SiguienteEntidad);
            }
            else
            {
                w.Seek(0, SeekOrigin.Begin);
                w.Write(SelecEnt.SiguienteEntidad);
            }
            
            SelecEnt.SiguienteEntidad = -1;
            if (IdxNEW != entidades.Count)
            {
                SelecEnt.SiguienteEntidad = entidades[IdxNEW].Direccion;
                w.Seek((int)SelecEnt.Direccion + 54, SeekOrigin.Begin);
                w.Write(entidades[IdxNEW].Direccion);
            }
            else
            {
                w.Seek((int)SelecEnt.Direccion + 54, SeekOrigin.Begin);
                w.Write((long)-1);
            }
            if (IdxNEW > 0)
            {
                entidades[IdxNEW - 1].SiguienteEntidad = SelecEnt.Direccion;
                w.Seek((int)entidades[IdxNEW - 1].Direccion + 54, SeekOrigin.Begin);
                w.Write(SelecEnt.Direccion);
            }
            w.Seek((int)SelecEnt.Direccion, SeekOrigin.Begin);
            Operaciones.Escribe(w, NewN, 30);
            SelecEnt.Nombre = NewN;

            entidades.Insert(IdxNEW, SelecEnt);
            w.Seek(0, SeekOrigin.Begin);
            w.Write(entidades[0].Direccion);
            
            w.Close();
            fs.Close();
            RecargaTabla();
            CEAtributos();
            ImpDD();
            return 0;
        }

        /// <summary>
        /// Elimina una entidad
        /// </summary>
        /// <param name="SelectEnt"></param>
        /// <returns></returns>
        public int EliminarEntidad(Entidad SelectEnt)
        {
            int beforeIdx;

            if (SelectEnt == null)
                return 1;
            if (SelectEnt.PD != -1)
                return 2;

            beforeIdx = entidades.IndexOf(SelectEnt);
            entidades.RemoveAt(beforeIdx);


            FileStream fs = new FileStream(ArchA, FileMode.Open);
            BinaryWriter w = new BinaryWriter(fs);

            if (beforeIdx > 0)
            {
                entidades[beforeIdx - 1].SiguienteEntidad = SelectEnt.SiguienteEntidad;
                w.Seek((int)entidades[beforeIdx - 1].Direccion + 54, SeekOrigin.Begin);
                w.Write(SelectEnt.SiguienteEntidad);
            }
            else
            {
                w.Seek(0, SeekOrigin.Begin);
                w.Write(SelectEnt.SiguienteEntidad);
            }
            w.Close();
            fs.Close();
            RecargaTabla();
            CEAtributos();
            ImpDD();
            return 0;
        }

        /// <summary>
        /// Agrega un nuevo atributo
        /// </summary>
        /// <param name="NAtr"></param>
        /// <param name="EntAtr"></param>
        /// <param name="TP"></param>
        /// <param name="Size"></param>
        /// <param name="TPidx"></param> /// Si es Clave foranea se almacena la direccion aqui
        /// <param name="EntF"></param>
        /// <returns></returns>
        public int AgregarAtributo(string NAtr, Entidad EntAtr, char TP, int Size, int TPidx, Entidad EntF)
        {
            foreach (Atributo Atr in EntAtr.Atributos)
                if (Atr.Nombre.CompareTo(NAtr) == 0)
                    return 1;

            if (TPidx == 3)
            {
                if (EntF == null)
                    return 5;
                else if (EntF.ClavePrimaria == null)
                    return 3;

                else if (EntF.ClavePrimaria.Tipo != TP)
                    return 6;

                else if (EntF.ClavePrimaria.Size != Size)
                    return 4;
            }


            if (TPidx == 2 && EntAtr.ClavePrimaria != null)
                return 2;

            if (EntAtr.PD == 0)
                return 9;


            FileStream fs = new FileStream(ArchA, FileMode.Open);
            BinaryWriter w = new BinaryWriter(fs);

            w.Seek(0, SeekOrigin.End);
            long dr = fs.Position;
            long drIdx = -1;
            Operaciones.Escribe(w, NAtr, 30);
            w.Write(dr);
            w.Write(TP);
            w.Write(Size);
            w.Write(TPidx);
            if (TPidx == 3)
                drIdx = EntF.Direccion;
            else if (TPidx == 2)
                if (EntAtr.Orden == TOrden.Hash)
                    drIdx = 80;

            w.Write(drIdx);
            w.Write((long)-1);

            if (EntAtr.Atributos.Count > 0)
            {
                EntAtr.Atributos.Last().SgAtributo = dr;
                w.Seek((int)EntAtr.Atributos.Last().Direccion + 55, SeekOrigin.Begin);
                w.Write(dr);
            }
            else
            {
                EntAtr.PrimerAtributo = dr;
                w.Seek((int)EntAtr.Direccion + 38, SeekOrigin.Begin);
                w.Write(dr);
            }

            Atributo NewAtr = new Atributo(NAtr, dr, TP, Size, TPidx, drIdx, -1);
            EntAtr.Atributos.Add(NewAtr);
            if (TPidx == 2)
                EntAtr.ClavePrimaria = NewAtr;
            w.Close();
            fs.Close();
            RecargaTabla();
            return 0;
        }

       /// <summary>
       /// Modifica un atributo
       /// </summary>
       /// <param name="SelectEnt"></param>
       /// <param name="SelectAtr"></param>
       /// <param name="NewN"></param>
       /// <param name="NewTP"></param>
       /// <param name="NewSize"></param>
       /// <param name="NewTPIdx"></param>
       /// <param name="NewEntF"></param>
       /// <returns></returns>
        public int ModificarAtributo(Entidad SelectEnt, Atributo SelectAtr, string NewN, char NewTP, int NewSize, int NewTPIdx, Entidad NewEntF)
        {
            if (SelectEnt == null || SelectAtr == null)
                return -1;
            if (NewN.Length <= 1)
                return 1;
            if (NewTPIdx == 3)
            {
                if (NewEntF == null)
                    return 2;
                if (NewEntF.ClavePrimaria == null)
                    return 3;
                if (NewTP != NewEntF.ClavePrimaria.Tipo)
                    return 4;
                if (NewSize != NewEntF.ClavePrimaria.Size)
                    return 5;
            }
            if (SelectEnt.PD == 0)
                return 8;

            foreach (Atributo Atr in SelectEnt.Atributos)
                if (Atr.Nombre.CompareTo(NewN) == 0)
                    return 6;
            if (SelectAtr.TPC == 2 && NewTPIdx != 2)
                SelectEnt.ClavePrimaria = null;
            if (SelectAtr.TPC != 2 && NewTPIdx == 2)
                if (SelectEnt.ClavePrimaria != null)
                    return 7;

            FileStream fs = new FileStream(ArchA, FileMode.Open);
            BinaryWriter w = new BinaryWriter(fs);

            w.Seek((int)SelectAtr.Direccion, SeekOrigin.Begin);
            long dr = fs.Position;
            long dridx = -1;
            Operaciones.Escribe(w, NewN, 30);
            w.Write(SelectAtr.Direccion);
            w.Write(NewTP);
            w.Write(NewSize);
            w.Write(NewTPIdx);
            if (NewTPIdx == 3)
            {
                dridx = NewEntF.Direccion;
                w.Write(NewEntF.Direccion);
            }
            else
                w.Write((long)-1);

            SelectAtr.Nombre = NewN;
            SelectAtr.Size = NewSize;
            SelectAtr.Tipo = NewTP;
            SelectAtr.TPC = NewTPIdx;
            if (SelectAtr.TPC == 3)
                SelectAtr.DDI = NewEntF.Direccion;
            else
                SelectAtr.DDI = -1;
            w.Close();
            fs.Close();
            RecargaTabla();
            ImpDD();
            return 0;

        }
        
        /// <summary>
        /// Elimina un atributo
        /// </summary>
        /// <param name="SelectEnt"></param>
        /// <param name="SelectAtr"></param>
        /// <returns></returns>
        public int EliminarAtributo(Entidad SelectEnt, Atributo SelectAtr)
        {
            if (SelectEnt == null)
                return 1;
            if (SelectAtr == null)
                return 2;
            if (SelectEnt.PD == 0)
                return  4;

            int IdxAux = SelectEnt.Atributos.IndexOf(SelectAtr);

            FileStream fs = new FileStream(ArchA, FileMode.Open);
            BinaryWriter w = new BinaryWriter(fs);

            if (IdxAux > 0)
            {
                SelectEnt.Atributos[IdxAux - 1].SgAtributo = SelectAtr.SgAtributo;
                w.Seek((int)SelectEnt.Atributos[IdxAux - 1].Direccion + 55, SeekOrigin.Begin);
                w.Write(SelectAtr.SgAtributo);
            }
            else
            {
                SelectEnt.PrimerAtributo = SelectAtr.SgAtributo;
                w.Seek((int)SelectEnt.Direccion + 38, SeekOrigin.Begin);
                w.Write(SelectAtr.SgAtributo);
            }

            SelectEnt.Atributos.RemoveAt(IdxAux);
            w.Close();
            fs.Close();
            RecargaTabla();
            ImpDD();

            return 0;
        }
        
        /// <summary>
        /// Lee la informacion de un archivo
        /// </summary>
        /// <returns></returns>
        public int Lectura()
        {
            FileStream fs = new FileStream(ArchA, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            long SgEnt;
            string Name;
            long dr;
            long drD;
            long SgAtr;
            long Patr;
            string NameAtr;
            long drAtr;
            char Tp;
            int Size;
            int TI;
            long DrIdx;

            SgEnt = br.ReadInt64();
            while (SgEnt != -1)
            {
                fs.Position = SgEnt;
                Name = Operaciones.Lee(br, 30);
                foreach (char CHE in Path.GetInvalidPathChars())
                {
                    if (Name.Contains(CHE))
                    {
                        int idxNn = Name.IndexOf(CHE);
                        Name = Name.Remove(idxNn, 1);
                    }

                }
                dr = br.ReadInt64();
                SgAtr = br.ReadInt64();
                Patr = SgAtr;
                drD = br.ReadInt64();
                SgEnt = br.ReadInt64();
                Entidad Entt = new Entidad(dr, Name.Trim(), SgEnt, 1);
                Entt.PrimerAtributo = Patr;
                Entt.PD = drD;
                entidades.Add(Entt);
                while (SgAtr != -1)
                {
                    fs.Position = SgAtr;
                    NameAtr = Operaciones.Lee(br, 30);
                    drAtr = br.ReadInt64();
                    Tp = br.ReadChar();
                    Size = br.ReadInt32();
                    TI = br.ReadInt32();
                    DrIdx = br.ReadInt64();
                    SgAtr = br.ReadInt64();
                    Atributo Atrr = new Atributo(NameAtr.Trim(), drAtr, Tp, Size, TI, DrIdx, SgAtr);
                    foreach (Entidad entt in entidades)
                    {
                        if (entt.PrimerAtributo == drAtr)
                        {
                            entt.Atributos.Add(Atrr);
                            if (TI == 2) entt.ClavePrimaria = Atrr;
                        }
                        else
                            if (entt.Atributos.Count > 0 && entt.Atributos.Last().SgAtributo == drAtr)
                        {
                            entt.Atributos.Add(Atrr);
                            if (TI == 2) entt.ClavePrimaria = Atrr;
                        }
                    }
                }
                Entt.ObtOrden();
            }
            fs.Close();
            br.Close();
            cb.Text = entidades[0].Direccion.ToString();
            RecargaTabla();
            CEAtributos();
            return 1;
        }

        /// <summary>
        /// 
        /// Crea un nuevo diccionario que en este caso seria una nueva BD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dg = new SaveFileDialog();
            dg.InitialDirectory = Directory.GetCurrentDirectory();
            dg.Filter = "data dictionary files (*.dd)|*.dd";
            dg.DefaultExt = "dd";
            dg.AddExtension = true;
            if (dg.ShowDialog() == DialogResult.OK)
            {
                ArchA = dg.FileName;
                act = true;
                FileStream fs = new FileStream(dg.FileName, FileMode.Create);
                BinaryWriter bw = new BinaryWriter(fs);
                long cb = -1;
                bw.Write(cb);
                fs.Close();
                bw.Close();
                ImpDD();
            }
            CEC();
            cb.Text = "-1";
        }

        /// <summary>
        /// Activa o desactiva controladores de estado
        /// </summary>
        private void CEC()
        {
            if (act)
            {
                Menu_Entidad.Enabled = true;
                Menu_Atributos.Enabled = true;
                Tabla.Enabled = true;
                nuevoToolStripMenuItem.Enabled = false;
                abrirToolStripMenuItem.Enabled = false;
                MenuAyuda.Enabled = true;
                this.Text = this.Text + " - " + Path.GetFileNameWithoutExtension(ArchA);
            }
            else
            {
                Menu_Entidad.Enabled = false;
                Menu_Atributos.Enabled = false;
                Tabla.Enabled = false;
                nuevoToolStripMenuItem.Enabled = true;
                abrirToolStripMenuItem.Enabled = true;
                MenuAyuda.Enabled = false;
                this.Text = "Diccionario de Datos";
            }
        }

        /// <summary>
        /// Activa o desactiva controladores de estado de atributos
        /// </summary>
        private void CEAtributos()
        {
            if (entidades.Count > 0)
                agregaatributoToolStripMenuItem.Enabled = true;
            else
                agregaatributoToolStripMenuItem.Enabled = false;
        }

        /// <summary>
        /// 
        /// Abre un diccionario de datos existente o en este caso una BD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AbrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dg = new OpenFileDialog();
            dg.InitialDirectory = Directory.GetCurrentDirectory();
            dg.Filter = "data dictionary files (*.dd)|*.dd";
            if (dg.ShowDialog() == DialogResult.OK)
            {
                ArchA = dg.FileName;
                act = true;
                Lectura();
                ImpDD();
                Recargar();
            }
            CEC();
        }

        /// <summary>
        /// 
        /// Cierra el diccionario actual o en este caso la BD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tabla.TabPages.Clear();
            entidades.Clear();
            act = false;
            ArchA = "";
            RTA = "";
            CEC();
            dataGridView1.Rows.Clear();
            cb.Text = "-1";
        }

        /// <summary>
        /// Actualiza los datos de los registros.
        /// </summary>
        public void Recargar()
        {
            if (Tabla.TabPages.Count > 0)
            {
                if (Tabla.SelectedIndex >= 0 && Tabla.SelectedTab.Controls.Count > 0)
                {
                    DataGridView aux = Tabla.SelectedTab.Controls[0] as DataGridView;
                    aux.MultiSelect = false;
                    aux.Rows.Clear();
                    Entidad entAux = entidades[Tabla.SelectedIndex];
                    DataGridViewRow lastFila = null;
                    if (File.Exists(Directory.GetCurrentDirectory() + "\\" + entAux.Nombre + ".dat"))
                    {
                        FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "\\" + entAux.Nombre + ".dat", FileMode.Open);
                        BinaryReader br = new BinaryReader(fs);
                        long SgD = entAux.PD;
                        long DrD = 0;
                        while (SgD != -1)
                        {
                            fs.Seek(SgD, SeekOrigin.Begin);
                            aux.Rows.Add();
                            lastFila = aux.Rows[aux.Rows.Count - 1];
                            lastFila.ReadOnly = true;
                            int j = 0;
                            try
                            {

                                foreach (Atributo atr in entAux.Atributos)
                                {
                                    if (atr.Tipo == 'E')
                                    {
                                        int entAuxiliar = br.ReadInt32();
                                        lastFila.Cells[j].Value = entAuxiliar;
                                    }
                                    else if (atr.Tipo == 'C')
                                    {
                                        string TextAux = Operaciones.Lee(br, atr.Size);
                                        lastFila.Cells[j].Value = TextAux;
                                    }
                                    else if (atr.Tipo == 'D')
                                    {
                                        double entAuxiliar = br.ReadDouble();
                                        lastFila.Cells[j].Value = entAuxiliar;
                                    }
                                    j++;
                                }

                                DrD = br.ReadInt64();
                                SgD = br.ReadInt64();
                                lastFila.Cells[j++].Value = "";
                                lastFila.Cells[j].Value = "";
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Error de datos: Se agrego un atributo a una entidad con datos");
                                break;
                            }
                        }
                        fs.Close();
                        br.Close();

                    }
                    else
                    {
                        FileStream fs = new FileStream(entAux.Nombre + ".dat", FileMode.Create);
                        BinaryWriter bw = new BinaryWriter(fs);
                        fs.Close();
                        bw.Close();
                    }
                }
            }
            ImpDD();
        }


        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// 
        /// Abre el formulario para solicitar los datos de una nueva entidad /// Tabla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void agregaentidadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EntidadA NewEnt = new EntidadA(this);
            NewEnt.ShowDialog();
            ImpDD();
        }

        /// <summary>
        /// 
        /// Abre el formulario para modificar los datos de una entidad /// Tabla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modificaentidadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EntidadM ModEnt = new EntidadM(this);
            ModEnt.Show();
        }

        /// <summary>
        /// 
        /// Abre el formulario para solicitar los datos de la entidad a eliminar. /// Tabla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void eliminaentidadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EntidadE DeletEnt = new EntidadE(this);
            DeletEnt.Show();
        }

        /// <summary>
        /// 
        /// Abre le formulario para solicitar los datos del atributo a agregar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void agregaatributoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AtributoA AddAtr = new AtributoA(this);
            AddAtr.ShowDialog();
            ImpDD();
        }

        /// <summary>
        /// 
        /// Abre le formulario para solicitar los datos del atributo a modificar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modificaatributoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AtributoM ModAtr = new AtributoM(this);
            ModAtr.Show();
        }

        /// <summary>
        /// 
        /// Abre le formulario para solicitar los datos del atributo a eliminar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void eliminaatributoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AtributoE DeleteAtr = new AtributoE(this);
            DeleteAtr.Show();
        }

        /// <summary>
        /// 
        /// Abre le formulario para solicitar los datos del registro a agregar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Tabla.TabPages.Count > 0)
            {
                if (Tabla.SelectedIndex >= 0 && Tabla.SelectedTab.Controls.Count > 0)
                {
                    RegistroA AddReg = new RegistroA(this, entidades[Tabla.SelectedIndex], RTA, ArchA);
                    AddReg.Show();
                    AddReg.Verifica();
                    Recargar();
                }
            }
        }

        /// <summary>
        /// 
        /// Abre le formulario para solicitar los datos del registro a modificar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Tabla.TabPages.Count > 0)
            {
                if (Tabla.SelectedIndex >= 0 && Tabla.SelectedTab.Controls.Count > 0)
                {
                    RegistroM ModReg = new RegistroM(this, entidades[Tabla.SelectedIndex], RTA, ArchA);
                    ModReg.ShowDialog();
                    Recargar();
                    ImpDD();
                }
            }
        }

        /// <summary>
        /// 
        /// Abre le formulario para solicitar los datos del registro a eliminar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Tabla.TabPages.Count > 0)
            {
                if (Tabla.SelectedIndex >= 0 && Tabla.SelectedTab.Controls.Count > 0)
                {
                    RegistroE DeleteReg = new RegistroE(this, entidades[Tabla.SelectedIndex], RTA, ArchA);
                    try
                    {
                        DeleteReg.ShowDialog();

                    }
                    catch (Exception en)
                    {
                        MessageBox.Show(en.Message);
                    }
                    Recargar();
                }
            }
        }

       

        /// <summary>
        /// 
        /// Recarga los datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void actualizaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Recargar();
        }

        internal List<Entidad> Entidades { get => entidades; set => entidades = value; }

        /// <summary>
        /// 
        /// Elimina totalmente la BD. Tanto Diccionario como archivos .Dat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void eliminaBDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dg = new OpenFileDialog();
            dg.InitialDirectory = Directory.GetCurrentDirectory();
            dg.Filter = "data dictionary files (*.dd)|*.dd";
            if (dg.ShowDialog() == DialogResult.OK)
            {
                File.Delete(dg.FileName);
            }
            foreach (var f in entidades)
            {
                File.Delete(f.Nombre + ".dat");
            }
            Tabla.TabPages.Clear();
            entidades.Clear();
            act = false;
            ArchA = "";
            RTA = "";
            CEC();
            dataGridView1.Rows.Clear();
            cb.Text = "";
        }

        private void consultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consultas consulta = new Consultas(this);
            consulta.Show();
        }
    }
}
