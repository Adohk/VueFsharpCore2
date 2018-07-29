namespace VueFsharpCore2.Models

open System
open System.ComponentModel.DataAnnotations

type LoginViewModel () =
    [<Required>]
    member val Email : string = null with get, set

    [<Required>]
    member val Password : string = null with get, set
