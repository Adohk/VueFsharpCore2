namespace VueFsharpCore2.Models

open System.ComponentModel.DataAnnotations

type Contact()=
    [<Key>]
    member val Id : int = 0 with get, set

    [<Required>]
    [<MinLength(3)>]
    member val FirstName : string = null with get, set

    [<Required>]
    [<MinLength(3)>]
    [<StringLength(255, MinimumLength = 3)>]
    member val LastName : string = null with get, set

    [<Required>]
    member val Phone : string = null with get, set

    [<Required>]
    [<DataType(DataType.EmailAddress)>]
    [<StringLength(40, MinimumLength = 0)>]
    member val Email : string = null with get, set