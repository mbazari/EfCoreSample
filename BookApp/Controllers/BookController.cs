using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApp.Data;
using BookApp.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BookApp.Controllers
{
    public class BookController : Controller
    {
        private AppDbContext _dbContext;

        public BookController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var data =_dbContext.Books.as .;
            return View();
        }
    }
}