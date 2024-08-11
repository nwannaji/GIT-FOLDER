using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using Dapper;

namespace FIRST_WebClient.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _configuration;
        public IndexModel(IConfiguration configuration) {
            _configuration = configuration;
        }
        public void OnGet()
        {
            //Message = "Your application description page.";
        }
        public List<CurrentEvent> GetList()
        {
            var connectionString = this.GetConnection();
            List<CurrentEvent> events = new List<CurrentEvent>();

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "select row_number() over(order by e.timestamp desc) as 'SN', l.serialnumber as 'LaptopId', u.lastname+ ', '+ u.firstname as 'User', case e.status when 1 then 'IN' when 0 then 'OUT' end as Status, right(convert(varchar, e.timestamp, 100), 7) as 'Time' from eventlog e, laptop l, userrecords u where e.laptopid=l.laptopid and u.laptopid=e.laptopid and e.timestamp between DATEADD(dd, DATEDIFF(dd,0,GETDATE()), 0) and DATEADD(dd, DATEDIFF(dd,0,GETDATE()), 1) order by e.timestamp desc";
                    events = con.Query<CurrentEvent>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {  
                    con.Close();
                }

                return events;
            }
        }
        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("FIRST").Value;
            return connection;
        }
    }
    public class CurrentEvent {
        public int SN { get; set; }
        public string LaptopId { get; set; }
        public string User { get; set; }
        public string Status { get; set; }
        public DateTime Time { get; set; }
    }
    public class Event {
        public int SN { get; set; }
        public string SerialNumber { get; set; }
        public string LaptopId { get; set; }
        public string Model { get; set; }
        public string Maker { get; set; }
        public string User { get; set; }
        public string Status { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
