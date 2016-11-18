using Lab4.Code.DataObjects;
using Lab4.Code.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab4.Controllers
{
    public class HomeController : Controller
    {
        IDataEntityRepository<BlogPost> _stuff;
        public HomeController()
        {
            _stuff = new BlogDBRepository();
        }
        //public HomeController(IDataEntityRepository<BlogPost> thing)
        //{
        //    _stuff = thing;
        //}
        // GET: Home
        public ActionResult Index()
        {
            List<BlogPost> thingy = _stuff.GetList();
            return View(thingy);
        }
    }
}