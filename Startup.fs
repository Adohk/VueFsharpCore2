namespace VueFsharpCore2

open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Logging
open Microsoft.AspNetCore.SpaServices.Webpack

type Startup private () =
    new (env: IHostingEnvironment) as this =
        Startup() then
        let builder = ConfigurationBuilder()
        builder.SetBasePath(env.ContentRootPath) |> ignore
        builder.AddJsonFile("appsettings.json", optional = true, reloadOnChange = true) |> ignore
        builder.AddEnvironmentVariables() |> ignore                         
        //this.Configuration <- configuration
        this.Configuration <- builder.Build()

    member val Configuration : IConfigurationRoot = null with get, set

    member this.ConfigureServices(services: IServiceCollection) =
        services.AddMvc() |> ignore

    member this.Configure(app: IApplicationBuilder, env: IHostingEnvironment, loggerFactory: ILoggerFactory) =        
        loggerFactory.AddConsole(this.Configuration.GetSection("Logging")) |> ignore
        loggerFactory.AddDebug() |> ignore

        if (env.IsDevelopment()) then
            app.UseDeveloperExceptionPage() |> ignore

            let options = WebpackDevMiddlewareOptions();
            options.HotModuleReplacement <- true
            app.UseWebpackDevMiddleware(options)
        else
            app.UseExceptionHandler("/Home/Error") |> ignore

        app.UseStaticFiles() |> ignore

        app.UseMvc(fun routes ->            
            routes.MapRoute(
                name = "default",
                template = "{controller=Home}/{action=Index}/{id?}") |> ignore
            routes.MapSpaFallbackRoute(
                name = "spa-fallback",
                defaults = "{controller=Home}/{action=Index}") |> ignore
        ) |> ignore    
