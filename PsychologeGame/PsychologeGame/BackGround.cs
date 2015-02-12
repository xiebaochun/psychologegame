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
  public class BackGround:Sprite
    {
    
     
      public BackGround(string file, float z, Boolean isVisible, Vector2 position)
          : base(@"BackGround/"+file, z, isVisible, position)
      {
           LINEAR_CHANGE_SPEED=0.02f;
      }
      public BackGround reload()
      {
          BackGround backGround;
          backGround = new BackGround("bg-0"+ CommonItem.BACKGROUND_INDEX, 0, true, Vector2.Zero);
          return backGround;
      }
      //public void LinearChangeTo(BackGround background)

      //{
      //    this.Alpha -= LINEAR_CHANGE_SPEED;
      //    if (this.Alpha < 0)
      //    {
      //        this.isVisible = false;
             
      //    }

      //}
    }
}
