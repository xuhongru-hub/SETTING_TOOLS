using System;
using CRC_App;


namespace mySpace
{
    public class Send
    {
        int check_type;
        int delay_time;
        int send_enable;

        public Send(int check, int dly_time, int s_enable)
        {
            check_type = check;
            delay_time = dly_time;
            send_enable = s_enable;
        }
        public byte[] send_String(string text)
        {
            byte[] bt;

            String_Handle str_hd = new String_Handle();

            String str = String_Handle.del_noused_content(text);
            bt = System.Text.Encoding.Default.GetBytes(str);
            return bt;
        }
        public byte[] send_Hex(string text)
        {
            byte[] bt;
            Int16 crc_value;

            String_Handle str_hd = new String_Handle();
            CRC_Handle crc = new CRC_Handle();

            String str = String_Handle.del_noused_content(text);

            bt = String_Handle.StrTobyteArray(str);
            //bt = System.Text.Encoding.Default.GetBytes(str);
            if (bt == null)
            {
                return bt;
            }
            else
            {
                

                if (check_type == 1)//crc
                {
                    byte[] bt2 = new byte[bt.Length + 2];

                    for (int i = 0; i < bt.Length; i++)
                    {
                        bt2[i] = bt[i];
                    }
                    crc_value = crc.CRC16(bt, bt.Length);
                    bt2[bt.Length] = (byte)(crc_value % 256);
                    bt2[bt.Length + 1] = (byte)(crc_value / 256);
                    return bt2;
                }
                else if (check_type == 2)//mod
                {
                    byte[] bt2 = new byte[bt.Length + 1];

                    Byte check = new Byte();
                    check = 0;
                    
                    for (int i = 0; i < bt.Length; i++)
                    {
                        bt2[i] = bt[i];
                        check = (byte)(check + bt[i]);
                    }
                    bt2[bt.Length] = check;
                    return bt2;

                }
                else 
                {
                    byte[] bt2 = new byte[bt.Length];

                    for (int i = 0; i < bt.Length; i++)
                    {
                        bt2[i] = bt[i];
                    }
                    return bt2;
                }                                   
                
            }
        }  
    }

    public class String_Handle
    {
        public String_Handle()
        {          
        }
        public static String del_noused_content(string text)
        {
            String strSend;

            strSend = text.Trim();                     //去掉前后空格
            strSend = strSend.Replace(',', ' ');          //去掉英文逗号 
            strSend = strSend.Replace('，', ' ');         //去掉中文逗号   

            strSend = strSend.Replace("0x", "");          //去掉0x   
            strSend = strSend.Replace("0X", "");          //去掉0X
            strSend = strSend.Replace(" ", "");           //去掉所有空格

            return strSend;
        }

        public static byte[] StrToHexByte(string hexString)
        {
            //hexString = hexString + '\0';
            byte[] returnBytes = new byte[(hexString.Length + 1) / 2];

            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

        public static byte[] StrTobyteArray(string text)
        {
            String str;
            byte[] bt;

            str = del_noused_content(text);

            if ((str.Length % 2) != 0)
            {
                //MessageBox.Show("发送内容异常！", "Error");
                return null;
            }
            else
            {
                bt = StrToHexByte(str);
                return bt;
            }            
        }

        public static int StrLength(string inputString)
        {
            System.Text.ASCIIEncoding ascii = new System.Text.ASCIIEncoding();
            int tempLen = 0;
            byte[] s = ascii.GetBytes(inputString);
            for (int i = 0; i < s.Length; i++)
            {
                if ((int)s[i] == 63)
                    tempLen += 2;
                else
                    tempLen += 1;
            }
            return tempLen;
        }

        public static byte StrCheck(byte[] s)
        {
            byte check = 0;

            for (int i = 0; i < s.Length; i++)
            {
                check += s[i];
            }
            return check;
        }

        public static int StrFind(string src, string obj)
        {
            int index;

            index = obj.IndexOf(src);

            return index;
        }

        public static string StrFormByteArray(byte[] bt,int len)
        {
            string str="";
            char[] HexChar = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
            //bt = StrToHexByte(indata);
            for (int i = 0; i < len; i++)
            {
                char hexH = HexChar[bt[i] / 16];
                char hexL = HexChar[bt[i] % 16];
                str += hexH.ToString();
                str += hexL.ToString();
                str += " ";
            }
            return str;
        }
    }
}