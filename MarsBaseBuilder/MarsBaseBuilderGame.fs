namespace MarsBaseBuilder

open System

open Microsoft.Xna.Framework

type MarsBaseBuilderGame() as this =
    inherit Game()

    let graphicsContext = lazy (new GraphicsContext(this.GraphicsDevice))

    let mutable mission = GameLogic.newMission

    override this.Draw(gameTime) =
        use draw = graphicsContext.Value.BeginDraw()
        Renderer.apply draw (Renderer.commands mission)
        base.Draw(gameTime)

    override this.Update(gameTime) =
        mission <- GameLogic.update mission gameTime
        ()
    
    override this.Dispose(disposing: bool) =
        if disposing && graphicsContext.IsValueCreated
        then (graphicsContext.Value :> IDisposable).Dispose()
