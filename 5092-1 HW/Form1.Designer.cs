namespace _5092_1_HW
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Calculate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.strike_price = new System.Windows.Forms.TextBox();
            this.underlying = new System.Windows.Forms.TextBox();
            this.tenor = new System.Windows.Forms.TextBox();
            this.volatility = new System.Windows.Forms.TextBox();
            this.risk_free_rate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.call_option = new System.Windows.Forms.TextBox();
            this.call_delta = new System.Windows.Forms.TextBox();
            this.call_gamma = new System.Windows.Forms.TextBox();
            this.call_vega = new System.Windows.Forms.TextBox();
            this.call_theta = new System.Windows.Forms.TextBox();
            this.call_rho = new System.Windows.Forms.TextBox();
            this.put_option = new System.Windows.Forms.TextBox();
            this.put_delta = new System.Windows.Forms.TextBox();
            this.put_gamma = new System.Windows.Forms.TextBox();
            this.put_vega = new System.Windows.Forms.TextBox();
            this.put_theta = new System.Windows.Forms.TextBox();
            this.put_rho = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.standard_errorc = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.standard_errorp = new System.Windows.Forms.TextBox();
            this.num_of_trials = new System.Windows.Forms.TextBox();
            this.step = new System.Windows.Forms.TextBox();
            this.NOT = new System.Windows.Forms.Label();
            this.Steps = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.timer = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.TextBox();
            this.deltacv = new System.Windows.Forms.CheckBox();
            this.multithreading = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cores = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label16 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Rebate = new System.Windows.Forms.Label();
            this.Rbate = new System.Windows.Forms.TextBox();
            this.barrier = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.barrierline = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // Calculate
            // 
            this.Calculate.Location = new System.Drawing.Point(21, 950);
            this.Calculate.Name = "Calculate";
            this.Calculate.Size = new System.Drawing.Size(147, 84);
            this.Calculate.TabIndex = 0;
            this.Calculate.Text = "Calculate";
            this.Calculate.UseVisualStyleBackColor = true;
            this.Calculate.Click += new System.EventHandler(this.Calculate_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(47, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "Strike price";
            // 
            // strike_price
            // 
            this.strike_price.Location = new System.Drawing.Point(366, 183);
            this.strike_price.Multiline = true;
            this.strike_price.Name = "strike_price";
            this.strike_price.Size = new System.Drawing.Size(137, 37);
            this.strike_price.TabIndex = 3;
            this.strike_price.TextChanged += new System.EventHandler(this.strike_price_TextChanged);
            // 
            // underlying
            // 
            this.underlying.Location = new System.Drawing.Point(366, 71);
            this.underlying.Name = "underlying";
            this.underlying.Size = new System.Drawing.Size(137, 42);
            this.underlying.TabIndex = 4;
            this.underlying.TextChanged += new System.EventHandler(this.underlying_TextChanged);
            // 
            // tenor
            // 
            this.tenor.Location = new System.Drawing.Point(366, 281);
            this.tenor.Name = "tenor";
            this.tenor.Size = new System.Drawing.Size(137, 42);
            this.tenor.TabIndex = 5;
            this.tenor.TextChanged += new System.EventHandler(this.tenor_TextChanged);
            // 
            // volatility
            // 
            this.volatility.Location = new System.Drawing.Point(366, 393);
            this.volatility.Name = "volatility";
            this.volatility.Size = new System.Drawing.Size(137, 42);
            this.volatility.TabIndex = 6;
            this.volatility.TextChanged += new System.EventHandler(this.volatility_TextChanged);
            // 
            // risk_free_rate
            // 
            this.risk_free_rate.Location = new System.Drawing.Point(366, 508);
            this.risk_free_rate.Name = "risk_free_rate";
            this.risk_free_rate.Size = new System.Drawing.Size(137, 42);
            this.risk_free_rate.TabIndex = 7;
            this.risk_free_rate.TextChanged += new System.EventHandler(this.risk_free_rate_TextChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(47, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 37);
            this.label2.TabIndex = 8;
            this.label2.Text = "Underlying price";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(47, 288);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 37);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tenor";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(47, 398);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(193, 37);
            this.label4.TabIndex = 10;
            this.label4.Text = "Volatility";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(47, 511);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(230, 37);
            this.label5.TabIndex = 11;
            this.label5.Text = "Risk-free rate";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(651, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(193, 30);
            this.label6.TabIndex = 12;
            this.label6.Text = "Option price";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(651, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 30);
            this.label7.TabIndex = 13;
            this.label7.Text = "Delta";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(651, 398);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 30);
            this.label8.TabIndex = 14;
            this.label8.Text = "Vega";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(651, 527);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 30);
            this.label9.TabIndex = 15;
            this.label9.Text = "Theta";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(651, 288);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 30);
            this.label10.TabIndex = 16;
            this.label10.Text = "Gamma";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(651, 645);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 30);
            this.label11.TabIndex = 17;
            this.label11.Text = "Rho";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(984, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 30);
            this.label12.TabIndex = 18;
            this.label12.Text = "Call";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1217, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 30);
            this.label13.TabIndex = 19;
            this.label13.Text = "Put";
            // 
            // call_option
            // 
            this.call_option.Location = new System.Drawing.Point(947, 74);
            this.call_option.Name = "call_option";
            this.call_option.Size = new System.Drawing.Size(142, 42);
            this.call_option.TabIndex = 20;
            // 
            // call_delta
            // 
            this.call_delta.Location = new System.Drawing.Point(947, 177);
            this.call_delta.Name = "call_delta";
            this.call_delta.Size = new System.Drawing.Size(142, 42);
            this.call_delta.TabIndex = 21;
            // 
            // call_gamma
            // 
            this.call_gamma.Location = new System.Drawing.Point(947, 283);
            this.call_gamma.Name = "call_gamma";
            this.call_gamma.Size = new System.Drawing.Size(142, 42);
            this.call_gamma.TabIndex = 22;
            // 
            // call_vega
            // 
            this.call_vega.Location = new System.Drawing.Point(947, 392);
            this.call_vega.Name = "call_vega";
            this.call_vega.Size = new System.Drawing.Size(142, 42);
            this.call_vega.TabIndex = 23;
            // 
            // call_theta
            // 
            this.call_theta.Location = new System.Drawing.Point(947, 522);
            this.call_theta.Name = "call_theta";
            this.call_theta.Size = new System.Drawing.Size(142, 42);
            this.call_theta.TabIndex = 24;
            // 
            // call_rho
            // 
            this.call_rho.Location = new System.Drawing.Point(947, 639);
            this.call_rho.Name = "call_rho";
            this.call_rho.Size = new System.Drawing.Size(142, 42);
            this.call_rho.TabIndex = 25;
            // 
            // put_option
            // 
            this.put_option.Location = new System.Drawing.Point(1178, 74);
            this.put_option.Name = "put_option";
            this.put_option.Size = new System.Drawing.Size(156, 42);
            this.put_option.TabIndex = 26;
            // 
            // put_delta
            // 
            this.put_delta.Location = new System.Drawing.Point(1178, 177);
            this.put_delta.Name = "put_delta";
            this.put_delta.Size = new System.Drawing.Size(156, 42);
            this.put_delta.TabIndex = 27;
            // 
            // put_gamma
            // 
            this.put_gamma.Location = new System.Drawing.Point(1178, 283);
            this.put_gamma.Name = "put_gamma";
            this.put_gamma.Size = new System.Drawing.Size(156, 42);
            this.put_gamma.TabIndex = 28;
            // 
            // put_vega
            // 
            this.put_vega.Location = new System.Drawing.Point(1178, 395);
            this.put_vega.Name = "put_vega";
            this.put_vega.Size = new System.Drawing.Size(156, 42);
            this.put_vega.TabIndex = 29;
            // 
            // put_theta
            // 
            this.put_theta.Location = new System.Drawing.Point(1178, 522);
            this.put_theta.Name = "put_theta";
            this.put_theta.Size = new System.Drawing.Size(156, 42);
            this.put_theta.TabIndex = 30;
            // 
            // put_rho
            // 
            this.put_rho.Location = new System.Drawing.Point(1178, 639);
            this.put_rho.Name = "put_rho";
            this.put_rho.Size = new System.Drawing.Size(156, 42);
            this.put_rho.TabIndex = 31;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // standard_errorc
            // 
            this.standard_errorc.Location = new System.Drawing.Point(947, 755);
            this.standard_errorc.Name = "standard_errorc";
            this.standard_errorc.Size = new System.Drawing.Size(142, 42);
            this.standard_errorc.TabIndex = 32;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(651, 761);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(223, 30);
            this.label14.TabIndex = 33;
            this.label14.Text = "Standard Error";
            // 
            // standard_errorp
            // 
            this.standard_errorp.Location = new System.Drawing.Point(1178, 755);
            this.standard_errorp.Name = "standard_errorp";
            this.standard_errorp.Size = new System.Drawing.Size(156, 42);
            this.standard_errorp.TabIndex = 34;
            // 
            // num_of_trials
            // 
            this.num_of_trials.Location = new System.Drawing.Point(366, 636);
            this.num_of_trials.Name = "num_of_trials";
            this.num_of_trials.Size = new System.Drawing.Size(137, 42);
            this.num_of_trials.TabIndex = 35;
            this.num_of_trials.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // step
            // 
            this.step.Location = new System.Drawing.Point(366, 752);
            this.step.Name = "step";
            this.step.Size = new System.Drawing.Size(137, 42);
            this.step.TabIndex = 36;
            // 
            // NOT
            // 
            this.NOT.Location = new System.Drawing.Point(47, 639);
            this.NOT.Name = "NOT";
            this.NOT.Size = new System.Drawing.Size(281, 40);
            this.NOT.TabIndex = 37;
            this.NOT.Text = "Number of Trails";
            // 
            // Steps
            // 
            this.Steps.Location = new System.Drawing.Point(47, 755);
            this.Steps.Name = "Steps";
            this.Steps.Size = new System.Drawing.Size(152, 43);
            this.Steps.TabIndex = 38;
            this.Steps.Text = "steps";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(286, 1000);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(456, 34);
            this.checkBox1.TabIndex = 40;
            this.checkBox1.Text = "Anthetic Variance Reduction";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // timer
            // 
            this.timer.Location = new System.Drawing.Point(651, 844);
            this.timer.Name = "timer";
            this.timer.Size = new System.Drawing.Size(128, 51);
            this.timer.TabIndex = 41;
            this.timer.Text = "Time";
            // 
            // lblTimer
            // 
            this.lblTimer.Location = new System.Drawing.Point(947, 844);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(142, 42);
            this.lblTimer.TabIndex = 42;
            // 
            // deltacv
            // 
            this.deltacv.AutoSize = true;
            this.deltacv.Location = new System.Drawing.Point(748, 1000);
            this.deltacv.Name = "deltacv";
            this.deltacv.Size = new System.Drawing.Size(456, 34);
            this.deltacv.TabIndex = 43;
            this.deltacv.Text = "Delta-based Control Variate";
            this.deltacv.UseVisualStyleBackColor = true;
            // 
            // multithreading
            // 
            this.multithreading.AutoSize = true;
            this.multithreading.Location = new System.Drawing.Point(1222, 1000);
            this.multithreading.Name = "multithreading";
            this.multithreading.Size = new System.Drawing.Size(261, 34);
            this.multithreading.TabIndex = 44;
            this.multithreading.Text = "Multithreading";
            this.multithreading.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(47, 847);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(94, 46);
            this.label15.TabIndex = 45;
            this.label15.Text = "cores";
            // 
            // cores
            // 
            this.cores.Location = new System.Drawing.Point(366, 847);
            this.cores.Name = "cores";
            this.cores.Size = new System.Drawing.Size(137, 42);
            this.cores.TabIndex = 46;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(52, 1088);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1289, 51);
            this.progressBar1.TabIndex = 47;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(1599, 21);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(484, 83);
            this.label16.TabIndex = 48;
            this.label16.Text = "Option Type";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "European",
            "Asian",
            "Digital",
            "Barrier",
            "Lookback",
            "Range"});
            this.comboBox1.Location = new System.Drawing.Point(1612, 176);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(342, 38);
            this.comboBox1.TabIndex = 49;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Rebate
            // 
            this.Rebate.Location = new System.Drawing.Point(1476, 522);
            this.Rebate.Name = "Rebate";
            this.Rebate.Size = new System.Drawing.Size(117, 37);
            this.Rebate.TabIndex = 51;
            this.Rebate.Text = "Rebate";
            this.Rebate.Click += new System.EventHandler(this.Rebate_Click);
            // 
            // Rbate
            // 
            this.Rbate.Enabled = false;
            this.Rbate.Location = new System.Drawing.Point(1690, 522);
            this.Rbate.Name = "Rbate";
            this.Rbate.Size = new System.Drawing.Size(158, 42);
            this.Rbate.TabIndex = 52;
            // 
            // barrier
            // 
            this.barrier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.barrier.Enabled = false;
            this.barrier.FormattingEnabled = true;
            this.barrier.Items.AddRange(new object[] {
            "Down and Out",
            "Up and Out",
            "Down and In",
            "Up and In"});
            this.barrier.Location = new System.Drawing.Point(1612, 285);
            this.barrier.Name = "barrier";
            this.barrier.Size = new System.Drawing.Size(342, 38);
            this.barrier.TabIndex = 53;
            this.barrier.SelectedIndexChanged += new System.EventHandler(this.barrier_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(1476, 639);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(118, 30);
            this.label18.TabIndex = 54;
            this.label18.Text = "Barrier";
            // 
            // barrierline
            // 
            this.barrierline.Enabled = false;
            this.barrierline.Location = new System.Drawing.Point(1690, 642);
            this.barrierline.Name = "barrierline";
            this.barrierline.Size = new System.Drawing.Size(158, 42);
            this.barrierline.TabIndex = 56;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2276, 1167);
            this.Controls.Add(this.barrierline);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.barrier);
            this.Controls.Add(this.Rbate);
            this.Controls.Add(this.Rebate);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.cores);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.multithreading);
            this.Controls.Add(this.deltacv);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.timer);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.Steps);
            this.Controls.Add(this.NOT);
            this.Controls.Add(this.step);
            this.Controls.Add(this.num_of_trials);
            this.Controls.Add(this.standard_errorp);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.standard_errorc);
            this.Controls.Add(this.put_rho);
            this.Controls.Add(this.put_theta);
            this.Controls.Add(this.put_vega);
            this.Controls.Add(this.put_gamma);
            this.Controls.Add(this.put_delta);
            this.Controls.Add(this.put_option);
            this.Controls.Add(this.call_rho);
            this.Controls.Add(this.call_theta);
            this.Controls.Add(this.call_vega);
            this.Controls.Add(this.call_gamma);
            this.Controls.Add(this.call_delta);
            this.Controls.Add(this.call_option);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.risk_free_rate);
            this.Controls.Add(this.volatility);
            this.Controls.Add(this.tenor);
            this.Controls.Add(this.underlying);
            this.Controls.Add(this.strike_price);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Calculate);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Calculate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox strike_price;
        private System.Windows.Forms.TextBox underlying;
        private System.Windows.Forms.TextBox tenor;
        private System.Windows.Forms.TextBox volatility;
        private System.Windows.Forms.TextBox risk_free_rate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox call_option;
        private System.Windows.Forms.TextBox call_delta;
        private System.Windows.Forms.TextBox call_gamma;
        private System.Windows.Forms.TextBox call_vega;
        private System.Windows.Forms.TextBox call_theta;
        private System.Windows.Forms.TextBox call_rho;
        private System.Windows.Forms.TextBox put_option;
        private System.Windows.Forms.TextBox put_delta;
        private System.Windows.Forms.TextBox put_gamma;
        private System.Windows.Forms.TextBox put_vega;
        private System.Windows.Forms.TextBox put_theta;
        private System.Windows.Forms.TextBox put_rho;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox standard_errorc;
        private System.Windows.Forms.TextBox standard_errorp;
        private System.Windows.Forms.TextBox step;
        private System.Windows.Forms.TextBox num_of_trials;
        private System.Windows.Forms.Label Steps;
        private System.Windows.Forms.Label NOT;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox lblTimer;
        private System.Windows.Forms.Label timer;
        private System.Windows.Forms.CheckBox deltacv;
        private System.Windows.Forms.CheckBox multithreading;
        private System.Windows.Forms.TextBox cores;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label Rebate;
        private System.Windows.Forms.TextBox Rbate;
        private System.Windows.Forms.ComboBox barrier;
        private System.Windows.Forms.TextBox barrierline;
        private System.Windows.Forms.Label label18;
    }
}

