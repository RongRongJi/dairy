using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Dairy1
{
    public partial class Form1 : Form
    {
        public ReadManager rm = new ReadManager();
        private TurnPage tp = new TurnPage();
        public MR_Text.TextArea tm = new MR_Text.TextArea();
        public FileManager fm = new FileManager();
        public Calender cd = new Calender();
        public SeconeBook photo = new SeconeBook();
        private int Delayms = 300;
        public BGM bgm = new BGM();
        public Form f;
        
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer, true);
            f = this;
        }
        
        //窗口初始化
        private void Form1_Load(object sender, EventArgs e)
        {
            String[] s = fm.GetFileNames(Application.StartupPath + "\\text");
            fm.HandleInformation(s);

            tp.backpanel = backpanel;
            tp.backpanellast = backpanellast;
            tp.forepanel = forepanel;
            //后景层设置
            //1.设定背景
            backpanel.BackgroundImageLayout = ImageLayout.Stretch;
            backpanel.BackgroundImage = Properties.Resources.bg1;
            backpanellast.BackgroundImageLayout = ImageLayout.Stretch;
            backpanellast.BackgroundImage = Properties.Resources.bg1;
            
            //5.把文字层drawtobitmap
            Bitmap bm = new Bitmap(backpanel.Width, backpanel.Height);
            Rectangle rec = new Rectangle(0, 0, backpanel.Width, backpanel.Height);
            backpanel.DrawToBitmap(bm, rec);//耗时
            backpanel.BackgroundImage = bm;
            tm.Visible = false;

            //前景层设置
            forepanel.BackgroundImageLayout = ImageLayout.Stretch;
            forepanel.BackgroundImage = Properties.Resources.frontbg;

            //加入窗体
            Controls.Add(forepanel);
            forepanel.Controls.Add(startbutton);
            forepanel.Controls.Add(exitbutton);
            forepanel.Controls.Add(openCalendar);
            forepanel.Controls.Add(others);
            forepanel.Controls.Add(nextpage);
            forepanel.Controls.Add(lastpage);
            forepanel.Controls.Add(locate_for_cale);
            forepanel.Controls.Add(nextcale);
            forepanel.Controls.Add(lastcale);
            forepanel.Controls.Add(menupanel);
            forepanel.Controls.Add(findMark);
            menupanel.Visible = false;
            nextpage.Visible = false;
            lastpage.Visible = false;
            locate_for_cale.Visible = false;
            nextcale.Visible = false;
            lastcale.Visible = false;

            //ForMenuPanel
            menupanel.BackgroundImage = Properties.Resources.menu_panel;
            menupanel.Controls.Add(addmark);
            menupanel.Controls.Add(loadmark);
            menupanel.Controls.Add(calendar);
            menupanel.Controls.Add(title);
            menupanel.Controls.Add(exit2);
            menupanel.Controls.Add(photo.menuablum);
            menupanel.Controls.Add(photo.menumusic);
            menupanel.Controls.Add(photo.title);
            menupanel.Controls.Add(photo.exit2);
            photo.menumusic.Visible = false;
            photo.menuablum.Visible = false;
            photo.title.Visible = false;
            photo.exit2.Visible = false;

            //ForMarkPanel
            markpanel.BackgroundImageLayout = ImageLayout.Stretch;
            markpanel.BackgroundImage = Properties.Resources.bm_bg;
            markpanel.Controls.Add(mark1s);
            markpanel.Controls.Add(mark2s);
            markpanel.Controls.Add(mark3s);
            markpanel.Controls.Add(mark1l);
            markpanel.Controls.Add(mark2l);
            markpanel.Controls.Add(mark3l);
            markpanel.Controls.Add(marklbl);
            marklbl.BringToFront();
            markpanel.BackColor = Color.FromArgb(20, Color.Black);

            //markstate
            if (fm.BookMark(1, 2)>-1)
            {
                markstate |= 1;
                mark1s.BackgroundImage = Properties.Resources.bm_1y;
                mark1l.BackgroundImage = Properties.Resources.bm_1y;
            }
            else
            {
                markstate &= 6;
                mark1s.BackgroundImage = Properties.Resources.bm_1n;
                mark1l.BackgroundImage = Properties.Resources.bm_1n;
            }
            if (fm.BookMark(2, 2)>-1)
            {
                markstate |= 2;
                mark2s.BackgroundImage = Properties.Resources.bm_2y;
                mark2l.BackgroundImage = Properties.Resources.bm_2y;
            }
            else
            {
                markstate &= 5;
                mark2s.BackgroundImage = Properties.Resources.bm_2n;
                mark2l.BackgroundImage = Properties.Resources.bm_2n;
            }
            if (fm.BookMark(3, 2)>-1)
            {
                markstate |= 4;
                mark3s.BackgroundImage = Properties.Resources.bm_3y;
                mark3l.BackgroundImage = Properties.Resources.bm_3y;
            }
            else
            {
                markstate &= 3;
                mark3s.BackgroundImage = Properties.Resources.bm_3n;
                mark3l.BackgroundImage = Properties.Resources.bm_3n;
            }

            photo.album.rm = rm;
            photo.rm = rm;
            bgm.rm = rm;
            bgm.init();
            photo.bgm = bgm;
        }

        private void menutofirst()
        {
            photo.menumusic.Visible = false;
            photo.menuablum.Visible = false;
            photo.title.Visible = false;
            photo.exit2.Visible = false;
            addmark.Visible = true;
            loadmark.Visible = true;
            calendar.Visible = true;
            title.Visible = true;
            exit2.Visible = true;
        }
        private void menutosecond()
        {
            photo.menumusic.Visible = true;
            photo.menuablum.Visible = true;
            photo.title.Visible = true;
            photo.exit2.Visible = true;
            addmark.Visible = false;
            loadmark.Visible = false;
            calendar.Visible = false;
            title.Visible = false;
            exit2.Visible = false;
        }
        
        private void menubutton_MouseLeave(object sender, EventArgs e)
        {
            Point msp = this.PointToClient(Control.MousePosition);
            int x = msp.X, y = msp.Y;
            if (!((x < 943 || x > 1118) || (y < 315 || y > 628))) return;
            if (menupanel.Location.X < 1073)
            {
                time2.Enabled = true;
                time2.Start();
                if (time1.Enabled) time2.Stop();
            }
        }
        private void menubutton_MouseEnter(object sender, EventArgs e)
        {
            if (menupanel.Location.X>943)
            {
                menupanel.BringToFront();
                time1.Enabled = true;
                time1.Start();
                if (time2.Enabled) time1.Stop();
            }
        }
        private void Time_Tick(object sender, EventArgs e)
        {
            menupanel.Visible = false;
            menupanel.Location = new Point(menupanel.Location.X - 30, menupanel.Location.Y);
            menupanel.Visible = true;
            if (menupanel.Location.X <= 943)
            {
                menupanel.Location = new Point(942, menupanel.Location.Y - 1);
                time1.Stop();
            }
        }
        private void Time_Tick2(object sender, EventArgs e)
        {
            menupanel.Visible = false;
            menupanel.Location = new Point(menupanel.Location.X + 30, menupanel.Location.Y);
            menupanel.Visible = true;
            if (menupanel.Location.X >= 1073)
            {
                menupanel.Location = new Point(1093, menupanel.Location.Y + 1);
                time2.Stop();
            }
        }


        private void addmark_MouseLeave(object sender, EventArgs e)
        {
            addmark.BackgroundImage = Properties.Resources.menu_button1_s;
        }
        private void addmark_MouseEnter(object sender, EventArgs e)
        {
            addmark.BackgroundImage = Properties.Resources.menu_button1_f;
        }
        private void loadmark_MouseLeave(object sender, EventArgs e)
        {
            loadmark.BackgroundImage = Properties.Resources.menu_button2_s;
        }
        private void loadmark_MouseEnter(object sender, EventArgs e)
        {
            loadmark.BackgroundImage = Properties.Resources.menu_button2_f;
        }
        private void calendar_MouseLeave(object sender, EventArgs e)
        {
            calendar.BackgroundImage = Properties.Resources.menu_button3_s;
        }
        private void calendar_MouseEnter(object sender, EventArgs e)
        {
            calendar.BackgroundImage = Properties.Resources.menu_button3_f;
        }
        private void title_MouseLeave(object sender, EventArgs e)
        {
            title.BackgroundImage = Properties.Resources.menu_button4_s;
        }
        private void title_MouseEnter(object sender, EventArgs e)
        {
            title.BackgroundImage = Properties.Resources.menu_button4_f;
        }
        private void exit2_MouseLeave(object sender, EventArgs e)
        {
            exit2.BackgroundImage = Properties.Resources.menu_button5_s;
        }
        private void exit2_MouseEnter(object sender, EventArgs e)
        {
            exit2.BackgroundImage = Properties.Resources.menu_button5_f;
        }

        private void startbutton_MouseLeave(object sender, EventArgs e)
        {
            startbutton.BackgroundImage = Properties.Resources.tb_diary1;
        }
        private void startbutton_MouseEnter(object sender, EventArgs e)
        {
            startbutton.BackgroundImage = Properties.Resources.tb_diary2;
        }
        private void title_Click(object sender, EventArgs e)
        {
            fm.JumpTo(-1);
            backpanellast.BackgroundImage = Properties.Resources.frontbg;
            //forepanel.Controls.Remove(menupanel);
            menupanel.Location = new System.Drawing.Point(1093, 315);
            HideBotton();
            tp.timelast.Enabled = true;
            tp.timelast.Start();
            Delay(Delayms);
            ChangeBotton();
            //forepanel.Controls.Add(menupanel);
            menupanel.BringToFront();
        }

        private void startbutton_Click(object sender, EventArgs e)
        {
            menutofirst();
            backpanel.BackgroundImage = Properties.Resources.bg1;
            fm.TurnNextDiary();
            rm.Updata(fm.GetPage);
            String nextDiary = fm.GetDiaryName();
            tm.Dispose();
            tm = new MR_Text.TextArea();
            tm.GetFile(Application.StartupPath + "\\text\\" + nextDiary, nextDiary);
            tm.shiftPage(1);
            tm.Visible = true;
            //1.将文字显示层添加到后景层上
            backpanel.Controls.Add(tm);

            //2.把文字层drawtobitmap
            Bitmap bm = new Bitmap(backpanel.Width, backpanel.Height);
            Rectangle rec = new Rectangle(0, 0, backpanel.Width, backpanel.Height);
            backpanel.DrawToBitmap(bm, rec);//耗时
            backpanel.BackgroundImage = bm;
            tm.Visible = false;

            //3.调用turnpage
            HideBotton();
            tp.time.Enabled = true;
            tp.time.Start();
            Delay(Delayms);
            ChangeBotton();
            bgm.AutoChange(fm.GetPage);
            forepanel.BackgroundImage = bm;
        }



        private void exitbutton_MouseLeave(object sender, EventArgs e)
        {
            exitbutton.BackgroundImage = Properties.Resources.tb_exit1;
        }
        private void exitbutton_MouseEnter(object sender, EventArgs e)
        {
            exitbutton.BackgroundImage = Properties.Resources.tb_exit2;
        }

        private void exitbutton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void openCalendar_MouseLeave(object sender, EventArgs e)
        {
            openCalendar.BackgroundImage = Properties.Resources.tb_calendar1;
        }
        private void openCalendar_MouseEnter(object sender, EventArgs e)
        {
            openCalendar.BackgroundImage = Properties.Resources.tb_calendar2;
        }

        private void openCalendar_Click(object sender, EventArgs e)
        {
            menutofirst();
            backpanel.BackgroundImage = cd.GetBitmap();
            HideBotton();
            tp.time.Enabled = true;
            tp.time.Start();
            Delay(Delayms);
            locate_for_cale.Visible = true;
            menupanel.Visible = true;
            if (cd.Year != 2016) nextcale.Visible = true;
            if (cd.Year != 2013) lastcale.Visible = true;
        }

        private void others_MouseLeave(object sender, EventArgs e)
        {
            others.BackgroundImage = Properties.Resources.tb_extra;
        }
        private void others_MouseEnter(object sender, EventArgs e)
        {
            others.BackgroundImage = Properties.Resources.tb_extra2;
        }

        private void others_Click(object sender, EventArgs e)
        {
            menutosecond();
            //menupanel.Visible = true;
            
            photo.ChangeToSecondBook(forepanel);
            menupanel.BringToFront();
        }

        private void findmark_MouseLeave(object sender, EventArgs e)
        {
            findMark.BackgroundImage = Properties.Resources.tb_bookmark1;
        }
        private void findmark_MouseEnter(object sender, EventArgs e)
        {
            findMark.BackgroundImage = Properties.Resources.tb_bookmark2;
        }

        private void findmark_Click(object sender, EventArgs e)
        {
            menutofirst();
            menupanel.Visible = true;
            loadmark_Click(sender, e);
        }

        private void nextpage_MouseLeave(object sender, EventArgs e)
        {
            nextpage.BackgroundImage = Properties.Resources.next1;
        }
        private void nextpage_MouseEnter(object sender, EventArgs e)
        {
            nextpage.BackgroundImage = Properties.Resources.next2;
        }

        private void lastpage_MouseLeave(object sender, EventArgs e)
        {
            lastpage.BackgroundImage = Properties.Resources.last1;
        }
        private void lastpage_MouseEnter(object sender, EventArgs e)
        {
            lastpage.BackgroundImage = Properties.Resources.last2;
        }

        private void nextpage_Click(object sender, EventArgs e)
        {
            if (tm.CurrentPage == tm.PageNumber && fm.IsLastDiary())//封底
            {
                backpanel.BackgroundImage = Properties.Resources.backbg;
                fm.TurnNextDiary();

                //3.调用turnpage
                HideBotton();
                tp.time.Enabled = true;
                tp.time.Start();
                Delay(Delayms);
                ChangeBotton();
                nextpage.Visible = false;
                forepanel.BackgroundImage = Properties.Resources.backbg;
            }
            else
            {
                int isUnlockPhoto = 0, isUnlockMusic = 0;
                backpanel.BackgroundImage = Properties.Resources.bg1;
                //2.切换页面函数
                if (tm.CurrentPage == tm.PageNumber)
                {
                    fm.TurnNextDiary();
                    int lastphotos = photo.album.UnlockCount();
                    int lastmusics = photo.MusicCount();
                    rm.Updata(fm.GetPage);
                    String nextDiary = fm.GetDiaryName();
                    tm.Dispose();
                    tm = new MR_Text.TextArea();
                    tm.GetFile(Application.StartupPath + "\\text\\" + nextDiary, nextDiary);
                    tm.shiftPage(1);
                    isUnlockPhoto = photo.album.UnlockCount()-lastphotos;
                    isUnlockMusic = photo.MusicCount() - lastmusics;
                }
                else
                    tm.shiftPage(tm.CurrentPage + 1);
                tm.Visible = true;
                //1.将文字显示层添加到后景层上
                backpanel.Controls.Add(tm);

                //5.把文字层drawtobitmap
                Bitmap bm = new Bitmap(backpanel.Width, backpanel.Height);
                Rectangle rec = new Rectangle(0, 0, backpanel.Width, backpanel.Height);
                backpanel.DrawToBitmap(bm, rec);//耗时
                backpanel.BackgroundImage = bm;
                tm.Visible = false;
                //4.
                //开启翻页计时器
                HideBotton();
                tp.time.Enabled = true;
                tp.time.Start();
                Delay(Delayms);
                ChangeBotton();
                bgm.AutoChange(fm.GetPage);
                forepanel.BackgroundImage = bm;
                if (isUnlockPhoto >= 1 || isUnlockMusic >= 1)
                {
                    LoadingPanel lp = LoadingPanel.GetLoadPage();
                    lp.setLoadPage = 0;
                    f.Controls.Add(lp);
                    lp.BringToFront();
                    if (isUnlockMusic >= 1)
                    {
                        if (isUnlockPhoto >= 1)
                        {
                            lp.setLoadPage = 2;
                        }
                        else
                        {
                            lp.setLoadPage = 1;
                        }
                    }
                }
            }
        }

        private void lastpage_Click(object sender, EventArgs e)
        {
            int isUnlockPhoto = 0, isUnlockMusic = 0;
            if (fm.IsFirstDiary() && tm.CurrentPage == 1) //返回title
            {
                fm.TurnLastDiary();
                backpanellast.BackgroundImage = Properties.Resources.frontbg;
            }
            else//不返回title
            {
                backpanellast.BackgroundImage = Properties.Resources.bg1;
                //2.切换页面函数
                if (tm.CurrentPage == 1)                    //LastText
                {
                    fm.TurnLastDiary();
                    int lastphotos = photo.album.UnlockCount();
                    int lastmusics = photo.MusicCount();
                    rm.Updata(fm.GetPage);
                    String lastDiary = fm.GetDiaryName();
                    tm.Dispose();
                    tm = new MR_Text.TextArea();
                    tm.GetFile(Application.StartupPath + "\\text\\" + lastDiary, lastDiary);
                    tm.shiftPage(tm.PageNumber);
                    isUnlockPhoto = photo.album.UnlockCount() - lastphotos;
                    isUnlockMusic = photo.MusicCount() - lastmusics;
                }
                else
                    tm.shiftPage(tm.CurrentPage - 1);       //LastPage
                tm.Visible = true;
                //1.将文字显示层添加到后景层上
                backpanellast.Controls.Add(tm);
                //2.把文字层drawtobitmap
                Bitmap bm = new Bitmap(backpanel.Width, backpanel.Height);
                Rectangle rec = new Rectangle(0, 0, backpanel.Width, backpanel.Height);
                backpanellast.DrawToBitmap(bm, rec);//耗时
                backpanellast.BackgroundImage = bm;
                tm.Visible = false;
            }

            //3.
            //开启翻页计时器
            HideBotton();
            tp.timelast.Enabled = true;
            tp.timelast.Start();
            Delay(Delayms);
            ChangeBotton();
            bgm.AutoChange(fm.GetPage);
            if (isUnlockPhoto >= 1 || isUnlockMusic >= 1)
            {
                LoadingPanel lp = LoadingPanel.GetLoadPage();
                lp.setLoadPage = 0;
                f.Controls.Add(lp);
                lp.BringToFront();
                if (isUnlockMusic >= 1)
                {
                    if (isUnlockPhoto >= 1)
                    {
                        lp.setLoadPage = 2;
                    }
                    else
                    {
                        lp.setLoadPage = 1;
                    }
                }
            }
        }

        //BookMark
        private void addmark_Click(object sender, EventArgs e)
        {
            forepanel.Controls.Remove(menupanel);
            HideMark(0);
            forepanel.Controls.Add(markpanel);
            marklbl.BringToFront();
            Bitmap bm = new Bitmap(forepanel.BackgroundImage);
            forepanel.BackgroundImage = bm;
            HideBotton();
        }
        private void loadmark_Click(object sender, EventArgs e)
        {
            forepanel.Controls.Remove(menupanel);
            HideMark(1);
            forepanel.Controls.Add(markpanel);
            Bitmap bm = new Bitmap(forepanel.BackgroundImage);
            forepanel.BackgroundImage = bm;
            HideBotton();
        }
        //bookmark
        private void mark1s_MouseLeave(object sender, EventArgs e)
        {
            if ((markstate & 1)>0) mark1s.BackgroundImage = Properties.Resources.bm_1y;
            else mark1s.BackgroundImage = Properties.Resources.bm_1n;
            settext();
        }
        private void mark1s_MouseEnter(object sender, EventArgs e)
        {
            
            if ((markstate & 1) > 0)
            {
                mark1s.BackgroundImage = Properties.Resources.bm_1yf;
                settext(fm.BookMark(1, 2, 0), fm.BookMark(1, 2, 1));
            }
            else mark1s.BackgroundImage = Properties.Resources.bm_1nf;
        }
        private void mark1s_Click(object sender, EventArgs e)
        {

            if (fm.IsTitle() || fm.IsBack()) return;
            markstate |= 1;
            mark1s.BackgroundImage = Properties.Resources.bm_1yf;
            fm.BookMark(1, 0, tm.PageNumber);
            settext(fm.GetDiaryDate(), tm.PageNumber);
        }
        private void mark2s_MouseLeave(object sender, EventArgs e)
        {
            if ((markstate & 2) > 0) mark2s.BackgroundImage = Properties.Resources.bm_2y;
            else mark2s.BackgroundImage = Properties.Resources.bm_2n;
            settext();
        }
        private void mark2s_MouseEnter(object sender, EventArgs e)
        {
            if ((markstate & 2) > 0)
            {
                mark2s.BackgroundImage = Properties.Resources.bm_2yf;
                settext(fm.BookMark(2, 2, 0), fm.BookMark(2, 2, 1));
            }
            else mark2s.BackgroundImage = Properties.Resources.bm_2nf;
        }
        private void mark2s_Click(object sender, EventArgs e)
        {

            if (fm.IsTitle() || fm.IsBack()) return;
            markstate |= 2;
            mark2s.BackgroundImage = Properties.Resources.bm_2yf;
            fm.BookMark(2, 0, tm.PageNumber);
            settext(fm.GetDiaryDate(), tm.PageNumber);
        }
        private void mark3s_MouseLeave(object sender, EventArgs e)
        {
            if ((markstate & 4) > 0) mark3s.BackgroundImage = Properties.Resources.bm_3y;
            else mark3s.BackgroundImage = Properties.Resources.bm_3n;
            settext();
        }
        private void mark3s_MouseEnter(object sender, EventArgs e)
        {
            if ((markstate & 4) > 0)
            {
                mark3s.BackgroundImage = Properties.Resources.bm_3yf;
                settext(fm.BookMark(3, 2, 0), fm.BookMark(3, 2, 1));
            }
            else mark3s.BackgroundImage = Properties.Resources.bm_3nf;
        }
        private void mark3s_Click(object sender, EventArgs e)
        {
            if (fm.IsTitle() || fm.IsBack()) return;
            markstate |= 4;
            mark3s.BackgroundImage = Properties.Resources.bm_3yf;
            fm.BookMark(3,0,tm.PageNumber);
            settext(fm.GetDiaryDate(), tm.PageNumber);
        }

        private void mark1l_MouseLeave(object sender, EventArgs e)
        {
            if ((markstate & 1) > 0) mark1l.BackgroundImage = Properties.Resources.bm_1y;
            else mark1l.BackgroundImage = Properties.Resources.bm_1n;
            settext();
        }
        private void mark1l_MouseEnter(object sender, EventArgs e)
        {
            if ((markstate & 1) > 0)
            {
                mark1l.BackgroundImage = Properties.Resources.bm_1yf;
                settext(fm.BookMark(1, 2, 0), fm.BookMark(1, 2, 1));
            }
            else mark1l.BackgroundImage = Properties.Resources.bm_1nf;
        }
        private void mark1l_Click(object sender, EventArgs e)
        {
            if ((markstate & 1) == 0) return;
            forepanel.Controls.Remove(markpanel);
            menupanel.Location = new Point(1063, menupanel.Location.Y);
            forepanel.Controls.Add(menupanel);
            int lastPG = fm.GetPage;
            fm.BookMark(1, 1);
            if (fm.IsTitle()) return;

            String Diary = fm.GetDiaryName();
            tm.Dispose();
            tm = new MR_Text.TextArea();
            tm.GetFile(Application.StartupPath + "\\text\\" + Diary, Diary);
            tm.shiftPage(fm.BookMark(1, 2, 1));
            tm.Visible = true;
            backpanel.BackgroundImage = backpanel.BackgroundImage = Properties.Resources.bg1;
            backpanel.Controls.Add(tm);
            Bitmap bm = new Bitmap(backpanel.Width, backpanel.Height);
            Rectangle rec = new Rectangle(0, 0, backpanel.Width, backpanel.Height);
            backpanel.DrawToBitmap(bm, rec);
            tm.Visible = false;
            HideBotton();
            if (lastPG>fm.GetPage)
            {
                backpanellast.BackgroundImage = bm;
                tp.timelast.Enabled = true;
                tp.timelast.Start();
            }
            else
            {
                backpanel.BackgroundImage = bm;
                tp.time.Enabled = true;
                tp.time.Start();
            }
            Delay(Delayms);
            ChangeBotton();
            bgm.AutoChange(fm.GetPage);
        }
        private void mark2l_MouseLeave(object sender, EventArgs e)
        {
            if ((markstate & 2) > 0) mark2l.BackgroundImage = Properties.Resources.bm_2y;
            else mark2l.BackgroundImage = Properties.Resources.bm_2n;
            settext();
        }
        private void mark2l_MouseEnter(object sender, EventArgs e)
        {
            if ((markstate & 2) > 0)
            {
                mark2l.BackgroundImage = Properties.Resources.bm_2yf;
                settext(fm.BookMark(2, 2, 0), fm.BookMark(2, 2, 1));
            }
            else mark2l.BackgroundImage = Properties.Resources.bm_2nf;
        }
        private void mark2l_Click(object sender, EventArgs e)
        {
            if ((markstate & 2) == 0) return;
            forepanel.Controls.Remove(markpanel);
            menupanel.Location = new Point(1063, menupanel.Location.Y);
            forepanel.Controls.Add(menupanel);
            int lastPG = fm.GetPage;
            fm.BookMark(2, 1);
            if (fm.IsTitle()) return;
            String Diary = fm.GetDiaryName();
            backpanel.BackgroundImage = backpanel.BackgroundImage = Properties.Resources.bg1;
            tm.Dispose();
            tm = new MR_Text.TextArea();
            tm.GetFile(Application.StartupPath + "\\text\\" + Diary, Diary);
            tm.shiftPage(fm.BookMark(2, 2, 1));
            tm.Visible = true;
            backpanel.Controls.Add(tm);
            Bitmap bm = new Bitmap(backpanel.Width, backpanel.Height);
            Rectangle rec = new Rectangle(0, 0, backpanel.Width, backpanel.Height);
            backpanel.DrawToBitmap(bm, rec);
            tm.Visible = false;
            HideBotton();
            if (lastPG > fm.GetPage)
            {
                backpanellast.BackgroundImage = bm;
                tp.timelast.Enabled = true;
                tp.timelast.Start();
            }
            else
            {
                backpanel.BackgroundImage = bm;
                tp.time.Enabled = true;
                tp.time.Start();
            }
            Delay(Delayms);
            ChangeBotton();
            bgm.AutoChange(fm.GetPage);
        }
        private void mark3l_MouseLeave(object sender, EventArgs e)
        {
            if ((markstate & 4) > 0) mark3l.BackgroundImage = Properties.Resources.bm_3y;
            else mark3l.BackgroundImage = Properties.Resources.bm_3n;
            settext();
        }
        private void mark3l_MouseEnter(object sender, EventArgs e)
        {
            if ((markstate & 4) == 0) return;
            if ((markstate & 4) > 0)
            {
                mark3l.BackgroundImage = Properties.Resources.bm_3yf;
                settext(fm.BookMark(3, 2, 0), fm.BookMark(3, 2, 1));
            }
            else mark3l.BackgroundImage = Properties.Resources.bm_3nf;
        }
        private void mark3l_Click(object sender, EventArgs e)
        {
            forepanel.Controls.Remove(markpanel);
            menupanel.Location = new Point(1063, menupanel.Location.Y);
            forepanel.Controls.Add(menupanel);
            int lastPG = fm.GetPage;
            fm.BookMark(3, 1);
            if (fm.IsTitle()) return;
            String Diary = fm.GetDiaryName();
            backpanel.BackgroundImage= backpanel.BackgroundImage = Properties.Resources.bg1;
            tm.Dispose();
            tm = new MR_Text.TextArea();
            tm.GetFile(Application.StartupPath + "\\text\\" + Diary, Diary);
            tm.shiftPage(fm.BookMark(3,2,1));
            tm.Visible = true;
            backpanel.Controls.Add(tm);
            Bitmap bm = new Bitmap(backpanel.Width, backpanel.Height);
            Rectangle rec = new Rectangle(0, 0, backpanel.Width, backpanel.Height);
            backpanel.DrawToBitmap(bm, rec);
            tm.Visible = false;
            HideBotton();
            if (lastPG > fm.GetPage)
            {
                backpanellast.BackgroundImage = bm;
                tp.timelast.Enabled = true;
                tp.timelast.Start();
            }
            else
            {
                backpanel.BackgroundImage = bm;
                tp.time.Enabled = true;
                tp.time.Start();
            }
            Delay(Delayms);
            ChangeBotton();
            menupanel.Visible = true;
            bgm.AutoChange(fm.GetPage);
        }
        private void exitmark_Click(object sender, EventArgs e)
        {
            forepanel.Controls.Remove(markpanel);
            menupanel.Location = new Point(1093, menupanel.Location.Y);
            forepanel.Controls.Add(menupanel);
            ChangeBotton();
            menupanel.BringToFront();
        }
        private void settext(int date = 0, int num = 0)
        {
            if (date == 0) marklbl.Visible = false;
            else marklbl.Visible = true;
            int y = date / 10000 + 2000, m = date % 10000 / 100, d = date % 100;
            marklbl.Text = y.ToString()+"年"+m.ToString()+"月"+d.ToString()+"日 第"+num.ToString()+"页";
        }

        //calendar
        private void nextcale_MouseLeave(object sender, EventArgs e)
        {
            nextcale.BackgroundImage = Properties.Resources.next1;
        }
        private void nextcale_MouseEnter(object sender, EventArgs e)
        {
            nextcale.BackgroundImage = Properties.Resources.next2;
        }
        private void lastcale_MouseLeave(object sender, EventArgs e)
        {
            lastcale.BackgroundImage = Properties.Resources.last1;
        }
        private void lastcale_MouseEnter(object sender, EventArgs e)
        {
            lastcale.BackgroundImage = Properties.Resources.last2;
        }
        private void calendar_Click(object sender, EventArgs e)
        {
            backpanel.BackgroundImage = cd.GetBitmap();
            HideBotton();
            tp.time.Enabled = true;
            tp.time.Start();
            Delay(Delayms);
            locate_for_cale.Visible = true;
            menupanel.Visible = true;
            if (cd.Year != 2016) nextcale.Visible = true;
            if (cd.Year != 2013) lastcale.Visible = true;
        }
        private void locate_for_cale_Click(object sender, EventArgs e)
        {
            Point msp = this.PointToClient(Control.MousePosition);
            int cdx = cd.GetDate(msp.X, msp.Y);
            //MessageBox.Show(cdx.ToString());
            int Index = fm.FindByDate(cdx);
            if (Index > -1)
            {
                fm.JumpTo(Index);
                int lastphotos = photo.album.UnlockCount();
                int lastmusics = photo.MusicCount();
                rm.Updata(Index);
                String JumpDiary = fm.GetDiaryName();
                tm.Dispose();
                tm = new MR_Text.TextArea();
                tm.GetFile(Application.StartupPath + "\\text\\" + JumpDiary, JumpDiary);
                tm.shiftPage(1);
                backpanel.BackgroundImage = Properties.Resources.bg1;
                tm.Visible = true;
                backpanel.Controls.Add(tm);
                int isUnlockPhoto = photo.album.UnlockCount()-lastphotos;
                int isUnlockMusic = photo.MusicCount() - lastmusics;


                Bitmap bm = new Bitmap(backpanel.Width, backpanel.Height);
                Rectangle rec = new Rectangle(0, 0, backpanel.Width, backpanel.Height);
                backpanel.DrawToBitmap(bm, rec);
                backpanel.BackgroundImage = bm;
                tm.Visible = false;

                HideBotton();
                tp.time.Enabled = true;
                tp.time.Start();
                Delay(Delayms);
                ChangeBotton();
                bgm.AutoChange(fm.GetPage);
                forepanel.BackgroundImage = bm;
                if (isUnlockPhoto >= 1 || isUnlockMusic >= 1)
                {
                    LoadingPanel lp = LoadingPanel.GetLoadPage();
                    lp.setLoadPage = 0;
                    f.Controls.Add(lp);
                    lp.BringToFront();
                    if (isUnlockMusic >= 1)
                    {
                        if (isUnlockPhoto >= 1)
                        {
                            lp.setLoadPage = 2;
                        }
                        else
                        {
                            lp.setLoadPage = 1;
                        }
                    }
                }
            }
            else
            {
                //fail
            }
        }
        private void lastcale_Click(object sender, EventArgs e)
        {
            cd.Year--;
            backpanellast.BackgroundImage = cd.GetBitmap();
            
            HideBotton();
            tp.timelast.Enabled = true;
            tp.timelast.Start();
            Delay(Delayms);
            if (cd.Year != 2014) lastcale.Visible = true;
            nextcale.Visible = true;
            locate_for_cale.Visible = true;
            menupanel.Visible = true;
        }
        private void nextcale_Click(object sender, EventArgs e)
        {
            cd.Year++;
            backpanel.BackgroundImage = cd.GetBitmap();
            
            HideBotton();
            tp.time.Enabled = true;
            tp.time.Start();
            Delay(Delayms);
            if (cd.Year != 2016) nextcale.Visible = true;
            lastcale.Visible = true;
            locate_for_cale.Visible = true;
            menupanel.Visible = true;
        }

        //TurnPage后显示按钮
        private void ChangeBotton()
        {
            if(fm.IsTitle())
            {
                startbutton.Visible = true;
                exitbutton.Visible = true;
                openCalendar.Visible = true;
                menupanel.Visible = false;
                others.Visible = true;
                findMark.Visible = true;
            }
            else
            {
                menupanel.Visible = true;
                nextpage.Visible = true;
                lastpage.Visible = true;
            }
        }
        //TurnPage前隐藏按钮
        private void HideBotton()
        {
            nextpage.Visible = false;
            lastpage.Visible = false;
            startbutton.Visible = false;
            exitbutton.Visible = false;
            openCalendar.Visible = false;
            others.Visible = false;
            findMark.Visible = false;

            menupanel.Visible = false;
            nextcale.Visible = false;
            lastcale.Visible = false;
            locate_for_cale.Visible = false;
        }
        private void HideMark(int oper)
        {
            if(oper==0) //save
            {
                mark1s.Visible = true;
                mark2s.Visible = true;
                mark3s.Visible = true;
                mark1l.Visible = false;
                mark2l.Visible = false;
                mark3l.Visible = false;
            }
            else        //load
            {
                mark1s.Visible = false;
                mark2s.Visible = false;
                mark3s.Visible = false;
                mark1l.Visible = true;
                mark2l.Visible = true;
                mark3l.Visible = true;
            }
        }
        //非假死的延时函数
        public static void Delay(int milliSecond)
        {
            int start = Environment.TickCount;
            while (Math.Abs(Environment.TickCount - start) < milliSecond)
            {
                Application.DoEvents();
            }
        }

        //解决闪烁
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
    }
}
