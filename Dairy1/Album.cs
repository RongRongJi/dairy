using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace Dairy1
{
    public class mapp
    {
        public Bitmap srcimg;
        public int index;
        public int date;
        
        public Bitmap img;
        public int type;
        public Point p;
        public mapp() { }
        public mapp(Bitmap _img,int _index,int _date=0)
        {
            srcimg = _img;
            index = _index;
            date = _date;
        }
        public void change(Bitmap _img, int _index, int _date = 0)
        {
            img = _img;
            index = _index;
            date = _date;
        }
        public void setP(Point _P) { p = _P; }
        public void Init(int _type)
        {
            type = _type;
        }
    }
    public class Album
    {
        public List<mapp> list = new List<mapp>();
        Bitmap white = Properties.Resources.album_white;
        private int whitepx = (int)(12 / 0.7);
        public ReadManager rm;
        private mapp p1, p2, p3, p4;
        private int v1, v2, v3, v4;//valid -1 none 0 lock 1 unlock
        private int x1=500;
        private int x2=1100;
        private int y1=250;
        private int y2=666;
        private Panel papa;
        private Bitmap[] album_lock = new Bitmap[2];
        private Timer timer = new Timer();
        public Album()
        {
            //LoadBitmap
            album_lock[0] = Properties.Resources.album_lock_h;//w
            album_lock[1] = Properties.Resources.album_lock_s;//h
            timer.Interval = 10;
            timer.Tick += new EventHandler(time_Tick);
            InitBitmap();
            InitPanel();
        }
        //*
        private Bitmap resize(Bitmap src, int w, int h)
        {
            Bitmap ret = new Bitmap(w, h);
            Graphics g = Graphics.FromImage(ret);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(src, new Rectangle(0, 0, w, h), new Rectangle(0, 0, src.Width, src.Height), GraphicsUnit.Pixel);
            g.Dispose();
            return ret;
        }
        private void draw(Bitmap src, Bitmap into,int x,int y)
        {
            int w = into.Width;
            int h = into.Height;
            x -= w / 2;
            y -= h / 2;
            Graphics g = Graphics.FromImage(src);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(white, new Rectangle(x - whitepx, y - whitepx, w + whitepx * 2, h + whitepx * 2), new Rectangle(0, 0, white.Width, white.Height), GraphicsUnit.Pixel);
            g.DrawImage(into, new Rectangle(x, y, w, h), new Rectangle(0, 0, w, h), GraphicsUnit.Pixel);
            g.Dispose();
        }
        private void Addmapp(Bitmap _img,int _index,int _date=0)
        {
            mapp one = new mapp(_img, _index,_date);
            int w = one.srcimg.Width, h = one.srcimg.Height;
            int st = 0;
            double div = (1.0 * w) / h;
            if (div > 1) h = (int)(160 / 0.7);
            else
            {
                h = (int)(210 / 0.7);
                st = 1;
            }
            w = (int)(div * h);
            one.img=resize(one.srcimg, w, h);
            one.Init(st);
            list.Add(one);
        }
        public Bitmap CreateAlbum(int page)
        {
            v1 = v2 = v3 = v4 = -1;
            if (page < 0) return Properties.Resources.album_bg_f;
            Bitmap result = new Bitmap(Properties.Resources.album_bg);
            Graphics g = Graphics.FromImage(result);
            int tot = list.Count;
            if (page * 4 < tot)
            {
                p1 = list[page * 4];
                if (rm.Query(p1.index)) v1 = 1;
                else v1 = 0;
            }
            if (page * 4 +1 < tot)
            {
                p2 = list[page * 4 + 1];
                if (rm.Query(p2.index)) v2 = 1;
                else v2 = 0;
            }
            if (page * 4 + 2 < tot)
            {
                p3 = list[page * 4 + 2];
                if (rm.Query(p3.index)) v3 = 1;
                else v3 = 0;
            }
            if (page * 4 + 3 < tot)
            {
                p4 = list[page * 4 + 3];
                if (rm.Query(p4.index)) v4 = 1;
                else v4 = 0;
            }
            if(v1>-1)
            if (rm.Query(p1.index)) draw(result, p1.img, x1, y1);
                else draw(result, album_lock[p1.type], x1, y1);
            if(v2>-1)
            if (rm.Query(p2.index)) draw(result, p2.img, x2, y1);
                else draw(result, album_lock[p2.type], x2, y1);
            if(v3>-1)
            if (rm.Query(p3.index)) draw(result, p3.img, x1, y2);
                else draw(result, album_lock[p3.type], x1, y2);
            if(v4>-1)
            if (rm.Query(p4.index)) draw(result, p4.img, x2, y2);
                else draw(result, album_lock[p4.type], x2, y2);
            return result;
        }
        private void InitBitmap()
        {
            Addmapp((Bitmap)Properties.Resources.ResourceManager.GetObject("高一科艺节"), -1);
            Addmapp((Bitmap)Properties.Resources.ResourceManager.GetObject("高一科艺节1"), -1);
            Addmapp((Bitmap)Properties.Resources.ResourceManager.GetObject("高一艺术墙"), -1);
            Addmapp((Bitmap)Properties.Resources.ResourceManager.GetObject("高一运动会"), -1);
            Addmapp((Bitmap)Properties.Resources.ResourceManager.GetObject("_140328"), 31);
            Addmapp((Bitmap)Properties.Resources.ResourceManager.GetObject("_140626"), 67);
            Addmapp((Bitmap)Properties.Resources.ResourceManager.GetObject("_141008"), 88);
            Addmapp((Bitmap)Properties.Resources.ResourceManager.GetObject("_1410081"), 88);
            Addmapp((Bitmap)Properties.Resources.ResourceManager.GetObject("_141231"), 140);
            Addmapp((Bitmap)Properties.Resources.ResourceManager.GetObject("_1504031"), 177);
            Addmapp((Bitmap)Properties.Resources.ResourceManager.GetObject("_1504032"), 177);
            Addmapp((Bitmap)Properties.Resources.ResourceManager.GetObject("_150512"), 202);
            Addmapp((Bitmap)Properties.Resources.ResourceManager.GetObject("_150527"), 213);
            Addmapp((Bitmap)Properties.Resources.ResourceManager.GetObject("_1505271"), 213);
            Addmapp((Bitmap)Properties.Resources.ResourceManager.GetObject("_1505272"), 213);
            Addmapp((Bitmap)Properties.Resources.ResourceManager.GetObject("_151010"), 260);
            Addmapp((Bitmap)Properties.Resources.ResourceManager.GetObject("_151011"), 261);
            Addmapp((Bitmap)Properties.Resources.ResourceManager.GetObject("_151231"), 308);
            Addmapp((Bitmap)Properties.Resources.ResourceManager.GetObject("_160524"), 389);
            Addmapp((Bitmap)Properties.Resources.ResourceManager.GetObject("_160525"), 390);
            Addmapp((Bitmap)Properties.Resources.ResourceManager.GetObject("_1605251"), 390);

        }
        private void InitPanel()
        {
            this.img1 = new AntiFlashPanel();
            this.img2 = new AntiFlashPanel();
            this.img3 = new AntiFlashPanel();
            this.img4 = new AntiFlashPanel();
            this.toppanel = new AntiFlashPanel();
            this.backpanel = new AntiFlashPanel();
            img1.BackColor = System.Drawing.Color.Transparent;
            img2.BackColor = System.Drawing.Color.Transparent;
            img3.BackColor = System.Drawing.Color.Transparent;
            img4.BackColor = System.Drawing.Color.Transparent;
            toppanel.BackColor = System.Drawing.Color.Transparent;

            img1.Click += new System.EventHandler(img1_MouseClick);
            img2.Click += new System.EventHandler(img2_MouseClick);
            img3.Click += new System.EventHandler(img3_MouseClick);
            img4.Click += new System.EventHandler(img4_MouseClick);
            backpanel.Click += new System.EventHandler(back_MouseClick);
            toppanel.Click += new System.EventHandler(back_MouseClick);

            backpanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            toppanel.Location = new System.Drawing.Point(0, 0);
            toppanel.Size = new System.Drawing.Size(1120, 630);
        }
        private void UpdatePanel(AntiFlashPanel panel,mapp p,int x,int y)
        {
            panel.Location = new System.Drawing.Point((int)((x - p.img.Width / 2) * 0.7), (int)((y - p.img.Height / 2) * 0.7));
            panel.Size = new System.Drawing.Size((int)(p.img.Width * 0.7), (int)(p.img.Height * 0.7));
        }
        int oldw, oldh, neww, newh, oldx, oldy, newx, newy, time=0;
        private void UpdatePanelSrc(mapp p)
        {
            int w = p.srcimg.Width;
            int h = p.srcimg.Height;
            double div = 1.0 * w / h;
            newh = 472;
            neww = (int)(newh * div);
            backpanel.Location = new System.Drawing.Point(oldx,oldy);
            newx = 560 - neww / 2;
            newy = 315 - newh / 2;
            backpanel.Size = new System.Drawing.Size(oldw, oldh);
            backpanel.BackgroundImage = p.srcimg;
        }
        private void time_Tick(object sender,EventArgs e)
        {
            int tpx = (oldx - newx) / 10;
            int tpy = (oldy - newy) / 10;
            backpanel.Location = new Point(backpanel.Location.X - tpx, backpanel.Location.Y - tpy);
            int tpw = (oldw - neww) / 10;
            int tph = (oldh - newh) / 10;
            backpanel.Size = new Size(backpanel.Size.Width - tpw, backpanel.Size.Height - tph);
            time++;
            if (time == 10)
            {
                timer.Stop();
                time = 0;
            }
        }
        public void Addpanel(Panel parent)
        {
            papa = parent;
            UpdatePanel(img1, p1, x1, y1);
            UpdatePanel(img2, p2, x2, y1);
            UpdatePanel(img3, p3, x1, y2);
            UpdatePanel(img4, p4, x2, y2);
            if(v1>0) parent.Controls.Add(img1);
            if(v2>0) parent.Controls.Add(img2);
            if(v3>0) parent.Controls.Add(img3);
            if(v4>0) parent.Controls.Add(img4);
        }
        public void Removepanel(Panel parent)
        {
            parent.Controls.Remove(img1);
            parent.Controls.Remove(img2);
            parent.Controls.Remove(img3);
            parent.Controls.Remove(img4);
            parent.Controls.Remove(backpanel);
            parent.Controls.Remove(toppanel);
        }
        private void img1_MouseClick(object sender, EventArgs e)
        {
            oldx = img1.Location.X;
            oldy = img1.Location.Y;
            oldw = img1.Size.Width;
            oldh = img1.Size.Height;
            UpdatePanelSrc(p1);
            papa.Controls.Add(toppanel);
            toppanel.BringToFront();
            papa.Controls.Add(backpanel);
            backpanel.BringToFront();
            timer.Enabled = true;
            timer.Start();
        }
        private void img2_MouseClick(object sender, EventArgs e)
        {
            oldx = img2.Location.X;
            oldy = img2.Location.Y;
            oldw = img2.Size.Width;
            oldh = img2.Size.Height;
            UpdatePanelSrc(p2);
            papa.Controls.Add(toppanel);
            toppanel.BringToFront();
            papa.Controls.Add(backpanel);
            backpanel.BringToFront();
            timer.Enabled = true;
            timer.Start();

        }
        private void img3_MouseClick(object sender, EventArgs e)
        {
            oldx = img3.Location.X;
            oldy = img3.Location.Y;
            oldw = img3.Size.Width;
            oldh = img3.Size.Height;
            UpdatePanelSrc(p3);
            papa.Controls.Add(toppanel);
            toppanel.BringToFront();
            papa.Controls.Add(backpanel);
            backpanel.BringToFront();
            timer.Enabled = true;
            timer.Start();
        }
        private void img4_MouseClick(object sender, EventArgs e)
        {
            oldx = img4.Location.X;
            oldy = img4.Location.Y;
            oldw = img4.Size.Width;
            oldh = img4.Size.Height;
            UpdatePanelSrc(p4);
            papa.Controls.Add(toppanel);
            toppanel.BringToFront();
            papa.Controls.Add(backpanel);
            backpanel.BringToFront();
            timer.Enabled = true;
            timer.Start();
        }
        private void back_MouseClick(object sender, EventArgs e)
        {
            papa.Controls.Remove(backpanel);
            papa.Controls.Remove(toppanel);
        }
        public int totPage
        {
            get { return list.Count / 4 + (list.Count % 4 > 0 ? 1 : 0); }
        }
        private AntiFlashPanel backpanel, img1, img2, img3, img4,toppanel;

        public int UnlockCount()
        {
            int res = 0;
            for(int i = 0; i < list.Count; i++)
            {
                if (rm.Query(list[i].index)) res++;
            }
            return res;
        }
        //*/
    }
}
