using CapaDatos.Modelos;
using CapaNegocio;
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

namespace SistemaFacturacionInventario.Unidad_Medida
{
    public partial class frmUMedida : FormBase
    {
        private string idUnidadMedidaSeleccionada = null;
        private AuxiliaresNegocio auxN = new AuxiliaresNegocio();
        public frmUMedida()
        {
            InitializeComponent();
        }

        private void frmUMedida_Load(object sender, EventArgs e)
        {
            try
            {
                listViewUMedida.View = View.Details;
                listViewUMedida.FullRowSelect = true;

                listViewUMedida.Columns.Add("Nro.", 60, HorizontalAlignment.Left);
                listViewUMedida.Columns.Add("Descripción", 300, HorizontalAlignment.Left);

                CargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarGrilla()
        {
            listViewUMedida.Items.Clear();
            var auxN = new AuxiliaresNegocio();
            List<UnidadesMedida> listum = auxN.ObtenerUMedida();
            foreach (UnidadesMedida um in listum)
            {
                var item = new ListViewItem { Tag = um.IdUnidadMedida.ToString(), Text = um.IdUnidadMedida.ToString() };
                item.SubItems.Add(um.Descripcion);
                listViewUMedida.Items.Add(item);
            }
        }


        private void listViewUMedida_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listViewUMedida.SelectedItems.Count > 0) // Si hay un elemento seleccionado
            {
                var item = listViewUMedida.SelectedItems[0]; // Obtener el primer seleccionado
                idUnidadMedidaSeleccionada = item.Text; // Guardar el Nro. de unidad de medida
                txtUMedida.Text = item.SubItems[1].Text; // Cargar descripción en txtUMedida
                btnNuevo.Text = "Guardar"; // Cambiar el botón 
                btnEliminar.Visible = true;
            }
            else 
            {
                idUnidadMedidaSeleccionada = null; // Limpiar variable
                txtUMedida.Clear(); // Vaciar el campo de texto
                btnNuevo.Text = "Nuevo"; // Volver el botón a Nuevo
                btnEliminar.Visible=false;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

            if (txtUMedida.Text != "")
            {
                var umed = new UnidadesMedida { Descripcion = txtUMedida.Text };
                if (btnNuevo.Text.ToUpper() == "NUEVO") { auxN.NuevaUMedida(umed); }
                else 
                {
                    umed.IdUnidadMedida = Convert.ToInt32(idUnidadMedidaSeleccionada);
                    auxN.EditarUMedida(umed); 
                }
                idUnidadMedidaSeleccionada = null ;
                txtUMedida.Clear();
                btnNuevo.Text = "Nuevo";
                CargarGrilla();
            }
            else { MessageBox.Show("Ingrese una descripción válida", "ERROR DE INGRESO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro que desea borrar la U.Medida seleccionada?", "BORRAR U.MEDIDA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (auxN.BorrarUMedida(Convert.ToInt32(idUnidadMedidaSeleccionada)))
                {
                    CargarGrilla();
                }
                else
                {
                    MessageBox.Show("No se puede borrar la unidad de medida porque hay artículos que forman parte de dicha unidad de medida",
                        "NO SE PUEDE BORRAR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
