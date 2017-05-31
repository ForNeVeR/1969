module MarsBaseBuilder.Measures

[<Measure>]
type gameUnit

[<Measure>]
type screenPx

[<Struct>]
type Position = {
    x : int<gameUnit>
    y : int<gameUnit>
}

[<Struct>]
type ScreenPoint = {
    x : int<screenPx>
    y : int<screenPx>
}

let gp (x : int) (y : int) : Position = { x = x * 1<gameUnit>; y = y * 1<gameUnit> }
let sp (x : int) (y : int) : ScreenPoint = { x = x * 1<screenPx>; y = y * 1<screenPx> }
