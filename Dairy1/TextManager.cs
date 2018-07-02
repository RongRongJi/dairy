/*
 * 由SharpDevelop创建。
 * 用户： rmdyh
 * 日期: 2018/1/23
 * 时间: 11:21
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;


namespace MR_Text
{

    //读入文本文档并生成pages
    public class TextArea : System.Windows.Forms.Panel
    {

        private List<MessageBoxLayers> Pages;
        private int nowPage = 0;

        public TextArea()
        {
            this.Size = new Size(new Point(1120, 630));
            BackColor = Color.FromArgb(0, 0, 0, 0);
            Pages = new List<MessageBoxLayers>();
            Size = new Size(new Point(1120, 630));
        }

        public void GetFile(string filepath, string textname)
        {
            var fs = new FileStream(filepath + "\\" + textname + ".txt", FileMode.Open);
            var sr = new StreamReader(fs, Encoding.Default);
            var content = sr.ReadToEnd();
            sr.Close();
            fs.Close();

            var page = new MessageBoxLayers();

            while (content.Length != 0)
            {
                var begin = content.IndexOf("<%");
                if (begin == -1)
                {
                    while (content.Length != 0)
                    {
                        if (page.isFull())
                        {
                            Pages.Add(page);
                            page = new MessageBoxLayers();
                        }

                        var usage = page.SetText(content);
                        content = content.Substring(usage, content.Length - usage);
                    }
                }
                else
                {
                    var subcontent = content.Substring(0, begin);
                    content = content.Substring(begin);
                    while (subcontent.Length != 0)
                    {
                        if (page.isFull())
                        {
                            Pages.Add(page);
                            page = new MessageBoxLayers();
                        }

                        var usage = page.SetText(subcontent);
                        subcontent = subcontent.Substring(usage, subcontent.Length - usage);
                    }

                    if (page.isFull())
                    {
                        Pages.Add(page);
                        page = new MessageBoxLayers();
                    }

                    var middle = content.IndexOf("|");
                    var end = content.IndexOf("%>");
                    int line = Convert.ToInt32(content.Substring(middle + 1, end - middle - 1));
                    string imgpath = content.Substring(2, middle - 2);
                    while (!page.SetImage(filepath + "\\" + imgpath, line))
                    {
                        Pages.Add(page);
                        page = new MessageBoxLayers();
                    }
                    content = content.Substring(end + 2);
                }
            }
            Pages.Add(page);

            for (int i = 0; i < Pages.Count; i += 2)
            {
                Pages[i].Location = new Point(130, 10);
                Pages[i].Visible = false;
                this.Controls.Add(Pages[i]);
            }
            for (int i = 1; i < Pages.Count; i += 2)
            {
                Pages[i].Location = new Point(576, 10);
                Pages[i].Visible = false;
                this.Controls.Add(Pages[i]);
            }
        }

        public void shiftPage(int a)
        {
            for (int i = 0; i < Pages.Count; i++)
            {
                if (i == a * 2 - 1 || i == a * 2 - 2)
                    Pages[i].Visible = true;
                else
                    Pages[i].Visible = false;
            }
            if (a <= Pages.Count / 2 + 1 && a > 0)
            {
                nowPage = a;
            }
        }

        protected override void Dispose(bool disposing)
        {
            foreach (Control control in this.Controls)
            {
                control.Dispose();
            }
            base.Dispose(disposing);
        }

        public int PageNumber
        {
            get
            {
                int aaa = (Pages.Count + 1) / 2;
                return (Pages.Count + 1) / 2;
            }
        }

        public int CurrentPage
        {
            get
            {
                return nowPage;
            }
        }
    }


    //一个文本显示框的类
    //处理换行
    public class MessageBoxLayers : System.Windows.Forms.Panel
    {

        //内边距
        const int PADDINGL = 20, PADDINGT = 42,
                  PADDINGR = 22, PADDINGB = 40;
        //行高、距离行底部的偏移量
        public const int LINEHEIGHT = 24, OFFSET = 0;
        //光标所在的x、y位置(包含padding)
        int currx = PADDINGL, curry = PADDINGT;
        //字体
        Font font = new Font("仿宋", 12f);
        //行数
        const int Lines = 22;
        const int linewidth = 429 - PADDINGL - PADDINGR;
        //障碍系统参数
        List<int> blockers;

        public MessageBoxLayers()
        {

            Size = new Size(new Point(429, 610));
            BackColor = Color.FromArgb(0, 0, 0, 0);

            blockers = new List<int>();
            for (int i = 1; i <= Lines; i++)
            {
                blockers.Add(i * linewidth - 1);
            }
            for (int i = 1; i <= Lines; i++)
            {
                blockers.Add(i * linewidth);
            }
            blockers.Sort();
        }
        public int SetText(string text)
        {
            //输入文字方法，若产生换行则返回剩余String，否则返回null
            var maxwidth = (blockers[0] % linewidth) - currx + PADDINGL;
            var textline = new TextShowerLayers(font, currx, curry, maxwidth, LINEHEIGHT);
            var buffer = new List<byte>(); string content = "";

            //三种情况结束content
            //1、文字没了
            //2、文字还有，放不下了
            //3、遇到换行符
            //根据以下三种情况设置不同的currx、curry
            int flag = 1;
            for (int i = 1; i <= text.Length; i++)
            {
                content = text.Substring(0, i);
                var sz = CreateGraphics().MeasureString(content, font);
                if (sz.Width >= textline.Width)
                {
                    content = content.Substring(0, content.Length - 1);
                    flag = 2;
                    break;
                }
                if (sz.Height >= textline.Height)
                {
                    content = content.Substring(0, content.Length - 1);
                    flag = 3;
                    break;
                }
            }

            var lenght = content.Length;
            if (flag == 1)
            {
                textline.Width = (int)CreateGraphics().MeasureString(content, font).Width + 1;
                currx += textline.Width;
            }
            if (flag == 2)
            {
                blockers.RemoveAt(0);
                currx = blockers[0] % linewidth + PADDINGL;
                curry = ((int)(blockers[0] / linewidth)) * LINEHEIGHT + PADDINGT;
                blockers.RemoveAt(0);
            }
            if (flag == 3)
            {
                while (content.Length > 0 &&
                    (content.Substring(content.Length - 1, 1) == "\r" || content.Substring(content.Length - 1, 1) == "\n"))
                    content = content.Remove(content.Length - 1);
                currx = PADDINGL;
                curry += LINEHEIGHT;
                while (blockers.Count != 0 && blockers[0] < ((curry - PADDINGT) / LINEHEIGHT) * linewidth)
                {
                    blockers.RemoveAt(0);
                }
                if(blockers.Count != 0)
                {
                    blockers.RemoveAt(0);
                }
            }

            textline.Text = content;
            Controls.Add(textline);

            return lenght;
        }

        public bool SetImage(String imgpath, int line)
        {
            //以当前光标所在行为第一行，维持图片长宽比在光标位置放置一张图片
            //若放下，则返回true，否则返回false
            Image img = Image.FromFile(imgpath);
            int height = line * LINEHEIGHT;
            int width = line * LINEHEIGHT * img.Width / img.Height;
            var maxwidth = (blockers[0] % linewidth) - currx + PADDINGL;

            //判定是否放得下图片,放不下则返回false
            if (maxwidth < width)
            {
                currx = PADDINGL;
                curry += LINEHEIGHT;
                while (blockers.Count != 0 && blockers[0] <= ((curry - PADDINGT) / LINEHEIGHT) * linewidth)
                {
                    blockers.RemoveAt(0);
                }
            }
            var nowline = (curry - PADDINGT) / LINEHEIGHT;
            if (Lines - nowline < line)
                return false;

            var imgbox = new ImageShowerLayers(width, height, currx, curry, img);
            this.Controls.Add(imgbox);


            for (int i = 1; i < line; i++)
            {
                blockers.Add(((curry - PADDINGT) / LINEHEIGHT + i) * linewidth + currx - PADDINGL);
                blockers.Add(((curry - PADDINGT) / LINEHEIGHT + i) * linewidth + currx - PADDINGL + width);
            }
            blockers.Sort();
            currx += width;

            return true;
        }

        public bool isFull()
        {
            return (curry - PADDINGT) / LINEHEIGHT == Lines;
        }

        protected override void Dispose(bool disposing)
        {
            foreach (Control control in this.Controls)
            {
                control.Dispose();
            }
            base.Dispose(disposing);
        }

    }

    //一个用于显示文本的类
    public class TextShowerLayers : System.Windows.Forms.Label
    {
        public TextShowerLayers(Font font, int x, int y, int width, int height)
        {
            this.Location = new Point(x, y);
            this.Width = width;
            this.Height = height;
            //BackColor=Color.White;
            TextAlign = ContentAlignment.MiddleLeft;
            Font = font;
        }
    }

    //一个用于显示图片的类
    public class ImageShowerLayers : System.Windows.Forms.PictureBox
    {
        public ImageShowerLayers(int width, int height, int x, int y, Image img)
        {
            this.Width = width;
            this.Height = height;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Location = new Point(x, y);
            this.Image = img;
        }
    }
}
