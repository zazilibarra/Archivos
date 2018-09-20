﻿using System;
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
        public long actualSize;

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
            {
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
                        writer.Close();
                        stream.Close();
                        modificarEntidad(ent);
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
                        writer.Close();
                        stream.Close();
                        modificarAtributo(an);
                    }
                }
                writer.Close();
                stream.Close();
            }
        }

        public void EliminarEntidad(Entidad enti)
        {
            DiccDatos.Remove(enti);
        }

        public void LeerArchivo()
        {
            List<Entidad> entidades = new List<Entidad>();
            actualSize = new System.IO.FileInfo(sRuta).Length;
            using (BinaryReader reader = new BinaryReader(new FileStream(sRuta, FileMode.Open)))
            {
                byte[] cabBytes = new byte[8];
                long cab;
                long currentDir;
                reader.Read(cabBytes, 0, 8);
                cab = BitConverter.ToInt64(cabBytes, 0);
                this.Cabecera = cab;
                currentDir = cab;
                while (currentDir >= 0)
                {
                    byte[] entBytes = new byte[62];
                    reader.BaseStream.Seek(currentDir, SeekOrigin.Begin);
                    reader.Read(entBytes, 0, 62);

                    byte[] entBytesNobre = new byte[29];
                    entBytesNobre = entBytes.Take(29).ToArray();
                    string nombre = BinaryToString(entBytesNobre);

                    byte[] entBytesDirRec = new byte[8];
                    entBytesDirRec= entBytes.Skip(29).Take(8).ToArray();
                    long direc = BitConverter.ToInt64(entBytesDirRec, 0);

                    byte[] entBytesDirAtr = new byte[8];
                    entBytesDirAtr = entBytes.Skip(37).Take(8).ToArray();
                    long dirAtr = BitConverter.ToInt64(entBytesDirAtr, 0);

                    byte[] entBytesDirDat = new byte[8];
                    entBytesDirDat = entBytes.Skip(45).Take(8).ToArray();
                    long dirRegDat = BitConverter.ToInt64(entBytesDirDat, 0);

                    byte[] entBytesDirSig = new byte[8];
                    entBytesDirSig = entBytes.Skip(53).Take(8).ToArray();
                    long dirSigEnt = BitConverter.ToInt64(entBytesDirSig, 0);
                    currentDir = dirSigEnt;

                    Entidad Ent = new Entidad(nombre, direc, dirAtr, dirRegDat, dirSigEnt);
                    entidades.Add(Ent);
                }
                reader.Close();
            }
            foreach (Entidad e in entidades)
            {
                long dirAux = e.DireccionAtr;
                List<Atributo> agregar = new List<Atributo>();
                while (dirAux >= 0)
                {
                    Atributo auxiliar = LeerAtributo(dirAux);
                    agregar.Add(auxiliar);
                    dirAux = auxiliar.DirSigAtributo;
                }
                this.DD.Add(e, agregar);
            }
        }

        public Atributo LeerAtributo(long dir)
        {
            using (BinaryReader reader = new BinaryReader(new FileStream(sRuta, FileMode.Open)))
            {
                byte[] atrBytes = new byte[63];
                reader.BaseStream.Seek(dir, SeekOrigin.Begin);

                byte[] atrBytesNobre = new byte[29];
                reader.Read(atrBytesNobre, 0, 29);
                string nombreAtr = BinaryToString(atrBytesNobre);

                reader.Read(atrBytes, 0, 8);
                long direcAtr = BitConverter.ToInt64(atrBytes, 0);

                reader.Read(atrBytes, 0, 1);
                char tipoAtr = BitConverter.ToChar(atrBytes, 0);

                reader.Read(atrBytes, 0, 4);
                int longAtr = BitConverter.ToInt32(atrBytes, 0);

                reader.Read(atrBytes, 0, 4);
                int tipoIAtr = BitConverter.ToInt32(atrBytes, 0);

                reader.Read(atrBytes, 0, 8);
                long dirIAtr = BitConverter.ToInt64(atrBytes, 0);

                reader.Read(atrBytes, 0, 8);
                long DirSigAtr = BitConverter.ToInt64(atrBytes, 0);

                Atributo auxiliar = new Atributo(nombreAtr, direcAtr, tipoAtr, longAtr, tipoIAtr, dirIAtr, DirSigAtr);

                reader.Close();
                return auxiliar;
            }
        }

        public void modificarCabecera()
        {
            using (Stream stream = File.Open(sRuta, FileMode.Open))
            {
                stream.Position = 0;
                stream.Write(BitConverter.GetBytes(this.Cabecera), 0, 8);
                stream.Close();
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
                stream.Close();
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
                stream.Close();
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
