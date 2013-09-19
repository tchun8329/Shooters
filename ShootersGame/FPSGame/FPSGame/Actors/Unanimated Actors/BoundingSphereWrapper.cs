﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace FPSGame
{
    public class BoundingSphereWrapper : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private BoundingSphere boundingSphere;
        private Player player;
        private SkinnedSphere skinnedSphere;

        public BoundingSphereWrapper(Game game, BoundingSphere boundingSphere, Player player, SkinnedSphere skinnedSphere) : base(game)
        {
            this.boundingSphere = boundingSphere;
            this.player = player;
            this.skinnedSphere = skinnedSphere;
        }

        public BoundingSphere getBoundingSphere
        {
            get
            {
                return this.boundingSphere;
            }
        }

        public Player getPlayer
        {
            get
            {
                return this.player;
            }
        }

        public SkinnedSphere getSkinnedSphere
        {
            get
            {
                return this.skinnedSphere;
            }
        }
    }
}
