namespace VueFsharpCore2.Controllers

open System
open Microsoft.AspNetCore.Mvc

// type WeatherForecast(dateFormatted : string,
//                      temperatureC  : int,
//                      summary       : string) =
//     member x.dateFormatted = dateFormatted
//     member x.temperatureC = temperatureC
//     member x.summary = summary
//     member x.temperatureF = (float)temperatureC / 0.5556   

type WeatherForecast =
    { dateFormatted : string
      temperatureC  : int
      summary       : string } 
    member x.temperatureF = (float)x.temperatureC / 0.5556   

[<Route("api/[controller]")>]
type SampleDataController () =
    inherit Controller()

    let summaries = [| "Freezing"; "Bracing"; "Chilly"; "Cool"; "Mild"; "Warm"; "Balmy"; "Hot"; "Sweltering"; "Scorching" |]

    [<HttpGet("WeatherForecasts")>]
    member this.WeatherForecasts() =
        let rng = Random()
        let data = 
            [1 .. 5] |> List.map (fun i ->
                { 
                    dateFormatted = DateTime.Now.AddDays((float)i).ToString("d"); 
                    temperatureC = rng.Next(-20, 55);
                    summary = summaries.[rng.Next(summaries.Length)] 
                })
        data
                   