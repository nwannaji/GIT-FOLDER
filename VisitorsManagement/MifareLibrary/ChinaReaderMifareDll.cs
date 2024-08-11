using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace MifareLibrary
{
    public class ChinaReaderMifareDll : I3rdPartyMifareDll
    {
        public const string dll = "MasterRD.dll";

        [DllImport(dll, EntryPoint = "rf_halt")]
        public static extern int rf_halt(byte icdev);

        //int WINAPI rf_M1_write(unsigned short icdev, unsigned char block, unsigned char *data);
        [DllImport(dll, EntryPoint = "rf_M1_write")]
        public static extern int rf_M1_write(byte icdev, byte block, byte[] data);

        //int WINAPI rf_M1_read(unsigned short icdev, unsigned char block, unsigned char *ppData, unsigned char *pLen);
        [DllImport(dll, EntryPoint = "rf_M1_read")]
        public static extern int rf_M1_read(byte icdev, byte block, byte[] data, ref byte len);

        //int WINAPI rf_M1_authentication2(unsigned short icdev,unsigned char model,unsigned char block, unsigned char *key);
        [DllImport(dll, EntryPoint = "rf_M1_authentication2")]
        public static extern int rf_M1_authentication2(byte icdev, byte model, byte block, byte[] key);

        //int WINAPI rf_select(unsigned short icdev,unsigned char *pSnr,unsigned char srcLen, unsigned char *Size);
        [DllImport(dll, EntryPoint = "rf_select")]
        public static extern int rf_select(byte icdev, byte[] serialNum, byte srcLen, ref byte size);

        //int WINAPI rf_anticoll(unsigned short icdev, unsigned char bcnt, unsigned char *ppSnr, unsigned char* pRLength);
        [DllImport(dll, EntryPoint = "rf_anticoll")]
        public static extern int rf_anticoll(byte icdev, byte bcnt, byte[] ptrSnr, ref byte pRLenght);

        //int WINAPI rf_request(unsigned short icdev, unsigned char model, unsigned short *TagType);
        [DllImport(dll, EntryPoint = "rf_request")]
        public static extern int rf_request(ushort icdev, byte model, ref ushort TagType);
    }
}
