module MarsBaseBuilder.Tests.GameLogicTests

open System

open Microsoft.Xna.Framework
open Xunit

open MarsBaseBuilder

let minute = TimeSpan.FromMinutes(1.0)
let gameMinute = GameTime(minute, minute)

[<Fact>]
let ``New mission should include a Base`` () =
    let state = GameLogic.newMission
    Assert.Contains(Base, state.units)

[<Fact>]
let ``Update should be callable`` () =
    let state = GameLogic.newMission
    let state' = GameLogic.update state gameMinute
    Assert.Equal(state, state')
    