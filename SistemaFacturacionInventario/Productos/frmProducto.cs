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
        private Form activeForm;
        public string Accion;
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
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private bool Validaciones()
        {
            bool Correcto = true;
            try
            {

                List<string> errores = new List<string>();

                if (string.IsNullOrWhiteSpace(txtDescCorta.Text))
                {
                    errores.Add("Ingrese descripción corta.");
                    Correcto = false;
                }

                if (string.IsNullOrWhiteSpace(txtDescLarga.Text))
                {
                    errores.Add("Ingrese descripción larga.");
                    Correcto = false;
                }

                if (errores.Count > 0)
                {
                    lblErrores.Text = string.Join("\n", errores);
                    lblErrores.Visible = true;
                }
                else
                {
                    lblErrores.Text = "";
                    lblErrores.Visible = false;
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return Correcto;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validaciones()) return;
                var productoNegocio = new ProductoNegocio();
                var producto = new CapaDatos.Modelos.Productos
                {
                    IdProducto = IdProducto,
                    NroProducto = productoNegocio.AgregarNroProducto(),
                    DescCorta = txtDescCorta.Text,
                    DescLarga = txtDescLarga.Text,
                    CantidadMinima = Convert.ToDouble(txtStockMin.Text.Replace(".", ",")),
                    IdRubro = Convert.ToInt32(cmbRubro.SelectedValue),
                    IdUnidadMedida = Convert.ToInt16(cmbUMedida.SelectedValue),
                    LlevarStock = chkStock.Checked,
                    StockActual = Convert.ToDouble(txtStockActual.Text.Replace(".", ",")),
                    UltimaActStock = DateTime.Now,
                    FechaAcceso = DateTime.Now
                };
                if (Accion == "ALTA")
                {
                    Int32 idProducto = productoNegocio.NuevoProducto(producto);
                    {
                        if (MessageBox.Show("El producto se ingresó correctamente." + Environment.NewLine + "Nro.Producto: " + idProducto + Environment.NewLine + "Desea cargar precios para el producto?",
                                "ALTA CORRECTA", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            var frm = new frmPrecios(idProducto);
                            frm.ShowDialog();
                        }
                    }
                }
                else
                {
                    if (productoNegocio.EditarProducto(producto, IdProducto)) { MessageBox.Show("El producto se editó correctamente.", "EDICIÓN CORRECTA", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUMedida_Click(object sender, EventArgs e)
        {

        }

        private void txtNroProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtNroProducto.Text != "") BuscarProducto(Convert.ToInt32(txtNroProducto.Text));
        }

        private void BuscarProducto(int idProducto)
        {
            try
            {
                ProductoNegocio productoNegocio = new ProductoNegocio();
                CapaDatos.Modelos.Productos producto = productoNegocio.ObtenerProductoPorId(idProducto);
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
                    Accion = "MOD";
                    if (producto.FechaBaja == null) return;
                    lblBaja.Text = "Dado de baja el día " + producto.FechaBaja.Value.ToShortDateString();
                    btnBaja.Enabled = false;
                    
                }
                else { MessageBox.Show("No se encontró el producto", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
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

        private void btnVolver_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmListaClientes(), sender);
        }

        public void OpenChildForm(Form childForm, object btnSender)
        {
            MenuPrincipal principal = Application.OpenForms["MenuPrincipal"] as MenuPrincipal;
            if (principal != null)
            {
                if (activeForm != null)
                {
                    activeForm.Close();
                }

                activeForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                principal.pnlContenedorPrincipal.Controls.Add(childForm);
                principal.pnlContenedorPrincipal.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
            }


        }

        private void txtNroProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar)) e.Handled = true;
        }

        private void txtStockActual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void txtStockMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNroProducto.Text != "")
                {
                     BuscarProducto(Convert.ToInt32(txtNroProducto.Text));                    
                }
                else { MessageBox.Show("Ingrese Nro.Producto para realizar la búsqueda", "Error de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chkStock_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                txtStockMin.Enabled = chkStock.Checked;
                txtStockActual.Enabled = chkStock.Checked && Accion == "ALTA";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
