using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mySpace;


namespace parameter_handle
{

    public class parameter
    {
        int check_type;
        int delay_time;
        int send_enable;


        public static int receive_check(byte[] bt,int len)
        {
            byte check = 0;
            //int len = bt.Length;

            for (int i = 0; i < len-1; i++)
            {
                check += bt[i];
            }
            if (check == bt[len])  return 1;
            else return 0;        
        }
        //在接收到的串中，提取出参数。 参数前4字节包头，参数后1字节校验和
        public static string get_parameter(byte[] bt,int len)
        {
            byte[] new_bt = new byte[64];
            //int len = bt.Length;

            for (int i=0;i<(len-5); i++)
            {
                new_bt[i] = bt[4 + i];
            }

            string str = System.Text.Encoding.Default.GetString(new_bt);

            return str;
        }

        public static byte[] fill_frame(byte head,byte cmd,int addr,int len)
        {
            byte[] bt = new byte[64];

            bt[0] = head;
            bt[1] = cmd;
            bt[2] = (Byte)(addr / 0x100);
            bt[3] = (Byte)(addr % 0x100);
            bt[4] = (Byte)(len / 0x100);
            bt[5] = (Byte)(len % 0x100);
            bt[6] = String_Handle.StrCheck(bt);

            return bt;
        }

    }
}
