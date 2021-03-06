﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;

namespace StateMgmt
{
    /// <summary>
    /// Summary description for CalculatorService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CalculatorService : System.Web.Services.WebService
    {
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Add(int a, int b)
        {
            return a + b;
        }
        [WebMethod]
        public DataSet GetEmployeeById(int id)
        {
            SqlConnection con = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=MyDB;Integrated Security=true");
            string query = "select * from Employee where Id =@id";
            SqlDataAdapter adap = new SqlDataAdapter(query, con);
            adap.SelectCommand.Parameters.AddWithValue("@id", id);
            DataSet ds = new DataSet();
            adap.Fill(ds);
            return ds;
        }
    }
}
