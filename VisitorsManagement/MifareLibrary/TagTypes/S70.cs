using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MifareLibrary
{
    public class S70 : IMifareStd
    {
        public IMifareDll Dll { get; set; }
        public S70(IMifareDll Dll)
        {
            this.Dll = Dll;
        }
        #region MifareStd Members


        public void Connect(int port, int baud)
        {
            try
            {
                Dll.Connect(port, baud);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public TagType Request(ushort deviceid, Mode mode)
        {
            TagType type = TagType.None;
            try
            {
                type = Dll.Request(deviceid, mode);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return type;
        }

        public ushort Select(ushort deviceid, string sn, byte len)
        {
            return Dll.Select(deviceid, sn, len);
        }

        public byte[] Read(ushort deviceid, byte blockno, KeyType keyType, byte[] key)
        {
            return Dll.Read(deviceid, blockno, keyType, key);
        }

        public byte[] Read(ushort deviceid, byte sectorno, byte blockno, KeyType keyType, byte[] key)
        {
            return Dll.Read(deviceid, sectorno, blockno, keyType, key);
        }

        public void Write(ushort deviceid, byte[] data, int blockno)
        {
            throw new NotImplementedException();
        }

        public void Halt(ushort deviceid)
        {
            throw new NotImplementedException();
        }

        public string Anticoll(ushort deviceid, ref byte len)
        {
            try
            {
                return Dll.Anticollision(deviceid, ref len);
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public void Authenticate(ushort deviceid, KeyType keyModel, byte blockno, byte[] key)
        {
            try
            {
                Dll.Authenticate(deviceid, keyModel, blockno, key);
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }
        #region Purse Functions
        public void InitVal()
        {
        }

        public void Increment()
        {
        }

        public void Decrement()
        {
        }

        public void ReadVal()
        {
        }

        public void Restore()
        {
        }

        public void Transfer()
        {
        }
        #endregion

        #endregion

        #region ISO14443A Members

        public string GetTagSerialNumber(ushort deviceid, ref byte len)
        {
            return Anticoll(deviceid, ref len);
        }

        public TagType GetTagType(ushort deviceid)
        {
            try
            {
                return Request(deviceid, Mode.RequstAllCards);
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        #endregion

        #region IMifareStd Members


        public void Write(ushort deviceid, byte blockno, byte[] data, KeyType keyType, byte[] key)
        {
            try
            {
                Dll.Write(deviceid, blockno, data, keyType, key);
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public void Write(ushort deviceid, byte sectorno, byte blockno, byte[] data, KeyType keyType, byte[] key)
        {
            try
            {
                Dll.Write(deviceid, sectorno, blockno, data, keyType, key);
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        #endregion
    }
}