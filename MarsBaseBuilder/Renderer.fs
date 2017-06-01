module MarsBaseBuilder.Renderer

open Microsoft.Xna.Framework

open MarsBaseBuilder.Measures

type DrawCommand = 
    | Background
    | Rectangle of a : ScreenPoint * b : ScreenPoint

let internal mapToScreenPoint (p : Position) : ScreenPoint =
    { x = 400<screenPx> + (int p.x) * 1<screenPx>
      y = 300<screenPx> + (int p.y) * 1<screenPx> }

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
let apply (context : IGraphicsContext) (commands : ResizeArray<DrawCommand>) : unit =
    context.BeginDraw()
    for c in commands do
        match c with
        | Background -> context.Clear marsColor
        | Rectangle (a, b) -> context.Rectangle(a, b)
    context.EndDraw()
