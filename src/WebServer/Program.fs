namespace WebServer

open System

open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting

open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting

open Giraffe
open Giraffe.ViewEngine

open WebApp

module Program =


    let configureApp (app: IApplicationBuilder) = app.UseGiraffe(router)

    let configureServices (services: IServiceCollection) = services.AddGiraffe() |> ignore

    [<EntryPoint>]
    let main _ =
        Host
            .CreateDefaultBuilder()
            .ConfigureWebHostDefaults(fun webHostBuilder -> webHostBuilder.Configure(configureApp) |> ignore)
            .Build()
            .Run()

        0 // Exit code
