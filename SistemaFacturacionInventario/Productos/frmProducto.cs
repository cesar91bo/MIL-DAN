using CapaDatos.Modelos;
using CapaNegocio;
using SistemaFacturacionInventario.Rubros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFacturacionInventario.Productos
{
    public partial class frmProducto : FormBase
    {
        public int IdProducto;
        public frmProducto()
        {
            InitializeComponent();
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            try
            {
                LlenarComboRubro();
                LlenarComboUMedida();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LlenarComboUMedida()
        {
            var rep = new AuxiliaresNegocio();
            cmbUMedida.DisplayMember = "Descripcion";
            cmbUMedida.ValueMember = "IdUnidadMedida";
            cmbUMedida.DataSource = rep.ObtenerUMedida(); ;
        }

        private void LlenarComboRubro()
        {
            try
            {
                var rep = new AuxiliaresNegocio();
                cmbRubro.DisplayMember = "Descripcion";
                cmbRubro.ValueMember = "IdRubro";
                cmbRubro.DataSource = rep.ObtenerRubros();
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void btnUMedida_Click(object sender, EventArgs e)
        {

        }

        private void txtNroProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtNroProducto.Text != "") BuscarProducto(Convert.ToInt32(txtNroProducto.Text));
        }

        private void BuscarProducto(int nroProducto)
        {
            try
            {
                ProductoNegocio productoNegocio = new ProductoNegocio();
                CapaDatos.Modelos.Productos producto = productoNegocio.ObtenerProductoPorId(IdProducto);
                if (producto != null)
                {
                    txtDescCorta.Text = producto.DescCorta;
                    txtDescLarga.Text = producto.DescLarga;
                    txtStockActual.Text = producto.StockActual.ToString();
                    txtStockMin.Text = producto.CantidadMinima.ToString();
                    cmbRubro.SelectedValue = producto.IdRubro;
                    cmbUMedida.SelectedValue = producto.IdUnidadMedida;
                    chkStock.Checked = producto.LlevarStock;
                    IdProducto = producto.NroProducto;
                    if (producto.FechaBaja == null) return;
                    lblBaja.Text = "Dado de baja el día " + producto.FechaBaja.Value.ToShortDateString();
                    btnBaja.Enabled = false;
                }
                else { MessageBox.Show("No se encontró el artículo", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnRubro_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmRubro();
                frm.ShowDialog();
                if (frm.DialogResult != DialogResult.OK) return;
                LlenarComboRubro();
                cmbRubro.SelectedIndex = cmbRubro.Items.Count - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
