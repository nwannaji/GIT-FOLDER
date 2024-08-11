using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary.DeviceData
{
     public class DeviceModel
    {
        public int DeviceId { get; set; }
        public long DeviceSN { get; set; }
        public string DeviceIPAddess { get; set; }
        public string MACAddress { get; set; }
        public int Port { get; set; }
        public string Gateway { get; set; }
        public string PCIPAddress { get; set; }
    }

    public class VisitorsModel
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public long Phone { get; set; }
        public string UniqueCode { get; set; }
        public int HostId { get; set; }
        public string Hostname { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int ClannitId { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Event { get; set; }
        public string ImageUrl { get; set; }
        public int PermanentQuest { get; set; }
        public int Status { get; set; }
        public int CodeStatus { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }
        public string Security { get; set; }
    }
}
