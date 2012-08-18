using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BEPUphysics;
using BEPUphysics.Entities.Prefabs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BEPUphysics.MathExtensions;

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
            //initClasses
            InitializeEntityModel eModels = new InitializeEntityModel();
            InitializeStaticModel sModels = new InitializeStaticModel();

            /** Static Models **/
            sModels.add("Models//playground", game, game.Content.Load<Texture2D>("Terrain\\playgroundTex"), new AffineTransform(new Vector3(0, -40, 0)));

            /** Entity Models **/
            Model CubeModel = game.Content.Load<Model>("Models//Cube");
            Texture RustTex = game.Content.Load<Texture2D>("Terrain//playgroundTex");
            
            //Ground
            eModels.add(new Box(Vector3.Zero, 30, 1, 30), CubeModel, game, RustTex);

            //Create Walls
            eModels.add(new Box(new Vector3(14.5f, 5, 0), 1, 10, 30), CubeModel, game, RustTex);
            eModels.add(new Box(new Vector3(0, 5, 14.5f), 30, 10, 1), CubeModel, game, RustTex);

            //Partial Roof
            eModels.add(new Box(new Vector3(10, 10, 10), 10, 1, 10), CubeModel, game, RustTex);

            //Cube Demo
            eModels.add(new Box(new Vector3(0, 2, 0), 1, 1, 1, 1), CubeModel, game, RustTex);
            eModels.add(new Box(new Vector3(0, 4, 0), 1, 1, 1, 1), CubeModel, game, RustTex);
            eModels.add(new Box(new Vector3(0, 6, 0), 1, 1, 1, 1), CubeModel, game, RustTex);            
        }
    }
}
