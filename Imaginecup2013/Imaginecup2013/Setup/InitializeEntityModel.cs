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
using BEPUphysics.Entities;

namespace Imaginecup2013.Setup
{
    class InitializeEntityModel
    {
        //Constructor
        public InitializeEntityModel(Model model, Leoni game, Texture tex, Entity entity, AffineTransform pos)
        {
            setup(model, game, tex, entity, pos);
        }
        //Blank Constructor
        public InitializeEntityModel() { }

        public void setup(Model model, Leoni game, Texture tex, Entity entity, AffineTransform pos)
        {
            
            game.space.Add(entity);
            
            //Make it visible too.
            EntityModel tmpModel = new EntityModel(entity, model, entity.WorldTransform, game, game.textureEffect);
            tmpModel.tex = tex;
            entity.Tag = tmpModel;

            game.Components.Add(tmpModel);
        }
    }
}
