using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snakeMG
{
    public class Snake
    {
        List<SnakePiece> snake;

        public SnakePiece Head => snake[0];
        public SnakePiece Tail => snake[snake.Count - 1];

        private Texture2D bodyTexture;

        public Snake(Texture2D headTexture, Texture2D tailTexture, Texture2D bodyTexture)
        {
            snake = new List<SnakePiece>()
            {
                new SnakePiece(new Vector2(), headTexture, Color.White, Orientation.Up),
                new SnakePiece(Vector2.Zero, bodyTexture, Color.White, Orientation.Up),
                new SnakePiece(Vector2.Zero, tailTexture, Color.White, Orientation.Up)
            };

            this.bodyTexture = bodyTexture;
        }

        public void Grow(int? pieceCount = null)
        {
            if(!pieceCount.HasValue)
            {
                pieceCount = 1;
            }

            for (int i = 0; i < pieceCount; i++)
            {
                snake.Insert(snake.Count - 2, new SnakePiece(Tail.Position, bodyTexture, Color.White, Tail.Direction));

                // TODO: Adjust tail's position based on direction
                switch (Tail.Direction)
                {
                    case Orientation.Up:
                        break;
                    case Orientation.Down:
                        break;
                    case Orientation.Left:
                        break;
                    case Orientation.Right:
                        break;
                    default:
                        break;
                }

            }

        }
        
        //move snake
        public void Move(Keys key)
        {

        }
    }
}
