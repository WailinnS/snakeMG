using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace snakeMG
{
    public class SnakePiece : Sprite
    {
        private Vector2 Speed { get; set; }

        public Orientation Direction { get; set; }
        public SnakePiece(Vector2 position, Texture2D image, Color tint,Orientation direction) 
                         : base(position, image, tint)
        {
            Direction = direction;
            Speed = new Vector2(20, 20);
        }

        private void update()
        {
            switch (Direction)
            {
                case Orientation.Up:
                    Position -= new Vector2(Position.X, Speed.Y);
                    break;
                case Orientation.Down:
                    Position += new Vector2(Position.X, Speed.Y);
                    break;
                case Orientation.Left:
                    Position -= new Vector2(Speed.X, Position.Y);
                    break;
                case Orientation.Right:
                    Position += new Vector2(Speed.X, Position.Y);
                    break;
                default:
                    break;
            }

        }

        
    }
}
