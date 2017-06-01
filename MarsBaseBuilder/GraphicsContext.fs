namespace MarsBaseBuilder

open System

open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics

open MarsBaseBuilder.Measures

type GraphicsContext(device : GraphicsDevice) =
    let spriteBatch = new SpriteBatch(device)
    let blackColor = Color.Black
    let singlePixelTexture =
        let t = new Texture2D(device, 1, 1)
        t.SetData([| blackColor |])
        t
    
    interface IDisposable with
        override __.Dispose() =
            singlePixelTexture.Dispose()
            spriteBatch.Dispose()

    member __.Clear(color : Color) : unit =
        device.Clear color
    
    // TODO[F]: Extract these to a separate, more safe type
    member __.BeginDraw() : unit = spriteBatch.Begin()
    member __.EndDraw() : unit = spriteBatch.End()

    member __.Rectangle(a : ScreenPoint, b : ScreenPoint) : unit =
        let position = Rectangle(int a.x, int a.y, int (b.x - a.x), int (b.y - a.y))
        spriteBatch.Draw(singlePixelTexture, destinationRectangle = Nullable position(*, blackColor*))
