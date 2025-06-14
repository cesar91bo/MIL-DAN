﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using CapaNegocio;
using CapaDatos.Modelos;
using SistemaFacturacionInventario.wsfev1;
using Newtonsoft.Json;
using System.Drawing.Imaging;
using System.IO;
using QRCoder;
namespace SistemaFacturacionInventario.Facturacion
{
    public partial class frmFacturaElectronica : Form
    {
        #region URLs

        //Las URLs del WSAA son:
        //TESTING: https://wsaahomo.afip.gov.ar/ws/services/LoginCms?wsdl
        //PRODUCCION: https://wsaa.afip.gov.ar/ws/services/LoginCms?wsdl

        //Las URLs del WSFEv1 son:
        //TESTING: https://wswhomo.afip.gov.ar/wsfev1/service.asmx?wsld 
        //PRODUCCION: https://servicios1.afip.gov.ar/wsfev1/service.asmx?wsld 

        #endregion

        private const string DEFAULT_URLWSAAWSDL = "https://wsaa.afip.gov.ar/ws/services/LoginCms?wsdl", DEFAULT_SERVICIO = "wsfe";
        private const bool DEFAULT_VERBOSE = true;
        public string bocaVenta;
        public List<int> ListFacturas;
        private int IdFacturaVenta;
        private List<ResultadoOperacion> Result = new List<ResultadoOperacion>();
        private string ruta;
        private int TipoCom;
        private readonly AuxiliaresNegocio empresaN = new AuxiliaresNegocio();

        private readonly FacturacionNegocio facturacionNegocio = new FacturacionNegocio();

        private readonly FacturasElectronicasNegocio facturasElectronicasNegocio = new FacturasElectronicasNegocio();
        private class ResultadoOperacion
        {
            public int IdResultado, IdFact;
            public string DescripcionResultado, CAE, FechaExpiracionCAE, NCompFact, Observacion;
        }
        public frmFacturaElectronica()
        {
            InitializeComponent();
        }

        private void frmFacturaElectronica_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (int f in ListFacturas) lblFacturasSeleccionadas.Text = lblFacturasSeleccionadas.Text + f;

                ConsultarEstadoServidor();
                Empresa emp = AuxiliaresNegocio.GetEmpresa();
                ruta = emp.RutaCertificado;
            }
            catch (Exception ex) { throw ex; }
        }

        #region FECAESolicitar

        private bool FECAESolicitar(string ruta)
        {
            try
            {
                var ventaN = new VentaNegocio();
                var ws = new ServiceSoapClient();
                var auth = new FEAuthRequest();
                AutenticacionesWSAA autenticacion = ventaN.ObtenerUltimaAutorizacionWSAA();
                Empresa Emp = AuxiliaresNegocio.GetEmpresa();
                //Consumo el WSAA para obtener los datos Tocken y Sign
                var ticket = new LoginTicket();
                if (autenticacion == null)
                {
                    var autent = new AutenticacionesWSAA();
                    string resultado = ticket.ObtenerLoginTicketResponse(DEFAULT_SERVICIO, DEFAULT_URLWSAAWSDL, ruta, DEFAULT_VERBOSE, Emp.SerialCertificado);
                    auth.Token = ticket.Token;
                    auth.Sign = ticket.Sign;
                    //Guardo el ticket en BD
                    autent.Sign = ticket.Sign;
                    autent.Token = ticket.Token;
                    autent.FechaAutorizacion = ticket.GenerationTime;
                    autent.FechaExpiracion = ticket.ExpirationTime;
                    autent.IdEmpresa = 1;
                    ventaN.NuevaAutenticacionWSAA(autent);
                }
                else
                {
                    auth.Token = autenticacion.Token;
                    auth.Sign = autenticacion.Sign;
                }

                auth.Cuit = Convert.ToInt64(Emp.CUIT.Replace("-", ""));

                //DEFINIMOS LA CABECERA DE LA FACTURA
                var fecabreq = new FECAECabRequest { CantReg = ListFacturas.Count };

                //DEFINIMOS EL CUERPO DE LA FACTURA OSEA EL DETALLE
                var ListDetalle = new List<FECAEDetRequest>();

                //wsfev1.FECAEDetRequest[] detalle = new wsfev1.FECAEDetRequest[ListFacturas.Count];
                int canta = 1, cantb = 1;

                //RECORREMOS EL LISTADO DE FACTURAS SELECCIONADAS, EN ESTE CASO SIMPRE VA A SER UNO
                foreach (int i in ListFacturas)
                {
                    IdFacturaVenta = i;
                    FacturasVenta Factura = ventaN.ObtenerFactura(IdFacturaVenta);
                    Factura.FechaEmision = DateTime.Now;
                    var listcbteasoc = new List<CbteAsoc>();

                    if (Factura.IdTipoDocumento == 1) //Fact.Vta
                    {
                        if (Factura.IdTipoFactura == 1) fecabreq.CbteTipo = 1;
                        else if (Factura.IdTipoFactura == 2) fecabreq.CbteTipo = 6;
                        else fecabreq.CbteTipo = 11;
                    }
                    else if (Factura.IdTipoDocumento == 2) //Nota  de Crédito AGREGAR DOCUMENTO ASOCIADO AL FINAL DE LA FACTURA
                    {
                        var cbte = new CbteAsoc { Nro = Convert.ToInt64(Factura.NroCompFactReferencia), PtoVta = Convert.ToInt32(Factura.BVReferencia) };

                        if (Factura.IdTipoFactura == 1)
                        {
                            fecabreq.CbteTipo = 3; //A
                            cbte.Tipo = 1; //Factura Vta A
                        }
                        else if (Factura.IdTipoFactura == 2)
                        {
                            fecabreq.CbteTipo = 8; //B
                            cbte.Tipo = 6; //Factura Vta B
                        }
                        else
                        {
                            fecabreq.CbteTipo = 13; //C
                            cbte.Tipo = 11; //Factura Vta C
                        }

                        listcbteasoc.Add(cbte);
                    }
                    else if (Factura.IdTipoDocumento == 3) //Nota de Débito AGREGAR DOCUMENTO ASOCIADO AL FINAL DE LA FACTURA
                    {
                        var cbte = new CbteAsoc { Nro = Convert.ToInt64(Factura.NroCompFactReferencia), PtoVta = Convert.ToInt32(Factura.BVReferencia) };
                        if (Factura.IdTipoFactura == 1)
                        {
                            fecabreq.CbteTipo = 2; //A
                            cbte.Tipo = 1; //Factura Vta A
                        }
                        else if (Factura.IdTipoFactura == 2)
                        {
                            fecabreq.CbteTipo = 7; //B
                            cbte.Tipo = 6; //Factura Vta B
                        }
                        else
                        {
                            fecabreq.CbteTipo = 12; //C
                            cbte.Tipo = 11; //Factura Vta C
                        }

                        listcbteasoc.Add(cbte);
                    }

                    fecabreq.PtoVta = Convert.ToInt32(bocaVenta);                   

                    var fedetreq = new FECAEDetRequest();
                    if (listcbteasoc.Count > 0) fedetreq.CbtesAsoc = listcbteasoc.ToArray();

                    fedetreq.Concepto = Factura.IdConceptoFactura;
                    fedetreq.CondicionIVAReceptorId = 5;
                    var clienteN = new ClienteNegocio();
                    VistaClientes Cliente = clienteN.ObtenerVCliporNroCli(Factura.IdCliente);

                    if (Cliente.Nro_Doc != "0")
                    {
                        if (Cliente.TipoDocumento == "CUIT")
                        {
                            fedetreq.DocTipo = 80; //80: CUIT 66: DNI  99: Otro
                            fedetreq.DocNro = Convert.ToInt64(Cliente.Cuit.Replace("-", ""));
                        }
                        else if (Cliente.TipoDocumento == "DNI")
                        {
                            fedetreq.DocTipo = 96;
                            fedetreq.DocNro = Convert.ToInt64(Cliente.Nro_Doc);
                        }
                        else if (Cliente.TipoDocumento == "CUIL")
                        {
                            fedetreq.DocTipo = 86;
                            fedetreq.DocNro = Convert.ToInt64(Cliente.Nro_Doc);
                        }
                        else if (Cliente.TipoDocumento == "LE")
                        {
                            fedetreq.DocTipo = 89;
                            fedetreq.DocNro = Convert.ToInt64(Cliente.Nro_Doc);
                        }
                        else if (Cliente.TipoDocumento == "LC")
                        {
                            fedetreq.DocTipo = 90;
                            fedetreq.DocNro = Convert.ToInt64(Cliente.Nro_Doc);
                        }
                    }
                    else
                    {
                        fedetreq.DocTipo = 99;
                        fedetreq.DocNro = 0;
                    }

                    //RECUPERA DE LA AFIP EL ULTIMO COMPROBANTE AUTORIZADO Y
                    //LE SUMA UNO AL NUMERO DEL COMPRONTE QUE SE VA A REGISTRAR EN LA AFIP
                    FERecuperaLastCbteResponse ultimoaut = ws.FECompUltimoAutorizado(auth, Convert.ToInt32(bocaVenta), fecabreq.CbteTipo);

                    TipoCom = fecabreq.CbteTipo;

                    if (Factura.IdTipoFactura == 1)
                    {

                        fedetreq.CbteDesde = ultimoaut.CbteNro + canta;
                        fedetreq.CbteHasta = ultimoaut.CbteNro + canta;
                    }
                    else if (Factura.IdTipoFactura == 2)
                    {
                        fedetreq.CbteDesde = ultimoaut.CbteNro + cantb;
                        fedetreq.CbteHasta = ultimoaut.CbteNro + cantb;
                    }

                    VistaLibroIvaVenta LibroIva = ventaN.ObtenerLibroIvaVentasPorIdFactura(Factura.IdFacturaVenta);
                    VistaTotalesDiscriminadosFactB TotalesFactB = ventaN.ObtenerVistaTotalesDiscriminadosFactBporIdFact(Factura.IdFacturaVenta);
                    fedetreq.CbteFch = Factura.FechaEmision.Year + Factura.FechaEmision.Month.ToString().PadLeft(2, '0') + Factura.FechaEmision.Day.ToString().PadLeft(2, '0');
                    if (Factura.IdConceptoFactura != 1)
                    {
                        fedetreq.FchServDesde = DateTime.Now.Year + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0');
                        fedetreq.FchServHasta = DateTime.Now.Year + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0');
                        fedetreq.FchVtoPago = DateTime.Now.Year + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0');
                    }

                    fedetreq.ImpTotal = Convert.ToDouble(Factura.Total);
                    fedetreq.ImpTotConc = 0;
                    switch (fecabreq.CbteTipo)
                    {
                        case 1:
                        case 6:
                        case 11:
                            fedetreq.ImpTotConc = 0;
                            fedetreq.ImpNeto = Convert.ToDouble(LibroIva.NetoGravado);
                            fedetreq.ImpOpEx = Convert.ToDouble(LibroIva.NoGravado);
                            fedetreq.ImpIVA = Math.Round(Convert.ToDouble(LibroIva.Iva105) + Convert.ToDouble(LibroIva.Iva21), 2, MidpointRounding.AwayFromZero);
                            break;
                        case 3:
                        case 8:
                        case 13:
                            fedetreq.ImpTotConc = 0;
                            fedetreq.ImpNeto = Math.Abs(Convert.ToDouble(LibroIva.NetoGravado));
                            fedetreq.ImpOpEx = Math.Abs(Convert.ToDouble(LibroIva.NoGravado));
                            fedetreq.ImpIVA = Math.Abs(Math.Round(Convert.ToDouble(LibroIva.Iva105) + Convert.ToDouble(LibroIva.Iva21), 2, MidpointRounding.AwayFromZero));
                            break;
                        case 2:
                        case 7:
                        case 12:
                            fedetreq.ImpTotConc = 0;
                            fedetreq.ImpNeto = Math.Abs(Convert.ToDouble(LibroIva.NetoGravado));
                            fedetreq.ImpOpEx = Math.Abs(Convert.ToDouble(LibroIva.NoGravado));
                            fedetreq.ImpIVA = Math.Abs(Math.Round(Convert.ToDouble(LibroIva.Iva105) + Convert.ToDouble(LibroIva.Iva21), 2, MidpointRounding.AwayFromZero));
                            break;
                    }

                    fedetreq.MonId = "PES";
                    fedetreq.MonCotiz = 1.000;

                    var listiva = new List<AlicIva>();
                    if (fecabreq.CbteTipo == 1 || fecabreq.CbteTipo == 3 || fecabreq.CbteTipo == 2) //Factura A o NC A no calculo base imponible
                    {
                        //if (Factura.Subtotal21 != 0)
                        //{
                        //    var iva = new AlicIva { BaseImp = Convert.ToDouble(Factura.TotalDescuento21), Id = 5, Importe = Math.Abs(Convert.ToDouble(LibroIva.Iva21)) };
                        //    listiva.Add(iva);
                        //}

                        if (Factura.Subtotal105 != 0)
                        {
                            var iva = new AlicIva { BaseImp = Convert.ToDouble(Factura.TotalDescuento105), Id = 4, Importe = Math.Abs(Convert.ToDouble(LibroIva.Iva105)) };
                            listiva.Add(iva);
                        }
                    }
                    else if (fecabreq.CbteTipo == 6 || fecabreq.CbteTipo == 8 || fecabreq.CbteTipo == 7) //Factura B o NC B calculo base imponible
                    {
                        var ListDetFact = new List<FacturasVentaDetalle>();
                        double totaliva21 = 0, totaliva105 = 0, totalnogravado = 0, totalnetogravado = 0, netogravado, importeiva21 = 0, importeiva105 = 0;
                        if (TotalesFactB.IVA21 != 0)
                        {
                            ListDetFact = ventaN.ObtenerFacturaVentaDetallexTipoIvayNroFact(Factura.IdFacturaVenta, 1);

                            foreach (FacturasVentaDetalle f in ListDetFact)
                                totaliva21 += Convert.ToDouble(f.TotalArt);

                            var iva = new AlicIva();
                            double montodescuento = totaliva21 * (Convert.ToDouble(Factura.Descuento) / 100); // No hace falta Convert.ToDouble
                            netogravado = (totaliva21 - montodescuento) / 1.21; // CORREGIDO

                            iva.BaseImp = Math.Round(netogravado, 2);
                            iva.Id = 5;
                            iva.Importe = Math.Round(iva.BaseImp * 0.21, 2); // CORREGIDO
                            listiva.Add(iva);

                            importeiva21 = iva.Importe;
                            totalnetogravado = netogravado;
                        }


                        if (TotalesFactB.IVA105 != 0)
                        {
                            ListDetFact = ventaN.ObtenerFacturaVentaDetallexTipoIvayNroFact(Factura.IdFacturaVenta, 2);
                            foreach (FacturasVentaDetalle f in ListDetFact) totaliva105 = totaliva105 + Convert.ToDouble(f.TotalArt);

                            var iva = new AlicIva();
                            double montodescuento = totaliva105 * (Convert.ToDouble(Factura.Descuento) / 100);
                            netogravado = (totaliva105 - montodescuento) / Convert.ToDouble("1,105");
                            iva.BaseImp = Math.Round(netogravado, 2);
                            iva.Id = 4;
                            //iva.Importe = Math.Round((total - iva.BaseImp - Convert.ToDouble(Factura.TotalDescuento)), 2, MidpointRounding.AwayFromZero);
                            iva.Importe = Math.Round(iva.BaseImp * Convert.ToDouble("0,105"), 2);
                            listiva.Add(iva);
                            importeiva105 = iva.Importe;
                            totalnetogravado = totalnetogravado + netogravado;
                        }

                        ListDetFact = ventaN.ObtenerFacturaVentaDetallexTipoIvayNroFact(Factura.IdFacturaVenta, 3);
                        if (ListDetFact.Count > 0)
                        {
                            double total = 0;
                            foreach (FacturasVentaDetalle f in ListDetFact) total = total + Convert.ToDouble(f.TotalArt);

                            double montodescuento = total * (Convert.ToDouble(Factura.Descuento) / 100);
                            totalnogravado = total - montodescuento;
                        }



                        fedetreq.ImpTotConc = Math.Round(totalnogravado, 2);
                        fedetreq.ImpNeto = Math.Round(totalnetogravado, 2);
                        fedetreq.ImpIVA = Math.Round(importeiva105 + importeiva21, 2);
                        fedetreq.ImpTrib = 0;
                        fedetreq.ImpTotal = fedetreq.ImpTotConc + fedetreq.ImpNeto + fedetreq.ImpIVA + fedetreq.ImpTrib;
                    }

                    if (listiva.Count > 0)
                    {
                        var alic = listiva.ToArray();
                        fedetreq.Iva = alic;
                    }

                    ListDetalle.Add(fedetreq);

                    if (Factura.IdTipoFactura == 1) canta = canta + 1;
                    else if (Factura.IdTipoFactura == 2) cantb = cantb + 1;

                    #region Calcuular para TIPO A
                    if (Factura.IdTipoFactura == 1)
                    {
                        fedetreq.ImpNeto = Math.Round((fedetreq.ImpTotal / 1.21), 2);
                        fedetreq.ImpTotal = Math.Round(fedetreq.ImpNeto * 1.21, 2);
                        fedetreq.ImpIVA = Math.Round(fedetreq.ImpTotal - fedetreq.ImpNeto, 2);
                        fedetreq.ImpOpEx = 0;

                        fedetreq.CondicionIVAReceptorId = 1;

                        var iva = new AlicIva { BaseImp = Math.Round((fedetreq.ImpTotal / (1 + 21 / 100) / 1.21), 2), Id = 5, Importe = fedetreq.ImpIVA };
                        listiva.Add(iva);

                        if (listiva.Count > 0)
                        {
                            var alic = listiva.ToArray();
                            fedetreq.Iva = alic;
                        }

                    }
                    #endregion
                }

                var detalle = ListDetalle.ToArray();
                var FECAERequest = new FECAERequest { FeCabReq = fecabreq, FeDetReq = detalle };
                var Autorizacion = new FECAEResponse();

                Autorizacion = ws.FECAESolicitar(auth, FECAERequest);

                // INICIO COMENTARIO
                // Esta porción de código muestra los mensajes de devolución de parte de AFIP.
                // Una "A" significa aprobado, una "R" rechazado.
                // Luego de estos mensajes salen las devoluciones de errores y observaciones.

                //MessageBox.Show(Autorizacion.FeCabResp.Resultado);

                foreach (FECAEDetResponse res in Autorizacion.FeDetResp.ToList())
                {
                    //MessageBox.Show(res.Resultado);
                    if (res.Observaciones == null) continue;
                    foreach (Obs obs in res.Observaciones) MessageBox.Show(obs.Msg);
                }

                if (Autorizacion.Errors != null)
                    foreach (Err r in Autorizacion.Errors.ToList())
                        MessageBox.Show(r.Code + r.Msg);

                if (Autorizacion.Events != null)
                    foreach (Evt r in Autorizacion.Events.ToList())
                        MessageBox.Show(r.Code + r.Msg);

                // FIN COMENTARIO

                var ListaResultados = new List<ResultadoOperacion>();
                if (Autorizacion.Errors != null)
                    foreach (Err r in Autorizacion.Errors.ToList())
                    {
                        var Resultado = new ResultadoOperacion { IdResultado = 2, DescripcionResultado = r.Msg };
                        ListaResultados.Add(Resultado);
                    }
                else

                    for (var i = 0; i < ListFacturas.Count; i++)
                        if (Autorizacion.FeDetResp[i].CAE != null)
                        {
                            string fecha = Autorizacion.FeDetResp[i].CAEFchVto.Substring(6, 2) + "/" +
                                           Autorizacion.FeDetResp[i].CAEFchVto.Substring(4, 2) + "/" +
                                           Autorizacion.FeDetResp[i].CAEFchVto.Substring(0, 4);

                            var Resultado = new ResultadoOperacion
                            {
                                IdResultado = 1,
                                DescripcionResultado = "Aprobado",
                                CAE = Autorizacion.FeDetResp[i].CAE,
                                FechaExpiracionCAE = fecha,
                                NCompFact = Autorizacion.FeDetResp[i].CbteDesde.ToString().PadLeft(8, '0')
                            };

                            ventaN.ActualizaNroFact(ListFacturas[i], Convert.ToInt32(Resultado.NCompFact), bocaVenta, 1);

                            string qr = ObtenerQrEnBase64(Resultado.CAE, Resultado.NCompFact, bocaVenta, TipoCom.ToString());

                            var FactEl = new FacturasElectronicas
                            {
                                CAE = Resultado.CAE,
                                FechaVtoCAE = Convert.ToDateTime(fecha + " 23:59:59"),
                                IdFacturaVenta = ListFacturas[i],
                                NCompFact = Resultado.NCompFact,
                                Fecha = DateTime.Now,
                                QrImageBase64 = qr
                            };

                            ventaN.NuevaFacturaElectronica(FactEl);

                            if (Autorizacion.FeDetResp[i].Observaciones != null) Resultado.Observacion = Autorizacion.FeDetResp[i].Observaciones.ToString();

                            ListaResultados.Add(Resultado);
                        }
                        else
                        {
                            MessageBox.Show(
                                "No se obtuvo el CAE del comprobante" + Environment.NewLine +
                                "Por favor registre y avise la situación.", "ATENCION", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                            var Resultado = new ResultadoOperacion
                            {
                                IdResultado = 3,
                                IdFact = ListFacturas[i],
                                DescripcionResultado =
                                    "Operación completa con errores. Las siguientes facturas fueron rechazadas: " +
                                    Environment.NewLine + Environment.NewLine
                            };

                            //Error en los datos de la factura
                            foreach (Obs t in Autorizacion.FeDetResp[i].Observaciones)
                                if (t != null) Resultado.DescripcionResultado = Resultado.DescripcionResultado + "IdFacturaVenta: " + Resultado.IdFact + "  - " + t.Msg + Environment.NewLine;
                                else break;

                            ListaResultados.Add(Resultado);
                            break;
                        }

                Result = ListaResultados.ToList();


                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        #region WSAA

        public class LoginTicket
        {
            // Entero de 32 bits sin signo que identifica el requerimiento 
            public uint UniqueId;

            // Momento en que fue generado el requerimiento 
            public DateTime GenerationTime;

            // Momento en el que exoira la solicitud 
            public DateTime ExpirationTime;

            // Identificacion del WSN para el cual se solicita el TA 
            public string Service;

            // Firma de seguridad recibida en la respuesta 
            public string Sign;

            // Token de seguridad recibido en la respuesta 
            public string Token;
            public XmlDocument XmlLoginTicketRequest, XmlLoginTicketResponse;
            private string RutaDelCertificadoFirmante;
            private const string XmlStrLoginTicketRequestTemplate =
                "<loginTicketRequest><header><uniqueId></uniqueId><generationTime></generationTime><expirationTime></expirationTime></header><service></service></loginTicketRequest>";

            //public String token, sig
            private static uint _globalUniqueID;
            public string ObtenerLoginTicketResponse(string argServicio, string argUrlWsaa, string argRutaCertX509Firmante, bool argVerbose, string SerialCert)
            {
                try
                {
                    RutaDelCertificadoFirmante = argRutaCertX509Firmante;
                    CertificadosX509Lib.VerboseMode = argVerbose;

                    string cmsFirmadoBase64;
                    string loginTicketResponse;
                    //XmlNode xmlNodoSource, xmlNodoDestination;
                    X509Certificate2 certFirmante;

                    // PASO 1: Genero el Login Ticket Request 
                    try
                    {
                        XmlLoginTicketRequest = new XmlDocument();
                        XmlLoginTicketRequest.LoadXml(XmlStrLoginTicketRequestTemplate);

                        XmlNode xmlNodoUniqueId = XmlLoginTicketRequest.SelectSingleNode("//uniqueId");
                        XmlNode xmlNodoGenerationTime = XmlLoginTicketRequest.SelectSingleNode("//generationTime");
                        XmlNode xmlNodoExpirationTime = XmlLoginTicketRequest.SelectSingleNode("//expirationTime");
                        XmlNode xmlNodoService = XmlLoginTicketRequest.SelectSingleNode("//service");

                        xmlNodoGenerationTime.InnerText = DateTime.Now.AddMinutes(-10).ToString("s");
                        xmlNodoExpirationTime.InnerText = DateTime.Now.AddMinutes(+10).ToString("s");
                        xmlNodoUniqueId.InnerText = Convert.ToString(_globalUniqueID);
                        xmlNodoService.InnerText = argServicio;

                        Service = argServicio;

                        _globalUniqueID += 1;


                        //if (_verboseMode)
                        //{
                        //    Console.WriteLine(XmlLoginTicketRequest.OuterXml);
                        //}
                    }

                    catch (Exception excepcionAlGenerarLoginTicketRequest) { throw new Exception("***Error GENERANDO el LoginTicketRequest : " + excepcionAlGenerarLoginTicketRequest.Message); }

                    // PASO 2: Firmo el Login Ticket Request 
                    try
                    {
                        //if (_verboseMode)
                        //{
                        //    Console.WriteLine("***Leyendo certificado: {0}", RutaDelCertificadoFirmante);
                        //}

                        certFirmante = CertificadosX509Lib.ObtieneCertificadoDesdeArchivo(RutaDelCertificadoFirmante, SerialCert);
                        //if (_verboseMode)
                        //{
                        //    Console.WriteLine("***Firmando: ");
                        //    Console.WriteLine(XmlLoginTicketRequest.OuterXml);
                        //}

                        // Convierto el login ticket request a bytes, para firmar 
                        Encoding EncodedMsg = Encoding.UTF8;
                        var msgBytes = EncodedMsg.GetBytes(XmlLoginTicketRequest.OuterXml);

                        // Firmo el msg y paso a Base64 
                        var encodedSignedCms = CertificadosX509Lib.FirmaBytesMensaje(msgBytes, certFirmante);
                        cmsFirmadoBase64 = Convert.ToBase64String(encodedSignedCms);
                    }

                    catch (Exception excepcionAlFirmar) { throw new Exception("***Error FIRMANDO el LoginTicketRequest : " + excepcionAlFirmar.Message); }

                    // PASO 3: Invoco al WSAA para obtener el Login Ticket Response 
                    try
                    {
                        //if (_verboseMode)
                        //{
                        //    Console.WriteLine("***Llamando al WSAA en URL: {0}", argUrlWsaa);
                        //    Console.WriteLine("***Argumento en el request:");
                        //    Console.WriteLine(cmsFirmadoBase64);
                        //}
                        var servicioWsaa = new SistemaFacturacionInventario.wsaa.LoginCMSClient();
                        //servicioWsaa.ClientCredentials = argRutaCertX509Firmante;
                        servicioWsaa.ClientCredentials.ClientCertificate.Certificate = certFirmante;
                        loginTicketResponse = servicioWsaa.loginCms(cmsFirmadoBase64);

                        //if (_verboseMode)
                        //{
                        //    Console.WriteLine("***LoginTicketResponse: ");
                        //    Console.WriteLine(loginTicketResponse);
                        //}
                    }

                    catch (Exception excepcionAlInvocarWsaa) { throw new Exception("***Error INVOCANDO al servicio WSAA : " + excepcionAlInvocarWsaa.Message); }


                    // PASO 4: Analizo el Login Ticket Response recibido del WSAA 
                    try
                    {
                        XmlLoginTicketResponse = new XmlDocument();
                        XmlLoginTicketResponse.LoadXml(loginTicketResponse);

                        UniqueId = uint.Parse(XmlLoginTicketResponse.SelectSingleNode("//uniqueId").InnerText);
                        GenerationTime = DateTime.Parse(XmlLoginTicketResponse.SelectSingleNode("//generationTime").InnerText);
                        ExpirationTime = DateTime.Parse(XmlLoginTicketResponse.SelectSingleNode("//expirationTime").InnerText);
                        Sign = XmlLoginTicketResponse.SelectSingleNode("//sign").InnerText;
                        Token = XmlLoginTicketResponse.SelectSingleNode("//token").InnerText;
                    }
                    catch (Exception excepcionAlAnalizarLoginTicketResponse) { throw new Exception("***Error ANALIZANDO el LoginTicketResponse : " + excepcionAlAnalizarLoginTicketResponse.Message); }

                    return loginTicketResponse;
                }
                catch (Exception ex) { throw ex; }
            }
        }

        private class CertificadosX509Lib
        {
            public static bool VerboseMode;
            /// <summary> 
            /// Firma mensaje 
            /// </summary> 
            /// <param name="argBytesMsg">Bytes del mensaje</param> 
            /// <param name="argCertFirmante">Certificado usado para firmar</param> 
            /// <returns>Bytes del mensaje firmado</returns> 
            /// <remarks></remarks> 
            public static byte[] FirmaBytesMensaje(byte[] argBytesMsg, X509Certificate2 argCertFirmante)
            {
                try
                {
                    // Pongo el mensaje en un objeto ContentInfo (requerido para construir el obj SignedCms) 
                    var infoContenido = new ContentInfo(argBytesMsg);
                    var cmsFirmado = new SignedCms(infoContenido);

                    // Creo objeto CmsSigner que tiene las caracteristicas del firmante 
                    var cmsFirmante = new CmsSigner(argCertFirmante);
                    cmsFirmante.IncludeOption = X509IncludeOption.EndCertOnly;
                    if (VerboseMode)
                    {
                        //Console.WriteLine("***Firmando bytes del mensaje...");
                    }

                    // Firmo el mensaje PKCS #7 
                    cmsFirmado.ComputeSignature(cmsFirmante);
                    if (VerboseMode)
                    {
                        //Console.WriteLine("***OK mensaje firmado");
                    }

                    // Encodeo el mensaje PKCS #7. 
                    return cmsFirmado.Encode();
                }
                catch (Exception excepcionAlFirmar) { throw new Exception("***Error al firmar: " + excepcionAlFirmar.Message); }
            }
            /// <summary> 
            /// Lee certificado de disco 
            /// </summary> 
            /// <param name="argArchivo">Ruta del certificado a leer.</param> 
            /// <returns>Un objeto certificado X509</returns> 
            /// <remarks></remarks> 
            public static X509Certificate2 ObtieneCertificadoDesdeArchivo(string argArchivo, string serial)
            {
                var objCert = new X509Certificate2();

                try
                {
                    //objCert.Import(Microsoft.VisualBasic.FileIO.FileSystem.ReadAllBytes(argArchivo));

                    var store = new X509Store();

                    store = new X509Store(StoreName.Root, StoreLocation.LocalMachine /*StoreLocation.LocalMachine*/ /*.CurrentUser*/);

                    store.Open(OpenFlags.ReadOnly);

                    X509Certificate2Collection collectionX509 = store.Certificates.Find(X509FindType.FindBySerialNumber, serial, false);


                    if (collectionX509.Count == 1) objCert = collectionX509[0];

                    else throw new Exception("No se puede encontrar el Certificado -> collectionX509.Count: " + collectionX509.Count.ToString(CultureInfo.InvariantCulture) + "\r\n\r\nServidor: " + "\r\nUser: ");

                    return objCert;
                }
                catch (Exception excepcionAlImportarCertificado) { throw new Exception("argArchivo=" + argArchivo + " excepcion=" + excepcionAlImportarCertificado.Message + " " + excepcionAlImportarCertificado.StackTrace); }
            }
        }

        #endregion;

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                lblLaOperacionPuedeDemorar.Visible = true;
                lblPorFavorEspere.Visible = true;
                pictureBox1.Visible = true;
                Cursor = Cursors.WaitCursor;
                backgroundWorker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            FECAESolicitar(ruta);
            e.Result = Result;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                Cursor = Cursors.Arrow;
                lblPorFavorEspere.Visible = false;
                lblLaOperacionPuedeDemorar.Visible = false;
                pictureBox1.Visible = false;
                var ok = false;
                var errores = "";
                foreach (ResultadoOperacion r in Result)
                    if (r.IdResultado == 1)
                    {
                        btnRegistrar.Enabled = false;
                        ok = true;
                        if (!string.IsNullOrEmpty(r.Observacion)) MessageBox.Show("Observaciones: la factura se autorizó correctamente, el servidor devolvió la siguiente observación. " + r.Observacion, "Observaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        errores += r.DescripcionResultado;
                        ok = false;
                    }

                if (ok)
                {
                    MessageBox.Show("Facturas Autorizadas Correctamente", "Autorización Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else { MessageBox.Show(errores == "" ? "Problemas internos con el servidor. Observe el estado del servidor en la esquina superior derecha." : errores, "Autorización Rechazada", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                var ws = new ServiceSoapClient();
                DummyResponse dummy = ws.FEDummy();
                string resul = "Auth Server: " + dummy.AuthServer;
                resul = resul + Environment.NewLine + "AppServer: " + dummy.AppServer;
                resul = resul + Environment.NewLine + "DBServer: " + dummy.DbServer;
                MessageBox.Show(resul, "Estado del Web Service", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ConsultarEstadoServidor()
        {
            try
            {
                var ws = new ServiceSoapClient();
                DummyResponse dummy = ws.FEDummy();
                ptbDB.BackColor = dummy.DbServer == "OK" ? Color.Green : Color.Yellow;
                ptbAuth.BackColor = dummy.AuthServer == "OK" ? Color.Green : Color.Yellow;
                ptbApp.BackColor = dummy.AppServer == "OK" ? Color.Green : Color.Yellow;
            }
            catch (Exception ex)
            {
                ptbApp.BackColor = Color.Red;
                ptbAuth.BackColor = Color.Red;
                ptbDB.BackColor = Color.Red;
            }
        }


        public static string ObtenerQrEnBase64(string cae, string factura, string ptoVta, string cbteTipo)
        {
            // Paso 1: Crear el objeto con los datos que necesita el QR
            var datosQR = new
            {
                ver = 1,
                fecha = DateTime.Now.ToString("yyyyMMdd"),
                cuit = "20301234567", // Reemplazalo por el CUIT real de la empresa emisora
                ptoVta = int.Parse(ptoVta),
                tipoCmp = int.Parse(cbteTipo),
                nroCmp = int.Parse(factura),
                importe = 1000.00, // Reemplazá por el total de la factura si lo tenés
                moneda = "PES",
                ctz = 1,
                tipoDocRec = 80,
                nroDocRec = 20123456789,
                tipoCodAut = "E",
                codAut = long.Parse(cae)
            };

            // Paso 2: Serializar a JSON
            string json = JsonConvert.SerializeObject(datosQR);

            // Paso 3: Codificar en Base64
            string jsonBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));

            // Paso 4: Construir la URL (esto es para QR AFIP)
            string urlQr = $"https://www.afip.gob.ar/fe/qr/?p={jsonBase64}";

            // Paso 5: Generar el QR
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(urlQr, QRCodeGenerator.ECCLevel.Q);
                using (QRCode qrCode = new QRCode(qrCodeData))
                {
                    using (Bitmap qrCodeImage = qrCode.GetGraphic(20))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            qrCodeImage.Save(ms, ImageFormat.Png);
                            byte[] imageBytes = ms.ToArray();

                            // Paso 6: Convertir imagen a base64
                            return Convert.ToBase64String(imageBytes);
                        }
                    }
                }
            }
        }

    }
}
