using DataAccessLibrary.DeviceData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public interface IAccessControllerDevicesData
    {
        Task<List<DeviceModel>> GetDevice();
        Task InsertDeviceData(DeviceModel device);
        public Task InsertVisitors(VisitorsModel visitor);
        public Task<List<VisitorsModel>> GetVisitors();
    }
}