using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Proyecto_Estructura_de_Archivos
{
    public class Indices
    {
        public struct Primaria
        {
            public long dir;
            public string v;
        }

        public struct Foranea
        {
            public string Val;
            public long Dir;
        }
        private List<Primaria> prim;
        private List<Foranea> FT;
        private List<List<long>> DIR;
        private string direccion = "";
        private Entidad entidad;
        private long DIRFT = 0;

        public Indices(Entidad entidad)
        {
            DIR = new List<List<long>>();
            FT = new List<Foranea>();
            prim = new List<Primaria>();
            this.entidad = entidad;
        }

       
        
       

       
    }
}
