using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRUEBA
{
    public partial class frmTipoDocumentoEdit : Form
    {
        private int? Id;
        public frmTipoDocumentoEdit(int? id = null)
        {
            InitializeComponent();
            this.Id = id;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int estado = chkEstado.Checked ? 1 : 0;
            string nombre = txtNombre.Text;
            var adaptador = new dsPruebaTableAdapters.TipoDocumentoTableAdapter();
            if (this.Id == null)
            {
                adaptador.Agregar(nombre, (byte)estado);
            }
            else
            {
                adaptador.Editar(nombre, (byte)estado, (int)this.Id);
            }
            this.Close();
        }

        private void frmTipoDocumentoEdit_Load(object sender, EventArgs e)
        {
            if (this.Id != null)
            {
                this.Text = "Editar";
                var adaptador = new dsPruebaTableAdapters.TipoDocumentoTableAdapter();
                var tabla = adaptador.GetDataByid((int)this.Id);
                var fila = (dsPrueba.TipoDocumentoRow)tabla.Rows[0];
                txtNombre.Text = fila.Nombre;
                chkEstado.Checked = fila.Estado == 1 ? true : false;
                
            }
            else
            {
                this.Text = "Nuevo";
            }
        }
    } 
}
