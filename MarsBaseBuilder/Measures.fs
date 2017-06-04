module MarsBaseBuilder.Measures

[<Measure>]
type dm

[<Measure>]
type px

[<Struct>]
type PhysicalPoint = {
    x : int<dm>
    y : int<dm>
}

[<Struct>]
type ScreenPoint = {
    x : int<px>
    y : int<px>
}

let pp (x : int) (y : int) : PhysicalPoint = { x = x * 1<dm>; y = y * 1<dm> }
let sp (x : int) (y : int) : ScreenPoint = { x = x * 1<px>; y = y * 1<px> }
