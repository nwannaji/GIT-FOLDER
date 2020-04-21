using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using MifareLibrary;
using ChinaReaderMifareLibrary;

namespace ChinaReaderMifareLibrary
{
    public class ChinaReaderMifareDll : IMifareDll
    {
        #region IMifareDll Members
        public TagType Request(ushort deviceid, Mode mode)
        {
            ushort type = 0;
            int response = ChinaReaderAPI.rf_request(deviceid, (byte)mode, ref type);
            //if (response == 0)
            {
                if (type == (ushort)0x02)
                    return TagType.S70;
                else if (type == (ushort)0x04)
                    return TagType.S50;
                else
                    return TagType.None;
            }

            throw new Exception("'Request' operation failed!");
        }

        public void Authenticate(ushort deviceid, KeyType keyModel, byte blockno, byte[] key)
        {
            if (ChinaReaderAPI.rf_M1_authentication2(deviceid, (byte)keyModel, blockno, key) != 0)
                throw new Exception("Authentication failed!");
        }

        public string Anticollision(ushort deviceid, ref byte len)
        {
            byte[] tagSN = new byte[7];//[1024];TAG SN CAN BE MORE THAN 4 BYTES
            byte count = 0x04;
            int response = ChinaReaderAPI.rf_anticoll(deviceid, count, tagSN, ref len);

            if (response == 0) return BitConverter.ToString(tagSN).Replace("-", string.Empty);
            throw new Exception("'Anticollision' operation failed!");
        }

        public void Connect(int port, int baud)
        {
            if (ChinaReaderAPI.rf_init_com(port, baud) != 0)
                throw new Exception("Connection to device failed!");
            else
                beep(0, 10);
                System.Threading.Thread.Sleep(100);
                beep(0, 10);
        }

        public ushort Select(ushort deviceid, string sn, byte len)
        {
            ushort size = 0;
            byte[] no = HexStringToByteArray(sn);
            int response = ChinaReaderAPI.rf_select(deviceid, no, len, ref size);
            if (response != 0) throw new Exception("'Select' operation failed!");
            return size;
        }

        //System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();

        public void ReadS70BySector(byte deviceID, byte readMode, byte SectorAddress, byte keyMode, byte[] key, ref byte[] data, ref ulong lengthOfData) 
        {
            light(0, 2);
            int res = ChinaReaderAPI.rf_s70_read(deviceID, readMode, SectorAddress, keyMode, key, data, ref lengthOfData);
            light(0, 1);
        }

        public void WriteS70BySector(byte deviceID, byte writeMode, byte sectorAddress, byte keyMode, byte[] key, byte[] data, ulong lengthOfData)
        {
            light(0, 2);
            int res = ChinaReaderAPI.rf_s70_write(deviceID, writeMode, sectorAddress, keyMode, key, data, lengthOfData);
            light(0, 1);    
        }
        
        public byte[] Read(ushort deviceid, byte[] blksToRead, KeyType keyType, byte[] key) 
          {     
              int cnt = 0;
              byte a = 0;
              byte authenLimit;
              int res;
              int totalBytes = blksToRead.Length * 16;
              byte[] buffer = new byte[blksToRead.Length * 16];
              byte[] data = new byte[16];
              byte len = 0;
              int response = 0;
              if (totalBytes == 512) authenLimit = 3;
              else authenLimit = 15;
              //timer.Start();
              light(0, 2);
              res = ChinaReaderAPI.rf_M1_authentication2(deviceid, (byte)keyType, blksToRead[0], key);

              for (int i = 0; i < blksToRead.Length; i++)
              {
                  if (a++ < authenLimit)
                      response = ChinaReaderAPI.rf_M1_read(deviceid, blksToRead[i], data, ref len);
                    
                  else
                  {
                      res = ChinaReaderAPI.rf_M1_authentication2(deviceid, (byte)keyType, blksToRead[i], key);
                      response = ChinaReaderAPI.rf_M1_read(deviceid, blksToRead[i], data, ref len);
                      a = 1;
                  }
                  for (int j = 0; j < 16; j++)
                  {
                      buffer[cnt++] = data[j];
                  }

              }
              
              //timer.Stop();
              //System.Diagnostics.Debug.Write(timer.ElapsedMilliseconds);
              //timer.Reset();
              light(0, 1);
              return buffer;
          }

        
        public byte[] Read(ushort deviceid, byte blockno, KeyType keyType, byte[] key)
        {
            byte[] data = new byte[16];

            if (isReadWritable(blockno))
            {
                byte len = 0;

                // AUTHENTICATE BEFORE ANY READ/WRITE OPERATION
                ChinaReaderAPI.rf_M1_authentication2(deviceid, (byte)keyType, blockno, key);
                int response = ChinaReaderAPI.rf_M1_read(deviceid, blockno, data, ref len);
                if (response == 0)
                    return data;
            }
            throw new Exception("'Read' operation failed for block " + blockno);
        }

        public byte[] Read(ushort deviceid, byte sectorno, byte blockno, KeyType keyType, byte[] key)
        {
            try
            {
                if (sectorno < 128 && sectorno > 0)
                { light(0, 2); return Read(deviceid, (byte)(sectorno * 4 + blockno), keyType, key); }
                else if (sectorno >= 128 && sectorno <= 255)
                { light(0, 1); return Read(deviceid, (byte)(sectorno * 16 + blockno), keyType, key); }
            }
            catch (Exception e) { light(0, 2); throw new Exception(e.Message); }
            return null;
        }

        public void Write(ushort deviceid, byte[] blksToWrite, byte[] data, KeyType keyType, byte[] key)
        {
            int cnt = 0;
            byte a = 0;
            byte authenLimit;
            int res;
            //int totalBytes = blksToRead.Length * 16;
            //byte[] buffer = new byte[blksToRead.Length * 16];
            byte[] tempData = new byte[16];
            int response = 0;

            if (data.Length == 512) authenLimit = 3;
            else authenLimit = 15;
            //timer.Start();
            light(0, 2);//on the green light
            res = ChinaReaderAPI.rf_M1_authentication2(deviceid, (byte)keyType, blksToWrite[0], key); // authenticate the first sector

            for (int i = 0; i < blksToWrite.Length; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    if (cnt < data.Length)
                        tempData[j] = data[cnt++];// copy data from source into sixteen byte temp storage
                    else
                        tempData[j] = 0;
                }

                if (a++ < authenLimit)
                    response = ChinaReaderAPI.rf_M1_write(deviceid, blksToWrite[i], tempData);

                else
                {
                    res = ChinaReaderAPI.rf_M1_authentication2(deviceid, (byte)keyType, blksToWrite[i], key);
                    response = ChinaReaderAPI.rf_M1_write(deviceid, blksToWrite[i], tempData);
                    a = 1;
                }
                light(0, 1);// on the red light
            }

            //timer.Stop();
            //System.Diagnostics.Debug.Write(timer.ElapsedMilliseconds);
            //timer.Reset();
            //return buffer;
        }
        
        
        public void Write(ushort deviceid, byte blockno, byte[] data, KeyType keyType, byte[] key)
        {
            
            if (isReadWritable(blockno))
            {
                // AUTHENTICATE BEFORE ANY READ/WRITE OPERATION
                ChinaReaderAPI.rf_M1_authentication2(deviceid, (byte)keyType, blockno, key);
                light(0, 2);
                if (ChinaReaderAPI.rf_M1_write(deviceid, blockno, data) == 0)
                {light(0, 1);
                    return;}
            }
            throw new Exception("'Write' operation failed for block " + blockno);
            //throw new Exception("Manufacturer's/Trailer block.");
        }

        public void Write2(ushort deviceid, byte blockno, byte[] data, KeyType keyType, byte[] key)
        {
            //if (isReadWritable(blockno))
            {
                // AUTHENTICATE BEFORE ANY READ/WRITE OPERATION
                int res = ChinaReaderAPI.rf_M1_authentication2(deviceid, (byte)keyType, blockno, key);
                light(0, 2);
                if (ChinaReaderAPI.rf_M1_write(deviceid, blockno, data) == 0)
                { light(0, 1); return; }
            }
            throw new Exception("'Write' operation failed for block " + blockno);
            //throw new Exception("Manufacturer's/Trailer block.");
        }

        private bool isReadWritable(byte blockno)
        {           
            // check for manufacturer's block and trailers
            if (blockno == 0)
                return false;
            if (blockno < 128 && blockno >= 0)
            {
                if (blockno == (blockno / 4 * 4 + 3))
                {
                    return false;                    
                }
            }
            else if (blockno >= 128 && blockno <= 255)
            {
               if (blockno == (blockno / 16 * 16 + 15))
                {
                    return false;
                }
                
            }
            return true;
        }

        public void Write(ushort deviceid, byte sectorno, byte blockno, byte[] data, KeyType keyType, byte[] key)
        {
            light(0, 2);
            if (sectorno < 128 && sectorno > 0)
                Write(deviceid, (byte)(sectorno * 4 + blockno), data, keyType, key);
            else if (sectorno >= 128 && sectorno <= 255)
                Write(deviceid, (byte)(sectorno * 16 + blockno), data, keyType, key);
            light(0, 1);
        }
        #endregion

        private byte[] HexStringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length).
                   Where(x => 0 == x % 2).
                   Select(x => Convert.ToByte(hex.Substring(x, 2), 16)).
                   ToArray();
        }

        public bool light(short deviceid, Int32 colour)
        {
            try
            {
                if (ChinaReaderAPI.rf_light(deviceid, colour) == 0)
                    return true;
                else return false;
            }
            catch (Exception ex) { return false; }
        }
        
        public bool beep(short deviceid, Int32 millisecs)
        {
            try
            {
                if (ChinaReaderAPI.rf_beep(deviceid, millisecs) == 0)
                    return true;
                else return false;
            }
            catch (Exception ex) { return false; }
        }
    }
}
