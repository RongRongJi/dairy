using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace Dairy1
{
    public class SeconeBook 
    {
        private ImageButton openAlbum; //相册
        public Button nextpage = new Button();    //下一页
        public Button lastpage = new Button();    //下一页
        public ImageButton back; //相册
        //For MenuPanel
        public System.Windows.Forms.Timer time1;
        public System.Windows.Forms.Timer time2;
        public ImageButton menuablum;
        public ImageButton menumusic;
        public ImageButton title;
        public ImageButton exit2;
        public bool ismusic = false;


        public ImageButton enjoyMusic; //音乐赏析
        private TurnPage tp = new TurnPage();
        public AntiFlashPanel forepanel = new AntiFlashPanel();
        public AntiFlashPanel backpanel = new AntiFlashPanel();
        public AntiFlashPanel backpanellast = new AntiFlashPanel();
        public int nPage = -1;//当前页
        public int lastPage; //结尾页
        public Album album = new Album();
        public BGM bgm;
        public ReadManager rm;
        private int Delayms = 300;

        public Button mbutton1, mbutton2, mbutton3, mbutton4, mbutton5, mbutton6, mbutton7, mbutton8, mbutton9, mbutton10, mbutton11, mbutton12;
        public SeconeBook()
        {
            init();
        }

        private System.Windows.Forms.Timer changebookTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer changebookTimer2 = new System.Windows.Forms.Timer();
        private ImageButton firstBook = new ImageButton();
        private ImageButton secondBook = new ImageButton();

        //动画 1到2
        public void ChangeToSecondBook(Panel forepanel)
        {
            forepanel.Controls.Add(this.forepanel);
            this.forepanel.BackgroundImage = Properties.Resources.desk_bg;
            this.forepanel.BringToFront();
            firstBook.BackgroundImageLayout = ImageLayout.Stretch;
            firstBook.BackgroundImage = Properties.Resources.book11;
            firstBook.Location = new Point(490, 0);
            firstBook.Size = new Size(630, 630);
            this.forepanel.Controls.Add(firstBook);
            firstBook.BringToFront();
            secondBook.BackgroundImageLayout = ImageLayout.Stretch;
            secondBook.BackgroundImage = Properties.Resources.book21;
            secondBook.Location = new Point(490 + 1500, 0);
            secondBook.Size = new Size(630, 630);
            this.forepanel.Controls.Add(secondBook);
            secondBook.BringToFront();
            changebookTimer.Enabled = true;
            changebookTimer.Start();
        }


        private void time_Tick(object sender, EventArgs e)
        {
            Control temp = firstBook.Parent;
            if (firstBook.Location.X != 490 + 1500)
            {
                firstBook.Visible = false;
                firstBook.Location = new Point(firstBook.Location.X + 50, firstBook.Location.Y);
                firstBook.Visible = true;
            }

            if (firstBook.Location.X == 490 + 1500)
            {
                secondBook.Visible = false;
                secondBook.Location = new Point(secondBook.Location.X - 50, secondBook.Location.Y);
                secondBook.Visible = true;
                if (secondBook.Location.X == 490)
                {
                    changebookTimer.Stop();
                    temp.Controls.Remove(firstBook);
                    forepanel.BackgroundImage = Properties.Resources.album_bg_f;
                    temp.Controls.Remove(secondBook);
                    openAlbum.Visible = true;
                    back.Visible = true;
                    enjoyMusic.Visible = true;
                }
            }
        }
        private void time2_Tick(object sender, EventArgs e)
        {
            Control temp = secondBook.Parent;
            if (secondBook.Location.X != 490 + 1500)
            {
                secondBook.Visible = false;
                secondBook.Location = new Point(secondBook.Location.X + 50, secondBook.Location.Y);
                secondBook.Visible = true;
            }
            if (secondBook.Location.X == 490 + 1500)
            {
                firstBook.Visible = false;
                firstBook.Location = new Point(firstBook.Location.X - 50, firstBook.Location.Y);
                firstBook.Visible = true;
                if (firstBook.Location.X == 490)
                {
                    changebookTimer2.Stop();
                    temp.Controls.Remove(secondBook);
                    temp.Controls.Remove(firstBook);
                    forepanel.Parent.Controls.Remove(forepanel);
                }
            }

        }


        //动画 2到1
        public void ChangeToFirstBook()
        {
            forepanel.BackgroundImage = Properties.Resources.desk_bg;
            forepanel.BringToFront();
            firstBook.BackgroundImageLayout = ImageLayout.Stretch;
            firstBook.BackgroundImage = Properties.Resources.book11;
            firstBook.Location = new Point(490 + 1500, 0);
            firstBook.Size = new Size(630, 630);
            forepanel.Controls.Add(firstBook);
            firstBook.BringToFront();
            secondBook.BackgroundImageLayout = ImageLayout.Stretch;
            secondBook.BackgroundImage = Properties.Resources.book21;
            secondBook.Location = new Point(490, 0);
            secondBook.Size = new Size(630, 630);
            forepanel.Controls.Add(secondBook);
            secondBook.BringToFront();
            openAlbum.Visible = false;
            back.Visible = false;
            enjoyMusic.Visible = false;
            changebookTimer2.Enabled = true;
            changebookTimer2.Start();
        }



        //初始化
        private void init()
        {
            forepanel.Location = new System.Drawing.Point(0, 0);
            forepanel.Size = new System.Drawing.Size(1120, 630);
            forepanel.BackgroundImageLayout = ImageLayout.Stretch;
            //forepanel.BackgroundImage = Properties.Resources.album_bg_f;

            backpanel.Location = new System.Drawing.Point(0, 0);
            backpanel.Size = new System.Drawing.Size(1120, 630);
            backpanel.BackgroundImageLayout = ImageLayout.Stretch;
            backpanel.BackgroundImage = Properties.Resources.album_bg;

            backpanellast.Location = new System.Drawing.Point(0, 0);
            backpanellast.Size = new System.Drawing.Size(1120, 630);
            backpanellast.BackgroundImageLayout = ImageLayout.Stretch;
            backpanellast.BackgroundImage = Properties.Resources.album_bg;

            //相册
            openAlbum = new ImageButton();
            openAlbum.BackColor = System.Drawing.Color.Transparent;
            openAlbum.BackgroundImage = Properties.Resources.tb_photo1;
            openAlbum.BackgroundImageLayout = ImageLayout.Stretch;
            openAlbum.FlatAppearance.BorderSize = 0;
            openAlbum.FlatStyle = FlatStyle.Flat;
            openAlbum.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            openAlbum.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            openAlbum.Location = new System.Drawing.Point(230, 250);
            openAlbum.Size = new System.Drawing.Size(208, 33);
            openAlbum.Click += new EventHandler(this.openAlbum_Click);
            openAlbum.MouseEnter += new EventHandler(this.openAlbum_MouseEnter);
            openAlbum.MouseLeave += new EventHandler(this.openAlbum_MouseLeave);


            //返回
            this.back = new ImageButton();
            this.back.BackColor = System.Drawing.Color.Transparent;
            this.back.BackgroundImage = global::Dairy1.Properties.Resources.tb_back;
            this.back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.back.FlatAppearance.BorderSize = 0;
            this.back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.back.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.back.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.back.Location = new System.Drawing.Point(230, 430);
            this.back.Size = new System.Drawing.Size(208, 33);
            this.back.Click += new System.EventHandler(this.back_Click);
            this.back.MouseEnter += new System.EventHandler(this.back_MouseEnter);
            this.back.MouseLeave += new System.EventHandler(this.back_MouseLeave);

            //音乐赏析
            this.enjoyMusic = new ImageButton();
            this.enjoyMusic.BackColor = System.Drawing.Color.Transparent;
            this.enjoyMusic.BackgroundImage = global::Dairy1.Properties.Resources.tb_music1;
            this.enjoyMusic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.enjoyMusic.FlatAppearance.BorderSize = 0;
            this.enjoyMusic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enjoyMusic.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.enjoyMusic.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.enjoyMusic.Location = new System.Drawing.Point(230, 340);
            this.enjoyMusic.Size = new System.Drawing.Size(208, 33);
            this.enjoyMusic.Click += new System.EventHandler(this.enjoyMusic_Click);
            this.enjoyMusic.MouseEnter += new System.EventHandler(this.enjoyMusic_MouseEnter);
            this.enjoyMusic.MouseLeave += new System.EventHandler(this.enjoyMusic_MouseLeave);

            //下一页
            this.nextpage.BackColor = System.Drawing.Color.Transparent;
            this.nextpage.BackgroundImage = global::Dairy1.Properties.Resources.next1;
            this.nextpage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.nextpage.FlatAppearance.BorderSize = 0;
            this.nextpage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextpage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.nextpage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.nextpage.Location = new System.Drawing.Point(1000, 530);
            this.nextpage.Size = new System.Drawing.Size(115, 27);
            this.nextpage.Click += new System.EventHandler(this.nextpage_Click);
            this.nextpage.MouseEnter += new System.EventHandler(this.nextpage_MouseEnter);
            this.nextpage.MouseLeave += new System.EventHandler(this.nextpage_MouseLeave);
            this.nextpage.Name = "next";

            //上一页
            this.lastpage.BackColor = System.Drawing.Color.Transparent;
            this.lastpage.BackgroundImage = global::Dairy1.Properties.Resources.last1;
            this.lastpage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lastpage.FlatAppearance.BorderSize = 0;
            this.lastpage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lastpage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.lastpage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.lastpage.Location = new System.Drawing.Point(5, 530);
            this.lastpage.Size = new System.Drawing.Size(115, 27);
            this.lastpage.Click += new System.EventHandler(this.lastpage_Click);
            this.lastpage.MouseEnter += new System.EventHandler(this.lastpage_MouseEnter);
            this.lastpage.MouseLeave += new System.EventHandler(this.lastpage_MouseLeave);
            this.lastpage.Name = "last";

            //timer
            changebookTimer.Interval = 10;
            changebookTimer.Tick += new EventHandler(time_Tick);
            changebookTimer2.Interval = 10;
            changebookTimer2.Tick += new EventHandler(time2_Tick);

            //换书
            firstBook.FlatAppearance.BorderSize = 0;
            firstBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            firstBook.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            firstBook.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            firstBook.BackColor = System.Drawing.Color.Transparent;
            secondBook.FlatAppearance.BorderSize = 0;
            secondBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            secondBook.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            secondBook.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            secondBook.BackColor = System.Drawing.Color.Transparent;
            tp.forepanel = forepanel;
            tp.backpanel = backpanel;
            tp.backpanellast = backpanellast;

            //Music
            mbutton1 = new Button();
            mbutton2 = new Button();
            mbutton3 = new Button();
            mbutton4 = new Button();
            mbutton5 = new Button();
            mbutton6 = new Button();
            mbutton7 = new Button();
            mbutton8 = new Button();
            mbutton9 = new Button();
            mbutton10 = new Button();
            mbutton11 = new Button();
            mbutton12 = new Button();

            this.mbutton1.BackColor = System.Drawing.Color.Transparent;
            this.mbutton1.BackgroundImage = global::Dairy1.Properties.Resources.mbutton1;
            this.mbutton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mbutton1.FlatAppearance.BorderSize = 0;
            this.mbutton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mbutton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.mbutton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.mbutton1.Location = new System.Drawing.Point(154, 105);
            this.mbutton1.Size = new System.Drawing.Size(355, 97);
            this.mbutton1.Click += new System.EventHandler(this.mbutton1_Click);
            this.mbutton1.MouseEnter += new System.EventHandler(this.mbutton1_MouseEnter);
            this.mbutton1.MouseLeave += new System.EventHandler(this.mbutton1_MouseLeave);

            this.mbutton2.BackColor = System.Drawing.Color.Transparent;
            this.mbutton2.BackgroundImage = global::Dairy1.Properties.Resources.mbutton2;
            this.mbutton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mbutton2.FlatAppearance.BorderSize = 0;
            this.mbutton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mbutton2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.mbutton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.mbutton2.Location = new System.Drawing.Point(154, 206);
            this.mbutton2.Size = new System.Drawing.Size(355, 97);
            this.mbutton2.Click += new System.EventHandler(this.mbutton2_Click);
            this.mbutton2.MouseEnter += new System.EventHandler(this.mbutton2_MouseEnter);
            this.mbutton2.MouseLeave += new System.EventHandler(this.mbutton2_MouseLeave);

            this.mbutton3.BackColor = System.Drawing.Color.Transparent;
            this.mbutton3.BackgroundImage = global::Dairy1.Properties.Resources.mbutton3;
            this.mbutton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mbutton3.FlatAppearance.BorderSize = 0;
            this.mbutton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mbutton3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.mbutton3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.mbutton3.Location = new System.Drawing.Point(154, 307);
            this.mbutton3.Size = new System.Drawing.Size(355, 166);
            this.mbutton3.Click += new System.EventHandler(this.mbutton3_Click);
            this.mbutton3.MouseEnter += new System.EventHandler(this.mbutton3_MouseEnter);
            this.mbutton3.MouseLeave += new System.EventHandler(this.mbutton3_MouseLeave);
        
            this.mbutton4.BackColor = System.Drawing.Color.Transparent;
            this.mbutton4.BackgroundImage = global::Dairy1.Properties.Resources.mbutton4;
            this.mbutton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mbutton4.FlatAppearance.BorderSize = 0;
            this.mbutton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mbutton4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.mbutton4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.mbutton4.Location = new System.Drawing.Point(154, 474);
            this.mbutton4.Size = new System.Drawing.Size(355, 115);
            this.mbutton4.Click += new System.EventHandler(this.mbutton4_Click);
            this.mbutton4.MouseEnter += new System.EventHandler(this.mbutton4_MouseEnter);
            this.mbutton4.MouseLeave += new System.EventHandler(this.mbutton4_MouseLeave);

            this.mbutton5.BackColor = System.Drawing.Color.Transparent;
            this.mbutton5.BackgroundImage = global::Dairy1.Properties.Resources.mbutton5;
            this.mbutton5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mbutton5.FlatAppearance.BorderSize = 0;
            this.mbutton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mbutton5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.mbutton5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.mbutton5.Location = new System.Drawing.Point(605, 42);
            this.mbutton5.Size = new System.Drawing.Size(355, 200);
            this.mbutton5.Click += new System.EventHandler(this.mbutton5_Click);
            this.mbutton5.MouseEnter += new System.EventHandler(this.mbutton5_MouseEnter);
            this.mbutton5.MouseLeave += new System.EventHandler(this.mbutton5_MouseLeave);

            this.mbutton6.BackColor = System.Drawing.Color.Transparent;
            this.mbutton6.BackgroundImage = global::Dairy1.Properties.Resources.mbutton6;
            this.mbutton6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mbutton6.FlatAppearance.BorderSize = 0;
            this.mbutton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mbutton6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.mbutton6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.mbutton6.Location = new System.Drawing.Point(605, 350);
            this.mbutton6.Size = new System.Drawing.Size(355, 32);
            this.mbutton6.Click += new System.EventHandler(this.mbutton6_Click);
            this.mbutton6.MouseEnter += new System.EventHandler(this.mbutton6_MouseEnter);
            this.mbutton6.MouseLeave += new System.EventHandler(this.mbutton6_MouseLeave);

            this.mbutton7.BackColor = System.Drawing.Color.Transparent;
            this.mbutton7.BackgroundImage = global::Dairy1.Properties.Resources.mbutton7;
            this.mbutton7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mbutton7.FlatAppearance.BorderSize = 0;
            this.mbutton7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mbutton7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.mbutton7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.mbutton7.Location = new System.Drawing.Point(605, 384);
            this.mbutton7.Size = new System.Drawing.Size(355, 32);
            this.mbutton7.Click += new System.EventHandler(this.mbutton7_Click);
            this.mbutton7.MouseEnter += new System.EventHandler(this.mbutton7_MouseEnter);
            this.mbutton7.MouseLeave += new System.EventHandler(this.mbutton7_MouseLeave);

            this.mbutton8.BackColor = System.Drawing.Color.Transparent;
            this.mbutton8.BackgroundImage = global::Dairy1.Properties.Resources.mbutton8;
            this.mbutton8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mbutton8.FlatAppearance.BorderSize = 0;
            this.mbutton8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mbutton8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.mbutton8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.mbutton8.Location = new System.Drawing.Point(605, 417);
            this.mbutton8.Size = new System.Drawing.Size(355, 32);
            this.mbutton8.Click += new System.EventHandler(this.mbutton8_Click);
            this.mbutton8.MouseEnter += new System.EventHandler(this.mbutton8_MouseEnter);
            this.mbutton8.MouseLeave += new System.EventHandler(this.mbutton8_MouseLeave);

            this.mbutton9.BackColor = System.Drawing.Color.Transparent;
            this.mbutton9.BackgroundImage = global::Dairy1.Properties.Resources.mbutton9;
            this.mbutton9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mbutton9.FlatAppearance.BorderSize = 0;
            this.mbutton9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mbutton9.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.mbutton9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.mbutton9.Location = new System.Drawing.Point(605, 451);
            this.mbutton9.Size = new System.Drawing.Size(355, 32);
            this.mbutton9.Click += new System.EventHandler(this.mbutton9_Click);
            this.mbutton9.MouseEnter += new System.EventHandler(this.mbutton9_MouseEnter);
            this.mbutton9.MouseLeave += new System.EventHandler(this.mbutton9_MouseLeave);

            this.mbutton10.BackColor = System.Drawing.Color.Transparent;
            this.mbutton10.BackgroundImage = global::Dairy1.Properties.Resources.mbutton10;
            this.mbutton10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mbutton10.FlatAppearance.BorderSize = 0;
            this.mbutton10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mbutton10.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.mbutton10.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.mbutton10.Location = new System.Drawing.Point(605, 483);
            this.mbutton10.Size = new System.Drawing.Size(355, 32);
            this.mbutton10.Click += new System.EventHandler(this.mbutton10_Click);
            this.mbutton10.MouseEnter += new System.EventHandler(this.mbutton10_MouseEnter);
            this.mbutton10.MouseLeave += new System.EventHandler(this.mbutton10_MouseLeave);

            this.mbutton11.BackColor = System.Drawing.Color.Transparent;
            this.mbutton11.BackgroundImage = global::Dairy1.Properties.Resources.mbutton11;
            this.mbutton11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mbutton11.FlatAppearance.BorderSize = 0;
            this.mbutton11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mbutton11.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.mbutton11.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.mbutton11.Location = new System.Drawing.Point(605, 518);
            this.mbutton11.Size = new System.Drawing.Size(355, 32);
            this.mbutton11.Click += new System.EventHandler(this.mbutton11_Click);
            this.mbutton11.MouseEnter += new System.EventHandler(this.mbutton11_MouseEnter);
            this.mbutton11.MouseLeave += new System.EventHandler(this.mbutton11_MouseLeave);

            this.mbutton12.BackColor = System.Drawing.Color.Transparent;
            this.mbutton12.BackgroundImage = global::Dairy1.Properties.Resources.mbutton12;
            this.mbutton12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mbutton12.FlatAppearance.BorderSize = 0;
            this.mbutton12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mbutton12.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.mbutton12.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.mbutton12.Location = new System.Drawing.Point(605, 552);
            this.mbutton12.Size = new System.Drawing.Size(355, 32);
            this.mbutton12.Click += new System.EventHandler(this.mbutton12_Click);
            this.mbutton12.MouseEnter += new System.EventHandler(this.mbutton12_MouseEnter);
            this.mbutton12.MouseLeave += new System.EventHandler(this.mbutton12_MouseLeave);



            this.menuablum = new ImageButton();
            this.menuablum.BackColor = System.Drawing.Color.Transparent;
            this.menuablum.BackgroundImage = global::Dairy1.Properties.Resources.menu_button6_s;
            this.menuablum.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuablum.FlatAppearance.BorderSize = 0;
            this.menuablum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuablum.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.menuablum.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.menuablum.Location = new System.Drawing.Point(65, 150);
            this.menuablum.Size = new System.Drawing.Size(98, 28);
            this.menuablum.Click += new System.EventHandler(this.menuablum_Click);
            this.menuablum.MouseEnter += new System.EventHandler(this.menuablum_MouseEnter);
            this.menuablum.MouseLeave += new System.EventHandler(this.menuablum_MouseLeave);

            this.menumusic = new ImageButton();
            this.menumusic.BackColor = System.Drawing.Color.Transparent;
            this.menumusic.BackgroundImage = global::Dairy1.Properties.Resources.menu_button7_s;
            this.menumusic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menumusic.FlatAppearance.BorderSize = 0;
            this.menumusic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menumusic.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.menumusic.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.menumusic.Location = new System.Drawing.Point(65, 180);
            this.menumusic.Size = new System.Drawing.Size(98, 28);
            this.menumusic.Click += new System.EventHandler(this.menumusic_Click);
            this.menumusic.MouseEnter += new System.EventHandler(this.menumusic_MouseEnter);
            this.menumusic.MouseLeave += new System.EventHandler(this.menumusic_MouseLeave);

            this.title = new ImageButton();
            this.title.BackColor = System.Drawing.Color.Transparent;
            this.title.BackgroundImage = global::Dairy1.Properties.Resources.menu_button4_s;
            this.title.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.title.FlatAppearance.BorderSize = 0;
            this.title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.title.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.title.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.title.Location = new System.Drawing.Point(65, 210);
            this.title.Size = new System.Drawing.Size(98, 28);
            this.title.Click += new System.EventHandler(this.title_Click);
            this.title.MouseEnter += new System.EventHandler(this.title_MouseEnter);
            this.title.MouseLeave += new System.EventHandler(this.title_MouseLeave);

            this.exit2 = new ImageButton();
            this.exit2.BackColor = System.Drawing.Color.Transparent;
            this.exit2.BackgroundImage = global::Dairy1.Properties.Resources.menu_button5_s;
            this.exit2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exit2.FlatAppearance.BorderSize = 0;
            this.exit2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.exit2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.exit2.Location = new System.Drawing.Point(65, 240);
            this.exit2.Size = new System.Drawing.Size(98, 28);
            this.exit2.Click += new System.EventHandler(this.exitbutton_Click);
            this.exit2.MouseEnter += new System.EventHandler(this.exit2_MouseEnter);
            this.exit2.MouseLeave += new System.EventHandler(this.exit2_MouseLeave);


            forepanel.Controls.Add(openAlbum);
            forepanel.Controls.Add(enjoyMusic);
            forepanel.Controls.Add(back);
            forepanel.Controls.Add(nextpage);
            forepanel.Controls.Add(lastpage);
            HideButton();
        }

        private void menuablum_MouseLeave(object sender, EventArgs e)
        {
            menuablum.BackgroundImage = Properties.Resources.menu_button6_s;
        }
        private void menuablum_MouseEnter(object sender, EventArgs e)
        {
            menuablum.BackgroundImage = Properties.Resources.menu_button6_f;
        }
        
        private void menuablum_Click(object sender,EventArgs e)
        {
            album.Removepanel(forepanel);
            HideButton();
            nPage=0;
            backpanel.BackgroundImage = album.CreateAlbum(nPage);
            tp.time.Enabled = true;
            tp.time.Start();
            Delay(Delayms);
            ChangeButton();
            album.Addpanel(forepanel);
        }
        private void menumusic_MouseLeave(object sender, EventArgs e)
        {
            menumusic.BackgroundImage = Properties.Resources.menu_button7_s;
        }
        private void menumusic_MouseEnter(object sender, EventArgs e)
        {
            menumusic.BackgroundImage = Properties.Resources.menu_button7_f;
        }
        private void menumusic_Click(object sender,EventArgs e)
        {
            album.Removepanel(forepanel);
            nPage = -1;
            enjoyMusic_Click(sender, e);
        }

        private void title_MouseLeave(object sender, EventArgs e)
        {
            title.BackgroundImage = Properties.Resources.menu_button4_s;
        }
        private void title_MouseEnter(object sender, EventArgs e)
        {
            title.BackgroundImage = Properties.Resources.menu_button4_f;
        }

        private void title_Click(object sender, EventArgs e)
        {
            menumusic.Parent.Visible = false;
            menumusic.Parent.Location = new System.Drawing.Point(1093, 315);
            HideButton();
            album.Removepanel(forepanel);
            nPage = -1;
            backpanellast.BackgroundImage = album.CreateAlbum(nPage);
            tp.timelast.Enabled = true;
            tp.timelast.Start();
            Delay(Delayms);
            ChangeButton();
        }
        private void exit2_MouseLeave(object sender, EventArgs e)
        {
            exit2.BackgroundImage = Properties.Resources.menu_button5_s;
        }
        private void exit2_MouseEnter(object sender, EventArgs e)
        {
            exit2.BackgroundImage = Properties.Resources.menu_button5_f;
        }
        private void exitbutton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void back_MouseLeave(object sender, EventArgs e)
        {
            back.BackgroundImage = Properties.Resources.tb_back;
        }
        private void back_MouseEnter(object sender, EventArgs e)
        {
            back.BackgroundImage = Properties.Resources.tb_back2;
        }

        private void back_Click(object sender, EventArgs e)
        {
            ChangeToFirstBook();
            menumusic.Parent.Visible = false;
        }

        private void enjoyMusic_MouseLeave(object sender, EventArgs e)
        {
            enjoyMusic.BackgroundImage = Properties.Resources.tb_music1;
        }
        private void enjoyMusic_MouseEnter(object sender, EventArgs e)
        {
            enjoyMusic.BackgroundImage = Properties.Resources.tb_music2;
        }

        private void enjoyMusic_Click(object sender, EventArgs e)
        {
            ismusic = true;
            menumusic.Parent.Visible = true;
            menumusic.Parent.Location = new System.Drawing.Point(1093, 315);
            bgm.stop();
            backpanel.BackgroundImage = Properties.Resources.mr_bg;
            Addmbutton(backpanel);
            HideButton();
            tp.time.Enabled = true;
            tp.time.Start();
            Delay(Delayms);
            Addmbutton(forepanel);
            Removembutton(backpanel);
            nPage++;
            lastpage.Visible = true;
        }

        private void openAlbum_MouseEnter(object sender,EventArgs e)
        {
            openAlbum.BackgroundImage = Properties.Resources.tb_photo2;
        }
        private void openAlbum_MouseLeave(object sender,EventArgs e)
        {
            openAlbum.BackgroundImage = Properties.Resources.tb_photo1;
        }
        private void openAlbum_Click(object sender,EventArgs e)
        {
            menumusic.Parent.Visible = true;
            menumusic.Parent.Location = new System.Drawing.Point(1093, 315);
            HideButton();
            nPage++;
            backpanel.BackgroundImage = album.CreateAlbum(nPage);
            tp.time.Enabled = true;
            tp.time.Start();
            Delay(Delayms);
            ChangeButton();
            album.Addpanel(forepanel);
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
            HideButton();
            album.Removepanel(forepanel);
            ++nPage;
            if (IsBack()) backpanel.BackgroundImage = Properties.Resources.album_bg_b;
            else backpanel.BackgroundImage = album.CreateAlbum(nPage);
            tp.time.Enabled = true;
            tp.time.Start();
            Delay(Delayms);
            ChangeButton();
            if(!IsBack()) album.Addpanel(forepanel);
        }

        private void lastpage_Click(object sender, EventArgs e)
        {
            HideButton();

            album.Removepanel(forepanel);
            --nPage;
            backpanellast.BackgroundImage = album.CreateAlbum(nPage);
            if (ismusic)
            {
                ismusic = false;
                Bitmap bm = new Bitmap(backpanel.Width, backpanel.Height);
                Rectangle rec = new Rectangle(0, 0, backpanel.Width, backpanel.Height);
                forepanel.DrawToBitmap(bm, rec);//耗时
                forepanel.BackgroundImage = bm;
                Removembutton(forepanel);
            }
            tp.timelast.Enabled = true;
            tp.timelast.Start();
            Delay(Delayms);
            ChangeButton();

            if (!IsTitlt()) album.Addpanel(forepanel);
            if (IsTitlt()) menumusic.Parent.Visible = false;
        }

        //Music_Room
        private void Addmbutton(Panel forepanel)
        {
            forepanel.Controls.Add(mbutton1);
            forepanel.Controls.Add(mbutton2);
            forepanel.Controls.Add(mbutton3);
            forepanel.Controls.Add(mbutton4);
            forepanel.Controls.Add(mbutton5);

            if (rm.Query(48)) forepanel.Controls.Add(mbutton6);
            if (rm.Query(209)) forepanel.Controls.Add(mbutton7);
            if (rm.Query(213)) forepanel.Controls.Add(mbutton8);
            double rate = rm.rate;
            if (rate>0.24) forepanel.Controls.Add(mbutton9);
            if (rate > 0.48) forepanel.Controls.Add(mbutton10);
            if (rate > 0.73) forepanel.Controls.Add(mbutton11);
            if (rate > 0.97) forepanel.Controls.Add(mbutton12);
        }
        private void Removembutton(Panel forepanel)
        {
            forepanel.Controls.Remove(mbutton1);
            forepanel.Controls.Remove(mbutton2);
            forepanel.Controls.Remove(mbutton3);
            forepanel.Controls.Remove(mbutton4);
            forepanel.Controls.Remove(mbutton5);
            forepanel.Controls.Remove(mbutton6);
            forepanel.Controls.Remove(mbutton7);
            forepanel.Controls.Remove(mbutton8);
            forepanel.Controls.Remove(mbutton9);
            forepanel.Controls.Remove(mbutton10);
            forepanel.Controls.Remove(mbutton11);
            forepanel.Controls.Remove(mbutton12);
        }
        private void mbutton1_MouseLeave(object sender, EventArgs e)
        {
            mbutton1.BackgroundImage = Properties.Resources.mbutton1;
        }
        private void mbutton1_MouseEnter(object sender, EventArgs e)
        {
            mbutton1.BackgroundImage = Properties.Resources.mbutton1f;
        }
        private void mbutton1_Click(object sender, EventArgs e)
        {
            bgm.changeBGM(4);
        }
        private void mbutton2_MouseLeave(object sender, EventArgs e)
        {
            mbutton2.BackgroundImage = Properties.Resources.mbutton2;
        }
        private void mbutton2_MouseEnter(object sender, EventArgs e)
        {
            mbutton2.BackgroundImage = Properties.Resources.mbutton2f;
        }
        private void mbutton2_Click(object sender, EventArgs e)
        {
            bgm.changeBGM(5);
        }
        private void mbutton3_MouseLeave(object sender, EventArgs e)
        {
            mbutton3.BackgroundImage = Properties.Resources.mbutton3;
        }
        private void mbutton3_MouseEnter(object sender, EventArgs e)
        {
            mbutton3.BackgroundImage = Properties.Resources.mbutton3f;
        }
        private void mbutton3_Click(object sender, EventArgs e)
        {
            bgm.changeBGM(6);
        }
        private void mbutton4_MouseLeave(object sender, EventArgs e)
        {
            mbutton4.BackgroundImage = Properties.Resources.mbutton4;
        }
        private void mbutton4_MouseEnter(object sender, EventArgs e)
        {
            mbutton4.BackgroundImage = Properties.Resources.mbutton4f;
        }
        private void mbutton4_Click(object sender, EventArgs e)
        {
            bgm.changeBGM(7);
        }
        private void mbutton5_MouseLeave(object sender, EventArgs e)
        {
            mbutton5.BackgroundImage = Properties.Resources.mbutton5;
        }
        private void mbutton5_MouseEnter(object sender, EventArgs e)
        {
            mbutton5.BackgroundImage = Properties.Resources.mbutton5f;
        }
        private void mbutton5_Click(object sender, EventArgs e)
        {
            bgm.changeBGM(8);
        }
        private void mbutton6_MouseLeave(object sender, EventArgs e)
        {
            mbutton6.BackgroundImage = Properties.Resources.mbutton6;
        }
        private void mbutton6_MouseEnter(object sender, EventArgs e)
        {
            mbutton6.BackgroundImage = Properties.Resources.mbutton6f;
        }
        private void mbutton6_Click(object sender, EventArgs e)
        {
            bgm.changeBGM(1);
        }
        private void mbutton7_MouseLeave(object sender, EventArgs e)
        {
            mbutton7.BackgroundImage = Properties.Resources.mbutton7;
        }
        private void mbutton7_MouseEnter(object sender, EventArgs e)
        {
            mbutton7.BackgroundImage = Properties.Resources.mbutton7f;
        }
        private void mbutton7_Click(object sender, EventArgs e)
        {
            bgm.changeBGM(2);
        }
        private void mbutton8_MouseLeave(object sender, EventArgs e)
        {
            mbutton8.BackgroundImage = Properties.Resources.mbutton8;
        }
        private void mbutton8_MouseEnter(object sender, EventArgs e)
        {
            mbutton8.BackgroundImage = Properties.Resources.mbutton8f;
        }
        private void mbutton8_Click(object sender, EventArgs e)
        {
            bgm.changeBGM(3);
        }
        private void mbutton9_MouseLeave(object sender, EventArgs e)
        {
            mbutton9.BackgroundImage = Properties.Resources.mbutton9;
        }
        private void mbutton9_MouseEnter(object sender, EventArgs e)
        {
            mbutton9.BackgroundImage = Properties.Resources.mbutton9f;
        }
        private void mbutton9_Click(object sender, EventArgs e)
        {
            bgm.changeBGM(9);
        }
        private void mbutton10_MouseLeave(object sender, EventArgs e)
        {
            mbutton10.BackgroundImage = Properties.Resources.mbutton10;
        }
        private void mbutton10_MouseEnter(object sender, EventArgs e)
        {
            mbutton10.BackgroundImage = Properties.Resources.mbutton10f;
        }
        private void mbutton10_Click(object sender, EventArgs e)
        {
            bgm.changeBGM(10);
        }
        private void mbutton11_MouseLeave(object sender, EventArgs e)
        {
            mbutton11.BackgroundImage = Properties.Resources.mbutton11;
        }
        private void mbutton11_MouseEnter(object sender, EventArgs e)
        {
            mbutton11.BackgroundImage = Properties.Resources.mbutton11f;
        }
        private void mbutton11_Click(object sender, EventArgs e)
        {
            bgm.changeBGM(11);
        }
        private void mbutton12_MouseLeave(object sender, EventArgs e)
        {
            mbutton12.BackgroundImage = Properties.Resources.mbutton12;
        }
        private void mbutton12_MouseEnter(object sender, EventArgs e)
        {
            mbutton12.BackgroundImage = Properties.Resources.mbutton12f;
        }
        private void mbutton12_Click(object sender, EventArgs e)
        {
            bgm.changeBGM(12);
        }


        private bool IsTitlt()
        {
            if (nPage == -1) return true;
            else return false;
        }
        private bool IsBack()
        {
            if (nPage == album.totPage) return true;
            else return false;
        }
        private void HideButton()
        {
            openAlbum.Visible = false;
            back.Visible = false;
            enjoyMusic.Visible = false;
            nextpage.Visible = false;
            lastpage.Visible = false;
        }
        private void ChangeButton()
        {
            if (IsTitlt())
            {
                openAlbum.Visible = true;
                back.Visible = true;
                enjoyMusic.Visible = true;
            }
            else if (IsBack())
            {
                lastpage.Visible = true;
            }
            else
            {
                nextpage.Visible = true;
                lastpage.Visible = true;
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

        public int MusicCount()
        {
            int res = 0;
            if (rm.Query(48)) res++;
            if (rm.Query(209)) res++;
            if (rm.Query(213)) res++;
            double rate = rm.rate;
            if (rate > 0.24) res++;
            if (rate > 0.48) res++;
            if (rate > 0.73) res++;
            if (rate > 0.97) res++;
            return res;
        }
    }
}
