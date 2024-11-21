using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Data;
using Restaurant.Data.Model;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoriesController(ApplicationDbContext db)
        {
            _db = db;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(_db.Categories.ToList());
        }

        //GET Create

        public ActionResult Create()
        {
            return View();
        }

        //POST Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category categorys)
        {
            if (ModelState.IsValid)
            {
                
                _db.Categories.Add(categorys);
                await _db.SaveChangesAsync();
                TempData["save"] = "Категорията беше запазена успешно.";
                return RedirectToAction(nameof(Index));
            }

            return View(categorys);
        }

        //GET Edit 
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        //POST Edit 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category categorys)
        {
            if (ModelState.IsValid)
            {
                _db.Update(categorys);
                await _db.SaveChangesAsync();
                TempData["edit"] = "Product type has been updated";
                return RedirectToAction(nameof(Index));
            }

            return View(categorys);
        }


        //GET Details

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        //POST Edit 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(Category category)
        {
            return RedirectToAction(nameof(Index));

        }

        //GET Delete

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        //POST Delete

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, Category categorys)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (id != categorys.Id)
            {
                return NotFound();
            }

            var category = _db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Remove(category);
                await _db.SaveChangesAsync();
                TempData["delete"] = "Категорията беше успешно изтрита.";
                return RedirectToAction(nameof(Index));
            }

            return View(categorys);
        }
        
    }
}

