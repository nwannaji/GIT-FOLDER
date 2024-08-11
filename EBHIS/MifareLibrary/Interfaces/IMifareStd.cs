using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MifareLibrary
{
    // applies to Mifare Standard specification smart cards 
    // i.e. S50 & S70 PICCs
    public interface IMifareStd : ISO14443A
    {
        TagType Request(ushort deviceid, Mode mode);
        ushort Select(ushort deviceid, string sn, byte len);
        byte[] Read(ushort deviceid, byte blockno, KeyType keyType, byte[] key);
        byte[] Read(ushort deviceid, byte sectorno, byte blockno, KeyType keyType, byte[] key);
        void Write(ushort deviceid, byte blockno, byte[] data, KeyType keyType, byte[] key);
        void Write(ushort deviceid, byte sectorno, byte blockno, byte[] data, KeyType keyType, byte[] key);
        void Halt(ushort deviceid);
        void Connect(int port, int baud);
        string Anticoll(ushort deviceid, ref byte len);
        void Authenticate(ushort deviceid, KeyType keyModel, byte blockno, byte[] key);

        // purse functions
        void InitVal();
        void Increment();
        void Decrement();
        void ReadVal();
        void Restore();
        void Transfer();
    }
}
