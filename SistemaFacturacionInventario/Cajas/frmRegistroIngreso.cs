﻿using CapaDatos.Modelos;
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

namespace SistemaFacturacionInventario.Cajas
{
    public partial class frmRegistroIngreso : Form
    {
        private CajaNegocio cajaNegocio = new CajaNegocio();
        private CapaDatos.Modelos.Cajas Caja;
        public frmRegistroIngreso()
        {
            InitializeComponent();
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            if (Validaciones())
            {
                CajasIngresos cajasIngresos = new CajasIngresos();
                cajasIngresos.Monto = Convert.ToDecimal(txtMonto.Text);
                cajasIngresos.Motivo = txtMotivo.Text;
                cajasIngresos.IdCaja = cajaNegocio.ObtenerCajaActual().IdCaja;

                var resultado = cajaNegocio.GuardarIngreso(cajasIngresos);

                if (resultado.EsExitoso)
                {
                    MessageBox.Show(resultado.Mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show(resultado.Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Close();
            }
        }
        private void LimpiarFormulario()
        {
            txtMotivo.Text = string.Empty;
            txtMonto.Text = string.Empty;
            Caja = null;
        }

        private bool Validaciones()
        {
            error.Clear();

            if (string.IsNullOrWhiteSpace(txtMotivo.Text))
            {
                error.SetError(txtMotivo, "Debe ingresar un motivo.");
                txtMotivo.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtMonto.Text))
            {
                error.SetError(txtMonto, "Debe ingresar un monto.");
                txtMonto.Focus();
                return false;
            }
            Caja = cajaNegocio.ObtenerCajaActual();
            if (Caja == null || Caja.Estado != "Abierto")
            {

                DialogResult respuesta = MessageBox.Show("No se abrió ninguna caja para el día de hoy. ¿Desea hacerlo ahora?", "Caja no abierta",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    frmAperturaCaja frm = new frmAperturaCaja();
                    frm.ShowDialog();

                    Caja = cajaNegocio.ObtenerCajaActual();
                    if (Caja == null || Caja.IdCaja == 0)
                    {
                        MessageBox.Show("No se pudo abrir la caja. Operación cancelada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Debe abrir una caja para continuar.", "Operación cancelada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            decimal totalIngreso = Convert.ToDecimal(txtMonto.Text);
            var resultado = cajaNegocio.EditarMontoCaja(totalIngreso, 0, Caja.IdCaja);
            if (resultado.EsExitoso == false)
            {
                MessageBox.Show(resultado.Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return true;
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            // Solo permitir un punto decimal
            TextBox textBox = sender as TextBox;
            if (e.KeyChar == '.' && textBox.Text.Contains("."))
            {
                e.Handled = true;
            }
        }
    }
}
