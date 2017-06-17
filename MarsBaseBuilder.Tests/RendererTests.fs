module MarsBaseBuilder.Tests.RendererTests

open Foq
open Microsoft.Xna.Framework.Graphics
open Xunit

open MarsBaseBuilder
open MarsBaseBuilder.Measures
open MarsBaseBuilder.Textures

let private mockDrawingContext () =
    Mock<IDrawingContext>()
        .SetupMethod(fun c -> <@ c.Rectangle @>).Returns(())
        .SetupMethod(fun c -> <@ c.Texture @>).Returns(())
        .Create()
let private mockTexture () = Mock<Texture2D>().Create()
let private textures = { builder = mockTexture() }

[<Fact>]
let ``mapToScreenPoint maps zero to 400, 300`` () =
    Assert.Equal(sp 400 300, Renderer.mapToScreenPoint (pp 0 0))

[<Fact>]
let ``mapToScreenTransform maps origin to position 400, 300`` () =
    let expected : ScreenTransform = 
        { position = sp 400 300
          rotation = rad 0.0f }
    Assert.Equal(expected, Renderer.mapToScreenTransform origin)

[<Fact>]
let ``mapToScreenPoint maps as x + 400, y + 300`` () =
    let x = 100
    let y = 200
    Assert.Equal(sp (x + 400) (y + 300), Renderer.mapToScreenPoint (pp x y))

[<Fact>]
let ``mapToScreenTransform maps as x + 400, y + 300 and rotation from deg to rad`` () =
    let x = 100
    let y = 200
    let rotDeg = deg 60.0f
    let rotRad = pi/3.0f

    let expected : ScreenTransform =
        { position = sp (x + 400) (y + 300)
          rotation = rotRad }
    let actual : PhysicalTransform = 
        { position = pp x y; 
          rotation = rotDeg }
    Assert.Equal(expected, Renderer.mapToScreenTransform actual)

[<Fact>]
let ``offset should move the screen point`` () =
    let p = sp 10 15
    Assert.Equal(Renderer.offset 5<px> -5<px> p, sp 15 10)

[<Fact>]
let ``Background should be drawn always`` () =
    Assert.Contains(Renderer.Background, Renderer.commands textures GameLogic.newMission)

[<Fact>]
let ``Base drawn radius is 5 px`` () =
    let transform = { origin with position = pp 5 5 }
    let (Renderer.Rectangle(a, b)) = Renderer.draw textures transform Base
    Assert.Equal(10<px>, b.x - a.x)
    Assert.Equal(10<px>, b.y - a.y)

[<Fact>]
let ``Builder should use a builder sprite`` () =
    let transform = { origin with position = pp 10 10 }
    let (Renderer.Sprite(center, t)) = Renderer.draw textures transform Builder
    Assert.Equal(Renderer.mapToScreenTransform transform, center)
    Assert.Equal(textures.builder, t)
    ()

[<Fact>]
let ``Background should clear the screen`` () =
    let context =
        Mock<IDrawingContext>()
            .SetupMethod(fun c -> <@ c.Clear @>).Returns(())
            .Create()
    
    let commands = ResizeArray([| Renderer.Background |])
    Renderer.apply context commands

    Mock.Verify(<@ context.Clear @>, once)

[<Fact>]
let ``Rectangle drawing should be proxied to context`` () =
    let context = mockDrawingContext()
    let p = sp 10 10
    let commands = ResizeArray([| Renderer.Rectangle(p, p) |])

    Renderer.apply context commands
    Mock.Verify(<@ context.Rectangle(p, p) @>, once)

[<Fact>]
let ``Sprite drawing should be performed`` () =
    let context = mockDrawingContext()
    let transform : ScreenTransform = { position = sp 5 5; rotation = rad 0.0f }
    let texture = mockTexture()
    let commands = ResizeArray([| Renderer.Sprite(transform, texture) |])

    Renderer.apply context commands
    Mock.Verify(<@ context.Texture(transform, texture) @>, once)
