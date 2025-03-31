using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFacturacionInventario.Proveedores
{
    public partial class frmProveedores : FormBase
    {
        private string idProveedorSeleccionado = null;
        private AuxiliaresNegocio auxN = new AuxiliaresNegocio();
        public frmProveedores()
        {
            InitializeComponent();
        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {
            try
            {
                listViewProveedor.View = View.Details;
                listViewProveedor.FullRowSelect = true;

                listViewProveedor.Columns.Add("Nro.", 60, HorizontalAlignment.Left);
                listViewProveedor.Columns.Add("Descripción", 300, HorizontalAlignment.Left);

                CargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarGrilla()
        {
            listViewProveedor.Items.Clear();
            var auxN = new AuxiliaresNegocio();
            List<CapaDatos.Modelos.Proveedores> listRubro = auxN.ObtenerProveedores();
            foreach (CapaDatos.Modelos.Proveedores rub in listRubro)
            {
                var item = new ListViewItem { Tag = rub.IdProveedor.ToString(), Text = rub.IdProveedor.ToString() };
                item.SubItems.Add(rub.Descripcion);
                listViewProveedor.Items.Add(item);
            }
        }

        private void listViewProveedor_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listViewProveedor.SelectedItems.Count > 0) // Si hay un elemento seleccionado
            {
                var item = listViewProveedor.SelectedItems[0]; // Obtener el primer seleccionado
                idProveedorSeleccionado = item.Text; // Guardar el Nro. de unidad de medida
                txtProveedor.Text = item.SubItems[1].Text; // Cargar descripción en txtUMedida
                btnNuevo.Text = "Guardar"; // Cambiar el botón 
                btnEliminar.Visible = true;
            }
            else
            {
                idProveedorSeleccionado = null; // Limpiar variable
                txtProveedor.Clear(); // Vaciar el campo de texto
                btnNuevo.Text = "Nuevo"; // Volver el botón a Nuevo
                btnEliminar.Visible = false;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (txtProveedor.Text != "")
            {
                var proveedor = new CapaDatos.Modelos.Proveedores { Descripcion = txtProveedor.Text };
                if (btnNuevo.Text.ToUpper() == "NUEVO") { auxN.NuevoProveedor(proveedor); }
                else
                {
                    proveedor.IdProveedor = Convert.ToInt32(idProveedorSeleccionado);
                    auxN.EditarProveedor(proveedor);
                }
                idProveedorSeleccionado = null;
                txtProveedor.Clear();
                btnNuevo.Text = "Nuevo";
                CargarGrilla();
            }
            else { MessageBox.Show("Ingrese una descripción válida", "ERROR DE INGRESO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro que desea borrar el proveedor seleccionado?", "BORRAR PROVEEDOR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (auxN.BorrarProveedor(Convert.ToInt32(idProveedorSeleccionado)))
                {
                    txtProveedor.Text = "";
                    idProveedorSeleccionado = null;
                    btnEliminar.Visible = false;
                    btnNuevo.Text = "Nuevo";
                    CargarGrilla();
                }
                else
                {
                    MessageBox.Show("No se puede borrar el proveedor porque hay productos que forman parte de dicho rubro",
                        "NO SE PUEDE BORRAR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
