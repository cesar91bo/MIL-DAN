using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFacturacionInventario.Principal
{
    public partial class frmIndex : FormBase
    {
        private const string API_KEY = "78b4da1978ee4caa972231323250702"; 
        private const string BASE_URL = "https://api.weatherapi.com/v1/current.json?key={0}&q={1}&lang=es";
        public frmIndex()
        {
            InitializeComponent();
        }

        private void horaFecha_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void frmIndex_Load(object sender, EventArgs e)
        {
            CargarClima();
        }

        private async void CargarClima()
        {
            string ciudad = "Pampa del Indio";
            if (!string.IsNullOrEmpty(ciudad))
            {
                await ObtenerClima(ciudad);
            }
            else
            {
                MessageBox.Show("Ingrese una ciudad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async Task ObtenerClima(string ciudad)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string url = string.Format(BASE_URL, API_KEY, ciudad);
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        var datosClima = JsonConvert.DeserializeObject<Clima>(json);

                        lblTemperatura.Text = "Temperatura en Pampa del Indio: " + $"{datosClima.Current.Temp_C} °C";
                        lblDescripcion.Text = "Clima: " + datosClima.Current.Condition.Text;
                        pictureBoxClima.Load("https:" + datosClima.Current.Condition.Icon);

                        lblTemperatura.Visible = true;
                        lblDescripcion.Visible = true;
                        pictureBoxClima.Visible = true;
                    }
                    else
                    {
                        lblTemperatura.Visible = false;
                        lblDescripcion.Visible = false; 
                        pictureBoxClima.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al obtener datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    public class Clima
    {
        public CurrentWeather Current { get; set; }
    }

    public class CurrentWeather
    {
        public float Temp_C { get; set; }
        public Condition Condition { get; set; }
    }

    public class Condition
    {
        public string Text { get; set; }
        public string Icon { get; set; }
    }
}
