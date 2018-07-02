using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Timers;

namespace Dairy1
{
    /*
      LoadingPanel lp = LoadingPanel.GetLoadPage();
      lp.setLoadPage=0;
      f.Controls.Add(lp);
      lp.BringToFront(); 
      其中f是form窗体，setLoadPage能set显示的图片
      set0显示解锁图片，set1显示解锁音乐
     */

    /// <summary>
    /// 透明的加载等待层
    /// </summary>
    [ToolboxBitmap(typeof(LoadingPanel))]
    public class LoadingPanel : Panel
    {
        // 透明度
        private int _alpha = 0;
        // 容器组件
        private System.ComponentModel.Container components = new System.ComponentModel.Container();


        private static bool _isActive = false;
        private static LoadingPanel _pool = null;

        private const int width = 1120, height = 630;
        private Panel[] LoadPicture = new Panel[4];

        private Thread runningThread;
        CancellationTokenSource cts = new CancellationTokenSource();

        private System.Timers.Timer releaseTimer = null;

        // 标准构造函数
        private LoadingPanel()
        {
            // | ControlStyles.OptimizedDoubleBuffer AllPaintingInWmPaint
            SetStyle(ControlStyles.Opaque | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            Size = new Size(1120, 630);

            base.CreateControl();
            // 显示等待的图像
            PictureBoxEx pictureBox_Loading = new PictureBoxEx();
            pictureBox_Loading.Click += new System.EventHandler(LoadPanel_Click);
            pictureBox_Loading.BackgroundImage = global::Dairy1.Properties.Resources.loadshadow;
            pictureBox_Loading.Size = new Size(1120, 630);
            pictureBox_Loading.Location = new Point(0, 0);
            this.Controls.Add(pictureBox_Loading);

            //初始化
            runningThread = new Thread(Run);

            for (int i = 0; i < 4; i++)
            {
                LoadPicture[i] = new AntiFlashPanel
                {
                    Size = new Size(448, 210),
                    Location = new Point(336, 180),
                    Visible = false,
                    BackgroundImageLayout = ImageLayout.Stretch,
                };
            }
            LoadPicture[0].BackgroundImage = global::Dairy1.Properties.Resources.load4;
            LoadPicture[1].BackgroundImage = global::Dairy1.Properties.Resources.load5;
            LoadPicture[2].BackgroundImage = global::Dairy1.Properties.Resources.load6;
            LoadPicture[3].BackgroundImage = global::Dairy1.Properties.Resources.load3;

            for (int i = 0; i < 4; i++)
                Controls.Add(LoadPicture[i]);

            LoadPicture[0].Visible = true;

        }

        // 析构处理
        protected override void Dispose(bool disposing)
        {
            if (releaseTimer != null)
            {
                releaseTimer.Stop();
                releaseTimer.Dispose();
            }
            if (runningThread.IsAlive)
            {
                Stop();
                while (runningThread.IsAlive) ;
            }
            for (int i = 0; i < 4; i++)
                LoadPicture[i].Dispose();

            if (disposing)
            {
                if (!((components == null)))
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
            _pool = null;
        }



        public void Start()
        {
            //如果线程正在运行，则返回
            if (_isActive)
                return;
            BringToFront();
            Show();
            _isActive = true;
            runningThread.Start();
        }

        public void Stop()
        {
            //如果线程不在运行，则返回
            if (_isActive == false)
                return;
            cts.Cancel();
            //等待线程停止
            while (runningThread.IsAlive) ;
            _isActive = false;
        }

        public void Release()
        {
            //删除LoadPage释放内存
            if (_pool == null || _isActive == true)
                return;
            if (releaseTimer != null)
            {
                releaseTimer.Stop();
                releaseTimer.Dispose();
            }
            releaseTimer = new System.Timers.Timer(10000);
            releaseTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            releaseTimer.AutoReset = false;
            releaseTimer.Enabled = true;

        }

        private delegate void DisposeCallBack();
        private void OnTimedEvent(Object source, ElapsedEventArgs e) =>
            this.Invoke(new DisposeCallBack(Dispose), new object[] { });

        private delegate void SetVisibleCallBack(int i, bool visible);

        private void SetVisible(int i, bool visible)
        {
            if (this.LoadPicture[i].InvokeRequired)
            {
                SetVisibleCallBack s = new SetVisibleCallBack(SetVisible);
                this.Invoke(s, new object[] { i, visible });
            }
            else
            {
                LoadPicture[i].Visible = visible;
            }
        }

        public void Run()
        {
            int now = 0, last = 3, timemarker = 20;
            while (!cts.Token.IsCancellationRequested && _pool != null)
            {
                if (timemarker >= 20)
                {
                    SetVisible(now, true);
                    SetVisible(last, false);
                    timemarker = 0;
                    last = now;
                    now = (now + 1) % 4;
                }
                timemarker++;
                Thread.Sleep(10);
            }
        }

        public static bool IsActive()
        {
            return _isActive;
        }

        public int setLoadPage
        {
            set
            {
                for (int i = 0; i < 4; i++)
                {
                    LoadPicture[i].Visible = false;
                }
                LoadPicture[value].Visible = true;
            }
        }

        public static LoadingPanel GetLoadPage()
        {
            if (_pool == null)
            {
                _pool = new LoadingPanel();
            }
            else
            {
                if (_pool.releaseTimer != null)
                {
                    _pool.releaseTimer.Stop();
                    _pool.releaseTimer.Dispose();
                    _pool.releaseTimer = null;
                }
            }
            _pool.Visible = true;
            return _pool;
        }

        // 自定义绘制窗体
        protected override void OnPaint(PaintEventArgs e)
        {
            float vlblControlWidth;
            float vlblControlHeight;

            Pen labelBorderPen;
            SolidBrush labelBackColorBrush;

            Color drawColor = Color.FromArgb(this._alpha, this.BackColor);
            labelBorderPen = new Pen(drawColor, 0);
            labelBackColorBrush = new SolidBrush(drawColor);
            vlblControlWidth = this.Size.Width;
            vlblControlHeight = this.Size.Height;
            e.Graphics.DrawRectangle(labelBorderPen, 0, 0, vlblControlWidth, vlblControlHeight);
            e.Graphics.FillRectangle(labelBackColorBrush, 0, 0, vlblControlWidth, vlblControlHeight);

            base.OnPaint(e);
        }

        private void LoadPanel_Click(object sender, EventArgs e)
        {
            _pool.Visible = false;
            _pool.Release();
        }
    }
}
