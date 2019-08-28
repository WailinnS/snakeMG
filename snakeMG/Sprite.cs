using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace snakeMG
{
    public class Sprite
    {
        public Vector2 Position { get; set; }
        public Texture2D Image { get; set; }
        public Color Tint { get; set; }

        public Sprite(Vector2 position, Texture2D image, Color tint)
        {
            Position = position;
            Image = image;
            Tint = tint;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Image, Position, Tint);
        }
    }
}
