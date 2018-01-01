namespace VueFsharpCore2.Controllers

open System
open System.Web
open System.Linq
open System.Collections.Generic
open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Mvc
open Microsoft.EntityFrameworkCore
open VueFsharpCore2.Models
open Microsoft.EntityFrameworkCore.Metadata.Internal
open Microsoft.AspNetCore.Rewrite.Internal.ApacheModRewrite
open Microsoft.CodeAnalysis.Semantics
open Microsoft.AspNetCore.Mvc
open Microsoft.AspNetCore.Mvc

[<Route("api/[controller]")>]
type DbDataController (db:AppDbContext) =
    inherit Controller()
    
    //Api/DbData/CreateContact
    //[<FromBody>] newContact:Contact
    [<HttpPost("[action]")>]
    member API.CreateContact() = 
        let newContact = Contact(Email = "test@test.com", FirstName = "Adohk", LastName = "321", Phone = "123" )
        if API.TryValidateModel(newContact) then
            try
                db.Contacts.Add(newContact) |> ignore
                db.SaveChanges() |> ignore
                let id = db.Contacts.Local.Single().Id
                API.Ok(db.Contacts.Find(id)) :> IActionResult
            with
                | ex -> API.BadRequest([ex.Message]) :> IActionResult
        else
            API.BadRequest(API.ModelState.Select(fun e -> e.Value.Errors)) :> IActionResult

    [<HttpGet("[action]")>]
    member API.ContactsData() = 
        db.Contacts.ToList()

    [<HttpGet("id/{id}")>]
    member API.ContactsData(id:int) = 
        db.Contacts.Find(id)
        
    [<HttpGet("name/{FirstName}")>]
    member API.ContactsData(firstName:string) = 
        db.Contacts.Where(fun x -> x.FirstName = firstName)
    