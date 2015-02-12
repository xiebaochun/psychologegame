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
   public class myVideo
    {
       public Boolean isStop = false;
       public Rectangle screen = new Rectangle(0, 0, 1280, 768);
       public Video video;
      public VideoPlayer videoPlayer;
      public Texture2D videoTexture;
      public Dictionary<string, string> result = new Dictionary<string, string>();
       public myVideo()
       {    
           videoPlayer = new VideoPlayer();
           result.Add("1.11", "End_1");
           result.Add("1.12", "End_2");
           result.Add("1.13", "End_3");
           result.Add("1.14", "1.1_End_d");
           result.Add("1.21", "End_1");
           result.Add("1.22", "End_2");
           result.Add("1.23", "End_3");
           result.Add("1.24", "1.2_End_d");
           result.Add("1.31", "End_1");
           result.Add("1.32", "End_2");
           result.Add("1.33", "End_3");
           result.Add("1.34", "1.3_End_d");
           result.Add("2.11", "1.1_End_d");
           result.Add("2.12", "1.2_End_d");
           result.Add("2.13", "1.3_End_d");
           result.Add("2.14", "1.4_End_d");
           result.Add("2.21", "End_1");
           result.Add("2.22", "End_1");
           result.Add("2.23", "End_1");
           result.Add("2.24", "End_1");
           result.Add("2.31", "1.1_End_d");
           result.Add("2.32", "End_1");
           result.Add("2.33", "End_2");
           result.Add("2.34", "End_3");
           result.Add("3.11", "1.1_End_d");
           result.Add("3.12", "1.2_End_d");
           result.Add("3.13", "1.3_End_d");
           result.Add("3.14", "1.4_End_d");
           result.Add("3.21", "End_1");
           result.Add("3.22", "End_1");
           result.Add("3.23", "End_1");
           result.Add("3.24", "End_1");
           result.Add("3.31", "End_2");
           result.Add("3.32", "1.2_End_d");
           result.Add("3.33", "1.3_End_d");
           result.Add("3.34", "End_3");
           result.Add("4.11", "End_1");
           result.Add("4.12", "End_1");
           result.Add("4.13", "End_1");
           result.Add("4.14", "End_1");
           result.Add("4.21", "End_2");
           result.Add("4.22", "End_2");
           result.Add("4.23", "End_2");
           result.Add("4.24", "End_2");
           result.Add("4.31", "End_3");
           result.Add("4.32", "End_3");
           result.Add("4.33", "End_3");
           result.Add("4.34", "End_3");
       }

       public void Play(String name)
       {
           video = Cache.VD(name);
           videoPlayer.Play(video);
       }
    }
}
