using Lab4.Code.DataObjects;
using Lab4.Code.Repositories;
using Lab4.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
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
        public ActionResult Add(InventoryModel item)
        {
            if (ModelState.IsValid)
            {
                byte[] img;
                Inventory tempo = new Inventory();
                tempo.ID = item.ID;
                tempo.CategoryID = item.CategoryID;
                tempo.Price = item.Price;
                tempo.ProductCode = item.ProductCode;
                tempo.ProductName = item.ProductName;
                tempo.ProductDescription = item.ProductDescription;
                tempo.Quantity = item.Quantity;
                if (item.ProductImage != null)
                {
                    using (MemoryStream mem = new MemoryStream())
                    {
                        item.ProductImage.InputStream.CopyTo(mem);
                        img = mem.ToArray();
                    }
                    tempo.ProductImage = img;
                    tempo.FileName = item.ProductImage.FileName;
                    tempo.ImageType = item.ProductImage.ContentType;
                }
                else
                {
                    tempo.ProductImage = null;
                }
                _thing.Save(tempo);
                return View();
            }
            else
                return View();
        }
        [HttpPost]
        public ActionResult Save(InventoryModel item)
        {
            if (ModelState.IsValid)
            {
                byte[] img;
                Inventory tempo = new Inventory();
                tempo.ID = item.ID;
                tempo.CategoryID = item.CategoryID;
                tempo.Price = item.Price;
                tempo.ProductCode = item.ProductCode;
                tempo.ProductName = item.ProductName;
                tempo.ProductDescription = item.ProductDescription;
                tempo.Quantity = item.Quantity;
                if (item.ProductImage != null)
                {
                    using (MemoryStream mem = new MemoryStream())
                    {
                        item.ProductImage.InputStream.CopyTo(mem);
                        img = mem.ToArray();
                    }
                    tempo.ProductImage = img;
                    tempo.FileName = item.ProductImage.FileName;
                    tempo.ImageType = item.ProductImage.ContentType;
                }
                else
                {
                    tempo.ProductImage = null;
                }
                _thing.Save(tempo);
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
        public ActionResult Edit(int Id)
        { 
               return View(_thing.Get(Id));
        }
        
        [Authorize]
        public ActionResult Delete(int Id)
        {
            //_thing.Delete(Id); dunno why this doesn't work.
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM [Product] WHERE ID=@ID";
                    command.Parameters.AddWithValue("@ID", Id);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            return View("Index", _thing.GetList());
        }
        
        [HttpPost]
        [Authorize]

        public ActionResult Edit(InventoryModel item)
        {
            if (ModelState.IsValid)
            {
                byte[] img;
                Inventory tempo = new Inventory();
                tempo.ID = item.ID;
                tempo.CategoryID = item.CategoryID;
                tempo.Price = item.Price;
                tempo.ProductCode = item.ProductCode;
                tempo.ProductName = item.ProductName;
                tempo.ProductDescription = item.ProductDescription;
                tempo.Quantity = item.Quantity;
                if (item.ProductImage != null)
                {
                    using (MemoryStream mem = new MemoryStream())
                    {
                        item.ProductImage.InputStream.CopyTo(mem);
                        img = mem.ToArray();
                    }
                    tempo.ProductImage = img;
                    tempo.FileName = item.ProductImage.FileName;
                    tempo.ImageType = item.ProductImage.ContentType;
                }
                else
                {
                    tempo.ProductImage = null;
                }
                _thing.Save(tempo);
                return View("Index", _thing.GetList());
            }
            else
                return View();
        }
    }
}