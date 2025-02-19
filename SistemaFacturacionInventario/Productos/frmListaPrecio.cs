using CapaDatos.Modelos;
using CapaNegocio;
using SistemaFacturacionInventario.Auxiliares;
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
    public partial class frmListaPrecio : FormBase
    {
        public int IdProducto;
        List<CapaDatos.Modelos.VistaPreciosVenta> precios;
        private int sortColumn = -1;
        public bool Seleccion;
        private Form activeForm;
        public frmListaPrecio()
        {
            InitializeComponent();
        }

        private void frmListaPrecio_Load(object sender, EventArgs e)
        {
            var dt = new DataTable();
            dt.Columns.Add("IdBusqueda");
            dt.Columns.Add("Descripcion");

            dt.Rows.Add("DescCorta", "Descripción Corta");
            dt.Rows.Add("IdProducto", "Nº Producto");
            cmbFiltro.DataSource = dt;
            cmbFiltro.DisplayMember = "Descripcion";
            cmbFiltro.ValueMember = "IdBusqueda";
            cmbFiltro.SelectedValue = "DescCorta";

            CrearColListView();
            Llenarlistview(true);
        }

        private void EditarProducto(object sender, EventArgs e)
        {
            if (listViewProductos.FocusedItem != null)
            {
                MessageBox.Show($"Editar producto: {listViewProductos.FocusedItem.Text}");
                // Aquí abrirías un formulario para editar el producto
            }
        }

        private void CrearColListView()
        {
            listViewProductos.Columns.Add("Nro.Producto", 60, HorizontalAlignment.Left);
            listViewProductos.Columns.Add("Nombre", 250, HorizontalAlignment.Left);
            listViewProductos.Columns.Add("Precio Contado Con IVA", 100, HorizontalAlignment.Left);
            listViewProductos.Columns.Add("Precio Contado Sin IVA", 100, HorizontalAlignment.Left);
            listViewProductos.Columns.Add("Fecha de Precio", 100, HorizontalAlignment.Left);
            listViewProductos.Columns.Add("Precio Base", 100, HorizontalAlignment.Left);
            listViewProductos.Columns.Add("% Ganancia", 100, HorizontalAlignment.Left);
            listViewProductos.Columns.Add("% Bonificación", 100, HorizontalAlignment.Left);
            listViewProductos.Columns.Add("% Flete", 85, HorizontalAlignment.Left);
        }

        private void Llenarlistview(bool siload)
        {
            listViewProductos.Items.Clear();

            if (siload)
            {
                var productoNegocio = new ProductoNegocio();

                precios = productoNegocio.ObtenerUltPrecioVenta();

            }
            else
            {
                precios = BuscarPrecio();
            }

            if (precios == null) return;
            foreach (CapaDatos.Modelos.VistaPreciosVenta precio in precios)
            {
                var item = new ListViewItem
                {
                    Tag = precio.IdProducto.ToString(),
                    Text = precio.IdProducto.ToString()
                };
                item.SubItems.Add(precio.DescCorta);
                item.SubItems.Add(precio.PrecioContadoIva.ToString("0.##"));
                item.SubItems.Add(precio.PrecioContado.ToString("0.##"));
                item.SubItems.Add(precio.FechaPrecio.ToString("dd-MM-yyyy"));
                item.SubItems.Add(precio.PrecioBase.ToString("0.##"));
                item.SubItems.Add(precio.PorcentajeGcia.ToString("0.##") ?? "0");
                item.SubItems.Add(precio.Bonificacion1?.ToString("0.##") ?? "0");
                item.SubItems.Add(precio.PorcentajeFlete?.ToString("0.##"));
                listViewProductos.Items.Add(item);
                listViewProductos.Focus();
            }
        }

        private List<VistaPreciosVenta> BuscarPrecio()
        {
            try
            {
                var productoNegocio = new ProductoNegocio();
                switch (cmbFiltro.SelectedValue.ToString().ToUpper())
                {
                    case "IDPRODUCTO":
                        if (!FuncionesForms.NroEneteroInt32(txtFiltro.Text))
                        {
                            MessageBox.Show("Ingrese texto de búsqueda válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return null;
                        }
                        return productoNegocio.ObtenerListPreciosPorNro(Convert.ToInt32(txtFiltro.Text));

                    case "DESCCORTA":
                        //TituloEx = "Listado de Artículos filtrado por Desc.Corta";
                        return (txtFiltro.Text != "") ? productoNegocio.ObtenerListPreciosPorDesc(txtFiltro.Text) : productoNegocio.ObtenerUltPrecioVenta();


                    default:
                        return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void listViewProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listViewProductos_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            try
            {
                if (e.Column != sortColumn)
                {
                    // Set the sort column to the new column.
                    sortColumn = e.Column;
                    // Set the sort order to ascending by default.
                    listViewProductos.Sorting = SortOrder.Ascending;
                }
                else
                {
                    // Determine what the last sort order was and change it.
                    listViewProductos.Sorting = listViewProductos.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
                }
                // Call the sort method to manually sort.
                listViewProductos.Sort();
                // Set the ListViewItemSorter property to a new ListViewItemComparer
                // object.
                listViewProductos.ListViewItemSorter = new ListViewItemComparer(e.Column, listViewProductos.Sorting);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void listViewProductos_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SeleccionProducto();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SeleccionProducto()
        {
            try
            {
                IdProducto = Convert.ToInt32(listViewProductos.SelectedItems[0].Tag);

                if (IdProducto > 0)
                {
                    btnEditar.Enabled = true;
                }

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void listViewProductos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                SeleccionProducto();
                var frm = new frmPrecios(IdProducto);
                frm.ShowDialog();
                btnEditar.Enabled = false;
                Llenarlistview(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var frm = new frmPrecios(Convert.ToInt32(listViewProductos.SelectedItems[0].Tag));
            frm.ShowDialog();
            btnEditar.Enabled = false;
            Llenarlistview(false);

            //var frm = new frmPrecios { IdProducto = IdProducto };
            // Suscribirse al evento FormClosed
            //frm.FormClosed += (s, args) => Llenarlistview(true);

            //OpenChildForm(frm, sender);
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

        private void listViewProductos_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listViewProductos.SelectedItems.Count > 0)
            {
                SeleccionProducto();
            }
            else
            {
                IdProducto = 0;
                btnEditar.Enabled = false;
            }
        }

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter) { Llenarlistview(false); }
                txtFiltro.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Llenarlistview(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
