namespace MarsBaseBuilder

open System

open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics

open MarsBaseBuilder.Measures

type IDrawingContext =
    inherit IDisposable
    abstract member Clear : Color -> unit
    abstract member Rectangle : ScreenPoint * ScreenPoint -> unit
    abstract member Texture : ScreenTransform * Texture2D -> unit

type IGraphicsContext =
    abstract member BeginDraw : unit -> IDrawingContext

type GraphicsContext(device : GraphicsDevice) =
    let spriteBatch = new SpriteBatch(device)
    let blackColor = Color.Black
    let singlePixelTexture =
        let t = new Texture2D(device, 1, 1)
        t.SetData([| blackColor |])
        t

    interface IDisposable with
        member __.Dispose() =
            singlePixelTexture.Dispose()
            spriteBatch.Dispose()

    member __.BeginDraw() =
        spriteBatch.Begin()
        { new IDrawingContext with
              member __.Dispose() = spriteBatch.End()

              member __.Clear(color : Color) : unit =
                  device.Clear color

              member __.Rectangle(a : ScreenPoint, b : ScreenPoint) : unit =
                  let position = Rectangle(int a.x, int a.y, int (b.x - a.x), int (b.y - a.y))
                  spriteBatch.Draw(singlePixelTexture, destinationRectangle = Nullable position)

              member __.Texture(st : ScreenTransform, t : Texture2D) : unit =
                  let v = Vector2(float32 st.position.x, float32 st.position.y)
                  let rot = float32 st.rotation
                  spriteBatch.Draw(t, position = Nullable v, rotation = rot) }
