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

            //Initilize models in the world
            InitializeStaticModel sModels = new InitializeStaticModel();
            sModels.setup("Models//playground", game, game.Content.Load<Texture2D>("Terrain\\playgroundTex"), new AffineTransform(new Vector3(0, -40, 0)));

            //InitializeEntityModel eModels = new InitializeEntityModel();
            //eModels.setup("Models//Cube", game, game.Content.Load<Texture2D>("Terrain\\playgroundTex"), new AffineTransform(new Vector3(2, 2, 0) ) );


            #region DemoCode
            /** Only Temporary **/


            Model CubeModel = game.Content.Load<Model>("Models//Cube");           

            //MAKE ALL ENTITIES TO A CUBE            
            foreach (Entity e in game.space.Entities)
            {
                Box box = e as Box;
                if (box != null) //This won't create any graphics for an entity that isn't a box since the model being used is a box.
                { 
                    Matrix scaling = Matrix.CreateScale(box.Width, box.Height, box.Length); //Since the cube model is 1x1x1, it needs to be scaled to match the size of each individual box.
                    EntityModel model = new EntityModel(e, CubeModel, scaling, game, game.textureEffect);
                    model.tex = game.Content.Load<Texture2D>("Terrain\\PlaygroundTex");
                    //Add the drawable game component for this entity to the game.
                    game.Components.Add(model);
                    e.Tag = model; //set the object tag of this entity to the model so that it's easy to delete the graphics component later if the entity is removed.
                }
            }
            /**   **/
            #endregion

            #region addEntityTest

            game.space.Add(new Box(new Vector3(5, 2, 0), 1, 1, 1, 1));

            Entity _e = game.space.Entities[game.space.Entities.Count - 1];
            Box _box = _e as Box;
            if (_box != null) //This won't create any graphics for an entity that isn't a box since the model being used is a box.
            {
                Matrix scaling = Matrix.CreateScale(_box.Width, _box.Height, _box.Length); //Since the cube model is 1x1x1, it needs to be scaled to match the size of each individual box.
                EntityModel model = new EntityModel(_e, CubeModel, scaling, game, game.textureEffect);
                model.tex = game.Content.Load<Texture2D>("Terrain\\PlaygroundTex");
                //Add the drawable game component for this entity to the game.
                game.Components.Add(model);
                _e.Tag = model; //set the object tag of this entity to the model so that it's easy to delete the graphics component later if the entity is removed.
            }

            #endregion


            //Initilize camera collision (too simple for it's own class?)
            game.cameraBox = new Sphere(new Vector3(0, 3, 10), 1, 1);
            game.space.Add(game.cameraBox);

            //Set gravity
            game.space.ForceUpdater.Gravity = new Vector3(0, -9.8f, 0);
        }
    }
}
