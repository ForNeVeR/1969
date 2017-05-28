namespace MarsBaseBuilder

open Microsoft.Xna.Framework

type MarsBaseBuilderGame() =
    inherit Game()

    let marsColor = Color.IndianRed
    
    let mutable mission = GameLogic.newMission

    override this.Draw(gameTime) =
        this.GraphicsDevice.Clear(marsColor)
        base.Draw(gameTime)

    override this.Update(gameTime) =
        mission <- GameLogic.update mission gameTime
        ()
