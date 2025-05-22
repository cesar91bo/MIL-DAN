using CapaDatos.Modelos;
using CapaNegocio;
using SistemaFacturacionInventario.Auxiliares;
using System;
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
    public partial class frmPrecioLote : FormBase
    {
        public int IdProducto;
        List<CapaDatos.Modelos.VistaPreciosVenta> precios;
        private bool _actualizandoLista = false;
        public frmPrecioLote()
        {
            InitializeComponent();
        }

        private void frmPrecioLote_Load(object sender, EventArgs e)
        {
            var dt = new DataTable();
            dt.Columns.Add("IdBusqueda");
            dt.Columns.Add("Descripcion");

            dt.Rows.Add("DescCorta", "Descripción Corta");
            dt.Rows.Add("IdProducto", "Nº Producto");
            dt.Rows.Add("IdRubro", "Categoría");

            cmbFiltro.DisplayMember = "Descripcion";
            cmbFiltro.ValueMember = "IdBusqueda";
            cmbFiltro.DataSource = dt;
            cmbFiltro.SelectedValue = "DescCorta"; 

            CrearColListView();
            LlenarlistProducto(true);

            listViewProdSelec.CheckBoxes = true;
            listViewProdSelec.ItemChecked += listViewProdSelec_ItemChecked;


        }
        private void CrearColListView()
        {
            listViewProductos.Columns.Add("Nro.Producto", 100, HorizontalAlignment.Center);
            listViewProductos.Columns.Add("Nombre", 250, HorizontalAlignment.Left);
            listViewProductos.Columns.Add("Precio Contado Con IVA", 100, HorizontalAlignment.Left);
            listViewProductos.Columns.Add("Precio Contado Sin IVA", 100, HorizontalAlignment.Left);
            listViewProductos.Columns.Add("Fecha de Precio", 100, HorizontalAlignment.Left);
            listViewProductos.Columns.Add("Precio Base", 100, HorizontalAlignment.Left);
            listViewProductos.Columns.Add("% Ganancia", 100, HorizontalAlignment.Left);

            listViewProdSelec.Columns.Add("Nro.Producto", 100, HorizontalAlignment.Center);
            listViewProdSelec.Columns.Add("Nombre", 250, HorizontalAlignment.Left);
            listViewProdSelec.Columns.Add("Precio Contado Con IVA", 100, HorizontalAlignment.Left);
            listViewProdSelec.Columns.Add("Precio Contado Sin IVA", 100, HorizontalAlignment.Left);
            listViewProdSelec.Columns.Add("Fecha de Precio", 100, HorizontalAlignment.Left);
            listViewProdSelec.Columns.Add("Precio Base", 100, HorizontalAlignment.Left);
            listViewProdSelec.Columns.Add("% Ganancia", 100, HorizontalAlignment.Left);


        }

        private void LlenarlistProducto(bool siload)
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

            foreach (var precio in precios)
            {
                var item = new ListViewItem
                {
                    Tag = precio.IdProducto.ToString(),
                    Text = "      " + precio.IdProducto.ToString()
                };

                item.SubItems.Add(precio.DescCorta);
                item.SubItems.Add(precio.PrecioContadoIva.ToString("N2"));  // 1.234,56 formato regional
                item.SubItems.Add(precio.PrecioContado.ToString("N2"));
                item.SubItems.Add(precio.FechaPrecio.ToString("dd-MM-yyyy"));
                item.SubItems.Add(precio.PrecioBase.ToString("N2"));
                item.SubItems.Add((precio.PorcentajeGcia).ToString("N2"));

                listViewProductos.Items.Add(item);
            }

            listViewProductos.Focus();
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

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter) { LlenarlistProducto(false); }
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
                LlenarlistProducto(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AgregarItemSeleccionado(ListViewItem itemOriginal)
        {
            // Evitar duplicados
            foreach (ListViewItem it in listViewProdSelec.Items)
            {
                if (it.Text == itemOriginal.Text)
                    return;
            }

            var nuevoItem = new ListViewItem(itemOriginal.Text); // Nro.Producto

            for (int i = 1; i < itemOriginal.SubItems.Count; i++)
            {
                nuevoItem.SubItems.Add(itemOriginal.SubItems[i].Text);
            }

            listViewProdSelec.Items.Add(nuevoItem);
        }

        private void EliminarItemSeleccionado(string idProducto)
        {
            foreach (ListViewItem it in listViewProdSelec.Items)
            {
                if (it.Text == idProducto)
                {
                    listViewProdSelec.Items.Remove(it);
                    break;
                }
            }
        }

        private void listViewProductos_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (_actualizandoLista) return;

            _actualizandoLista = true;

            try
            {
                // Si fue desmarcado, lo quitamos de la lista seleccionada
                if (!e.Item.Checked)
                {
                    foreach (ListViewItem item in listViewProdSelec.Items)
                    {
                        if (item.Text == e.Item.Text) // comparar por ID de producto
                        {
                            listViewProdSelec.Items.Remove(item);
                            break;
                        }
                    }
                }
                else
                {
                    // Si fue marcado, agregarlo
                    var nuevoItem = (ListViewItem)e.Item.Clone();
                    listViewProdSelec.Items.Add(nuevoItem);
                }
            }
            finally
            {
                _actualizandoLista = false;
            }
        }

        private void listViewProdSelec_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (!e.Item.Checked)
            {
                // Usamos BeginInvoke para diferir la eliminación hasta que termine el evento
                this.BeginInvoke(new Action(() =>
                {
                    listViewProdSelec.Items.Remove(e.Item);
                }));
            }
        }
    }
}
