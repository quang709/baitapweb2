using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using baitapweb2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace baitapweb2.Controllers
{
 
    public class TagController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public TagController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            IEnumerable<Tag> Tag = _appDbContext.Tags;

            return View(Tag);
        }
    }
}
