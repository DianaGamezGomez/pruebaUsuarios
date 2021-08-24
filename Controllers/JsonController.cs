using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DianaGamezWebApp.Models;

namespace DianaGamezWebApp.Controllers
{
    public class JsonController : Controller
    {
        // GET: Json
        public ActionResult Index()
        {
            var users = ObtenUsuarios();
            return View(users);
        }
        public List<User> ObtenUsuarios() 
        {
            List<User> lst;
            using (telguaEntities db = new telguaEntities())
            {
                lst = (from users in db.User
                       select users).ToList();
            }
            return lst;
        }
        public ActionResult Total() {
            var users = ObtenUsuarios();

            return View(users);
        }
        public ActionResult Baja()
        {
            List<User> lst;
            using (telguaEntities db = new telguaEntities())
            {
                lst = (from users in db.User
                       select users).ToList();

            }
            return View(lst);
        }
       
        public JsonResult GetUser(int Uid) 
        {
            using (telguaEntities db = new telguaEntities()) 
            {
                var getUsr = (from a in db.User
                             where a.id == Uid
                             select a).FirstOrDefault();
                return Json(getUsr, JsonRequestBehavior.AllowGet);
            }
        }
        public int UpdateUser(User user) 
        {
            using (telguaEntities db = new telguaEntities())
            {
                var registro = (from a in db.User
                              where a.id == user.id
                              select a).FirstOrDefault();
                if (registro != null)
                {
                    registro.id = user.id;
                    registro.Exp = user.Exp;
                    registro.Active = user.Active;
                    registro.Alias = user.Alias;
                    registro.Name = user.Name;
                    registro.UpdateDate = DateTime.Now;
                }
                return db.SaveChanges();
            }
        }
        public int DeleteUser(int Uid)
        {
            using (telguaEntities db = new telguaEntities())
            {
                var Remov=(from a in db.User
                               where a.id == Uid
                               select a).SingleOrDefault();
                if (Remov != null)
                {
                    db.User.Remove(Remov);
                    return db.SaveChanges();
                }
                else { return 0; }                
            }
        }
        public int InsertUser(FormCollection registro) {
            User objUser = new User();
            objUser.Exp = registro["Exp"];
            objUser.Alias = registro["Alias"];
            objUser.Name = registro["Name"];
            objUser.Active = Convert.ToBoolean(registro["Active"]);
            objUser.RegisterDate = DateTime.Now;
            objUser.UpdateDate = DateTime.Now;
            int res = 0;
            using (telguaEntities db = new telguaEntities())
            {
                db.User.Add(objUser);
               res= db.SaveChanges();
            }
            return res;
        }
    }
}