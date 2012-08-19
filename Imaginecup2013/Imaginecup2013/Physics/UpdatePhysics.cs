using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Imaginecup2013.Physics
{
    public class UpdatePhysics
    {
        UpdateCamera updateGameCamera = new UpdateCamera();

        //Update physics
        public void update(Leoni leoni, GameTime gameTime)
        {
            //updates game camera
            updateGameCamera.update(leoni, gameTime);
            
            //Steps the simulation forward one time step.
            leoni.space.Update();            
        }
    }
}
