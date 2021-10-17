using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myMvc.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult WorkOut()
        {
            return View();
        }
        public ActionResult HealthyRecipes()
        {
            return View();
        }

        public ActionResult login(Models.gym ck)
        {
            ViewBag.Message = "your contact page.";

            try
            {
                string connectionString = "Data Source=sql-dev.mapline.net,55355;Initial Catalog=Training;Integrated Security=True";
                //string sql = "signups";
                string uid = ck.username;
                string pass = ck.password;
                System.Data.SqlClient.SqlConnection conString = new SqlConnection(connectionString);
                conString.Open();
                string qry = "select * from signupss where usernames='" + uid + "' and psw='" + pass + "'";
                SqlCommand cmd = new SqlCommand(qry, conString);
                SqlDataReader sdr = cmd.ExecuteReader();

                // cmd.CommandType = CommandType.StoredProcedure;


                if (sdr.Read())
                {
                    TempData["Message"] = "login successfully";
                    return View("Workout");
                }
                else
                {
                    TempData["Message"] = "enter username and password";
                }
                conString.Close();
            }
            catch (Exception ex)
            {
                TempData["Message"] = "exception";
                //Response.Write(ex.Message);
            }

            return View();
        }


    }
}