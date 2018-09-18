using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Archivos
{
    public partial class Main : Form
    {
        Archivo Archivo;
        long currentDir = 8;

        public Main()
        {
            InitializeComponent();
            txtCabecera.Text = "No existe archivo";
        }

        //Crear nuevo Archivo
        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream;
            //Crea una instancia de SaveFileDialog para que se pueda elegir el nombre y la ubicacion del archivo
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            //Extencion .dd
            saveFileDialog.Filter = "Archivo de diccionario de datos (*.dd)|*.dd";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog.OpenFile()) != null)
                {
                    //Crea una instancia de Archivo con el nombre que se ingresó
                    Archivo = new Archivo(Path.GetFileNameWithoutExtension(saveFileDialog.FileName));
                    myStream.Close();
                }
            }

        }

        //Crear Entidad
        private void btnCrearEntidad_Click(object sender, EventArgs e)
        {
            try
            {
                //Si existe un archivo abierto
                if (Archivo != null)
                {
                    //Se crea una instancia de Entidad con el nombre deseado y su direccion
                    Entidad ent = new Entidad(txtEntidad.Text, currentDir);
                    //La nueva entidad se agrega a DD
                    Archivo.DiccDatos.Add(ent, new List<Atributo>());
                    //Se recorre el apuntador de la direecion actual
                    currentDir += 62;
                    //Se actualiza la cabecera del archivo
                    Archivo.Cabecera = Archivo.DiccDatos.Keys.First<Entidad>().Direccion;
                    txtCabecera.Text = Archivo.Cabecera.ToString();
                    //Se actualiza la Grid de Entidades
                    actualizarGridEntidad();
                }
            }
            //Catch atrapa la excepcion de cuando se quiere añadir otra llave (Entidad) con algun nombre que ya existe
            catch(ArgumentException excep)
            {
                MessageBox.Show("Ya existe una entidad con el mismo nombre");
            }
        }

        //Actualiza Grid de Entidades
        private void actualizarGridEntidad()
        {
            //Limpia la Grid
            gridEntidad.Rows.Clear();
            //Recorre las entidades del DD y va añadiendo renglones con la respectiva informacion
            foreach (Entidad ent in Archivo.DiccDatos.Keys)
            {
                gridEntidad.Rows.Add(ent.Nombre, ent.Direccion, ent.DireccionAtr, ent.DireccionDatos, ent.DirSigEntidad);
            }
        }

        //Actualiza Grid de Entidades. Le llega como parametro la entidad de la cual va a mostrar los atributos
        private void actualizarGridAtributo(Entidad ent)
        {
            //Limpia la Grid
            gridAtributos.Rows.Clear();
            //Recorre los atributos de la entidad y va añadiendo renglones con la respectiva informacion
            foreach (Atributo attr in Archivo.DiccDatos[ent])
            {
                gridAtributos.Rows.Add(attr.Nombre, attr.Direccion, attr.TipoDato, attr.Longitud, attr.TipoIndice,attr.DirIndice, attr.DirSigAtributo);
            }
        }

        //Añadir atributo
        private void button4_Click(object sender, EventArgs e)
        {
            //Verifica que existan entidades
            if (Archivo.DiccDatos == null)
            {
                MessageBox.Show("La lista de entidades está vacia");
            }
            else
            {
                //Crea una instancia de la ventana para capturar las propiedades del nuevo atributo
                Nuevo_Atributo na = new Nuevo_Atributo(Archivo);
                var Resultado = na.ShowDialog();
                //Cuando la ventana se cierra
                if (Resultado == DialogResult.OK)
                {
                    //Crea una instancia de Atributo
                    Atributo a = na.atributo;
                    //Se le asigna direccion al nuevo atributo
                    a.Direccion = currentDir;
                    Entidad ent = na.destino;
                    //Añade al atributo a la entidad correspondiente
                    Archivo.DiccDatos[ent].Add(a);
                    //Actualiza la Grid de Atributos
                    actualizarGridAtributo(ent);
                    currentDir += 63;
                }
            }
        }

        //Evento de dar click en una entidad en la Grid
        private void gridEntidad_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Obtiene el nombre de la entidad a la que se dio click
            string nEntidad = gridEntidad.SelectedCells[0].Value.ToString();
            //Busca la entidad en el DD
            Entidad resEntidad = Archivo.BuscarEntidad(nEntidad);
            //Si se regresa una entidad se actualiza la Grid de Atributos
            if(resEntidad != null)
                actualizarGridAtributo(resEntidad);
        }

        //Guardar Archivo
        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Archivo.Save();
        }

        //Abrir Archivo
        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Archivo.Load();
            actualizarGridEntidad();
        }
    }
}
