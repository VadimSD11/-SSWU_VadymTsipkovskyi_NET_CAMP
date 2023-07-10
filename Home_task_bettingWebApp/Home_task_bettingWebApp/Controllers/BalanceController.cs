using Microsoft.AspNetCore.Mvc;
using Home_task_bettingWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Home_task_bettingWebApp.Controllers
{
    public class BalanceController : Controller
    {
        private readonly BettingContext _context;

        public BalanceController(BettingContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var balances = _context.Balances;
            return View(balances);
        }
        public IActionResult Details(int id)
        {
            var balance = _context.Balances.FirstOrDefault(b => b.BalanceId == id);

            if (balance == null)
            {
                return NotFound();
            }

            var transactions = _context.Transactions
                .Where(t => t.UserId == balance.UserId)
                .ToList();

            ViewBag.Transactions = transactions;
            return View(balance);
        }



        public IActionResult Create()
        {
            ViewBag.UserList = new SelectList(_context.Users, "UserId", "UserId");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Balance balance)
        {
            if (ModelState.IsValid)
            {
                _context.Balances.Add(balance);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine(error.ErrorMessage);
            }
            return View(balance);
        }

        public IActionResult Edit(int id)
        {
            var balance = _context.Balances.Find(id);
            if (balance == null)
            {
                return NotFound();
            }

            ViewBag.UserList = new SelectList(_context.Users, "UserId", "UserId", balance.UserId);
            return View(balance);
        }
        [HttpPost]
        public IActionResult Edit(Balance balance)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(balance).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(balance);
        }

        public IActionResult Delete(int id)
        {
            var balance = _context.Balances.Find(id);
            if (balance == null)
            {
                return NotFound();
            }
            return View(balance);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var balance = _context.Balances.Find(id);
            _context.Balances.Remove(balance);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
