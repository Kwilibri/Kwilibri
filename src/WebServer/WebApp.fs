namespace WebServer

open Microsoft.AspNetCore.Http

open Giraffe
open Giraffe.ViewEngine
open MasterPage

module WebApp =

    let indexGet () =
        fun (next: HttpFunc) (ctx: HttpContext) ->
            let pageContent =
                [ div [] []
                  section
                      []
                      [ p
                            []
                            [ encodedText
                                  "Kwilibri is a software and services company based in Johannesburg, South Africa." ]
                        p
                            []
                            [ encodedText
                                  "We help organizations and busy people get things done while being compliant with relevant legislation and regulations." ]
                        p
                            []
                            [ encodedText
                                  "For more information you can contact us on info@kwilibri.com or by phone at (+ 27)11 083 6706." ]
                        p
                            []
                            [ encodedText "You can also log a service request on our "
                              a [ _href "https://kwilibri.freshdesk.com/" ] [ rawText "support portal." ] ] ]
                  div [] []
                  div [] []
                  div [] []
                  div [] [] ]

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
