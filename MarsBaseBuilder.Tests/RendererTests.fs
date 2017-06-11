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
    Assert.Equal({ x = 400<px>; y = 300<px> }, Renderer.mapToScreenPoint (pp 0 0))

[<Fact>]
let ``mapToScreenPoint maps as x + 400, y + 300`` () =
    let p = pp 100 200
    Assert.Equal({ x = 400<px>; y = 300<px> }, Renderer.mapToScreenPoint (pp 0 0))

[<Fact>]
let ``offset should move the screen point`` () =
    let p = sp 10 15
    Assert.Equal(Renderer.offset 5<px> -5<px> p, sp 15 10)

[<Fact>]
let ``Background should be drawn always`` () =
    Assert.Contains(Renderer.Background, Renderer.commands textures GameLogic.newMission)

[<Fact>]
let ``Base drawn radius is 5 px`` () =
    let (Renderer.Rectangle(a, b)) = Renderer.draw textures (pp 5 5) Base
    Assert.Equal(10<px>, b.x - a.x)
    Assert.Equal(10<px>, b.y - a.y)

[<Fact>]
let ``Builder should use a builder sprite`` () =
    let pos = pp 10 10
    let (Renderer.Sprite(center, t)) = Renderer.draw textures pos Builder
    Assert.Equal(Renderer.mapToScreenPoint pos, center)
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
    let p = sp 5 5
    let texture = mockTexture()
    let commands = ResizeArray([| Renderer.Sprite(p, texture) |])

    Renderer.apply context commands
    Mock.Verify(<@ context.Texture(p, texture) @>, once)
