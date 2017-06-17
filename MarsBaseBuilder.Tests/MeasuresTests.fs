module MarsBaseBuilder.Tests.MeasuresTests

open Xunit

open MarsBaseBuilder.Measures

[<Fact>]
let ``PhysicalPoint parameters are proper after its' creation`` () =
    let p = pp 10 5
    let expected : PhysicalPoint = { x = 10<dm>; y = 5<dm> }
    Assert.Equal(expected, p)

[<Fact>]
let ``ScreenPoint parameters are proper after its' creation`` () =
    let p = sp 100 300
    let expected = { x = 100<px>; y = 300<px> }
    Assert.Equal(expected, p)

[<Fact>]
let ``Degrees to radians conversion works proper`` () =
    let angleInDeg = deg 90.0f
    let angleInRad = pi/2.0f
    Assert.Equal(angleInRad, deg2rad angleInDeg)
