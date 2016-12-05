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
        public ActionResult AddCategory(string CategoryName)
        {
            if (ModelState.IsValid)
            {
                Category post = new Category();
                post.CategoryName = CategoryName;
                _thing.Save(post);
                return RedirectToAction("Index");
            }
            else
                return View(CategoryName);
        }

        [Authorize]
        public ActionResult Edit(Category model)
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