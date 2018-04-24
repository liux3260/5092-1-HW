using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _5092_1_HW
{
    class simulator//This Class is to generate random number matrix. We have to make sure that when we calculate Greeks, the random number matrix stays the same
    {
        public int simulation { get; set; }
        public int M { get; set; }
        public static int c = System.Environment.ProcessorCount;
        private double x1, x2;

        public simulator(Parameters GIP)
        {
            simulation = GIP.simulation;
            M = GIP.M;
        }
        public double[,] Box_Muller()//The polar rejection transformation
        {
            double[] Norm = new double[2];
            Random rnd = new Random();
            double[,] ep = new double[M, simulation];
            for (int m = 0; m < M; m++)
            {
                for (int n = 0; n < simulation; n++)
                {
                    x1 = rnd.NextDouble();
                    x2 = rnd.NextDouble();
                    Norm[0] = Math.Sqrt(-2 * Math.Log(x1)) * Math.Cos(2 * Math.PI * x2);
                    ep[m, n] = Norm[0];
                }
            }
            return ep;
        }

        public void multithread()
        {
            int perc = M / c;

            int count = 0;
            List<Thread> ThreadList = new List<Thread>();
            for (int i = 0; i < c; i++)
            {
                Thread t = new Thread(new ParameterizedThreadStart(getRM));
                ThreadList.Add(t);
                t.Start(count);
                count = count + perc;
            }
            foreach (Thread t in ThreadList)
            {
                t.Join();
            }
        }

        public void getRM(object x)
        {
            int perc = M / c;
            Random rnd = new Random();
            double[] Norm = new double[2];
            int getinput = Convert.ToInt32(x);
            int startc = getinput;
            int endc = getinput + perc;
            for (int i = startc; i < endc; i++)
            {
                for (int j = 0; j < simulation; j++)
                {
                    x1 = rnd.NextDouble();
                    x2 = rnd.NextDouble();
                    Norm[0] = Math.Sqrt(-2 * Math.Log(x1)) * Math.Cos(2 * Math.PI * x2);
                    Form1.ep[i, j] = Norm[0];
                }
            }
        }



    }
}
