using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addition
{
    public class OD_Array
    {
        private int[] a;
        public OD_Array(int n, int min, int max)
        {
            a = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
                a[i] = rnd.Next(min, max);
        }

        public OD_Array(int startel,int step)//В задании сказано с заданной размерностью, тут можно, конечно, костыль на еще один параметр поставить
            //но лучше уж сделать заданный изначально размер
        {
            a = new int[10];
            for(int i = 0; i < 10; i++)
            {
                a[i] = startel + i * step;
            }
        }

        public OD_Array(string filepath)
        {
            string[] fileArray = File.ReadAllLines(filepath);
            a = new int[fileArray.Length];
            for(int i = 0; i < a.Length; i++)
            {
                a[i] = Convert.ToInt32(fileArray[i]);
            }
        }

        public void WriteToFile(string filepath)
        {
            string s = "";
            for(int i = 0; i < a.Length; i++)
            {
                s += a[i] + "\n";
            }
            File.WriteAllText(filepath, s);
            
        }

        public int Sum
        {
            get
            {
                int sum = 0;
                for(int i = 0; i < a.Length; i++)
                {
                    sum += a[i];
                }
                return sum;
            }
        }

        public int MaxCount
        {
            get
            {
                int max=a[1];
                int maxc = 1;
                for(int i = 2; i < a.Length; i++)
                {
                    if (a[i] > max)
                    {
                        maxc = 1;
                        max = a[i];
                    }
                    else
                    {
                        if (a[i] == max) maxc++;
                        
                    }
                }
                return maxc;//число максимальных элементов(насколько понимаю, это максимальный элемент, который повторяется)
            }
        }

        public int Max
        {
            get
            {
                int max = a[0];
                for (int i = 1; i < a.Length; i++)
                    if (a[i] > max) max = a[i];
                return max;
            }
        }
        public int Min
        {
            get
            {
                int min = a[0];
                for (int i = 1; i < a.Length; i++)
                    if (a[i] < min) min = a[i];
                return min;
            }
        }
        public int CountPositiv
        {
            get
            {
                int count = 0;
                for (int i = 0; i < a.Length; i++)
                    if (a[i] > 0) count++;
                return count;
            }
        }

        public void Inverse()
        {
            for(int i = 0; i < a.Length; i++)
            {
                a[i] *= -1;
            }
        }

        public void Multi(int mul)
        {
            for(int i = 0; i < a.Length;i++)
            {
                a[i] *= mul;
            }
        }

        public override string ToString()
        {
            string s = "";
            foreach (int v in a)
                s = s + v + " ";
            return s;
        }

    }
     public class TD_Array
    {
        private int[,] a;
        public TD_Array(int i,int j)
        {
            Random r = new Random();
            a = new int[i, j];
            for (int ic = 0; ic < i; ic++)
                for (int jc = 0; jc < j; jc++)
                    a[ic, jc] = r.Next(20);
        }

        public TD_Array(string filepath)
        {
            string[] fileArray = File.ReadAllLines(filepath);
            string[] buf;
            buf = fileArray[1].Split(' ');
            a = new int[fileArray.Length, buf.Length];
            for(int i = 0; i < fileArray.Length; i++)
            {
                buf = fileArray[i].Split(' ');
                for(int j = 0; j < buf.Length; j++)
                {
                    a[i, j] = Convert.ToInt32(buf[j]);
                }
            }
        }

        public void WriteToFile(string filepath)
        {
            string s = "";
            for (int i = 0; i < a.GetUpperBound(0)+1; i++)
            {
                for (int j = 0; j < a.GetUpperBound(1)+1; j++)
                {
                    s += $"{a[i, j]} ";
                }
                s += "\n";
            }
            File.WriteAllText(filepath, s);
        }

        public int Sum()
        {
            int s = 0;
            for (int i = 0; i < a.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < a.GetUpperBound(1) + 1; j++)
                {
                    s +=a[i, j];
                }
            }
            return s;
        }

        public int Sum(int el)
        {
            int s = 0;
            for (int i = 0; i < a.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < a.GetUpperBound(1) + 1; j++)
                {
                    if(a[i,j]>el)s += a[i, j];
                }
            }
            return s;
        }

        public int Max
        {
            get {
                int max = a[0, 0];
                for (int i = 0; i < a.GetUpperBound(0) + 1; i++)
                {
                    for (int j = 0; j < a.GetUpperBound(1) + 1; j++)
                    {
                        if (a[i, j] > max) max = a[i, j];
                    }
                }
                return max;
            }
            
        }

        public int Min
        {
            get
            {
                int max = a[0, 0];
                for (int i = 0; i < a.GetUpperBound(0) + 1; i++)
                {
                    for (int j = 0; j < a.GetUpperBound(1) + 1; j++)
                    {
                        if (a[i, j] < max) max = a[i, j];
                    }
                }
                return max;
            }
            
        }

        public void IndexOfMax(out int ind_line, out int ind_column)
        {
            
            int max = a[0, 0];
            ind_line = 0;
            ind_column = 0;
            for (int i = 0; i < a.GetUpperBound(0) + 1; i++)
                {
                    for (int j = 0; j < a.GetUpperBound(1) + 1; j++)
                    {
                        if (a[i, j] > max)
                        {
                        max = a[i, j];
                        ind_line = i;
                        ind_column = j;
                        }
                    }
                }
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < a.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < a.GetUpperBound(1) + 1; j++)
                {
                    s += $"{a[i, j]} ";
                }
                s += "\n";
            }
            return s;
        }
    }

}
