﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FPSGame
{
    public class TargetCamera : TempCamera
    {
        public Vector3 Position { get; set; }
        public Vector3 Target { get; set; }

        public TargetCamera(Vector3 Position, Vector3 Target,
        GraphicsDevice graphicsDevice)
            : base(graphicsDevice)
        {
            this.Position = Position;
            this.Target = Target;

        }
        public override void Update()
        {
            Vector3 forward = Target - Position;
            Vector3 side = Vector3.Cross(forward, Vector3.Up);
            Vector3 up = Vector3.Cross(forward, side);
            this.View = Matrix.CreateLookAt(Position, Target, up);
        }

    }
}
