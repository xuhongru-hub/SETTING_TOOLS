using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.IO.Ports;
using Microsoft.Win32;
using mySpace;
using CRC_App;


namespace WFA1
{
    public partial class Form1 : Form
    {

        int lb_sum_nubmer;
        int window_width;
        int hide_width = 640;
        bool isOpened = false;//串口状态标志
        int lb_receivesum_nubmer = 0;

        public Form1()
        {
            InitializeComponent();

            foreach (CheckBox ck in panel_mul_sel.Controls)
            {
                ck.CheckedChanged += ck_child_CheckedChanged;
            }           
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            GetComList();

            //批量添加波特率列表
            string[] baud = { "4800", "9600", "19200", "57600", "115200" };
            comboBox2.Items.AddRange(baud);

            string[] CRC = { "CRC8", "CRC16", "CRC32" };
            comb_crc_type.Items.AddRange(CRC);

            //设置默认值
            comboBox1.Text = "COM1";
            comboBox2.Text = "115200";

            serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);

            lb_sum.Text = "0";
            cur_sum.Text = "0";
            lb_receive_sum.Text = "0";
            tx_timer_send.Text = "1000";

            button2.Text = "扩展  >>>";

            window_width = this.Width;
            this.Width = hide_width;

            hide_part_init();

        }


        public static void Delay(int milliSecond)
        {
            int start = Environment.TickCount;
            while (Math.Abs(Environment.TickCount - start) < milliSecond)//毫秒
            {
                Application.DoEvents();//可执行某无聊的操作
            }
        }        
        public void GetComList()
        {
            RegistryKey keyCom = Registry.LocalMachine.OpenSubKey("Hardware\\DeviceMap\\SerialComm");
            if (keyCom != null)
            {
                string[] sSubKeys = keyCom.GetValueNames();
                this.comboBox1.Items.Clear();
                foreach (string sName in sSubKeys)
                {
                    string sValue = (string)keyCom.GetValue(sName);
                    this.comboBox1.Items.Add(sValue);
                }
            }
        }
        public void hide_part_init()
        {
            rdo_string_text.Checked = true;
            rdo_check_null.Checked = true;
            textB_avg_time.Text = "";

            bt_send.Enabled = false;
            bt_send.Text = "禁止发送";

            btn_batch_send.Enabled = false;
            btn_batch_send.Text = "禁止发送";

            button3.Enabled = false;
            button3.Text = "禁止";

            Button[] sidebtns = { btn_send1, btn_send2, btn_send3, btn_send4, btn_send5, btn_send6, btn_send7, btn_send8 };

            foreach (var item in sidebtns)
            {
                item.Enabled = false;
                item.Text = "禁止";
            }
        }
        public void open_comm_display()
        {
            bt_send.Enabled = true;
            bt_send.Text = "发送数据";

            btn_batch_send.Enabled = true;
            btn_batch_send.Text = "批量发送";

            button3.Enabled = true;
            button3.Text = "重置";

            Button[] sidebtns = { btn_send1, btn_send2, btn_send3, btn_send4, btn_send5, btn_send6, btn_send7, btn_send8 };

            foreach (var item in sidebtns)
            {
                item.Enabled = true;
                item.Text = "发送";
            }
        }
        private void send_handle(CheckBox ck_b, TextBox tx_b_send, TextBox tx_b_disp)
        {
            byte[] bt;

            int type = get_check_type();
            Send send1 = new Send(type, 0, 1);

            if (ck_b.Checked == false) return;


            if (rdo_hex_text.Checked == true)
            {
                bt = send1.send_Hex(tx_b_send.Text);
            }
            else
            {
                bt = send1.send_String(tx_b_send.Text);
            }
            if (bt == null)
            {
                MessageBox.Show("数据为空或者位数不合法！");
                return;
            }

            serialPort1.Write(bt, 0, bt.Length);
            update_send_parametion(bt.Length);

            if (type == 1) //crc
            {
                int len = bt.Length;
                char[] HexChar = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

                tx_b_disp.Text = "";
                for (int i = 2; i > 0; i--)
                {
                    char hexH = HexChar[bt[len - i] / 16];
                    char hexL = HexChar[bt[len - i] % 16];

                    tx_b_disp.AppendText(hexH.ToString() + hexL.ToString() + " ");
                }
            }
            else if (type == 2)//mod
            {
                int len = bt.Length;
                char[] HexChar = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

                char hexH = HexChar[bt[len - 1] / 16];
                char hexL = HexChar[bt[len - 1] % 16];

                tx_b_disp.Text = (hexH.ToString() + hexL.ToString() + " ");
            }
            else
            {
                tx_b_disp.Text = "";
            }
        }
        private void read_form_file(string file)
        {
            CheckBox[] ch_box = { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8 };
            TextBox[] tx_box_send = { textBox_send1, textBox_send2, textBox_send3, textBox_send4, textBox_send5, textBox_send6, textBox_send7, textBox_send8 };
            TextBox[] tx_box = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8 };
            TextBox[] tx_box_time = { textBox_time1, textBox_time2, textBox_time3, textBox_time4, textBox_time5, textBox_time6, textBox_time7, textBox_time8 };

            string[] ch_b = new string[8];
            string line = "";

            using (StreamReader sr = new StreamReader(file))
            {
                for (int i = 0; i < 8; i++)
                {
                    line = sr.ReadLine();
                    if (line == "1")
                    {
                        ch_box[i].Checked = true;
                    }
                    else if (line == "0")
                    {
                        ch_box[i].Checked = false;
                    }
                    else
                    {
                        MessageBox.Show("文件内容非法！");
                    }
                }
                for (int i = 0; i < 8; i++)
                {
                    tx_box_send[i].Text = sr.ReadLine();
                }
                for (int i = 0; i < 8; i++)
                {
                    tx_box[i].Text = sr.ReadLine();
                }
                for (int i = 0; i < 8; i++)
                {
                    tx_box_time[i].Text = sr.ReadLine();
                }

                line = sr.ReadLine();
                if (line == "1")
                {
                    rdo_hex_text.Checked = true;
                }
                else
                {
                    rdo_string_text.Checked = true;
                }

                line = sr.ReadLine();
                if (line == "1")
                {
                    rdo_crc.Checked = true;
                    line = sr.ReadLine();
                    comb_crc_type.Text = line;
                }
                else if (line == "2")
                {
                    rdo_mod.Checked = true;
                }
                else if (line == "3")
                {
                    rdo_check_null.Checked = true;
                }
                else
                {
                    MessageBox.Show("文件内容非法！");
                }

                line = sr.ReadLine();
                if (line == "1")
                {
                    ckbox_avg_time.Checked = true;
                    line = sr.ReadLine();
                    textB_avg_time.Text = line;
                }

            }
        }
        private void write_to_file(string file)
        {
            CheckBox[] ch_box = { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8 };
            TextBox[] tx_box_send = { textBox_send1, textBox_send2, textBox_send3, textBox_send4, textBox_send5, textBox_send6, textBox_send7, textBox_send8 };
            TextBox[] tx_box = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8 };
            TextBox[] tx_box_time = { textBox_time1, textBox_time2, textBox_time3, textBox_time4, textBox_time5, textBox_time6, textBox_time7, textBox_time8 };

            string[] ch_b = new string[8];

            using (StreamWriter sw = new StreamWriter(file))
            {
                for (int i = 0; i < 8; i++)
                {
                    if (ch_box[i].Checked == true)
                        ch_b[i] = "1";
                    else
                        ch_b[i] = "0";
                    sw.WriteLine(ch_b[i]);
                }
                for (int i = 0; i < 8; i++)
                {
                    sw.WriteLine(tx_box_send[i].Text);
                }
                for (int i = 0; i < 8; i++)
                {
                    sw.WriteLine(tx_box[i].Text);
                }
                for (int i = 0; i < 8; i++)
                {
                    sw.WriteLine(tx_box_time[i].Text);
                }
                //HEX OR string
                if (rdo_hex_text.Checked == true)
                    ch_b[0] = "1";
                else
                    ch_b[0] = "0";
                sw.WriteLine(ch_b[0]);

                //if (rdo_string_text.Checked == true)
                //    ch_b[0] = "1";
                //else
                //    ch_b[0] = "0";
                //sw.WriteLine(ch_b[0]);

                //check type
                if (rdo_crc.Checked == true)
                {
                    ch_b[0] = "1";
                    sw.WriteLine(ch_b[0]);

                    sw.WriteLine(comb_crc_type.Text);
                }
                else if (rdo_mod.Checked == true)
                {
                    ch_b[0] = "2";
                    sw.WriteLine(ch_b[0]);
                }
                else if (rdo_check_null.Checked == true)
                {
                    ch_b[0] = "3";
                    sw.WriteLine(ch_b[0]);
                }
                else
                {
                    ch_b[0] = "0";
                    sw.WriteLine(ch_b[0]);
                }

                //平均间隔时间
                if (ckbox_avg_time.Checked == true)
                {
                    ch_b[0] = "1";
                    sw.WriteLine(ch_b[0]);
                    sw.WriteLine(textB_avg_time.Text);
                }
                else
                {
                    ch_b[0] = "0";
                    sw.WriteLine(ch_b[0]);
                }


            }
        }
        private string ShowSaveFileDialog()
        {
            string localFilePath = "";
            //string localFilePath, fileNameExt, newFileName, FilePath; 
            SaveFileDialog sfd = new SaveFileDialog();
            //设置文件类型 
            sfd.Filter = "Excel表格（*.xls）|*.xls";

            //设置默认文件类型显示顺序 
            sfd.FilterIndex = 1;

            //保存对话框是否记忆上次打开的目录 
            sfd.RestoreDirectory = true;

            //点了保存按钮进入 
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                localFilePath = sfd.FileName.ToString(); //获得文件路径 
                string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1); //获取文件名，不带路径

                //获取文件路径，不带文件名 
                //FilePath = localFilePath.Substring(0, localFilePath.LastIndexOf("\\")); 
                //给文件名前加上时间 
                //newFileName = DateTime.Now.ToString("yyyyMMdd") + fileNameExt; 
                //在文件名里加字符 
                //saveFileDialog1.FileName.Insert(1,"dameng"); 
                //System.IO.FileStream fs = (System.IO.FileStream)sfd.OpenFile();//输出文件 
                ////fs输出带文字或图片的文件，就看需求了 

                write_to_file(fileNameExt);
            }

            return localFilePath;
        }
        private int get_check_type()
        {
            if (rdo_crc.Checked == true)
                return 1;
            else if (rdo_mod.Checked == true)
                return 2;
            else if (rdo_check_null.Checked == true)
                return 3;
            else return 0;
        }
        private int get_code_type()
        {
            if (rdo_hex_text.Checked == true)
                return 1;
            else if (rdo_string_text.Checked == true)
                return 2;
            else return 0;
        }
        private void update_send_parametion(int number)
        {
            cur_sum.Text = Convert.ToString(number);
            lb_sum_nubmer = lb_sum_nubmer + number;
            lb_sum.Text = Convert.ToString(lb_sum_nubmer);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //callOnClick(bt_send);  
            bt_send.PerformClick();
        }
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //byte[] bt = 4096;

            SerialPort sp = (SerialPort)sender;
            int len = sp.BytesToRead;
            byte[] bt = new byte[len];

            sp.Read(bt, 0, len);
            //读取串口中一个字节的数据
            this.receive_text.Invoke(
                //在拥有此控件的基础窗口句柄的线程上执行委托Invoke(Delegate)
                //即在textBox_ReceiveDate控件的父窗口form中执行委托.
             new MethodInvoker(
                /*表示一个委托，该委托可执行托管代码中声明为 void 且不接受任何参数的任何方法。 在对控件的 Invoke 	方法进行调用时或需要一个简单委托又不想自己定义时可以使用该委托。*/
                 delegate
                 {
                     /*匿名方法,C#2.0的新功能，这是一种允许程序员将一段完整代码区块当成参数传递的程序代码编写技术，
                      * 通过此种方法可 	以直接使用委托来设计事件响应程序以下就是你要在主线程上实现的功能但是有一点要注意，
                      * 这里不适宜处理过多的方法，因为C#消息机制是消息流水线响应机制，
                      * 如果这里在主线程上处理语句的时间过长会导致主UI线程阻塞，
                      * 停止响应或响应不顺畅,这时你的主form界面会延迟或卡死      */
                     if (cb_receive_hex.Checked == true) //“16进制发送” 按钮   
                     {
                         char[] HexChar = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
                         //bt = StrToHexByte(indata);
                         for (int i = 0; i < bt.Length; i++)
                         {
                             char hexH = HexChar[bt[i] / 16];
                             char hexL = HexChar[bt[i] % 16];

                             this.receive_text.AppendText(hexH.ToString() + hexL.ToString() + " ");

                             lb_receivesum_nubmer = lb_receivesum_nubmer + 1;
                             lb_receive.Text = Convert.ToString(lb_receivesum_nubmer);
                         }
                     }
                     else
                     {
                         string str = System.Text.Encoding.Default.GetString(bt);
                         this.receive_text.AppendText(str);//输出到主窗口文本控件

                         lb_receivesum_nubmer = lb_receivesum_nubmer + str.Length;
                         lb_receive.Text = Convert.ToString(lb_receivesum_nubmer);

                     }
                 }
             )
             );
        }
        
        private void button11_Click(object sender, EventArgs e)
        {
            CheckBox[] ch_box = { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8 };
            TextBox[] tx_box_send = { textBox_send1, textBox_send2, textBox_send3, textBox_send4, textBox_send5, textBox_send6, textBox_send7, textBox_send8 };
            TextBox[] tx_box = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8 };
            TextBox[] tx_box_time = { textBox_time1, textBox_time2, textBox_time3, textBox_time4, textBox_time5, textBox_time6, textBox_time7, textBox_time8 };

            int timer;
            
            string temp;
            for (int i = 0;i < 8;i++)
            {
                send_handle(ch_box[i], tx_box_send[i], tx_box[i]);

                if (ckbox_avg_time.Checked == true)
                {
                    temp = textB_avg_time.Text;
                }
                else
                {
                    temp = tx_box_time[i].Text;
                }

                if (temp == "")
                {
                    timer = 0;
                }
                else
                {
                    timer = Convert.ToInt32(temp);
                }

                if (ch_box[i].Checked == true)
                {
                    Delay(timer);
                }
                
            }
            

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }                      
        private void label1_Click(object sender, EventArgs e)
        {

        }        
        private void button1_Click(object sender, EventArgs e)
        {
            if (!isOpened)
            {
                serialPort1.PortName  = comboBox1.Text;
                serialPort1.BaudRate = Convert.ToInt32(comboBox2.Text, 10);
                try
                {
                    serialPort1.Open();     //打开串口

                    button1.Text = "关闭串口";

                    comboBox1.Enabled = false;//关闭使能
                    comboBox2.Enabled = false;
                    isOpened = true;

                    open_comm_display();
        
                }
                catch
                {
                    MessageBox.Show("串口打开失败！");
                }
            }
            else
            {
                try
                {
                    serialPort1.Close();     //关闭串口
                    button1.Text = "打开串口";

                    comboBox1.Enabled = true;//打开使能
                    comboBox2.Enabled = true;
                    isOpened = false;

                    hide_part_init();
                }
                catch
                {
                    MessageBox.Show("串口关闭失败！");
                }
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (!isOpened) //如果没打开   
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }

            string strSend = sendBox.Text;
            byte[] bt;
            String_Handle str_hd = new String_Handle();

            if (send_hex_sel.Checked == true) //“16进制发送” 按钮   
            {

                strSend = String_Handle.del_noused_content(sendBox.Text);
                bt = String_Handle.StrTobyteArray(strSend);
                if(bt == null)
                {
                    MessageBox.Show("发送内容异常！", "Error");
                }
                else
                {
                    //Int16 _returnValue = CRC16(bt, bt.Length);
                    serialPort1.Write(bt, 0, bt.Length);
                    update_send_parametion(bt.Length);
                }


            }
            else //按字符串发送
            {
                //byte[] bt1 = System.Text.Encoding.Default.GetBytes(strSend);
                byte[] bt1;

                if (cb_nextline.Checked == true)
                {
                    strSend = strSend + "\r\n";
                    bt1 = System.Text.Encoding.Default.GetBytes(strSend);
                }
                else
                {
                    bt1 = System.Text.Encoding.Default.GetBytes(strSend);
                }

                serialPort1.Write(bt1, 0, bt1.Length);

                cur_sum.Text = Convert.ToString(strSend.Length);
                lb_sum_nubmer = lb_sum_nubmer + strSend.Length;
                lb_sum.Text = Convert.ToString(lb_sum_nubmer);

                if (strSend == "xhr5251@163.com")
                {
                    if (this.Width == hide_width) this.Width = window_width;
                    else this.Width = hide_width;
                }
            }

            //int ii = 0; //用于给byteBuffer赋值 >  
        }        
        private void button12_Click(object sender, EventArgs e)
        {
            receive_text.Clear();
            lb_receive_sum.Text = "0";
            lb_receive.Text = "0";

        }
        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void label9_Click(object sender, EventArgs e)
        {

        }
        private void clear_send_Click(object sender, EventArgs e)
        {
            sendBox.Clear ();
            //cur_sum.Text = "0";
        }
        private void button12_Click_1(object sender, EventArgs e)
        {
            lb_sum_nubmer = 0;
            lb_sum.Text = "0";
        }
        private void button13_Click(object sender, EventArgs e)
        {
            cur_sum.Text = "0";
        }
        private void label4_Click_1(object sender, EventArgs e)
        {

        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (button2.Text == "扩展  >>>")
            {
                button2.Text = "隐藏  <<<";

                if (this.Width == hide_width) this.Width = window_width;
                //else; 
            }
            else
            {
                button2.Text = "扩展  >>>";
                //splitContainer4.SplitterDistance = originWidth;
                this.Width = hide_width;
            }

        }
        
        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
                btn_send1.Enabled = true;
            else
                btn_send1.Enabled = false;
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
                btn_send2.Enabled = true;
            else
                btn_send2.Enabled = false;
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
                btn_send3.Enabled = true;
            else
                btn_send3.Enabled = false;
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
                btn_send4.Enabled = true;
            else
                btn_send4.Enabled = false;
        }
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
                btn_send5.Enabled = true;
            else
                btn_send5.Enabled = false;
        }
        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
                btn_send6.Enabled = true;
            else
                btn_send6.Enabled = false;
        }
        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
                btn_send7.Enabled = true;
            else
                btn_send7.Enabled = false;
        }
        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked == true)
                btn_send8.Enabled = true;
            else
                btn_send8.Enabled = false;
        }

        private void btn_send1_Click(object sender, EventArgs e)
        {
            CheckBox[] ch_box = { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8 };
            TextBox[] tx_box_send = { textBox_send1, textBox_send2, textBox_send3, textBox_send4, textBox_send5, textBox_send6, textBox_send7, textBox_send8 };
            TextBox[] tx_box = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8 };

            send_handle(ch_box[0], tx_box_send[0], tx_box[0]);
        }
        private void btn_send2_Click(object sender, EventArgs e)
        {
            CheckBox[] ch_box = { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8 };
            TextBox[] tx_box_send = { textBox_send1, textBox_send2, textBox_send3, textBox_send4, textBox_send5, textBox_send6, textBox_send7, textBox_send8 };
            TextBox[] tx_box = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8 };
            
            send_handle(ch_box[1], tx_box_send[1], tx_box[1]);
        }        
        private void btn_send3_Click(object sender, EventArgs e)
        {
            CheckBox[] ch_box = { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8 };
            TextBox[] tx_box_send = { textBox_send1, textBox_send2, textBox_send3, textBox_send4, textBox_send5, textBox_send6, textBox_send7, textBox_send8 };
            TextBox[] tx_box = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8 };

            send_handle(ch_box[2], tx_box_send[2], tx_box[2]);
        }
        private void btn_send4_Click(object sender, EventArgs e)
        {
            CheckBox[] ch_box = { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8 };
            TextBox[] tx_box_send = { textBox_send1, textBox_send2, textBox_send3, textBox_send4, textBox_send5, textBox_send6, textBox_send7, textBox_send8 };
            TextBox[] tx_box = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8 };

            send_handle(ch_box[3], tx_box_send[3], tx_box[3]);
        }
        private void btn_send5_Click(object sender, EventArgs e)
        {
            CheckBox[] ch_box = { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8 };
            TextBox[] tx_box_send = { textBox_send1, textBox_send2, textBox_send3, textBox_send4, textBox_send5, textBox_send6, textBox_send7, textBox_send8 };
            TextBox[] tx_box = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8 };

            send_handle(ch_box[4], tx_box_send[4], tx_box[4]);
        }
        private void btn_send6_Click(object sender, EventArgs e)
        {
            CheckBox[] ch_box = { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8 };
            TextBox[] tx_box_send = { textBox_send1, textBox_send2, textBox_send3, textBox_send4, textBox_send5, textBox_send6, textBox_send7, textBox_send8 };
            TextBox[] tx_box = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8 };

            send_handle(ch_box[5], tx_box_send[5], tx_box[5]);
        }
        private void btn_send7_Click(object sender, EventArgs e)
        {
            CheckBox[] ch_box = { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8 };
            TextBox[] tx_box_send = { textBox_send1, textBox_send2, textBox_send3, textBox_send4, textBox_send5, textBox_send6, textBox_send7, textBox_send8 };
            TextBox[] tx_box = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8 };

            send_handle(ch_box[6], tx_box_send[6], tx_box[6]);
        }
        private void btn_send8_Click(object sender, EventArgs e)
        {
            CheckBox[] ch_box = { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8 };
            TextBox[] tx_box_send = { textBox_send1, textBox_send2, textBox_send3, textBox_send4, textBox_send5, textBox_send6, textBox_send7, textBox_send8 };
            TextBox[] tx_box = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8 };

            send_handle(ch_box[7], tx_box_send[7], tx_box[7]);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "所有文件(*xls*)|*.xls*"; //设置要选择的文件的类型
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;//返回文件的完整路径     
                read_form_file(file);
            }


        }
        private void button4_Click(object sender, EventArgs e)
        {
            ShowSaveFileDialog();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            CheckBox[] ch_box = { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8 };
            TextBox[] tx_box_send = { textBox_send1, textBox_send2, textBox_send3, textBox_send4, textBox_send5, textBox_send6, textBox_send7, textBox_send8 };
            TextBox[] tx_box = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8 };
            TextBox[] tx_box_time = { textBox_time1, textBox_time2, textBox_time3, textBox_time4, textBox_time5, textBox_time6, textBox_time7, textBox_time8 };

            for (int i = 0; i < 8; i++)
            {
                ch_box[i].Checked = false;
                tx_box_send[i].Text = "";
                tx_box[i].Text = "";
                tx_box_time[i].Text = "";
            }
            //hide_part_init();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("    串口调试助手V1.0.0" + System.Environment.NewLine + "" + System.Environment.NewLine + "    xhr5251@163.com");
        }


        private void rdo_crc_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_crc.Checked == true)
            {
                comb_crc_type.Text = "CRC16";
            }
            else 
            {
                comb_crc_type.Text = "";
            }
        }
        private void rdo_mod_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //comb_crc_type.Text = "CRC16";
        }
        private void rdo_hex_text_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void rdo_string_text_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_string_text.Checked == true)
            {
                rdo_check_null.Checked = true;

                rdo_crc.Enabled = false;
                rdo_mod.Enabled = false;
                comb_crc_type.Text = "";

            }
            else
            {
                rdo_crc.Enabled = true;
                rdo_mod.Enabled = true;
            }
        }
        private void checkB_all_sel_CheckedChanged(object sender, EventArgs e)
        {
            if (checkB_all_sel.CheckState == CheckState.Checked)
            {
                foreach (CheckBox ck in panel_mul_sel.Controls)
                    ck.Checked = true;
            }
            else
            {
                foreach (CheckBox ck in panel_mul_sel.Controls)
                    ck.Checked = false;
            }
        }
        private void ck_timer_send_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_timer_send.Checked == true)
            {
                timer1.Interval = Convert.ToInt16(tx_timer_send.Text, 10);
                //启动定时器
                timer1.Start();
            }
            else
            {
                timer1.Stop();
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void ck_child_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            if (c.Checked == true)
            {
                foreach (CheckBox ch in panel_mul_sel.Controls)
                {
                    if (ch.Checked == false) //ch.Checked = true;
                        return;
                }
            }
            else
            {

            }
        }

        private void receive_text_TextChanged(object sender, EventArgs e)
        {

        }

        private void cb_receive_hex_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_receive_hex.Checked == true)
            {
                    //string input = "Hello World!";
                    char[] values = receive_text.Text.ToCharArray();
                    this.receive_text.Clear();
                    foreach (char letter in values)
                    {
                        // Get the integral value of the character.
                        int value = Convert.ToInt32(letter);
                        // Convert the decimal value to a hexadecimal value in string form.
                        string hexOutput = String.Format("{0:X}", value);
                        //Console.WriteLine("Hexadecimal value of {0} is {1}", letter, hexOutput);
                        this.receive_text.AppendText(hexOutput + " ");
                    } 
                
            }
            else
            {
                byte[] bt1;
                string str = "";
                //bt1 = System.Text.Encoding.Default.GetBytes(receive_text.Text);
                bt1 = String_Handle.StrTobyteArray(receive_text.Text);

                //serialPort1.Write(bt1, 0, bt1.Length);

                this.receive_text.Clear();

                string s = Encoding.ASCII.GetString(bt1);

                this.receive_text.AppendText(s);                

            }
        }        
    }
}



