namespace VueFsharpCore2.Controllers

open System
open Microsoft.AspNetCore.Mvc

type WeatherForecast =
    { date          : DateTime
      temperatureC  : float
      summary       : string } 
    member x.temperatureF = Math.Round((x.temperatureC * 1.8 + 32.), 1) 
    member x.dateFormatted = x.date.ToString("d")

module WeatherForecastUtils =
    let private rng = Random()    
    let private summaries = [| "Freezing"; "Bracing"; "Chilly"; "Cool"; "Mild"; "Warm"; "Balmy"; "Hot"; "Sweltering"; "Scorching" |]
    let mutable min = -20.
    let mutable max = 50.
    let GetSummary(x) =
        let i = Math.Floor(((x + abs min) / 7.))
        match i with
        | x when x <= 0. -> summaries.[int i] 
        | _ -> summaries.[int i - 1] 

    let CreateNew(i) =
        let calc = Math.Round(min + rng.NextDouble() * (max - min), 1);
        { date = DateTime.Now.AddDays(i);
          temperatureC = calc;
          summary = GetSummary calc }

[<Route("api/[controller]")>]
type SampleDataController () =
    inherit Controller()

    [<HttpGet("WeatherForecasts")>]
    member API.WeatherForecasts() =
        [1. .. 5.] |> List.map WeatherForecastUtils.CreateNew