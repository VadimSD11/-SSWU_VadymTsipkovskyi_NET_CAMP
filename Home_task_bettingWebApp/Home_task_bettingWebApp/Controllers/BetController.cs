using Microsoft.AspNetCore.Mvc;
using Home_task_bettingWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Home_task_bettingWebApp.Controllers
{
    public class BetController : Controller
    {
        private readonly BettingContext _context;

        public BetController(BettingContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var bets = _context.Bets;
            return View(bets);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Bet bet)
        {
            if (ModelState.IsValid)
            {
                _context.Bets.Add(bet);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bet);
        }

        public IActionResult Edit(int id)
        {
            var bet = _context.Bets.Find(id);
            if (bet == null)
            {
                return NotFound();
            }
            return View(bet);
        }

        [HttpPost]
        public IActionResult Edit(Bet bet)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(bet).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bet);
        }

        public IActionResult Delete(int id)
        {
            var bet = _context.Bets.Find(id);
            if (bet == null)
            {
                return NotFound();
            }
            return View(bet);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var bet = _context.Bets.Find(id);
            _context.Bets.Remove(bet);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
