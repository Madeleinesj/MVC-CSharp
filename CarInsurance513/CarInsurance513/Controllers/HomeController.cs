using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarInsurance513.Models;
using CarInsurance513;

namespace CarInsurance513.Controllers
{
    public class HomeController : Controller
    {
        private readonly string connectionString = @"metadata=res://*/Models.InsuranceEntities.csdl|res://*/Models.InsuranceEntities.ssdl|res://*/Models.InsuranceEntities.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\Insurance.mdf;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;";
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        
        public ActionResult QuoteList(string firstName, string lastName, string emailAddress, decimal quote, int carYear, string carMake, string carModel, bool coverageType, bool DUI)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(emailAddress))
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                using (InsuranceEntities db = new InsuranceEntities())
                {
                    Insuree quoteN = new Insuree();
                    quoteN.FirstName = firstName;
                    quoteN.LastName = lastName;
                    quoteN.EmailAddress = emailAddress;
                    quoteN.CarMake = carMake;
                    quoteN.CarModel = carModel;
                    quoteN.CarYear = carYear;
                    quoteN.CoverageType = coverageType;
                    quoteN.Quote = quote;

                    db.Insurees.Add(quoteN);
                    db.SaveChanges();
                }
                return View("Success");
            }
        }
        public ActionResult Admin()
        {
            
            string queryString = @"SELECT Quote, FirstName, LastName, EmailAddress from Insurees";
            List<Insuree> quotes = new List<Insuree>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Insuree quoteList = new Insuree();
                    quoteList.Id = Convert.ToInt32(reader["Id"]);
                    quoteList.FirstName = reader["FirstName"].ToString();
                    quoteList.LastName = reader["LastName"].ToString();
                    quoteList.EmailAddress = reader["EmailAddress"].ToString();
                    quotes.Add(quoteList);
                }
                return View();
            }
        }
    }
}