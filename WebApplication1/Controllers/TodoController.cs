using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TodoController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TodoController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create() { return View(); }

        public IActionResult Update(int id)
        {
            var todoobj = _db.Todos.FirstOrDefault(b=> b.Id == id );
            return View(todoobj);
        }

        public IActionResult Update(Todo obj)
        {
            _db.Todos.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var todoobj =_db.Todos.FirstOrDefault(b=> b.Id
            == id);
            _db.Todos.Remove(todoobj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
