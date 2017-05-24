namespace MarsBaseBuilder

open Microsoft.Xna.Framework

type MarsBaseBuilderGame() =
    inherit Game()

    let marsColor = Color.IndianRed

    override this.Draw(gameTime) =
        this.GraphicsDevice.Clear(marsColor)
        base.Draw(gameTime)
