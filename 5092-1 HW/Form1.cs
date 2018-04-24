using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using MicrosoftResearch.Infer.Maths;
using System.Threading;
namespace _5092_1_HW
{
    public partial class Form1 : Form
    {
        public static double[,] ep;
        public static double[,] path1;
        public static double[,] path2;
        public static double[] payoff;
        public static int c;
        Stopwatch watch = new Stopwatch();


        public Form1()
        {
            InitializeComponent();
        }

        private void Calculate_Click(object sender, EventArgs e)
        {

            double s, k, sigma, r, t;//Initialization
            int check1, check2, check3;
            int downandout = 0, upandout = 0, downandin = 0, upandin = 0;
            double checkbarrier, checkrebate;
            int M, simulation;
            double[] P = new double[4];
            double[] del_gam = new double[4];
            double[] vega = new double[2];
            double[] theta = new double[2];
            double[] rho = new double[2];
            double[] standard_error = new double[2];
            watch.Start();//start to calculate time

            k = Convert.ToDouble(strike_price.Text);//get strike
            s = Convert.ToDouble(underlying.Text);//input underlying
            sigma = Convert.ToDouble(volatility.Text);//input volatility
            r = Convert.ToDouble(risk_free_rate.Text);//input rate
            t = Convert.ToDouble(tenor.Text);//input time to maturity
            M = Convert.ToInt32(num_of_trials.Text);//input # of trials
            simulation = Convert.ToInt16(step.Text);// input steps
            c = Convert.ToInt16(cores.Text);// input cores
            progressBar1.Maximum = 70;
            progressBar1.Value = 0;

            check1 = 0;
            if (checkBox1.Checked == true)//check the antithetic variance reduction method
            {
                check1 = 1;
            }
            check2 = 0;
            if (deltacv.Checked == true)//check the control variate variance reduction method
            {
                check2 = 1;
            }

            check3 = 0;
            if (multithreading.Checked == true)//check the multithreading
            {
                check3 = 1;
            }


            if (barrier.Text == "Down and Out")//Inputs from Barrier  option
            {
                downandout = 1;
            }
            else if (barrier.Text == "Up and Out")
            {
                upandout = 1;
            }
            else if (barrier.Text == "Down and In")
            {
                downandin = 1;
            }
            else if (barrier.Text == "Up and In")
            {
                upandin = 1;
            }

            if (comboBox1.Text == "Barrier")//error handling
            {
                try
                {
                    checkbarrier = Convert.ToDouble(barrierline.Text);
                }
                catch
                {
                    MessageBox.Show("Please enter a numeric value for barrier!", "Input Error!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
                    return;
                }
                if ((s < checkbarrier && (downandin == 1 || downandout == 1) || (s > checkbarrier && (upandin == 1 || upandout == 1))))
                {
                    MessageBox.Show("Please check your input of underlying, barrier and the type of barrier option, the barrier option doesn't make sense !", "Input Error!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
                    return;
                }
            }
            else if (comboBox1.Text == "Digital")
            {
                try
                {
                    checkrebate = Convert.ToDouble(Rbate.Text);
                }
                catch
                {
                    MessageBox.Show("Please enter a numeric value for rebate!", "Input Error!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
                    return;
                }
            }

            Parameters GIP = new Parameters(k, s, sigma, t, r, simulation, M, check1, check2, check3, downandout, upandout, downandin, upandin, c);//input the data

            simulator sims = new simulator(GIP);
            getpayoff GPO = new getpayoff(GIP);

            if (s > 0 && k > 0 && sigma > 0 && r > 0 && t > 0 && M > 0 && simulation > 2 && comboBox1.Text != "")
            {
                ep = new double[M, simulation];//declare the matrix

                path1 = new double[M, simulation + 1];//declare paths
                path2 = new double[M, simulation + 1];
                payoff = new double[2 * M];//declare payoff
                double[] greeks = new double[10];

                if (comboBox1.Text == "European")
                {
                    European Euro = new European(GIP);
                    if (multithreading.Checked == true)
                    {
                        sims.multithread();//get the random matrix
                        progressBar1.Increment(+10);
                    }
                    else
                    {
                        ep = sims.Box_Muller();//get the random matrix
                        progressBar1.Increment(+10);
                    }
                    payoff = Euro.get_payoff();//calculate the payoff matrix
                }
                else if (comboBox1.Text == "Asian")
                {
                    Asian Asian = new Asian(GIP);
                    if (multithreading.Checked == true)
                    {
                        sims.multithread();
                        progressBar1.Increment(+10);
                    }
                    else
                    {
                        ep = sims.Box_Muller();//get the random matrix
                        progressBar1.Increment(+10);
                    }
                    payoff = Asian.get_payoff();
                }
                else if (comboBox1.Text == "Digital")
                {
                    Digital digital = new Digital(GIP);
                    digital.rebate = Convert.ToDouble(Rbate.Text);
                    if (multithreading.Checked == true)
                    {
                        sims.multithread();
                        progressBar1.Increment(+10);
                    }
                    else
                    {
                        ep = sims.Box_Muller();//get the random matrix
                        progressBar1.Increment(+10);
                    }
                    payoff = digital.get_payoff();
                }
                else if (comboBox1.Text == "Lookback")
                {
                    Lookback lookback = new Lookback(GIP);
                    if (multithreading.Checked == true)
                    {
                        sims.multithread();
                        progressBar1.Increment(+10);
                    }
                    else
                    {
                        ep = sims.Box_Muller();//get the random matrix
                        progressBar1.Increment(+10);
                    }
                    payoff = lookback.get_payoff();
                }
                else if (comboBox1.Text == "Range")
                {
                    Range range = new Range(GIP);
                    if (multithreading.Checked == true)
                    {
                        sims.multithread();
                        progressBar1.Increment(+10);
                    }
                    else
                    {
                        ep = sims.Box_Muller();//get the random matrix
                        progressBar1.Increment(+10);
                    }
                    payoff = range.get_payoff();
                }
                else if (comboBox1.Text == "Barrier")
                {
                    Barrier barrier = new Barrier(GIP);
                    barrier.barrier = Convert.ToDouble(barrierline.Text);
                    if (multithreading.Checked == true)
                    {
                        sims.multithread();
                        progressBar1.Increment(+10);
                    }
                    else
                    {
                        ep = sims.Box_Muller();//get the random matrix
                        progressBar1.Increment(+10);
                    }
                    payoff = barrier.get_payoff();
                }
                progressBar1.Increment(+10);
                P = get_option_price(payoff, GIP);//calculate the option price
                call_option.Text = Convert.ToString(Math.Round(P[0], 4));
                put_option.Text = Convert.ToString(Math.Round(P[1], 4));
                progressBar1.Increment(+10);


                standard_errorc.Text = Convert.ToString(Math.Round(P[2], 4));
                standard_errorp.Text = Convert.ToString(Math.Round(P[3], 4));
                progressBar1.Increment(+10);


                greeks = getgreeks(P, GIP);//calculate Greeks


                call_delta.Text = Convert.ToString(Math.Round(greeks[0], 4));
                call_gamma.Text = Convert.ToString(Math.Round(greeks[2], 4));
                put_gamma.Text = Convert.ToString(Math.Round(greeks[3], 4));
                put_delta.Text = Convert.ToString(Math.Round(greeks[1], 4));
                progressBar1.Increment(+10);


                call_vega.Text = Convert.ToString(Math.Round(greeks[4], 4));//vega calculation
                put_vega.Text = Convert.ToString(Math.Round(greeks[5], 4));
                progressBar1.Increment(+10);

                call_theta.Text = Convert.ToString(Math.Round(greeks[6], 4));
                put_theta.Text = Convert.ToString(Math.Round(greeks[7], 4));
                progressBar1.Increment(+10);


                call_rho.Text = Convert.ToString(Math.Round(greeks[8], 4));//rho calculation
                put_rho.Text = Convert.ToString(Math.Round(greeks[9], 4));
                progressBar1.Increment(+10);

                watch.Stop();//Stop the timer
                lblTimer.Text = watch.Elapsed.Hours.ToString() + ":" + watch.Elapsed.Minutes.ToString() + ":" + watch.Elapsed.Seconds.ToString() + ":" + watch.Elapsed.Milliseconds.ToString();
                watch.Reset();
            }
            else
            {
                MessageBox.Show("Please enter a positive numeric value, the steps most be larger than 2 and you must select an option type!", "Input Error!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
            }

        }

        public double[] getgreeks(double[] price, Parameters GIP)//get the greeks
        {
            Parameters deltau = new Parameters(GIP.K, GIP.S * 1.001, GIP.sigma, GIP.T, GIP.R, GIP.simulation, GIP.M, GIP.check1, GIP.check2, GIP.check3, GIP.downandout, GIP.upandout, GIP.downandin, GIP.upandin, GIP.c);
            Parameters deltad = new Parameters(GIP.K, GIP.S * 0.999, GIP.sigma, GIP.T, GIP.R, GIP.simulation, GIP.M, GIP.check1, GIP.check2, GIP.check3, GIP.downandout, GIP.upandout, GIP.downandin, GIP.upandin, GIP.c);

            Parameters vegau = new Parameters(GIP.K, GIP.S, GIP.sigma * 1.001, GIP.T, GIP.R, GIP.simulation, GIP.M, GIP.check1, GIP.check2, GIP.check3, GIP.downandout, GIP.upandout, GIP.downandin, GIP.upandin, GIP.c);
            Parameters vegad = new Parameters(GIP.K, GIP.S, GIP.sigma * 0.999, GIP.T, GIP.R, GIP.simulation, GIP.M, GIP.check1, GIP.check2, GIP.check3, GIP.downandout, GIP.upandout, GIP.downandin, GIP.upandin, GIP.c);
            Parameters thetau = new Parameters(GIP.K, GIP.S, GIP.sigma, GIP.T * 1.001, GIP.R, GIP.simulation, GIP.M, GIP.check1, GIP.check2, GIP.check3, GIP.downandout, GIP.upandout, GIP.downandin, GIP.upandin, GIP.c);

            Parameters rhou = new Parameters(GIP.K, GIP.S, GIP.sigma, GIP.T, GIP.R * 1.001, GIP.simulation, GIP.M, GIP.check1, GIP.check2, GIP.check3, GIP.downandout, GIP.upandout, GIP.downandin, GIP.upandin, GIP.c);
            Parameters rhod = new Parameters(GIP.K, GIP.S, GIP.sigma, GIP.T, GIP.R * 0.999, GIP.simulation, GIP.M, GIP.check1, GIP.check2, GIP.check3, GIP.downandout, GIP.upandout, GIP.downandin, GIP.upandin, GIP.c);


            double[] greek = new double[10];

            double[] payoffdeltau = new double[2 * GIP.M];
            double[] payoffdeltad = new double[2 * GIP.M];
            double[] payoffvegau = new double[2 * GIP.M];
            double[] payoffvegad = new double[2 * GIP.M];
            double[] payoffthetau = new double[2 * GIP.M];
            double[] payoffrhou = new double[2 * GIP.M];
            double[] payoffrhod = new double[2 * GIP.M];

            double[] Pdeltau = new double[4];
            double[] Pdeltad = new double[4];
            double[] Pvegau = new double[4];
            double[] Pvegad = new double[4];
            double[] Pthetau = new double[4];
            double[] Prhou = new double[4];
            double[] Prhod = new double[4];

            if (comboBox1.Text == "European")
            {
                European Eurodeltau = new European(deltau);
                European Eurodeltad = new European(deltad);
                European Eurovegau = new European(vegau);
                European Eurovegad = new European(vegad);
                European Eurothetau = new European(thetau);
                European Eurorhou = new European(rhou);
                European Eurorhod = new European(rhod);

                payoffdeltau = Eurodeltau.get_payoff();
                payoffdeltad = Eurodeltad.get_payoff();
                payoffvegau = Eurovegau.get_payoff();
                payoffvegad = Eurovegad.get_payoff();
                payoffthetau = Eurothetau.get_payoff();
                payoffrhou = Eurorhou.get_payoff();
                payoffrhod = Eurorhod.get_payoff();


            }
            else if (comboBox1.Text == "Asian")
            {
                Asian Eurodeltau = new Asian(deltau);
                Asian Eurodeltad = new Asian(deltad);
                Asian Eurovegau = new Asian(vegau);
                Asian Eurovegad = new Asian(vegad);
                Asian Eurothetau = new Asian(thetau);
                Asian Eurorhou = new Asian(rhou);
                Asian Eurorhod = new Asian(rhod);



                payoffdeltau = Eurodeltau.get_payoff();
                payoffdeltad = Eurodeltad.get_payoff();
                payoffvegau = Eurovegau.get_payoff();
                payoffvegad = Eurovegad.get_payoff();
                payoffthetau = Eurothetau.get_payoff();
                payoffrhou = Eurorhou.get_payoff();
                payoffrhod = Eurorhod.get_payoff();

            }
            else if (comboBox1.Text == "Digital")
            {
                Digital Eurodeltau = new Digital(deltau);
                Digital Eurodeltad = new Digital(deltad);
                Digital Eurovegau = new Digital(vegau);
                Digital Eurovegad = new Digital(vegad);
                Digital Eurothetau = new Digital(thetau);
                Digital Eurorhou = new Digital(rhou);
                Digital Eurorhod = new Digital(rhod);

                Eurodeltau.rebate = Convert.ToDouble(Rbate.Text);
                Eurodeltad.rebate = Convert.ToDouble(Rbate.Text);
                Eurovegau.rebate = Convert.ToDouble(Rbate.Text);
                Eurovegad.rebate = Convert.ToDouble(Rbate.Text);
                Eurothetau.rebate = Convert.ToDouble(Rbate.Text);
                Eurorhou.rebate = Convert.ToDouble(Rbate.Text);
                Eurorhod.rebate = Convert.ToDouble(Rbate.Text);

                payoffdeltau = Eurodeltau.get_payoff();
                payoffdeltad = Eurodeltad.get_payoff();
                payoffvegau = Eurovegau.get_payoff();
                payoffvegad = Eurovegad.get_payoff();
                payoffthetau = Eurothetau.get_payoff();
                payoffrhou = Eurorhou.get_payoff();
                payoffrhod = Eurorhod.get_payoff();

            }
            else if (comboBox1.Text == "Lookback")
            {
                Lookback Eurodeltau = new Lookback(deltau);
                Lookback Eurodeltad = new Lookback(deltad);
                Lookback Eurovegau = new Lookback(vegau);
                Lookback Eurovegad = new Lookback(vegad);
                Lookback Eurothetau = new Lookback(thetau);
                Lookback Eurorhou = new Lookback(rhou);
                Lookback Eurorhod = new Lookback(rhod);



                payoffdeltau = Eurodeltau.get_payoff();
                payoffdeltad = Eurodeltad.get_payoff();
                payoffvegau = Eurovegau.get_payoff();
                payoffvegad = Eurovegad.get_payoff();
                payoffthetau = Eurothetau.get_payoff();
                payoffrhou = Eurorhou.get_payoff();
                payoffrhod = Eurorhod.get_payoff();


            }
            else if (comboBox1.Text == "Range")
            {
                Range Eurodeltau = new Range(deltau);
                Range Eurodeltad = new Range(deltad);
                Range Eurovegau = new Range(vegau);
                Range Eurovegad = new Range(vegad);
                Range Eurothetau = new Range(thetau);
                Range Eurorhou = new Range(rhou);
                Range Eurorhod = new Range(rhod);



                payoffdeltau = Eurodeltau.get_payoff();
                payoffdeltad = Eurodeltad.get_payoff();
                payoffvegau = Eurovegau.get_payoff();
                payoffvegad = Eurovegad.get_payoff();
                payoffthetau = Eurothetau.get_payoff();
                payoffrhou = Eurorhou.get_payoff();
                payoffrhod = Eurorhod.get_payoff();

            }
            else
            {
                Barrier Eurodeltau = new Barrier(deltau);
                Barrier Eurodeltad = new Barrier(deltad);
                Barrier Eurovegau = new Barrier(vegau);
                Barrier Eurovegad = new Barrier(vegad);
                Barrier Eurothetau = new Barrier(thetau);
                Barrier Eurorhou = new Barrier(rhou);
                Barrier Eurorhod = new Barrier(rhod);

                Eurodeltau.barrier = Convert.ToDouble(barrierline.Text);
                Eurodeltad.barrier = Convert.ToDouble(barrierline.Text);
                Eurovegau.barrier = Convert.ToDouble(barrierline.Text);
                Eurovegad.barrier = Convert.ToDouble(barrierline.Text);
                Eurothetau.barrier = Convert.ToDouble(barrierline.Text);
                Eurorhou.barrier = Convert.ToDouble(barrierline.Text);
                Eurorhod.barrier = Convert.ToDouble(barrierline.Text);

                payoffdeltau = Eurodeltau.get_payoff();
                payoffdeltad = Eurodeltad.get_payoff();
                payoffvegau = Eurovegau.get_payoff();
                payoffvegad = Eurovegad.get_payoff();
                payoffthetau = Eurothetau.get_payoff();
                payoffrhou = Eurorhou.get_payoff();
                payoffrhod = Eurorhod.get_payoff();
            }

            Pdeltau = get_option_price(payoffdeltau, deltau);//[0] is the call price, [1] is the put price
            Pdeltad = get_option_price(payoffdeltad, deltad);
            Pvegau = get_option_price(payoffvegau, vegau);
            Pvegad = get_option_price(payoffvegad, vegad);
            Pthetau = get_option_price(payoffthetau, thetau);
            Prhou = get_option_price(payoffrhou, rhou);
            Prhod = get_option_price(payoffrhod, rhod);

            greek[0] = (Pdeltau[0] - Pdeltad[0]) / (2 * 0.001 * GIP.S);//call delta
            greek[1] = (Pdeltau[1] - Pdeltad[1]) / (2 * 0.001 * GIP.S);//put delta
            greek[2] = (Pdeltau[0] + Pdeltad[0] - 2 * price[0]) / Math.Pow((0.001 * GIP.S), 2);//call gamma
            greek[3] = (Pdeltau[1] + Pdeltad[1] - 2 * price[1]) / Math.Pow((0.001 * GIP.S), 2);//put gamma


            greek[4] = (Pvegau[0] - Pvegad[0]) / (2 * 0.001 * GIP.sigma);//call vega
            greek[5] = (Pvegau[1] - Pvegad[1]) / (2 * 0.001 * GIP.sigma);//put vega


            greek[6] = -(Pthetau[0] - price[0]) / (0.001 * GIP.T);//call theta
            greek[7] = -(Pthetau[1] - price[1]) / (0.001 * GIP.T);//put theta

            greek[8] = (Prhou[0] - Prhod[0]) / (2 * 0.001 * GIP.R);//call rho
            greek[9] = (Prhou[1] - Prhod[1]) / (2 * 0.001 * GIP.R);//put rho

            return greek;

        }
        public double[] get_option_price(double[] payoff, Parameters GIP)
        {
            Parameters input = new Parameters(GIP.K, GIP.S, GIP.sigma, GIP.T, GIP.R, GIP.simulation, GIP.M, GIP.check1, GIP.check2, GIP.check3, GIP.downandout, GIP.upandout, GIP.downandin, GIP.upandin, GIP.c);
            double rate, tenor;
            int check1;
            int M;
            M = input.M;
            check1 = input.check1;
            rate = input.R;
            tenor = input.T;
            double sumc = 0, sump = 0;
            double[] payoffc = new double[M];
            double[] payoffp = new double[M];
            double sumtc = 0, sumtp = 0, sec, sep;
            for (int i = 0; i < 2 * M; i++)
            {
                if (i < M)
                {
                    sumc = sumc + payoff[i];
                    payoffc[i] = payoff[i];
                }
                else
                {
                    sump = sump + payoff[i];
                    payoffp[i - M] = payoff[i];
                }
            }
            double[] option_price = new double[4];
            if (check1 == 1)
            {
                option_price[0] = 0.5 * sumc / M * Math.Exp(-rate * tenor);//calculate the option price
                option_price[1] = 0.5 * sump / M * Math.Exp(-rate * tenor);
            }
            else if (check1 == 0)
            {
                option_price[0] = sumc / M * Math.Exp(-rate * tenor);//calculate the option price
                option_price[1] = sump / M * Math.Exp(-rate * tenor);
            }

            for (int j = 0; j < M; j++)
            {
                if (check1 == 1)
                {
                    sumtc = sumtc + Math.Pow(0.5 * payoffc[j] * Math.Exp(-rate * tenor) - option_price[0], 2);
                    sumtp = sumtp + Math.Pow(0.5 * payoffp[j] * Math.Exp(-rate * tenor) - option_price[1], 2);
                }
                else if (check1 == 0)
                {
                    sumtc = sumtc + Math.Pow(payoffc[j] * Math.Exp(-rate * tenor) - option_price[0], 2);

                    sumtp = sumtp + Math.Pow(payoffp[j] * Math.Exp(-rate * tenor) - option_price[1], 2);
                }
            }

            sec = Math.Sqrt(sumtc / (M - 1)) / Math.Sqrt(M);//calculate the standard error
            sep = Math.Sqrt(sumtp / (M - 1)) / Math.Sqrt(M);
            option_price[2] = sec;
            option_price[3] = sep;

            return (option_price);
        }



        private void underlying_TextChanged(object sender, EventArgs e)//error handling
        {
            double num;
            if (!double.TryParse(underlying.Text, out num))
                errorProvider1.SetError(underlying, "Please enter a number!");
            else
                errorProvider1.SetError(underlying, string.Empty);
        }

        private void strike_price_TextChanged(object sender, EventArgs e)
        {
            double num;
            if (!double.TryParse(strike_price.Text, out num))
                errorProvider1.SetError(strike_price, "Please enter a number!");
            else
                errorProvider1.SetError(strike_price, string.Empty);
        }

        private void tenor_TextChanged(object sender, EventArgs e)
        {
            double num;
            if (!double.TryParse(tenor.Text, out num))
                errorProvider1.SetError(tenor, "Please enter a number!");
            else
                errorProvider1.SetError(tenor, string.Empty);
        }

        private void volatility_TextChanged(object sender, EventArgs e)
        {
            double num;
            if (!double.TryParse(volatility.Text, out num))
                errorProvider1.SetError(volatility, "Please enter a number!");
            else
                errorProvider1.SetError(volatility, string.Empty);
        }

        private void risk_free_rate_TextChanged(object sender, EventArgs e)
        {
            double num;
            if (!double.TryParse(risk_free_rate.Text, out num))
                errorProvider1.SetError(risk_free_rate, "Please enter a number!");
            else
                errorProvider1.SetError(risk_free_rate, string.Empty);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            barrier.Enabled = false;
            Rbate.Enabled = false;
            barrierline.Enabled = false;
            if (comboBox1.Text == "Barrier")
            {
                barrier.Enabled = true;
                barrierline.Enabled = true;

            }
            else if (comboBox1.Text == "Digital")
            {
                Rbate.Enabled = true;
            }
        }

        private void Rebate_Click(object sender, EventArgs e)
        {

        }

        private void barrier_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

