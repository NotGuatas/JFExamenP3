using JFExamenP3.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFExamenP3.Services;

public class JFServices
{
    private readonly HttpClient _httpClient;
    private const string ApiKey = "cf2d539a5efe27414b7afccb2b553009";
    private const string BaseUrl = "https://api.openweathermap.org/data/2.5/weather";
    public JFServices()
    {
        _httpClient = new HttpClient();
    }

    public async Task<JFInfoClima> GetWeatherAsync(string city)
    {
        var url = $"{BaseUrl}?q={city}&appid={ApiKey}&units=metric&lang=es";
        var response = await _httpClient.GetStringAsync(url);
        return JsonConvert.DeserializeObject<JFInfoClima>(response);
    }

}
