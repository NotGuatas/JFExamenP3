using JFExamenP3.Models;
using JFExamenP3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace JFExamenP3
{
    public partial class MainPage : ContentPage
    {
        private readonly JFServices _weatherService;

        public MainPage()
        {
            InitializeComponent();
            _weatherService = new JFServices();
        }

        public async void ObtenerClima(object sender, EventArgs args)
        {
            var city = CityEntry.Text;
            if (!string.IsNullOrWhiteSpace(city))
            {
                try
                {
                    var weather = await _weatherService.GetWeatherAsync(city);

                    TemperatureLabel.Text = $"Temperatura actual: {weather.Main.Temp}°C";
                    MinMaxTempLabel.Text = $"Mín: {weather.Main.TempMin}°C, Máx: {weather.Main.TempMax}°C";
                    DescriptionLabel.Text = $"Descripción: {weather.Weather[0].Description}";
                    WindLabel.Text = $"Viento: {weather.Wind.Speed} m/s, Dirección: {weather.Wind.Deg}°";
                    PressureLabel.Text = $"Presión: {weather.Main.Pressure} hPa";

                    var sunrise = DateTimeOffset.FromUnixTimeSeconds(weather.Sys.Sunrise).ToLocalTime();
                    var sunset = DateTimeOffset.FromUnixTimeSeconds(weather.Sys.Sunset).ToLocalTime();
                    SunriseSunsetLabel.Text = $"Amanecer: {sunrise:HH:mm}, Atardecer: {sunset:HH:mm}";

                    await App.ClimaRepo.AddNew(city);
                    statusMessage.Text = "Ciudad guardada exitosamente!";
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", "No se pudo obtener el clima. Verifique el nombre de la ciudad e intente nuevamente.", "OK");
                }
            }
        }

        public async void OnGetButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = "";

            List<JFInfoClima> people = await App.ClimaRepo.GetAllPeople();

            peopleList.ItemsSource = people;
        }
    }
}
