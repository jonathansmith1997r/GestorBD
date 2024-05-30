using System.IO;

namespace Proyecto_Estructura_de_Archivos
{
    static class Operaciones
    {
        public static string Lee(BinaryReader br, int Size)
        {
            string aux = "";
            for (int i = 0; i < Size; i++)
            {
                aux += br.ReadChar();
            }
            return aux;
        }

        public static void Escribe(BinaryWriter bw, string texto, int Size)
        {
            string TextA = texto.PadRight(Size + 1);
            for (int i = 0; i < Size; i++)
            {
                bw.Write(TextA[i]);
            }
        }
    }
}
