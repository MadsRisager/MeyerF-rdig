using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Meyer.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace Meyer.Controllers
{
    public class NewRegController : Controller
    {
        // GET: NewReg

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserClass uc)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["MeyerEntities"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "insert into [dbo].[Bruger] (Fornavn, Username, [E-mail], password) values (@Fornavn, @Username, @E_mail, @Password)";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            sqlconn.Open();
            sqlcomm.Parameters.AddWithValue("@Fornavn", uc.Fornavn);
            sqlcomm.Parameters.AddWithValue("@Username", uc.Username);
            sqlcomm.Parameters.AddWithValue("@E_mail", uc.E_mail);
            sqlcomm.Parameters.AddWithValue("@Password", uc.Password);
            sqlcomm.ExecuteNonQuery();
            sqlconn.Close();
            ViewData["Message"] = " Brugeroplysninger for " + uc.Fornavn + " gemt successfuldt!";
            return View();
        }
    }
}