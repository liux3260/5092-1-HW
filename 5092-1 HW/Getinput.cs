using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5092_1_HW
{
    public class Parameters//get all the inputs from the user // change name into "Inputs"
    {
        public int simulation { get; set; }
        public int M { get; set; }
        public double K { get; set; }
        public double S { get; set; }
        public double sigma { get; set;}
        public double T { get; set; }
        public double R { get; set; }
        public int check1 { get; set; }
        public int check2 { get; set; }
        public int check3 { get; set; }
        public int downandout { get; set; }
        public int upandout { get; set; }
        public int downandin { get; set; }
        public int upandin { get; set; }
        public double barrier { get; set; }
        public int c { get; set; }
        public Parameters (double strike, double underlying, double volatility, double tenor, double rate,int step,int trail,int Check1,int Check2,int Check3,int DAO,int UAO,int DAI,int UAI,int core)
        {
            K = strike;
            S = underlying;
            sigma = volatility;
            T = tenor;
            R = rate;
            simulation = step;
            M = trail;
            check1 = Check1;
            check2 = Check2;
            check3 = Check3;
            downandout = DAO;
            upandout = UAO;
            downandin = DAI;
            upandin = UAI;
            c = core;
        }
    }
}
