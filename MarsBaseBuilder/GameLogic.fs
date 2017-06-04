module MarsBaseBuilder.GameLogic

open Microsoft.Xna.Framework

open MarsBaseBuilder.Measures

type GameState = {
    units : Map<GameUnit, PhysicalPoint>
}

let newMission = { units = Map([|Base, pp 0 0|]) }

let update (state : GameState) (timeDelta : GameTime) : GameState = state
