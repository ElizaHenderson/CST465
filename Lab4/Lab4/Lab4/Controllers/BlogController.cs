using Lab4.Code.DataObjects;
using Lab4.Code.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab4.Controllers
{
    public class BlogController : Controller
    {
        private IDataEntityRepository<BlogPost> _thing;
        // GET: Blog
        public ActionResult Index()
        {
            return View(_thing.GetList());
        }

        public ActionResult Add()
        {
            BlogPostModel _obj = new BlogPostModel();
            return View(_obj);
        }

        [HttpPost]
        public ActionResult Add(BlogPostModel model)
        {
            if(ModelState.IsValid)
            {
                BlogPost post = new BlogPost();
                post.Author = model.Author;
                post.Content = model.Content;
                post.ID = model.ID;
                post.Title = model.Title;
                _thing.Save(post);
                return RedirectToAction("Index");
            }
            else
                return View(model);

        }
        public ActionResult Edit(int id)
        {
            BlogPost post = new BlogPost();
            BlogPostModel model = new BlogPostModel();
            post = _thing.Get(id);
            model.Author = post.Author;
            model.Content = post.Content;
            model.ID = post.ID;
            model.Title = post.Title;
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(BlogPostModel model)
        {
            if (ModelState.IsValid)
            {
                BlogPost post = new BlogPost();
                post.Author = model.Author;
                post.Content = model.Content;
                post.ID = model.ID;
                post.Title = model.Title;
                _thing.Save(post);
                return RedirectToAction("Index");
            }
            else
                return View(model);
            

        }

        public ActionResult ViewSingleBlog(BlogPostModel model)
        {
            var blogPost = new BlogPost();
            blogPost = _thing.Get(model.ID);
             

        }
        public BlogController ()
        {
            _thing = new BlogDBRepository();
        }
        
    }
    
}