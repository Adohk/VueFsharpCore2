namespace VueFsharpCore2.Controllers

open Microsoft.AspNetCore.Mvc

type HomeController () =
    inherit Controller()

    member this.Index () =
        this.View()

    member this.Error () =
        this.View();
