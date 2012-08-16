using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BEPUphysics;
using Microsoft.Xna.Framework.Graphics;
using Imaginecup2013;
using BEPUphysics.DataStructures;
using BEPUphysics.Collidables;
using BEPUphysics.MathExtensions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Imaginecup2013.Setup
{
    class InitializeModel
    {
        //Constructor
        public InitializeModel(String file, Leoni game)
        {
            setup(file, game);
        }
        //Blank Constructor
        public InitializeModel(){  }

        public void setup(String file, Leoni game)
        {
            //Load Model
            Model model = game.Content.Load<Model>(file);

            //change the model to a mesh to create vertici collision
            Vector3[] vertices;
            int[] indices;
            TriangleMesh.GetVerticesAndIndicesFromModel(model, out vertices, out indices);
            var mesh = new StaticMesh(vertices, indices, new AffineTransform(new Vector3(0, -40, 0)));

            //Add it to the space!
            game.space.Add(mesh);

            //Make it visible too.
            game.Components.Add(new StaticModel(model, mesh.WorldTransform.Matrix, game));
        }
    }
}
