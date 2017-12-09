namespace VueFsharpCore2.Controllers

open System
open Microsoft.AspNetCore.Mvc

type WeatherForecast =
    { date          : DateTime
      temperatureC  : float
      summary       : string } 
    member x.temperatureF = Math.Round((x.temperatureC * 1.8 + 32.), 1) 
    member x.dateFormatted = x.date.ToString("d")

[<Route("api/[controller]")>]
type SampleDataController () =
    inherit Controller()

    let summaries = [| "Freezing"; "Bracing"; "Chilly"; "Cool"; "Mild"; "Warm"; "Balmy"; "Hot"; "Sweltering"; "Scorching" |]

    [<HttpGet("WeatherForecasts")>]
    member API.WeatherForecasts() =
        let rng = Random()
        [1. .. 5.] |> List.map (fun i ->
            { date = DateTime.Now.AddDays(i);
              temperatureC = Math.Round(-20. + rng.NextDouble() * (50. - -22.), 1);
              summary = summaries.[rng.Next(summaries.Length)] }) 