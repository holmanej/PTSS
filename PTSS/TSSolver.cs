using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSS
{
    class TSSolver
    {
        private Dictionary<char, int> Amap = new Dictionary<char, int>();
        private Dictionary<int, int[]> P = new Dictionary<int, int[]>();
        private int M;
        private int Halt = -1;

        public TSSolver(int M, string A, string[] rules)
        {
            this.M = M;

            for (int i = 0; i < A.Count(); i++)
            {
                Amap.Add(A[i], i);
                if (A[i] == 'H')
                {
                    Halt = i;
                }
            }
            
            for (int i = 0; i < rules.Count(); i++)
            {
                int[] rule = new int[rules[i].Count()];
                for (int j = 0; j < rules[i].Count(); j++)
                {
                    rule[j] = Amap[rules[i][j]];
                }
                P.Add(i, rule);
            }

            //foreach (var entry in P)
            //{
            //    Debug.Write(entry.Key + " = ");
            //    foreach (int s in entry.Value)
            //    {
            //        Debug.Write(s + ", ");
            //    }
            //    Debug.Write("\r\n");
            //}
        }


        public string Solve(string tape)
        {
            List<int> T = new List<int>();
            foreach (char c in tape)
            {
                T.Add(Amap[c]);
            }

            while (T.Count >= M && T.First() != Halt)
            {
                int delCnt = T.Count + (T.Count % M);
                int cnt = T.Count;

                for (int i = 0; i < cnt; i += M)
                {
                    T.AddRange(P[T[i]]);
                }
                T.RemoveRange(0, delCnt);

                //foreach (int s in T)
                //{
                //    Debug.Write(Amap.Keys.ElementAt(s));
                //}
                //Debug.Write("\r\n");
            }

            string result = "Done: ";
            foreach (int s in T)
            {
                result += Amap.Keys.ElementAt(s);
            }

            return result;
        }
    }
}
