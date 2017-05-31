module MarsBaseBuilder.Tests.RendererTests

open Xunit

open MarsBaseBuilder
open MarsBaseBuilder.Measures

let mission = GameLogic.newMission

[<Fact>]
let ``mapToScreenPoint maps zero to 400, 300`` () =
    Assert.Equal({ x = 400<screenPx>; y = 300<screenPx> }, Renderer.mapToScreenPoint (gp 0 0))

[<Fact>]
let ``mapToScreenPoint maps as x + 400, y + 300`` () =
    let p = gp 100 200
    Assert.Equal({ x = 400<screenPx>; y = 300<screenPx> }, Renderer.mapToScreenPoint (gp 0 0))

[<Fact>]
let ``offset should move the screen point`` () =
    let p = sp 10 15
    Assert.Equal(Renderer.offset 5<screenPx> -5<screenPx> p, sp 15 10)

[<Fact>]
let ``Background should be drawn always`` () =
    Assert.Contains(Renderer.Background, Renderer.commands mission)

[<Fact>]
let ``Base resolves to rectangle`` () =
    let commands = Renderer.commands mission
    Assert.True(Seq.exists(function Renderer.Rectangle _ -> true | _ -> false) commands)

[<Fact>]
let ``Base drawn radius is 5 px`` () =
    let (Renderer.Rectangle(a, b)) = Renderer.draw (gp 5 5) Base
    Assert.Equal(10<screenPx>, b.x - a.x)
    Assert.Equal(10<screenPx>, b.y - a.y)
