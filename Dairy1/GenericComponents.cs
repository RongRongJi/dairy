using System;
using System.Drawing;
using System.Windows.Forms;

namespace Dairy1
{
    public class AntiFlashPanel : Panel
    {
        public AntiFlashPanel()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
        }
    }

    public class ImageButton : Button
    {
        public ImageButton()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
        }
    }

    /// <summary>
    /// come from:http://blog.csdn.net/cuiyh1993/article/details/42113063
    /// 一个可以支持png透明显示的picturebox
    /// </summary>
    public class PictureBoxEx : Panel
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020;       // 实现透明样式
                return cp;
            }
        }

        public PictureBoxEx()
        {
            SetStyle(ControlStyles.Opaque | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.BackColor = Color.Transparent;
            this.ForeColor = Color.Transparent;
        }
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {

        }
        protected override void OnPaint(PaintEventArgs e)
        {

            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

            int width = this.Width;
            int height = this.Height;
            Rectangle recModel = new Rectangle(0, 0, width, height);
            if (this.BackgroundImage != null)
            {
                e.Graphics.DrawImage(this.BackgroundImage, recModel);
            }
            else if (this.ForeColor != Color.Transparent)
            {
                e.Graphics.Clear(this.ForeColor);
            }
            else if (this.BackColor != Color.Transparent)
            {
                e.Graphics.Clear(this.BackColor);
            }
        }
    }

    public class BackgroundPanel : PictureBoxEx
    {
        private bool isBackChange=true;
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //base.OnPaintBackground(e);

            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

            int width = this.Width;
            int height = this.Height;
            Rectangle recModel = new Rectangle(0, 0, width, height);
            if (this.BackgroundImage != null)
            {
                if (isBackChange)
                {
                    e.Graphics.DrawImage(this.BackgroundImage, recModel);
                    isBackChange = false;
                }
            }
            else if (this.ForeColor != Color.Transparent)
            {
                e.Graphics.Clear(this.ForeColor);
            }
            else if (this.BackColor != Color.Transparent)
            {
                e.Graphics.Clear(this.BackColor);
            }
        }

        public override Image BackgroundImage
        {
            get {return base.BackgroundImage; }
            set
            {
                base.BackgroundImage = value;
                this.isBackChange = true;
            }
        }
    }

    public class AntiFlashPanelEx : BackgroundPanel
    {
        public AntiFlashPanelEx()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
        }
    }
}
