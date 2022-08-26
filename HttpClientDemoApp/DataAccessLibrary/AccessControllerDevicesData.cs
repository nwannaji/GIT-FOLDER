using DataAccessLibrary.DeviceData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class AccessControllerDevicesData : IAccessControllerDevicesData
    {
        string sql = "SELECT * FROM tblDeviceInfo";
        private readonly IDatabaseAccess _db;

        public AccessControllerDevicesData(IDatabaseAccess db)
        {
            this._db = db;
        }
        public Task<List<DeviceModel>> GetDevice()
        {
            return _db.LoadData<DeviceModel, dynamic>(sql, new { });
        }
        public Task<List<VisitorsModel>> GetVisitors()
        {
            return _db.LoadData<VisitorsModel, dynamic>(sql, new { });
        }

        public Task InsertDeviceData(DeviceModel device)
        {
            string sql = @"insert into tblDeviceInfo (DeviceSN, DeviceIPAddress, MACAddress,Port,Gateway)
                          VALUES(@DeviceSN, @DeviceIPAddress, @MACAddress,@Port,@Gateway);";

            return _db.SaveData(sql, device);
        }
        public Task InsertVisitors(VisitorsModel visitor)
        {
            string query = @"insert into tblVisitors(Id,VisitorFirstname,VisitorLastname, VisitorPhone,UniqueCode,HostId,Hostname,
                                 CheckInDate,CheckOutDate,ClannitId,ExpiryDate,DateCreated,DateFrom,DateTo,Event,
                                 QuestImage,PermanentQuest,Status, StatusCode,TimeFrom,TimeTo,Security)

                          values(@Id,@VisitorFirstname,@VisitorLastname, @VisitorPhone,@UniqueCode,@HostId,@Hostname,
                                  @CheckInDate,@CheckOutDate,@ClannitId,@ExpiryDate,@DateCreated,@DateFrom,@DateTo,@Event,
                                   @QuestImage,@PermanentQuest,@Status, @StatusCode,@TimeFrom,@TimeTo,@Security));";
            return _db.SaveData(query, visitor);
        }
    }
}
