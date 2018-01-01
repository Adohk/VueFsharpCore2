namespace VueFsharpCore2.Controllers

open System.Linq
open Microsoft.AspNetCore.Mvc
open Microsoft.AspNetCore.Identity
open VueFsharpCore2.Models

[<Route("api/auth")>]
type AccountController
    ( db : AppDbContext 
    , userManager : UserManager<ApplicationUser>
    , signInManager : SignInManager<ApplicationUser> ) =
    inherit Controller()

    member x.UserManager = userManager
    member x.SignInManager = signInManager
    
    [<HttpPost("[action]")>]
    member API.Register() =         
        let x = 
            Async.StartAsTask 
            <|  
            async {
                let user = "adohk"
                let email = "adohk@adohk.com"
                let password = "!asdfASDF1234"        
                let appuser = ApplicationUser(UserName = user, Email = email)
                let! result = Async.AwaitTask <| API.UserManager.CreateAsync(appuser, password) 
                if result.Succeeded then
                    let! res = Async.AwaitTask <| API.SignInManager.PasswordSignInAsync(appuser, password, false, false)
                    return API.Ok([res.Succeeded]) :> IActionResult
                else
                    return API.BadRequest(result.Errors.ToList()) :> IActionResult
            }            
        x.Result

    [<HttpGet("[action]")>]
    member API.GetUsers() =         
        db.Users.ToList()


//TODO
(*
    Seed Admin
    Seed Roles
    Add user to role

    Add JWT to sync with frontend
    Add Auth route guards in frontend
*)