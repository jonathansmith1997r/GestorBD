using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace Proyecto_Estructura_de_Archivos
{
    public enum TOrden
    {
        Secuencial, SecuencialIndexado, Hash
    }
    public class Entidad
    {
        private long direccion;
        private string nombre;
        private long SigEntidad;
        private long PrimerAtrb;
        private long PrimerDat;
        private List<Atributo> atributos;
        private Atributo CvePrimaria;
        private TOrden orden;
        public Indices Indice;


        /// <summary>
        /// Constructor de la entidad
        /// </summary>
        /// <param name="direccion"></param>
        /// <param name="nombre"></param>
        /// <param name="SgE"></param> Direccion de Siguiente entidad
        /// <param name="TOr"></param> Tipo de Orden
        public Entidad(long direccion, string nombre, long SgE, int TOr)
        {
            if (TOr == 1)
                orden = TOrden.Secuencial;
            
            PrimerAtrb = -1;
            PrimerDat = -1;
            this.direccion = direccion;
            if (nombre.Length > 30)
                nombre.Remove(31);
            else
                if (nombre.Length < 30)
                nombre.PadRight(30);
            this.nombre = nombre;

            this.SigEntidad = SgE;
            atributos = new List<Atributo>();
            CvePrimaria = null;
        }

        /// <summary>
        /// 
        /// Obtine el tamaño del dato
        /// </summary>
        /// <returns></returns>
        public int SizeD()
        {
            int s = 0;
            foreach (Atributo atributo in atributos)
            {
                s += atributo.Size;
            }
            return s;
        }

        /// <summary>
        /// 
        /// Obtine el tipo de orden de archivos
        /// </summary>
        public void ObtOrden()
        {
            bool Primaria = false;
            bool Secundaria = false;
            long DirPrimaria = 0;
            foreach (Atributo atributo in atributos)
            {
                switch (atributo.TPC)
                {
                    case 0: break;
                    case 1: break;
                    case 2:
                        Primaria = true;
                        DirPrimaria = atributo.DDI;
                        break;
                    case 3:
                        Secundaria = true;
                        break;
                }
            }
            orden = TOrden.Secuencial;
        }


        /// <summary>
        /// 
        /// Modificar para admitir datos de tipo Decimal
        /// Listo se agrego el dato Decimal
        /// Modificacion2 - Solo almacena las claves del primer atributo que encuentre dependiendo el tipo de clave ques es
        /// En el caso de que no tenga clave primaria la tabla.
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="TipoDeClave"></param>
        /// <returns></returns>
        public List<string> ObtClave(string ruta, int TipoDeClave, long DirAtributo)
        {
            List<string> claves = new List<string>();

            if (File.Exists(Directory.GetCurrentDirectory() + "\\" + Nombre + ".dat"))
            {
                FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "\\" + Nombre + ".dat", FileMode.Open);
                BinaryReader LeerDato = new BinaryReader(fs);
                long SigDato = PD;
                long DirDato = 0;
                int contador = 0;
                while (SigDato != -1)
                {
                    contador = 0;
                    fs.Seek(SigDato, SeekOrigin.Begin);
                    try
                    {

                        foreach (Atributo atributo in Atributos)
                        {
                            if (atributo.Tipo == 'E')
                            {
                                int intAuxiliar = LeerDato.ReadInt32();
                                //MessageBox.Show(intAuxiliar + " " + atributo.Nombre + " " + atributo.TPC);
                                //MessageBox.Show(intAuxiliar + " " + atributo.Nombre + " " + atributo.TPC + " " + DirAtributo);
                                if (atributo.TPC == TipoDeClave && contador < 1 && atributo.Direccion == DirAtributo)
                                {
                                    claves.Add(intAuxiliar.ToString());
                                    //MessageBox.Show(intAuxiliar + " " + atributo.Nombre + " " + atributo.TPC + " " + DirAtributo);
                                    contador++;
                                }
                            }
                            else if (atributo.Tipo == 'C')
                            {
                                string stringAuxiliar = Operaciones.Lee(LeerDato, atributo.Size);
                                if (atributo.TPC == TipoDeClave && atributo.Direccion == DirAtributo)
                                {
                                    claves.Add(stringAuxiliar);
                                }
                                    
                            }
                            else if (atributo.Tipo == 'D')
                            {
                                double intAuxiliar = LeerDato.ReadDouble();
                                if (atributo.TPC == TipoDeClave && atributo.Direccion == DirAtributo)
                                {
                                    claves.Add(intAuxiliar.ToString());
                                }
                            }
                        }

                        DirDato = LeerDato.ReadInt64();
                        SigDato = LeerDato.ReadInt64();
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }
                fs.Close();
                LeerDato.Close();
            }
            return claves;
        }

        
        /// <summary>
        /// 
        /// Retorna las direcciones de los registros en la entidad
        /// </summary>
        /// <param name="binaryReader"></param>
        /// <param name="indice"></param>
        /// <returns></returns>
        public List<long> RegDir(BinaryReader binaryReader, int indice)
        {
            Stream fs = (FileStream)binaryReader.BaseStream;

            List<long> direcciones = new List<long>();
            long DAnt = -1;
            long DSig = -1;
            long DAct = -1;

            DSig = PD;
            for (int i = 0; i <= indice; i++)
            {
                DAnt = DAct;
                DAct = DSig;
                fs.Seek(DSig + SizeD() + 8, SeekOrigin.Begin);
                DSig = binaryReader.ReadInt64();
            }
            direcciones.Add(DAnt);
            direcciones.Add(DAct);
            direcciones.Add(DSig);
            return direcciones;
        }

        public long PrimerAtributo { get => PrimerAtrb; set => PrimerAtrb = value; }
        public Atributo ClavePrimaria { get => CvePrimaria; set => CvePrimaria = value; }
        public long PD { get => PrimerDat; set => PrimerDat = value; }
        public TOrden Orden { get => orden; set => orden = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public List<Atributo> Atributos { get => atributos; set => atributos = value; }
        public long Direccion { get => direccion; set => direccion = value; }
        public long SiguienteEntidad { get => SigEntidad; set => SigEntidad = value; }
       
    }
}
