using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeyerFærdig.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
//Dette er kontrolleren til oprettelse af bruger.
namespace MeyerFærdig.Controllers
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
            //Dette er koden til at oprette profilen. Her bliver vores data fra hjemmesiden sat over i Databasen på SQL.

            //Denne linjer giver adgang til at konfigurere i databasen
            string mainconn = ConfigurationManager.ConnectionStrings["MeyerEntities"].ConnectionString;
            //Her bliver oprettet en ny klasse som tager alt inputtet som brugeren taster ind, og sender det over i den forrige variabel (^^) som sender det ind i databasen
            SqlConnection sqlconn = new SqlConnection(mainconn);
            //I denne string indsættes de respektive inputs i database tabbelens kolonner.
            string sqlquery = "insert into [dbo].[Bruger] (Fornavn, Username, [E-mail], password) values (@Fornavn, @Username, @E_mail, @Password)";
            //Her oprettes en klasse som tager to parametre
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            sqlconn.Open();
            //Her bliver returneret en værdi for SqlParameter fra et objekt. Objeket her er fx. "uc.Fornavn".
            sqlcomm.Parameters.AddWithValue("@Fornavn", uc.Fornavn);
            sqlcomm.Parameters.AddWithValue("@Username", uc.Username);
            sqlcomm.Parameters.AddWithValue("@E_mail", uc.E_mail);
            sqlcomm.Parameters.AddWithValue("@Password", uc.Password);
            //Her bliver data fra objekterne "manipulere"/ændret ind i tabellerne.
            sqlcomm.ExecuteNonQuery();
            sqlconn.Close();
            //Her bliver det hele returneret.
            ViewData["Message"] = " Brugeroplysninger for " + uc.Fornavn + " gemt successfuldt!";
            return View();
        }
    }
}