namespace MarsBaseBuilder

open System
open System.IO

open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Input

open MarsBaseBuilder.Textures

type MarsBaseBuilderGame(resourceBasePath : string) as this =
    inherit Game()

    let graphicsContext = lazy (new GraphicsContext(this.GraphicsDevice))

    let mutable mission = GameLogic.newMission
    let mutable textures = Unchecked.defaultof<TextureContainer>

    let loadCursor () =
        let cursor = MouseCursor.FromTexture2D(textures.cursor, 0, 0)
        Mouse.SetCursor(cursor)
        this.IsMouseVisible <- true

    override this.LoadContent() =
        let resourceDirectory = Path.Combine(resourceBasePath, "resources")
        textures <- Textures.load resourceDirectory this.GraphicsDevice
        loadCursor()

    override __.Draw(gameTime) =
        use draw = graphicsContext.Value.BeginDraw()
        Renderer.apply draw (Renderer.commands textures mission)
        base.Draw(gameTime)

    override __.Update(gameTime) =
        mission <- GameLogic.update mission gameTime
        ()
    
    override __.Dispose(disposing: bool) =
        if disposing && graphicsContext.IsValueCreated
        then (graphicsContext.Value :> IDisposable).Dispose()
