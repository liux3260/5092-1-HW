using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicrosoftResearch.Infer.Maths;
using System.Threading;

namespace _5092_1_HW
{
    class getpayoff//This Class is to generate underlying path.
    {
        public int check1
        {
            get;
            set;
        }
        public int check2
        {
            get;
            set;
        }
        public int check3
        {
            get;
            set;
        }
        public int downandout { get; set; }
        public int upandout { get; set; }
        public int downandin { get; set; }
        public int upandin { get; set; }
        public double barrier { get; set; }
        public int simulation { get; set; }
        public int M { get; set; }
        public double strike { get; set; }
        public double underlying { get; set; }
        public double volatility { get; set; }
        public double tenor { get; set; }
        public double rate { get; set; }
        public int c { get; set; }
        public getpayoff(Parameters GIP)
        {
            simulation = GIP.simulation;
            M = GIP.M;
            strike = GIP.K;
            underlying = GIP.S;
            volatility = GIP.sigma;
            tenor = GIP.T;
            rate = GIP.R;
            check1 = GIP.check1;
            check2 = GIP.check2;
            check3 = GIP.check3;
            downandout = GIP.downandout;
            upandout = GIP.upandout;
            downandin = GIP.downandin;
            upandin = GIP.upandin;
            c = GIP.c;
        }


        public void getpaths1(object x)//get paths
        {
            int perc = M / c;
            int getinput = Convert.ToInt32(x);
            int startc = getinput;
            int endc = getinput + perc;
            double dt = tenor / simulation;
            for (int j = startc; j < endc; j++)
            {
                Form1.path1[j, 0] = underlying;
                if (check1 == 1)
                {
                    Form1.path2[j, 0] = underlying;
                }
                for (int i = 1; i < simulation + 1; i++)
                {
                    Form1.path1[j, i] = Form1.path1[j, i - 1] * Math.Exp((rate - Math.Pow(volatility, 2) / 2) * dt + volatility * Math.Sqrt(dt) * Form1.ep[j, i - 1]);//calculate the paths
                    if (check1 == 1)
                    {
                        Form1.path2[j, i] = Form1.path2[j, i - 1] * Math.Exp((rate - Math.Pow(volatility, 2) / 2) * dt + volatility * Math.Sqrt(dt) * -Form1.ep[j, i - 1]);//calculate the paths
                    }
                }
            }
        }


    }
}
