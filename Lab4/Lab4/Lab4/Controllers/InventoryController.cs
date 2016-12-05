using Lab4.Code.DataObjects;
using Lab4.Code.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab4.Controllers
{
    [Authorize]
    public class InventoryController : Controller
    {
        // GET: Inventory
        private IDataEntityRepository<Inventory> _thing;
        public InventoryController(IDataEntityRepository<Inventory> steve)
        {
            _thing = steve;
        }
        public ActionResult Index()
        {
            return View(_thing.GetList());
        }
        [Authorize]
        public ActionResult Add()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Inventory item)
        {
            if(ModelState.IsValid)
            {
                _thing.Save(item);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Save(Inventory item)
        {
            if (ModelState.IsValid)
            {
                _thing.Save(item);
                return View();
            }
            else
                return View();
        }
        [HttpPost]
        public ActionResult AddInventory(string InventoryName)
        {
            if (ModelState.IsValid)
            {
                Inventory post = new Inventory();
                post.ProductName = InventoryName;
                _thing.Save(post);
                return RedirectToAction("Index");
            }
            else
                return View(InventoryName);
        }

        [Authorize]
        public ActionResult Edit(Inventory model)
        {
            if (ModelState.IsValid)
            {
                _thing.Save(model);
                return RedirectToAction("Index");
            }
            else
                return View(model);
        }
    }
}