using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult register()
        {

            return View();
        }

        public ActionResult login()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult editProfile(FormCollection fc)
        {

            int id = int.Parse(fc["id"]);

            String firstname = fc["firstname"];
            String lastname = fc["lastname"];
            String email = fc["email"];
            String password = fc["password"];

            friendsEntities1 fe = new friendsEntities1();

            user u = (from a in fe.users
                      where a.id == id
                      select a).FirstOrDefault();

            u.firstname = firstname;
            u.lastname = lastname;
            u.email = email;
            u.password = password;

            Session["first_name"] = u.firstname;
            Session["last_name"] = u.lastname;

            fe.SaveChanges();

            return RedirectToAction("staff");
        }

        public ActionResult goToEdit()
        {

            int id = (int)Session["user_id"];

            friendsEntities1 fe = new friendsEntities1();

            user u = (from a in fe.users
                      where a.id == id
                      select a).FirstOrDefault();

            ViewData["user"] = u;

            return View();
        }



        public ActionResult staff()
        {

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            return View();
        }

        public ActionResult admin()
        {   

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            return View();
        }

        public ActionResult logout()
        {
            Session.Clear();

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            return RedirectToAction("login");
        }

        public ActionResult insertData(FormCollection fc)
        {

            String firstname = fc["firstname"];
            String lastname = fc["lastname"];
            String email = fc["email"];
            String password = fc["pass"];
            int role;

            if (email == "admin@gmail.com" && password == "p@ssw0rd") {
                role = 2;             
            }
            else
            {
                role = 1;
            }

            user u = new user();

            u.firstname = firstname;
            u.lastname = lastname;
            u.email = email;
            u.password = password;
            u.role_id = role;

            friendsEntities1 fe = new friendsEntities1();

            fe.users.Add(u);
            fe.SaveChanges();

            return RedirectToAction("login");
        }


        public ActionResult authenticate(FormCollection fc)
        {

            string email = fc["email"];
            string password = fc["password"];

            friendsEntities1 authenticateduser = new friendsEntities1();

            user authenticatedUser = authenticateduser.users.FirstOrDefault(u => u.password == password && u.email == email);

            if (authenticatedUser != null)
            {
                if (authenticatedUser.role_id == 1)
                {
                    Session["first_name"] = authenticatedUser.firstname;
                    Session["last_name"] = authenticatedUser.lastname;
                    Session["user_id"] = authenticatedUser.id;

                    return RedirectToAction("staff");
                }
                else if (authenticatedUser.role_id == 2)
                {
                    Session["first_name"] = authenticatedUser.firstname;
                    Session["last_name"] = authenticatedUser.lastname;
                    Session["userid"] = authenticatedUser.id;

                    return RedirectToAction("admin");
                }

            }
            else
            {
                ViewData["ErrorMessage"] = "Invalid credentials. Please try again.";
            }

        
            return View("login");
        }

    }
}