using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PsychologeGame
{
   public class Sprite_Sheet:Sprite
    {
       public Sprite_Sheet(string file, float z, Boolean isVisible, Vector2 position, Boolean isPool, int Sprite_X, int Sprite_Y):base(file,z,isVisible,position)
        {
            this.isPool = isPool;
            this.SpriteSizeX = Sprite_X;
            this.SpriteSizeY = Sprite_Y;
            this.CollisionRect = this.collisionRect(this);
        }
    }
}
