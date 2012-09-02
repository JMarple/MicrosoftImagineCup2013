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
    static class InitializeGround 
    {
        public static void setup(Leoni game)
        {
            //initClasses
            InitializeEntityModel eModels = new InitializeEntityModel();
            InitializeStaticModel sModels = new InitializeStaticModel();

            /** Static Models **/           
            sModels.add("Terrain//Ground//floor1", game, game.Content.Load<Texture2D>("Terrain\\Ground\\gravel1"), new AffineTransform(new Vector3(0)));
            
            /** Entity Models **/
            Model CubeModel = game.Content.Load<Model>("Models//Cube");
            Model plantPot1 = game.Content.Load<Model>("Terrain//Objects//plantpot1");

            Texture RustTex = game.Content.Load<Texture2D>("Terrain//playgroundTex");
            Texture tPlantPot1 = game.Content.Load<Texture2D>("Terrain//Objects//tPlantPot1");
            //Ground
            //eModels.add(new Box(Vector3.Zero, 30, 1, 30), CubeModel, game, RustTex);

            //Create Walls
            //eModels.add(new Box(new Vector3(14.5f, 5, 0), 1, 10, 30), CubeModel, game, RustTex);
            //eModels.add(new Box(new Vector3(0, 5, 14.5f), 30, 10, 1), CubeModel, game, RustTex);

            //Partial Roof
            //eModels.add(new Box(new Vector3(10, 10, 10), 10, 1, 10), CubeModel, game, RustTex);

            eModels.add(new Box(new Vector3(3, 2, 3), 1, 1, 1, 1), plantPot1, game, tPlantPot1);
            //Cube Demo
            eModels.add(new Box(new Vector3(0, 2, 0), 1, 1, 1, 1), CubeModel, game, RustTex);
            eModels.add(new Box(new Vector3(0, 4, 0), 1, 1, 1, 1), CubeModel, game, RustTex);
            eModels.add(new Box(new Vector3(0, 6, 0), 1, 1, 1, 1), CubeModel, game, RustTex);            
        }
    }
}
