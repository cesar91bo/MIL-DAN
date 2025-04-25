using CapaDatos.Modelos;
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

namespace SistemaFacturacionInventario.Facturacion
{
    public partial class frmAnularFactura : FormBase
    {
        public int idFactura = 0;
        private FacturacionNegocio facturacionNegocio = new FacturacionNegocio();
        private FacturasVenta facturaVenta = new FacturasVenta();
        public frmAnularFactura()
        {
            InitializeComponent();
        }

        private void frmAnularFactura_Load(object sender, EventArgs e)
        {
            LLenarCampos();
        }

        private void LLenarCampos()
        {
            facturaVenta = facturacionNegocio.ObtenerFactura(idFactura);

            if (facturaVenta != null) 
            {
            }
        }
    }
}
