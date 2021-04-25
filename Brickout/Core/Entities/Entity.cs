using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brickout.Core.Entities
{
    public class Entity : DrawableGameComponent
    {
        public Vector2 Position;
        public Vector2 Direction;
        public int Width;
        public int Height;


        public Rectangle BoundingBox;
        public Texture2D Texture;

        public Entity(Game game) : base(game)
        {

        }

        public bool Colliding(Entity entity )
        {
            bool col = false;

            if (BoundingBox.Intersects(entity.BoundingBox))
            {
                col = true;
            }

            return col;
        }


        public override void Update(GameTime gameTime)
        {
            BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, Width, Height);
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            if (Texture != null)
            {
                SpriteBatch batch = Program.MyGame.spriteBatch;
                batch.Begin();
                batch.Draw(Texture, BoundingBox, Color.White);
                batch.End();
            }


            base.Draw(gameTime);
        }

    }
}
