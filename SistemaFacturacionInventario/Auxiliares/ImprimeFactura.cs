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
            pd.DefaultPageSettings.PaperSize = new PaperSize("Custom", 315, 1000); // 80mm de ancho (315 unidades)
            pd.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0); // Márgenes: 0 (ajusta si es necesario)

            // Asignar el evento PrintPage
            pd.PrintPage += (sender, e) =>
            {
                float x = 0; // Borde izquierdo
                float y = 10; // Inicio superior de la página
                float espacioLinea = 2 * new Font("Arial", 8).GetHeight(e.Graphics); // Espaciado doble entre líneas normales
                float espacioLineaNombreEmp = 3 * new Font("Arial", 8).GetHeight(e.Graphics);
                float espacioSeccion = espacioLinea * 2; // Espaciado mayor entre secciones

                Font fuente = new Font("Arial", 8);
                Font fuenteNomEmpresa = new Font("Arial", 13, FontStyle.Bold);
                Font fuenteImporte = new Font("Arial", 10, FontStyle.Bold);

                // Obtener el ancho del área de impresión
                int anchoPagina = e.PageBounds.Width;

                // Medir el ancho del texto
                SizeF tamañoTexto = e.Graphics.MeasureString(empresa.NFantasia, fuenteNomEmpresa);

                // Calcular la posición X para centrar con ajuste manual (prueba restando 5 o 10 unidades)
                float ajusteManual = 10;  // Puedes ajustar este valor según el desplazamiento
                float xCentrado = (anchoPagina - tamañoTexto.Width) / 2 - ajusteManual;

                // Encabezado
                e.Graphics.DrawString(empresa.NFantasia, fuenteNomEmpresa, Brushes.Black, xCentrado, y);
                y += espacioLineaNombreEmp;

                e.Graphics.DrawString("Dirección: " + empresa.Direccion ?? "", fuente, Brushes.Black, x, y);
                y += espacioLinea;

                e.Graphics.DrawString("Localidad: Pampa del Indio", fuente, Brushes.Black, x, y);
                y += espacioLinea;

                e.Graphics.DrawString("Provincia: Chaco", fuente, Brushes.Black, x, y);
                y += espacioLinea;

                e.Graphics.DrawString("CUIT: " + empresa.CUIT, fuente, Brushes.Black, x, y);
                y += espacioLinea;

                e.Graphics.DrawString($"Fecha de Emisión: {fact.FechaEmision.ToShortDateString()}", fuente, Brushes.Black, x, y);
                y += espacioLinea;

                e.Graphics.DrawString($"Hora de Emisión: {fact.FechaEmision.ToShortTimeString()}", fuente, Brushes.Black, x, y);
                y += espacioSeccion;

                e.Graphics.DrawString("=========================================", fuente, Brushes.Black, x, y);
                y += fuente.GetHeight(e.Graphics);

                // Detalles de compra
                foreach (var detalle in factDetalle)
                {
                    string producto = detalle.Producto.Length > 20 ? detalle.IdProducto +"-"+ detalle.Producto.Substring(0, 20) + "..." : detalle.IdProducto + "-" + detalle.Producto.PadRight(20);
                    string cantidadPrecio = $"x{detalle.Cantidad}  ${detalle.PrecioUnitario,6}";

                    e.Graphics.DrawString(producto, fuente, Brushes.Black, x, y);
                    e.Graphics.DrawString(cantidadPrecio, fuente, Brushes.Black, 150, y);

                    y += fuente.GetHeight(e.Graphics);
                }

                e.Graphics.DrawString("=========================================", fuente, Brushes.Black, x, y);
                y += espacioSeccion;

                // Totales
                e.Graphics.DrawString($"Importe: $ {fact.Total}", fuenteImporte, Brushes.Black, x, y);
                y += espacioSeccion;

                // Pie de página
                e.Graphics.DrawString("Gracias por su compra", fuente, Brushes.Black, x, y);
                y += espacioLinea;

                e.Graphics.DrawString("Visítanos nuevamente!", fuente, Brushes.Black, x, y);
            };

            // Enviar a imprimir
            pd.Print();

            Console.WriteLine("Ticket impreso.");
        }


        public static void ImprimeFacturaElec(FacturasVenta fact, List<FacturasVentaDetalle> factDetalle)
        {
            string impresora = @"EPSON TM-T20IIIL Receipt"; // Nombre exacto de la impresora en Windows

            AuxiliaresNegocio auxiliaresNegocio = new AuxiliaresNegocio();
            Empresa empresa = auxiliaresNegocio.ObtenerEmpresa();

            FacturasElectronicasNegocio facturasElectronicasNegocio = new FacturasElectronicasNegocio();
            var factElec = facturasElectronicasNegocio.GetFacturaElectronicaByFacturaVentaId(fact.IdFacturaVenta);
            // Crear el objeto PrintDocument
            PrintDocument pd = new PrintDocument();
            pd.PrinterSettings.PrinterName = impresora;

            // Configuración del tamaño de la página
            pd.DefaultPageSettings.PaperSize = new PaperSize("Custom", 315, 1000); // 80mm de ancho (315 unidades)
            pd.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0); // Márgenes: 0 (ajusta si es necesario)

            // Asignar el evento PrintPage
            pd.PrintPage += (sender, e) =>
            {
                float x = 0; // Borde izquierdo
                float y = 10; // Inicio superior de la página
                float espacioLinea = 2 * new Font("Arial", 8).GetHeight(e.Graphics); // Espaciado doble entre líneas normales
                float espacioLineaNombreEmp = 3 * new Font("Arial", 8).GetHeight(e.Graphics);
                float espacioSeccion = espacioLinea * 2; // Espaciado mayor entre secciones

                Font fuente = new Font("Arial", 8);
                Font fuenteNomEmpresa = new Font("Arial", 13, FontStyle.Bold);
                Font fuenteImporte = new Font("Arial", 10, FontStyle.Bold);

                // Obtener el ancho del área de impresión
                int anchoPagina = e.PageBounds.Width;

                // Medir el ancho del texto
                SizeF tamañoTexto = e.Graphics.MeasureString(empresa.NFantasia, fuenteNomEmpresa);

                // Calcular la posición X para centrar con ajuste manual (prueba restando 5 o 10 unidades)
                float ajusteManual = 10;  // Puedes ajustar este valor según el desplazamiento
                float xCentrado = (anchoPagina - tamañoTexto.Width) / 2 - ajusteManual;

                // Encabezado
                e.Graphics.DrawString(empresa.NFantasia, fuenteNomEmpresa, Brushes.Black, xCentrado, y);
                y += espacioLineaNombreEmp;

                e.Graphics.DrawString("Dirección: " + empresa.Direccion ?? "", fuente, Brushes.Black, x, y);
                y += espacioLinea;

                e.Graphics.DrawString("Localidad: Pampa del Indio", fuente, Brushes.Black, x, y);
                y += espacioLinea;

                e.Graphics.DrawString("Provincia: Chaco", fuente, Brushes.Black, x, y);
                y += espacioLinea;

                e.Graphics.DrawString("CUIT: " + empresa.CUIT, fuente, Brushes.Black, x, y);
                y += espacioLinea;

                e.Graphics.DrawString("CAE: " + factElec.CAE, fuente, Brushes.Black, x, y);
                y += espacioLinea;

                e.Graphics.DrawString("Comprobante: " + factElec.NCompFact, fuente, Brushes.Black, x, y);
                y += espacioLinea;

                e.Graphics.DrawString($"Fecha de Emisión: {fact.FechaEmision.ToShortDateString()}", fuente, Brushes.Black, x, y);
                y += espacioLinea;

                e.Graphics.DrawString($"Hora de Emisión: {fact.FechaEmision.ToShortTimeString()}", fuente, Brushes.Black, x, y);
                y += espacioSeccion;

                e.Graphics.DrawString("=========================================", fuente, Brushes.Black, x, y);
                y += fuente.GetHeight(e.Graphics);

                // Detalles de compra
                foreach (var detalle in factDetalle)
                {
                    string producto = detalle.Producto.Length > 20 ? detalle.IdProducto + "-" + detalle.Producto.Substring(0, 20) + "..." : detalle.IdProducto + "-" + detalle.Producto.PadRight(20);
                    string cantidadPrecio = $"x{detalle.Cantidad}  ${detalle.PrecioUnitario,6}";

                    e.Graphics.DrawString(producto, fuente, Brushes.Black, x, y);
                    e.Graphics.DrawString(cantidadPrecio, fuente, Brushes.Black, 150, y);

                    y += fuente.GetHeight(e.Graphics);
                }

                e.Graphics.DrawString("=========================================", fuente, Brushes.Black, x, y);
                y += espacioSeccion;

                //Discriminación IVA
                string iva = CalculaIVA(fact.Total);

                e.Graphics.DrawString("RÉGIMEN DE TRANSFERENCIA FISCAL AL CONSUMIDOR FINAL LEY 27.743", fuente, Brushes.Black, x, y);
                y += espacioLinea;
                e.Graphics.DrawString($"IVA Contenido: $ {iva}", fuente, Brushes.Black, x, y);
                y += espacioLinea;
                e.Graphics.DrawString("Imp. Int.: $ 0.00", fuente, Brushes.Black, x, y);
                y += espacioLinea;

                // Totales
                e.Graphics.DrawString($"Importe: $ {fact.Total}", fuenteImporte, Brushes.Black, x, y);
                y += espacioSeccion;

                // Pie de página
                e.Graphics.DrawString("Gracias por su compra", fuente, Brushes.Black, x, y);
                y += espacioLinea;

                e.Graphics.DrawString("Visítanos nuevamente!", fuente, Brushes.Black, x, y);
            };

            // Enviar a imprimir
            pd.Print();

            Console.WriteLine("Ticket impreso.");
        }

        private static string CalculaIVA(decimal total)
        {
            var iva = total * 0.1736m;
            return iva.ToString("F2");
        }
    }
}
