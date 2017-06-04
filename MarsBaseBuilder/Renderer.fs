module MarsBaseBuilder.Renderer

open Microsoft.Xna.Framework

open MarsBaseBuilder.Measures

type DrawCommand = 
    | Background
    | Rectangle of a : ScreenPoint * b : ScreenPoint

let internal mapToScreenPoint (p : PhysicalPoint) : ScreenPoint =
    { x = 400<px> + (int p.x) * 1<px>
      y = 300<px> + (int p.y) * 1<px> }

let internal offset x y (sp : ScreenPoint) =
    { sp with x = sp.x + x; y = sp.y + y }

let baseRadius = 5<px>
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
let apply (draw : IDrawingContext) (commands : ResizeArray<DrawCommand>) : unit =
    for c in commands do
        match c with
        | Background -> draw.Clear marsColor
        | Rectangle (a, b) -> draw.Rectangle(a, b)
