module MarsBaseBuilder.Tests.GameLogicTests

open System

open Microsoft.Xna.Framework
open Xunit

open MarsBaseBuilder
open MarsBaseBuilder.Measures

let minute = TimeSpan.FromMinutes 1.0
let gameMinute = GameTime(minute, minute)

[<Fact>]
let ``New mission should include a Base`` () =
    let state = GameLogic.newMission
    Assert.True(Map.containsKey Base state.units)
    Assert.Equal(originTransform, Map.find Base state.units)

[<Fact>]
let ``New mission should include a Builder`` () =
    let state = GameLogic.newMission
    let transform = {originTransform with position = pp 30 30; rotation = deg 30.0f}
    Assert.True(Map.containsKey Builder state.units)
    Assert.Equal(transform, Map.find Builder state.units)

[<Fact>]
let ``Update should be callable`` () =
    let state = GameLogic.newMission
    let state' = GameLogic.update state gameMinute
    Assert.Equal(state, state')
    