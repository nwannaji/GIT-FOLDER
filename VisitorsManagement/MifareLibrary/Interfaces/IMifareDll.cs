using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MifareLibrary
{
    public interface IMifareDll
    {
        TagType Request(ushort deviceid, Mode mode);
        string Anticollision(ushort deviceid, ref byte len);
        void Authenticate(ushort deviceid, KeyType keyModel, byte blockno, byte[] key);
        ushort Select(ushort deviceid, string sn, byte len);
        byte[] Read(ushort deviceid, byte blockno, KeyType keyType, byte[] key);
        byte[] Read(ushort deviceid, byte sectorno, byte blockno, KeyType keyType, byte[] key);
        void Write(ushort deviceid, byte blockno, byte[] data, KeyType keyType, byte[] key);
        void Write2(ushort deviceid, byte blockno, byte[] data, KeyType keyType, byte[] key);
        void Write(ushort deviceid, byte sectorno, byte blockno, byte[] data, KeyType keyType, byte[] key);
        void Connect(int port, int baud);
        
        /***************************************/
        /**new read and write additions*********/
        //byte[] Read(ushort deviceid, byte[] blksToRead, KeyType keyType, byte[] key, Sector typeOfSector);
        byte[] Read(ushort deviceid, byte[] blksToRead, KeyType keyType, byte[] key);
        void Write(ushort deviceid, byte[] blksToWrite, byte[] data, KeyType keyType, byte[] key);
        void ReadS70BySector(byte deviceID, byte readMode, byte SectorAddress, byte keyMode, byte[] key, ref byte[] data, ref ulong lengthOfData);
        void WriteS70BySector(byte deviceID, byte writeMode, byte SectorAddress, byte keyMode, byte[] key, byte[] data, ulong lengthOfData);
        /*********************************************/
        /***new beep and light functions**************/
        bool light(short icdev, Int32 colour);
        bool beep(short icdev, Int32 millisecs);
    }
}
