﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PyramidPanic
{
    public class ExplorerWalkDown : AnimatedSprite, IAnimatedSprite
    {

        // Fields
        private Explorer explorer;
        private Vector2 speed;

        // Properties
        public Rectangle DestinationRectangle
        {
            set { this.destinationRectangle = value; }
            get { return this.destinationRectangle; }
        }
        // Constructor
        public ExplorerWalkDown(Explorer explorer) : base(explorer)
        {
            this.explorer = explorer;
            this.destinationRectangle = new Rectangle((int)this.explorer.Position.X,
                                                      (int)this.explorer.Position.Y,
                                                      this.explorer.Texture.Width / 4,
                                                      this.explorer.Texture.Height);
           
            this.speed = new Vector2(0f, this.explorer.Speed);
            this.rotation = (float)Math.PI / 2;
        }

        public void Initialize()
        {
            this.destinationRectangle.X = (int)this.explorer.Position.X;
            this.destinationRectangle.Y = (int)this.explorer.Position.Y;
        }

        // Update
        public override void Update(GameTime gameTime)
        {
            this.explorer.Position += this.speed;
            
            if (ExplorerManager.CollisionDetectExplorerWallsDown())
            {
                this.explorer.Position -= this.speed;
            }

            if (Input.LevelDetectKeyUp(Keys.Down))
            {
                // Bereken de hoeveel pixels het middelpunt van de explorer verwijdert is van 16
                int modulo = (int)this.explorer.Position.Y % 32;

                // Als module vlak voor de 16 staat dan wordt de laatste stap in het if-statement gezet.
                if (modulo >= 16 - this.explorer.Speed && modulo <= 16)
                {
                    // Bereken de positie in geheel aantal malen 32
                    int geheelAantalMalen32 = (int)(this.explorer.Position.Y / 32);

                    // Zet de explorer precies op het grid
                    this.explorer.Position = new Vector2(this.explorer.Position.X,
                                                            ((geheelAantalMalen32 + 1) * 32f) - 16f);
                    this.explorer.State = this.explorer.Idle;
                    this.explorer.Idle.Rotation = (float)Math.PI / 2;
                    //Console.WriteLine(this.explorer.Position.X / 32);
                    //Console.WriteLine(this.explorer.Position.Y / 32);
                }
            }
            
            
            base.Update(gameTime);
        }


        // Draw
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
