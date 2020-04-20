using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.Web.Helpers;

namespace COVID19Ninjas.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}