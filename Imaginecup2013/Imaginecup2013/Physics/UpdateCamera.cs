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

            leoni.cameraBox.LinearVelocity = leoni.Camera.WorldMatrix.Left * tbX * cameraSpeed + leoni.Camera.WorldMatrix.Forward * tbY * cameraSpeed + new Vector3(0, -11f, 0);       
            
            leoni.Camera.Position = new Vector3(leoni.cameraBox.Position.X, leoni.cameraBox.Position.Y + 2, leoni.cameraBox.Position.Z);

            //Update the camera.
            leoni.Camera.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
        }
    }
}
