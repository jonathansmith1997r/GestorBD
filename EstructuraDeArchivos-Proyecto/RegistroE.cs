using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Proyecto_Estructura_de_Archivos
{
    public partial class RegistroE : Form
    {
        Inicio InicioF = null;
        Entidad entidadA = null;
        string DirArch;
        string DirDiccionario;
        List<string> auxclave;

        public RegistroE(Inicio Prim, Entidad EntE, string dr, string drDD)
        {
            InitializeComponent();
            auxclave = new List<string>();
            InicioF = Prim;
            entidadA = EntE;
            DirArch = dr;
            DirDiccionario = drDD;
            ///Posible problema en la funcion ObtClave
            int tipoclave = VerificarTipoReg();
            auxclave = entidadA.ObtClave(dr, tipoclave, entidadA.Atributos[0].Direccion);
            if (entidadA.Orden == TOrden.Secuencial)
                foreach (string c in auxclave)
                {
                    listBox1.Items.Add(c);
                }
            
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("No existen datos");
                this.Close();
            }
        }



        /// <summary>
        /// 
        /// Verifica si el registro a Elimnar tiene un atributo de tipo clave primaria
        /// Si no cuenta con clave primaria, manda el tipo de clave del primer atributo.
        /// </summary>
        /// <returns></returns>
        private int VerificarTipoReg()
        {
            bool TieneClavePrimaria = false;
           foreach(Atributo atrb in entidadA.Atributos)
            {
                if(atrb.TPC == 2)
                {
                    TieneClavePrimaria = true;
                    break;
                }
            }
            if (!TieneClavePrimaria)
            {
                return entidadA.Atributos[0].TPC;
            }
            else
                return 2;
        }
        
        /// <summary>
        /// 
        /// Elimina el registro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ///
        private void button1_Click(object sender, EventArgs e)
        {
            int Indice = listBox1.SelectedIndex;
            if (Indice >= 0 && Indice < listBox1.Items.Count)
            {
                if (IntegridadModAtributo(Indice))
                {
                    FileStream FR = new FileStream(DirArch + "//" + entidadA.Nombre + ".dat", FileMode.Open);
                    BinaryReader BR = new BinaryReader(FR);
                    long DirDato = -1;
                    long DirDatoAnterior = -1;
                    long DirSigDato = -1;

                    DirSigDato = entidadA.PD;
                    for (int i = 0; i <= Indice; i++)
                    {
                        DirDatoAnterior = DirDato;
                        DirDato = DirSigDato;
                        FR.Seek(DirSigDato + entidadA.SizeD() + 8, SeekOrigin.Begin);
                        DirSigDato = BR.ReadInt64();
                    }
                    BR.Close();
                    FR.Close();


                    if (Indice == 0)
                    {
                        FileStream sd = new FileStream(DirDiccionario, FileMode.Open);
                        BinaryWriter wd = new BinaryWriter(sd);
                        sd.Seek(entidadA.Direccion + 46, SeekOrigin.Begin);
                        wd.Write(DirSigDato);
                        sd.Close();
                        wd.Close();
                        entidadA.PD = DirSigDato;
                    }
                    else
                    {
                        FileStream sd = new FileStream(DirArch + "//" + entidadA.Nombre + ".dat", FileMode.Open);
                        BinaryWriter wd = new BinaryWriter(sd);
                        sd.Seek(DirDatoAnterior + entidadA.SizeD() + 8, SeekOrigin.Begin);
                        wd.Write(DirSigDato);
                        wd.Close();
                        sd.Close();
                    }
                    FileStream sda = new FileStream(DirArch + "//" + entidadA.Nombre + ".dat", FileMode.Open);
                    BinaryWriter wda = new BinaryWriter(sda);
                    sda.Seek(DirDato + entidadA.SizeD(), SeekOrigin.Begin);
                    wda.Write((long)-1);
                    wda.Close();
                    sda.Close();
                    InicioF.Recargar();
                    MessageBox.Show("Eliminado");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error de Integridad el Registro a eliminar existe en otra tabla");
                    this.Close();
                }
                    
                
            }
            else
            {
                MessageBox.Show("Selecciona un dato");
            }
        }


        /// <summary>
        /// 
        /// Verifica que el registro a eliminar no exista en otra tabla
        /// </summary>
        /// <param name="indice"></param>
        /// <returns></returns>
        private bool IntegridadModAtributo(int indice)
        {
            bool Integridad = true;

            List<List<string>> ClavesForaneasE = new List<List<string>>();
            List<string> auxCve = new List<string>();
            string DirDat ="";

            foreach (Entidad enti in InicioF.Entidades)
            {
                foreach (Atributo atrb in enti.Atributos)
                {
                    if (atrb.TPC == 3)
                    {
                        if (entidadA.Direccion == atrb.DDI)
                        {

                            DirDat = DirArch + "//" + enti.Nombre + ".dat";
                            auxCve = enti.ObtClave(DirDat, 3,atrb.Direccion);
                            ClavesForaneasE.Add(auxCve);
                        }
                        
                    }
                }
            }
            
                foreach (List<string> op in ClavesForaneasE)
                {
                    foreach(string ui in op)
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
    }

}
