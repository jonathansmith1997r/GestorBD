namespace Proyecto_Estructura_de_Archivos
{
    public class Atributo
    {
        private string nombre;
        private long direccion;
        private char tipo;
        private int Tsize;
        private int TClave;
        private long DRINDICES;
        private long DRSiguienteARr;

        public Atributo(string nombre, long direccion, char tipo, int s, int tc, long di, long sa)
        {
            this.nombre = nombre;
            this.direccion = direccion;
            this.tipo = tipo;
            this.Tsize = s;
            this.TClave = tc;
            this.DRINDICES = di;
            this.DRSiguienteARr = sa;
        }

        
        public long SgAtributo { get => DRSiguienteARr; set => DRSiguienteARr = value; }
        public int Size { get => Tsize; set => Tsize = value; }
        public int TPC { get => TClave; set => TClave = value; }
        public long DDI { get => DRINDICES; set => DRINDICES = value; }
        public long Direccion { get => direccion; set => direccion = value; }
        public char Tipo { get => tipo; set => tipo = value; }
        public string Nombre { get => nombre; set => nombre = value; }

    }
}
