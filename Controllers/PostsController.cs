using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using baitapweb2.Models;
using baitapweb2.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace baitapweb2.Controllers
{
    public class PostsController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        // GET: PostsController

        public PostsController(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public ActionResult Index()
        {
            ViewBag.Message = "ablabla";
         
            var Posts = _appDbContext.Posts.Include(p => p.Category).ToList();
            return View(Posts);
        }

        // GET: PostsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PostsController/Create
        public IActionResult Create()
        {
            PostsCreateVM PostsVM = new PostsCreateVM()
            {
                Posts = new Posts(),
                CategorySelectList = _appDbContext.Categories.Select(item => new SelectListItem
                {
                    Text = item.Title,
                    Value = item.Id.ToString()
                }),
                TagSelectList = _appDbContext.Tags.Select(item => new SelectListItem
                {
                    Text = item.Title,
                    Value = item.Id.ToString()
                })
            };
            return View(PostsVM);
        }


        [HttpPost]
        public IActionResult Create(PostsCreateVM postsCreateVM)
        {
           
            foreach (var item in postsCreateVM.SelectListTagIds)
            {
                postsCreateVM.Posts.PostsTags.Add(new PostsTag()
                {
                    TagId = item
                });
            }

            _appDbContext.Posts.Add(postsCreateVM.Posts);
            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        // POST: PostsController/Create
     /*   [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/

        // GET: PostsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PostsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PostsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PostsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
