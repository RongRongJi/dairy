namespace Dairy1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {

            CheckForIllegalCrossThreadCalls = false;
            //主窗体
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "班级日记";
            this.Name = "Form1";
            this.ClientSize = new System.Drawing.Size(1120, 630);
            this.Load += new System.EventHandler(this.Form1_Load);

            //后景层
            this.backpanel = new AntiFlashPanel();
            this.backpanel.Location = new System.Drawing.Point(0, 0);
            this.backpanel.Size = new System.Drawing.Size(1120, 630);
            this.backpanellast = new AntiFlashPanel();
            this.backpanellast.Location = new System.Drawing.Point(0, 0);
            this.backpanellast.Size = new System.Drawing.Size(1120, 630);

            //前景层
            this.forepanel = new AntiFlashPanel();
            this.forepanel.Location = new System.Drawing.Point(0, 0);
            this.forepanel.Size = new System.Drawing.Size(1120, 630);

            //菜单层
            this.menupanel = new BackgroundPanel();
            //this.menupanel.Location = new System.Drawing.Point(910, 315);
            //this.menupanel.Size = new System.Drawing.Size(210, 315);

            //书签层
            this.markpanel = new AntiFlashPanel();
            this.markpanel.Location = new System.Drawing.Point(0, 0);
            this.markpanel.Size = new System.Drawing.Size(1120, 630);

            //寻找书签
            this.findMark = new System.Windows.Forms.Button();
            this.findMark.BackColor = System.Drawing.Color.Transparent;
            this.findMark.BackgroundImage = global::Dairy1.Properties.Resources.tb_bookmark1;
            this.findMark.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.findMark.FlatAppearance.BorderSize = 0;
            this.findMark.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.findMark.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.findMark.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.findMark.Location = new System.Drawing.Point(230, 230);
            this.findMark.Size = new System.Drawing.Size(208, 33);
            this.findMark.Click += new System.EventHandler(this.findmark_Click);
            this.findMark.MouseEnter += new System.EventHandler(this.findmark_MouseEnter);
            this.findMark.MouseLeave += new System.EventHandler(this.findmark_MouseLeave);

            //翻开日记按钮
            this.startbutton = new System.Windows.Forms.Button();
            this.startbutton.BackColor = System.Drawing.Color.Transparent;
            this.startbutton.BackgroundImage = global::Dairy1.Properties.Resources.tb_diary1;
            this.startbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.startbutton.FlatAppearance.BorderSize = 0;
            this.startbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startbutton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.startbutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.startbutton.Location = new System.Drawing.Point(230, 150);
            this.startbutton.Size = new System.Drawing.Size(208, 33);
            this.startbutton.Click += new System.EventHandler(this.startbutton_Click);
            this.startbutton.MouseEnter += new System.EventHandler(this.startbutton_MouseEnter);
            this.startbutton.MouseLeave += new System.EventHandler(this.startbutton_MouseLeave);

            //查看日历
            this.openCalendar = new System.Windows.Forms.Button();
            this.openCalendar.BackColor = System.Drawing.Color.Transparent;
            this.openCalendar.BackgroundImage = global::Dairy1.Properties.Resources.tb_calendar1;
            this.openCalendar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.openCalendar.FlatAppearance.BorderSize = 0;
            this.openCalendar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openCalendar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.openCalendar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.openCalendar.Location = new System.Drawing.Point(230, 310);
            this.openCalendar.Size = new System.Drawing.Size(208, 33);
            this.openCalendar.Click += new System.EventHandler(this.openCalendar_Click);
            this.openCalendar.MouseEnter += new System.EventHandler(this.openCalendar_MouseEnter);
            this.openCalendar.MouseLeave += new System.EventHandler(this.openCalendar_MouseLeave);

            //查看其他
            this.others = new System.Windows.Forms.Button();
            this.others.BackColor = System.Drawing.Color.Transparent;
            this.others.BackgroundImage = global::Dairy1.Properties.Resources.tb_extra;
            this.others.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.others.FlatAppearance.BorderSize = 0;
            this.others.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.others.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.others.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.others.Location = new System.Drawing.Point(230, 390);
            this.others.Size = new System.Drawing.Size(208, 33);
            this.others.Click += new System.EventHandler(this.others_Click);
            this.others.MouseEnter += new System.EventHandler(this.others_MouseEnter);
            this.others.MouseLeave += new System.EventHandler(this.others_MouseLeave);

            //退出按钮
            this.exitbutton = new System.Windows.Forms.Button();
            this.exitbutton.BackColor = System.Drawing.Color.Transparent;
            this.exitbutton.BackgroundImage = global::Dairy1.Properties.Resources.tb_exit1;
            this.exitbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exitbutton.FlatAppearance.BorderSize = 0;
            this.exitbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitbutton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.exitbutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.exitbutton.Location = new System.Drawing.Point(230, 470);
            this.exitbutton.Size = new System.Drawing.Size(208, 33);
            this.exitbutton.Click += new System.EventHandler(this.exitbutton_Click);
            this.exitbutton.MouseEnter += new System.EventHandler(this.exitbutton_MouseEnter);
            this.exitbutton.MouseLeave += new System.EventHandler(this.exitbutton_MouseLeave);

            //下一页
            this.nextpage = new System.Windows.Forms.Button();
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
            this.lastpage = new System.Windows.Forms.Button();
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

            //日历定位
            this.locate_for_cale = new System.Windows.Forms.Button();
            this.locate_for_cale.BackColor = System.Drawing.Color.Transparent;
            this.locate_for_cale.FlatAppearance.BorderSize = 0;
            this.locate_for_cale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.locate_for_cale.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.locate_for_cale.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.locate_for_cale.Location = new System.Drawing.Point(154, 151);
            this.locate_for_cale.Size = new System.Drawing.Size(805, 423); 
            this.locate_for_cale.Click += new System.EventHandler(this.locate_for_cale_Click);

            //下一日历
            this.nextcale = new System.Windows.Forms.Button();
            this.nextcale.BackColor = System.Drawing.Color.Transparent;
            this.nextcale.BackgroundImage = global::Dairy1.Properties.Resources.next1;
            this.nextcale.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.nextcale.FlatAppearance.BorderSize = 0;
            this.nextcale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextcale.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.nextcale.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.nextcale.Location = new System.Drawing.Point(1000, 530);
            this.nextcale.Size = new System.Drawing.Size(115, 27);
            this.nextcale.Click += new System.EventHandler(this.nextcale_Click);
            this.nextcale.MouseEnter += new System.EventHandler(this.nextcale_MouseEnter);
            this.nextcale.MouseLeave += new System.EventHandler(this.nextcale_MouseLeave);
            this.nextcale.Name = "nextcale";

            //上一日历
            this.lastcale = new System.Windows.Forms.Button();
            this.lastcale.BackColor = System.Drawing.Color.Transparent;
            this.lastcale.BackgroundImage = global::Dairy1.Properties.Resources.last1;
            this.lastcale.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lastcale.FlatAppearance.BorderSize = 0;
            this.lastcale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lastcale.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.lastcale.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.lastcale.Location = new System.Drawing.Point(5, 530);
            this.lastcale.Size = new System.Drawing.Size(115, 27);
            this.lastcale.Click += new System.EventHandler(this.lastcale_Click);
            this.lastcale.MouseEnter += new System.EventHandler(this.lastcale_MouseEnter);
            this.lastcale.MouseLeave += new System.EventHandler(this.lastcale_MouseLeave);
            this.lastcale.Name = "lastcale";

            //For MenuPanel
            this.menupanel.Location = new System.Drawing.Point(1093, 315);           
            this.menupanel.Size = new System.Drawing.Size(190, 315);
            this.menupanel.MouseEnter += new System.EventHandler(this.menubutton_MouseEnter);
            this.menupanel.MouseLeave+= new System.EventHandler(this.menubutton_MouseLeave);

            this.time1 = new System.Windows.Forms.Timer();
            this.time1.Interval = 5;
            this.time1.Tick += new System.EventHandler(this.Time_Tick);
            this.time2 = new System.Windows.Forms.Timer();
            this.time2.Interval = 5;
            this.time2.Tick += new System.EventHandler(this.Time_Tick2);

            this.addmark = new ImageButton();
            this.addmark.BackColor = System.Drawing.Color.Transparent;
            this.addmark.BackgroundImage = global::Dairy1.Properties.Resources.menu_button1_s;
            this.addmark.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addmark.FlatAppearance.BorderSize = 0;
            this.addmark.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addmark.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.addmark.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.addmark.Location = new System.Drawing.Point(65, 150);
            this.addmark.Size = new System.Drawing.Size(98, 28);
            this.addmark.Click += new System.EventHandler(this.addmark_Click);
            this.addmark.MouseEnter += new System.EventHandler(this.addmark_MouseEnter);
            this.addmark.MouseLeave += new System.EventHandler(this.addmark_MouseLeave);

            this.loadmark = new ImageButton();
            this.loadmark.BackColor = System.Drawing.Color.Transparent;
            this.loadmark.BackgroundImage = global::Dairy1.Properties.Resources.menu_button2_s;
            this.loadmark.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.loadmark.FlatAppearance.BorderSize = 0;
            this.loadmark.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadmark.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.loadmark.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.loadmark.Location = new System.Drawing.Point(65, 180);
            this.loadmark.Size = new System.Drawing.Size(98, 28);
            this.loadmark.Click += new System.EventHandler(this.loadmark_Click);
            this.loadmark.MouseEnter += new System.EventHandler(this.loadmark_MouseEnter);
            this.loadmark.MouseLeave += new System.EventHandler(this.loadmark_MouseLeave);

            this.calendar = new ImageButton();
            this.calendar.BackColor = System.Drawing.Color.Transparent;
            this.calendar.BackgroundImage = global::Dairy1.Properties.Resources.menu_button3_s;
            this.calendar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.calendar.FlatAppearance.BorderSize = 0;
            this.calendar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.calendar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.calendar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.calendar.Location = new System.Drawing.Point(65, 210);
            this.calendar.Size = new System.Drawing.Size(98, 28);
            this.calendar.Click += new System.EventHandler(this.calendar_Click);
            this.calendar.MouseEnter += new System.EventHandler(this.calendar_MouseEnter);
            this.calendar.MouseLeave += new System.EventHandler(this.calendar_MouseLeave);

            this.title = new ImageButton();
            this.title.BackColor = System.Drawing.Color.Transparent;
            this.title.BackgroundImage = global::Dairy1.Properties.Resources.menu_button4_s;
            this.title.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.title.FlatAppearance.BorderSize = 0;
            this.title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.title.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.title.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.title.Location = new System.Drawing.Point(65, 240);
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
            this.exit2.Location = new System.Drawing.Point(65, 270);
            this.exit2.Size = new System.Drawing.Size(98, 28);
            this.exit2.Click += new System.EventHandler(this.exitbutton_Click);
            this.exit2.MouseEnter += new System.EventHandler(this.exit2_MouseEnter);
            this.exit2.MouseLeave += new System.EventHandler(this.exit2_MouseLeave);

            this.mark1s = new ImageButton();
            this.mark1s.BackColor = System.Drawing.Color.Transparent;
            this.mark1s.BackgroundImage = global::Dairy1.Properties.Resources.bm_1nf;
            this.mark1s.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mark1s.FlatAppearance.BorderSize = 0;
            this.mark1s.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mark1s.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.mark1s.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.mark1s.Location = new System.Drawing.Point(200, 100);
            this.mark1s.Size = new System.Drawing.Size(175, 427);
            this.mark1s.Click += new System.EventHandler(this.mark1s_Click);
            this.mark1s.MouseEnter += new System.EventHandler(this.mark1s_MouseEnter);
            this.mark1s.MouseLeave += new System.EventHandler(this.mark1s_MouseLeave);

            this.mark2s = new ImageButton();
            this.mark2s.BackColor = System.Drawing.Color.Transparent;
            this.mark2s.BackgroundImage = global::Dairy1.Properties.Resources.bm_2nf;
            this.mark2s.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mark2s.FlatAppearance.BorderSize = 0;
            this.mark2s.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mark2s.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.mark2s.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.mark2s.Location = new System.Drawing.Point(500, 100);
            this.mark2s.Size = new System.Drawing.Size(175, 427);
            this.mark2s.Click += new System.EventHandler(this.mark2s_Click);
            this.mark2s.MouseEnter += new System.EventHandler(this.mark2s_MouseEnter);
            this.mark2s.MouseLeave += new System.EventHandler(this.mark2s_MouseLeave);

            this.mark3s = new ImageButton();
            this.mark3s.BackColor = System.Drawing.Color.Transparent;
            this.mark3s.BackgroundImage = global::Dairy1.Properties.Resources.bm_3nf;
            this.mark3s.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mark3s.FlatAppearance.BorderSize = 0;
            this.mark3s.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mark3s.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.mark3s.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.mark3s.Location = new System.Drawing.Point(800, 100);
            this.mark3s.Size = new System.Drawing.Size(175, 427);
            this.mark3s.Click += new System.EventHandler(this.mark3s_Click);
            this.mark3s.MouseEnter += new System.EventHandler(this.mark3s_MouseEnter);
            this.mark3s.MouseLeave += new System.EventHandler(this.mark3s_MouseLeave);

            this.mark1l = new ImageButton();
            this.mark1l.BackColor = System.Drawing.Color.Transparent;
            this.mark1l.BackgroundImage = global::Dairy1.Properties.Resources.bm_1yf;
            this.mark1l.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mark1l.FlatAppearance.BorderSize = 0;
            this.mark1l.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mark1l.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.mark1l.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.mark1l.Location = new System.Drawing.Point(200, 100);
            this.mark1l.Size = new System.Drawing.Size(175, 427);
            this.mark1l.Click += new System.EventHandler(this.mark1l_Click);
            this.mark1l.MouseEnter += new System.EventHandler(this.mark1l_MouseEnter);
            this.mark1l.MouseLeave += new System.EventHandler(this.mark1l_MouseLeave);
        
            this.mark2l = new ImageButton();
            this.mark2l.BackColor = System.Drawing.Color.Transparent;
            this.mark2l.BackgroundImage = global::Dairy1.Properties.Resources.bm_2yf;
            this.mark2l.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mark2l.FlatAppearance.BorderSize = 0;
            this.mark2l.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mark2l.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.mark2l.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.mark2l.Location = new System.Drawing.Point(500, 100);
            this.mark2l.Size = new System.Drawing.Size(175, 427);
            this.mark2l.Click += new System.EventHandler(this.mark2l_Click);
            this.mark2l.MouseEnter += new System.EventHandler(this.mark2l_MouseEnter);
            this.mark2l.MouseLeave += new System.EventHandler(this.mark2l_MouseLeave);

            this.mark3l = new ImageButton();
            this.mark3l.BackColor = System.Drawing.Color.Transparent;
            this.mark3l.BackgroundImage = global::Dairy1.Properties.Resources.bm_3yf;
            this.mark3l.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mark3l.FlatAppearance.BorderSize = 0;
            this.mark3l.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mark3l.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.mark3l.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.mark3l.Location = new System.Drawing.Point(800, 100);
            this.mark3l.Size = new System.Drawing.Size(175, 427);
            this.mark3l.Click += new System.EventHandler(this.mark3l_Click);
            this.mark3l.MouseEnter += new System.EventHandler(this.mark3l_MouseEnter);
            this.mark3l.MouseLeave += new System.EventHandler(this.mark3l_MouseLeave);

            this.markpanel.Click+= new System.EventHandler(this.exitmark_Click);

            this.marklbl= new System.Windows.Forms.Label();
            this.marklbl.BackColor = System.Drawing.Color.Transparent;
            this.marklbl.Location = new System.Drawing.Point(700, 10);
            this.marklbl.Size = new System.Drawing.Size(300, 60);
            this.marklbl.Text = "";
            this.marklbl.Font = new System.Drawing.Font("宋体", 15, System.Drawing.FontStyle.Bold);

        }

        #endregion
        public AntiFlashPanel backpanel;                //下一页后景层
        public AntiFlashPanel backpanellast;            //上一页后景层
        public AntiFlashPanel forepanel;                //前景层
        public BackgroundPanel menupanel;               //菜单层
        public AntiFlashPanel markpanel;               //书签层
        public System.Windows.Forms.Button startbutton; //翻开日记
        public System.Windows.Forms.Button exitbutton;  //退出
        public System.Windows.Forms.Button others; //其他内容
        public System.Windows.Forms.Button openCalendar; //查看日历
        public System.Windows.Forms.Button findMark; //寻找书签




        public System.Windows.Forms.Button nextpage;    //下一页
        public System.Windows.Forms.Button lastpage;    //上一页
        public System.Windows.Forms.Button locate_for_cale;    //日历定位
        public System.Windows.Forms.Button nextcale;    //下一页
        public System.Windows.Forms.Button lastcale;    //上一页
        
        //For MenuPanel
        public System.Windows.Forms.Timer time1;
        public System.Windows.Forms.Timer time2;
        public ImageButton addmark;
        public ImageButton loadmark;
        public ImageButton calendar;    //日历
        public ImageButton title;
        public ImageButton exit2;
        public ImageButton mark1s, mark2s, mark3s;
        public ImageButton mark1l, mark2l, mark3l;
        public int markstate;
        public System.Windows.Forms.Label marklbl;
        //menupanel.BringToFront
    }
}
