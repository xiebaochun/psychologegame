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
    public class Cache
    {
        static ContentManager content;
        static Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();
        static Dictionary<string, Texture2D> fontTextures = new Dictionary<string, Texture2D>();
        static Dictionary<string, SoundEffect> sounds = new Dictionary<string, SoundEffect>();
       public static Dictionary<string, Video> videos = new Dictionary<string,Video>();

        public static void Initialize(ContentManager c)
        {
            content = c;
        }

        public static Texture2D Texture(string file)
        {
            if (!textures.ContainsKey(file))
            {
                try
                {
                    textures.Add(file, content.Load<Texture2D>(@"GameContent/Images/" + file));
                }
                catch
                {
                    throw new Exception("加载图像文件失败：" + file);
                }
            }
            return textures[file];
        }

        public static Texture2D FontTexture(string fontIndex, int imageIndex)
        {
            string file = fontIndex + "/" + imageIndex;
            if (!fontTextures.ContainsKey(file))
            {
                try
                {
                    fontTextures.Add(file, content.Load<Texture2D>(@"GameContent/Fonts/" + file));
                }
                catch
                {
                    throw new Exception("加载字体文件失败：" + file);
                }

            }
            return fontTextures[file];
        }

        public static SoundEffect BGM(string file)
        {
            if (!sounds.ContainsKey("BGM/" + file))
            {
                try
                {
                    SoundEffect bgm = content.Load<SoundEffect>(@"GameContent/Sounds/BGM/" + file);
                    sounds.Add("BGM/" + file, bgm);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return sounds["BGM/" + file];
        }

        public static SoundEffect SE(string file)
        {
            if (!sounds.ContainsKey("SE/" + file))
            {
                try
                {
                    sounds.Add("SE/" + file, content.Load<SoundEffect>(@"GameContent/Sounds/SE/" + file));
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
            return sounds["SE/" + file];
        }

        public static Video VD(string File)
        {
            if(!videos.ContainsKey("WMV/"+File))
            {
                try
                {
                   Video vd=content.Load<Video>(@"GameContent/Videos/WMV/"+File);
                    videos.Add("WMV/"+File,vd);
                }
                catch(Exception e)
                {
                    throw e;
                }
            }
            return videos["WMV/" + File];
        }
    }
}
