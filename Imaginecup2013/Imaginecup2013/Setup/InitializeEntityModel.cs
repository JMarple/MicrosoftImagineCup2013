using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BEPUphysics;
using Microsoft.Xna.Framework.Graphics;
using Imaginecup2013;
using BEPUphysics.DataStructures;
using BEPUphysics.Collidables;
using BEPUphysics.MathExtensions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Imaginecup2013.Setup
{
    class InitializeEntityModel
    {
        //Constructor
        public InitializeEntityModel(String file, Leoni game, Texture tex, AffineTransform pos)
        {
            setup(file, game, tex, pos);
        }
        //Blank Constructor
        public InitializeEntityModel() { }

        public void setup(String file, Leoni game, Texture tex, AffineTransform pos)
        {
            //Nothing for now...
        }
    }
}
