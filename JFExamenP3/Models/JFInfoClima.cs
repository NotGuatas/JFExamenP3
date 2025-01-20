using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace JFExamenP3.Models;

public class JFInfoClima
{
    public Main Main { get; set; }
    public Weather[] Weather { get; set; }
    public Wind Wind { get; set; }
    public Sys Sys { get; set; }
}
public class Main
{
    public float Temp { get; set; }
    public float TempMin { get; set; }
    public float TempMax { get; set; }
    public int Humidity { get; set; }
    public int Pressure { get; set; }
}

public class Weather
{
    public string Description { get; set; }
    public string Icon { get; set; }
}

public class Wind
{
    public float Speed { get; set; }
    public int Deg { get; set; }
}

public class Sys
{
    public long Sunrise { get; set; }
    public long Sunset { get; set; }
}
