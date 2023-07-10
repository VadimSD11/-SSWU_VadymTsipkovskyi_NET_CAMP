using Microsoft.AspNetCore.Mvc;
using Home_task_bettingWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Home_task_bettingWebApp.Controllers
{
    public class ResultController : Controller
    {
        private readonly BettingContext _context;

        public ResultController(BettingContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var results = _context.Results;
            return View(results);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Result result)
        {
            if (ModelState.IsValid)
            {
                _context.Results.Add(result);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(result);
        }

        public IActionResult Edit(int id)
        {
            var result = _context.Results.Find(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(Result result)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(result).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(result);
        }

        public IActionResult Delete(int id)
        {
            var result = _context.Results.Find(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var result = _context.Results.Find(id);
            _context.Results.Remove(result);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
