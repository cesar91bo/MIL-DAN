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
    public partial class frmConsultaFacturas : Form
    {
        public frmConsultaFacturas()
        {
            InitializeComponent();
        }

        private void frmConsultaFacturas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'sistemaGestionPymeBDDataSet.Clientes' Puede moverla o quitarla según sea necesario.
           // this.clientesTableAdapter.Fill(this.sistemaGestionPymeBDDataSet.Clientes);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<CapaDatos.Modelos.Clientes> clientes = new ClienteNegocio().ListaClientes();
            dataGridViewConsulta.DataSource = clientes;
        }
    }
}
