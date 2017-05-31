namespace MarsBaseBuilder

open Microsoft.Xna.Framework

type MarsBaseBuilderGame() =
    inherit Game()

    let mutable mission = GameLogic.newMission

    override this.Draw(gameTime) =
        let render = Renderer.apply this.GraphicsDevice
        render (Renderer.commands mission)
        base.Draw(gameTime)

    override this.Update(gameTime) =
        mission <- GameLogic.update mission gameTime
        ()
