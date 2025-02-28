using CapaDatos.Modelos;
using CapaNegocio;
using SistemaFacturacionInventario.Auxiliares;
using SistemaFacturacionInventario.Productos;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace SistemaFacturacionInventario.Clientes
{
    public partial class frmCliente : FormBase
    {
        public string Accion;
        public Int32 IdCliente;
        public bool VienedeFact;
        private Form activeForm;
        public frmCliente()
        {
            InitializeComponent();
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            try
            {
                var auxiliaresNegocio = new AuxiliaresNegocio();
                cmbProvincia.DisplayMember = "Provincia";
                cmbProvincia.ValueMember = "IdProvincia";
                cmbProvincia.DataSource = auxiliaresNegocio.ObtenerProvincias();
                cmbProvincia.SelectedValue = 7;
                cmbTipoDoc.DisplayMember = "TipoDocumento";
                cmbTipoDoc.ValueMember = "TipoDocumento";
                cmbTipoDoc.DataSource = auxiliaresNegocio.ObtenerTiposDoc();
                cmbRegimen.DisplayMember = "Descripcion";
                cmbRegimen.ValueMember = "IdRegimenImpositivo";
                cmbRegimen.DataSource = auxiliaresNegocio.ObtenerRegimenes();
                activeForm = new frmCliente();

                cargarLocalidades(Convert.ToInt16(cmbProvincia.SelectedValue));
                cmbLocalidad.SelectedValue = "3531-1";

                if (Accion == "MOD")
                {
                    if (IdCliente > 0) BuscarCliente(IdCliente);
                    else
                    {

                        txtNroCliente.Visible = true;
                        btnBuscar.Visible = true;
                        btnListado.Visible = true;
                    }
                }
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BuscarCliente(int nroCliente)
        {
            try
            {
                var clienteNegocio = new ClienteNegocio();
                CapaDatos.Modelos.Clientes cli = clienteNegocio.ObtenerCliporNroCli(nroCliente);
                var aux = new AuxiliaresNegocio();
                if (cli != null)
                {
                    if (cli.FechaBaja == null)
                    {
                        IdCliente = cli.IdCliente;
                        txtNroCliente.Text = IdCliente.ToString();
                        txtNroCliente.Enabled = true;
                        btnBuscar.Enabled = true;
                        btnListado.Enabled = true;
                        btnBaja.Enabled = true;

                        CPostales CP = aux.ObtenerDatosCP(cli.CodigoPostal, cli.SubCodigoPostal);
                        txtNombre.Text = cli.Nombre;
                        txtApellido.Text = cli.Apellido;
                        txtDireccion.Text = cli.Direccion;
                        cmbProvincia.SelectedValue = CP.IdProvincia;
                        cmbLocalidad.SelectedValue = CP.CodigoPostal + "-" + CP.SubCodigoPostal;
                        txtCuit0.Text = cli.Cuit0;
                        txtCuit1.Text = cli.Cuit1;
                        txtCuit2.Text = cli.Cuit2;
                        cmbRegimen.SelectedValue = cli.IdRegimenImpositivo;

                        cmbTipoDoc.SelectedValue = cli.TipoDocumento ?? "-";
                        txtNumDoc.Text = cli.Documento.ToString();
                        if (cli.FechaNacimiento != null) dtpFechaNac.Value = Convert.ToDateTime(cli.FechaNacimiento);
                        txtTelefono.Text = cli.Telefono;
                        btnGuardar.Enabled = true;

                        Validaciones();
                    }
                    else { MessageBox.Show("El Cliente fue dado de baja", "Error de Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); this.Close(); }
                }
                else MessageBox.Show("No se encontró el Cliente", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex) { throw ex; }
        }

        private void cargarLocalidades(Int16 IdProv)
        {
            try
            {
                var auxiliaresNegocio = new AuxiliaresNegocio();
                DataTable dt = auxiliaresNegocio.DTCP(IdProv);
                cmbLocalidad.DisplayMember = "Localidad";
                cmbLocalidad.ValueMember = "CpSubCp";
                cmbLocalidad.DataSource = dt;
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validaciones())
                {
                    var clienteNegocio = new ClienteNegocio();
                    if (cmbTipoDoc.SelectedValue.ToString() == "CUIT")
                    {
                        List<CapaDatos.Modelos.Clientes> cuit = clienteNegocio.ObtenerClientesCargadosCUIT(Convert.ToInt64(txtCuit1.Text), cmbTipoDoc.SelectedValue.ToString());
                        if (cuit.Count > 1)
                        {
                            if (Accion.ToUpper() == "ALTA")
                            {
                                if (MessageBox.Show(
                                        "Se ha encontrado un Cliente con el mismo número de CUIT, ¿Desea cargarlo de todas formas?",
                                        "CUIT ENCONTRADO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                                    DialogResult.No)
                                {
                                    lblErrores.Text = "Está registrando un Cliente con un mismo CUIT";
                                    return;
                                }
                            }
                            else
                            {
                                if (MessageBox.Show(
                                        "Se ha encontrado un Cliente con el mismo número de CUIT, ¿Desea editarlo de todas formas?",
                                        "CUIT ENCONTRADO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                                    DialogResult.No)
                                {
                                    lblErrores.Text = "Ya ha ingresado un Cliente con este CUIT";
                                    return;
                                }
                            }
                        }
                    }
                    var cli = new CapaDatos.Modelos.Clientes
                    {
                        Nombre = txtNombre.Text,
                        Apellido = txtApellido.Text,
                        Direccion = txtDireccion.Text,
                        Email = txtEmail.Text,
                        Telefono = txtTelefono.Text,
                        Estado = "Activo",
                        FechaRegistro = DateTime.Now
                    };
                    cli.CodigoPostal = Convert.ToInt16(cmbLocalidad.SelectedValue.ToString().Substring(0, 4));
                    cli.SubCodigoPostal = Convert.ToByte(cmbLocalidad.SelectedValue.ToString().Substring(5));
                    cli.FechaNacimiento = (dtpFechaNac.Checked) ? Convert.ToDateTime(dtpFechaNac.Text) : (DateTime?)null;
                    cli.IdRegimenImpositivo = Convert.ToInt16(cmbRegimen.SelectedValue);
                    switch (cmbTipoDoc.SelectedValue.ToString())
                    {
                        case "CUIL":
                            cli.Cuit0 = txtCuit0.Text;
                            cli.Cuit1 = txtCuit1.Text;
                            cli.Cuit2 = txtCuit2.Text;
                            cli.TipoDocumento = "CUIL";
                            cli.Documento = null;
                            break;

                        case "CUIT":
                            cli.Cuit0 = txtCuit0.Text;
                            cli.Cuit1 = txtCuit1.Text;
                            cli.Cuit2 = txtCuit2.Text;
                            cli.TipoDocumento = "CUIT";
                            cli.Documento = null;
                            break;

                        case "-":
                            cli.Cuit0 = null;
                            cli.Cuit1 = null;
                            cli.Cuit2 = null;
                            cli.TipoDocumento = "-";
                            cli.Documento = null;
                            break;

                        case "DNI":
                            cli.Cuit0 = null;
                            cli.Cuit1 = null;
                            cli.Cuit2 = null;
                            cli.TipoDocumento = cmbTipoDoc.SelectedValue.ToString();
                            cli.Documento = Convert.ToInt32(txtNumDoc.Text);
                            break;

                        default:
                            cli.Cuit0 = null;
                            cli.Cuit1 = null;
                            cli.Cuit2 = null;
                            cli.TipoDocumento = cmbTipoDoc.SelectedValue.ToString();
                            cli.Documento = Convert.ToInt32(txtNumDoc.Text);
                            break;
                    }
                    if (Accion == "ALTA")
                    {
                        Int32 NroCli = clienteNegocio.NuevoCliente(cli);
                        if (NroCli > 0)
                        {
                            MessageBox.Show("El cliente se ingresó correctamente." + Environment.NewLine +
                            "Nro.Cliente: " + NroCli, "ALTA CORRECTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (VienedeFact)
                            {
                                IdCliente = NroCli;
                                DialogResult = DialogResult.OK;
                            }
                            LimpiarCampos();
                        }
                    }
                    else if (Accion == "MOD")
                    {
                        clienteNegocio.EditarCliente(cli, IdCliente);
                        MessageBox.Show("El cliente se editó correctamente.", "EDICIÓN CORRECTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        IdCliente = 0;
                        if (txtNroCliente.Visible == false)
                        {
                            this.Close();
                        }
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            cmbProvincia.SelectedValue = 7;
            cargarLocalidades(Convert.ToInt16(cmbProvincia.SelectedValue));
            cmbLocalidad.SelectedValue = "3531-1";
            txtDireccion.Text = string.Empty;
            cmbRegimen.SelectedValue = 1;
            cmbTipoDoc.SelectedValue = "CUIT";
            txtCuit0.Text = string.Empty;
            txtCuit1.Text = string.Empty;
            txtCuit2.Text = string.Empty;
            txtNumDoc.Text = string.Empty;
            dtpFechaNac.Value = DateTime.Now;
            dtpFechaNac.Checked = false;
            txtTelefono.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtComentario.Text = string.Empty;
            IdCliente = 0;
        }

        private bool Validaciones()
        {
            try
            {
                bool Correcto = true;
                List<string> errores = new List<string>();

                if (cmbLocalidad.SelectedValue == null)
                {
                    errores.Add("Ingrese una localidad existente");
                    Correcto = false;
                }

                if (txtNombre.Text.All(char.IsWhiteSpace))
                {
                    errores.Add("Ingrese el Nombre");
                    Correcto = false;
                }

                if (txtApellido.Text.All(char.IsWhiteSpace))
                {
                    errores.Add("Ingrese el Apellido");
                    Correcto = false;
                }

                if (txtNombre.Text.All(char.IsNumber) || txtApellido.Text.All(char.IsNumber))
                {
                    errores.Add("Nombre o apellido invalido");
                    Correcto = false;
                }

                if (txtDireccion.Text == "")
                {
                    txtDireccion.Text = "-";
                }
                if (cmbRegimen.SelectedValue.ToString() == "1" || cmbTipoDoc.SelectedValue.ToString() == "CUIT") //Resp Inscripto
                {

                    if (txtCuit0.Text.Length != 2)
                    {
                        errores.Add("Ingrese Nro.Cuit correcto");
                        Correcto = false;
                    }
                }
                else
                {
                    if (cmbTipoDoc.SelectedValue.ToString() != "-")
                    {
                        if (txtNumDoc.Text == "")
                        {
                            errores.Add("Si selecciona un Tipo Doc. deberá ingresar un nro. de documento" + Environment.NewLine +
                                "Sino quiere ingresar Nro.Documento seleccione el Tipo de Documento: '-'");
                            Correcto = false;
                        }
                        else
                        {
                            if (cmbTipoDoc.SelectedValue.ToString() == "DNI")
                            {
                                if (txtNumDoc.Text.Length < 8)
                                {
                                    errores.Add("Faltan números por ingresar");
                                    Correcto = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (txtNumDoc.Text != "")
                        {
                            errores.Add("No se puede ingresar Numero de Documento para el Tipo de Documento '-'" + Environment.NewLine +
                                                      "Si quiere ingresar un valor para este campo seleccione un Tipo de Documento diferente");
                            Correcto = false;
                        }
                    }
                }
                if (!Correcto)
                {
                    lblErrores.Text = string.Join("\n", errores);
                    lblErrores.Visible = true;
                    return false;
                }

                var clienteNegocio = new ClienteNegocio();

                if (cmbTipoDoc.SelectedValue.ToString() == "DNI" || cmbTipoDoc.SelectedValue.ToString() == "LC" || cmbTipoDoc.SelectedValue.ToString() == "LE" || cmbTipoDoc.SelectedValue.ToString() == "CUIL")
                {
                    if (txtNumDoc.Text == "0") return Correcto;

                    var cli = clienteNegocio.ObtenerClientesCargadosDni(Convert.ToInt64(txtNumDoc.Text), cmbTipoDoc.SelectedValue.ToString());

                    if (cli == null || cli.Exists(c => c.IdCliente == IdCliente) || !cli.Any()) return true;

                    if (MessageBox.Show("Se ha encontrado un cliente con el mismo número de Documento, ¿desea cargarlo de todas formas?", "DOCUMENTO ENCONTRADO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        errores.Add("Ya ha ingresado Cliente con este número");
                        MessageBox.Show("Numero de Documento ya existente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Correcto = false;
                    }
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
                return Correcto;
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
            OpenChildForm(new frmListaClientes(), sender);
        }

        public void OpenChildForm(Form childForm, object btnSender)
        {
            MenuPrincipal principal = Application.OpenForms["MenuPrincipal"] as MenuPrincipal;
            if (principal != null)
            {
                this.Close();

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

        private void txtNumDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumEntero(e);
        }

        private void txtCuit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumEntero(e);
        }

        private void txtCuit2_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumEntero(e);
        }

        private void txtCuit0_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumEntero(e);
        }

        private void btnBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumEntero(e);
        }

        private void SoloNumEntero(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquea la entrada
            }
        }

        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbProvincia.SelectedValue == null) return;
                if (Convert.ToInt32(cmbProvincia.SelectedValue.ToString()) > 0) cargarLocalidades(Convert.ToInt16(cmbProvincia.SelectedValue));
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
                if (txtNroCliente.Text != "")
                {
                    IdCliente = Convert.ToInt32(txtNroCliente.Text);
                    BuscarCliente(IdCliente);
                }
                else
                {
                    MessageBox.Show("Ingrese Nro. de Cliente para realizar la búsqueda", "Error de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnListado_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmListaClientes(), sender);
        }

        private void cmbRegimen_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbRegimen.SelectedValue == null) return;
                if (Convert.ToInt16(cmbRegimen.SelectedValue) == 1 || Convert.ToInt16(cmbRegimen.SelectedValue) == 3 || Convert.ToInt16(cmbRegimen.SelectedValue) == 5) //Resp.Inscripto o Excento
                {
                    cmbTipoDoc.SelectedValue = "CUIT";
                    cmbTipoDoc.Enabled = false;
                }
                else
                {
                    cmbTipoDoc.SelectedValue = "-";
                    cmbTipoDoc.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCuit1_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtCuit1.Text.Length < 8)
                {
                    txtCuit1.Text = txtCuit1.Text.PadLeft(8, '0');
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbTipoDoc_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbTipoDoc.SelectedValue != null)
                {
                    if (cmbTipoDoc.SelectedValue.ToString() == "CUIT")
                    {
                        txtCuit0.Visible = true;
                        txtCuit1.Visible = true;
                        txtCuit2.Visible = true;
                        txtNumDoc.Visible = false;
                    }
                    else
                    {
                        txtCuit0.Visible = false;
                        txtCuit1.Visible = false;
                        txtCuit2.Visible = false;
                        txtNumDoc.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmCliente_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '(' && e.KeyChar != ')' && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void txtCuit1_TextChanged(object sender, EventArgs e)
        {
            if (txtCuit1.Text.Length > 8)
            {
                txtCuit1.Text = txtCuit1.Text.Substring(0, 8);
                txtCuit1.SelectionStart = txtCuit1.Text.Length; // Mantiene el cursor al final
            }
        }

        private void txtNumDoc_TextChanged(object sender, EventArgs e)
        {
            if (txtNumDoc.Text.Length > 8)
            {
                txtNumDoc.Text = txtNumDoc.Text.Substring(0, 8);
                txtNumDoc.SelectionStart = txtNumDoc.Text.Length; // Mantiene el cursor al final
            }
        }

        private void txtCuit2_TextChanged(object sender, EventArgs e)
        {
            if (txtCuit2.Text.Length > 1)
            {
                txtCuit2.Text = txtCuit2.Text.Substring(0, 1);
                txtCuit2.SelectionStart = txtCuit2.Text.Length; // Mantiene el cursor al final
            }
        }

        private void txtCuit0_TextChanged(object sender, EventArgs e)
        {
            if (txtCuit0.Text.Length > 2)
            {
                txtCuit0.Text = txtCuit0.Text.Substring(0, 2);
                txtCuit0.SelectionStart = txtCuit0.Text.Length; // Mantiene el cursor al final
            }
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            if (txtTelefono.Text.Length > 15)
            {
                txtTelefono.Text = txtTelefono.Text.Substring(0, 8);
                txtTelefono.SelectionStart = txtTelefono.Text.Length; // Mantiene el cursor al final
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Desea dar de baja al cliente '" + txtNombre.Text + " " + txtApellido.Text + "' ?", "CONFIRMAR BAJA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                var clienteNegocio = new ClienteNegocio();
                if (clienteNegocio.BajaCliente(IdCliente))
                {
                    MessageBox.Show("El Cliente fue dado de baja correctamente", "BAJA CORRECTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                OpenChildForm(new frmListaClientes(), sender);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
