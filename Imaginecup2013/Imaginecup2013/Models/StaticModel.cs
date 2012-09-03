using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BEPUphysics.DataStructures;
using System.Collections.Generic;

namespace Imaginecup2013
{
    public class StaticModel : DrawableGameComponent
    {
        Model model;

        // Base transformation to apply to the model.
        public Matrix Transform;
        Matrix[] boneTransforms;
        Effect effect;
        public Texture tex;        

        /// <summary>
        /// Creates a new StaticModel.
        /// </summary>
        /// <param name="model">Graphical representation to use for the entity.</param>
        /// <param name="transform">Base transformation to apply to the model before moving to the entity.</param>
        /// <param name="game">Game to which this component will belong.</param>
        public StaticModel(Model model, Matrix transform, Game game) : base(game)
        {
            this.model = model;
            this.Transform = transform;
            effect = (game as Leoni).simpleEffect;

            //Collect any bone transformations in the model itself.
            boneTransforms = new Matrix[model.Bones.Count];
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (ModelMeshPart part in mesh.MeshParts)
                {
                    part.Effect = effect;
                }
            }
        }

        public StaticModel(Model model, Matrix transform, Game game, Effect effect) : base(game)
        {
            this.model = model;
            this.Transform = transform;
            this.effect = effect;

            boneTransforms = new Matrix[model.Bones.Count];
            foreach (ModelMesh mesh in model.Meshes)
            {
                
                foreach (ModelMeshPart part in mesh.MeshParts)                
                    part.Effect = effect;                
            }            
        }        

        public override void Draw(GameTime gameTime)
        {           

            model.CopyAbsoluteBoneTransformsTo(boneTransforms);

            
            

            //Should we be trying to get a depth map or get a normal map?
            if ((Game as Leoni).isShadowMapping)            
                effect.CurrentTechnique = effect.Techniques["Depth"];          
            else            
                effect.CurrentTechnique = effect.Techniques["Main"];
                
            

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                foreach (ModelMesh mesh in model.Meshes)
                {
                    //Set Effect values
                    effect.Parameters["lightView"].SetValue((Game as Leoni).lightsView);
                    effect.Parameters["lightProjection"].SetValue((Game as Leoni).lightProjection);
                    effect.Parameters["cameraPosition"].SetValue((Game as Leoni).lightPos);
                    effect.Parameters["View"].SetValue((Game as Leoni).Camera.ViewMatrix);
                    effect.Parameters["Projection"].SetValue((Game as Leoni).Camera.ProjectionMatrix);
                    effect.Parameters["World"].SetValue(boneTransforms[mesh.ParentBone.Index] * Transform);
                    effect.Parameters["tex"].SetValue(tex);

                    //Apply effect
                    pass.Apply();

                    //Render Scene
                    (Game as Leoni).GraphicsDevice.SetVertexBuffer(mesh.MeshParts[mesh.ParentBone.Index].VertexBuffer);
                    (Game as Leoni).GraphicsDevice.Indices = mesh.MeshParts[mesh.ParentBone.Index].IndexBuffer;
                    (Game as Leoni).GraphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, mesh.MeshParts[mesh.ParentBone.Index].NumVertices, 0, mesh.MeshParts[mesh.ParentBone.Index].PrimitiveCount);
                }

            }           
            
            base.Draw(gameTime);
        }
    }
}
