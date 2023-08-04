namespace WebServer

module MasterPage =
    open Giraffe.ViewEngine

    let masterPage (pageTitle: string) (content: XmlNode list) =
        html
            [ _lang "en" ]
            [ head
                  []
                  [ meta [ _charset "utf-8" ]
                    meta [ _name "viewport"; _content "width=device-width, initial-scale=1.0" ]
                    link [ _rel "icon"; _type "image/svg+xml"; _href "./images/favicon.svg" ]
                    link [ _rel "stylesheet"; _href "/css/normalize.css" ]
                    link [ _rel "stylesheet"; _href "/css/main.css" ]
                    title [] [ encodedText pageTitle ] ]
              body [] [ main [] content ] ]
