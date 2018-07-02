using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
namespace Dairy1
{
    public class ReadManager
    {
        private const int len = (400 / 8) + 1;
        //private bool[] dat = new bool[len * 8];
        private byte[] data = new byte[len];
        private string path = "read.dat";
        public ReadManager()
        {
            data = Load();
            /*
            Updata(5);
            Updata(10);
            data = Load();
            if(Query(5)) MessageBox.Show("5-1");
            else MessageBox.Show("5-2");

            if (Query(10)) MessageBox.Show("10-1");
            else MessageBox.Show("10-2");

            if (Query(8)) MessageBox.Show("8-1");
            else MessageBox.Show("8-2");

            if (Query(1)) MessageBox.Show("1-1");
            else MessageBox.Show("1-2");
            //*/
        }
        private byte[] Load()
        {
            if (!File.Exists(path)) return new byte[len];
            FileStream fs = new FileStream(path, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);

            byte[] bt = br.ReadBytes(len);
            br.Close();
            fs.Close();

            return bt;
        }
        public bool Query(int t)
        {
            if (t == -1) return true;
            int t1 = t / 8, t2 = t % 8;
            int tmp = data[t1] & (1 << t2);
            if (tmp > 0) return true;
            return false;
        }
        public void Updata(int t)
        {
            int t1 = t / 8;
            byte t2 = (byte)(t % 8);
            //MessageBox.Show(t.ToString()+t1.ToString()+t2.ToString());
            data[t1] =(byte) (data[t1] | (1 << t2));
            /*
            for (int i = 0; i < data.Length; i++)
                data[i] = 0;
                */
            Save();
        }
        private void Save()
        {
            if (File.Exists(path)) File.Delete(path);
            FileStream fs = new FileStream(path, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(data);
            bw.Flush();

            bw.Close();
            fs.Close();
        }
        public void Delete()
        {
            if (File.Exists(path)) File.Delete(path);
        }
        public double rate
        {
            get
            { double count = 0;
                for (int i = 0; i < 400; i++)
                    if (Query(i)) count++;
                return count / 400;
            }
        }
    }
}
