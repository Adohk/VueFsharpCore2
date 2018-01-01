namespace VueFsharpCore2

open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Logging
open Microsoft.AspNetCore.SpaServices.Webpack

type FallbackDefaults =
    { controller : string
      action     : string }
   
type Startup private () =
    new (configuration : IConfiguration) as this =
        Startup() then
        this.Configuration <- configuration

    member val Configuration : IConfiguration = null with get, set

    member this.ConfigureServices(services: IServiceCollection) =
        services.AddMvc() |> ignore

    member this.Configure(app: IApplicationBuilder, env: IHostingEnvironment, loggerFactory: ILoggerFactory) =
        loggerFactory
            .AddConsole(this.Configuration.GetSection("Logging"))
            .AddDebug() |> ignore
        System.Console.WriteLine(env.IsDevelopment())
        if (env.IsDevelopment()) then
            let options = WebpackDevMiddlewareOptions()
            options.HotModuleReplacement <- true
            app.UseDeveloperExceptionPage() |> ignore            
            app.UseWebpackDevMiddleware(options)
        else
            app.UseExceptionHandler("/Home/Error") |> ignore

        let spaFallbackDefaults = { controller = "Home"; action = "Index"}
        app
            .UseStaticFiles()
            .UseMvc(fun routes ->
            routes.MapRoute(
                name = "default",
                template = "{controller=Home}/{action=Index}/{id?}") |> ignore
            routes.MapSpaFallbackRoute(
                name = "spa-fallback",
                defaults = spaFallbackDefaults) |> ignore
            ) |> ignore