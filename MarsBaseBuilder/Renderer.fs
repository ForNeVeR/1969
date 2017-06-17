module MarsBaseBuilder.Renderer

open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics

open MarsBaseBuilder.Measures
open MarsBaseBuilder.Textures

type DrawCommand =
    | Background
    | Rectangle of a : ScreenPoint * b : ScreenPoint
    | Sprite of center : ScreenTransform * texture : Texture2D

let internal mapToScreenPoint (p : PhysicalPoint) : ScreenPoint =
    { x = 400<px> + (int p.x) * 1<px>
      y = 300<px> + (int p.y) * 1<px> }

let internal mapToScreenTransform (t : PhysicalTransform) : ScreenTransform = 
    {
        position = mapToScreenPoint t.position
        rotation = deg2rad t.rotation
    }

let internal offset x y (sp : ScreenPoint) =
    { sp with x = sp.x + x; y = sp.y + y }

let baseRadius = 5<px>
let internal draw (textures : TextureContainer) (transform : PhysicalTransform) : GameUnit -> DrawCommand =
    let screenTransform = mapToScreenTransform transform
    function
    | Base -> 
        let topLeft = offset (-baseRadius) (-baseRadius) screenTransform.position
        let rightBottom = offset baseRadius baseRadius screenTransform.position
        Rectangle (topLeft, rightBottom)

    | Builder -> Sprite (screenTransform, textures.builder)

let commands (textures : TextureContainer) (state : GameLogic.GameState) : ResizeArray<DrawCommand> =
    let drawUnit = draw textures
    let list = ResizeArray()
    list.Add Background
    state.units |> Map.iter (fun u p -> drawUnit p u |> list.Add)
    list

let marsColor = Color.IndianRed
let apply (draw : IDrawingContext) (commands : ResizeArray<DrawCommand>) : unit =
    for c in commands do
        match c with
        | Background -> draw.Clear marsColor
        | Rectangle (a, b) -> draw.Rectangle(a, b)
        | Sprite(c, t) -> draw.Texture(c, t)
