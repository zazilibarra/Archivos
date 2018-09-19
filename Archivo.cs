using System;
using System.Collections.Generic;
using System.IO;
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
        private string sRuta;
        private string sDirectorio;

        //Constructor
        public Archivo(string n, string ruta, string direc)
        {
            sNombre = n;
            DD = new SortedDictionary<Entidad, List<Atributo>>(new ComparaEntidades());
            lCabecera = -1;
            sRuta = ruta;
            direc = sDirectorio;
        }

        public void GuardarCambios(Object elemento)
        {
            using (var stream = new FileStream(sRuta, FileMode.Append, FileAccess.Write, FileShare.None))
            using (var writer = new BinaryWriter(stream))
                if (elemento is long)
                {
                    {
                        writer.Write((long)elemento);
                    }
                }
                else
                {
                    if (elemento is Entidad)
                    {
                        Entidad ent = (Entidad)elemento;
                        writer.Write(ent.Nombre.PadRight(29));
                        writer.Write(ent.Direccion);
                        writer.Write(ent.DireccionAtr);
                        writer.Write(ent.DireccionDatos);
                        writer.Write(ent.DirSigEntidad);
                    }
                    else
                    {
                        Atributo an = (Atributo)elemento;
                        writer.Write(an.Nombre.PadRight(29));
                        writer.Write(an.Direccion);
                        writer.Write(an.TipoDato);
                        writer.Write(an.Longitud);
                        writer.Write(an.TipoIndice);
                        writer.Write(an.DirIndice);
                        writer.Write(an.DirSigAtributo);
                    }
                }
        }

        public void LeerArchivo()
        {
            using (BinaryReader reader = new BinaryReader(new FileStream(sRuta, FileMode.Open)))
            {
                byte[] cabBytes = new byte[8];
                byte[] entBytes = new byte[62];
                long cab;
                long currentDir;
                reader.Read(cabBytes, 0, 8);
                cab = BitConverter.ToInt64(cabBytes, 0);
                currentDir = cab;
                while (currentDir != -1)
                {
                    reader.BaseStream.Seek(currentDir, SeekOrigin.Begin);
                    byte[] entBytesNobre = new byte[29];
                    reader.Read(entBytesNobre, 0, 29);
                    string nombre = BinaryToString(entBytesNobre);
                    
                    byte[] entBytesDirRec = new byte[8];
                    reader.Read(entBytesDirRec, 0, 8);
                    long direc = BitConverter.ToInt64(entBytesDirRec, 0);
                    
                    reader.Read(entBytes, 0, 8);
                    long dirAtr = BitConverter.ToInt64(entBytes, 0);
                    
                    reader.Read(entBytes, 0, 8);
                    long dirRegDat = BitConverter.ToInt64(entBytes, 0);

                    reader.Read(entBytes, 0, 8);
                    long dirSigEnt = BitConverter.ToInt64(entBytes, 0);
                    currentDir = dirSigEnt;


                }
            }
        }

        public long LeerAtributo(long dir)
        {
            using (BinaryReader reader = new BinaryReader(new FileStream(sRuta, FileMode.Open)))
            {
                byte[] atrBytes = new byte[63];
                reader.BaseStream.Seek(dir, SeekOrigin.Begin);

                byte[] entBytesNobre = new byte[29];
                reader.Read(entBytesNobre, 0, 29);
                string nombre = BinaryToString(entBytesNobre);

                byte[] entBytesDirRec = new byte[8];
                reader.Read(entBytesDirRec, 0, 8);
                long direc = BitConverter.ToInt64(entBytesDirRec, 0);

                reader.Read(atrBytes, 0, 8);
                long dirAtr = BitConverter.ToInt64(atrBytes, 0);

                reader.Read(atrBytes, 0, 8);
                long dirRegDat = BitConverter.ToInt64(atrBytes, 0);

                reader.Read(atrBytes, 0, 8);
                long dirSigEnt = BitConverter.ToInt64(atrBytes, 0);
                dir = dirSigEnt;

                return -1;
            }
        }

        public void modificarCabecera()
        {
            using (Stream stream = File.Open(sRuta, FileMode.Open))
            {
                stream.Position = 0;
                stream.Write(BitConverter.GetBytes(this.Cabecera), 0, 8);
            }
        }

        public void modificarEntidad(Entidad ent)
        {
            using (Stream stream = File.Open(sRuta, FileMode.Open))
            {
                stream.Position = ent.Direccion;
                byte[] s = StringToBinary(ent.Nombre.PadRight(29));
                stream.Write(s, 0, 29);
                stream.Write(BitConverter.GetBytes(ent.Direccion), 0, 8);
                stream.Write(BitConverter.GetBytes(ent.DireccionAtr), 0, 8);
                stream.Write(BitConverter.GetBytes(ent.DireccionDatos), 0, 8);
                stream.Write(BitConverter.GetBytes(ent.DirSigEntidad), 0, 8);
            }
        }

        public string BinaryToString(byte[] entBytes)
        {
            return Encoding.ASCII.GetString(entBytes);
        }

        public byte[] StringToBinary(string texto)
        {
            byte[] lb = new byte[29];

            for (int i = 0; i < 29; i++)
            {
                lb[i] = Convert.ToByte(texto[i]);
            }
            return lb;
        }

        public void modificarAtributo(Atributo ant)
        {
            using (Stream stream = File.Open(sRuta, FileMode.Open))
            {
                stream.Position = ant.Direccion;
                stream.Write(Encoding.ASCII.GetBytes(ant.Nombre.PadRight(29)), 0, 29);
                stream.Write(BitConverter.GetBytes(ant.Direccion), 0, 8);
                stream.Write(Encoding.ASCII.GetBytes(ant.TipoDato.ToString()), 0, 1);
                stream.Write(BitConverter.GetBytes(ant.Longitud), 0, 4);
                stream.Write(BitConverter.GetBytes(ant.TipoIndice), 0, 4);
                stream.Write(BitConverter.GetBytes(ant.DirIndice), 0, 8);
                stream.Write(BitConverter.GetBytes(ant.DirSigAtributo), 0, 8);
            }
        }

        //Llena el DD con sus respectivas entidades y atributos cuando se abre un archivo
        public void LlenarDiccionario(Dictionary<Entidad, List<Atributo>> r)
        {
            foreach (Entidad ent in r.Keys)
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

        public string Directorio
        {
            get
            {
                return sDirectorio;
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
