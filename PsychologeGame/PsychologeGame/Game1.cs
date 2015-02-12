using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Windows.Forms;
using System.Drawing;
using Newtonsoft.Json;
using System.IO;

namespace PsychologeGame
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        #region Declear
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        enum GameState { login,start,preChoose, choose,response,result,playVideo, gameOver,tryAgain};
        GameState gamestate = GameState.start;
        MouseState mouseState, pre_mouseState;
        Microsoft.Xna.Framework.Point mousePosition;
       // SpriteFont word;

        Effect SpriteEffect;
        SpriteFont Font1;
        Answers answers;

        Sprite content;
        Sprite result;
        Sprite Stage;
        Sprite_Sheet StageNumber;
        Sprite_Sheet wrongCount;
        BackGround backGround;
        Sprite inputBox;
        Sprite cursor;
        Sprite_Sheet home;
        Sprite_Sheet exit;
        Sprite_Sheet start;

        Sprite next_icon1;
        Sprite_Sheet loginButton;

        Vector2 stagePosition = new Vector2(500, -5);
        Vector2 wrongCountPosition = new Vector2(650, 345);

        //TextBox text1 = new TextBox();

        MyTextBox textBox;
        float loginDisapprearSpeed=0.02f;
        float elapseTime = 0;
        float readShareTime = 0;
        const int CHOOSE_TIME = 3;
        Vector2 NEXT_ICON_POSITION = new Vector2(1093, 572);

        KeyboardState myKeyboardState;

        Boolean isChangeBackGround = false;
        Boolean isAnserRight=false;
        Boolean isPlayingIntro = false;

        public bool isPlayingVoice = false;
        List<Sprite> Sprites = new List<Sprite>();

        Random rd = new Random();
        int intRd;
        int wrongcount = 0;
        int bgmCount = 0;
        int fullscreen = 0;
        int timeDialogue = 2000;
        DateTime currentTime;

        myVideo myvideo;
        log4net.ILog log = log4net.LogManager.GetLogger("test.Loggging");//fetch a logger
        Vector2 rate;
        // datebase manager
        DBConnect dbconnect;
        ShareData sharedata;
        #endregion

        public Game1()
        {
            fullscreen = Properties.GameSetting.Default.fullscreen;

            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = CommonItem.BACKBUFFER_WIDTH;
            graphics.PreferredBackBufferHeight = CommonItem.BACKBUFFER_HEIGHT;
            Content.RootDirectory = "Content";
            Cache.Initialize(this.Content);
            if (fullscreen == 1)
            {
                graphics.IsFullScreen = true;
            }
            
            IsMouseVisible = true;
            
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            //text1.Location = new System.Drawing.Point(40, 40);
            //text1.BorderStyle = BorderStyle.None;
            //text1.Multiline = true;
            //text1.Size = new Size(400, 400);
            //text1.Enabled = true;
            //Control.FromHandle(Window.Handle).Controls.Add(text1);
            base.Initialize();
        }

        protected override void LoadContent()
        {

            Font1 = Content.Load<SpriteFont>("SpriteFont1");
            CommonItem.rate = new Vector2((float)GraphicsDevice.Viewport.Width / 1280, (float)GraphicsDevice.Viewport.Height / 768);
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            SpriteEffect = Content.Load<Effect>(@"GameContent/Effects/SpriteEffect");
            backGround = new BackGround("bg-01", 0, true, Vector2.Zero);
            AddChild(backGround);

            Stage = new Sprite("stage/Stage", 3,false,stagePosition);
            AddChild(Stage);
            StageNumber = new Sprite_Sheet("stage/StageNumber", 3, false, stagePosition + new Vector2(262, 0), true, 11, 1);
            StageNumber.ShowingRect = StageNumber.SourceRect(StageNumber);
            AddChild(StageNumber);

            wrongCount = new Sprite_Sheet("stage/StageNumber", 3, true, wrongCountPosition, true, 11, 1);
            wrongCount.ShowingRect = wrongCount.SourceRect(wrongCount);
            AddChild(wrongCount);           
            content = new Sprite("Contents/1/Cont_111", 1, false, Vector2.Zero);
            result = new Sprite("Results/1/Result_111", 1, false, Vector2.Zero);
            inputBox = new Sprite("Login/inputBox", 1, false,CommonItem.inputBoxPosition);
            loginButton = new Sprite_Sheet("Login/login", 2, false, CommonItem.inputBoxPosition + CommonItem.loginButtonPosition, false, 2, 1);
            AddChild(inputBox);
            AddChild(loginButton);
            AddChild(content);
            AddChild(result);
            cursor = new Sprite("Login/cursor",2,false,CommonItem.inputBoxPosition+CommonItem.cursorPosition);
            AddChild(cursor);

            next_icon1 = new Sprite("next icon1", 10, false, NEXT_ICON_POSITION);
            AddChild(next_icon1);

            home = new Sprite_Sheet("home", 10, true, new Vector2(28, 28), false, 2, 1);
            AddChild(home);

            exit = new Sprite_Sheet("exit", 10, false, new Vector2(1087, 587),false,2,1);
            AddChild(exit);

            start = new Sprite_Sheet("start", 10, true, new Vector2(1085, 450), false, 2, 1);
            //start.CurrentPositionX = 1;
            //start.SourceRect(start);
            AddChild(start)
                ;
            myvideo = new myVideo();
            log.Info("this is loginfo");
            log.Warn(DateTime.Now.ToString()+"hello");
            textBox = new MyTextBox(this.Content);
            textBox.isVisible = false;

            answers = new Answers();
            //dbconnect = new DBConnect();
            // TODO: use this.Content to load your game content here

            sharedata = new ShareData
            {
                Name = "PsychologeGame",
                IsRunning = "true",
                Operate = "",
                StartTime = DateTime.Now.ToString(),
                EndTime = "",
                GameNo = "2",
                IsSendResults = "false",
                Score1 = "",
                Score2 = "",
                Score3 = ""
            };
            File.WriteAllText("C:\\log.txt", Directory.GetCurrentDirectory());
            // serialize JSON to a string and then write string to a file
            File.WriteAllText(Directory.GetCurrentDirectory()+"\\share.json", JsonConvert.SerializeObject(sharedata));

           
            log.Info("rate:"+rate.ToString());
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        private KeyboardState oldKeyState = Keyboard.GetState();

        protected override void Update(GameTime gameTime)
        {
           // read file into a string and deserialize JSON to a type
            readShareTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (readShareTime >= 3.0f)
            {
                readShareTime = 0;
                sharedata = JsonConvert.DeserializeObject<ShareData>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\share.json"));
                //MessageBox.Show(sharedata.Operate);
                if (sharedata.Operate == "stop")
                {
                    //MessageBox.Show(sharedata.Operate);
                    sharedata.EndTime = DateTime.Now.ToString();
                    sharedata.IsRunning = "false";
                    sharedata.Operate = "";
                    // serialize JSON to a string and then write string to a file
                    File.WriteAllText(Directory.GetCurrentDirectory() + "\\share.json", JsonConvert.SerializeObject(sharedata));
                    this.Exit();
                }
            }
           
            
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
            //    this.Exit();
            foreach (Microsoft.Xna.Framework.Input.Keys key in Keyboard.GetState().GetPressedKeys())
            {
                if (key == Microsoft.Xna.Framework.Input.Keys.Escape)
                {
                    this.Exit();
                }
            }
            StageNumber.CurrentPositionX = CommonItem.SCENE_INDEX - 1;
            foreach (var sp in Sprites)
            {
                sp.ShowingRect = sp.SourceRect(sp);
            }
            mouseState = Mouse.GetState();
           
            mousePosition = new Microsoft.Xna.Framework.Point(mouseState.X, mouseState.Y);
            spriteRectUpdate();
            if (gamestate != GameState.login)
            {         
                BackGroundUpdate();
            }

           
               
            switch (gamestate)
            {
                case GameState.login:

                        myKeyboardState = Keyboard.GetState();

                        
                            textBox.OnKeyboardKeyPress(myKeyboardState, oldKeyState);
                        
                          switch (CommonItem.texFocuseIndex)
                          {
                              case 1:      
                                  textBox.Id.myText = textBox.keyboardString;
                                  break;
                              case 2:
                                 textBox.Name.myText=textBox.keyboardString;
                                 break;
                              //case 3:
                              //   textBox.OnKeyboardKeyPressNumber(myKeyboardState);
                              //   textBox.Age.myText = textBox.keyboardString;
                              //   break;
                          }
                              
                          
                          CursorUpdate();
                          
                          
                    break;
                case GameState.start:
                    
                    if (myvideo.videoPlayer.State == MediaState.Stopped && CommonItem.BACKGROUND_INDEX == 3 && Audio.bgmStatus != BGMStatus.FadingIn)
                    {
                        Audio.BGSStopAll();
                       
                        Audio.BGSPlay("EachStage", true);//°¢ÆÅ²¡ÁË±³¾°
                        Audio.BGSPlay("Stage" + CommonItem.SCENE_INDEX + "_scene_introduction", false);//°¢ÆÅ²¡ÁË£¨½²»°£©
                        Audio.bgmStatus = BGMStatus.FadingIn;
                    }
                    if (isPlayingIntro==false)
                    {
                        isPlayingIntro = true;

                        Audio.BGSStopAll();
                        
                        Audio.BGMPlay("intro", true);//Ö÷»­Ãæ²¥·Å
                      
                        

                    }
                  
                    Cache.videos.Clear();
                    backGround.isVisible = true;                
                    TouchUpdate();
                    break;
                case GameState.preChoose:
                    //if (mouseLeftButtonClick()&&new Microsoft.Xna.Framework.Rectangle((int)(1099 * CommonItem.rate.X), (int)(582 * CommonItem.rate.X), (int)(106*CommonItem.rate.X), (int)(102 * CommonItem.rate.X)).Contains(mousePosition))
                    //{
                    //    gamestate = GameState.choose;
                    //}
                    //isPlayingIntro =false;
                    if (elapseTime == 0)
                    {

                        Audio.BGSStopAll();
                        Audio.BGSPlay("choose", false);
                    }

                    elapseTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
                    if (elapseTime >= CHOOSE_TIME)
                    {
                        gamestate = GameState.choose;
                        elapseTime = 0;
                        Audio.BGSStopAll();
                        Audio.BGSPlay("Selection", true);
                    }

                    break;
                case GameState.choose:
                    backGround.isVisible = false;
                    if (backGround.Alpha >= 1)
                    {                    
                        answers.Visible = true;
                        answers.voice_A.isVisible = true;
                        answers.voice_B.isVisible = true;
                        answers.voice_C.isVisible = true;
                        answers.voice_D.isVisible = true;
                        foreach (var option in answers.Options)
                        {
                           
                            if (option.CollisionRect.Contains(mousePosition))
                            {
                                option.isVisible = true;
                                //for (int i = 0; i <= 3; i++)
                                //{
                                //    if (option == answers.Options[i])
                                //    {
                                //        answers.Voices[i].isVisible = true;
                                //        answers.Voices[(i+1)/3].isVisible = false;
                                //        answers.Voices[(i+2)/3].isVisible = false ;
                                //        answers.Voices[(i+3)/3].isVisible = false;
                                //    }
                                //}
                               
                               
                                if (mouseLeftButtonClick())
                                {
                                    answers.CollisionUpdate();//Update answer Collision Rect
                                    option.isVisible = false;
                                    if (answers.Ans_01.CollisionRect.Contains(mousePosition) && !voiceCcontainsMouse(mousePosition))
                                    {
                                        Audio.BGSStopAll();
                                        gamestate = GameState.response;
                                        CommonItem.ANS_INDEX = 1;
                                        wrongcount++;
                                        CommonItem.aggressiveCount++;
                                    }
                                    else if (answers.Ans_02.CollisionRect.Contains(mousePosition) && !voiceCcontainsMouse(mousePosition))
                                    {
                                        Audio.BGSStopAll();
                                      
                                        gamestate = GameState.response;
                                        CommonItem.ANS_INDEX = 2;
                                        wrongcount++;
                                        CommonItem.submissiveCount++;
                                    }
                                    else if (answers.Ans_03.CollisionRect.Contains(mousePosition) && !voiceCcontainsMouse(mousePosition))
                                    {
                                        Audio.BGSStopAll();
                                        
                                        gamestate = GameState.response;
                                        CommonItem.ANS_INDEX = 3;
                                        wrongcount++;
                                        CommonItem.passiveAggressiveCount++;
                                    }
                                    else if (answers.Ans_04.CollisionRect.Contains(mousePosition) && !voiceCcontainsMouse(mousePosition))
                                    {
                                        Audio.BGSStopAll();
                                        
                                        gamestate = GameState.response;
                                        CommonItem.ANS_INDEX = 4;
                                        isAnserRight = true;
                                        wrongcount = 0;
                                    }

                                    if (answers.Ans_01.CollisionRect.Contains(mousePosition) && voiceCcontainsMouse(mousePosition))
                                    {
                                        isPlayingVoice = true;
                                        myvideo.Play(CommonItem.SCENE_INDEX.ToString() + "/A-D/" + CommonItem.SCENE_INDEX.ToString() + "_1" );
                                    }
                                    else if (answers.Ans_02.CollisionRect.Contains(mousePosition) && voiceCcontainsMouse(mousePosition))
                                    {
                                        isPlayingVoice = true;
                                        myvideo.Play(CommonItem.SCENE_INDEX.ToString() + "/A-D/" + CommonItem.SCENE_INDEX.ToString() + "_2");
                                    }
                                    else if (answers.Ans_03.CollisionRect.Contains(mousePosition) && voiceCcontainsMouse(mousePosition))
                                    {
                                        isPlayingVoice = true;
                                        myvideo.Play(CommonItem.SCENE_INDEX.ToString() + "/A-D/" + CommonItem.SCENE_INDEX.ToString() + "_3");
                                    }
                                    else if (answers.Ans_04.CollisionRect.Contains(mousePosition) && voiceCcontainsMouse(mousePosition))
                                    {
                                        isPlayingVoice = true;
                                        myvideo.Play(CommonItem.SCENE_INDEX.ToString() + "/A-D/" + CommonItem.SCENE_INDEX.ToString() + "_4");
                                    }
                                }
                            }
                            else
                            {
                                option.isVisible = false;
                            }
                        }
                    }
                    break;

                case GameState.response:
                    isPlayingVoice = false;
                    answers.Visible = false;
                    backGround.isVisible = false;
                    Stage.isVisible = false;
                    StageNumber.isVisible = false;
                   if (CommonItem.BACKGROUND_INDEX == 4)
                   { 
                       CommonItem.BACKGROUND_INDEX++;
                       myvideo.Play(CommonItem.SCENE_INDEX.ToString() + "/A-D/" + CommonItem.SCENE_INDEX.ToString()+"_" + CommonItem.ANS_INDEX.ToString());
                       myvideo.videoPlayer.Pause();
                       Audio.BGSPlay("dialogue" + CommonItem.SCENE_INDEX.ToString(), false);
                    //    backGround.Alpha -= backGround.LINEAR_CHANGE_SPEED;
                    //    isChangeBackGround = true;
                       intRd = rd.Next(1, 5);
                        Cache.VD(CommonItem.SCENE_INDEX.ToString() + "/React/" + CommonItem.SCENE_INDEX.ToString() + "_" + CommonItem.ANS_INDEX.ToString() + intRd.ToString()); 

                   }
                   if (myvideo.videoPlayer.State == MediaState.Paused)
                   {
                       timeDialogue -= gameTime.ElapsedGameTime.Milliseconds;
                       if (timeDialogue < 0)
                       {
                           timeDialogue = 2000;
                           myvideo.videoPlayer.Resume();
                           //Audio.BGSStopAll();
                           switch (CommonItem.ANS_INDEX)
                           {
                               case 1:
                                   Audio.BGSPlay("Aggression", true);
                                   break;
                               case 2:
                                   Audio.BGSPlay("Submissive", true);
                                   break;
                               case 3:
                                   Audio.BGSPlay("Passive Aggression", true);
                                   break;
                               case 4:
                                   Audio.BGSPlay("Assertive", true);
                                   break;

                           }
                       }
                   }
                        //content.SourceTexture = Cache.Texture(@"Contents/"+CommonItem.SCENE_INDEX+@"/Cont_1" + CommonItem.ANS_INDEX + intRd);
                   if (myvideo.videoPlayer.State == MediaState.Stopped && CommonItem.BACKGROUND_INDEX == 5)
                    {
                        CommonItem.BACKGROUND_INDEX++;
                        myvideo.Play(CommonItem.SCENE_INDEX.ToString() + "/React/" + CommonItem.SCENE_INDEX.ToString() + "_" + CommonItem.ANS_INDEX.ToString() + intRd.ToString());
                               //intRd = rd.Next(1, 5);
                              if (CommonItem.ANS_INDEX == 4)
                                {
                                    Cache.VD(CommonItem.SCENE_INDEX + "/Transition/" + "pass");
                                }
                                else
                                {
                                    //if (intRd <= 3)
                                    //{
                                    //    Cache.VD(CommonItem.SCENE_INDEX.ToString() + "/Result/" + "End_" + intRd);           
                                    //}
                                    //else
                                    //{
                                    //    Cache.VD(CommonItem.SCENE_INDEX.ToString() + "/Result/1." + CommonItem.ANS_INDEX + "_End_d");            
                                    //    //myvideo.Play(CommonItem.SCENE_INDEX + "." + CommonItem.ANS_INDEX + "_End_d");
                                    //}
                                    Cache.VD(CommonItem.SCENE_INDEX.ToString() + "/Result/" + myvideo.result[CommonItem.SCENE_INDEX.ToString() + "." + CommonItem.ANS_INDEX.ToString() + intRd.ToString()]); //"End_" + intRd); 
                                }
                    }
                        //myvideo.Play(CommonItem.SCENE_INDEX.ToString() + "." + CommonItem.ANS_INDEX.ToString() + intRd.ToString());
                    
                    //if (backGround.Alpha >= 1f)
                    //{
                   if (myvideo.videoPlayer.PlayPosition.Milliseconds == myvideo.videoPlayer.PlayPosition.TotalMilliseconds)
                   { 
                      // backGround.SourceTexture = myvideo.videoPlayer.GetTexture();                             
                   }
                   if (myvideo.videoPlayer.State == MediaState.Stopped)
                   {
                       if (myvideo.isStop == false)
                       {     
                           myvideo.isStop = true;
                           if (CommonItem.ANS_INDEX == 4)
                           {
                               myvideo.Play(CommonItem.SCENE_INDEX + "/Transition/" + "pass");
                               Audio.BGSStopAll();
                               //intRd = 4;
                               switch (intRd)
                               {
                                   case 1:
                                       Audio.BGSPlay("Aggression",false);
                                       break;
                                   case 2:
                                       Audio.BGSPlay("Submissive", false);
                                       break;
                                   case 3:
                                       Audio.BGSPlay("Passive Aggression", false);
                                       break;
                                   case 4:
                                       Audio.BGSPlay("Assertive", false);
                                       Audio.BGSPlay("Applause", false);
                                       break;
                               }
                           }
                           else
                           {
                               //if (intRd <= 3)
                               //{
                               //    myvideo.Play(CommonItem.SCENE_INDEX.ToString() + "/Result/" + "End_" + intRd);
                               //}
                               //else
                               //{
                               //    myvideo.Play(CommonItem.SCENE_INDEX.ToString() + "/Result/1." + CommonItem.ANS_INDEX + "_End_d");
                                   
                               //    //myvideo.Play(CommonItem.SCENE_INDEX + "." + CommonItem.ANS_INDEX + "_End_d");
                               //}
                               myvideo.Play(CommonItem.SCENE_INDEX.ToString() + "/Result/" + myvideo.result[CommonItem.SCENE_INDEX.ToString() + "." + CommonItem.ANS_INDEX.ToString() + intRd.ToString()]);
                           }
                       }
                       if (isAnserRight ==false)
                       {
                           backGround.Alpha = 0.8f;
                       }
                       gamestate = GameState.result;
                   }

                        //content.isVisible = true;
                        //if (mouseLeftButtonClick())
                        //{
                            //content.isVisible = false;
                            //intRd = rd.Next(1, 5);
                            //isChangeBackGround = true;
                            //result.SourceTexture = Cache.Texture(@"Results/"+ CommonItem.SCENE_INDEX+@"/Result_1" + CommonItem.ANS_INDEX + intRd);
                            //gamestate = GameState.result;
                    //    }
                    //}
                    break;

                case GameState.result:

                    //if (backGround.Alpha >= 1f)
                    //{
                    //    result.isVisible = true;
                    //    if (mouseLeftButtonClick())
                    //    {
                    //        result.isVisible = false;
                    if (myvideo.videoPlayer.State == MediaState.Stopped)
                    {
                        if (isAnserRight == true)
                        {
                            answers.PositionUpate(); //Update answers Position randomly
                            isAnserRight = false;
                            CommonItem.BACKGROUND_INDEX = 3;                   
                            gamestate = GameState.start;
                            CommonItem.SCENE_INDEX++;
                            if (CommonItem.SCENE_INDEX <= 4)
                            {
                                Audio.BGSStopAll();
                                Audio.BGSPlay("Stage" + CommonItem.SCENE_INDEX + "_start", true);
                                myvideo.Play("scene" + CommonItem.SCENE_INDEX);
                                backGround.SourceTexture = new BackGround("Q" + CommonItem.SCENE_INDEX, 0, true, Vector2.Zero).SourceTexture;
                            }

                            if (CommonItem.SCENE_INDEX > 4)
                            {
                                //CommonItem.BACKGROUND_INDEX = 1;

                                //backGround.SourceTexture = new BackGround("bg-01", 0, true, Vector2.Zero).SourceTexture;
                                //gamestate = GameState.start;
                                //CommonItem.SCENE_INDEX = 1;
                                //isPlayingIntro = false;

                               // wrongcount = 0;
                                getPassMode();
                                CommonItem.BACKGROUND_INDEX = 7;
                                isChangeBackGround = true;
                                backGround.Alpha = 0.8f;
                                gamestate = GameState.gameOver;
                                Audio.BGSStopAll();
                            }
                        }
                        else if (wrongcount < 3)
                        {
                           
                            //CommonItem.BACKGROUND_INDEX=6;
                            //isChangeBackGround = true;
                            gamestate = GameState.tryAgain;
                        }
                        else if (wrongcount >= 3)
                        {
                            //wrongcount = 0;

                            //CommonItem.BACKGROUND_INDEX = 7;
                            //isChangeBackGround = true;
                            //gamestate = GameState.gameOver;

                            backGround.isVisible = false;
                            backGround.Alpha = 1;
                            answers.PositionUpate(); //Update answers Position randomly
                            isAnserRight = false;
                            CommonItem.BACKGROUND_INDEX = 3;
                            backGround.SourceTexture = new BackGround("Q" + CommonItem.SCENE_INDEX, 0, true, Vector2.Zero).SourceTexture;
                            gamestate = GameState.start;
                            isPlayingIntro = false;
                        }
                        myvideo.isStop = false;
                    }
                    //    }
                    //}
                   break;
             
                case GameState.tryAgain:
                   
                        if (myvideo.videoPlayer.State==MediaState.Stopped&&myvideo.isStop ==false)
                        {   
                            myvideo.isStop = true;
                            myvideo.Play(CommonItem.SCENE_INDEX + "/Transition/" + "Try Again");
                          
                        }
                        if (myvideo.videoPlayer.State == MediaState.Stopped&&myvideo.isStop == true)
                        {
                            myvideo.isStop = false;
                            backGround.isVisible = false;
                            answers.PositionUpate(); //Update answers Position randomly
                            isAnserRight = false;
                            CommonItem.BACKGROUND_INDEX = 3;
                            backGround.Alpha = 1;
                            backGround.SourceTexture = new BackGround("Q" + CommonItem.SCENE_INDEX, 0, true, Vector2.Zero).SourceTexture;
                            gamestate = GameState.start;
                        }
                    
                    break;
                    //summarize the game scene
                case GameState.gameOver:
                    if (backGround.Alpha >= 1)
                    {
                        if (mouseLeftButtonClick())
                        {
                            backGround.isVisible = true;
                            backGround.Alpha = 1;
                            answers.PositionUpate(); //Update answers Position randomly
                            isAnserRight = false;
                            CommonItem.BACKGROUND_INDEX = 1;
                            backGround.SourceTexture = new BackGround("bg-01", 0, true, Vector2.Zero).SourceTexture;
                            CommonItem.SCENE_INDEX = 1;
                           gamestate = GameState.start;
                           isPlayingIntro = false;
                            //the mode count set default zero
                           CommonItem.aggressiveCount = 0;
                           CommonItem.submissiveCount = 0;
                           CommonItem.passiveAggressiveCount = 0;
                        }
                    }
                    break;
            }
            pre_mouseState = mouseState;
            oldKeyState = myKeyboardState;
            base.Update(gameTime);
        }

        private bool voiceCcontainsMouse(Microsoft.Xna.Framework.Point mousePosition)
        {
            foreach (var voice in answers.Voices)
            {
                if (voice.CollisionRect.Contains(mousePosition))
                {
                    return true;
                }
            }
            return false;
        }
        //get the game pass mode to choosr the game over scene
        private int getPassMode()
        {
            if (CommonItem.aggressiveCount <= 4 && CommonItem.submissiveCount <= 4 && CommonItem.passiveAggressiveCount <= 4)
            {
                return 3;
            }
            if (CommonItem.aggressiveCount == CommonItem.submissiveCount && CommonItem.aggressiveCount == CommonItem.passiveAggressiveCount)
            {
                return 0;
            }

            if (CommonItem.aggressiveCount >= CommonItem.passiveAggressiveCount)
            {
                if (CommonItem.aggressiveCount >= CommonItem.submissiveCount)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }


            }
            else
            {
                if (CommonItem.passiveAggressiveCount >= CommonItem.submissiveCount)
                {
                    return 2;
                }
                else
                {
                    return 1;
                }
            }
           
        }

        private void CursorUpdate()
        {
            cursor.Alpha -= cursor.LINEAR_CHANGE_SPEED;
            if (cursor.Alpha <= 0) cursor.LINEAR_CHANGE_SPEED *= -1;
            if (cursor.Alpha >= 1) cursor.LINEAR_CHANGE_SPEED *= -1;
            //cursor.isVisible = false;
            cursor.position = new Vector2(CommonItem.inputBoxPosition.X + CommonItem.cursorPosition.X + textBox.keyboardString.Length * 13, CommonItem.inputBoxPosition.Y + CommonItem.cursorPosition.Y);
           
           
        }

        private void spriteRectUpdate()
        {

            exit.Alpha = backGround.Alpha;
            home.Alpha = backGround.Alpha;
            if (loginButton.isAlive == false)
            {
                loginButton.Alpha -= loginDisapprearSpeed;
                inputBox.Alpha -= loginDisapprearSpeed;
                if (loginButton.Alpha <= 0f)
                {
                    loginButton.isAlive = true;
                    inputBox.isAlive = true;

                    loginButton.isVisible = false;
                    inputBox.isVisible = false;

                    cursor.isVisible = false;
                    
                    loginButton.Alpha = 1f; ;
                    inputBox.Alpha = 1f;
                    
                    gamestate = GameState.start;
                }
            }
            if (loginButton.isVisible == true)
            {
                if (loginButton.CollisionRect.Contains(mousePosition))
                {
                    loginButton.CurrentPositionX = 1;
                    //loginButton.ShowingRect = loginButton.SourceRect(loginButton);
                    if (mouseLeftButtonClick())
                    {

                        if (dbconnect.read(textBox.Id.myText))
                        {
                            loginButton.isAlive = false;
                            inputBox.isAlive = false;
                            textBox.Id.ShouldItBeShownInThisScreen = false;
                            textBox.Name.ShouldItBeShownInThisScreen = false;
                            // dbconnect.OpenConnection();
                            //dbconnect.Insert(textBox.Id.myText,textBox.Name.myText);
                            //textBox.playerInfo.myText = dbconnect.getPlayerInfo(textBox.Id.myText);
                        }
                        else
                        {
                            MessageBox.Show("invalid ID,please again!");
                        }
                    }
                }
                else
                {
                    loginButton.CurrentPositionX = 0;
                    //loginButton.ShowingRect = loginButton.SourceRect(loginButton);
                }
            }

            if (CommonItem.BACKGROUND_INDEX == 1 && backGround.Alpha == 1)
            {
                home.isVisible = false;
                exit.isVisible = true;
                start.isVisible = true;
                if (exit.CollisionRect.Contains(mousePosition) && mouseLeftButtonClick()&&exit.isVisible==true)
                {
                    exit.CurrentPositionX = 0;
                    exit.SourceRect(exit);
                    this.Exit();
                }
                if (start.CollisionRect.Contains(mousePosition) && mouseLeftButtonClick() && start.isVisible == true)
                {
                    start.CurrentPositionX = 0;
                    start.SourceRect(start);
                    start.isVisible = false;
                }
                backGround.CollisionRect = new Microsoft.Xna.Framework.Rectangle((int)(1078 * CommonItem.rate.X), (int)(452 * CommonItem.rate.X), (int)(121 * CommonItem.rate.X), (int)(111 * CommonItem.rate.X));
            }
            else
            {
                if (backGround.Alpha <= 0.4) exit.isVisible = false;
                if (backGround.Alpha ==1) home.isVisible = true;
               
               
              
                backGround.CollisionRect = new Microsoft.Xna.Framework.Rectangle((int)(1099 * CommonItem.rate.X), (int)(582 * CommonItem.rate.X), (int)(106 * CommonItem.rate.X), (int)(102 * CommonItem.rate.X));
               
                if (next_icon1.CollisionRect.Contains(mousePosition) && mouseLeftButtonPressed() && exit.isVisible == false&&CommonItem.BACKGROUND_INDEX <=3)
                {
                    next_icon1.isVisible = true;
                    next_icon1.iCount = 0;
                }
                else
                {
                    next_icon1.iCount++;
                    if (next_icon1.iCount >= 30)
                    {
                        next_icon1.iCount = 0;
                        next_icon1.isVisible = false;
                    }
                }
            }
            if (gamestate == GameState.gameOver)
            {
                home.isVisible = false;
                exit.isVisible = false;
            }
            //im bellow gameState,the home button visible is false
            if (gamestate == GameState.choose || gamestate == GameState.preChoose || gamestate == GameState.response || gamestate == GameState.result || myvideo.videoPlayer.State == MediaState.Playing)
            {
                home.isVisible = false;
            }
            if (home.CollisionRect.Contains(mousePosition) && mouseLeftButtonClick() && home.isVisible == true)
            {
                CommonItem.BACKGROUND_INDEX = 1;
                home.CurrentPositionX = 0;
                home.SourceRect(home);
                //isChangeBackGround = true;
                answers.Visible = false;
                isPlayingIntro = false;
               
                backGround.SourceTexture = new BackGround("bg-01", 0, true, Vector2.Zero).SourceTexture;
                gamestate = GameState.start;
            }
            if (home.CollisionRect.Contains(mousePosition) && mouseLeftButtonPressed() && home.isVisible == true)
            {
                home.CurrentPositionX = 1;
                home.SourceRect(home);
            }
            if (exit.CollisionRect.Contains(mousePosition) && mouseLeftButtonPressed() && exit.isVisible == true)
            {
                exit.CurrentPositionX = 1;
                exit.SourceRect(exit);
            }
            if (start.CollisionRect.Contains(mousePosition) && mouseLeftButtonPressed() && start.isVisible == true)
            {
                start.CurrentPositionX = 1;
                start.SourceRect(start);
            }

        }
        //background update
        private void BackGroundUpdate()
        {
           // if (backGround.CollisionRect.Contains(mousePosition) && mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && exit.isVisible == false)
           
            //background change(linear switch to next)
            #region background change(linear switch to next)
            if (isChangeBackGround == true)
            {
                backGroundFadein_out();
               
            }
            #endregion



            if (CommonItem.BACKGROUND_INDEX == 06 && backGround.Alpha >= 1 && myvideo.videoPlayer.State == MediaState.Stopped)
            {
                wrongCount.CurrentPositionX = wrongcount - 1;
                wrongCount.isVisible = true;
            }
            else
            {
                wrongCount.isVisible = false;
            }
            /////////////////////////////////////////////////the stage string and stage number visible//////////////////
            //if (CommonItem.BACKGROUND_INDEX <= 2)
            //{
            //    Stage.isVisible = false;
            //    StageNumber.isVisible = false;
            //}
            //else if(backGround.Alpha>=1&&backGround.isVisible==true)
            //{
            //    Stage.isVisible = true;
            //    StageNumber.isVisible = true;
            //}
            if (CommonItem.BACKGROUND_INDEX == 3 && backGround.Alpha >= 1 && backGround.isVisible == true)
            {
                Stage.isVisible = true;
                StageNumber.isVisible = true;
            }
            else
            {
                Stage.isVisible = false;
                StageNumber.isVisible = false;
            }


        }

        private void backGroundFadein_out()
        {
            backGround.Alpha -= backGround.LINEAR_CHANGE_SPEED;
            if (backGround.Alpha <= 0.2f)
            {
                backGround.isVisible = true;
                if (CommonItem.BACKGROUND_INDEX == 3)
                {
                    backGround.SourceTexture = new BackGround("Q" + CommonItem.SCENE_INDEX, 0, true, Vector2.Zero).SourceTexture;
                }
                else if (CommonItem.BACKGROUND_INDEX == 4)
                {
                    backGround.SourceTexture = new BackGround("A" + CommonItem.SCENE_INDEX+"_BG", 0, true, Vector2.Zero).SourceTexture;
                }
                else if (CommonItem.BACKGROUND_INDEX == 7)
                {
                    backGround.SourceTexture = new BackGround("S_" +getPassMode(), 0, true, Vector2.Zero).SourceTexture;
                }
                else
                {
                    backGround.SourceTexture = backGround.reload().SourceTexture;
                }
                backGround.LINEAR_CHANGE_SPEED *= -1;
            }
            if (backGround.Alpha >= 1f)
            {         
                backGround.LINEAR_CHANGE_SPEED *= -1;
                isChangeBackGround = false;
            }
        }
        //this is mouse click update current,later it will become screen touch 
        private void TouchUpdate()
        {

            
            if (mouseLeftButtonClick() && backGround.CollisionRect.Contains(mousePosition)&&CommonItem.BACKGROUND_INDEX<=3&&backGround.Alpha>=1&&myvideo.videoPlayer.State==MediaState.Stopped)
            {

                    backGround.Alpha -= 0.01f;
                    CommonItem.BACKGROUND_INDEX++;
                    if (CommonItem.BACKGROUND_INDEX == 2)
                    {
                        Cache.VD("scene" + CommonItem.SCENE_INDEX);
                        Audio.BGSPlay("role_introduction", false);
                    }
                if (CommonItem.BACKGROUND_INDEX == 3)
                    {
                        myvideo.Play("scene"+CommonItem.SCENE_INDEX);
                        Audio.BGSStopAll();
          
                        Audio.BGSPlay("Stage" + CommonItem.SCENE_INDEX + "_start", true);
                    }
                    isChangeBackGround = true;     
                if (CommonItem.BACKGROUND_INDEX >= 4)
                {
                   
                    gamestate = GameState.preChoose;
                    answers = new Answers();
                    AddChild(answers.Ans_01);
                    AddChild(answers.Ans_02);
                    AddChild(answers.Ans_03);
                    AddChild(answers.Ans_04);
                    AddChild(answers.option_A);
                    AddChild(answers.option_B);
                    AddChild(answers.option_C);
                    AddChild(answers.option_D);
                    AddChild(answers.voice_A);
                    AddChild(answers.voice_B);
                    AddChild(answers.voice_C);
                    AddChild(answers.voice_D);

                }
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.Black);
            if (myvideo.videoPlayer.State != MediaState.Stopped)
            {
                myvideo.videoTexture = myvideo.videoPlayer.GetTexture();
            }
            SpriteEffect.CurrentTechnique = SpriteEffect.Techniques["AlphaBlend"];
            spriteBatch.Begin(SpriteSortMode.Immediate,BlendState.AlphaBlend,null,null,null,SpriteEffect);

            foreach (var sp in Sprites)
            {
                if (sp.isVisible == true)
                {
                   
                    sp.scale =CommonItem.rate;
                    sp.finalColor.A = (byte)(255 * sp.Alpha);
                    spriteBatch.Draw(sp.SourceTexture, sp.position, sp.ShowingRect, sp.finalColor, 0f, Vector2.Zero, sp.scale, SpriteEffects.None, 1f);
                    //spriteBatch.Draw(sp.SourceTexture, new Microsoft.Xna.Framework.Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), sp.ShowingRect, sp.finalColor);
                    
                }
            }

            if (myvideo.videoPlayer.State != MediaState.Stopped&&!isPlayingVoice)
            {
                if (myvideo.videoTexture.Width > 1200)
                {
                    spriteBatch.Draw(myvideo.videoTexture, new Microsoft.Xna.Framework.Rectangle(-(int)(CommonItem.rate.X*50), 0, GraphicsDevice.Viewport.Width+(int)(CommonItem.rate.X*100), GraphicsDevice.Viewport.Height + 5), Microsoft.Xna.Framework.Color.White);
                }
                else
                {
                    spriteBatch.Draw(myvideo.videoTexture, new Microsoft.Xna.Framework.Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height + 5), Microsoft.Xna.Framework.Color.White);
                }
                
               
            }
            textBox.DrawTexts(spriteBatch);
            if (gamestate == GameState.gameOver&&backGround.Alpha==1)
            {
                spriteBatch.DrawString(Font1, "" + CommonItem.submissiveCount, new Vector2(824 * CommonItem.rate.X, 286 * CommonItem.rate.Y), Microsoft.Xna.Framework.Color.LightGreen, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0.5f);
                spriteBatch.DrawString(Font1, "" + CommonItem.passiveAggressiveCount, new Vector2(824 * CommonItem.rate.X, 367 * CommonItem.rate.Y), Microsoft.Xna.Framework.Color.LightGreen, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0.5f);
                spriteBatch.DrawString(Font1, "" + CommonItem.aggressiveCount, new Vector2(824 * CommonItem.rate.X, 447 * CommonItem.rate.Y), Microsoft.Xna.Framework.Color.LightGreen, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0.5f);
                spriteBatch.DrawString(Font1, "4", new Vector2(824 * CommonItem.rate.X, 530 * CommonItem.rate.Y), Microsoft.Xna.Framework.Color.LightGreen, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0.5f);
            }                                                                
            spriteBatch.End();
            base.Draw(gameTime);
      
        }

        public virtual void AddChild(Sprite child)
        {
            Sprites.Add(child);
            sortChilds();
        }

        private void sortChilds()
        {
            Sprites.Sort(sortFunc);
        }

        int sortFunc(Sprite a, Sprite b)
        {
            if (a.Z > b.Z) return 1;
            else if (a.Z < b.Z) return -1;
            else return 0;
        }

        private bool mouseLeftButtonClick()
        {
            Boolean result = false;
            if (mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released && pre_mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)result=true;
            return result;
        }
        private bool mouseLeftButtonPressed()
        {
            Boolean result = false;
            if (mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed&& pre_mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released) result = true;
            return result;
        }


        
    }
}
