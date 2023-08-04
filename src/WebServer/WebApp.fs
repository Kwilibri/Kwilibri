namespace WebServer

open Microsoft.AspNetCore.Http

open Giraffe
open Giraffe.ViewEngine
open MasterPage

module WebApp =

    let indexGet () =
        fun (next: HttpFunc) (ctx: HttpContext) ->
            let pageContent = [ p [] [ encodedText "Hello World" ] ]
            let view = pageContent |> masterPage "Kwilibri"
            (htmlView view) next ctx


    let router =
        fun (next: HttpFunc) (ctx: HttpContext) ->
            let route =
                choose
                    [ GET
                      >=> choose
                          [ route "/" >=> indexGet ()
                            route "/index" >=> indexGet ()
                            route "/home" >=> indexGet () ]
                      setStatusCode 404 >=> text "Error 404: Page not found" ]

            route next ctx
