using CapaNegocio;
using System;
using System.Collections;
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
    public partial class frmListaProductos : FormBase
    {
        public int IdProducto;
        List<CapaDatos.Modelos.VistaProducto> productos;
        private int sortColumn = -1;
        public bool Seleccion;
        public frmListaProductos()
        {
            InitializeComponent();
        }

        private void frmListaProductos_Load(object sender, EventArgs e)
        {
            var dt = new DataTable();
            dt.Columns.Add("IdBusqueda");
            dt.Columns.Add("Descripcion");

            dt.Rows.Add("DescCorta", "Descripción Corta");
            dt.Rows.Add("IdProducto", "Nº Producto");
            dt.Rows.Add("Rubro", "Rubro");
            cmbFiltro.DataSource = dt;
            cmbFiltro.DisplayMember = "Descripcion";
            cmbFiltro.ValueMember = "IdBusqueda";
            cmbFiltro.SelectedValue = "DescCorta";

            CrearColListView();
            Llenarlistview(true);
        }

        private void DarDeBaja(object sender, EventArgs e)
        {
            if (listViewProductos.FocusedItem != null)
            {
                DialogResult result = MessageBox.Show($"¿Está seguro de dar de baja el producto {listViewProductos.FocusedItem.Text}?",
                                                      "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    listViewProductos.Items.Remove(listViewProductos.FocusedItem);
                    MessageBox.Show("Producto dado de baja.");
                    // Aquí podrías actualizar la base de datos o cambiar el estado del producto
                }
            }
        }

        private void CargarPrecio(object sender, EventArgs e)
        {
            if (listViewProductos.FocusedItem != null)
            {
                MessageBox.Show($"Cargar precio del producto: {listViewProductos.FocusedItem.Text}");
                // Aquí podrías abrir una ventana para ingresar el nuevo precio
            }
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
            listViewProductos.Columns.Add("Nro.Producto", 70, HorizontalAlignment.Left);
            listViewProductos.Columns.Add("Nombre", 300, HorizontalAlignment.Left);
            listViewProductos.Columns.Add("Lleva Stock", 85, HorizontalAlignment.Left);
            listViewProductos.Columns.Add("Stock", 85, HorizontalAlignment.Left);
            listViewProductos.Columns.Add("U.Medida", 100, HorizontalAlignment.Left);
            listViewProductos.Columns.Add("Rubro", 125, HorizontalAlignment.Left);
            listViewProductos.Columns.Add("Fecha Baja", 90, HorizontalAlignment.Left);
        }

        private void Llenarlistview(bool siload)
        {
            listViewProductos.Items.Clear();

            if (siload)
            {
                var productoNegocio = new ProductoNegocio();
                productos = productoNegocio.ObtenerTodo();
            }
            else
            {
                productos = BuscarProducto();
            }

            if (productos == null) return;
            foreach (CapaDatos.Modelos.VistaProducto prods in productos)
            {
                var item = new ListViewItem
                {
                    Tag = prods.IdProducto.ToString(),
                    Text = prods.IdProducto.ToString()
                };
                item.SubItems.Add(prods.DescCorta);
                item.SubItems.Add(prods.LlevarStock.ToString());
                item.SubItems.Add(prods.StockActual.ToString());
                item.SubItems.Add(prods.UnidadMedida.ToString());
                item.SubItems.Add(prods.Rubro.ToString());

                item.SubItems.Add(prods.FechaBaja.ToString());
                if (prods.FechaBaja.ToString() != "") { item.ForeColor = Color.Red; }
                listViewProductos.Items.Add(item);
                listViewProductos.Focus();
            }
        }

        private List<CapaDatos.Modelos.VistaProducto> BuscarProducto()
        {
            throw new NotImplementedException();
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
                    DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void listViewProductos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try { SeleccionProducto(); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listViewProductos_MouseClick(object sender, MouseEventArgs e)
        {
            try { SeleccionProducto(); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
