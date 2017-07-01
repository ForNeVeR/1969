module MarsBaseBuilder.Program

open System
open System.IO
open System.Reflection

open Microsoft.Xna.Framework

let private getExecutableDirectoryPath () =
    let codeBase = Uri(Assembly.GetExecutingAssembly().CodeBase)
    Path.GetDirectoryName codeBase.AbsolutePath

[<EntryPoint>]
let main argv =
    let path = getExecutableDirectoryPath()
    printfn "Starting game in %s" path
    use game = new MarsBaseBuilderGame(path)
    use graphics = new GraphicsDeviceManager(game)

    game.Run()

    printfn "Exiting game"
    0
