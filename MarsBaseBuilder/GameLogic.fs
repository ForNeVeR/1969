module MarsBaseBuilder.GameLogic

open Microsoft.Xna.Framework

type GameState = {
    units : Set<GameUnit>
}

let newMission = { units = Set([|Base|]) }

let update (state : GameState) (timeDelta : GameTime) : GameState = state
