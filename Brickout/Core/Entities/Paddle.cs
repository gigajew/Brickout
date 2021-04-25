using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brickout.Core.Entities
{
    public class Paddle : Entity
    {
        private Texture2D texture;

        public Paddle(Game game) : base(game)
        {
            Texture = new Texture2D(game.GraphicsDevice, 1, 1);
            Texture.SetData(new Color[] { Color.Red });
        }

        public void Reset()
        {
            GraphicsDevice device = Program.MyGame.GraphicsDevice;
            Position.X  = device.Viewport.Width / 2 - Width / 2;
            Position.Y = device.Viewport.Height - 20;
        }

        public override void Update(GameTime gameTime)
        {
            GraphicsDevice device = Program.MyGame.GraphicsDevice;
            var mouseState = Mouse.GetState();
            if(mouseState.X <= device.Viewport.Width - Width  &&
                mouseState.X >= 0)
            {
                this.Position.X = Mouse.GetState().X;
            }
           
            base.Update(gameTime);
        }
    }
}
