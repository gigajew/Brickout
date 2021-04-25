using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brickout.Core.Entities
{
    public class Brick : Entity
    {

        public Brick(Game game) : base(game)
        {
            Texture = new Texture2D(game.GraphicsDevice, 1, 1);
            Texture.SetData(new Color[] { Color.IndianRed });
        }

    }
}
