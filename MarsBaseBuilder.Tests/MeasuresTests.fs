module MarsBaseBuilder.Tests.MeasuresTests

open Xunit

open MarsBaseBuilder.Measures

[<Fact>]
let ``Position parameters are proper after its' creation`` () =
    let p = gp 10 5
    let expected : Position = { x = 10<gameUnit>; y = 5<gameUnit> }
    Assert.Equal(expected, p)

[<Fact>]
let ``ScreenPoint parameters are proper after its' creation`` () =
    let p = sp 100 300
    let expected = { x = 100<screenPx>; y = 300<screenPx> }
    Assert.Equal(expected, p)
