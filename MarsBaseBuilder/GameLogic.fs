module MarsBaseBuilder.GameLogic

open Microsoft.Xna.Framework

open MarsBaseBuilder.Measures

type GameState = {
    units : Map<GameUnit, Position>
}

let newMission = { units = Map([|Base, gp 0 0|]) }

let update (state : GameState) (timeDelta : GameTime) : GameState = state
