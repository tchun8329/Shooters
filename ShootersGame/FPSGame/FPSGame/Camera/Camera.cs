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

    public abstract class Camera : Microsoft.Xna.Framework.GameComponent
    {
        protected Pose pose = new Pose();
        protected Matrix viewMatrix;
        protected Matrix projMatrix;

        public Camera(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
        }

        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here

            base.Update(gameTime);
        }

        public virtual void Update()
        {
        }

        public Matrix ViewMatrix
        {
            get
            {
                return this.viewMatrix;
            }
            set
            {
                this.viewMatrix = value;
            }
        }

        public Matrix ProjMatrix
        {
            get
            {
                return this.projMatrix;
            }
            set
            {
                this.projMatrix = value;
            }
        }

        public abstract void updateViewMatrix();
    }
}
