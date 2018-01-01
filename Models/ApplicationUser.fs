namespace VueFsharpCore2.Models

open Microsoft.AspNetCore.Identity;

type ApplicationUser () =
    inherit IdentityUser()
    member val GivenName : string = null with get, set