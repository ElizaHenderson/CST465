using Lab4.Code.DataObjects;
using Lab4.Code.Repositories;
using Lab4.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab4.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private IDataEntityRepository<Category> _thing;
        // GET: Categories
        //public CategoryController()
        //{
        //    _thing = new CategoryDBRepository();
        //}
        public CategoryController(IDataEntityRepository<Category> steve)
        {
            _thing = steve;
        }
        public ActionResult Index()
        {
            return View(_thing.GetList());
        }

        public ActionResult Add()
        {
            CategoryModel _obj = new CategoryModel();
            return View(_obj);
        }

        [HttpPost]
        public ActionResult AddCategory(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                Category post = new Category();
                post.CategoryName = model.CategoryName;
                _thing.Save(post);
                return RedirectToAction("Index");
            }
            else
                return View(model);
        }
        
        public ActionResult Edit(int id)
        {
            Category post = new Category();
            CategoryModel model = new CategoryModel();
            post = _thing.Get(id);
            model.CategoryName = post.CategoryName;
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                Category post = new Category();
                post.CategoryName = model.CategoryName;
                _thing.Save(post);
                return RedirectToAction("Index");
            }
            else
                return View(model);
        }

    }

}