module MarsBaseBuilder.Textures

open Microsoft.Xna.Framework.Content
open Microsoft.Xna.Framework.Graphics

type TextureContainer = {
    builder : Texture2D
}
    
let load (content : ContentManager) : TextureContainer =
    { builder = content.Load "builder" }
