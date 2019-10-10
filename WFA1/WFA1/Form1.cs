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
using parameter_handle;

namespace parameter_handle
{
    public partial class Form1 : Form
    {

        //int lb_sum_nubmer;
        int window_width;
        int hide_width = 640*2;
        bool isOpened = false;//串口状态标志

        byte[] g_receive_buff = new byte[128];
        int g_receive_len = 0;

        //int lb_receivesum_nubmer = 0;

        public Form1()
        {
            InitializeComponent();
         
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            GetComList();


            //设置默认值
            comboBox1.Text = "COM1";
            //comboBox2.Text = "9600";

            serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);

            //timer1.Interval = 1000;
            //timer1.Start();


            window_width = this.Width;
            this.Width = hide_width;
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

        /*
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
             //update_send_parametion(bt.Length);

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
             //CheckBox[] ch_box = { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8 };
             TextBox[] tx_box_send = { textBox_send1, textBox_send2, textBox_send3, textBox_send4, textBox_send5, textBox_send6, textBox_send7, textBox_send8 };
             TextBox[] tx_box = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, receive_text, textBox8 };
             TextBox[] tx_box_time = { textBox_r1, textBox_r2, textBox_r3, textBox_time4, textBox_time5, textBox_time6, textBox_time7, textBox_time8 };

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
             //CheckBox[] ch_box = { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8 };
             TextBox[] tx_box_send = { textBox_send1, textBox_send2, textBox_send3, textBox_send4, textBox_send5, textBox_send6, textBox_send7, textBox_send8 };
             TextBox[] tx_box = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, receive_text, textBox8 };
             TextBox[] tx_box_time = { textBox_r1, textBox_r2, textBox_r3, textBox_time4, textBox_time5, textBox_time6, textBox_time7, textBox_time8 };

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

        */

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

                //write_to_file(fileNameExt);
            }

            return localFilePath;
        }
              
     

        private void timer1_Tick(object sender, EventArgs e)
        {
            //callOnClick(bt_send);  
            //bt_send.PerformClick();
        }
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //byte[] bt = 4096;
            int i;

            SerialPort sp = (SerialPort)sender;
            int len = sp.BytesToRead;
            byte[] bt = new byte[len];

            sp.Read(bt, 0, len);
            for(i=0;i<len;i++)
            {
                g_receive_buff[i] = bt[i];
            }
            g_receive_buff[i] = 0;

            g_receive_len = len;

            
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
                     
                    string str = System.Text.Encoding.Default.GetString(bt);
                    this.receive_text.AppendText(str);//输出到主窗口文本控件
                 }
             )
             );
        }
        
       
       
        //打开串口按钮------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            if (!isOpened)
            {
                serialPort1.PortName  = comboBox1.Text;
                serialPort1.BaudRate  = 9600;
                try
                {
                    serialPort1.Open();     //打开串口

                    button1.Text = "关闭串口";

                    comboBox1.Enabled = false;//关闭使能
                    //comboBox2.Enabled = false;
                    isOpened = true;

                    //open_comm_display();
        
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
                    //comboBox2.Enabled = true;
                    isOpened = false;

                    //hide_part_init();
                }
                catch
                {
                    MessageBox.Show("串口关闭失败！");
                }
            }

        }
        /*
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
         */
         
        
       
       
      

       
        //载入当前配置----------------------------------------
        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "所有文件(*xls*)|*.xls*"; //设置要选择的文件的类型
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;//返回文件的完整路径     
                //read_form_file(file);
            }
        }

        //保存当前配置---------------------------------------
        private void button4_Click(object sender, EventArgs e)
        {
            ShowSaveFileDialog();
        }
        /*
        private void button3_Click(object sender, EventArgs e)
        {
            //CheckBox[] ch_box = { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8 };
            TextBox[] tx_box_send = { textBox_send1, textBox_send2, textBox_send3, textBox_send4, textBox_send5, textBox_send6, textBox_send7, textBox_send8 };
            TextBox[] tx_box = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, receive_text, textBox8 };
            TextBox[] tx_box_time = { textBox_r1, textBox_r2, textBox_r3, textBox_time4, textBox_time5, textBox_time6, textBox_time7, textBox_time8 };

            for (int i = 0; i < 8; i++)
            {
                //ch_box[i].Checked = false;
                tx_box_send[i].Text = "";
                tx_box[i].Text = "";
                tx_box_time[i].Text = "";
            }
            //hide_part_init();
        }*/
        //关于软件
        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("    串口调试助手V1.0.0" + System.Environment.NewLine + "" + System.Environment.NewLine + "    xhr5251@163.com");
        }

        //MQTT基本参数发送
        private void button2_Click_2(object sender, EventArgs e)
        {
            byte[] bt = new byte[128];
            byte[] tmp = new byte[128];
            int len;
            string str;

            int Product_KEY   = 0xA0;
            int Device_NAME   = 0xC0;
            int Device_SECRET = 0xE0;

            //发送Product_KEY ----------------------------------------------------------------------
            len = String_Handle.StrLength(textBox_send1.Text);
            if (len == 0)
            {
                MessageBox.Show("数据为空或者位数不合法！");
                return;
            }

            bt[0] = 0xAA;
            bt[1] = 0xB0;
            bt[2] = (Byte) (Product_KEY / 0x100);
            bt[3] = (Byte) (Product_KEY % 0x100);
            bt[4] = (Byte) (len / 0x100);
            bt[5] = (Byte) (len % 0x100);

            //tmp[] = String_Handle.StrTobyteArray(textBox_send1.Text);
            tmp =  System.Text.Encoding.Default.GetBytes(textBox_send1.Text);
            for (int i = 0; i < len; i++)
            { 
                bt[6 + i] = tmp[i];
            }

            bt[6 + len] = String_Handle.StrCheck(bt);

            serialPort1.Write(bt, 0, len+6);

            str = String_Handle.StrFormByteArray(bt,len+7);
            this.send_text.AppendText(str);

            Delay(1000);
            int index = String_Handle.StrFind(receive_text.Text, "product_key setting ok");
            if (index < 0)
            {
                MessageBox.Show("未收到应答！");
            }
 

            //发送Device_NAME ----------------------------------------------------------------------
            len = String_Handle.StrLength(textBox_send2.Text);
            if (len == 0)
            {
                MessageBox.Show("数据为空或者位数不合法！");
                return;
            }
            
            bt[0] = 0xAA;
            bt[1] = 0xB0;
            bt[2] = (Byte)(Device_NAME / 0x100);
            bt[3] = (Byte)(Device_NAME % 0x100);
            bt[4] = (Byte)(len / 0x100);
            bt[5] = (Byte)(len % 0x100);

            tmp = System.Text.Encoding.Default.GetBytes(textBox_send2.Text);
            for (int i = 0; i < len; i++)
            {
                bt[6 + i] = tmp[i];
            }

            bt[6 + len] = String_Handle.StrCheck(bt);

            serialPort1.Write(bt, 0, len + 6);

            str = String_Handle.StrFormByteArray(bt, len + 7);
            this.send_text.AppendText(str);

            Delay(1000);
            index = String_Handle.StrFind(receive_text.Text, "device_name setting ok");
            if (index < 0)
            {
                MessageBox.Show("未收到应答！");
            }

            //发送Device_SECRET ----------------------------------------------------------------------
            len = String_Handle.StrLength(textBox_send3.Text);
            if (len == 0)
            {
                MessageBox.Show("数据为空或者位数不合法！");
                return;
            }

            bt[0] = 0xAA;
            bt[1] = 0xB0;
            bt[2] = (Byte)(Device_SECRET / 0x100);
            bt[3] = (Byte)(Device_SECRET % 0x100);
            bt[4] = (Byte)(len / 0x100);
            bt[5] = (Byte)(len % 0x100);

            tmp = System.Text.Encoding.Default.GetBytes(textBox_send3.Text);
            for (int i = 0; i < len; i++)
            {
                bt[6 + i] = tmp[i];
            }

            bt[6 + len] = String_Handle.StrCheck(bt);

            serialPort1.Write(bt, 0, len + 6);
            str = String_Handle.StrFormByteArray(bt, len + 7);
            this.send_text.AppendText(str);
            Delay(1000);
            index = String_Handle.StrFind(receive_text.Text, "device_secret setting ok");
            if (index < 0)
            {
                MessageBox.Show("未收到应答！");
            }
        }


        
        //WIFI参数写入
        private void button13_Click(object sender, EventArgs e)
        {
            byte[] bt = new byte[128];
            byte[] tmp = new byte[128];
            int len;
            string str;

            int WIFI_SSID_ADDR = 0x20;
            int WIFI_PASSWORD_ADDR = 0x60;


            //发送WIFI_SSID ----------------------------------------------------------------------
            len = String_Handle.StrLength(wifi_ssid_text.Text);
            if (len == 0)
            {
                MessageBox.Show("数据为空或者位数不合法！");
                return;
            }

            bt[0] = 0xAA;
            bt[1] = 0xB0;
            bt[2] = (Byte)(WIFI_SSID_ADDR / 0x100);
            bt[3] = (Byte)(WIFI_SSID_ADDR % 0x100);
            bt[4] = (Byte)(len / 0x100);
            bt[5] = (Byte)(len % 0x100);

            //tmp[] = String_Handle.StrTobyteArray(textBox_send1.Text);
            tmp = System.Text.Encoding.Default.GetBytes(wifi_ssid_text.Text);
            for (int i = 0; i < len; i++)
            {
                bt[6 + i] = tmp[i];
            }

            bt[6 + len] = String_Handle.StrCheck(bt);

            serialPort1.Write(bt, 0, len + 6);

            str = String_Handle.StrFormByteArray(bt, len + 7);
            this.send_text.AppendText(str);

            Delay(1000);
            int index = String_Handle.StrFind(receive_text.Text, "wifi_ssid setting ok");
            if (index < 0)
            {
                MessageBox.Show("未收到应答！");
            }


            //发送WIFI_PASSWORD ----------------------------------------------------------------------
            len = String_Handle.StrLength(wifi_password_text.Text);
            if (len == 0)
            {
                MessageBox.Show("数据为空或者位数不合法！");
                return;
            }

            bt[0] = 0xAA;
            bt[1] = 0xB0;
            bt[2] = (Byte)(WIFI_PASSWORD_ADDR / 0x100);
            bt[3] = (Byte)(WIFI_PASSWORD_ADDR % 0x100);
            bt[4] = (Byte)(len / 0x100);
            bt[5] = (Byte)(len % 0x100);

            tmp = System.Text.Encoding.Default.GetBytes(wifi_password_text.Text);
            for (int i = 0; i < len; i++)
            {
                bt[6 + i] = tmp[i];
            }

            bt[6 + len] = String_Handle.StrCheck(bt);

            serialPort1.Write(bt, 0, len + 6);

            str = String_Handle.StrFormByteArray(bt, len + 7);
            this.send_text.AppendText(str);

            Delay(1000);
            index = String_Handle.StrFind(receive_text.Text, "wifi_password setting ok");
            if (index < 0)
            {
                MessageBox.Show("未收到应答！");
            }


        }
        //WIFI参数读出
        private void button12_Click(object sender, EventArgs e)
        {
            byte[] bt = new byte[128];
            byte[] tmp = new byte[128];
            int res;
            string str;

            int WIFI_SSID_ADDR = 0x20;
            int WIFI_PASSWORD_ADDR = 0x60;
            int MAX_LEN = 64;

            wifi_ssid_text.Text = "";
            wifi_password_text.Text = "";

            //读取WIFI_SSID ----------------------------------------------------------------------
            bt = parameter.fill_frame(0xAA, 0xC0, WIFI_SSID_ADDR, MAX_LEN);

            serialPort1.Write(bt, 0, 6);

            Delay(500);

            res = parameter.receive_check(g_receive_buff,g_receive_len);
            if (res == 0)
            {
                MessageBox.Show("校验错误！");
            }
            str = parameter.get_parameter(g_receive_buff,g_receive_len);
            wifi_password_text.Text = str;
            //读取WIFI_PASSWORD ----------------------------------------------------------------------
            bt = parameter.fill_frame(0xAA, 0xC0, WIFI_PASSWORD_ADDR, MAX_LEN);

            serialPort1.Write(bt, 0, 6);

            Delay(500);

            res = parameter.receive_check(g_receive_buff,g_receive_len);
            if (res == 0)
            {
                MessageBox.Show("校验错误！");
            }
            str = parameter.get_parameter(g_receive_buff,g_receive_len);
            wifi_password_text.Text = str;



        }
        //MQTT基本参数读出
        private void button10_Click(object sender, EventArgs e)
        {

        }
        //订阅写入
        private void btn_batch_send_Click(object sender, EventArgs e)
        {

        }
        //订阅读出
        private void button11_Click(object sender, EventArgs e)
        {

        }        
    }
}



