using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Imaginecup2013.Physics
{
    public static class UpdatePhysics
    {       

        //Update physics
        public static void update(Leoni leoni, GameTime gameTime)
        {
            //updates game camera
            UpdateCamera.update(leoni, gameTime);
            
            //Steps the simulation forward one time step.
            leoni.space.Update();            
        }
    }
}
