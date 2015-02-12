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
using System.Text;
using System.Collections;


namespace PsychologeGame
{

    public class MyTextBox
    {
        public bool isVisible=true;
        //public Text mytext;
        public Text Id;
        public Text Name;
        public Text Age;
        public Text playerInfo;
        public List<Text> myTexts = new List<Text>();
        bool IsGettingStringFromUseron = true;
        public string keyboardString = "";
       public clsInput myclsinput;
        ContentManager content;
        
        public MyTextBox(ContentManager c)
        {
            this.content = c;
            myclsinput = new clsInput();
            //mytext
            //mytext = new Text();
            //mytext.key = 0;
            //mytext.HorizontalMargin = 50;
            //mytext.mycolor = Color.Wheat;
            //mytext.rect = new Rectangle((CommonItem.BACKBUFFER_WIDTH - 1000) / 2 + mytext.HorizontalMargin,
            //  (CommonItem.BACKBUFFER_HEIGHT - 300) / 2 + 50, 1000 - 1 * mytext.HorizontalMargin, 300);
            //mytext.strplaceOfUse = "AddNewWords_Word";
            //mytext.ShouldItBeShownInThisScreen = true;
            //mytext.myText = "logintext";
            //mytext.FontSize = 22;
            //mytext.wrappedString = WrapText(fncGivemeFont(mytext.FontSize), mytext.myText, mytext.rect.Width);
            //mytext.Action = "TextBox";
            //mytext.isFocused = true;
            ////ArrayList=>MyTexts
            ////myTexts[0] = mytext;
            //myTexts.Add(mytext);

            Id = new Text();
            Id.key = 0;
            Id.HorizontalMargin = 50;
            Id.mycolor = Color.IndianRed;
            Id.rect = new Rectangle((int)(CommonItem.inputBoxPosition.X+CommonItem.loginTextBoxPosition.X),(int)(CommonItem.inputBoxPosition.Y+CommonItem.loginTextBoxPosition.Y), 1000 - 1 * Id.HorizontalMargin, 300);
            Id.strplaceOfUse = "AddNewWords_Word";
            Id.ShouldItBeShownInThisScreen = true;
            Id.myText = "put you ID";
            Id.FontSize = 22;
            Id.wrappedString = WrapText(fncGivemeFont(Id.FontSize), Id.myText, Id.rect.Width);
            Id.Action = "TextBox";
            Id.isFocused = true;
            //ArrayList=>Ids
            //Ids[0] = Id;
            myTexts.Add(Id);

            Name = new Text();
            Name.key = 0;
            Name.HorizontalMargin = 50;
            Name.mycolor = Color.IndianRed;
            Name.rect = new Rectangle((int)(CommonItem.inputBoxPosition.X + CommonItem.loginTextBoxPosition.X), (int)(CommonItem.inputBoxPosition.Y + CommonItem.loginTextBoxPosition.Y+58), 1000 - 1 * Name.HorizontalMargin, 300);
            Name.strplaceOfUse = "AddNewWords_Word";
            Name.ShouldItBeShownInThisScreen = true;
            Name.myText = "";
            Name.FontSize = 22;
            Name.wrappedString = WrapText(fncGivemeFont(Name.FontSize), Name.myText, Name.rect.Width);
            Name.Action = "TextBox";
            Name.isFocused = true;
            //ArrayList=>Names
            //Names[0] = Name;
            myTexts.Add(Name);

            Age = new Text();
            Age.key = 0;
            Age.HorizontalMargin = 50;
            Age.mycolor = Color.IndianRed;
            Age.rect = new Rectangle((int)(CommonItem.inputBoxPosition.X + CommonItem.loginTextBoxPosition.X), (int)(CommonItem.inputBoxPosition.Y + CommonItem.loginTextBoxPosition.Y + 58*2), 1000 - 1 * Age.HorizontalMargin, 300);
            Age.strplaceOfUse = "AddNewWords_Word";
            Age.ShouldItBeShownInThisScreen = true;
            Age.myText = "";
            Age.FontSize = 22;
            Age.wrappedString = WrapText(fncGivemeFont(Age.FontSize), Age.myText, Age.rect.Width);
            Age.Action = "TextBox";
            Age.isFocused = true;
            //ArrayList=>Ages
            //Ages[0] = Age;
            myTexts.Add(Age);

            playerInfo = new Text();
            playerInfo.key = 0;
            playerInfo.HorizontalMargin = 50;
            playerInfo.mycolor = Color.Blue;
            //playerInfo.rect = new Rectangle((int)playerInfoPosition.X, (int)playerInfoPosition.Y,300,1000 - 1 * playerInfo.HorizontalMargin);
            playerInfo.rect = new Rectangle((int)CommonItem.playerInfoPosition.X, (int)CommonItem.playerInfoPosition.Y,1000 - 1 * playerInfo.HorizontalMargin, 300);
            playerInfo.strplaceOfUse = "AddNewWords_Word";
            playerInfo.ShouldItBeShownInThisScreen = true;
            playerInfo.myText = "patient Info";
            playerInfo.FontSize = 22;
            playerInfo.wrappedString = WrapText(fncGivemeFont(playerInfo.FontSize), playerInfo.myText, playerInfo.rect.Width);
            playerInfo.Action = "TextBox";
            playerInfo.isFocused = true;
            myTexts.Add(playerInfo);
            
        }

        public void DrawTexts(SpriteBatch mybatch)
        {
            if (isVisible == true)
            {
                //foreach (var mytext in myTexts)
                //{
                //    if (mytext.ShouldItBeShownInThisScreen)
                //    {
                //        mybatch.DrawString(fncGivemeFont(mytext.FontSize),
                //          mytext.wrappedString,
                //          new Vector2(mytext.rect.Left, mytext.rect.Top),
                //          mytext.mycolor);
                //    }
                //}
                for (int i = 0; i < myTexts.ToArray().Length; i++)
                {

                    if (myTexts[i].ShouldItBeShownInThisScreen)
                    {
                        mybatch.DrawString(fncGivemeFont(myTexts[i].FontSize),
                          myTexts[i].myText,
                            new Vector2(myTexts[i].rect.Left, myTexts[i].rect.Top),
                           
                          myTexts[i].mycolor);
                    }
                }
                //mybatch.DrawString(fncGivemeFont(myTexts[0].FontSize),
                //       myTexts[0].wrappedString,
                //         new Vector2(myTexts[0].rect.Left, myTexts[0].rect.Top),
                //         myTexts[0].mycolor);
            }
        }

        public SpriteFont fncGivemeFont(int fontsize)
        {
            //string BaseDirectory = ".";
            SpriteFont myfont = null;
            //switch (fontsize)
            //{
            //    case 14:
            //        {
            //            myfont = content.Load<SpriteFont>(BaseDirectory + "\\Font\\myfont14");
            //            break;
            //        }
            //    case 16:
            //        {
            //            myfont = content.Load<SpriteFont>(BaseDirectory + "\\Font\\myfont16");
            //            break;
            //        }
            //    case 18:
            //        {
            //            myfont = content.Load<SpriteFont>(BaseDirectory + "\\Font\\myfont18");
            //            break;
            //        }
            //    case 20:
            //        {
            //            myfont = content.Load<SpriteFont>(BaseDirectory + "\\Font\\myfont20");
            //            break;
            //        }
            //    case 22:
            //        {
            //            myfont = content.Load<SpriteFont>(BaseDirectory + "\\Font\\myfont22");
            //            break;
            //        }
            //    default:
            //        {
            //            myfont = content.Load<SpriteFont>(BaseDirectory + "\\Font\\myfont14");
            //            break;
            //        }
            //}
            myfont = content.Load<SpriteFont>("GameContent\\Fonts\\myFont");
            return myfont;
        }
        public static string WrapText(SpriteFont spriteFont, string text, float maxLineWidth)
        {
            string[] words = text.Split(' ');
            StringBuilder sb = new StringBuilder();
            //
            ArrayList MyFormattedWords = new ArrayList();
            int currentkey = 0;
            //
            float lineWidth = 0f;

            float spaceWidth = spriteFont.MeasureString(" ").X;
            Vector2 ResidueSize = Vector2.Zero;
            foreach (string word in words)
            {
                Vector2 size = spriteFont.MeasureString(word);
                if (size.X > maxLineWidth)
                {

                    string tempstr1 = "";
                    int EndIndexOfSplittedWord = 0;
                    ArrayList mystringList = new ArrayList();
                    int SplittedWordIndex = 0;
                    int StartIndexOfSplittedWord = 0;
                    for (int i = 0; i < word.Length; i++)
                    {
                        tempstr1 += word[i];
                        Vector2 mytempstrsize = spriteFont.MeasureString(tempstr1);
                        if (mytempstrsize.X >= maxLineWidth)
                        {
                            EndIndexOfSplittedWord = i - 1;
                            mylist objstring = new mylist();
                            objstring.mystring = "";
                            SplittedWordIndex++;
                            objstring.key = SplittedWordIndex;
                            for (int j = StartIndexOfSplittedWord; j < EndIndexOfSplittedWord; j++)
                            {
                                objstring.mystring += word[j].ToString();
                            }
                            mystringList.Add(objstring);
                            tempstr1 = word[i].ToString();
                            StartIndexOfSplittedWord = i;
                            if (i == word.Length - 1)
                            {
                                mylist objstring2 = new mylist();
                                objstring2.mystring = tempstr1;
                                SplittedWordIndex++;
                                objstring2.key = SplittedWordIndex;
                                mystringList.Add(objstring2);
                            }
                        }
                        else if (!(mytempstrsize.X >= maxLineWidth))
                        {
                            if (i == word.Length - 1)
                            {
                                mylist objstring3 = new mylist();
                                objstring3.mystring = tempstr1;
                                SplittedWordIndex++;
                                objstring3.key = SplittedWordIndex;
                                mystringList.Add(objstring3);
                            }
                        }
                    }
                    //
                    string mystr = "";
                    for (int i = 1; i <= SplittedWordIndex; i++)
                    {
                        foreach (mylist objlist in mystringList)
                        {
                            if (objlist.key == i)
                            {
                                currentkey++;
                                mylist formattedobjlist;
                                formattedobjlist.key = currentkey;
                                formattedobjlist.mystring = objlist.mystring;
                                MyFormattedWords.Add(formattedobjlist);
                            }
                        }
                    }
                    sb.Append(mystr);
                }
                else
                {
                    currentkey++;
                    mylist formattedobjlist;
                    formattedobjlist.key = currentkey;
                    formattedobjlist.mystring = word;
                    MyFormattedWords.Add(formattedobjlist);
                }
            }
            for (int i = 1; i <= currentkey; i++)
            {
                foreach (mylist wordx in MyFormattedWords)
                {
                    if (i == wordx.key)
                    {
                        Vector2 size = spriteFont.MeasureString(wordx.mystring);

                        if (lineWidth + size.X < maxLineWidth)
                        {
                            sb.Append(wordx.mystring + " ");
                            lineWidth += size.X + spaceWidth;
                        }
                        else
                        {
                            sb.Append("\n" + wordx.mystring + " ");
                            lineWidth = size.X + spaceWidth;
                        }
                    }
                }
            }
            return sb.ToString();
        }

        public void OnKeyboardKeyPress(KeyboardState myKeyboardState, KeyboardState oldKeyState)
        {
            //if (myKeyboardState.IsKeyDown(Keys.Back))
            //{
            //    myclsinput = new clsInput();
            //    if (myclsinput.BackKeyState == "none") myclsinput.BackKeyState = "down";
            //    //if (keyboardString != "") keyboardString = keyboardString.Remove(keyboardString.Length - 1);
            //}
            //if (myKeyboardState.IsKeyUp(Keys.Back))
            //{
            //    if (myclsinput.BackKeyState == "down")
            //    {
            //        if (keyboardString != "") keyboardString = keyboardString.Remove(keyboardString.Length - 1);
            //        myclsinput.BackKeyState = "none";
            //    }
            //}

            //if (IsGettingStringFromUseron&&keyboardString.Length<15
            if (IsGettingStringFromUseron && keyboardString.Length < 13)
            {
                Keys[] mykeys = myKeyboardState.GetPressedKeys();
                bool isShift = myclsinput.isShiftPressed(mykeys);
                bool isControl = myclsinput.isControlPressed(mykeys);

                foreach (Keys key in myKeyboardState.GetPressedKeys())
                {
                    if (oldKeyState.IsKeyUp(key))
                    {
                        if (key == Keys.Back)
                        {
                            if (keyboardString.Length > 0)
                            {
                                keyboardString = keyboardString.Remove(keyboardString.Length - 1, 1);
                            }
                        }
                        else if (key.ToString().Length == 1 && keyboardString.Length < 12)
                        {
                            if (isShift)
                            {
                                keyboardString += key.ToString();
                            }
                            else
                            {
                                keyboardString += key.ToString().ToLower();
                            }
                        }
                        else if (key.ToString().StartsWith("D") && key.ToString().Length > 1 && keyboardString.Length < 12)
                        {
                            keyboardString += key.ToString().Substring(1);
                        }
                        else if (key.ToString().StartsWith("NumPad") && key.ToString().Length > 1 && keyboardString.Length < 12)
                        {
                            keyboardString += key.ToString().Substring("NumPad".Length);
                        }
                        else if (key == Keys.Subtract && keyboardString.Length < 12)
                        {
                            keyboardString += "-";
                        }
                        else if (key == Keys.OemMinus && keyboardString.Length < 12)
                        {
                            if (isShift)
                            {
                                keyboardString += "_";
                            }
                            else
                            {
                                keyboardString += "-";
                            }
                        }
                        //检查id是否存在
                        ////////////////////////////////
                    }
                }
                //    }
                //    ////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.A))
                //    {
                //        if (myclsinput.AKeyState == "none") myclsinput.AKeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.A))
                //    {
                //        if (myclsinput.AKeyState == "down")
                //        {
                //            if (isShift) keyboardString += "A";
                //            else keyboardString += "a";
                //            myclsinput.AKeyState = "none";
                //        }
                //    }
                //    ////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.Space))
                //    {
                //        if (myclsinput.SpaceKeyState == "none") myclsinput.SpaceKeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.Space))
                //    {
                //        if (myclsinput.SpaceKeyState == "down")
                //        {
                //            keyboardString += " ";
                //            myclsinput.SpaceKeyState = "none";
                //        }
                //    }
                //    ///////////////////////////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.B))
                //    {
                //        if (myclsinput.BKeyState == "none") myclsinput.BKeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.B))
                //    {
                //        if (myclsinput.BKeyState == "down")
                //        {
                //            if (isShift) keyboardString += "B";
                //            else keyboardString += "b";
                //            myclsinput.BKeyState = "none";
                //        }
                //    }
                //    ///////////////////////////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.Z))
                //    {
                //        if (myclsinput.ZKeyState == "none") myclsinput.ZKeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.Z))
                //    {
                //        if (myclsinput.ZKeyState == "down")
                //        {
                //            if (isShift) keyboardString += "Z";
                //            else keyboardString += "z";
                //            myclsinput.ZKeyState = "none";
                //        }
                //    }
                //    ///////////////////////////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.C))
                //    {
                //        if (myclsinput.CKeyState == "none") myclsinput.CKeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.C))
                //    {
                //        if (myclsinput.CKeyState == "down")
                //        {
                //            if (isShift) keyboardString += "C";
                //            else keyboardString += "c";
                //            myclsinput.CKeyState = "none";
                //        }
                //    }
                //    ////////////////////////////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.D))
                //    {
                //        if (myclsinput.DKeyState == "none") myclsinput.DKeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.D))
                //    {
                //        if (myclsinput.DKeyState == "down")
                //        {
                //            if (isShift) keyboardString += "D";
                //            else keyboardString += "d";
                //            myclsinput.DKeyState = "none";
                //        }
                //    }
                //    ////////////////////////////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.E))
                //    {
                //        if (myclsinput.EKeyState == "none") myclsinput.EKeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.E))
                //    {
                //        if (myclsinput.EKeyState == "down")
                //        {
                //            if (isShift) keyboardString += "E";
                //            else keyboardString += "e";
                //            myclsinput.EKeyState = "none";
                //        }
                //    }
                //    ///////////////////////////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.F))
                //    {
                //        if (myclsinput.FKeyState == "none") myclsinput.FKeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.F))
                //    {
                //        if (myclsinput.FKeyState == "down")
                //        {
                //            if (isShift) keyboardString += "F";
                //            else keyboardString += "f";
                //            myclsinput.FKeyState = "none";
                //        }
                //    }
                //    ///////////////////////////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.G))
                //    {
                //        if (myclsinput.GKeyState == "none") myclsinput.GKeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.G))
                //    {
                //        if (myclsinput.GKeyState == "down")
                //        {
                //            if (isShift) keyboardString += "G";
                //            else keyboardString += "g";
                //            myclsinput.GKeyState = "none";
                //        }
                //    }
                //    ///////////////////////////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.H))
                //    {
                //        if (myclsinput.HKeyState == "none") myclsinput.HKeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.H))
                //    {
                //        if (myclsinput.HKeyState == "down")
                //        {
                //            if (isShift) keyboardString += "H";
                //            else keyboardString += "h";
                //            myclsinput.HKeyState = "none";
                //        }
                //    }
                //    ///////////////////////////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.I))
                //    {
                //        if (myclsinput.IKeyState == "none") myclsinput.IKeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.I))
                //    {
                //        if (myclsinput.IKeyState == "down")
                //        {
                //            if (isShift) keyboardString += "I";
                //            else keyboardString += "i";
                //            myclsinput.IKeyState = "none";
                //        }
                //    }
                //    ///////////////////////////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.J))
                //    {
                //        if (myclsinput.JKeyState == "none") myclsinput.JKeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.J))
                //    {
                //        if (myclsinput.JKeyState == "down")
                //        {
                //            if (isShift) keyboardString += "J";
                //            else keyboardString += "j";
                //            myclsinput.JKeyState = "none";
                //        }
                //    }
                //    ///////////////////////////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.K))
                //    {
                //        if (myclsinput.KKeyState == "none") myclsinput.KKeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.K))
                //    {
                //        if (myclsinput.KKeyState == "down")
                //        {
                //            if (isShift) keyboardString += "K";
                //            else keyboardString += "k";
                //            myclsinput.KKeyState = "none";
                //        }
                //    }
                //    if (myKeyboardState.IsKeyDown(Keys.L))
                //    {
                //        if (myclsinput.LKeyState == "none") myclsinput.LKeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.L))
                //    {
                //        if (myclsinput.LKeyState == "down")
                //        {
                //            if (isShift) keyboardString += "L";
                //            else keyboardString += "l";
                //            myclsinput.LKeyState = "none";
                //        }
                //    }
                //    ///////////////////////////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.M))
                //    {
                //        if (myclsinput.MKeyState == "none") myclsinput.MKeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.M))
                //    {
                //        if (myclsinput.MKeyState == "down")
                //        {
                //            if (isShift) keyboardString += "M";
                //            else keyboardString += "m";
                //            myclsinput.MKeyState = "none";
                //        }
                //    }
                //    ///////////////////////////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.N))
                //    {
                //        if (myclsinput.NKeyState == "none") myclsinput.NKeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.N))
                //    {
                //        if (myclsinput.NKeyState == "down")
                //        {
                //            if (isShift) keyboardString += "N";
                //            else keyboardString += "n";
                //            myclsinput.NKeyState = "none";
                //        }
                //    }
                //    ///////////////////////////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.O))
                //    {
                //        if (myclsinput.OKeyState == "none") myclsinput.OKeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.O))
                //    {
                //        if (myclsinput.OKeyState == "down")
                //        {
                //            if (isShift) keyboardString += "O";
                //            else keyboardString += "o";
                //            myclsinput.OKeyState = "none";
                //        }
                //    }
                //    ///////////////////////////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.P))
                //    {
                //        if (myclsinput.PKeyState == "none") myclsinput.PKeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.P))
                //    {
                //        if (myclsinput.PKeyState == "down")
                //        {
                //            if (isShift) keyboardString += "P";
                //            else keyboardString += "p";
                //            myclsinput.PKeyState = "none";
                //        }
                //    }
                //    ///////////////////////////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.Q))
                //    {
                //        if (myclsinput.QKeyState == "none") myclsinput.QKeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.Q))
                //    {
                //        if (myclsinput.QKeyState == "down")
                //        {
                //            if (isShift) keyboardString += "Q";
                //            else keyboardString += "q";
                //            myclsinput.QKeyState = "none";
                //        }
                //    }
                //    ///////////////////////////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.R))
                //    {
                //        if (myclsinput.RKeyState == "none") myclsinput.RKeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.R))
                //    {
                //        if (myclsinput.RKeyState == "down")
                //        {
                //            if (isShift) keyboardString += "R";
                //            else keyboardString += "r";
                //            myclsinput.RKeyState = "none";
                //        }
                //    }
                //    ///////////////////////////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.S))
                //    {
                //        if (myclsinput.SKeyState == "none") myclsinput.SKeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.S))
                //    {
                //        if (myclsinput.SKeyState == "down")
                //        {
                //            if (isShift) keyboardString += "S";
                //            else keyboardString += "s";
                //            myclsinput.SKeyState = "none";
                //        }
                //    }
                //    ///////////////////////////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.T))
                //    {
                //        if (myclsinput.TKeyState == "none") myclsinput.TKeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.T))
                //    {
                //        if (myclsinput.TKeyState == "down")
                //        {
                //            if (isShift) keyboardString += "T";
                //            else keyboardString += "t";
                //            myclsinput.TKeyState = "none";
                //        }
                //    }
                //    ///////////////////////////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.U))
                //    {
                //        if (myclsinput.UKeyState == "none") myclsinput.UKeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.U))
                //    {
                //        if (myclsinput.UKeyState == "down")
                //        {
                //            if (isShift) keyboardString += "U";
                //            else keyboardString += "u";
                //            myclsinput.UKeyState = "none";
                //        }
                //    }
                //    ///////////////////////////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.V))
                //    {
                //        if (myclsinput.VKeyState == "none") myclsinput.VKeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.V))
                //    {
                //        if (myclsinput.VKeyState == "down")
                //        {
                //            if (isShift) keyboardString += "V";
                //            else keyboardString += "v";
                //            myclsinput.VKeyState = "none";
                //        }
                //    }
                //    ///////////////////////////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.W))
                //    {
                //        if (myclsinput.WKeyState == "none") myclsinput.WKeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.W))
                //    {
                //        if (myclsinput.WKeyState == "down")
                //        {
                //            if (isShift) keyboardString += "W";
                //            else keyboardString += "w";
                //            myclsinput.WKeyState = "none";
                //        }
                //    }
                //    ///////////////////////////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.Y))
                //    {
                //        if (myclsinput.YKeyState == "none") myclsinput.YKeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.Y))
                //    {
                //        if (myclsinput.YKeyState == "down")
                //        {
                //            if (isShift) keyboardString += "Y";
                //            else keyboardString += "y";
                //            myclsinput.YKeyState = "none";
                //        }
                //    }
                //    ///////////////////////////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.X))
                //    {
                //        if (myclsinput.XKeyState == "none") myclsinput.XKeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.X))
                //    {
                //        if (myclsinput.XKeyState == "down")
                //        {
                //            if (isShift) keyboardString += "X";
                //            else keyboardString += "x";
                //            myclsinput.XKeyState = "none";
                //        }
                //    }
                //    /////////////////////////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.OemSemicolon))
                //    {
                //        if (myclsinput.OemSemicolonKeyState == "none") myclsinput.OemSemicolonKeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.OemSemicolon))
                //    {
                //        if (myclsinput.OemSemicolonKeyState == "down")
                //        {
                //            if (isShift) keyboardString += ":";
                //            else keyboardString += ";";
                //            myclsinput.OemSemicolonKeyState = "none";
                //        }
                //    }
                //    /////////////////////////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.OemQuotes))
                //    {
                //        if (myclsinput.OemQuotesKeyState == "none") myclsinput.OemQuotesKeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.OemQuotes))
                //    {
                //        if (myclsinput.OemQuotesKeyState == "down")
                //        {
                //            if (isShift) keyboardString += "\"";
                //            else keyboardString += "'";
                //            myclsinput.OemQuotesKeyState = "none";
                //        }
                //    }
                //    ///////////////////////////////////////////////////////////
                //    //if (myKeyboardState.IsKeyDown(Keys.Back))
                //    //{
                //    //    if (myclsinput.BackKeyState == "none") myclsinput.BackKeyState = "down";
                //    //}
                //    //if (myKeyboardState.IsKeyUp(Keys.Back))
                //    //{
                //    //    if (myclsinput.BackKeyState == "down")
                //    //    {
                //    //        if (keyboardString != "") keyboardString = keyboardString.Remove(keyboardString.Length - 1);
                //    //        myclsinput.BackKeyState = "none";
                //    //    }
                //    //}
                //    ///////////////////////////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.OemComma))
                //    {
                //        if (myclsinput.OemCommaKeyState == "none") myclsinput.OemCommaKeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.OemComma))
                //    {
                //        if (myclsinput.OemCommaKeyState == "down")
                //        {
                //            if (isShift) keyboardString += "<";
                //            else keyboardString += ",";
                //            myclsinput.OemCommaKeyState = "none";
                //        }
                //    }
                //    ///////////////////////////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.OemPeriod))
                //    {
                //        if (myclsinput.OemPeriodKeyState == "none") myclsinput.OemPeriodKeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.OemPeriod))
                //    {
                //        if (myclsinput.OemPeriodKeyState == "down")
                //        {
                //            if (isShift) keyboardString += ">";
                //            else keyboardString += ".";
                //            myclsinput.OemPeriodKeyState = "none";
                //        }
                //    }
                //    ///////////////////////////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.OemQuestion))
                //    {
                //        if (myclsinput.OemQuestionKeyState == "none") myclsinput.OemQuestionKeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.OemQuestion))
                //    {
                //        if (myclsinput.OemQuestionKeyState == "down")
                //        {
                //            if (isShift) keyboardString += "?";
                //            else keyboardString += "/";
                //            myclsinput.OemQuestionKeyState = "none";
                //        }
                //    }
                //    ///////////////////////////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.OemOpenBrackets))
                //    {
                //        if (myclsinput.OemOpenBracketsKeyState == "none") myclsinput.OemOpenBracketsKeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.OemOpenBrackets))
                //    {
                //        if (myclsinput.OemOpenBracketsKeyState == "down")
                //        {
                //            if (isShift) keyboardString += "{";
                //            else keyboardString += "[";
                //            myclsinput.OemOpenBracketsKeyState = "none";
                //        }
                //    }
                //    ///////////////////////////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.OemCloseBrackets))
                //    {
                //        if (myclsinput.OemCloseBracketsKeyState == "none") myclsinput.OemCloseBracketsKeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.OemCloseBrackets))
                //    {
                //        if (myclsinput.OemCloseBracketsKeyState == "down")
                //        {
                //            if (isShift) keyboardString += "}";
                //            else keyboardString += "]";
                //            myclsinput.OemCloseBracketsKeyState = "none";
                //        }
                //    }
                //    ///////////////////////////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.OemPipe))
                //    {
                //        if (myclsinput.OemPipeKeyState == "none") myclsinput.OemPipeKeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.OemPipe))
                //    {
                //        if (myclsinput.OemPipeKeyState == "down")
                //        {
                //            if (isShift) keyboardString += "|";
                //            else keyboardString += "\\";
                //            myclsinput.OemPipeKeyState = "none";
                //        }
                //    }
                //    ///////////////////////////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.D1))
                //    {
                //        if (myclsinput.D1KeyState == "none") myclsinput.D1KeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.D1))
                //    {
                //        if (myclsinput.D1KeyState == "down")
                //        {
                //            if (isShift) keyboardString += "!";
                //            else keyboardString += "1";
                //            myclsinput.D1KeyState = "none";
                //        }
                //    }
                //    ///////////////////////////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.D2))
                //    {
                //        if (myclsinput.D2KeyState == "none") myclsinput.D2KeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.D2))
                //    {
                //        if (myclsinput.D2KeyState == "down")
                //        {
                //            if (isShift) keyboardString += "@";
                //            else keyboardString += "2";
                //            myclsinput.D2KeyState = "none";
                //        }
                //    }
                //    ///////////////////////////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.D3))
                //    {
                //        if (myclsinput.D3KeyState == "none") myclsinput.D3KeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.D3))
                //    {
                //        if (myclsinput.D3KeyState == "down")
                //        {
                //            if (isShift) keyboardString += "#";
                //            else keyboardString += "3";
                //            myclsinput.D3KeyState = "none";
                //        }
                //    }
                //    ///////////////////////////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.D4))
                //    {
                //        if (myclsinput.D4KeyState == "none") myclsinput.D4KeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.D4))
                //    {
                //        if (myclsinput.D4KeyState == "down")
                //        {
                //            if (isShift) keyboardString += "$";
                //            else keyboardString += "4";
                //            myclsinput.D4KeyState = "none";
                //        }
                //    }
                //    ///////////////////////////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.D5))
                //    {
                //        if (myclsinput.D5KeyState == "none") myclsinput.D5KeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.D5))
                //    {
                //        if (myclsinput.D5KeyState == "down")
                //        {
                //            if (isShift) keyboardString += "%";
                //            else keyboardString += "5";
                //            myclsinput.D5KeyState = "none";
                //        }
                //    }
                //    ///////////////////////////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.D6))
                //    {
                //        if (myclsinput.D6KeyState == "none") myclsinput.D6KeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.D6))
                //    {
                //        if (myclsinput.D6KeyState == "down")
                //        {
                //            if (isShift) keyboardString += "^";
                //            else keyboardString += "6";
                //            myclsinput.D6KeyState = "none";
                //        }
                //    }
                //    ///////////////////////////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.D7))
                //    {
                //        if (myclsinput.D7KeyState == "none") myclsinput.D7KeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.D7))
                //    {
                //        if (myclsinput.D7KeyState == "down")
                //        {
                //            if (isShift) keyboardString += "&";
                //            else keyboardString += "7";
                //            myclsinput.D7KeyState = "none";
                //        }
                //    }
                //    ///////////////////////////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.D8))
                //    {
                //        if (myclsinput.D8KeyState == "none") myclsinput.D8KeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.D8))
                //    {
                //        if (myclsinput.D8KeyState == "down")
                //        {
                //            if (isShift) keyboardString += "*";
                //            else keyboardString += "8";
                //            myclsinput.D8KeyState = "none";
                //        }
                //    }
                //    ///////////////////////////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.D9))
                //    {
                //        if (myclsinput.D9KeyState == "none") myclsinput.D9KeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.D9))
                //    {
                //        if (myclsinput.D9KeyState == "down")
                //        {
                //            if (isShift) keyboardString += "(";
                //            else keyboardString += "9";
                //            myclsinput.D9KeyState = "none";
                //        }
                //    }
                //    ///////////////////////////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.D0))
                //    {
                //        if (myclsinput.D0KeyState == "none") myclsinput.D0KeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.D0))
                //    {
                //        if (myclsinput.D0KeyState == "down")
                //        {
                //            if (isShift) keyboardString += ")";
                //            else keyboardString += "0";
                //            myclsinput.D0KeyState = "none";
                //        }
                //    }
                //    ///////////////////////////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.OemTilde))
                //    {
                //        if (myclsinput.OemTildeKeyState == "none") myclsinput.OemTildeKeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.OemTilde))
                //    {
                //        if (myclsinput.OemTildeKeyState == "down")
                //        {
                //            if (isShift) keyboardString += "~";
                //            else keyboardString += "`";
                //            myclsinput.OemTildeKeyState = "none";
                //        }
                //    }
                //    ///////////////////////////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.OemMinus))
                //    {
                //        if (myclsinput.OemMinusKeyState == "none") myclsinput.OemMinusKeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.OemMinus))
                //    {
                //        if (myclsinput.OemMinusKeyState == "down")
                //        {
                //            if (isShift) keyboardString += "_";
                //            else keyboardString += "-";
                //            myclsinput.OemMinusKeyState = "none";
                //        }
                //    }
                //    ///////////////////////////////////////////////////////////
                //    if (myKeyboardState.IsKeyDown(Keys.OemPlus))
                //    {
                //        if (myclsinput.OemPlusKeyState == "none") myclsinput.OemPlusKeyState = "down";
                //    }
                //    if (myKeyboardState.IsKeyUp(Keys.OemPlus))
                //    {
                //        if (myclsinput.OemPlusKeyState == "down")
                //        {
                //            if (isShift) keyboardString += "+";
                //            else keyboardString += "=";
                //            myclsinput.OemPlusKeyState = "none";
                //        }
                //    }

                //    ///////////////////////////////////////////////////////////
                //    ////////////////////////////////////////////////////////////
                //}



                ///////////////////////////////////////////////////////////
                if (myKeyboardState.IsKeyDown(Keys.Tab))
                {
                    if (myclsinput.TabKeyState == "none") myclsinput.TabKeyState = "down";
                }
                if (myKeyboardState.IsKeyUp(Keys.Tab))
                {
                    if (myclsinput.TabKeyState == "down")
                    {

                        CommonItem.texFocuseIndex++;
                        CommonItem.cursorPosition.Y += 58;
                        if (CommonItem.cursorPosition.Y > 100)
                        {
                            CommonItem.texFocuseIndex = 1;
                            CommonItem.cursorPosition.Y = 24;
                        }
                        keyboardString = myTexts[CommonItem.texFocuseIndex - 1].myText;


                        myclsinput.TabKeyState = "none";
                    }
                }

                //////////////////////////////////////////////////////
            }
        }


        public void OnKeyboardKeyPressNumber(KeyboardState myKeyboardState)
        {

            Keys[] mykeys = myKeyboardState.GetPressedKeys();
            bool isShift = myclsinput.isShiftPressed(mykeys);
            bool isControl = myclsinput.isControlPressed(mykeys);
            if (myKeyboardState.IsKeyDown(Keys.Back))
            {
                if (myclsinput.BackKeyState == "none") myclsinput.BackKeyState = "down";
                //if (keyboardString != "") keyboardString = keyboardString.Remove(keyboardString.Length - 1);
            }
            if (myKeyboardState.IsKeyUp(Keys.Back))
            {
                if (myclsinput.BackKeyState == "down")
                {
                    if (keyboardString != "") keyboardString = keyboardString.Remove(keyboardString.Length - 1);
                    myclsinput.BackKeyState = "none";
                }
            }
            if (keyboardString.Length <= 3)
            {
                if (myKeyboardState.IsKeyDown(Keys.D1))
                {
                    if (myclsinput.D1KeyState == "none") myclsinput.D1KeyState = "down";
                }
                if (myKeyboardState.IsKeyUp(Keys.D1))
                {
                    if (myclsinput.D1KeyState == "down")
                    {
                        if (isShift) keyboardString += "!";
                        else keyboardString += "1";
                        myclsinput.D1KeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (myKeyboardState.IsKeyDown(Keys.D2))
                {
                    if (myclsinput.D2KeyState == "none") myclsinput.D2KeyState = "down";
                }
                if (myKeyboardState.IsKeyUp(Keys.D2))
                {
                    if (myclsinput.D2KeyState == "down")
                    {
                        if (isShift) keyboardString += "@";
                        else keyboardString += "2";
                        myclsinput.D2KeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (myKeyboardState.IsKeyDown(Keys.D3))
                {
                    if (myclsinput.D3KeyState == "none") myclsinput.D3KeyState = "down";
                }
                if (myKeyboardState.IsKeyUp(Keys.D3))
                {
                    if (myclsinput.D3KeyState == "down")
                    {
                        if (isShift) keyboardString += "#";
                        else keyboardString += "3";
                        myclsinput.D3KeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (myKeyboardState.IsKeyDown(Keys.D4))
                {
                    if (myclsinput.D4KeyState == "none") myclsinput.D4KeyState = "down";
                }
                if (myKeyboardState.IsKeyUp(Keys.D4))
                {
                    if (myclsinput.D4KeyState == "down")
                    {
                        if (isShift) keyboardString += "$";
                        else keyboardString += "4";
                        myclsinput.D4KeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (myKeyboardState.IsKeyDown(Keys.D5))
                {
                    if (myclsinput.D5KeyState == "none") myclsinput.D5KeyState = "down";
                }
                if (myKeyboardState.IsKeyUp(Keys.D5))
                {
                    if (myclsinput.D5KeyState == "down")
                    {
                        if (isShift) keyboardString += "%";
                        else keyboardString += "5";
                        myclsinput.D5KeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (myKeyboardState.IsKeyDown(Keys.D6))
                {
                    if (myclsinput.D6KeyState == "none") myclsinput.D6KeyState = "down";
                }
                if (myKeyboardState.IsKeyUp(Keys.D6))
                {
                    if (myclsinput.D6KeyState == "down")
                    {
                        if (isShift) keyboardString += "^";
                        else keyboardString += "6";
                        myclsinput.D6KeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (myKeyboardState.IsKeyDown(Keys.D7))
                {
                    if (myclsinput.D7KeyState == "none") myclsinput.D7KeyState = "down";
                }
                if (myKeyboardState.IsKeyUp(Keys.D7))
                {
                    if (myclsinput.D7KeyState == "down")
                    {
                        if (isShift) keyboardString += "&";
                        else keyboardString += "7";
                        myclsinput.D7KeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (myKeyboardState.IsKeyDown(Keys.D8))
                {
                    if (myclsinput.D8KeyState == "none") myclsinput.D8KeyState = "down";
                }
                if (myKeyboardState.IsKeyUp(Keys.D8))
                {
                    if (myclsinput.D8KeyState == "down")
                    {
                        if (isShift) keyboardString += "*";
                        else keyboardString += "8";
                        myclsinput.D8KeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (myKeyboardState.IsKeyDown(Keys.D9))
                {
                    if (myclsinput.D9KeyState == "none") myclsinput.D9KeyState = "down";
                }
                if (myKeyboardState.IsKeyUp(Keys.D9))
                {
                    if (myclsinput.D9KeyState == "down")
                    {
                        if (isShift) keyboardString += "(";
                        else keyboardString += "9";
                        myclsinput.D9KeyState = "none";
                    }
                }
                ///////////////////////////////////////////////////////////
                if (myKeyboardState.IsKeyDown(Keys.D0))
                {
                    if (myclsinput.D0KeyState == "none") myclsinput.D0KeyState = "down";
                }
                if (myKeyboardState.IsKeyUp(Keys.D0))
                {
                    if (myclsinput.D0KeyState == "down")
                    {
                        if (isShift) keyboardString += ")";
                        else keyboardString += "0";
                        myclsinput.D0KeyState = "none";
                    }
                }
            }
        }
    }
    
   public class clsInput
    {
        public string AKeyState = "none";
        public string BKeyState = "none";
        public string CKeyState = "none";
        public string DKeyState = "none";
        public string EKeyState = "none";
        public string FKeyState = "none";
        public string GKeyState = "none";
        public string HKeyState = "none";
        public string IKeyState = "none";
        public string JKeyState = "none";
        public string KKeyState = "none";
        public string LKeyState = "none";
        public string MKeyState = "none";
        public string NKeyState = "none";
        public string OKeyState = "none";
        public string PKeyState = "none";
        public string QKeyState = "none";
        public string RKeyState = "none";
        public string SKeyState = "none";
        public string TKeyState = "none";
        public string UKeyState = "none";
        public string VKeyState = "none";
        public string WKeyState = "none";
        public string XKeyState = "none";
        public string YKeyState = "none";
        public string ZKeyState = "none";
        public string SpaceKeyState = "none";
        public string BackKeyState = "none";
        /// //////////////////////////////////////////////
        public string OemSemicolonKeyState = "none";
        public string OemQuotesKeyState = "none";
        public string OemCommaKeyState = "none";
        public string OemPeriodKeyState = "none";
        public string OemQuestionKeyState = "none";
        /////////////////////////////////////////////////
        public string OemOpenBracketsKeyState = "none";
        public string OemCloseBracketsKeyState = "none";
        public string OemPipeKeyState = "none";
        //////////////////////////////////////////////////
        public string D1KeyState = "none";
        public string D2KeyState = "none";
        public string D3KeyState = "none";
        public string D4KeyState = "none";
        public string D5KeyState = "none";
        public string D6KeyState = "none";
        public string D7KeyState = "none";
        public string D8KeyState = "none";
        public string D9KeyState = "none";
        public string D0KeyState = "none";
        //////////////////////////////////////////////////
        public string OemTildeKeyState = "none";
        public string OemMinusKeyState = "none";
        public string OemPlusKeyState = "none";
        public string TabKeyState = "none";
        /// ////////////////////////////////////////////////
        public bool isShiftPressed(Keys[] mykeys)
        {
            bool result = false;
            foreach (Keys key in mykeys)
            {
                if (key == Keys.LeftShift || key == Keys.RightShift)
                {
                    result = true;
                }
            }
            return result;
        }
        public bool isControlPressed(Keys[] mykeys)
        {
            bool result = false;
            foreach (Keys key in mykeys)
            {
                if (key == Keys.LeftControl || key == Keys.RightControl)
                {
                    result = true;
                }
            }
            return result;
        }
    }
   //public struct Text
    public class Text
   {
       public int key;
       public string myText;
       public int FontSize;
       public Rectangle rect;
       public Color mycolor;
       public string strplaceOfUse;
       public bool ShouldItBeShownInThisScreen;
       public string wrappedString;
       public int HorizontalMargin;
       public string Action;
       public bool isFocused;
   }
   public struct mylist
   {
       public string mystring;
       public int key;
   }

}
