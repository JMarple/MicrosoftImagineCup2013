using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BEPUphysics;
using BEPUphysics.Entities.Prefabs;
using Microsoft.Xna.Framework;

namespace Imaginecup2013.Setup
{
    class InitializeGround 
    {
        //Constructor
        public InitializeGround(Leoni game)
        {
            setup(game);
        }

        public void setup(Leoni game)
        {
            //Create ground
            Box ground = new Box(Vector3.Zero, 30, 1, 30);
            game.space.Add(ground);

            //Create Walls
            game.space.Add(new Box(new Vector3(14.5f, 5, 0), 1, 10, 30));
            game.space.Add(new Box(new Vector3(0, 5, 14.5f), 30, 10, 1));

            //Partial Roof
            game.space.Add(new Box(new Vector3(10, 10, 10), 10, 0, 10));

            //Other things in demo
            game.space.Add(new Box(new Vector3(0, 2, 0), 1, 1, 1, 1));
            game.space.Add(new Box(new Vector3(0, 4, 0), 1, 1, 1, 1));
            game.space.Add(new Box(new Vector3(0, 6, 0), 1, 1, 1, 1));    
        }
    }
}
