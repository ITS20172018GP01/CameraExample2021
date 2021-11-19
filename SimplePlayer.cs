using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprites
{
    class SimplePlayer : SimpleSprite
    {
        float speed = 5.0f;
        public SimplePlayer(Texture2D spriteImage, Vector2 StartPos) : base(spriteImage,StartPos)
        {
            

        }
        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                Move(new Vector2(1, 0) * speed);
                
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                Move(new Vector2(-1, 0) * speed);
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                Move(new Vector2(0, -1) * speed);
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                Move(new Vector2(0, 1) * speed);
        }
    }
}
