using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BEPUphysics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using BEPUphysics.Entities.Prefabs;
using Microsoft.Xna.Framework.Graphics;
using BEPUphysics.Entities;
using BEPUphysics.MathExtensions;

namespace Imaginecup2013.Setup
{
    public class InitializeWorld
    {
        public InitializeWorld(Leoni game)
        {
            //Initilize ground
            InitializeGround ground = new InitializeGround(game);
            
            //Initilize camera collision
            game.cameraBox = new Sphere(new Vector3(0, 3, 10), 1, 1);
            game.space.Add(game.cameraBox);

            //Set gravity
            game.space.ForceUpdater.Gravity = new Vector3(0, -9.8f, 0);
        }
    }
}
