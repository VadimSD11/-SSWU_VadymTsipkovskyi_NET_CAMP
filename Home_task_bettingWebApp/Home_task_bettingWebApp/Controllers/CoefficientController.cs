using Microsoft.AspNetCore.Mvc;
using Home_task_bettingWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Home_task_bettingWebApp.Controllers
{
    public class CoefficientController : Controller
    {
        private readonly BettingContext _context;

        public CoefficientController(BettingContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var coefficients = _context.Coefficients;
            return View(coefficients);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Coefficient coefficient)
        {
            if (ModelState.IsValid)
            {
                _context.Coefficients.Add(coefficient);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coefficient);
        }

        public IActionResult Edit(int id)
        {
            var coefficient = _context.Coefficients.Find(id);
            if (coefficient == null)
            {
                return NotFound();
            }
            return View(coefficient);
        }

        [HttpPost]
        public IActionResult Edit(Coefficient coefficient)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(coefficient).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coefficient);
        }

        public IActionResult Delete(int id)
        {
            var coefficient = _context.Coefficients.Find(id);
            if (coefficient == null)
            {
                return NotFound();
            }
            return View(coefficient);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var coefficient = _context.Coefficients.Find(id);
            _context.Coefficients.Remove(coefficient);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
