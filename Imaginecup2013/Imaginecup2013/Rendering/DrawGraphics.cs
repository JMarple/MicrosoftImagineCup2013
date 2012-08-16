using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Imaginecup2013.Rendering
{
    public class DrawGraphics
    {
        public void draw(Leoni game, Texture2D map)
        {
            //Draw Post processing
            game.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Opaque, SamplerState.LinearClamp, DepthStencilState.Default, RasterizerState.CullNone, game.postEffect);
            game.spriteBatch.Draw(map, new Rectangle(0, 0, game.screenSizeWidth, game.screenSizeHeight), Color.White);
            game.spriteBatch.End();
        }
    }
}
