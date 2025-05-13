using CapaDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CapaNegocio;
using System.IO;

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
                    string cantidadPrecio = $"x{detalle.Cantidad.ToString("0")}  ${detalle.PrecioUnitario,8:0.00}";

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
                Font fuenteRegimen = new Font("Arial", 5, FontStyle.Bold);

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
                    string cantidadPrecio = $"x{detalle.Cantidad.ToString("0")}  ${detalle.PrecioUnitario,8:0.00}";

                    e.Graphics.DrawString(producto, fuente, Brushes.Black, x, y);
                    e.Graphics.DrawString(cantidadPrecio, fuente, Brushes.Black, 150, y);

                    y += fuente.GetHeight(e.Graphics);
                }

                e.Graphics.DrawString("=========================================", fuente, Brushes.Black, x, y);
                y += espacioSeccion;

                //Discriminación IVA
                string iva = CalculaIVA(fact.Total);

                e.Graphics.DrawString("RÉGIMEN DE TRANSFERENCIA FISCAL AL CONSUMIDOR FINAL LEY 27.743", fuenteRegimen, Brushes.Black, x, y);
                y += espacioLinea;
                e.Graphics.DrawString($"IVA Contenido: $ {iva}", fuente, Brushes.Black, x, y);
                y += espacioLinea;
                e.Graphics.DrawString("Imp. Int.: $ 0.00", fuente, Brushes.Black, x, y);
                y += espacioLinea;

                // Totales
                e.Graphics.DrawString($"Importe: $ {fact.Total}", fuenteImporte, Brushes.Black, x, y);
                y += espacioSeccion;

                if (!string.IsNullOrEmpty(factElec.QrImageBase64))
                {
                    byte[] qrBytes = Convert.FromBase64String(factElec.QrImageBase64);
                    using (MemoryStream ms = new MemoryStream(qrBytes))
                    {
                        Image qrImage = Image.FromStream(ms);

                        int anchoQr = 170;
                        int altoQr = 170;

                        // Cálculo para centrar horizontalmente
                        float xCentradoQr = (anchoPagina - anchoQr) / 2 - 15;

                        e.Graphics.DrawImage(qrImage, xCentradoQr, y, anchoQr, altoQr);
                        y += altoQr + 10; // Espaciado después del QR
                    }
                }

                //Agregar acá el logo de ARCA
                // Logo de ARCA desde los recursos
                Image logoArca = Properties.Resources.logoArca;

                int anchoLogo = 120;
                int altoLogo = 120;

                // Centrado horizontal
                float xCentradoLogo = (anchoPagina - anchoLogo) / 2;

                e.Graphics.DrawImage(logoArca, xCentradoLogo, y, anchoLogo, altoLogo);
                y += altoLogo + 8;

                e.Graphics.DrawString("Comprobante Autorizado", fuenteImporte, Brushes.Black, x, y);
                y += espacioLinea;

                // Pie de página
                e.Graphics.DrawString("Gracias por su compra", fuente, Brushes.Black, x, y);
                y += espacioLinea;

                e.Graphics.DrawString("Visítanos nuevamente!", fuente, Brushes.Black, x, y);
            };

            // Enviar a imprimir
            pd.Print();

            Console.WriteLine("Ticket impreso.");
        }

        public static void ImprimeAnulacion(FacturasVenta fact, List<FacturasVentaDetalle> factDetalle)
        {
            string impresora = @"EPSON TM-T20IIIL Receipt"; // Nombre exacto de la impresora

            AuxiliaresNegocio auxiliaresNegocio = new AuxiliaresNegocio();
            Empresa empresa = auxiliaresNegocio.ObtenerEmpresa();

            PrintDocument pd = new PrintDocument();
            pd.PrinterSettings.PrinterName = impresora;

            pd.DefaultPageSettings.PaperSize = new PaperSize("Custom", 315, 1000);
            pd.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);

            pd.PrintPage += (sender, e) =>
            {
                float x = 0;
                float y = 10;
                float espacioLinea = 2 * new Font("Arial", 8).GetHeight(e.Graphics);
                float espacioLineaNombreEmp = 3 * new Font("Arial", 8).GetHeight(e.Graphics);
                float espacioSeccion = espacioLinea * 2;

                Font fuente = new Font("Arial", 8);
                Font fuenteNomEmpresa = new Font("Arial", 13, FontStyle.Bold);
                Font fuenteImportante = new Font("Arial", 10, FontStyle.Bold);

                int anchoPagina = e.PageBounds.Width;
                float ajusteManual = 10;
                SizeF tamañoTexto = e.Graphics.MeasureString(empresa.NFantasia, fuenteNomEmpresa);
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

                e.Graphics.DrawString($"Fecha de Anulación: {DateTime.Now.ToShortDateString()}", fuente, Brushes.Black, x, y);
                y += espacioLinea;

                e.Graphics.DrawString($"Hora: {DateTime.Now.ToShortTimeString()}", fuente, Brushes.Black, x, y);
                y += espacioSeccion;

                // Línea separadora
                e.Graphics.DrawString("***************************************", fuente, Brushes.Black, x, y);
                y += fuente.GetHeight(e.Graphics);

                // Mensaje de anulación destacado
                string mensaje = "*** COMPROBANTE ANULADO ***";
                SizeF tamañoMensaje = e.Graphics.MeasureString(mensaje, fuenteImportante);
                float xMensaje = (anchoPagina - tamañoMensaje.Width) / 2;
                e.Graphics.DrawString(mensaje, fuenteImportante, Brushes.Black, xMensaje, y);
                y += espacioSeccion;

                // Detalles de compra
                foreach (var detalle in factDetalle)
                {
                    string producto = detalle.Producto.Length > 20 ? detalle.IdProducto + "-" + detalle.Producto.Substring(0, 20) + "..." : detalle.IdProducto + "-" + detalle.Producto.PadRight(20);
                    string cantidadPrecio = $"x{detalle.Cantidad.ToString("0")}  ${detalle.PrecioUnitario,8:0.00}";

                    e.Graphics.DrawString(producto, fuente, Brushes.Black, x, y);
                    e.Graphics.DrawString(cantidadPrecio, fuente, Brushes.Black, 150, y);

                    y += fuente.GetHeight(e.Graphics);
                }

                e.Graphics.DrawString("Documento ANULADO.", fuente, Brushes.Black, x, y);
                y += espacioSeccion;

                e.Graphics.DrawString("***************************************", fuente, Brushes.Black, x, y);
                y += espacioLinea;


                e.Graphics.DrawString("Este ticket es solo constancia de anulación.", fuente, Brushes.Black, x, y);
            };

            pd.Print();

            Console.WriteLine("Ticket de anulación impreso.");
        }


        private static string CalculaIVA(decimal total)
        {
            var iva = total * 0.1736m;
            return iva.ToString("F2");
        }
    }
}
