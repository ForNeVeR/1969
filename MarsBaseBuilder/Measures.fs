module MarsBaseBuilder.Measures

[<Measure>]
type dm

[<Measure>]
type px

[<Measure>]
type rad

[<Measure>]
type deg

[<Struct>]
type PhysicalPoint = 
    { x : int<dm>
      y : int<dm> }

[<Struct>]
type PhysicalTransform = 
    { position : PhysicalPoint
      rotation : float32<deg> }

[<Struct>]
type ScreenPoint = 
    { x : int<px>
      y : int<px> }

[<Struct>]
type ScreenTransform = 
    { position : ScreenPoint
      rotation : float32<rad> }

let pp (x : int) (y : int) : PhysicalPoint = { x = x * 1<dm>; y = y * 1<dm> }
let sp (x : int) (y : int) : ScreenPoint = { x = x * 1<px>; y = y * 1<px> }

let deg (angle : float32) : float32<deg> = angle * 1.0f<deg>
let rad (angle : float32) : float32<rad> = angle * 1.0f<rad>

let pi = rad <| (float32) System.Math.PI
let deg2rad (angle : float32<deg>) : float32<rad> =
    let coeff = pi/180.0f<deg>
    angle*coeff

let origin : PhysicalTransform = {position = (pp 0 0); rotation = deg 0.0f}
