using Care.Data;
using Care.Models;
using Microsoft.AspNetCore.Mvc;

namespace Care.Controllers
{
    public class CategoryController : Controller
    {
        //For reteriving data from database

        //1. CREATE PRIVATE READONLY FIELD
        private readonly ApplicationDbContext _context;


        //2. retrive data using constructor and storing in the object & using Care.Data;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //3. writing dbset name to reterive data from database
            //var objCatList=_context.Medecines.ToList(); 

            //we can use  strongly type and using Care.Models;
            IEnumerable<Category> objCatList = _context.Categories;

            //4. we will pass the value into the view and @view reterive using foreach LOOP.
            return View(objCatList);
        }

        public IActionResult Create()
        {
 
            return View();
        }

        //postmethod
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {


            //check validation
            if (ModelState.IsValid)
            {
                _context.Categories.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if(id== null || id==0)
            {
                return NotFound();
            }
            var category = _context.Categories.Find(id);
            //another method
           // var category = _context.Categories.FirstORDefault(u=>u.Id==id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        //postmethod
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {


            //check validation
            if (ModelState.IsValid)
            {
                _context.Categories.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


       public IActionResult Delete(int? id)
        {
            //RETRIEVE THE CATAGORY USING ID
            if(id== null || id==0)
            {
                return NotFound();
            }
            var category = _context.Categories.Find(id);
            //another method
           // var category = _context.Categories.FirstORDefault(u=>u.Id==id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        //postmethod
        [HttpPost]
        public IActionResult DeletePOST(Category obj)
        {

             var category = _context.Categories.Find(id);
              if (category == null)
            {
                return NotFound();
            }
            //check validation
                _contxt.Categories.Remove(id);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
    }
}

