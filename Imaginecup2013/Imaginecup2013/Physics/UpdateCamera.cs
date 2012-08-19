using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Imaginecup2013.Physics
{
    public class UpdateCamera
    {
        const int cameraSpeed = 10;
        bool jumping;
        int jumpCur;
        double jumpLength = 20;//20 loops (60 frames per second)
        float jumpThreshold = 3f;

        public void update(Leoni leoni, GameTime gameTime)
        {
            //Camera Collision Box
            /*Get Keyboard movement*/
            float tbX = 0;
            float tbY = 0;

            if (Keyboard.GetState().IsKeyDown(Keys.A))
                tbX += 1;

            if (Keyboard.GetState().IsKeyDown(Keys.D))
                tbX -= 1;

            if (Keyboard.GetState().IsKeyDown(Keys.W))
                tbY += 1;

            if (Keyboard.GetState().IsKeyDown(Keys.S))
                tbY -= 1;

            //Check to see if the user wants to jump
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                //Are we in a jump right now?
                if (jumping == false && Math.Abs(leoni.cameraBox.LinearVelocity.Y) < jumpThreshold)
                {
                    //Turn Jumping on
                    jumping = true;
                    jumpCur = 0;
                }
            }
            
            //Get Jump
            int yval = -11;
            if (jumping)
            {    
                if (jumpCur++>=jumpLength)
                {
                    //Wait until we are not moving, or just barely going down hill
                    if (Math.Abs(leoni.cameraBox.LinearVelocity.Y) < jumpThreshold)
                    {
                        jumping = false;//We can jump again!
                    }                    
                }
                else
                {
                     yval = 11;//Go Up
                }                    
            }
            //Set velocity based on input
            leoni.cameraBox.LinearVelocity = leoni.Camera.WorldMatrix.Left * tbX * cameraSpeed + leoni.Camera.WorldMatrix.Forward * tbY * cameraSpeed;

            //Filter to input to prevent people from going up unless we want them to
            leoni.cameraBox.LinearVelocity = new Vector3(leoni.cameraBox.LinearVelocity.X, yval, leoni.cameraBox.LinearVelocity.Z);
            
            leoni.Camera.Position = new Vector3(leoni.cameraBox.Position.X, leoni.cameraBox.Position.Y + 2, leoni.cameraBox.Position.Z);

            //Update the camera.
            leoni.Camera.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
        }
    }
}
