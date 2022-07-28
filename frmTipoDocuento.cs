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
    public partial class frmTipoDocuento : Form
    {
        public frmTipoDocuento()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void cargarDatos()
        {
            var adaptador = new dsPruebaTableAdapters.TipoDocumentoTableAdapter();
            var tabla = adaptador.GetData();
            dgvDatos.DataSource = tabla;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            
            DialogResult respuesta = MessageBox.Show("¿Desea agregar nuevo registro?", "SISTEMA",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                var frm = new frmTipoDocumentoEdit();
                frm.ShowDialog();
                MessageBox.Show("Registro agregado", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargarDatos();
            }
            else
            {
                MessageBox.Show("Operacion cancelada", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int id = getId();
            if (id > 0)
            {
                var frm = new frmTipoDocumentoEdit(id);
                frm.ShowDialog();
                cargarDatos();
            }
            else
            {
                MessageBox.Show("Seleccione un Id válido", "SISTEMA",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private int getId()
        {
            try
            {
                DataGridViewRow filaActual = dgvDatos.CurrentRow;
                if (filaActual == null)
                {
                    return 0;
                }
                return int.Parse(dgvDatos.Rows[filaActual.Index].Cells[0].Value.ToString());
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = getId();
            if (id > 0)
            {
                DialogResult respuesta = MessageBox.Show("¿Realmente desea eliminar el registro "+id+"?", "SISTEMA",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    var adaptador = new dsPruebaTableAdapters.TipoDocumentoTableAdapter();
                    adaptador.Eliminar(id);
                    MessageBox.Show("Registro "+id+" Eliminado", "SISTEMA",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarDatos();
                }
                else
                {
                    MessageBox.Show("Operacion cancelada", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
               MessageBox.Show("Debe seleccionar un Id válido", "SISTEMA",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmTipoDocuento_Load(object sender, EventArgs e)
        {

        }
    }

}
