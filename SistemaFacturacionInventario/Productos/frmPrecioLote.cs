using CapaDatos;
using CapaDatos.Modelos;
using CapaNegocio;
using SistemaFacturacionInventario.Auxiliares;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        ProductoNegocio productoNegocio = new ProductoNegocio();
        private Seteos seteos = new Seteos();
        public frmPrecioLote()
        {
            InitializeComponent();
        }

        private void frmPrecioLote_Load(object sender, EventArgs e)
        {
            LlenarComboCategoria();

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

        private void LlenarComboCategoria()
        {
            try
            {
                var rep = new AuxiliaresNegocio();
                cmbCategoria.DisplayMember = "Descripcion";
                cmbCategoria.ValueMember = "IdRubro";
                cmbCategoria.DataSource = rep.ObtenerRubros();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
                //var productoNegocio = new ProductoNegocio();
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

                if (chkFiltrar.Checked)
                {
                    // Validar que haya una categoría seleccionada
                    if (cmbCategoria.SelectedValue == null)
                    {
                        MessageBox.Show("Debe seleccionar una categoría.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return null;
                    }

                    int idRubro;
                    if (int.TryParse(cmbCategoria.SelectedValue.ToString(), out idRubro))
                    {
                        return productoNegocio.ObtenerListPreciosPorRubro(idRubro);
                    }
                    else
                    {
                        MessageBox.Show("Categoría inválida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                }
                else
                {
                    // Buscar por texto libre si no está el filtro activado
                    if (string.IsNullOrWhiteSpace(txtFiltro.Text))
                    {
                        MessageBox.Show("Ingrese texto de búsqueda.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return null;
                    }

                    return productoNegocio.ObtenerListPreciosPorDesc(txtFiltro.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar precios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
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

                        // Intentamos leer el porcentaje y aplicar el cálculo
                        if (decimal.TryParse(txtPorcCambio.Text, out decimal porcCambio))
                        {
                            bool aumentar = rbAumentar.Checked;
                            RecalcularValoresItem(nuevoItem, porcCambio, aumentar);
                        }

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

        private void RecalcularValoresItem(ListViewItem item, decimal porcCambio, bool aumentar)
        {
            decimal iva = 21m; // O toma esta variable desde donde la tengas definida

            if (decimal.TryParse(item.SubItems[5].Text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal precioBase) &&
                decimal.TryParse(item.SubItems[6].Text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal porcentajeGanancia))
            {
                decimal factor = aumentar ? (1 + porcCambio / 100m) : (1 - porcCambio / 100m);
                decimal nuevoPrecioBase = Math.Round(precioBase * factor, 2);
                item.SubItems[5].Text = nuevoPrecioBase.ToString("N2");

                decimal precioContado = Math.Round(nuevoPrecioBase * (1 + porcentajeGanancia / 100m), 2);
                item.SubItems[3].Text = precioContado.ToString("N2");

                decimal precioContadoIva = Math.Round(precioContado * (1 + iva / 100m), 2);
                item.SubItems[2].Text = precioContadoIva.ToString("N2");

                item.SubItems[4].Text = DateTime.Now.ToString("dd/MM/yyyy");
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
            if (listViewProdSelec.Items.Count == 0)
            {
                MessageBox.Show("No hay productos seleccionados para guardar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Salir para no continuar con la lógica
            }
            var difCambio = txtPorcCambio.Text != "" ? Convert.ToDecimal(txtPorcCambio.Text) : 0;
            if(difCambio != seteos.PorcentajeDiferencia)
            {
                seteos.PorcentajeDiferencia = difCambio;
                auxiliaresNegocio.ActualizarSeteos(seteos);
            }

            List<PrecioActualizadoDto> listaActualizada = new List<PrecioActualizadoDto>();

            foreach (ListViewItem item in listViewProdSelec.Items)
            {
                listaActualizada.Add(new PrecioActualizadoDto
                {
                    IdProducto = int.Parse(item.SubItems[0].Text),
                    PrecioContadoIva = decimal.Parse(item.SubItems[2].Text),
                    PrecioContado = decimal.Parse(item.SubItems[3].Text),
                    FechaPrecio = DateTime.ParseExact(item.SubItems[4].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    PrecioBase = decimal.Parse(item.SubItems[5].Text),
                    PorcentajeGanancia = decimal.Parse(item.SubItems[6].Text)
                });
            }

            productoNegocio.ActualizarPrecios(listaActualizada);

            MessageBox.Show("Precios actualizados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LlenarlistProducto(true);
            listViewProdSelec.Items.Clear();
            cmbCategoria.SelectedIndex =  1; // Limpiar selección del combo
            chkFiltrar.Checked = false; // Desmarcar el checkbox
            txtFiltro.Clear();
           
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

        private void chkFiltrar_CheckedChanged(object sender, EventArgs e)
        {
            cmbCategoria.Enabled = chkFiltrar.Checked;
        }
    }
}
