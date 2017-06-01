namespace MarsBaseBuilder

open System

open Microsoft.Xna.Framework

type MarsBaseBuilderGame() as this =
    inherit Game()

    let graphicsContext = lazy (new GraphicsContext(this.GraphicsDevice))
    let render = lazy (Renderer.apply graphicsContext.Value)

    let mutable mission = GameLogic.newMission

    override this.Draw(gameTime) =        
        render.Value (Renderer.commands mission)
        base.Draw(gameTime)

    override this.Update(gameTime) =
        mission <- GameLogic.update mission gameTime
        ()
    
    override this.Dispose(disposing: bool) =
        if disposing && graphicsContext.IsValueCreated
        then (graphicsContext.Value :> IDisposable).Dispose()
