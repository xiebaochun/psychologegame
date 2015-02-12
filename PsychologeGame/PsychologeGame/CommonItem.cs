using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PsychologeGame
{
   public static class CommonItem
    {     
      public static int SCENE_INDEX = 1;
      public static int ANS_INDEX = 1;
      public static int BACKGROUND_INDEX = 1;

      public const int BACKBUFFER_WIDTH = 1280;
      public const int BACKBUFFER_HEIGHT = 768;

      public static Vector2 rate = new Vector2(1, 1);
      public static Vector2 inputBoxPosition = new Vector2(50, 620);
      public static Vector2 loginButtonPosition = new Vector2(317, 0);

      public static Vector2 loginTextBoxPosition = new Vector2(80, 24);
      public static Vector2 playerInfoPosition = new Vector2(10, 10);
      public static Vector2 cursorPosition = new Vector2(80, 24);

      public static int texFocuseIndex = 1;

      public static int aggressiveCount = 0; //自我确定次数

      public static int submissiveCount= 0;  //被动次数

      public static int passiveAggressiveCount = 0;//被动攻击次数


    }
}
