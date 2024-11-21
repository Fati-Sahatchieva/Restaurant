using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.Data.Model;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _he;

        public ProductsController(ApplicationDbContext db, IWebHostEnvironment he)
        {
            _db = db;
            _he = he;
        }
        public IActionResult Index()
        {
            return View(_db.Products.Include(c => c.Category).ToList());
        }

        //POST Index 
        [HttpPost]
        public IActionResult Index(decimal? lowAmount, decimal? largeAmount)
        {
            var products = _db.Products.Include(c => c.Category)
                .Where(c => c.Price >= lowAmount && c.Price <= largeAmount).ToList();
            if (lowAmount == null || largeAmount == null)
            {
                products = _db.Products.Include(c => c.Category).ToList();
            }
            return View(products);
        }

        //Get Create method
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_db.Categories.ToList(), "Id", "Name");
            return View();
        }


        //Post Create method
        [HttpPost]
        public async Task<IActionResult> Create(Product product, IFormFile image)
        {
            if(ModelState.IsValid)
            {
                var searchProduct = _db.Products.FirstOrDefault(c => c.Name == product.Name);
                if (searchProduct != null)
                {
                    ViewBag.message = "Този продукт вече съществува";
                    ViewData["CategoryId"] = new SelectList(_db.Categories.ToList(), "Id", "Name");
                   
                    return View(product);
                }
                if (image != null)
                {
                    string filename = image.FileName;
                    string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Image"));
                    using (var filestream = new FileStream(Path.Combine(path, filename), FileMode.Create))
                    { await image.CopyToAsync(filestream); }

                    product.Image = filename;
                }
                _db.Products.Add(product);
                await _db.SaveChangesAsync();
                TempData["save"] = "Продукта беше запазен успешно.";
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        //GET Edit Method

        public ActionResult Edit(int? id)
        {
            ViewData["CategoryId"] = new SelectList(_db.Categories.ToList(), "Id", "Name");

            if (id == null)
            {
                return NotFound();
            }

            var product = _db.Products.Include(c => c.Category)
                .FirstOrDefault(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        //POST Edit Method
        [HttpPost]
        public async Task<IActionResult> Edit(Product products, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    string filename = image.FileName;
                    string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Image"));
                    using (var filestream = new FileStream(Path.Combine(path, filename), FileMode.Create))
                    { await image.CopyToAsync(filestream); }

                    products.Image = filename;
                }
                _db.Products.Update(products);
                await _db.SaveChangesAsync();
                TempData["edit"] = "Продукта беше редактиран успешно.";
                return RedirectToAction(nameof(Index));
            }

            return View(products);
        }

        //GET Details Method
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var product = _db.Products.Include(c => c.Category)
                .FirstOrDefault(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        //GET Delete Method

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _db.Products.Include(c => c.Category).Where(c => c.Id == id).FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        //POST Delete Method

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _db.Products.FirstOrDefault(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
            TempData["delete"] = "Продукта беше изтрит успешно.";
            return RedirectToAction(nameof(Index));
        }
       
    }
}
