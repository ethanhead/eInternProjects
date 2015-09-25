using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using HttpHandlersDemo;


namespace HttpHandlersDemo
{
    public class MVHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            //throw new NotImplementedException();
            HttpRequest request = context.Request;

            string name = request.Params["name"];

            if (String.IsNullOrEmpty(name))
            {
                name = "Guest";
            }

            HttpResponse response = context.Response;

            response.ContentType = "application/json";

            //Customer c = new Customer()
            //{
            //    CustomerID = 10,
            //    Email = "sreenath@mv.net",
            //    Firstname = "Sreenath",
            //    Lastname = "H B"
            //};

            using (AdventureWorks2012Entities dc = new AdventureWorks2012Entities())
            {
                //var people = 
                var people = dc.People.Select(p => 
                                        new { 
                                          PersonID = p.BusinessEntityID, 
                                          Firstname = p.FirstName, 
                                          Lastname = p.LastName, 
                                          Email = p.EmailAddresses.FirstOrDefault().EmailAddress1 
                                        }).Take(1000) ;
                response.Write(JsonConvert.SerializeObject(people));
            }

        }


    }

    public class Customer
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public int CustomerID { get; set; }
    }
}