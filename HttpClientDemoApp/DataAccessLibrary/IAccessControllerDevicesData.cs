using DataAccessLibrary.DeviceData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public interface IAccessControllerDevicesData
    {
        Task<List<DeviceModel>> GetDeviceById(int id);
        Task<List<DeviceModel>> GetDevices();
        Task InsertDeviceData(DeviceModel device);
        Task InsertVisitors(VisitorsModel visitor);
        Task<List<VisitorsModel>> GetVisitors();
    }
}