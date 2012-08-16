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

namespace Imaginecup2013.Setup
{
    public class InitializeWorld
    {
        public InitializeWorld(Leoni game)
        {          

            //Initilize ground
            InitializeGround ground = new InitializeGround(game);

            //Initilize models in the world
            InitializeModel models = new InitializeModel();
            models.setup("Models//playground", game);

            #region DemoCode
            /** Only Temporary **/
            Model CubeModel = game.Content.Load<Model>("Models//cube");

            //MAKE ALL ENTITIES TO A CUBE            
            foreach (Entity e in game.space.Entities)
            {
                Box box = e as Box;
                if (box != null) //This won't create any graphics for an entity that isn't a box since the model being used is a box.
                {
                    Matrix scaling = Matrix.CreateScale(box.Width, box.Height, box.Length); //Since the cube model is 1x1x1, it needs to be scaled to match the size of each individual box.
                    EntityModel model = new EntityModel(e, CubeModel, scaling, game);
                    //Add the drawable game component for this entity to the game.
                    game.Components.Add(model);
                    e.Tag = model; //set the object tag of this entity to the model so that it's easy to delete the graphics component later if the entity is removed.
                }
            }
            /**   **/
            #endregion

            //Initilize camera collision (too simple for it's own class?)
            game.cameraBox = new Sphere(new Vector3(0, 3, 10), 1, 1);
            game.space.Add(game.cameraBox);

            //Set gravity
            game.space.ForceUpdater.Gravity = new Vector3(0, -9.8f, 0);
        }
    }
}
