using System;
using myMvc.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data; 
using System.Data.SqlClient;

namespace myMvc.Controllers
{
    public class gymController : Controller
    {

        static List<gym> listuser = new List<gym> {

            // cricketer c = new cricketer();

            new gym() { email = "virat@123", password = "india"}
            //new cricketer() { username = "ashwin", country = "india" },
            //new cricketer() { username = "shami", country = "india" },
            //new cricketer() { username = "sakibul", country = "bangladesh" }
        };

    public ActionResult homePage()
        {
            return View(listuser);
        }

        public ActionResult sighup(gym ckr)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (useradd(ckr))
                    {
                        TempData["Message"] = "SignUp successfully";
                    }
                    else
                    {
                        TempData["Message"] = "please enter the details";
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        public bool useradd(gym ck)
        {
            try
            {
                string connectionString = "Data Source=sql-dev.mapline.net,55355;Initial Catalog=Training;Integrated Security=True";
                string sql = "signups";
                SqlConnection conString = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sql, conString);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usernames", ck.username);
                cmd.Parameters.AddWithValue("@email", ck.email);
                cmd.Parameters.AddWithValue("@mobileno", ck.number);
                cmd.Parameters.AddWithValue("@psw", ck.password);
                conString.Open();
                int p = cmd.ExecuteNonQuery();
                conString.Close();
                if (p >= 1) return true;
                else return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void login(gym ck)
        {
            try
            {
                string connectionString = "Data Source=sql-dev.mapline.net,55355;Initial Catalog=Training;Integrated Security=True";
                //string sql = "signups";
                string uid = ck.username;
                string pass = ck.password;
                string qry = "select * from signupss where usernames='" + uid + "' and psw='" + pass + "'";
                SqlConnection conString = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(qry, conString);
                SqlDataReader sdr = cmd.ExecuteReader();

                cmd.CommandType = CommandType.StoredProcedure;
                
                conString.Open();
                if (sdr.Read())
                {
                    TempData["Message"] = "login successfully";
                }
                else
                {
                    TempData["Message"] = "UserId & Password Is not correct Try again..!!";
                }
                conString.Close();
            }
            catch (Exception ex)
            {
                TempData["Message"] = "UserId & Password Is not correct Try again..!!";
                //Response.Write(ex.Message);
            }
        }
            


    




















    ///////////////////////////////////////////////////////////////////////////////////////////////////////////

    //  cricketer std;
    //public ActionResult update(string Name)
    //{
    //    std = listuser.Where(s => s.username ==Name).FirstOrDefault();

    //    return View(std);
    //}

    //public ActionResult update2(cricketer uc)
    //{


    //   // var student = listuser.Where(s => s.username == uc.username).FirstOrDefault();
    //    // var std =  listuser.Where(p.username=Name);
    //    listuser.Remove(std);
    //     listuser.Add(uc);
    //    return View(uc);
    //  //  return RedirectToAction("Index1");
    //}


    //public ActionResult remove(cricketer uc)
    //{
    //    listuser.Remove(listuser.Last()); 
    //    return View(uc);
    //}


    // GET: cricketer
    //public ActionResult Index()
    //{
    //    return View();
    //}
    //public ActionResult get()
    //{
    //    return View();
    //}


    //public ActionResult GetEmployeeData()
    //{
    //    SqlConnection conString = new SqlConnection("Data Source=sql-dev.mapline.net,55355;Initial Catalog=Training;Integrated Security=True");
    //    using (conString)
    //    {
    //        SqlCommand command = new SqlCommand("SELECT * FROM  sakibNew; ", conString );
    //           conString.Open();
    //        SqlDataReader reader = command.ExecuteReader();        
    //            while (reader.Read())
    //            {
    //            cricketer c = new cricketer();
    //            c.username = (string)reader["myName"];
    //            c.country = (string)reader["country"];
    //            listuser.Add(c);
    //            }  
    //        reader.Close();
    //    }
    //    return View();
    //}






}


}
    
