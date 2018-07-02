using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace Dairy1
{
    public class Calender
    {
        private double rate = 0.7;      //缩放比例
        public int Year = 2015;         //当前年份
        private double blockX = 33;     //小格宽
        private double blockY = 25;     //小格高
        private double[] MoonX = { 0, 221, 502, 221, 502, 221, 502, 860, 1141, 860, 1141, 860, 1141 };//月份首位X
        private double[] MoonY = { 0,217,217,441,441,665,665,217,217,441,441,665,665 };//月份首位Y
        private int[,] first = new int[4, 13]{          //2016-Year 16-0 15-1 14-2 13-3
            {0,-4,0,-1,-4,1,-2,-4,0,-3,-5,-1,-3},
            {0,-3,1,1,-2,-4,0,-2,-5,-1,-3,1,-1 },
            {0,-2,-5,-5,-1,-3,1,-1,-4,0,-2,-5,0 },
            {0,-1,-4,-4,0,-2,-5,0,-3,1,-1,-4,1 }
        };

        private int[] last = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };     //月份天数
        public Calender()
        {
            //全体缩放
            blockX *= rate; blockY *= rate;
            int i;
            for (i = 0; i < 13; i++)
            {
                MoonX[i] *= 0.7;
                MoonY[i] *= 0.7;
            }
        }
        public Bitmap GetBitmap()
        {
            switch (Year)
            {
                case 2016:
                    return Properties.Resources._2016_f;
                case 2015:
                    return Properties.Resources._2015_f;
                case 2014:
                    return Properties.Resources._2014_f;
                case 2013:
                    return Properties.Resources._2013_f;
                default:
                    MessageBox.Show("ERROR YEAR "+Year.ToString());
                    break;
            };
            return Properties.Resources.exit1;
        }
        public int GetDate(int x,int y)
        {
            int i;
            int yy=Year, mm=0, dd=0;
            int BX = (int)Math.Ceiling(blockX * 7);
            int BY = (int)Math.Ceiling(blockY * 6);
            for(i=1;i<13;i++)
            {
                if(MoonX[i]<=x&&MoonX[i]+BX>=x&&MoonY[i]<y&&MoonY[i]+BY>=y)
                {
                    mm = i;
                    break;
                }
            }
            if (mm == 0) return 0;
            int First = first[2016-Year,mm];
            int X = (int)Math.Floor((x - MoonX[mm]) / blockX);
            int Y = (int)Math.Floor((y - MoonY[mm]) / blockY);
            dd = Y * 7 + X + First;
            if (dd < 1 || dd > last[mm]) return 0;
            int result = yy * 10000 + mm * 100 + dd;
            return result;
        }
    }
}
