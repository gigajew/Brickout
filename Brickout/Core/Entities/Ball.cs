using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brickout.Core.Entities
{
    public class Ball : Entity
    {
        public Ball(Game game) : base(game)
        {
            Texture = new Texture2D(game.GraphicsDevice,1, 1);
            Texture.SetData(new Color[] { Color.White });

        }

        public void Reset()
        {
            GraphicsDevice device = Program.MyGame.GraphicsDevice;
            Position.X = device.Viewport.Width / 2 - Width / 2;
            Position.Y  = device.Viewport.Height - device.Viewport.Height / 3;
        }

        public void ResetDirection(int speed)
        {
            do
            {
                Direction.X = Program.MyGame.random.Next(-speed, speed);
            } while (Direction.X== 0);

            do
            {
                Direction.Y = Program.MyGame.random.Next(-speed, speed);
            } while (Direction.Y == 0);
        }

    }
}
