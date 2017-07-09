module MarsBaseBuilder.Textures

open System.IO

open Microsoft.Xna.Framework.Graphics

type TextureContainer = {
    builder : Texture2D
    cursor : Texture2D
}
    
let load (path : string) (graphics : GraphicsDevice) : TextureContainer =
    let fromFile fileName =
        use stream = new FileStream(Path.Combine(path, fileName), FileMode.Open)
        Texture2D.FromStream(graphics, stream)
    { builder = fromFile "builder.png"
      cursor = fromFile "cursor.png" }
