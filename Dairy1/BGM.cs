using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.IO;
namespace Dairy1
{
    public class BGM
    {
        Thread thread;
        public ReadManager rm;
        SoundPlayer player = new SoundPlayer();
        private int num = 0, list = 0;
        List<string>[] songlist = new List<string>[13];
        private bool PlayOnce = false;
        public BGM() { }
        public void init()
        {
            songlist[0] = new List<string>();
            songlist[1] = new List<string>();
            songlist[2] = new List<string>();
            songlist[3] = new List<string>();
            songlist[4] = new List<string>();
            songlist[5] = new List<string>();
            songlist[6] = new List<string>();
            songlist[7] = new List<string>();
            songlist[8] = new List<string>();
            songlist[9] = new List<string>();
            songlist[10] = new List<string>();
            songlist[11] = new List<string>();
            songlist[12] = new List<string>();

            songlist[0].Add("music/Chiru(Saisei no Uta).wav");
            if (rm.Query(209)) songlist[0].Add("music/抗敌歌伴奏.wav");
            songlist[0].Add("music/Senpai - Tomorrow With You.wav");
            if(rm.Query(48)) songlist[0].Add("music/HJGEEK - 卷珠帘 钢琴版.wav");
            songlist[0].Add("music/Uyama Hiroto - Stratus.wav");
            if(rm.Query(213)) songlist[0].Add("music/祈航.wav");
            songlist[0].Add("music/みかん箱 - 云流れ.wav");
            songlist[0].Add("music/秋～華恋～.wav");
            songlist[1].Add("music/HJGEEK - 卷珠帘 钢琴版.wav");
            songlist[2].Add("music/抗敌歌伴奏.wav");
            songlist[3].Add("music/祈航.wav");

            songlist[4].Add("music/Uyama Hiroto - Stratus.wav");
            songlist[5].Add("music/Chiru(Saisei no Uta).wav");
            songlist[6].Add("music/Senpai - Tomorrow With You.wav");
            songlist[7].Add("music/みかん箱 - 云流れ.wav");
            songlist[8].Add("music/秋～華恋～.wav");
            Random rd = new Random();
            num = rd.Next(0, songlist[0].Count());
            play();
        }
        public void play()
        {
            thread = new Thread(new ThreadStart(Threadmothod));
            thread.Start();
            thread.IsBackground = true;
        }
        public void stop()
        {
            player.Stop();
            thread.Abort();
        }
        public void Threadmothod()
        {
            playnew(songlist[list][num]);
            if (PlayOnce) thread.Abort();
            num++;
            if (num == songlist[list].Count) num = 0;
            Threadmothod();
        }
        public void AutoChange(int index)
        {
            PlayOnce = false;
            int next = list;
            switch (index)
            {
                case 48:
                    next = 1;
                    break;
                case 209:
                    next = 2;
                    break;
                case 213:
                    next = 3;
                    break;
                default:
                    next = 0;
                    break;
            }
            if (next != list)
            {
                thread.Abort();
                list = next;
                num = 0;
                thread = new Thread(new ThreadStart(Threadmothod));
                thread.IsBackground = true;
                thread.Start();
            }
        }
        public void changeBGM(int _list)
        {
            PlayOnce = true;
               thread.Abort();
            list = _list;
            num = 0;
            thread = new Thread(new ThreadStart(Threadmothod));
            thread.IsBackground = true;
            thread.Start();
        }

        public int gettime(string path)
        {
            FileStream data = new FileStream(path, FileMode.Open);
            long cdx = data.Length;
            byte[] tmp4 = new byte[4];
            byte[] rubbish = new byte[100];
            data.Read(rubbish, 0, 28);
            data.Read(tmp4, 0, 4);
            uint rate = BitConverter.ToUInt32(tmp4, 0);
            //System.Windows.Forms.MessageBox.Show(cdx.ToString() + "/" + rate.ToString() + "=" + (cdx / rate).ToString());
            return (int)(cdx * 1000 / rate);
        }
        public void playnew(string path)
        {
            int timer = gettime(path);
            player.SoundLocation = path;
            player.Load();
            if (player.IsLoadCompleted) player.Play();
            Delay(timer);
        }
        public static void Delay(int milliSecond)
        {
            int start = Environment.TickCount;
            while (Math.Abs(Environment.TickCount - start) < milliSecond)
            {
                System.Windows.Forms.Application.DoEvents();
            }
        }
    }
}
