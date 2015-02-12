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

namespace PsychologeGame
{
    public class Sprite
    {
        float _alpha = 1f;
        public float Alpha
        {
            get
            {
                return _alpha;
            }

            set
            {
                _alpha = value;
                if (_alpha > 1f) _alpha = 1f;
                if (_alpha < 0f) _alpha = 0f;
            }
        }
        public Color finalColor = Color.White;
        public float Z;
        public float LINEAR_CHANGE_SPEED = 0.05f;
        //public Sprite effectSprite;
        public Texture2D SourceTexture;
        public Vector2 position;
        public Boolean isVisible;
        public Boolean isAlive = true;
        public Rectangle ShowingRect;
        public int CurrentPositionX = 0;
        public int CurrentPositionY = 0;
        public int SpriteSizeX=1;
        public int SpriteSizeY=1;
        public Boolean isPool;
        public Boolean isHit = true;
        public int iCount = 0;
        public Rectangle CollisionRect;
        public Vector2 scale = new Vector2(1, 1);

        public Sprite(string file, float z, Boolean isVisible, Vector2 position)
        {
            this.SourceTexture = Cache.Texture(file);
            this.isVisible = isVisible;
            //this.position = position;
            this.position = position*CommonItem.rate;  
            this.Z = z;
            this.ShowingRect = this.SourceRect(this);
            this.CollisionRect = this.collisionRect(this);
        }

        public Rectangle collisionRect(Sprite Sprite)
        {
            Rectangle rect;
            rect = new Rectangle((int)(Sprite.position.X), (int)(Sprite.position.Y), (int)(Sprite.SourceTexture.Width * CommonItem.rate.X / Sprite.SpriteSizeX),
                                         (int)(Sprite.SourceTexture.Height * CommonItem.rate.Y / Sprite.SpriteSizeY));
            return rect;
        }

        public Rectangle SourceRect(Sprite Sprite)
        {
            Rectangle SourceRect;
            SourceRect = new Rectangle(Sprite.CurrentPositionX * Sprite.SourceTexture.Width / Sprite.SpriteSizeX,
                                     Sprite.CurrentPositionY * Sprite.SourceTexture.Height / Sprite.SpriteSizeY,
                                     (int)(Sprite.SourceTexture.Width/ Sprite.SpriteSizeX),
                                     (int)(Sprite.SourceTexture.Height/ Sprite.SpriteSizeY));
            return SourceRect;

        }

        public void ObjectAnimation(Sprite Sprite, int time)
        {
            if (Sprite.isVisible == true)
            {
                Sprite.iCount++;
                if (Sprite.iCount >= time)
                {
                    Sprite.iCount = 0;
                    Sprite.CurrentPositionX++;

                    if (Sprite.CurrentPositionX >= Sprite.SpriteSizeX)
                    {
                        Sprite.CurrentPositionX = 0;
                        Sprite.CurrentPositionY++;
                    }
                    if (Sprite.CurrentPositionY >= Sprite.SpriteSizeY)
                    {
                        Sprite.CurrentPositionY = 0;
                        if (Sprite.isPool == false)
                        {
                            Sprite.isVisible = false;
                        }
                    }
                    Sprite.ShowingRect = SourceRect(Sprite);
                }
            }
        }

        public void disappear(Sprite Sprite, int time)
        {
            if (Sprite.isVisible == true && Sprite.isAlive == false)
            {
                //if (Sprite.isHit == false)
                //{
                //    Sprite.isVisible = false;
                //    Sprite.isAlive = true;                   
                //    Sprite.effectSprite.ShowingRect = Sprite.effectSprite.SourceRect(Sprite.effectSprite);
                //    Sprite.effectSprite.isVisible = true;
                //    Sprite.CurrentPositionY = Sprite.SpriteSizeY - 1;
                //    Sprite.CurrentPositionX = Sprite.SpriteSizeX - 1;
                //}
                Sprite.iCount++;
                if (Sprite.iCount >= time)
                {
                    Sprite.iCount = 0;


                    Sprite.CurrentPositionX++;

                    if (Sprite.CurrentPositionX >= Sprite.SpriteSizeX)
                    {
                        Sprite.CurrentPositionX = 0;
                        Sprite.CurrentPositionY++;
                    }
                    if (Sprite.CurrentPositionY >= Sprite.SpriteSizeY)
                    {
                        Sprite.CurrentPositionY = Sprite.SpriteSizeY - 1;
                        Sprite.CurrentPositionX = Sprite.SpriteSizeX - 1;
                        if (Sprite.isPool == false)
                        {
                            Sprite.isVisible = false;
                            Sprite.isAlive = true;
                        }
                    }
                    Sprite.ShowingRect = SourceRect(Sprite);
                }
            }
        }

        public void ShowUp(Sprite Sprite, int time)
        {
            if (Sprite.isVisible == true && Sprite.isAlive == true)
            {
                Sprite.iCount++;
                if (Sprite.iCount >= time)
                {
                    Sprite.iCount = 0;

                    Sprite.CurrentPositionX--;
                    if (Sprite.CurrentPositionX < 0)
                    {
                        Sprite.CurrentPositionX = Sprite.SpriteSizeX;
                        Sprite.CurrentPositionY--;
                    }
                    if (Sprite.CurrentPositionY < 0)
                    {
                        Sprite.CurrentPositionY = 0;
                        Sprite.CurrentPositionX = 0;

                    }
                    Sprite.ShowingRect = SourceRect(Sprite);
                }
            }
        }
    }
}
