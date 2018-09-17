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

        public Archivo(string n)
        {
            sNombre = n;
            DD = new SortedDictionary<Entidad, List<Atributo>>(new ComparaEntidades());
            lCabecera = -1;
        }

        public void Save()
        {
            Dictionary<Entidad, List<Atributo>> tempDD = DD.ToDictionary(x => x.Key, x => x.Value);
            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            var fi = new System.IO.FileInfo(@sNombre + ".dd");
            using (var binaryFile = fi.Create())
            {
                binaryFormatter.Serialize(binaryFile, tempDD);
                binaryFile.Flush();
            }
        }

        public void Load()
        {
            Dictionary<Entidad, List<Atributo>> readBack;
            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            var fi = new System.IO.FileInfo(@"jhgfdsa.dd");
            using (var binaryFile = fi.OpenRead())
            {
                readBack = (Dictionary<Entidad, List<Atributo>>)binaryFormatter.Deserialize(binaryFile);
            }
            LlenarDiccionario(readBack);
        }

        public void LlenarDiccionario(Dictionary<Entidad, List<Atributo>> r)
        {
            foreach(Entidad ent in r.Keys)
            {
                DD.Add(ent, r[ent]);
            }
        }

        public class ComparaEntidades : IComparer<Entidad>
        {
            public int Compare(Entidad x, Entidad y)
            {
                return x.Nombre.CompareTo(y.Nombre);
            }
        }

        public Entidad BuscarEntidad(string n)
        {
            foreach (Entidad e in DiccDatos.Keys)
            {
                if (e.Nombre == n)
                {
                    return e;
                }
            }

            return null;
        }

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
    }
}
