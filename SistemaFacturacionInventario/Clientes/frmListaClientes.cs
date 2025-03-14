using CapaDatos.Modelos;
using CapaNegocio;
using SistemaFacturacionInventario.Auxiliares;
using SistemaFacturacionInventario.Clientes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFacturacionInventario.Productos
{
    public partial class frmListaClientes : FormBase
    {
        public int IdCLiente;
        List<CapaDatos.Modelos.VistaClientes> vistaClientes;
        private int sortColumn = -1;
        public bool Seleccion;
        private Form activeForm;

        public frmListaClientes()
        {

            InitializeComponent();
        }

        private void frmListaClientes_Load(object sender, EventArgs e)
        {
            try
            {
                CrearColListCliente();
                LLenarListaCliente(true);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CrearColListCliente()
        {
            listViewClientes.Columns.Add("Nro.Cliente", 60, HorizontalAlignment.Left);
            listViewClientes.Columns.Add("Cliente", 250, HorizontalAlignment.Left);
            listViewClientes.Columns.Add("Tipo Doc.", 80, HorizontalAlignment.Left);
            listViewClientes.Columns.Add("Número", 134, HorizontalAlignment.Left);
            listViewClientes.Columns.Add("Dirección", 250, HorizontalAlignment.Left);
            listViewClientes.Columns.Add("Teléfono", 134, HorizontalAlignment.Left);
            listViewClientes.Columns.Add("Estado", 90, HorizontalAlignment.Left);
        }

        private void LLenarListaCliente(bool siload)
        {
            listViewClientes.Items.Clear();

            if (siload)
            {
                var clienteNegocio = new ClienteNegocio();
                if (chkCliBaja.Checked)
                {
                    vistaClientes = clienteNegocio.ObtenerListaClientes();
                }
                else
                {
                    vistaClientes = clienteNegocio.ObtenerListaClientesActivos();
                }

            }
            else
            {
                vistaClientes = BuscarCliente();
            }

            if (vistaClientes == null) return;
            foreach (CapaDatos.Modelos.VistaClientes vistaCliente in vistaClientes)
            {
                var item = new ListViewItem
                {
                    Tag = vistaCliente.IdCliente.ToString(),
                    Text = vistaCliente.IdCliente.ToString()
                };
                item.SubItems.Add(vistaCliente.Nombre + " " + vistaCliente.Apellido);
                item.SubItems.Add(vistaCliente.TipoDocumento);
                item.SubItems.Add(vistaCliente.Nro_Doc != "" ? vistaCliente.Nro_Doc : vistaCliente.Cuit);
                item.SubItems.Add(vistaCliente.Direccion);
                item.SubItems.Add(vistaCliente.Telefono);
                item.SubItems.Add(vistaCliente.Estado);

                if (vistaCliente.FechaBaja.ToString() != "") { item.ForeColor = Color.Red; }
                listViewClientes.Items.Add(item);
                listViewClientes.Focus();
            }
        }

        private List<VistaClientes> BuscarCliente()
        {
            try
            {
                var clienteNegocio = new ClienteNegocio();


                return (txtFiltro.Text != "") ? clienteNegocio.ObtenerCliporNombreApellido(txtFiltro.Text, chkCliBaja.Checked) : clienteNegocio.ObtenerListaClientes();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var frm = new frmCliente { IdCliente = Convert.ToInt32(listViewClientes.SelectedItems[0].Tag), Accion = "MOD" };
            frm.ShowDialog();
            btnEditar.Enabled = false;
            LLenarListaCliente(false);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                LLenarListaCliente(false);

                if (string.IsNullOrWhiteSpace(txtFiltro.Text))
                {
                    LLenarListaCliente(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
            }
        }

        private void listViewClientes_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            try
            {
                if (e.Column != sortColumn)
                {
                    // Set the sort column to the new column.
                    sortColumn = e.Column;
                    // Set the sort order to ascending by default.
                    listViewClientes.Sorting = SortOrder.Ascending;
                }
                else
                {
                    // Determine what the last sort order was and change it.
                    listViewClientes.Sorting = listViewClientes.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
                }
                // Call the sort method to manually sort.
                listViewClientes.Sort();
                // Set the ListViewItemSorter property to a new ListViewItemComparer
                // object.
                listViewClientes.ListViewItemSorter = new ListViewItemComparer(e.Column, listViewClientes.Sorting);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private class ListViewItemComparer : IComparer
        {
            private readonly int ColumnNumber;
            private readonly SortOrder SortOrder;

            public ListViewItemComparer(int column_number,
                SortOrder sort_order)
            {
                ColumnNumber = column_number;
                SortOrder = sort_order;
            }

            // Se comparan dos ListViewItems.
            public int Compare(object object_x, object object_y)
            {
                // Seteamos los objetos como ListViewItems.
                ListViewItem item_x = object_x as ListViewItem;
                ListViewItem item_y = object_y as ListViewItem;

                // Obtenemos los valores de sub-item correspondientes.
                string string_x;
                if (item_x.SubItems.Count <= ColumnNumber)
                {
                    string_x = "";
                }
                else
                {
                    string_x = item_x.SubItems[ColumnNumber].Text;
                }

                string string_y;
                if (item_y.SubItems.Count <= ColumnNumber)
                {
                    string_y = "";
                }
                else
                {
                    string_y = item_y.SubItems[ColumnNumber].Text;
                }

                // Comparamos.
                int result;
                double double_x, double_y;
                if (double.TryParse(string_x, out double_x) &&
                    double.TryParse(string_y, out double_y))
                {
                    // Lo trata como número.
                    result = double_x.CompareTo(double_y);
                }
                else
                {
                    DateTime date_x, date_y;
                    if (DateTime.TryParse(string_x, out date_x) &&
                        DateTime.TryParse(string_y, out date_y))
                    {
                        // Lo trata como fecha.
                        result = date_x.CompareTo(date_y);
                    }
                    else
                    {
                        // Lo trata como texto.
                        result = string_x.CompareTo(string_y);
                    }
                }

                // Devuelve el resultado correcto dependiendo si
                // ordenamos ascendente o descendentemente.
                if (SortOrder == SortOrder.Ascending)
                {
                    return result;
                }
                else
                {
                    return -result;
                }
            }
        }

        private void listViewClientes_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SeleccionarCliente();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SeleccionarCliente()
        {
            try
            {
                IdCLiente = Convert.ToInt32(listViewClientes.SelectedItems[0].Tag);

                if (IdCLiente > 0)
                {
                    btnEditar.Enabled = true;
                }
                else
                {
                    btnEditar.Enabled = false;
                }

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listViewClientes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                SeleccionarCliente();
                var frm = new frmCliente { IdCliente = IdCLiente, Accion = "MOD" };
                frm.ShowDialog();
                btnEditar.Enabled = false;
                LLenarListaCliente(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void listViewClientes_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listViewClientes.SelectedItems.Count > 0)
            {
                SeleccionarCliente();

                if (e.Item.SubItems[6].Text == "Dado de Baja") btnActivar.Visible = true; else btnActivar.Visible = false;
            }
            else
            {
                IdCLiente = 0;
                btnEditar.Enabled = false;
            }
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            var clienteNegocio = new ClienteNegocio();

            if (clienteNegocio.ActivarCliente(IdCLiente))
            {
                MessageBox.Show("El Cliente fue dado de alta nuevamente", "ACTIVACIÓN CORRECTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            LLenarListaCliente(true);
        }

        private void chkCliBaja_CheckedChanged(object sender, EventArgs e)
        {
            LLenarListaCliente(true);
        }
    }
}
