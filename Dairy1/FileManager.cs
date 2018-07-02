using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dairy1
{
    //每个文件的信息
    //130901-crx
    public class FileInformation
    {
        private String writerName;
        private int date;
        private String fileName;

        public String WriterName
        {
            set { writerName = value; }
            get {return writerName; }
        }

        public int Date
        {
            set { date = value; }
            get {return date; }
        }
        
        public String FileName
        {
            set { fileName = value; }
            get {return fileName; }
        }
    }

    //处理文件
    public class FileManager
    {
        private List<FileInformation> informations = new List<FileInformation>();//文件信息群
        private int PageCounter = -1;

        /// <summary>
        /// 遍历文件寻找全部的txt文件
        /// </summary>
        /// <param name="filepath">文件夹路径</param>
        /// <returns>String[] 文件名</returns>
        public String[] GetFileNames(string filepath)
        {
            DirectoryInfo di = new DirectoryInfo(filepath);
            DirectoryInfo[] dis = di.GetDirectories();
            String[] dirNames = new String[dis.Length];
            for(int i = 0; i < dis.Length; i++)
            {
                dirNames[i] = dis[i].Name;
            }
            return dirNames;
        }

        /// <summary>
        /// 处理文件名
        /// 130901-crx
        /// 通过List的Add方法添加到文件信息群中
        /// </summary>
        /// <param name="filename"></param>
        private void HandleInformation(string filename)
        {
            FileInformation infor = new FileInformation();
            infor.FileName=filename;
            String[] temp = filename.Split('-');
            infor.Date=int.Parse(temp[0]);
            infor.WriterName=temp[1];
            informations.Add(infor);
        }
        public void HandleInformation(String[] filenames)
        {
            for(int i = 0; i < filenames.Length; i++)
            {
                HandleInformation(filenames[i]);
            }
        }

        /// <summary>
        /// 根据日期排序，从小到大，稳定排序
        /// 传入List<FileInformation>信息群，可以是此类的私有量，也可以传入自己创建的变量
        /// </summary>
        /// <returns>返回的是String[]数组，即按照日期顺序排序完毕的文件名（不含后缀）</returns>
        public String[] SortByDate()
        {
            for(int i = 0; i < informations.Count; i++)
            {
                for(int j = 0; j < informations.Count - i - 1; j++)
                {
                    if (informations[j].Date > informations[j + 1].Date)
                    {
                        FileInformation temp = informations[j];
                        informations[j] = informations[j + 1];
                        informations[j + 1] = temp;
                    }
                }
            }
            String[] fileNameByDate = new String[informations.Count];
            for(int i = 0; i < fileNameByDate.Length; i++)
            {
                fileNameByDate[i] = informations[i].FileName;
            }
            return fileNameByDate;
        }

        /// <summary>
        /// 根据所需要的姓名，返回作者是该人的全部文件名
        /// </summary>
        /// <param name="name">所要求的作者名</param>
        /// <returns>返回的List<String>为作者为该人的全部文件名</returns>
        public List<String> SortByName(String name)
        {
            List<String> fileNameByName = new List<string>();
            for(int i = 0; i < informations.Count; i++)
            {
                if (informations[i].WriterName.Equals(name))
                {
                    string filename = informations[i].FileName;
                    fileNameByName.Add(filename);
                }
            }
            return fileNameByName;
        }

        /// <summary>
        /// 根据输入的日期，返回在informations中的下标
        /// </summary>
        /// <returns></returns>
        public int FindByDate(int date)
        {
            date %= 1000000;
            for (int i = 0; i < informations.Count; i++)
                if (informations[i].Date.Equals(date))
                    return i; 
            return -1;
        }


        public bool TurnNextDiary()
        {
            if (IsLastDiary())
            {
                PageCounter = informations.Count;
                return false;
            }
            PageCounter++;
            return true;
        }

        public bool TurnLastDiary()
        {
            if (IsFirstDiary())
            {
                PageCounter = -1;
                return false;
            }
            PageCounter--;
            return true;
        }
        
        public String GetDiaryName()
        {
            return informations[PageCounter].FileName;
        }

        public int GetDiaryDate()
        {
            return informations[PageCounter].Date;
        }

        public bool JumpTo(int page)
        {
            if (page < -1 || page>informations.Count) return false;
            PageCounter = page;
            return true;
        }

        public bool IsFirstDiary()
        {
            return PageCounter == 0;
        }

        public bool IsLastDiary()
        {
            return PageCounter == informations.Count - 1;
        }
        public bool IsTitle()
        {
            return PageCounter == -1;
        }
        public bool IsBack()
        {
            return PageCounter == informations.Count;
        }
        public int GetPage { get { return PageCounter; } }
        public int BookMark(int num, int oper = 0, int pg = 0)
        {
            string path = "BookMark" + num.ToString() + ".txt";
            string temp = "";
            int d1 = 0, d2 = 0;
            if (oper > 0)
            {
                if (!File.Exists(path)) return -1;
                temp = File.ReadAllText(path);
                if (string.IsNullOrWhiteSpace(temp)) return -1;
                temp = temp.Replace("\n", "x");
                string[] array = temp.Split('x');
                d1 = System.Int32.Parse(array[0]);
                d2 = System.Int32.Parse(array[1]);
            }
            switch (oper)
            {
                case 0: //Save
                    File.WriteAllText(path, PageCounter.ToString() + "\r\n" + pg.ToString());
                    return 0;

                case 1: //Load
                    return PageCounter = d1;
                case 2: //Find
                    if (pg == 0) return informations[d1].Date;
                    else return d2;
                default:
                    return -1;
            }
        }
    }
}
