using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MifareLibrary
{
    public enum Mode { RequstAllCards=0x52, RequestNonHaltCard=0x26};
    public enum KeyType { KeyA=0x60, KeyB=0x61 };
    public enum TagType 
    {
        UltraLight=0x4400,
        S50=0x0400,
        S70=0x0200,
        DESFire=0x4403,
        Pro=0x0800,
        ProX=0x0403,
        SHC1102=0x0033,
        None=0x0000
    };
    //New Enum type added to distinguish between 4 block sector and 16 block sector

    public enum Sector {LowerSector, UpperSector};

    // Phillips (NXP) ISO14443A standard
    public interface ISO14443A
    {
        //TagType Request(ushort deviceid, Mode mode);
        //void Select(ushort deviceid);
        //byte[] Read(ushort deviceid, int blockno);
        //void Write(ushort deviceid, byte[] data, int blockno);
        //void Halt(ushort deviceid);
        //void Connect(int port, int baud);
        string GetTagSerialNumber(ushort deviceid, ref byte len);
        TagType GetTagType(ushort deviceid);
        IMifareDll Dll { get; }

        //void SetTagOnActivationStatus(ushort deviceid);
        //void SetTagKey(ushort deviceid, byte[] key);
        
        //void HaltCard(ushort deviceid);
        //void WriteBlock(ushort deviceid, ushort blockno);
        //byte[] ReadBlock(ushort deviceid, ushort blockno, ushort len);
        //void WriteSector(ushort deviceid, ushort sectorno);
        //byte[] ReadSector(ushort deviceid, ushort sectorno, ushort len);
        
        //void Beep(ushort deiveid, ushort duration);
        //void SetLED(ushort deivceid, ushort color);
        //int GetDeivceNo();
        //void InitDeviceNo(ushort deviceid);
    }
}
