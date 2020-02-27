using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace ChinaReaderMifareLibrary
{
    public class ChinaReaderAPI
    {
        public const string dll = "MasterRD.dll";

        [DllImport(dll, EntryPoint = "rf_halt")]
        public static extern int rf_halt(ushort icdev);

        //int WINAPI rf_M1_write(unsigned short icdev, unsigned char block, unsigned char *data);
        [DllImport(dll, EntryPoint = "rf_M1_write")]
        public static extern int rf_M1_write(ushort icdev, byte block, byte[] data);

        //int WINAPI rf_M1_read(unsigned short icdev, unsigned char block, unsigned char *ppData, unsigned char *pLen);
        [DllImport(dll, EntryPoint = "rf_M1_read")]
        public static extern int rf_M1_read(ushort icdev, byte block, byte[] data, ref byte len);

        //int WINAPI rf_M1_authentication2(unsigned short icdev,unsigned char model,unsigned char block, unsigned char *key);
        [DllImport(dll, EntryPoint = "rf_M1_authentication2")]
        public static extern int rf_M1_authentication2(ushort icdev, byte model, byte block, byte[] key);

        [DllImport("MasterRD.dll")]
        public static extern int rf_init_com(int port, int baud);

        //int WINAPI rf_select(unsigned short icdev,unsigned char *pSnr,unsigned char srcLen, unsigned char *Size);
        [DllImport(dll, EntryPoint = "rf_select")]
        public static extern int rf_select(ushort icdev, byte[] serialNum, byte srcLen, ref ushort size);

        //int WINAPI rf_anticoll(unsigned short icdev, unsigned char bcnt, unsigned char *ppSnr, unsigned char* pRLength);
        [DllImport(dll, EntryPoint = "rf_anticoll")]
        public static extern int rf_anticoll(ushort icdev, byte bcnt, byte[] ptrSnr, ref byte pRLenght);

        //int WINAPI rf_request(unsigned short icdev, unsigned char model, unsigned short *TagType);
        [DllImport(dll, EntryPoint = "rf_request")]
        public static extern int rf_request(ushort icdev, byte model, ref ushort TagType);

        [DllImport(dll, EntryPoint = "rf_light")]
        public static extern int rf_light(short icdev, Int32 value);
        
        [DllImport(dll, EntryPoint = "rf_beep")]
        public static extern int rf_beep(short icdev, Int32 millisecs);



        /***************************************************************************************/
        //S70 Extra Commands (specific to S70 cards for faster reading and writing)
        /***************************************************************************************/

        [DllImport("MasterRD.dll", EntryPoint = "rf_ClosePort")]
        public static extern int rf_ClosePort();


        [DllImport("MasterRD.dll", EntryPoint = "rf_s70_select")]
        public static extern int rf_s70_select(byte icdev, byte[] pData, ref byte retLen);

        [DllImport("MasterRD.dll", EntryPoint = "rf_s70_read")]
        public static extern int rf_s70_read(byte icdev, byte ReadMode, byte address, byte KeyMode, byte[] Key, byte[] pData, ref ulong retLen);

        [DllImport("MasterRD.dll", EntryPoint = "rf_s70_write")]
        public static extern int rf_s70_write(byte icdev, byte WriteMode, byte address, byte KeyMode, byte[] Key, byte[] pData, ulong retLen);
          

    }
}
