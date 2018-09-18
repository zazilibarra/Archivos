﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    //Atributo Serializable para guardar y abrir archivos
    [Serializable]
    public class Entidad
    {
        private string sNombre;
        private long dirEntidad;
        private long dirAtributo;
        private long dirRegDat;
        private long dirSigEnt;

        //Constructor
        public Entidad(string n, long de)
        {
            sNombre = n;
            dirEntidad = de;
            dirAtributo = -1;
            dirRegDat = -1;
            dirSigEnt = -1;
        }

        #region METODOS DE ACCESO
        public void Modificar(string n)
        {
            this.sNombre = n;
        }

        public string Nombre
        {
            get
            {
                return sNombre;
            }
        }

        public long Direccion
        {
            get
            {
                return dirEntidad;
            }
        }

        public long DireccionAtr
        {
            get
            {
                return dirAtributo;
            }
        }

        public long DireccionDatos
        {
            get
            {
                return dirRegDat;
            }
        }

        public long DirSigEntidad
        {
            set
            {
                dirSigEnt = value;
            }
            get
            {
                return dirSigEnt;
            }
        }
        #endregion
    }
}
