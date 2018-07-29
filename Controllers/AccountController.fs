namespace VueFsharpCore2.Controllers

open System.Linq
open Microsoft.AspNetCore.Mvc
open Microsoft.AspNetCore.Identity
open VueFsharpCore2.Models
open Microsoft.AspNetCore.Authorization
open Microsoft.Extensions.Configuration
open Microsoft.IdentityModel.Tokens
open System.IdentityModel.Tokens.Jwt
open Microsoft.AspNetCore.Cors
open System.Security.Claims
open System
open System.Text
open Microsoft.AspNetCore.Mvc.Filters
open Microsoft.AspNetCore.Identity

type TokenResult =
    { token : string }



[<EnableCors("CORSPolicy")>]
[<Route("api/auth")>]
type AccountController
    ( db : AppDbContext 
    , userManager : UserManager<ApplicationUser>
    , signInManager : SignInManager<ApplicationUser>
    , configuration : IConfiguration ) =
    inherit Controller()

    member x.UserManager = userManager
    member x.SignInManager = signInManager
    member x.Configuration = configuration
    
    [<DefaultValue>] 
    val mutable currentUser : ApplicationUser
    member x.CurrentUser with get() = x.currentUser and set v = x.currentUser <- v


    // override x.OnActionExecuted(filterContext : ActionExecutedContext) =                
    //     let isAuth = filterContext.HttpContext.User.Identity.IsAuthenticated
    //     if isAuth then
    //         let userId = filterContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value
    //         let user = Async.StartAsTask <| async { return Async.AwaitTask <| x.UserManager.FindByIdAsync(userId) }
    //         x.CurrentUser <- user.Result            
    //         ()        

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
    
    [<HttpGet("[action]")>]
    member API.LoginTest1() =
        let isAuth = API.User.Identity.IsAuthenticated
        String.Format("Hello!, Are you authenticated? {0}", isAuth.ToString())
        
    [<Authorize>]
    [<HttpGet("[action]")>]
    member API.LoginTest2() =
        let isAuth = API.User.Identity.IsAuthenticated
        String.Format("Hello!, Are you authenticated? {0}", isAuth.ToString())

    [<Authorize(Roles = "Admin, SuperAdmin")>]
    [<HttpGet("[action]")>]
    member API.LoginTest3() =
        let roles = API.User.Claims.Where(fun c -> c.Type = ClaimTypes.Role).Select(fun x -> x.Value).ToList();
        String.Format("Hello!, You must be authenticated!, Your roles are: {0}", String.Join(", ", roles))

    [<Authorize(Roles = "SomeRole")>]
    [<HttpGet("[action]")>]
    member API.LoginTest4() =
        "You shouldn't be here!"

    [<HttpPost("Login")>]
    member API.GetToken( [<FromBody>] model:LoginViewModel ) =
        if API.TryValidateModel(model) then
            let asyncResult = 
                Async.StartAsTask 
                <| async {
                    let! user = Async.AwaitTask <| API.UserManager.FindByEmailAsync(model.Email)
                    match box user with
                    | null -> return API.Unauthorized() :> IActionResult
                    | _ -> 
                        let! loginResult = Async.AwaitTask <| API.SignInManager.CheckPasswordSignInAsync(user, model.Password, false)
                        if loginResult.Succeeded then
                            let claims : Claim list = 
                                [ Claim(JwtRegisteredClaimNames.Sub, user.Id)
                                ; Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()); ]
                            
                            let! roles = Async.AwaitTask <| API.UserManager.GetRolesAsync(user)
                            let claimList = claims.ToList()
                            for role in roles do
                                let roleClaim = Claim (ClaimTypes.Role, role)
                                claimList.Add(roleClaim)
                                
                            let credentials = 
                                SigningCredentials(SymmetricSecurityKey
                                    ( Encoding.UTF8.GetBytes(API.Configuration.["Token:Key"]))
                                    , SecurityAlgorithms.HmacSha256 )

                            let token = 
                                JwtSecurityToken
                                    ( claims = claimList
                                    , signingCredentials = credentials
                                    , notBefore = Nullable DateTime.UtcNow
                                    , expires = Nullable (DateTime.UtcNow.AddMinutes(30.)) )

                            let stringToken = JwtSecurityTokenHandler().WriteToken(token)

                            return API.Ok( stringToken ) :> IActionResult
                        else
                            return API.Unauthorized() :> IActionResult
                }
            asyncResult.Result
        else
            API.BadRequest(API.ModelState.Select(fun e -> e.Value.Errors)) :> IActionResult


//TODO
(*
    Seed Admin
    Seed Roles
    Add user to role

    Add JWT to sync with frontend
    Add Auth route guards in frontend
*)
