namespace VueFsharpCore2.Controllers

open System
open Microsoft.AspNetCore.Mvc

//Record type for structuring data
type WeatherForecast =
    { date          : DateTime
      temperatureC  : float
      summary       : string }
    member x.temperatureF = Math.Round((x.temperatureC * 1.8 + 32.), 1)
    member x.dateFormatted = x.date.ToString("d")

//We use a module to avoid unnecesary calls from the API members
module WeatherForecastUtils =
    let private rng = Random()
    let private summaries = [| "Freezing"; "Bracing"; "Chilly"; "Cool"; "Mild"; "Warm"; "Balmy"; "Hot"; "Sweltering"; "Scorching" |]
    let private min = -20.
    let private max = 50.

    //We take the current temp and check against the summaries in a range based on the min and max temps
    let GetSummary(x) =
        let xx = x + abs min
        let yy = abs min + max
        let i = floor xx / (yy / float summaries.Length)
        match i with
        | x when x < 1. -> summaries.[int i]
        | _ -> summaries.[int i - 1]
        
    //We create a random temp and use the record type to create a new forecast and call GetSummary inside the record
    let CreateNew(i) =
        let calc = Math.Round(min + rng.NextDouble() * (max - min), 1)
        { date = DateTime.Now.AddDays(i);
          temperatureC = calc;
          summary = GetSummary calc }

[<Route("api/[controller]")>]
type SampleDataController () =
    inherit Controller()

    // GET /api/SampleData
    [<HttpGet>]
    member API.Get() =
        API.Ok(["Hello! This the Controller Get!"])

    // POST /api/SampleData
    //Multiple paths, send json either true or false!
    [<HttpPost>]
    member API.Post([<FromBody>] isAuth) =
        match isAuth with
        | true  -> API.Ok(["You are authorized!"]) :> IActionResult
        | false -> API.BadRequest(["You are not authorized on this endpoint"]) :> IActionResult

    // GET /api/SampleData/WeatherForecasts
    [<HttpGet("[action]")>]
    member API.WeatherForecasts() =
        API.Ok([1. .. 5.] |> List.map WeatherForecastUtils.CreateNew)
