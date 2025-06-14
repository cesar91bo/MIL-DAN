﻿using CapaDatos.Modelos;
using CapaNegocio;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Xml.Linq;
using Font = iTextSharp.text.Font;
using Paragraph = iTextSharp.text.Paragraph;

namespace SistemaFacturacionInventario.Cajas
{
    public partial class frmCaja : Form
    {
        List<CapaDatos.Modelos.Cajas> cajas = new List<CapaDatos.Modelos.Cajas>();
        CajaNegocio cajaNegocio = new CajaNegocio();
        public bool load;
        private FacturacionNegocio facturasVentaN = new FacturacionNegocio();
        public frmCaja()
        {
            InitializeComponent();
        }

        private void frmCaja_Load(object sender, EventArgs e)
        {
            CrearColList();
            LLenarListaFecha(load);
        }

        private void CrearColList()
        {
            listCaja.Columns.Add("Id Caja", 70, HorizontalAlignment.Left);
            listCaja.Columns.Add("Fecha Apertura", 110, HorizontalAlignment.Left);
            listCaja.Columns.Add("Fecha Cierre", 110, HorizontalAlignment.Left);
            listCaja.Columns.Add("Monto Inicial", 110, HorizontalAlignment.Left);
            listCaja.Columns.Add("Monto Final", 110, HorizontalAlignment.Left);
            listCaja.Columns.Add("Total Ventas", 110, HorizontalAlignment.Left);
            listCaja.Columns.Add("Total Ingreso", 110, HorizontalAlignment.Left);
            listCaja.Columns.Add("Total Egresos", 110, HorizontalAlignment.Left);
            listCaja.Columns.Add("Observaciones", 150, HorizontalAlignment.Left);
        }

        private void LLenarListaFecha(bool load)
        {
            listCaja.Items.Clear();
            DateTime desde = dtpDesde.Value.Date;
            DateTime hasta = dtpHasta.Value.Date;

            if (load)
            {
                cajas = cajaNegocio.ObtenerCajas();
            }
            else
            {
                cajas = cajaNegocio.ObtenerCajaPorFecha(desde, hasta);
            }

            if (cajas.Count > 0)
            {

                foreach (var caja in cajas)
                {
                    List<CajasEgresos> cajasEgresos = cajaNegocio.ObtenerCajaEgresoPorIdCaja(caja.IdCaja);
                    List<CajasIngresos> cajasIngresos = cajaNegocio.ObtenerCajasIngresosPorIdCaja(caja.IdCaja);

                    List<VistaCabFactVenta> facturasVentas = facturasVentaN.BuscarFacturasFechaDesdeFechaHasta(caja.FechaApertura.Date, caja.FechaApertura.Date);

                    ListViewItem item = new ListViewItem(caja.IdCaja.ToString());
                    item.SubItems.Add(caja.FechaApertura.ToString("dd/MM/yyyy HH:mm") ?? "");
                    item.SubItems.Add(caja.FechaCierre?.ToString("dd/MM/yyyy HH:mm") ?? "");
                    item.SubItems.Add((caja.MontoInicial).ToString("N2"));
                    item.SubItems.Add((caja.MontoFinal ?? 0.00m).ToString("N2"));
                    item.SubItems.Add(facturasVentas.Sum(f => f.Total).ToString("N2"));
                    item.SubItems.Add(cajasIngresos.Sum(c => c.Monto).ToString("N2"));
                    item.SubItems.Add(cajasEgresos.Sum(c => c.Monto).ToString("N2"));
                    item.SubItems.Add(caja.Observaciones ?? "");

                    listCaja.Items.Add(item);
                }
            }

        }

        private void checkHabilitar_CheckedChanged(object sender, EventArgs e)
        {
            if (checkHabilitar.Checked)
            {
                dtpDesde.Enabled = true;
                dtpHasta.Enabled = true;
                btnBuscar.Enabled = true;
            }
            else
            {
                dtpDesde.Enabled = false;
                dtpHasta.Enabled = false;
                btnBuscar.Enabled = false;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            LLenarListaFecha(false);
        }

        private void btnAbrirCaja_Click(object sender, EventArgs e)
        {
            CapaDatos.Modelos.Cajas caja = cajaNegocio.ObtenerCajaActual();
            if (caja != null && caja.FechaCierre == null)
            {
                MessageBox.Show("Ya existe una caja abierta para el día de hoy.");
                return;
            }
            var frmc = new frmAperturaCaja();

            frmc.ShowDialog();

            LLenarListaFecha(true);
        }

        private void btnIngleso_Click(object sender, EventArgs e)
        {
            CapaDatos.Modelos.Cajas cajaDiaria = cajaNegocio.ObtenerCajaActual();
            if (cajaDiaria == null)
            {
                DialogResult respuesta = MessageBox.Show("No se abrió ninguna caja para el día de hoy. ¿Desea hacerlo ahora?", "Caja no abierta",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    frmAperturaCaja frm = new frmAperturaCaja();
                    frm.ShowDialog();

                    cajaDiaria = cajaNegocio.ObtenerCajaActual();
                    if (cajaDiaria == null || cajaDiaria.IdCaja == 0)
                    {
                        MessageBox.Show("No se pudo abrir la caja. Operación cancelada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Debe abrir una caja para continuar.", "Operación cancelada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                }
            }

            var frmIngreso = new frmRegistroIngreso();
            frmIngreso.ShowDialog();

            LLenarListaFecha(true);
        }

        private void btnEgreso_Click(object sender, EventArgs e)
        {
            CapaDatos.Modelos.Cajas cajaDiaria = cajaNegocio.ObtenerCajaActual();
            if (cajaDiaria == null)
            {
                DialogResult respuesta = MessageBox.Show("No se abrió ninguna caja para el día de hoy. ¿Desea hacerlo ahora?", "Caja no abierta",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    frmAperturaCaja frm = new frmAperturaCaja();
                    frm.ShowDialog();

                    cajaDiaria = cajaNegocio.ObtenerCajaActual();
                    if (cajaDiaria == null || cajaDiaria.IdCaja == 0)
                    {
                        MessageBox.Show("No se pudo abrir la caja. Operación cancelada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Debe abrir una caja para continuar.", "Operación cancelada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                }
            }

            var frmEgreso = new frmRegistroEgreso();
            frmEgreso.ShowDialog();

            LLenarListaFecha(true);
        }

        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            CapaDatos.Modelos.Cajas cajaDiaria = cajaNegocio.ObtenerUltimaCaja();

            if (cajaDiaria == null)
            {
                MessageBox.Show("No se puede cerrar la caja. No hay una caja abierta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cajaDiaria.FechaCierre != null)
            {
                MessageBox.Show("La caja ya fue cerrada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var frmCierra = new frmCierreCaja();
            frmCierra.ShowDialog();

            LLenarListaFecha(true);
        }

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            if (listCaja.Items.Count == 0)
            {
                MessageBox.Show("La lista está vacía, por favor filtre por las fechas correctas para exportar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Archivo PDF (*.pdf)|*.pdf",
                FileName = "HistorialDeCajas.pdf",
                Title = "Guardar PDF"
            };

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            string path = saveFileDialog.FileName;

            // Crear PDF
            Document doc = new Document(PageSize.A4, 40, 40, 40, 40);
            PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
            doc.Open();

            // Título
            Paragraph titulo = new Paragraph("Historial de Cajas", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18));
            titulo.Alignment = Element.ALIGN_CENTER;
            titulo.SpacingAfter = 20f;
            doc.Add(titulo);

            // Subtítulo con fechas

            DateTime fechaDesde = DateTime.Parse(listCaja.Items[listCaja.Items.Count - 1].SubItems[1].Text);
            DateTime fechaHasta = DateTime.Parse(listCaja.Items[0].SubItems[1].Text);

            // Formatear solo la parte de la fecha (sin hora)
            string fechaDesdeFormateada = fechaDesde.ToString("dd/MM/yyyy");
            string fechaHastaFormateada = fechaHasta.ToString("dd/MM/yyyy");

            Paragraph subtitulo = new Paragraph($"Desde: {fechaDesdeFormateada}   Hasta: {fechaHastaFormateada}", FontFactory.GetFont(FontFactory.HELVETICA, 11));
            subtitulo.Alignment = Element.ALIGN_CENTER;
            subtitulo.SpacingAfter = 15f;
            doc.Add(subtitulo);

            // Tabla
            int columnCount = listCaja.Columns.Count - 1;
            PdfPTable table = new PdfPTable(columnCount);
            table.WidthPercentage = 100;

            // Proporciones de las columnas
            float[] widths = new float[] { 2f, 2f, 2f, 2f, 2f, 2f, 2f, 6f };
            table.SetWidths(widths);

            // Fuente cabecera
            Font fontcabecera = FontFactory.GetFont(FontFactory.HELVETICA, 9);
            //Fuente normal
            Font fontNormal = FontFactory.GetFont(FontFactory.HELVETICA, 7);

            // Encabezados, en vez del foreach elijo el for para omitir la primer columna
            for (int i = 1; i < listCaja.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell(new Phrase(listCaja.Columns[i].Text, fontcabecera));
                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                table.AddCell(cell);
            }

            // Datos
            foreach (ListViewItem item in listCaja.Items)
            {
                for (int i = 1; i < item.SubItems.Count; i++) // omitimos SubItem[0] (Id Caja)
                {
                    table.AddCell(new Phrase(item.SubItems[i].Text, fontNormal));
                }
            }

            doc.Add(table);
            doc.Close();

            MessageBox.Show("PDF generado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // (Opcional) Abrir el PDF automáticamente
            if (File.Exists(path))
            {
                System.Diagnostics.Process.Start(path);
            }
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            if (dtpDesde.Value > dtpHasta.Value)
            {
                dtpHasta.Value = dtpDesde.Value;
            }
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            if (dtpHasta.Value < dtpDesde.Value)
            {
                MessageBox.Show("La fecha 'Hasta' no puede ser menor que la fecha 'Desde'.", "Fecha inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                dtpHasta.Value = dtpDesde.Value;
            }
        }
    }
}
