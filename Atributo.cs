using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    [Serializable]
    public class Atributo
    {
        private string sNombre;
        private long dirAtributo;
        private char cTipo;
        private int iLong;
        private int iTipoIndice;
        private long dirIndice;
        private long dirSigAtributo;

        public Atributo(string n, char t, int l, int ti, long da)
        {
            sNombre = n;
            dirAtributo = da;
            cTipo = t;
            iLong = l;
            iTipoIndice = ti;
            dirIndice = -1;
            dirSigAtributo = -1;
        }

        public bool Modificar(string n, char t, int l, int ti)
        {
            sNombre = n;
            cTipo = t;
            iLong = l;
            iTipoIndice = ti;

            return true;
        }

        public string Nombre
        {
            get
            {
                return sNombre;
            }
        }

        public char TipoDato
        {
            get
            {
                return cTipo;
            }
        }

        public long DirIndice
        {
            get
            {
                return dirIndice;
            }
        }

        public int Longitud
        {
            get
            {
                return iLong;
            }
        }

        public long TipoIndice
        {
            get
            {
                return iTipoIndice;
            }
        }

        public long Direccion
        {
            set
            {
                dirAtributo = value;
            }
            get
            {
                return dirAtributo;
            }
        }

        public long DirSigAtributo
        {
            set
            {
                dirSigAtributo = value;
            }
            get
            {
                return dirSigAtributo;
            }
        }


    }
}
