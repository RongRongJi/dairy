using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Dairy1
{
    public class TurnPage
    {
        private int visibleSizeX = 1120;    //窗口高
        private int visibleSizeY = 630;     //窗口宽
        private int pageHeight = 620;       //页高
        private int pageWidth = 434;        //页宽
        private int left = 130;             //书页与左边距离
        private int up = 8;                 //书页与顶端距离
        //private int pagemid = 2;//页缝距
        private Bitmap bmleft;              //翻页的背面
        private Bitmap bmright;             //翻页呈现的页
        public AntiFlashPanel PageAnimate = new AntiFlashPanel();   //翻页panel
        private AntiFlashPanel pageback = new AntiFlashPanel();     //翻页的背面
        private BackgroundPanel pagebackParent = new BackgroundPanel();
        private BackgroundPanel pageforeParent = new BackgroundPanel();
        private AntiFlashPanel pagefore = new AntiFlashPanel();     //翻页呈现的页面
        private AntiFlashPanel shadow = new AntiFlashPanel();       //阴影
        public Timer time;                  //计时器
        public Timer timelast;              //计时器
        private int calTime = 0;            //下一页计数器
        private int calTimelast = 0;        //上一页计数器
        //private Form1 form;
        public Panel forepanel;
        public Panel backpanel;
        public Panel backpanellast;

        //构造函数
        public TurnPage()
        {
            //this.form = form;
            pageback.Size = new Size(pageWidth, pageHeight);
            pagefore.Size = new Size(pageWidth, pageHeight);
            pagebackParent.Controls.Add(pageback);
            pageforeParent.Controls.Add(pagefore);
            PageAnimate.Controls.Add(pageforeParent);
            PageAnimate.Controls.Add(pagebackParent);
            time = new Timer();
            time.Tick += new EventHandler(time_Tick);
            timelast = new Timer();
            timelast.Tick += new EventHandler(timelast_Tick);
            time.Interval = 10;
            timelast.Interval = 10;
        }

        //截取图片
        private Bitmap CopyImage(Bitmap bt, int x, int y, int width, int height)
        {
            AntiFlashPanel panel3 = new AntiFlashPanel();
            panel3.Size = new Size(width, height);
            panel3.Location = new Point(0, 0);
            AntiFlashPanel panel4 = new AntiFlashPanel();
            panel4.Size = new Size(bt.Width, bt.Height);
            panel4.BackgroundImage = bt;
            panel4.Location = new Point(-x, -y);
            panel3.Controls.Add(panel4);
            Bitmap bm = new Bitmap(width, height);
            Rectangle rec = new Rectangle(0, 0, width, height);
            panel3.DrawToBitmap(bm, rec);//耗时
            panel3.Dispose();
            return bm;
        }

        //预处理
        public void PreLoad(Panel backpanel)
        {
            PageAnimate.Size = new Size(visibleSizeX, visibleSizeY);
            PageAnimate.Location = new Point(0, 0);
            PageAnimate.BackgroundImageLayout = ImageLayout.Stretch;
            PageAnimate.BackgroundImage = forepanel.BackgroundImage;
            Bitmap bm = new Bitmap(backpanel.Width, backpanel.Height);
            Rectangle rec = new Rectangle(0, 0, backpanel.Width, backpanel.Height);
            backpanel.DrawToBitmap(bm, rec);//耗时
            //翻页的背面
            bmleft = CopyImage(bm, left, up, pageWidth, pageHeight);
            //翻页呈现的页
            bmright = CopyImage(bm, left + pageWidth, up, pageWidth, pageHeight);
        }

        private int[] Fibonacci = { 3, 8, 16, 29, 50, 71, 84, 92, 97, 100 };

        //翻页
        private void GetNextPage(int percent,Panel forepanel)
        {
            //计算位置
            int width = (int)(pageWidth * (percent / 100.0));
            int height = pageHeight;
            int positionY = up;
            int positionX = left + pageWidth * 2 - width;
            //创建呈现页面
            pageback.BackgroundImage = bmleft;
            pageback.Location = new Point(0, 0);
            pagefore.BackgroundImage = bmright;
            pagefore.Location = new Point(width - pageWidth, 0);
            pagebackParent.Size = new Size(width, height);
            pagebackParent.Location = new Point(positionX - width, positionY);
            pageforeParent.Size = new Size(width, height);
            pageforeParent.Location = new Point(positionX, positionY);
            //检查代码
            Bitmap bm = new Bitmap(PageAnimate.Width, PageAnimate.Height);
            Rectangle rec = new Rectangle(0, 0, PageAnimate.Width, PageAnimate.Height);
            PageAnimate.DrawToBitmap(bm, rec);
            forepanel.BackgroundImage = bm;

        }
        private int preloadNum = 0;
        Image[] shadows =
        {
            Properties.Resources.shadow0,Properties.Resources.shadow1,
            Properties.Resources.shadow2,Properties.Resources.shadow3,
            Properties.Resources.shadow4,Properties.Resources.shadow5,
            Properties.Resources.shadow6,Properties.Resources.shadow7,
            Properties.Resources.shadow8
        };
        private void GetNextPage(int percent, Panel backpanel,Panel forepanel)
        {
            
            if(preloadNum == 0)
            {
                //forepanel.Controls.Add(PageAnimate);
                
            }
            GetNextPage(percent, forepanel);
            if (preloadNum < 9)
            {
                shadow.Size = new Size(visibleSizeX, visibleSizeY);
                shadow.Location = new Point(0, 0);
                shadow.BackColor = Color.Transparent;
                shadow.BackgroundImage = shadows[preloadNum];
                forepanel.Controls.Add(shadow);
                shadow.BringToFront();
                preloadNum++;
            }
            else
            {
                preloadNum = 0;
                forepanel.Controls.Remove(shadow);
                //forepanel.Controls.Remove(PageAnimate);
                //后景层设置为前景层
                forepanel.BackgroundImage = backpanel.BackgroundImage;
            }
        }

        //计时器
        private void time_Tick(object sender, EventArgs e)
        {
            //加载
            if (calTime == 0)
            {
                PreLoad(backpanel);
            }
            int max = Fibonacci.Length;
            //翻页函数
            GetNextPage(Fibonacci[calTime], backpanel, forepanel);
            calTime++;//计数器自增 0到10
            if (calTime >= max)
            {
                calTime = 0;
                time.Stop();
            }
        }

        private int[] FibonacciLast = { 97, 92, 84, 71, 50, 29, 16, 8, 3, 0 };
        private int preloadNumlast = 8;
        //预处理
        public void PreLoadlist(Panel forepanel)
        {
            PageAnimate.Size = new Size(visibleSizeX, visibleSizeY);
            PageAnimate.Location = new Point(0, 0);
            PageAnimate.BackgroundImageLayout = ImageLayout.Stretch;
            PageAnimate.BackgroundImage = backpanellast.BackgroundImage;
            Bitmap bm = new Bitmap(forepanel.Width, forepanel.Height);
            Rectangle rec = new Rectangle(0, 0, forepanel.Width, forepanel.Height);
            forepanel.DrawToBitmap(bm, rec);//耗时
            //翻页的背面
            bmleft = CopyImage(bm, left, up, pageWidth, pageHeight);
            //翻页呈现的页
            bmright = CopyImage(bm, left + pageWidth, up, pageWidth, pageHeight);
        }
        private void GetLastPage(int percent, Panel backpanel, Panel forepanel)
        {
            GetNextPage(percent, forepanel);
            if (preloadNumlast >= 0)
            {
                shadow.Size = new Size(visibleSizeX, visibleSizeY);
                shadow.Location = new Point(0, 0);
                shadow.BackColor = Color.Transparent;
                shadow.BackgroundImage = shadows[preloadNumlast];
                //shadow.BackgroundImage = Image.FromFile("shadow" + preloadNumlast + ".png");
                shadow.BringToFront();
                forepanel.Controls.Add(shadow);
                preloadNumlast--;
            }
            else
            {
                preloadNumlast = 8;
                forepanel.Controls.Remove(shadow);
                //forepanel.Controls.Remove(PageAnimate);
                //后景层设置为前景层
                forepanel.BackgroundImage = backpanel.BackgroundImage;
            }
        }

        //翻上页计时器
        private void timelast_Tick(object sender, EventArgs e)
        {
            //加载
            if (calTimelast == 0)
            {
                PreLoadlist(forepanel);
            }
            int max = FibonacciLast.Length;
            //翻页函数，preMaps是预加载的图片数组，forepanel是前景层
            GetLastPage(FibonacciLast[calTimelast], backpanellast, forepanel);
            calTimelast++;//计数器自增 0到10
            if (calTimelast >= max)
            {
                calTimelast = 0;
                timelast.Stop();
            }
        }
    }
}
