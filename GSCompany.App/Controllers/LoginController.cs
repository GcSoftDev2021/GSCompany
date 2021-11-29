using GSCompany.Data.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GSCompany.App.Controllers
{
    public class LoginController : Controller
    {
        
        private readonly DataLogin dataLogin = new DataLogin();                      

        public JsonResult IniciarSesion(string Usuario, string Password)
        {
            string resultado = dataLogin.IniciarSesion(Usuario, Password);
            return Json(resultado);
        }
    }
}