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
    public class CategoriesController : Controller
    {
        private IDataEntityRepository<Categories> _thing;
        // GET: Categories
        public ActionResult Index()
        {
            return View(_thing.GetList());
        }

        public ActionResult Add()
        {
            CategoriesModel _obj = new CategoriesModel();
            return View(_obj);
        }

        [HttpPost]
        public ActionResult Add(CategoriesModel model)
        {
            if (ModelState.IsValid)
            {
                Categories post = new Categories();
                post.CategoryName = model.CategoryName;
                _thing.Save(post);
                return RedirectToAction("Index");
            }
            else
                return View(model);

        }
        public ActionResult Edit(int id)
        {
            Categories post = new Categories();
            CategoriesModel model = new CategoriesModel();
            post = _thing.Get(id);
            model.CategoryName = post.CategoryName;
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(CategoriesModel model)
        {
            if (ModelState.IsValid)
            {
                Categories post = new Categories();
                post.CategoryName = model.CategoryName;
                _thing.Save(post);
                return RedirectToAction("Index");
            }
            else
                return View(model);


        }

        public ActionResult ViewSingleBlog(CategoriesModel model)
        {
            var blogPost = new Categories();
            blogPost = _thing.Get(model.ID);
            return View(blogPost);

        }
        public CategoriesController()
        {
            //_thing = new CategoriesDBRepository();
        }

    }

}