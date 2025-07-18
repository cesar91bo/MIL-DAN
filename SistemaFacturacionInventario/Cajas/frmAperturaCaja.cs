﻿using CapaNegocio;
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
    public partial class frmAperturaCaja : Form
    {
        private CajaNegocio cajaNegocio = new CajaNegocio();
        public frmAperturaCaja()
        {
            InitializeComponent();
        }

        private void txtMontoInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private bool Validaciones()
        {
            if (string.IsNullOrWhiteSpace(txtMontoInicial.Text))
            {
                MessageBox.Show("Debe ingresar un monto inicial para abrir la caja.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMontoInicial.Focus();
                return false;
            }

            var ultimaCaja = cajaNegocio.ObtenerUltimaCaja();

            if (ultimaCaja != null && ultimaCaja.FechaCierre == null)
            {
                MessageBox.Show("No se puede abrir una nueva caja mientras la anterior esté abierta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return false;
            }

            return true;
        }

        private void btnAbrirCaja_Click(object sender, EventArgs e)
        {
            if (Validaciones())
            {
                CapaDatos.Modelos.Cajas caja = new CapaDatos.Modelos.Cajas
                {
                    FechaApertura = DateTime.Now,
                    MontoInicial = Convert.ToDecimal(txtMontoInicial.Text),
                    UsuarioApertura = 1,
                    Estado = "Abierto"
                };

                bool apertura = cajaNegocio.NuevaCaja(caja);

                if (apertura)
                {
                    MessageBox.Show("La caja fue abierta correctamente.");
                }
                else
                {
                    MessageBox.Show("No se pudo abrir la caja. Intente nuevamente.", "ERROR CAJA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
            }
        }
    }
}
