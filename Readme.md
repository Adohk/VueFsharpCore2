# VueFsharpCore2
Vue + Vuex | F# Dotnet Core 2.0
 * Based on https://github.com/MarkPieszak/aspnetcore-Vue-starter
 * Live Demo http://vuefsharpcore2.azurewebsites.net/


# Getting Started:
 * `dotnet restore`
 * `dotnet build`
 * `npm install`
 * `npm run dev` or `npm run prod` or `dotnet run`
 
 other commands: `npm run build`, `npm run build-all`, `npm run build-prod`, `npm run publish` 

 # Database Migrations:
 * A C# project with references to the F# DbContext and models.
 * Add a model and bind it to the context in the F# project then build
 * Travel to `../VueFsharpCore2/Migrator` and add a migration:
 * `dotnet ef migrations add [Name]`
 * To update the database:
 * `dotnet ef database update`