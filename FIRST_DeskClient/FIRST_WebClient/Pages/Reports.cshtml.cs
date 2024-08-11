using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using Dapper;

namespace FIRST_WebClient.Pages 
{
    public class AboutModel : PageModel
    {
        [BindProperty]
        public List<string> LaptopSelection { get; set; }
        [BindProperty]
        public List<string> UserSelection { get; set; }
        [BindProperty]
        public List<string> StatusSelection { get; set; }
        [BindProperty]
        public DateTime StartDate { get; set; }
        [BindProperty]
        public DateTime EndDate { get; set; }
        [BindProperty]
        public string SearchCriteria { get; set; }
        private readonly IConfiguration _configuration;
        public string ErrorMsg { get; set; }

        public AboutModel(IConfiguration configuration) {
            _configuration = configuration;
        }
        //int count;
        public void OnGet() {
            //Message = "Your application description page.";
            ViewData["Title"] = "Reports Page";//count++;//string.Format("{0}/{1}/{2}", LaptopSelection, UserSelection, StatusSelection);
        }
        public void OnPost() {
            //ViewData["Title"] = "posted" + ++count;
            //return Page();
        }

        public List<Laptop> GetLaptops() {
            var connectionString = this.GetConnection();
            List<Laptop> laptops = new List<Laptop>();

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "select row_number() over(order by (select 1)) as 'SN', * from laptop";
                    laptops = con.Query<Laptop>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {  
                    con.Close();
                }
                return laptops;
            }
        }

        public List<User> GetUsers() {
            var connectionString = this.GetConnection();
            List<User> users = new List<User>();

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "select row_number() over(order by (select 1)) as 'SN', * from userrecords";
                    users = con.Query<User>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {  
                    con.Close();
                }
                return users;
            }
        }
        
        public string GetConnection() {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("FIRST").Value;
            return connection;
        }
        
        public List<Event> GetEvents() { 
            var connectionString = this.GetConnection();
            List<Event> events = new List<Event>();

            using (var con = new SqlConnection(connectionString)) {
                try
                {
                    con.Open();
                    var query = "select row_number() over(order by e.timestamp) as 'SN', l.laptopid as LaptopId, l.laptopmodel as Model, l.laptopmaker as Maker, l.serialnumber as " +
                                "'SerialNumber', u.lastname + ', ' + u.firstname as 'User', case e.status when 1 then 'IN' when 0 then 'OUT' end as Status, " +
                                "e.timestamp as Timestamp from eventlog e, laptop l, userrecords u where l.laptopid=u.laptopid and e.laptopid=l.laptopid and ";
                    
                    if (SearchCriteria == "User") {
                        if (UserSelection != null && StatusSelection != null && StartDate != null && EndDate != null) {
                            if (UserSelection.Any() && StatusSelection.Any() && StartDate <= EndDate) 
                            {
                                query += "(";
                                foreach(var sSel in StatusSelection) {
                                    query += string.Format("e.status={0} or ", sSel);
                                }
                                query = query.Remove(query.LastIndexOf(" or"));
                                query += ") and (";
                                foreach(var uSel in UserSelection) {    
                                    query += string.Format("u.userid='{0}' or ", uSel);
                                }
                                query = query.Remove(query.LastIndexOf(" or"));
                                //Debug.WriteLine("query: {0}", query);
                                query += string.Format(") and e.timestamp between '{0}' and DATEADD(day, 1, '{1}') order by timestamp", StartDate.ToString("MM/dd/yyyy"), EndDate.ToString("MM/dd/yyyy"));
                                events = con.Query<Event>(query).ToList();
                            }
                        }
                    }
                    else if (SearchCriteria == "Laptop") {
                        if (LaptopSelection != null && StatusSelection != null && StartDate != null && EndDate != null) {
                            if (LaptopSelection.Any() && StatusSelection.Any() && StartDate <= EndDate) {
                                query += "(";
                                foreach(var sSel in StatusSelection) {
                                    query += string.Format("e.status={0} or ", sSel);
                                }
                                query = query.Remove(query.LastIndexOf(" or"));
                                query += ") and (";
                                foreach(var lSel in LaptopSelection) {
                                    query += string.Format("e.laptopid='{0}' or ", lSel);
                                }
                                query = query.Remove(query.LastIndexOf(" or"));
                                query += string.Format(") and e.timestamp between '{0}' and DATEADD(day, 1, '{1}') order by timestamp", StartDate.ToString("MM/dd/yyyy"), EndDate.ToString("MM/dd/yyyy"));
                                events = con.Query<Event>(query).ToList();
                            }
                        }
                    }
                    else if (SearchCriteria == "Status") {
                        if (UserSelection != null) {
                            if (UserSelection.Any()) {//&& UserSelection==null && StartDate==null && EndDate==null) {
                                query = string.Format("select top(1) case status when 1 then 'IN' when 0 then 'OUT' end as Status, timestamp from eventlog e, userrecords u where userid='{0}' and e.laptopid=u.laptopid order by timestamp desc", UserSelection[0]);
                                events = con.Query<Event>(query).ToList();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;// create an error flag/msg
                }
                finally
                {
                    con.Close();
                }
                return events;
            }
        }
    }

    public class Laptop {
        public int Id { get; set; }
        public string LaptopId { get; set; }
        public string SerialNumber { get; set; }
        public string LaptopModel { get; set; }
        public string LaptopMaker { get; set; }
        public bool isActive { get; set; }
        public string TagId { get; set; }
    }

    public class User {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public List<Laptop> Laptop { get; set; }
    }
}
