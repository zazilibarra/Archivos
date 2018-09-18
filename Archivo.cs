using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Archivo
    {
        private string sNombre;
        private SortedDictionary<Entidad, List<Atributo>> DD;
        private long lCabecera;

        //Constructor
        public Archivo(string n)
        {
            sNombre = n;
            DD = new SortedDictionary<Entidad, List<Atributo>>(new ComparaEntidades());
            lCabecera = -1;
        }

        //Guarda los cambios realizados en el archivo
        public void Save()
        {
            //Auciliar para convertir de SortedDictionary a Dictionary
            Dictionary<Entidad, List<Atributo>> tempDD = DD.ToDictionary(x => x.Key, x => x.Value);
            //Formato de Serializacion/Deserializacion
            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            var fi = new System.IO.FileInfo(@sNombre + ".dd");
            //Crea el archivo
            using (var binaryFile = fi.Create())
            {
                //Serializa el diccionario con el formato binario
                binaryFormatter.Serialize(binaryFile, tempDD);
                binaryFile.Flush();
            }
        }

        //Abre el archivo deseado
        public void Load()
        {
            //Auxiliar
            Dictionary<Entidad, List<Atributo>> readBack;
            //Formato de Serializacion/Deserializacion
            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            var fi = new System.IO.FileInfo(@"jhgfdsa.dd");
            //Abre el archivo
            using (var binaryFile = fi.OpenRead())
            {
                //Deserializa el archivo binario y la informacion llega a un Diccionario auxiliar
                readBack = (Dictionary<Entidad, List<Atributo>>)binaryFormatter.Deserialize(binaryFile);
            }
            //Llenba el DD para estarse trabajando en el programa
            LlenarDiccionario(readBack);
        }

        //Llena el DD con sus respectivas entidades y atributos cuando se abre un archivo
        public void LlenarDiccionario(Dictionary<Entidad, List<Atributo>> r)
        {
            foreach(Entidad ent in r.Keys)
            {
                //Por cada entidad añade una llave con su respectiva valor (Atributos)
                DD.Add(ent, r[ent]);
            }
        }

        //Buscar una entidad por Nombre en el DD
        public Entidad BuscarEntidad(string n)
        {
            //Recorre todas las entidades hasta encontrar la que coincide con el nombre que llega
            foreach (Entidad e in DiccDatos.Keys)
            {
                if (e.Nombre == n)
                {
                    //Cuando la encuentra, directamente la retorna
                    return e;
                }
            }
            //Single no la encuenta regresa null
            return null;
        }


        //Clase que se usa al crear el DD para ordenar alfabeticamente las entidades
        public class ComparaEntidades : IComparer<Entidad>
        {
            public int Compare(Entidad x, Entidad y)
            {
                return x.Nombre.CompareTo(y.Nombre);
            }
        }

        #region METODOS DE ACCESO
        public SortedDictionary<Entidad, List<Atributo>> DiccDatos
        {
            get
            {
                return DD;
            }
        }

        public long Cabecera
        {
            get
            {
                return lCabecera;
            }
            set
            {
                lCabecera = value;
            }
        }
        #endregion
    }
}
