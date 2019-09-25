using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake9_10_2019
{
    public class Snake
    {

        Texture2D SnakeHead;
        Texture2D SnakeBody;
        public List<SnakePiece> snakePieces = new List<SnakePiece>();
        
        TimeSpan updateTargetTime = TimeSpan.FromMilliseconds(120); //set a variable called updateTargetTime to be 120 miliseconds
        TimeSpan elapsedTime =  TimeSpan.Zero; //makes a timespan varialbe to check on how much time has passed, sets to zero.

        public Snake(Texture2D snakeHead, Texture2D snakeBody, Vector2 position)
        {
            SnakeHead = snakeHead;
            SnakeBody = snakeBody;

            snakePieces.Add(new SnakePiece(SnakeHead, position, Color.White));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < snakePieces.Count; i++)
            {
                snakePieces[i].Draw(spriteBatch);
            }
        }

        public void Grow()
        {
            snakePieces.Add(new SnakePiece(SnakeBody, snakePieces[snakePieces.Count-1].Position, Color.White));
        }
        public void Update(KeyboardState ks, GameTime gameTime,GraphicsDevice graphics ,Food food)
        {
            elapsedTime += gameTime.ElapsedGameTime; //adds the current gametime to elapsedTime for running count.

            //check direction of head
            if (ks.IsKeyDown(Keys.Down))
            {
                snakePieces[0].Direction = Directions.Down;
                snakePieces[0].Rotation = MathHelper.Pi;
            }
            else if (ks.IsKeyDown(Keys.Up) )
            {
                snakePieces[0].Direction = Directions.Up;
                snakePieces[0].Rotation = 0;
            }
            else if(ks.IsKeyDown(Keys.Left))
            {
                snakePieces[0].Direction = Directions.Left;
                snakePieces[0].Rotation = MathHelper.Pi * 3 / 2;
            }
            else if(ks.IsKeyDown(Keys.Right))
            {
                snakePieces[0].Direction = Directions.Right;
                snakePieces[0].Rotation = MathHelper.PiOver2;
            }


            //for (int i = 1; i < snakePieces.Count-1; i++)
            //{
            //    if(snakePieces[0].hitBox.Intersects(snakePieces[i].hitBox))
            //    {
            //        snakePieces[0].Direction = Directions.None;
            //    }
            //}

            //updates when the elapsed time has been met or exceeded.
            if (elapsedTime >= updateTargetTime)
            {
                elapsedTime = TimeSpan.Zero; //resets the elapsedTime back to zero so that it will update again.

                //change all directions of the snake - head to tail
                for (int i = 0; i < snakePieces.Count; i++)
                {
                    switch (snakePieces[i].Direction)
                    {
                        case Directions.Up:
                            snakePieces[i].Position = new Vector2(snakePieces[i].Position.X, snakePieces[i].Position.Y - SnakeHead.Bounds.Height);                            
                            break;
                        case Directions.Down:
                            snakePieces[i].Position = new Vector2(snakePieces[i].Position.X, snakePieces[i].Position.Y + SnakeHead.Bounds.Height);                            
                            break;
                        case Directions.Left:
                           snakePieces[i].X -= snakePieces[i].Image.Width; //better way to do it. instead of the top 2 and bottom one.                           
                            break;
                        case Directions.Right:
                            snakePieces[i].Position = new Vector2(snakePieces[i].Position.X + SnakeHead.Width, snakePieces[i].Position.Y);
                            break;
                    }
                }

                //updates the direction of the snake from back to front.
                for (int i = snakePieces.Count - 1; i > 0; i--)
                {
                    if(snakePieces[i-1].hitBox.Intersects(snakePieces[i].hitBox))
                    {
                        for (int j = 0; j < snakePieces.Count-1; j++)
                        {
                            snakePieces[j].Direction = Directions.None;
                        }
                        break;
                    }
                    snakePieces[i].Direction = snakePieces[i - 1].Direction;
                }
            }

            if (snakePieces[0].hitBox.Intersects(food.hitBox))
            {
                food.GenNewPos(graphics);
                Grow();
            }
        }
    }
}
