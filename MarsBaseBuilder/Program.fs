module MarsBaseBuilder.Program

open Microsoft.Xna.Framework

[<EntryPoint>]
let main argv =
    printfn "Starting game"
    use game = new MarsBaseBuilderGame()
    use graphics = new GraphicsDeviceManager(game)

    game.Run()

    printfn "Exiting game"
    0
