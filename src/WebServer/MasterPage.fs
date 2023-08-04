namespace WebServer

module MasterPage = 
    open Giraffe.ViewEngine

    let masterPage (pageTitle:string) (content:XmlNode list) =
        html [ _lang "en"] [
            head [] [
                meta [ _charset "utf-8" ]
                title [] [encodedText pageTitle]
            ]
            body [] [
                main [] content
            ]
        ]


