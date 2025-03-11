using CapaDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Printing;
using CapaNegocio;

namespace SistemaFacturacionInventario.Auxiliares
{
    public static class ImprimeFactura
    {
        public static void ImprimeFacturaX(FacturasVenta fact, List<FacturasVentaDetalle> factDetalle) 
        {
            string impresora = @"EPSON TM-T20IIIL Receipt"; // Nombre exacto de la impresora en Windows

            AuxiliaresNegocio auxiliaresNegocio = new AuxiliaresNegocio();
            Empresa empresa = auxiliaresNegocio.ObtenerEmpresa();

            // Crear el objeto PrintDocument
            PrintDocument pd = new PrintDocument();
            pd.PrinterSettings.PrinterName = impresora;

            // Configuración del tamaño de la página
            pd.DefaultPageSettings.PaperSize = new PaperSize("Custom", 315, 1000); // 80mm de ancho (315 unidades), altura de 1000 unidades (ajustar si es necesario)
            pd.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0); // Márgenes: 0 (ajusta según sea necesario)

            // Asignar el evento PrintPage
            pd.PrintPage += (sender, e) =>
            {
                float x = 0; // Comienza en el borde izquierdo
                float y = 10; // Comienza en la parte superior de la página
                Font fuente = new Font("Arial", 8);

                // Encabezado
                e.Graphics.DrawString(empresa.NFantasia, fuente, Brushes.Black, x, y);
                y += fuente.GetHeight(e.Graphics);
                e.Graphics.DrawString(empresa.CUIT, fuente, Brushes.Black, x, y);
                y += fuente.GetHeight(e.Graphics);
                e.Graphics.DrawString(empresa.Direccion ?? "", fuente, Brushes.Black, x, y);
                y += fuente.GetHeight(e.Graphics);
                e.Graphics.DrawString(empresa.Telefono ?? "", fuente, Brushes.Black, x, y);
                y += fuente.GetHeight(e.Graphics);
                e.Graphics.DrawString("=========================================", fuente, Brushes.Black, x, y); // Línea separadora
                y += fuente.GetHeight(e.Graphics);

                // Detalles de compra
                foreach (var detalle in factDetalle)
                {
                    e.Graphics.DrawString(detalle.Producto, fuente, Brushes.Black, x, y);
                    e.Graphics.DrawString($"Cant.: {detalle.Cantidad} Precio: ${detalle.PrecioUnitario}", fuente, Brushes.Black, 130, y);

                    y += fuente.GetHeight(e.Graphics);
                }

                e.Graphics.DrawString("=========================================", fuente, Brushes.Black, x, y); // Línea separadora
                y += fuente.GetHeight(e.Graphics);

                // Totales
                e.Graphics.DrawString($"Subtotal: ${fact.SubTotal}", fuente, Brushes.Black, x, y);
                y += fuente.GetHeight(e.Graphics);

                e.Graphics.DrawString($"Total: $ {fact.Total}", fuente, Brushes.Black, x, y);
                y += fuente.GetHeight(e.Graphics);

                // Pie de página
                e.Graphics.DrawString("Gracias por su compra", fuente, Brushes.Black, x, y);
                y += fuente.GetHeight(e.Graphics);
                e.Graphics.DrawString("Visítanos nuevamente!", fuente, Brushes.Black, x, y);
            };

            // Enviar a imprimir
            pd.Print();

            Console.WriteLine("Ticket impreso.");
        }
    }
}
