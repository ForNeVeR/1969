module MarsBaseBuilder.Textures

open System.IO

open Microsoft.Xna.Framework.Graphics

type TextureContainer = {
    builder : Texture2D
}
    
let load (path : string) (graphics : GraphicsDevice) : TextureContainer =
    use builder = new FileStream(Path.Combine(path, "builder.png"), FileMode.Open)
    { builder = Texture2D.FromStream(graphics, builder) }
