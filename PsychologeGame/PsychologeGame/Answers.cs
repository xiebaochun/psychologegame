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
    public class Answers
    {
        const int AnswersTextureWidth = 322;
        public int OPTION_COLLISION_WIDTH = (int)(AnswersTextureWidth* CommonItem.rate.X);
        public int OPTION_COLLISION_HEIGHT = (int)(768 * CommonItem.rate.X);

        Vector2 AnsPosition_A = new Vector2(0, 0);
        Vector2 AnsPosition_B = new Vector2(AnswersTextureWidth-1, 0);
        Vector2 AnsPosition_C = new Vector2(AnswersTextureWidth*2-1, 0);
        Vector2 AnsPosition_D = new Vector2(AnswersTextureWidth*3-1, 0);

        Vector2 OptPosition_A = (new Vector2(0, 0)) * CommonItem.rate;
        Vector2 OptPosition_B = new Vector2(AnswersTextureWidth-1, 0) * CommonItem.rate;
        Vector2 OptPosition_C = new Vector2(AnswersTextureWidth * 2-3, 0) * CommonItem.rate;
        Vector2 OptPosition_D = new Vector2(AnswersTextureWidth * 3-3, 0) * CommonItem.rate;

        List<Vector2> AnsPositions = new List<Vector2>();
       public List<Sprite> Options = new List<Sprite>();
       public List<Sprite> Voices = new List<Sprite>();
        List<int> AnsPositions_fresh = new List<int>();
       public Sprite Ans_01;
       public Sprite Ans_02;
       public Sprite Ans_03;
       public Sprite Ans_04;


      public Sprite option_A;
      public Sprite option_B;
      public Sprite option_C;
      public Sprite option_D;

      public Sprite voice_A;
      public Sprite voice_B;
      public Sprite voice_C;
      public Sprite voice_D;

      Boolean _visible = false;
      public Boolean Visible
      {
          get
          {
              return _visible;
          }
          set
          {
              _visible = value;
              if (_visible == true)
              {
                  Ans_01.isVisible = true;
                  Ans_02.isVisible = true;
                  Ans_03.isVisible = true;
                  Ans_04.isVisible = true;

                  voice_A.isVisible = true;
                  voice_B.isVisible = true;
                  voice_C.isVisible = true;
                  voice_D.isVisible = true;
              }
              else
              {
                  Ans_01.isVisible = false;
                  Ans_02.isVisible = false;
                  Ans_03.isVisible = false;
                  Ans_04.isVisible = false;

                  voice_A.isVisible = false;
                  voice_B.isVisible = false;
                  voice_C.isVisible = false;
                  voice_D.isVisible = false;
              }
          }
      }
      Random rd = new Random();

      int a;
        public Answers()
      {

          AnsPositions.Add(AnsPosition_A);
          AnsPositions.Add(AnsPosition_B);
          AnsPositions.Add(AnsPosition_C);
          AnsPositions.Add(AnsPosition_D);

          while (true)
          {
              while (true)
              {
                  a = rd.Next(0, 4);
                  if (!AnsPositions_fresh.Contains(a))
                  {
                      AnsPositions_fresh.Add(a);
                      break;
                  }
              }
              if (AnsPositions_fresh.Count >= 4) break;
          }
          Ans_01 = new Sprite("Ans/" + "Random Ans" + CommonItem.SCENE_INDEX + @"/Ans" + CommonItem.SCENE_INDEX + "_1" + (AnsPositions_fresh[0]+1), 1, Visible, AnsPositions[AnsPositions_fresh[0]]);
          Ans_02 = new Sprite("Ans/" + "Random Ans" + CommonItem.SCENE_INDEX + @"/Ans" + CommonItem.SCENE_INDEX + "_2" + (AnsPositions_fresh[1]+1), 1, Visible, AnsPositions[AnsPositions_fresh[1]]);
          Ans_03 = new Sprite("Ans/" + "Random Ans" + CommonItem.SCENE_INDEX + @"/Ans" + CommonItem.SCENE_INDEX + "_3" + (AnsPositions_fresh[2]+1), 1, Visible, AnsPositions[AnsPositions_fresh[2]]);
          Ans_04 = new Sprite("Ans/" + "Random Ans" + CommonItem.SCENE_INDEX + @"/Ans" + CommonItem.SCENE_INDEX + "_4" + (AnsPositions_fresh[3]+1), 1, Visible, AnsPositions[AnsPositions_fresh[3]]);
          //Ans_01 = new Sprite("Ans/Ans_01", 1, Visible, AnsPosition_A);
          //Ans_02 = new Sprite("Ans/Ans_02", 1, Visible, AnsPosition_B);
          //Ans_03 = new Sprite("Ans/Ans_03", 1, Visible, AnsPosition_C);
          //Ans_04 = new Sprite("Ans/Ans_04", 1, Visible, AnsPosition_D);

          option_A = new Sprite("Options/A", 10, Visible, Vector2.Zero);
          option_B = new Sprite("Options/B", 10, Visible, Vector2.Zero);
          option_C = new Sprite("Options/C", 10, Visible, Vector2.Zero);
          option_D = new Sprite("Options/D", 10, Visible, Vector2.Zero);

          voice_A = new Sprite_Sheet("voice", 11, Visible, AnsPositions[AnsPositions_fresh[0]],true,3,1);
          voice_B = new Sprite_Sheet("voice", 11, Visible, AnsPositions[AnsPositions_fresh[1]], true, 3, 1);
          voice_C = new Sprite_Sheet("voice", 11, Visible, AnsPositions[AnsPositions_fresh[2]], true, 3, 1);
          voice_D = new Sprite_Sheet("voice", 11, Visible, AnsPositions[AnsPositions_fresh[3]], true, 3, 1);


          option_A.CollisionRect = new Rectangle((int)OptPosition_A.X, (int)OptPosition_A.Y, OPTION_COLLISION_WIDTH, OPTION_COLLISION_HEIGHT);
          option_B.CollisionRect = new Rectangle((int)OptPosition_B.X, (int)OptPosition_B.Y, OPTION_COLLISION_WIDTH, OPTION_COLLISION_HEIGHT);
          option_C.CollisionRect = new Rectangle((int)OptPosition_C.X, (int)OptPosition_C.Y, OPTION_COLLISION_WIDTH, OPTION_COLLISION_HEIGHT);
          option_D.CollisionRect = new Rectangle((int)OptPosition_D.X, (int)OptPosition_D.Y, OPTION_COLLISION_WIDTH, OPTION_COLLISION_HEIGHT);

          Options.Add(option_A);
          Options.Add(option_B);
          Options.Add(option_C);
          Options.Add(option_D);

          Voices.Add(voice_A);
          Voices.Add(voice_B);
          Voices.Add(voice_C);
          Voices.Add(voice_D);
      }
        //updata the each answer position
        public void PositionUpate()
        {
            AnsPositions_fresh.Clear();
            while(true)
            {
              while(true)
                {
                    a = rd.Next(0, 4);
                    if (!AnsPositions_fresh.Contains(a))
                    {
                        AnsPositions_fresh.Add(a);
                        break;
                    }
                }
              if (AnsPositions_fresh.Count >= 4) break;
            }
            Ans_01.position =AnsPositions[AnsPositions_fresh[0]];
            Ans_02.position =AnsPositions[AnsPositions_fresh[1]];
            Ans_03.position =AnsPositions[AnsPositions_fresh[2]];
            Ans_04.position =AnsPositions[AnsPositions_fresh[3]];



        }

        public void CollisionUpdate()
        {
            Ans_01.CollisionRect = Ans_01.collisionRect(Ans_01);
            Ans_02.CollisionRect = Ans_01.collisionRect(Ans_02);
            Ans_03.CollisionRect = Ans_01.collisionRect(Ans_03);
            Ans_04.CollisionRect = Ans_01.collisionRect(Ans_04);

        }
    }

}
