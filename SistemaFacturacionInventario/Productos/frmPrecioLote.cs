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
        private AuxiliaresNegocio auxiliaresNegocio = new AuxiliaresNegocio();
        private Seteos seteos = new Seteos();
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
            listViewProductos.CheckBoxes = true;

            listViewProductos.ItemChecked += listViewProductos_ItemChecked;
            listViewProdSelec.ItemChecked += listViewProdSelec_ItemChecked; 

            seteos = auxiliaresNegocio.ObtenerSeteo();
            var porcentajeDiferencia = seteos.PorcentajeDiferencia ?? 0;
            txtPorcCambio.Text = porcentajeDiferencia.ToString("N2"); // Formato de número con 2 decimales
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

        private void listViewProductos_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (_actualizandoLista) return;

            _actualizandoLista = true;

            try
            {
                if (e.Item.Checked)
                {
                    // Agrego el item a la segunda grilla solo si no está ya
                    bool existe = false;
                    foreach (ListViewItem it in listViewProdSelec.Items)
                    {
                        if (it.Text == e.Item.Text)
                        {
                            existe = true;
                            break;
                        }
                    }
                    if (!existe)
                    {
                        var nuevoItem = (ListViewItem)e.Item.Clone();
                        nuevoItem.Checked = true; // check por defecto
                        listViewProdSelec.Items.Add(nuevoItem);
                    }
                }
                else
                {
                    // Desmarcó en primera grilla => quito el item de segunda grilla
                    for (int i = listViewProdSelec.Items.Count - 1; i >= 0; i--)
                    {
                        if (listViewProdSelec.Items[i].Text == e.Item.Text)
                        {
                            listViewProdSelec.Items.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
            finally
            {
                _actualizandoLista = false;
            }
        }

        private void listViewProdSelec_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (_actualizandoLista) return;

            if (!e.Item.Checked)
            {
                // Cuando el checkbox se desmarca, elimina ese item de la segunda grilla
                this.BeginInvoke(new Action(() =>
                {
                    listViewProdSelec.Items.Remove(e.Item);
                }));

                // Además, sincronizar en la primera grilla para desmarcar el checkbox correspondiente
                for (int i = 0; i < listViewProductos.Items.Count; i++)
                {
                    if (listViewProductos.Items[i].Text == e.Item.Text)
                    {
                        _actualizandoLista = true;
                        listViewProductos.Items[i].Checked = false;
                        _actualizandoLista = false;
                        break;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var difCambio = txtPorcCambio.Text != "" ? Convert.ToDecimal(txtPorcCambio.Text) : 0;
            if(difCambio != seteos.PorcentajeDiferencia)
            {
                seteos.PorcentajeDiferencia = difCambio;
                auxiliaresNegocio.ActualizarSeteos(seteos);
            }
        }

        private void txtPorcCambio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir teclas de control como backspace
            if (char.IsControl(e.KeyChar))
                return;

            // Permitir solo dígitos y un único punto decimal
            TextBox txt = sender as TextBox;

            if (char.IsDigit(e.KeyChar))
            {
                return; // permitir dígitos
            }
            else if (e.KeyChar == '.' && !txt.Text.Contains('.'))
            {
                return; // permitir un solo punto decimal
            }
            else
            {
                e.Handled = true; // bloquear todo lo demás
            }
        }
    }
}
