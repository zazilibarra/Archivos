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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Archivo de diccionario de datos (*.dd)|*.dd";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog.OpenFile()) != null)
                {
                    Archivo = new Archivo(Path.GetFileNameWithoutExtension(saveFileDialog.FileName));
                    myStream.Close();
                }
            }

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCrearEntidad_Click(object sender, EventArgs e)
        {
            try
            {
                if (Archivo != null)
                {
                    Entidad ent = new Entidad(txtEntidad.Text, currentDir);
                    Archivo.DiccDatos.Add(ent, new List<Atributo>());
                    currentDir += 62;
                    Archivo.Cabecera = Archivo.DiccDatos.Keys.First<Entidad>().Direccion;
                    txtCabecera.Text = Archivo.Cabecera.ToString();
                    actualizarRowEntidad();
                }
            }
            catch(ArgumentException excep)
            {
                MessageBox.Show("Ya existe una entidad con el mismo nombre");
            }
        }

        private void actualizarRowEntidad()
        {
            gridEntidad.Rows.Clear();
            foreach (Entidad ent in Archivo.DiccDatos.Keys)
            {
                gridEntidad.Rows.Add(ent.Nombre, ent.Direccion, ent.DireccionAtr, ent.DireccionDatos, ent.DirSigEntidad);
            }
        }

        private void actualizarRowAtributo(Entidad ent)
        {
            gridAtributos.Rows.Clear();
            foreach (Atributo attr in Archivo.DiccDatos[ent])
            {
                gridAtributos.Rows.Add(attr.Nombre, attr.Direccion, attr.TipoDato, attr.Longitud, attr.TipoIndice,attr.DirIndice, attr.DirSigAtributo);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Archivo.DiccDatos == null)
            {
                MessageBox.Show("La lista de entidades está vacia");
            }
            else
            {
                Nuevo_Atributo na = new Nuevo_Atributo(Archivo);
                var Resultado = na.ShowDialog();
                if (Resultado == DialogResult.OK)
                {
                    Atributo a = na.atributo;
                    a.Direccion = currentDir;
                    Entidad ent = na.destino;
                    Archivo.DiccDatos[ent].Add(a);
                    actualizarRowAtributo(ent);
                    currentDir += 63;
                }
            }
        }

        private void gridEntidad_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string nEntidad = gridEntidad.SelectedCells[0].Value.ToString();
            Entidad resEntidad = Archivo.BuscarEntidad(nEntidad);
            if(resEntidad != null)
                actualizarRowAtributo(resEntidad);
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Archivo.Save();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Archivo.Load();
            actualizarRowEntidad();
        }
    }
}
