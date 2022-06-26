using Microsoft.Xna.Framework.Graphics;

namespace Ancient.Demo.Platformer.Components;
public class TextureComponent : EntityComponentBase
{
    public Texture2D Texture { get; set; }

    public TextureComponent(Texture2D texture)
    {
        Texture = texture;
    }
}
