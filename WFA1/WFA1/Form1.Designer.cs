namespace parameter_handle
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button6 = new System.Windows.Forms.Button();
            this.btn_batch_send = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button11 = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox_time8 = new System.Windows.Forms.TextBox();
            this.textBox_time7 = new System.Windows.Forms.TextBox();
            this.textBox_time6 = new System.Windows.Forms.TextBox();
            this.textBox_time5 = new System.Windows.Forms.TextBox();
            this.textBox_time4 = new System.Windows.Forms.TextBox();
            this.textBox_send8 = new System.Windows.Forms.TextBox();
            this.textBox_send7 = new System.Windows.Forms.TextBox();
            this.textBox_send6 = new System.Windows.Forms.TextBox();
            this.textBox_send5 = new System.Windows.Forms.TextBox();
            this.textBox_send4 = new System.Windows.Forms.TextBox();
            this.btn_send8 = new System.Windows.Forms.Button();
            this.btn_send7 = new System.Windows.Forms.Button();
            this.textBox_send3 = new System.Windows.Forms.TextBox();
            this.textBox_send2 = new System.Windows.Forms.TextBox();
            this.textBox_send1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.wifi_password_text = new System.Windows.Forms.TextBox();
            this.wifi_ssid_text = new System.Windows.Forms.TextBox();
            this.button10 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.receive_text = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.send_text = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(36, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(321, 80);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "串口设置";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(230, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "打开串口 ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "波特率:     9600";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "串口:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(82, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 25);
            this.comboBox1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button6.ForeColor = System.Drawing.Color.Black;
            this.button6.Location = new System.Drawing.Point(515, 40);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 12;
            this.button6.Text = "关于软件";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // btn_batch_send
            // 
            this.btn_batch_send.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_batch_send.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_batch_send.Location = new System.Drawing.Point(193, 28);
            this.btn_batch_send.Name = "btn_batch_send";
            this.btn_batch_send.Size = new System.Drawing.Size(75, 29);
            this.btn_batch_send.TabIndex = 5;
            this.btn_batch_send.Text = "批量写入";
            this.btn_batch_send.UseVisualStyleBackColor = false;
            this.btn_batch_send.Click += new System.EventHandler(this.btn_batch_send_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(389, 82);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(99, 23);
            this.button4.TabIndex = 12;
            this.button4.Text = "保存当前配置";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(389, 40);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(99, 23);
            this.button5.TabIndex = 13;
            this.button5.Text = "载入配置文件";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button11);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.textBox5);
            this.groupBox4.Controls.Add(this.textBox6);
            this.groupBox4.Controls.Add(this.button8);
            this.groupBox4.Controls.Add(this.textBox3);
            this.groupBox4.Controls.Add(this.textBox4);
            this.groupBox4.Controls.Add(this.button7);
            this.groupBox4.Controls.Add(this.textBox1);
            this.groupBox4.Controls.Add(this.textBox2);
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.textBox_time8);
            this.groupBox4.Controls.Add(this.textBox_time7);
            this.groupBox4.Controls.Add(this.textBox_time6);
            this.groupBox4.Controls.Add(this.textBox_time5);
            this.groupBox4.Controls.Add(this.textBox_time4);
            this.groupBox4.Controls.Add(this.textBox_send8);
            this.groupBox4.Controls.Add(this.textBox_send7);
            this.groupBox4.Controls.Add(this.textBox_send6);
            this.groupBox4.Controls.Add(this.textBox_send5);
            this.groupBox4.Controls.Add(this.textBox_send4);
            this.groupBox4.Controls.Add(this.btn_send8);
            this.groupBox4.Controls.Add(this.btn_send7);
            this.groupBox4.Controls.Add(this.btn_batch_send);
            this.groupBox4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.ForeColor = System.Drawing.Color.Black;
            this.groupBox4.Location = new System.Drawing.Point(618, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(571, 469);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "命令组";
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button11.Location = new System.Drawing.Point(78, 28);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 29);
            this.button11.TabIndex = 83;
            this.button11.Text = "全部读取";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(21, 418);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(51, 17);
            this.label15.TabIndex = 82;
            this.label15.Text = "订阅8：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(21, 374);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 17);
            this.label14.TabIndex = 81;
            this.label14.Text = "订阅7：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(21, 334);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 17);
            this.label13.TabIndex = 80;
            this.label13.Text = "订阅6：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(21, 287);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 17);
            this.label12.TabIndex = 79;
            this.label12.Text = "订阅5：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(19, 241);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 17);
            this.label11.TabIndex = 78;
            this.label11.Text = "订阅4：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 192);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 17);
            this.label9.TabIndex = 77;
            this.label9.Text = "订阅3：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 17);
            this.label8.TabIndex = 76;
            this.label8.Text = "订阅2：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 17);
            this.label7.TabIndex = 75;
            this.label7.Text = "订阅1：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(391, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 74;
            this.label5.Text = "发送结果：";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(394, 412);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(69, 23);
            this.textBox5.TabIndex = 72;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(78, 412);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(300, 23);
            this.textBox6.TabIndex = 71;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(484, 412);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 70;
            this.button8.Text = "发送";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(394, 369);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(69, 23);
            this.textBox3.TabIndex = 69;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(78, 369);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(300, 23);
            this.textBox4.TabIndex = 68;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(484, 369);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 67;
            this.button7.Text = "发送";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(394, 328);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(69, 23);
            this.textBox1.TabIndex = 66;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(78, 328);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(300, 23);
            this.textBox2.TabIndex = 65;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(484, 328);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 64;
            this.button3.Text = "发送";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // textBox_time8
            // 
            this.textBox_time8.Location = new System.Drawing.Point(394, 284);
            this.textBox_time8.Name = "textBox_time8";
            this.textBox_time8.Size = new System.Drawing.Size(69, 23);
            this.textBox_time8.TabIndex = 63;
            // 
            // textBox_time7
            // 
            this.textBox_time7.Location = new System.Drawing.Point(394, 235);
            this.textBox_time7.Name = "textBox_time7";
            this.textBox_time7.Size = new System.Drawing.Size(69, 23);
            this.textBox_time7.TabIndex = 62;
            // 
            // textBox_time6
            // 
            this.textBox_time6.Location = new System.Drawing.Point(394, 186);
            this.textBox_time6.Name = "textBox_time6";
            this.textBox_time6.Size = new System.Drawing.Size(69, 23);
            this.textBox_time6.TabIndex = 61;
            // 
            // textBox_time5
            // 
            this.textBox_time5.Location = new System.Drawing.Point(394, 137);
            this.textBox_time5.Name = "textBox_time5";
            this.textBox_time5.Size = new System.Drawing.Size(69, 23);
            this.textBox_time5.TabIndex = 60;
            // 
            // textBox_time4
            // 
            this.textBox_time4.Location = new System.Drawing.Point(394, 88);
            this.textBox_time4.Name = "textBox_time4";
            this.textBox_time4.Size = new System.Drawing.Size(69, 23);
            this.textBox_time4.TabIndex = 59;
            // 
            // textBox_send8
            // 
            this.textBox_send8.Location = new System.Drawing.Point(78, 284);
            this.textBox_send8.Name = "textBox_send8";
            this.textBox_send8.Size = new System.Drawing.Size(300, 23);
            this.textBox_send8.TabIndex = 58;
            // 
            // textBox_send7
            // 
            this.textBox_send7.Location = new System.Drawing.Point(78, 235);
            this.textBox_send7.Name = "textBox_send7";
            this.textBox_send7.Size = new System.Drawing.Size(300, 23);
            this.textBox_send7.TabIndex = 57;
            // 
            // textBox_send6
            // 
            this.textBox_send6.Location = new System.Drawing.Point(78, 186);
            this.textBox_send6.Name = "textBox_send6";
            this.textBox_send6.Size = new System.Drawing.Size(300, 23);
            this.textBox_send6.TabIndex = 56;
            // 
            // textBox_send5
            // 
            this.textBox_send5.Location = new System.Drawing.Point(78, 137);
            this.textBox_send5.Name = "textBox_send5";
            this.textBox_send5.Size = new System.Drawing.Size(300, 23);
            this.textBox_send5.TabIndex = 55;
            // 
            // textBox_send4
            // 
            this.textBox_send4.Location = new System.Drawing.Point(78, 88);
            this.textBox_send4.Name = "textBox_send4";
            this.textBox_send4.Size = new System.Drawing.Size(300, 23);
            this.textBox_send4.TabIndex = 54;
            // 
            // btn_send8
            // 
            this.btn_send8.Location = new System.Drawing.Point(484, 284);
            this.btn_send8.Name = "btn_send8";
            this.btn_send8.Size = new System.Drawing.Size(75, 23);
            this.btn_send8.TabIndex = 49;
            this.btn_send8.Text = "发送";
            this.btn_send8.UseVisualStyleBackColor = true;
            // 
            // btn_send7
            // 
            this.btn_send7.Location = new System.Drawing.Point(484, 235);
            this.btn_send7.Name = "btn_send7";
            this.btn_send7.Size = new System.Drawing.Size(75, 23);
            this.btn_send7.TabIndex = 50;
            this.btn_send7.Text = "发送";
            this.btn_send7.UseVisualStyleBackColor = true;
            // 
            // textBox_send3
            // 
            this.textBox_send3.Location = new System.Drawing.Point(277, 150);
            this.textBox_send3.Name = "textBox_send3";
            this.textBox_send3.Size = new System.Drawing.Size(202, 23);
            this.textBox_send3.TabIndex = 65;
            // 
            // textBox_send2
            // 
            this.textBox_send2.Location = new System.Drawing.Point(277, 101);
            this.textBox_send2.Name = "textBox_send2";
            this.textBox_send2.Size = new System.Drawing.Size(202, 23);
            this.textBox_send2.TabIndex = 64;
            // 
            // textBox_send1
            // 
            this.textBox_send1.Location = new System.Drawing.Point(277, 52);
            this.textBox_send1.Name = "textBox_send1";
            this.textBox_send1.Size = new System.Drawing.Size(202, 23);
            this.textBox_send1.TabIndex = 63;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.Location = new System.Drawing.Point(488, 144);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(53, 29);
            this.button2.TabIndex = 70;
            this.button2.Text = "写入";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_2);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(274, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 17);
            this.label3.TabIndex = 71;
            this.label3.Text = "PRODUCT-KEY：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(274, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 17);
            this.label6.TabIndex = 72;
            this.label6.Text = "DEVICE-NAME：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(274, 127);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 17);
            this.label10.TabIndex = 73;
            this.label10.Text = "DEVICE-SECRET：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button12);
            this.groupBox2.Controls.Add(this.button13);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.wifi_password_text);
            this.groupBox2.Controls.Add(this.wifi_ssid_text);
            this.groupBox2.Controls.Add(this.button10);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.textBox_send1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBox_send2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBox_send3);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(36, 129);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(554, 190);
            this.groupBox2.TabIndex = 74;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "基础参数";
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button12.Location = new System.Drawing.Point(167, 98);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(58, 29);
            this.button12.TabIndex = 80;
            this.button12.Text = "读取";
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button13.Location = new System.Drawing.Point(167, 144);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(56, 29);
            this.button13.TabIndex = 79;
            this.button13.Text = "写入";
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label20.Location = new System.Drawing.Point(21, 127);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(119, 17);
            this.label20.TabIndex = 78;
            this.label20.Text = "WIFI-PASSWORD：";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label16.Location = new System.Drawing.Point(21, 81);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(78, 17);
            this.label16.TabIndex = 77;
            this.label16.Text = "WIFI-SSID：";
            // 
            // wifi_password_text
            // 
            this.wifi_password_text.Location = new System.Drawing.Point(24, 150);
            this.wifi_password_text.Name = "wifi_password_text";
            this.wifi_password_text.Size = new System.Drawing.Size(132, 23);
            this.wifi_password_text.TabIndex = 76;
            // 
            // wifi_ssid_text
            // 
            this.wifi_ssid_text.Location = new System.Drawing.Point(24, 101);
            this.wifi_ssid_text.Name = "wifi_ssid_text";
            this.wifi_ssid_text.Size = new System.Drawing.Size(132, 23);
            this.wifi_ssid_text.TabIndex = 75;
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button10.Location = new System.Drawing.Point(488, 95);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(53, 29);
            this.button10.TabIndex = 74;
            this.button10.Text = "读取";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.receive_text);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(36, 424);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(554, 72);
            this.groupBox3.TabIndex = 75;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "接收数据";
            // 
            // receive_text
            // 
            this.receive_text.Location = new System.Drawing.Point(15, 22);
            this.receive_text.Multiline = true;
            this.receive_text.Name = "receive_text";
            this.receive_text.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.receive_text.Size = new System.Drawing.Size(526, 36);
            this.receive_text.TabIndex = 19;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label17.Location = new System.Drawing.Point(322, 29);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(0, 17);
            this.label17.TabIndex = 18;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.send_text);
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox5.ForeColor = System.Drawing.Color.Black;
            this.groupBox5.Location = new System.Drawing.Point(36, 346);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(554, 72);
            this.groupBox5.TabIndex = 76;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "发送数据";
            // 
            // send_text
            // 
            this.send_text.Location = new System.Drawing.Point(15, 22);
            this.send_text.Multiline = true;
            this.send_text.Name = "send_text";
            this.send_text.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.send_text.Size = new System.Drawing.Size(526, 36);
            this.send_text.TabIndex = 19;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label18.Location = new System.Drawing.Point(322, 29);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(0, 17);
            this.label18.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1212, 509);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.ForeColor = System.Drawing.Color.SlateGray;
            this.Name = "Form1";
            this.Text = "串口调试工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btn_batch_send;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox_time8;
        private System.Windows.Forms.TextBox textBox_time7;
        private System.Windows.Forms.TextBox textBox_time6;
        private System.Windows.Forms.TextBox textBox_time5;
        private System.Windows.Forms.TextBox textBox_time4;
        private System.Windows.Forms.TextBox textBox_send8;
        private System.Windows.Forms.TextBox textBox_send7;
        private System.Windows.Forms.TextBox textBox_send6;
        private System.Windows.Forms.TextBox textBox_send5;
        private System.Windows.Forms.TextBox textBox_send4;
        private System.Windows.Forms.Button btn_send8;
        private System.Windows.Forms.Button btn_send7;
        private System.Windows.Forms.TextBox textBox_send3;
        private System.Windows.Forms.TextBox textBox_send2;
        private System.Windows.Forms.TextBox textBox_send1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox wifi_password_text;
        private System.Windows.Forms.TextBox wifi_ssid_text;
        private System.Windows.Forms.TextBox receive_text;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox send_text;
        private System.Windows.Forms.Label label18;
    }
}

