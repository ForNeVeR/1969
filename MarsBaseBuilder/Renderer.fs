module MarsBaseBuilder.Renderer

open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics

open MarsBaseBuilder.Measures

type DrawCommand = 
    | Background
    | Rectangle of a : ScreenPoint * b : ScreenPoint

let internal mapToScreenPoint (p : Position) : ScreenPoint =
    { x = 400<screenPx> + (p.x * 1<screenPx/gameUnit>)
      y = 300<screenPx> + (p.y * 1<screenPx/gameUnit>) }

let internal offset x y (sp : ScreenPoint) =
    { sp with x = sp.x + x; y = sp.y + y }

let baseRadius = 5<screenPx>
let internal draw coords = function
    | Base -> 
        let pos = mapToScreenPoint coords
        Rectangle (offset (-baseRadius) (-baseRadius) pos, offset baseRadius baseRadius pos)

let commands (state : GameLogic.GameState) : ResizeArray<DrawCommand> =
    let list = ResizeArray()
    list.Add Background
    state.units |> Map.iter (fun u p -> draw p u |> list.Add)
    list

let marsColor = Color.IndianRed
let apply (graphics : GraphicsDevice) (commands : ResizeArray<DrawCommand>) : unit =
    for c in commands do
        match c with
        | Background -> graphics.Clear marsColor
        | Rectangle (a, b) -> () // TODO[F]: Draw a rectangle
