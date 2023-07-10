using Microsoft.AspNetCore.Mvc;
using Home_task_bettingWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Home_task_bettingWebApp.Controllers
{
    public class EventController : Controller
    {
        private readonly BettingContext _context;

        public EventController(BettingContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var events = _context.Events;
            return View(events);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Event @event)
        {
            if (ModelState.IsValid)
            {
                _context.Events.Add(@event);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(@event);
        }

        public IActionResult Edit(int id)
        {
            var @event = _context.Events.Find(id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        [HttpPost]
        public IActionResult Edit(Event @event)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(@event).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(@event);
        }

        public IActionResult Delete(int id)
        {
            var @event = _context.Events.Find(id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var @event = _context.Events.Find(id);
            _context.Events.Remove(@event);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
