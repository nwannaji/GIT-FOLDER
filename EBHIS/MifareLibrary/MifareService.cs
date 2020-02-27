using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MifareLibrary
{
    public class MifareService
    {
        ISO14443A tag;
        IMifareDll dll;
        public MifareService(IMifareDll dll)
        {
            this.dll = dll;
        }

        public MifareService(ISO14443A tag)
        {
            this.tag = tag;
            this.dll = tag.Dll;
        }

        public TagType GetTagType(ushort deviceid, Mode mode)
        {
            //int type = tag.Request(deviceid, mode);
            if (dll == null) return TagType.None;

            return dll.Request(deviceid, mode);
           
        }

        public ushort Select(ushort deviceid, string sn, byte len)
        {
            return dll.Select(deviceid, sn, len);
        }

        public string GetTagSerialNumber(ushort deviceid, ref byte len)
        {
            //if (tag == null) throw new Exception("Object reference not set to an instance.");
            try
            {
                return tag.GetTagSerialNumber(deviceid, ref len);
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public void Write(ushort deviceid, byte blockno, byte[] data, KeyType keyType, byte[] key)
        {
            try
            {
                dll.Write(deviceid, blockno, data, keyType, key);
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public void Write2(ushort deviceid, byte blockno, byte[] data, KeyType keyType, byte[] key)
        {
            try
            {
                dll.Write2(deviceid, blockno, data, keyType, key);
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public void Write(ushort deviceid, byte sectorno, byte blockno, byte[] data, KeyType keyType, byte[] key)
        {
            try
            {
                dll.Write(deviceid, sectorno, blockno, data, keyType, key);
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public void Authenticate(ushort deviceid, KeyType keyModel, byte blockno, byte[] key)
        {
            try
            {
                dll.Authenticate(deviceid, keyModel, blockno, key);
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public void Connect(int port, int baud)
        {
            dll.Connect(port, baud);
        }

        public byte[] Read(ushort deviceid, byte blockno, KeyType keyType, byte[] key)
        {
            return dll.Read(deviceid, blockno, keyType, key);
        }

        public void SetTagKey(ushort deviceid, byte[] key)
        {
        }

        /***************************************/
        /**new read and write additions*********/
        public byte[] Read(ushort deviceid, byte[] blksToRead, KeyType keyType, byte[] key)
        {
            return dll.Read(deviceid, blksToRead, keyType, key);
        }

        public void ReadS70BySector(byte deviceID, byte readMode, byte sectorAddress, byte keyMode, byte[] key,ref byte[] data, ref ulong lengthOfData)
        {
            dll.ReadS70BySector(deviceID, readMode, sectorAddress, keyMode, key, ref data, ref lengthOfData);
            //return data;
        }

        public void WriteS70BySector(byte deviceID, byte writeMode, byte sectorAddress, byte keyMode, byte[] key, byte[] data, ulong lengthOfData)
        {
            dll.WriteS70BySector(deviceID, writeMode, sectorAddress, keyMode, key, data, lengthOfData);
        }

        public void Write(ushort deviceid, byte[] blksToWrite, byte[] data, KeyType keyType, byte[] key)
        {
            dll.Write(deviceid, blksToWrite, data, keyType, key);        
        }

        /*********************************************/
        /***new beep and light functions**************/

        public bool light(short icdev, Int32 colour)
        {
            return dll.light(icdev, colour);
        }
        
        public bool beep(short icdev, Int32 millisecs) 
        {
            return dll.beep(icdev, millisecs);           
        }

        //public byte[] Read(ushort deviceid, byte[] blksToRead, KeyType keyType, byte[] key, Sector typeOfSector) 
        //{        
        //    return dll.Read(deviceid,blksToRead,keyType,key,typeOfSector);
        //}
    }
}
