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
                    title [] [ encodedText pageTitle ] ]
              body [] [ main [] content ] ]
