using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicrosoftResearch.Infer.Maths;
using System.Threading;


namespace _5092_1_HW
{
    class European:getpayoff
    {
        private double _multiplier;
        public European(Parameters GIP, double multiplier):base (GIP)
        {
            _multiplier = multiplier
        }

        public double[] get_payoff()//get payoff
        {
            int perc = M / c;
            double[] payoffc1 = new double[M];
            double[] payoffp1 = new double[M];
            double[] payoffc2 = new double[M];
            double[] payoffp2 = new double[M];
            double[] payoffp = new double[M];
            double[] payoffc = new double[M];
            double[] payoff = new double[2 * M];
            double dt = tenor / simulation;
            int beta1 = -1;
            double erddt = Math.Exp(rate * dt);

            if (check3 == 1)
            {
                int count = 0;
                List<Thread> ThreadList = new List<Thread>();
                for (int i = 0; i < c; i++)
                {
                    Thread t = new Thread(new ParameterizedThreadStart(getpaths1));
                    ThreadList.Add(t);
                    t.Start(count);
                    count = count + perc;
                }
                foreach (Thread t in ThreadList)
                {
                    t.Join();
                }
                foreach (Thread t in ThreadList)
                {
                    t.Abort();
                }
            }
            else
            {
                c = 1;
                Thread t = new Thread(new ParameterizedThreadStart(getpaths1));
                t.Start(0);
                t.Join();
                t.Abort();             
            }


            Action<object> po = x =>
             {
                 int getinput = Convert.ToInt32(x);
                 int startc = getinput;
                 int endc = getinput + perc;

                 for (int j = startc; j < endc; j++)
                 {
                         double cvc1 = 0;
                         double cvp1 = 0;
                             double cvc2 = 0;
                             double cvp2 = 0;
                     for (int i = 0; i < simulation ; i++)
                     {
                         if (check2 == 1)//control variate
                         {
                             double t = (simulation - i) * dt;
                             double deltac1 = getbsdelta(strike, Form1.path1[j, i ], volatility, t, rate)[0];
                             double deltap1 = getbsdelta(strike, Form1.path1[j, i ], volatility, t, rate)[1];
                             cvc1 = cvc1 + deltac1 * (Form1.path1[j, i+1] - Form1.path1[j, i ] * erddt);
                             cvp1 = cvp1 + deltap1 * (Form1.path1[j, i+1] - Form1.path1[j, i ] * erddt);

                             if (check1 == 1)//control variate+antithetic
                             {
                                 double deltac2 = getbsdelta(strike, Form1.path2[j, i ], volatility, t, rate)[0];
                                 double deltap2 = getbsdelta(strike, Form1.path2[j, i ], volatility, t, rate)[1];
                                 cvc2 = cvc2 + deltac2 * (Form1.path2[j, i+1] - Form1.path2[j, i ] * erddt);
                                 cvp2 = cvp2 + deltap2 * (Form1.path2[j, i+1] - Form1.path2[j, i ] * erddt);
                             }
                             else
                             {
                             }
                         }

                     }

                     if (check2 == 1)//control variate
                     {
                         payoffc1[j] = Math.Max(Form1.path1[j, simulation] - strike, 0) + beta1 * cvc1;//get the payoff matrix
                         payoffp1[j] = Math.Max(strike - Form1.path1[j, simulation], 0) + beta1 * cvp1;
                         if (check1 == 1)//control variate+antithetic
                         {
                             payoffc2[j] = Math.Max(Form1.path2[j, simulation] - strike, 0) + beta1 * cvc2;//get the payoff matrix
                             payoffp2[j] = Math.Max(strike - Form1.path2[j, simulation], 0) + beta1 * cvp2;
                             payoffc[j] = payoffc1[j] + payoffc2[j];
                             payoffp[j] = payoffp1[j] + payoffp2[j];
                         }
                         else
                         {
                             payoffc[j] = payoffc1[j];
                             payoffp[j] = payoffp1[j];
                         }
                     }
                     else if (check2 == 0)
                     {
                         payoffc1[j] = Math.Max(Form1.path1[j, simulation] - strike, 0);//get the payoff matrix
                         payoffp1[j] = Math.Max(strike - Form1.path1[j, simulation], 0);
                         if (check1 == 1)
                         {
                             payoffc2[j] = Math.Max(Form1.path2[j, simulation] - strike, 0);//get the payoff matrix
                             payoffp2[j] = Math.Max(strike - Form1.path2[j, simulation], 0);
                             payoffc[j] = payoffc1[j] + payoffc2[j];
                             payoffp[j] = payoffp1[j] + payoffp2[j];
                         }
                         else
                         {
                             payoffc[j] = payoffc1[j];
                             payoffp[j] = payoffp1[j];
                         }
                     }

                 }


             };

            if (check3==1)
            {
                int count = 0;
                List<Thread> ThreadList = new List<Thread>();
                for (int i = 0; i < c; i++)
                {
                    Thread t = new Thread(new ParameterizedThreadStart(po));
                    ThreadList.Add(t);
                    t.Start(count);
                    count = count + perc;
                }
                foreach (Thread t in ThreadList)
                {
                    t.Join();
                }
                foreach (Thread t in ThreadList)
                {
                    t.Abort();
                }
            }
            else
            {
                perc = M;
                Thread t = new Thread(new ParameterizedThreadStart(po));
                t.Start(0);
                t.Join();
                t.Abort();
            }


            payoffc.CopyTo(payoff, 0);
            payoffp.CopyTo(payoff, M);
            return payoff;
        }


        public double[] getbsdelta(double strike, double under, double volatility, double t, double rate)//calculate delta
        {
            double d1;
            double[] delta = new double[2];
            d1 = (Math.Log(under / strike) + (rate + Math.Pow(volatility, 2) / 2) * t) / (volatility * Math.Sqrt(t));
            delta[0] = MMath.NormalCdf(d1);//call delta
            delta[1] = delta[0] - 1;//put delta
            return delta;
        }



    }
}
