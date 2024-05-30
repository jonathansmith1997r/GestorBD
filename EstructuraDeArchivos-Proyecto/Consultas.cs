
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Proyecto_Estructura_de_Archivos
{
    public partial class Consultas : Form
    {
        private List<Entidad> entidades = new List<Entidad>();
        private List<string> Registros = new List<string>();
        String[] condicionAuxiliarWhere = null;
        private Atributo auxiliarWhere;
        private Inicio FormPrim;
        string AtributoUnionInnerJoin = "";
        private int indexEntidadAtributo;//Indice de la Entidad con la que se trabaja actualmente.
        private int operador = -1; //Funciona como una variable que obtiene un valor dependiendo del operador de la CONDICION
        private bool operadorIzq = false;//Indica si el elemento Izquierdo de la condición es atributo
        private bool operadorDer = false;//Indica si el elemento Derecho de la condición es atributo
        private bool errorConsulta = false;//Bandera que señala que existe un error en la consulta.
        private string opDer = "";//Obtiene el valor del atributo de la condición Derecha.
        private string opIzq = "";//Obtiene el valor del atributo de la condición Derecha.
        public FileStream fs;
        public StreamWriter sw;
        public Consultas(Inicio FormPrincipal)
        {
            InitializeComponent();
            FormPrim = FormPrincipal;
            entidades = FormPrim.Entidades;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string consultaAux = "";
            int indiceAux;
            bool comandosCorrectos = true;
            //VERIFICAR QUE LA CADENA NO ESTE VACIA
            if (textBox1.Text.Length != 0)
            {
                consultaAux = textBox1.Text.ToUpper();

                if (consultaAux.Contains("SELECT") && consultaAux.Contains("FROM"))
                {
                    //VERIFICAR QUE EXISTE SELECT EN LA CONSULTA
                    indiceAux = consultaAux.IndexOf("SELECT");
                    
                    if (consultaAux[indiceAux + 6] != ' ' || indiceAux != 0)//Verifica si contiene la sentencia SELECT
                    {
                        MessageBox.Show("Tu consulta requiere el comando SELECT");
                        comandosCorrectos = false;
                    }
                    else
                    {
                        //VERIFICAR QUE EXISTE FROM
                        indiceAux = consultaAux.IndexOf("FROM");
                        
                        if (consultaAux[indiceAux - 1] != ' ' || consultaAux[indiceAux + 4] != ' ')
                        {
                            MessageBox.Show("Tu consulta requiere el comando FROM");
                            comandosCorrectos = false;
                        }
                        else
                        {
                            //VERIFICAR QUE EXISTE WHERE
                            if (consultaAux.Contains("WHERE") && !consultaAux.Contains("INNER JOIN"))
                            {
                                indiceAux = consultaAux.IndexOf("WHERE");
                                if (consultaAux[indiceAux - 1] != ' ' || consultaAux[indiceAux + 5] != ' ')
                                {
                                    MessageBox.Show(("Tu consulta requiere el comando WHERE"));
                                    comandosCorrectos = false;
                                }
                            }

                            ///Verificacion del INNER JOIN
                            if ((consultaAux.Contains("WHERE") && !consultaAux.Contains("INNER JOIN") && !consultaAux.Contains("ON")) || (!consultaAux.Contains("WHERE") && !consultaAux.Contains("INNER JOIN") && !consultaAux.Contains("ON")))
                                    segundaRevision(consultaAux, 1);
                            else if(consultaAux.Contains("WHERE") && consultaAux.Contains("INNER JOIN") && consultaAux.Contains("ON"))
                            {
                                if (consultaAux.IndexOf("WHERE") < consultaAux.IndexOf("INNER JOIN"))
                                {
                                    MessageBox.Show("Error de Sintanxis - WHERE no puede ir antes que el INNER JOIN.");
                                    Limpia();
                                }
                                else if (consultaAux.IndexOf("WHERE") < consultaAux.IndexOf(" ON "))
                                {
                                    MessageBox.Show("Error de Sintaxis - WHERE no puede ir antes que el ON");
                                    Limpia();
                                }
                                else
                                    segundaRevision(consultaAux, 3);
                            }
                            else if(!consultaAux.Contains("WHERE") && consultaAux.Contains("INNER JOIN") && consultaAux.Contains("ON"))
                            {
                                if (consultaAux.IndexOf(" ON ") < consultaAux.IndexOf("INNER JOIN"))
                                {
                                    //MessageBox.Show(consultaAux.IndexOf(" ON ").ToString(), consultaAux.IndexOf("INNER JOIN").ToString());
                                    MessageBox.Show("Error de Sintanxis - ON no puede ir antes que el INNER JOIN.");
                                    Limpia();
                                }
                                else
                                {
                                    //MessageBox.Show("Entre");
                                    segundaRevision(consultaAux, 2);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Error de Sintaxis - No se encuentra INNER JOIN o ON en la consulta");
                                Limpia();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Error de Sintaxis - No se contiene Select o From");
                    Limpia();
                }
            }
            else
            {
                MessageBox.Show("Consulta incompleta");
                Limpia();
            }
        }
        
        private void Limpia()
        {
            Tabla.TabPages.Clear();
        }
        private void segundaRevision(string consultaAux, int opcion)
        {
            string consultaAux2;
            if (opcion == 1)
            {
                consultaAux2 = consultaAux.Replace(" ", "").Replace("SELECT", "").Replace("FROM", "#").Replace("WHERE", "&");
                String[] elementos = consultaAux2.Split(new char[] { '#', '&' });
                switch (elementos.Length)
                {
                    case 3:
                        //CONSULTA PARA CUANDO SE EMPLEA WHERE
                        if (elementos[0].Length != 0 && elementos[1].Length != 0 && elementos[2].Length != 0)
                            consultaConWhere(elementos[0], elementos[1], elementos[2]);
                        else
                            MessageBox.Show("El comando FROM o WHERE se encuentra en una posición incorrecta");
                        break;

                    case 2:
                        //CONSULTA PARA CUANDO NO SE EMPLEA WHERE 
                        if (elementos[0].Length != 0 && elementos[1].Length != 0)
                            consultaSinWhere(elementos[0], elementos[1]);
                        else
                            MessageBox.Show("El comando FROM se encuentra en una posición incorrecta");
                        break;

                    default:
                        MessageBox.Show("El comando FROM o WHERE se encuentra en una posición incorrecta");
                        break;
                }
            }
            if (opcion == 2)
            {
                consultaAux2 = consultaAux.Replace("SELECT", "").Replace("FROM", "#").Replace("INNER JOIN", "&").Replace(" ON ","@").Replace(" ", "");
                //MessageBox.Show(consultaAux2);
                String[] elementos = consultaAux2.Split(new char[] { '#', '&', '@' });
                switch (elementos.Length)
                {
                    case 4:
                        //CONSULTA PARA CUANDO SE EMPLEA    INNER JOIN - ON
                        if (elementos[0].Length != 0 && elementos[1].Length != 0 && elementos[2].Length != 0 && elementos[3].Length != 0)
                            consultainnerjoin(elementos[0], elementos[1], elementos[2], elementos[3]);
                        else
                            MessageBox.Show("Faltan datos en la consulta");
                        break;

                    default:
                        MessageBox.Show("El comando FROM o WHERE se encuentra en una posición incorrecta");
                        break;
                }
            }

        }

        /// <summary>
        /// 
        /// Verifica que exista el atributo de union en las dos Tablas.
        /// 
        /// Falta verificar si es clave primaria en Entidad y Clave foranea en Entidad Foranes
        /// </summary>
        /// <param name="union"></param>
        /// <param name="entidad"></param>
        /// <param name="entidadForanea"></param>
        /// <param name="IdxEntidad"></param>
        /// <param name="IdxForanea"></param>
        /// <returns></returns>
        private int VerificaUnion(string union, string entidad, string entidadForanea, int IdxEntidad, int IdxForanea)
        {
            int aprobada = 0;
            String[] auxUnion = union.Split('=');
            String[] auxUnion2 = auxUnion[0].Split('.');
            String[] auxUnion3 = auxUnion[1].Split('.');
            int existe = 0;


            //Verifico que los datos sean correctos y que los atributos a comparar existan en las dos entidades.
            if (auxUnion2[0].ToUpper().Equals(entidad.ToUpper()) && auxUnion3[0].ToUpper().Equals(entidadForanea.ToUpper()))
            {
                if (auxUnion2[1].ToUpper().Equals(auxUnion3[1].ToUpper()))
                {
                    foreach(Entidad ent in entidades)
                    {
                        if (ent.Nombre.ToUpper().Equals(entidad.ToUpper()) || ent.Nombre.ToUpper().Equals(entidadForanea.ToUpper()))
                        {
                            foreach (Atributo atr in ent.Atributos)
                            {
                                if (atr.Nombre.ToUpper().Equals(auxUnion3[1].ToUpper()))
                                {
                                    existe++;
                                }
                            }
                        }
                    }
                    
                }
                else
                    aprobada = 2;
            }
            else
                aprobada = 1;

            if (existe == 2)
            {
                AtributoUnionInnerJoin = auxUnion3[1];
                aprobada = 4;
            }
            else
                aprobada = 3;

            return aprobada;
        }

        private void generaRegistrosInnerJoin(List<string> Concatenados, string EntidadOrigen, string EntidadForanea)
        {
            List<List<string>> ListaCveAtributos = new List<List<string>>(); /// Lista de lista donde se almacenaran todos los datos de cada atributo
            List<List<string>> ListaCveAtributosEntidadOrigen = new List<List<string>>();
            List<List<string>> ListaCveAtributosEntidadForanea = new List<List<string>>();
            List<string> CveAtributos = new List<string>(); ///Lista donde se almacenan los datos de un unico atributo.
            List<string> atributosNormales = new List<string>();
            int pocicionAtrOriginal = 0;
            int pocisionAtrForaneo = 0;

            ///Almacena todos los datos en modo clave de cada atributo de la entidad origen
            int aux = 0;
            foreach(Atributo auxtrorigen in entidades[indiceEntidad(EntidadOrigen)].Atributos)
            {
                if(auxtrorigen.Nombre.Equals(AtributoUnionInnerJoin.ToLower()))
                {
                    pocicionAtrOriginal = aux;
                }
                CveAtributos = entidades[indiceEntidad(EntidadOrigen)].ObtClave("#", auxtrorigen.TPC, auxtrorigen.Direccion);
                ListaCveAtributosEntidadOrigen.Add(CveAtributos);
                aux++;
            }
            aux = 0;
            ///Almacena todos los datos en modo clave de cada atributo de la entidad foranea
            foreach (Atributo auxtrorigen in entidades[indiceEntidad(EntidadForanea)].Atributos)
            {
                if (auxtrorigen.Nombre.Equals(AtributoUnionInnerJoin.ToLower()))
                {
                    pocisionAtrForaneo = aux;
                }
                CveAtributos = entidades[indiceEntidad(EntidadForanea)].ObtClave("#", auxtrorigen.TPC, auxtrorigen.Direccion);
                ListaCveAtributosEntidadForanea.Add(CveAtributos);
                aux++;
            }

           
            List<string> ConcatenadoCve = new List<string>();
            List<string> unionF = ListaCveAtributosEntidadForanea[pocisionAtrForaneo];
            List<string> unionO = ListaCveAtributosEntidadOrigen[pocicionAtrOriginal];
            ///Ciclo en el cual se concatena la informacion por filas y se concatena en un solo string
            for (int i = 0; i < unionF.Count; i++)
            {
                string auxcve = "";
                for(int j = 0; j < unionO.Count; j++)
                {
                    if(unionF[i].Equals(unionO[j]))
                    {
                        //MessageBox.Show(unionF[i] + " " + unionO[j]);
                        
                        foreach (string clavesAtributos in Concatenados)
                        {
                            String[] separados = clavesAtributos.Split('.');
                            int indiceE = indiceEntidad(separados[0]);
                            int indiceAlterno = 0;
                            //atributosNormales.Add(separados[1]);
                            foreach (Atributo atr in entidades[indiceE].Atributos)
                            {
                                if (entidades[indiceE].Nombre.ToLower().Equals(EntidadOrigen.ToLower()))
                                {
                                    if (separados[1].ToLower().Equals(atr.Nombre))
                                    {
                                        auxcve += ListaCveAtributosEntidadOrigen[indiceAlterno][j] + ",";
                                    }
                                    indiceAlterno++;
                                }
                                else if(entidades[indiceE].Nombre.ToLower().Equals(EntidadForanea.ToLower()))
                                {
                                    if (separados[1].ToLower().Equals(atr.Nombre))
                                    {
                                        auxcve += ListaCveAtributosEntidadForanea[indiceAlterno][i] + ",";
                                    }
                                    indiceAlterno++;
                                }
                                
                            }
                            //MessageBox.Show(auxcve);
                        }
                    }
                }
                ConcatenadoCve.Add(auxcve);
                //MessageBox.Show(auxcve);
            }
            foreach (string clavesAtributos in Concatenados)
            {
                String[] separados = clavesAtributos.Split('.');
                atributosNormales.Add(separados[1].ToLower());
            }
            Registros = ConcatenadoCve;
            PreparaTabla(atributosNormales);
            ImprimeConsultaSinWhere(Registros, 1, 0);
        }

        private void consultainnerjoin(string atributos, string entidad, string entidadForanea, string Union)
        {
            String[] atributosAux = atributos.Replace(" ", "").Split(','); ///Existe la posibilidad de que se repitan, modificar para que suceda.
            List<string> atributosConcatenados = new List<string>();
           
            List<string> atributosNormales = new List<string>();

            int indiceEnt = indiceEntidad(entidad);
            int indiceEntForanea = indiceEntidad(entidadForanea);

            if (indiceEnt >= 0 && indiceEntForanea >= 0)
            {
                int verificacion = VerificaUnion(Union, entidad, entidadForanea, indiceEnt, indiceEntForanea);
                switch (verificacion)
                {
                    case 1:
                        MessageBox.Show("No existe una de las entidades a comparar");
                        Limpia();
                        break;
                    case 2:
                        MessageBox.Show("El atributo de comparacion no es el mismo");
                        Limpia();
                        break;
                    case 3:
                        MessageBox.Show("El atributo de comparacion no existe en alguna de las tablas.");
                        Limpia();
                        break;
                }
                if (verificacion == 4)
                {
                    ///Por alguna razon almaceno los atributos con y sin tabla por separado ademas de su posicion a la solicitud principal
                    for (int i = 0; i < atributosAux.Length; i++)
                    {
                        if (atributosAux[i].Contains("."))
                        {
                            String[] aux = atributosAux[i].Split('.');
                            atributosConcatenados.Add(atributosAux[i]);
                        }
                        else
                        {
                            atributosConcatenados.Add(entidad+"."+atributosAux[i]);
                        }
                    }
                    int cont = 0;
                    foreach (string clavesAtributos in atributosConcatenados)
                    {
                        String[] separados = clavesAtributos.Split('.');
                        if(indiceEntidad(separados[0])>= 0)
                        {
                            foreach (Atributo aty in entidades[indiceEntidad(separados[0])].Atributos)
                            {
                                if (aty.Nombre.ToLower().Equals(separados[1].ToLower()))
                                {
                                    cont++;
                                }
                            }
                        }
                    }
                    if (cont == atributosConcatenados.Count)
                        generaRegistrosInnerJoin(atributosConcatenados, entidad, entidadForanea);
                    else
                    {
                        MessageBox.Show("Uno de los atributos no existe en las tablas.");
                        Limpia();
                    }
                }
            }
            else
            {
                MessageBox.Show("Error - No existe alguna de las Tablas.");
                Limpia();
            }
        }

        private void consultaConWhere(string atr, string entidad, string condicion)
        { 
            //MessageBox.Show("Consulta con Where");
            String[] atributosAux = atr.Replace(" ", "").Split(',');
            string condicionAux = condicion.Replace(" ", "").Replace(">=", "♦").Replace("<=", "♣").Replace("<>", "♠").Replace("<", "◄").Replace(">", "►").Replace("=", "♥");
            List<string> atributos = new List<string>();
            List<string> atributosEntidad = new List<string>();
            int indiceE = indiceEntidad(entidad);
            if(indiceE >= 0)
            {
                foreach (Atributo atributoaux in entidades[indiceE].Atributos)
                {
                    atributosEntidad.Add(atributoaux.Nombre);
                }

                if (entidades[indiceE].PD == 0 && verificaCondicion(condicionAux) && atributosEntidad.Contains(condicionAuxiliarWhere[0].ToLower()))
                {
                    atributos = AlmacenaAtributos(atributosAux);
                    if (atributosAux.Length == 1 && atributos.Contains("*")) //El caso de que sea solo un atributo y sea igual a *
                    {
                        atributos.Clear();
                        PreparaTabla(atributosEntidad);
                        CargarRegistros(indiceE, atributosEntidad, 2);
                        ImprimeConsultaSinWhere(atributosEntidad, 1, indiceE);
                    }
                    else if (atributosAux.Length != 0 && !atributos.Contains("*"))
                    {
                        ///Imprime solo determinados atributos
                        if (existeAtributo(atributos, indiceE))
                        {
                            PreparaTabla(atributos);
                            atributos.Add(condicionAuxiliarWhere[0].ToLower());
                            CargarRegistros(indiceE, atributos, 2);
                            atributos.Remove(condicionAuxiliarWhere[0].ToLower());
                            ImprimeConsultaSinWhere(atributos, 2, indiceE);
                        }
                    }
                    else
                        MessageBox.Show("Eror Sintaxis -> No es posible solicitar * con otros elementos.");
                    //MessageBox.Show(atributosAux[0], atributosAux.Length.ToString());

                }
                else
                    MessageBox.Show("No existen datos en la tabla.");
            }
            


        }
        

        /// <summary>
        /// 
        /// Agrega a la tabla los encabezados de cada atributo y prepara sus correspondientes columnas.
        /// </summary>
        /// <param name="atributos"></param>
         private void PreparaTabla(List<string> atributos)
         {
                Tabla.TabPages.Clear();
                TabPage NewP = new TabPage("Consulta");
                DataGridView newDG = new DataGridView();
                newDG.AutoSize = true;
                newDG.Dock = DockStyle.Fill;
                newDG.AllowUserToAddRows = false;
                foreach (string atr in atributos)
                {
                    newDG.Columns.Add("texto", atr);
                }
                Tabla.TabPages.Add(NewP);
                NewP.Controls.Add(newDG);
         }


        /// <summary>
        /// 
        /// Funcion que imprime los registros de la consulta
        /// </summary>
        /// <param name="auxAtr"></param> Lista de los atributos que contiene la consulta
        /// <param name="opcion"></param> Determina el caso que se empleara 'Todos atributos', 'Un unico atributo', 'Atributos en desorde'
        /// <param name="indiceEntidad"></param> Indice de la entidad ya que se llama a una funcion que lo necesita
         private void ImprimeConsultaSinWhere(List<string> auxAtr, int opcion, int indiceEntidad)
         {
            if (Tabla.TabPages.Count > 0)
            {

                if (Tabla.SelectedIndex >= 0 && Tabla.SelectedTab.Controls.Count > 0)
                {
                    DataGridView aux = Tabla.SelectedTab.Controls[0] as DataGridView;
                    aux.MultiSelect = false;
                    aux.Rows.Clear();
                    Entidad entAux = entidades[indiceEntidad];
                    int fila = aux.Rows.Add();

                    ///Se inicia el proceso de imprecion en el datagrid de la consulta
                    foreach (string ce in Registros)
                    {
                        String[] atributosAux = ce.Replace(" ", "").Split(',');
                        for(int i = 0; i < atributosAux.Length-1; i++)
                        {
                            aux.Rows[fila].Cells[i].Value = atributosAux[i];
                        }
                        fila = aux.Rows.Add();
                    }

                }
            }
        }
       
        /// <summary>
        /// 
        /// Almacena los registro en modo de una solo cadena por renglon 
        /// </summary>
        /// <param name="indiceE"></param> indice de la entidad
        /// <param name="atributos"></param> lista de atributos a manejar
        private void CargarRegistros(int indiceE, List<string> atributos, int tipo)
        {
            List<List<string>> ListaCveAtributos = new List<List<string>>(); /// Lista de lista donde se almacenaran todos los datos de cada atributo
            List<string> CveAtributos = new List<string>(); ///Lista donde se almacenan los datos de un unico atributo.

            if(tipo == 1)
            {
                ////Ciclo mediante el cual se almacenan los datos por atributo solicitado dentro de una lista.
                foreach (string clavesAtributos in atributos)
                {
                    foreach (Atributo atr in entidades[indiceE].Atributos)
                    {
                        if (clavesAtributos.CompareTo(atr.Nombre) == 0)
                        {
                            CveAtributos = entidades[indiceE].ObtClave("#", atr.TPC, atr.Direccion);
                            ListaCveAtributos.Add(CveAtributos);
                        }
                        //MessageBox.Show("El numero de elementos del atributo son: " + CveAtributos.Count);
                        //CveAtributos.Clear();
                    }
                }
                List<string> ConcatenadoCve = new List<string>();

                ///Ciclo en el cual se concatena la informacion por filas y se concatena en un solo string
                for (int i = 0; i < ListaCveAtributos[0].Count; i++)
                {
                    string auxcve = "";
                    foreach (List<string> ls in ListaCveAtributos)
                    {
                        auxcve += ls[i] + ",";
                    }
                    ConcatenadoCve.Add(auxcve);
                    //MessageBox.Show(auxcve);
                }
                Registros = ConcatenadoCve;
            }else if(tipo == 2)
            {
                char tipodato = 'E';
                ////Ciclo mediante el cual se almacenan los datos por atributo solicitado dentro de una lista.
                foreach (string clavesAtributos in atributos)
                {
                    foreach (Atributo atr in entidades[indiceE].Atributos)
                    {
                        if (clavesAtributos.CompareTo(atr.Nombre) == 0)
                        {
                            if (atr.Nombre.Replace(" ", "").CompareTo(condicionAuxiliarWhere[0].ToLower()) == 0)
                            {
                                tipodato = atr.Tipo;
                                //MessageBox.Show(atr.Nombre);
                            }
                            //MessageBox.Show(atr.Nombre + "   " + condicionAuxiliarWhere[0]);
                            CveAtributos = entidades[indiceE].ObtClave("#", atr.TPC, atr.Direccion);
                            ListaCveAtributos.Add(CveAtributos);
                        }
                        //MessageBox.Show("El numero de elementos del atributo son: " + CveAtributos.Count);
                        //CveAtributos.Clear();
                    }
                }
                List<string> ConcatenadoCve = new List<string>();
                List<string> prueba = new List<string>();
                List<string> prueba2 = new List<string>();
                bool aprobada = true;

                if(ListaCveAtributos.Count == entidades[indiceE].Atributos.Count)
                {
                    int dato = 0;
                    for(int c = 0; c < atributos.Count; c++)
                    {
                        if (atributos[c].CompareTo(condicionAuxiliarWhere[0].ToLower()) == 0)
                        {
                            dato = c;
                        }
                    }
                    ///Ciclo en el cual se concatena la informacion por filas y se concatena en un solo string
                    for (int i = 0; i < ListaCveAtributos[0].Count; i++)
                    {
                        string auxcve = "";
                        for (int j = 0; j < ListaCveAtributos.Count; j++)
                        {
                            prueba = ListaCveAtributos[j];
                            prueba2 = ListaCveAtributos[dato];
                            //MessageBox.Show(prueba2[i] + tipodato);
                            if (Comparacion(tipodato, prueba2[i], condicionAuxiliarWhere[1]))
                            {
                                auxcve += prueba[i] + ",";
                                aprobada = true;
                            }
                            else
                            {
                                auxcve += prueba[i] + ",";
                                aprobada = false;
                            }

                        }
                        if (aprobada)
                        {
                            ConcatenadoCve.Add(auxcve);
                            //MessageBox.Show(auxcve);
                        }

                    }
                }
                else
                {
                    ///Ciclo en el cual se concatena la informacion por filas y se concatena en un solo string
                    for (int i = 0; i < ListaCveAtributos[0].Count; i++)
                    {
                        string auxcve = "";
                        for (int j = 0; j < ListaCveAtributos.Count - 1; j++)
                        {
                            prueba = ListaCveAtributos[j];
                            prueba2 = ListaCveAtributos[ListaCveAtributos.Count - 1];
                            //MessageBox.Show(prueba2[i] + "=" + condicionAuxiliarWhere[1]);
                            if (Comparacion(tipodato, prueba2[i], condicionAuxiliarWhere[1]))
                            {
                                auxcve += prueba[i] + ",";
                                aprobada = true;
                            }
                            else
                            {
                                auxcve += prueba[i] + ",";
                                aprobada = false;
                            }

                        }
                        if (aprobada)
                        {
                            ConcatenadoCve.Add(auxcve);
                            //MessageBox.Show(auxcve);
                        }

                    }
                }
                
                Registros = ConcatenadoCve;
            }
           
        }
       
        /// <summary>
        /// 
        /// Almacena los atributos que se estan solicitando.
        /// </summary>
        /// <param name="aux"></param>
        /// <returns></returns>
        private List<string> AlmacenaAtributos(String[] aux)
        {
            List<string> auxs = new List<string>();
            for(int i = 0; i < aux.Length; i++)
            {
                auxs.Add(aux[i].ToLower());
            }
            return auxs;
        }

        /// <summary>
        /// 
        /// Verifica si los atributos que solicito el usuario existen en la tabla a consultar.
        /// </summary>
        /// <param name="auxAtr"></param>
        /// <returns></returns>
        private bool existeAtributo(List<string> auxAtr, int indiceEntidad)
        {
            bool existe = true;
            List<string> auxAtributos = new List<string>();
            foreach (Atributo atr in entidades[indiceEntidad].Atributos)
            {
                auxAtributos.Add(atr.Nombre);
            }

            foreach (string atrib in auxAtr)
            {
                 if(!auxAtributos.Contains(atrib.ToLower()))
                 {
                    existe = false;
                    MessageBox.Show("Error de Datos -> Atributo: " + atrib + "no existe");
                    Limpia();
                    break;
                 }
            }
            
            return existe;
        }
       
        /// <summary>
        /// 
        /// Realiza la consulta Nornal Select "" From ""
        /// </summary>
        /// <param name="atr"></param>
        /// <param name="entidad"></param>
        private void consultaSinWhere(string atr, string entidad)
        {
            String[] atributosAux = atr.Replace(" ", "").Split(',');
            List<string> atributos = new List<string>();
            //MessageBox.Show("Se ha realizado una consulta sin WHERE");
            //recibe la entidad
            int indiceE = indiceEntidad(entidad);
            if (indiceE >= 0)
            {
                if (entidades[indiceE].PD == 0)
                {
                    atributos = AlmacenaAtributos(atributosAux);
                    if (atributosAux.Length == 1 && atributos.Contains("*")) //El caso de que sea solo un atributo y sea igual a *
                    {
                        ///Imprime todos los atributos
                        atributos.Clear();
                        foreach (Atributo atributoaux in entidades[indiceE].Atributos)
                        {
                            atributos.Add(atributoaux.Nombre);
                        }
                        PreparaTabla(atributos);
                        CargarRegistros(indiceE, atributos, 1);
                        ImprimeConsultaSinWhere(atributos, 1, indiceE);
                    }
                    else if (atributosAux.Length != 0 && !atributos.Contains("*"))
                    {
                        ///Imprime solo determinados atributos
                        if (existeAtributo(atributos, indiceE))
                        {
                            PreparaTabla(atributos);
                            CargarRegistros(indiceE, atributos, 1);
                            ImprimeConsultaSinWhere(atributos, 2, indiceE);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Eror Sintaxis -> No es posible solicitar * con otros elementos.");
                        Limpia();
                    }
                    //MessageBox.Show(atributosAux[0], atributosAux.Length.ToString());
                }
                else
                {
                    MessageBox.Show("No existen datos en la tabla.");
                    Limpia();
                }
                    

            }
            
        }
        private int indiceEntidad(string entidad)
        {
            indexEntidadAtributo = -1;
            for (int i = 0; i < entidades.Count; i++)
            {
                //BUSCA LA ENTIDAD DE LA CONSULTA
                //No me deja llamar el metodo para obtener el nombre
                if (entidades[i].Nombre.ToUpper().CompareTo(entidad.ToUpper()) == 0)
                {
                    indexEntidadAtributo = i;
                }
            }
            if (indexEntidadAtributo == -1)
            {
                MessageBox.Show("No Existe La Tabla " + entidad.ToUpper());
                Limpia();
            }
            else
            {
                //MessageBox.Show("La entidad que buscas es>: " + entidades[indexEntidadAtributo].Nombre + "  " + entidad.ToUpper());
                return indexEntidadAtributo;
            }
                
            /////////////<------- Truena si la tabla no existe 
            
            return indexEntidadAtributo;
        }

        /// <summary>
        /// /
        /// Verifica si la condicional del where es valida
        /// </summary>
        /// <param name="condicion"></param>
        /// <returns></returns>
        private bool verificaCondicion(string condicion)
        {
            operadorDer = false;
            operadorIzq = false;
            bool valida = true;
            condicionAuxiliarWhere = null;

            // = >= <= <> < >
            if (condicion.Contains("♥"))//=
            {
                condicionAuxiliarWhere = condicion.Split('♥');
                //MessageBox.Show("Condición =");
                operador = 1;
            }
            else
            {
                if (condicion.Contains("♦"))//>=
                {
                    condicionAuxiliarWhere = condicion.Split('♦');
                    //MessageBox.Show("Condición >=");
                    operador = 2;
                }
                else
                {
                    if (condicion.Contains("♣"))//<=
                    {
                        condicionAuxiliarWhere = condicion.Split('♣');
                        //MessageBox.Show("Condición <=");
                        operador = 3;
                    }
                    else
                    {
                        if (condicion.Contains("♠"))//<>
                        {
                            condicionAuxiliarWhere = condicion.Split('♠');
                            //MessageBox.Show("Condición <>");
                            operador = 4;
                        }
                        else
                        {
                            if (condicion.Contains("◄"))//<
                            {
                                condicionAuxiliarWhere = condicion.Split('◄');
                                //MessageBox.Show("Condición <");
                                operador = 5;
                            }
                            else
                            {
                                if (condicion.Contains("►"))//>
                                {
                                    condicionAuxiliarWhere = condicion.Split('►');
                                    //MessageBox.Show("Condición >");
                                    operador = 6;
                                }
                                else
                                    valida = false;
                            }
                        }
                    }
                }
            }

            return (valida);
        }

        private bool Comparacion(char tipo, string elementoIzq, string elementoDer)
        {
            //comparativa de datos por tipo INT FLOAT DOUBLE CHAR STRING LONG
            bool respuesta = false;
            string sAuxI = elementoIzq.Replace(" ", "").ToUpper();
            string sAuxD = elementoDer.Replace(" ", "").ToUpper();
            //MessageBox.Show(sAuxI + "/" + sAuxD);
            try
            {
                switch (tipo)
                {
                    case 'E':
                        int intIzq = Convert.ToInt32(elementoIzq);
                        int intDer = Convert.ToInt32(elementoDer);
                        // = >= <= <> < >
                        switch (operador)
                        {
                            case 1:
                                if (intIzq == intDer)
                                    respuesta = true;
                                break;
                            case 2:
                                if (intIzq >= intDer)
                                    respuesta = true;
                                break;
                            case 3:
                                if (intIzq <= intDer)
                                    respuesta = true;
                                break;
                            case 4:
                                if (intIzq != intDer)
                                    respuesta = true;
                                break;
                            case 5:
                                if (intIzq < intDer)
                                    respuesta = true;
                                break;
                            case 6:
                                if (intIzq > intDer)
                                    respuesta = true;
                                break;
                            default:
                                respuesta = false;
                                errorConsulta = true;
                                break;

                        }
                        break;

                    case 'C':
                        // = >= <= <> < >
                        switch (operador)
                        {
                            case 1:
                                if (sAuxI.CompareTo(sAuxD) == 0)
                                    respuesta = true;
                                break;
                            case 4:
                                if (!sAuxI.Equals(sAuxD))
                                    respuesta = true;
                                break;
                            default:
                                respuesta = false;
                                errorConsulta = true;
                                break;
                        }
                        break;

                    case 'D':
                        double floatIzq = Convert.ToDouble(elementoIzq);
                        double floatDer = Convert.ToDouble(elementoDer);
                        // = >= <= <> < >
                        switch (operador)
                        {
                            case 1:
                                if (floatIzq == floatDer)
                                    respuesta = true;
                                break;
                            case 2:
                                if (floatIzq >= floatDer)
                                    respuesta = true;
                                break;
                            case 3:
                                if (floatIzq <= floatDer)
                                    respuesta = true;
                                break;
                            case 4:
                                if (floatIzq != floatDer)
                                    respuesta = true;
                                break;
                            case 5:
                                if (floatIzq < floatDer)
                                    respuesta = true;
                                break;
                            case 6:
                                if (floatIzq > floatDer)
                                    respuesta = true;
                                break;
                            default:
                                respuesta = false;
                                errorConsulta = true;
                                break;

                        }
                        break;

                   
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de tipo de DATO en CONSULTA");
                Limpia();
                errorConsulta = true;
                respuesta = false;
            }
            return (respuesta);
        }

        private void Consultas_Load(object sender, EventArgs e)
        {
            //cargar archivo 
            //cargar entidades
        }
    }
}
