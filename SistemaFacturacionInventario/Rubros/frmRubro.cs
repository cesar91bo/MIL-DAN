using CapaDatos.Modelos;
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

namespace SistemaFacturacionInventario.Rubros
{
    public partial class frmRubro : FormBase
    {
        private string idRubroSeleccionada = null;
        private AuxiliaresNegocio auxN = new AuxiliaresNegocio();
        public frmRubro()
        {
            InitializeComponent();
        }

        private void listViewRubro_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listViewRubro.SelectedItems.Count > 0) // Si hay un elemento seleccionado
            {
                var item = listViewRubro.SelectedItems[0]; // Obtener el primer seleccionado
                idRubroSeleccionada = item.Text; // Guardar el Nro. de unidad de medida
                txtRubro.Text = item.SubItems[1].Text; // Cargar descripción en txtUMedida
                btnNuevo.Text = "Guardar"; // Cambiar el botón 
                btnEliminar.Visible = true;
            }
            else
            {
                idRubroSeleccionada = null; // Limpiar variable
                txtRubro.Clear(); // Vaciar el campo de texto
                btnNuevo.Text = "Nuevo"; // Volver el botón a Nuevo
                btnEliminar.Visible = false;
            }
        }

        private void frmRubro_Load(object sender, EventArgs e)
        {
            try
            {
                listViewRubro.View = View.Details;
                listViewRubro.FullRowSelect = true;

                listViewRubro.Columns.Add("Nro.", 60, HorizontalAlignment.Left);
                listViewRubro.Columns.Add("Descripción", 300, HorizontalAlignment.Left);

                CargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarGrilla()
        {
            listViewRubro.Items.Clear();
            var auxN = new AuxiliaresNegocio();
            List<CapaDatos.Modelos.Rubros> listRubro = auxN.ObtenerRubros();
            foreach (CapaDatos.Modelos.Rubros rub in listRubro)
            {
                var item = new ListViewItem { Tag = rub.IdRubro.ToString(), Text = rub.IdRubro.ToString() };
                item.SubItems.Add(rub.Descripcion);
                listViewRubro.Items.Add(item);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (txtRubro.Text != "")
            {
                var rubro = new CapaDatos.Modelos.Rubros { Descripcion = txtRubro.Text };
                if (btnNuevo.Text.ToUpper() == "NUEVO") { auxN.NuevoRubro(rubro); }
                else
                {
                    rubro.IdRubro = Convert.ToInt32(idRubroSeleccionada);
                    auxN.EditarRubro(rubro);
                }
                idRubroSeleccionada = null;
                txtRubro.Clear();
                btnNuevo.Text = "Nuevo";
                CargarGrilla();
            }
            else { MessageBox.Show("Ingrese una descripción válida", "ERROR DE INGRESO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro que desea borrar el rubro seleccionada?", "BORRAR RUBRO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (auxN.BorrarRubro(Convert.ToInt32(idRubroSeleccionada)))
                {
                    txtRubro.Text = "";
                    idRubroSeleccionada = null;
                    btnEliminar.Visible = false;
                    btnNuevo.Text = "Nuevo";
                    CargarGrilla();
                }
                else
                {
                    MessageBox.Show("No se puede borrar el rubro porque hay productos que forman parte de dicho rubro",
                        "NO SE PUEDE BORRAR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
