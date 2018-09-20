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
                    Archivo = new Archivo(Path.GetFileNameWithoutExtension(saveFileDialog.FileName), Path.GetFullPath(saveFileDialog.FileName), Path.GetDirectoryName(saveFileDialog.FileName));
                    myStream.Close();
                }
                Archivo.Cabecera = -1;
                txtCabecera.Text = Archivo.Cabecera.ToString();
                Archivo.GuardarCambios(Archivo.Cabecera);
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
                    Archivo.modificarCabecera();
                    //Se actualiza la Grid de Entidades
                    ent.GuardarEnt(Archivo.Directorio);
                    Archivo.GuardarCambios(ent);
                    calcularDirecciones();
                    actualizarGridEntidad();
                }
            }
            //Catch atrapa la excepcion de cuando se quiere añadir otra llave (Entidad) con algun nombre que ya existe
            catch (ArgumentException excep)
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
                gridAtributos.Rows.Add(attr.Nombre, attr.Direccion, attr.TipoDato, attr.Longitud, attr.TipoIndice, attr.DirIndice, attr.DirSigAtributo);
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
                Nuevo_Atributo na = new Nuevo_Atributo(Archivo,false);
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
                    Archivo.GuardarCambios(a);
                    calcularDirecciones();
                    actualizarGridAtributo(ent);
                    actualizarGridEntidad();
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
            if (resEntidad != null)
                actualizarGridAtributo(resEntidad);
        }

        //Guardar Archivo
        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // Archivo.Save();
        }

        //Abrir Archivo
        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream;
            //Crea una instancia de SaveFileDialog para que se pueda elegir el nombre y la ubicacion del archivo
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //Extencion .dd
            openFileDialog.Filter = "Archivo de diccionario de datos (*.dd)|*.dd";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = openFileDialog.OpenFile()) != null)
                {
                    //Crea una instancia de Archivo con el nombre que se ingresó
                    Archivo = new Archivo(Path.GetFileNameWithoutExtension(openFileDialog.FileName), Path.GetFullPath(openFileDialog.FileName), Path.GetDirectoryName(openFileDialog.FileName));
                    myStream.Close();
                }
            }
            Archivo.LeerArchivo();
            actualizarGridEntidad();
        }

        //Boton para la modificacion del nombre de la entidad
        private void button2_Click(object sender, EventArgs e)
        {
            //Se busca la entidad contenida en el datagrid para modificar el valor del nombre
            foreach (Entidad ent in Archivo.DiccDatos.Keys)
            {
                if (ent.Nombre == gridEntidad.SelectedCells[0].Value.ToString())
                {
                    ent.Nombre = txtEntidad.Text;
                    calcularDirecciones();
                }
            }
            //Se actualiza el grid
            actualizarGridEntidad();
        }

        //Metodo para eliminar la entidad seleccionada en el datagrid
        private void button5_Click(object sender, EventArgs e)
        {
            Entidad borrar = null;
            //Se busca en el diccionario la entidad que se va a eliminar
            foreach (Entidad ent in Archivo.DiccDatos.Keys)
            {
                if (ent.Nombre == gridEntidad.SelectedCells[0].Value.ToString())
                {
                    borrar = ent;
                }
            }
            //Si se encontro la entidad, se elimina del diccionario
            if (borrar != null)
            {
                Archivo.DiccDatos.Remove(borrar);
            }
            //Se actualiza el datagrid
            calcularDirecciones();
            actualizarGridEntidad();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Entidad dueno=null;
            //Verifica que existan entidades
            if (Archivo.DiccDatos == null)
            {
                MessageBox.Show("La lista de entidades está vacia");
            }
            else
            {
                //Crea una instancia de la ventana para modificar las propiedades del atributo
                Nuevo_Atributo na = new Nuevo_Atributo(Archivo,true);
                var Resultado = na.ShowDialog();
                //Cuando la ventana se cierra
                if (Resultado == DialogResult.OK)
                {
                    //Se busca la entidad a la cual pertenece el atributo que se modificara
                    foreach (Entidad ent in Archivo.DiccDatos.Keys)
                    {
                        if (ent.Nombre == gridEntidad.SelectedCells[0].Value.ToString())
                        {
                            dueno = ent;
                        }
                    }
                    foreach (Atributo an in Archivo.DiccDatos[dueno])
                    {
                        //Se modifican los valores de nombre y el tipo de indice, pero el tipo de dato y longitud se quedan como estaban
                        if (an.Nombre == gridAtributos.SelectedCells[0].Value.ToString())
                        {
                            an.Nombre = na.atributo.Nombre;
                            an.iTipoIndice = na.atributo.iTipoIndice;
                            Archivo.modificarAtributo(an);
                        }
                    }
                    //Se actualiza el datagrid
                    actualizarGridAtributo(dueno);
                }
            }
        }

        //Metodo para eliminar un atributo de una entidad
        private void button6_Click(object sender, EventArgs e)
        {
            Entidad dueno = null;
            Atributo borrar = null;
            //Primero se busca la entidad en la cual se encuentra el atributo que se va a eliminar
            foreach (Entidad ent in Archivo.DiccDatos.Keys)
            {
                if (ent.Nombre == gridEntidad.SelectedCells[0].Value.ToString())
                {
                    dueno = ent;
                }
            }
            //Se busca el atributo en la lista de atributos que contiene la entidad y se guarda para posteriormente eliminarlo
            if (dueno != null)
            {
                foreach (Atributo an in Archivo.DiccDatos[dueno])
                {
                    if (an.Nombre == gridAtributos.SelectedCells[0].Value.ToString())
                    {
                        borrar = an;
                    }
                }
            }
            else
            {
                MessageBox.Show("No se encontro la entidad");
            }
            //Se elimina el atributo
            Archivo.DiccDatos[dueno].Remove(borrar);
            //Se actualiza el datagrid
            calcularDirecciones();
            actualizarGridAtributo(dueno);
        }

        //Metodo para calcular las direcciones siguientes de cada entidad y de cada atributo, asi como el primer atributo de cada entidad
        private void calcularDirecciones()
        {
            Entidad anterior = null;
            Atributo antes = null;
            //Se busca cada entidad para aplicar los cambios
            foreach (Entidad ent in Archivo.DiccDatos.Keys)
            {
                antes = null;
                //Si la entidad tiene atributos se busca el primero y se guarda la direccion
                if (Archivo.DiccDatos[ent].Count != 0)
                {
                    ent.DireccionAtr = Archivo.DiccDatos[ent][0].Direccion;
                    Archivo.modificarEntidad(ent);
                }
                //Se guarda la direccion de la entidad siguiente en el directorio
                if (anterior != null)
                {
                    anterior.DirSigEntidad = ent.Direccion;
                    Archivo.modificarEntidad(anterior);
                }
                anterior = ent;
                foreach (Atributo an in Archivo.DiccDatos[ent])
                {
                    //Se guarda la direccion del siguiente atributo de la entidad
                    if(antes!=null)
                    {
                        antes.DirSigAtributo = an.Direccion;
                        Archivo.modificarAtributo(antes);
                    }
                    antes = an;
                }
            }
        }
    }
}
