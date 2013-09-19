using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace FPSGame
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Skybox : IRenderable
    {
        private Model skyBox;
        private TextureCube skyBoxTexture;
        private Effect skyBoxEffect;
        private float size = 1000f;


        public Skybox(ContentManager Content)
        {
            skyBox = Content.Load<Model>("AssetCollection\\Map\\skybox_model");
            skyBoxTexture = Content.Load<TextureCube>("AssetCollection\\Map\\skybox_texture");
            skyBoxEffect = Content.Load<Effect>("AssetCollection\\Effects\\Skybox");
        }

        public void Draw(Matrix view, Matrix proj,Vector3 cameraPosition)
        {
            foreach (EffectPass pass in skyBoxEffect.CurrentTechnique.Passes)
            {
                foreach (ModelMesh mesh in skyBox.Meshes)
                { 
                    foreach(ModelMeshPart part in mesh.MeshParts)
                    {
                        
                        part.Effect = skyBoxEffect;
                        part.Effect.Parameters["World"].SetValue(Matrix.CreateScale(size)*Matrix.CreateTranslation(cameraPosition));
                        part.Effect.Parameters["View"].SetValue(view);
                        part.Effect.Parameters["Projection"].SetValue(proj);
                        part.Effect.Parameters["SkyBoxTexture"].SetValue(skyBoxTexture);
                        part.Effect.Parameters["CameraPosition"].SetValue(cameraPosition);
                        
                    }
                    mesh.Draw();
                }
            }
        }
        public void SetClipPlane(Vector4? Plane)
        {
            skyBoxEffect.Parameters["ClipPlaneEnabled"].SetValue(Plane.HasValue);
            if (Plane.HasValue)
                skyBoxEffect.Parameters["ClipPlane"].SetValue(Plane.Value);
        }
    }
}
