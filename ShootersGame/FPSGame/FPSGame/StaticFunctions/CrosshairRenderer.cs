﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace FPSGame
{
    public static class CrosshairRenderer
    {
        static private Texture2D crosshairTexture;
        static private bool _set_data = false;
        static private Vector2 up1;
        static private Vector2 up2;
        static private Vector2 right1;
        static private Vector2 right2;
        static private Vector2 down1;
        static private Vector2 down2;
        static private Vector2 left1;
        static private Vector2 left2;

        static public void initCrosshair(GraphicsDevice device)
        {
            crosshairTexture = new Texture2D(device, 1, 1, false, SurfaceFormat.Color);
            up1 = new Vector2(device.Viewport.Width / 2, device.Viewport.Height / 2-20);
            up2 = new Vector2(device.Viewport.Width / 2, device.Viewport.Height / 2);
            right1 = new Vector2(device.Viewport.Width / 2, device.Viewport.Height / 2);
            right2 = new Vector2(device.Viewport.Width / 2+20, device.Viewport.Height / 2);
            down1 = new Vector2(device.Viewport.Width / 2, device.Viewport.Height / 2);
            down2 = new Vector2(device.Viewport.Width / 2, device.Viewport.Height / 2+20);
            left1 = new Vector2(device.Viewport.Width / 2-20, device.Viewport.Height / 2);
            left2 = new Vector2(device.Viewport.Width / 2, device.Viewport.Height / 2);
        }

        static public void drawCrosshair(SpriteBatch batch, Color color, float recoil)
        {

            drawLine(batch, color, up1, up2, new Vector2(0,-recoil));
            drawLine(batch, color, right1, right2, new Vector2(recoil,0));
            drawLine(batch, color, down1, down2, new Vector2(0, recoil));
            drawLine(batch, color, left1, left2, new Vector2(-recoil,0));
        }

        /// <summary>
        /// Draw a line into a SpriteBatch
        /// </summary>
        /// <param name="batch">SpriteBatch to draw line</param>
        /// <param name="color">The line color</param>
        /// <param name="point1">Start Point</param>
        /// <param name="point2">End Point</param>
        /// <param name="Layer">Layer or Z position</param>
        static public void drawLine(SpriteBatch batch, Color color, Vector2 point1,
                                    Vector2 point2, Vector2 recoil)
        {
            //Check if data has been set for texture
            //Do this only once otherwise
            if (!_set_data)
            {
                crosshairTexture.SetData(new[] { Color.White});
                _set_data = true;
            }


            float angle = (float)Math.Atan2(point2.Y - point1.Y, point2.X - point1.X);
            float length = (point2 - point1).Length();

            batch.Begin(SpriteSortMode.FrontToBack,BlendState.Opaque);
            batch.Draw(crosshairTexture, point1+recoil, null, color,
                       angle, Vector2.Zero, new Vector2(length, 1),
                       SpriteEffects.None, 1);
            batch.End();
        }
































        /*
        static VertexBuffer vertexBuffer;
        static BasicEffect crosshairEffect;
        static VertexPositionColor[] crosshairPieces;

        public static void InitializeGraphics(GraphicsDevice graphicsDevice)
        {
            crosshairPieces = new VertexPositionColor[8];
            for (int i = 0; i < crosshairPieces.Length; i++)
                crosshairPieces[i].Color = Color.Green;

            crosshairEffect = new BasicEffect(graphicsDevice);
            vertexBuffer = new VertexBuffer(graphicsDevice, typeof(VertexPositionColor), 8, BufferUsage.None);
            vertexBuffer.SetData<VertexPositionColor>(crosshairPieces);
            crosshairEffect.VertexColorEnabled = true;
        }

        public static void drawCrosshair(Matrix view,Matrix proj,Matrix transform,GraphicsDevice graphicsDevice)
        {
            if (vertexBuffer == null)
                InitializeGraphics(graphicsDevice);

            graphicsDevice.SetVertexBuffer(vertexBuffer);
            crosshairEffect.World = transform;
            crosshairEffect.Projection = proj;
            crosshairEffect.View = view;
            for (int i = 0; i < crosshairPieces.Length; i++)
                crosshairPieces[i].Position = transform.Translation;

            
            crosshairPieces[0].Position += new Vector3(graphicsDevice.Viewport.Width / 2, graphicsDevice.Viewport.Height / 2 - 10, 50);
            crosshairPieces[1].Position += new Vector3(graphicsDevice.Viewport.Width / 2, graphicsDevice.Viewport.Height / 2 - 40, 50);
            crosshairPieces[2].Position +=new Vector3(graphicsDevice.Viewport.Width / 2 + 10, graphicsDevice.Viewport.Height / 2, 50);
            crosshairPieces[3].Position += new Vector3(graphicsDevice.Viewport.Width / 2 + 40, graphicsDevice.Viewport.Height / 2, 50);
            crosshairPieces[4].Position += new Vector3(graphicsDevice.Viewport.Width / 2, graphicsDevice.Viewport.Height / 2 + 10, 50);
            crosshairPieces[5].Position += new Vector3(graphicsDevice.Viewport.Width / 2, graphicsDevice.Viewport.Height / 2 + 40, 50);
            crosshairPieces[6].Position += new Vector3(graphicsDevice.Viewport.Width / 2 - 10, graphicsDevice.Viewport.Height / 2, 50);
            crosshairPieces[7].Position += new Vector3(graphicsDevice.Viewport.Width / 2 - 40, graphicsDevice.Viewport.Height / 2, 50);
            

            crosshairPieces[0].Position += transform.Forward*5;
            crosshairPieces[1].Position += transform.Forward * 5;
            crosshairPieces[2].Position += transform.Forward * 5;
            crosshairPieces[3].Position += transform.Forward * 5;
            crosshairPieces[4].Position += transform.Forward * 5;
            crosshairPieces[5].Position += transform.Forward * 5;
            crosshairPieces[6].Position += transform.Forward * 5;
            crosshairPieces[7].Position += transform.Forward * 5;



            crosshairEffect.CurrentTechnique.Passes[0].Apply();
            graphicsDevice.DrawPrimitives(PrimitiveType.LineList, 0, 3);
        }
        */
    }
}
