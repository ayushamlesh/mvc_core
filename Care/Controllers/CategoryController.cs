using Care.Data;
using Care.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.FileSystem;
using Paharamacyapi.Models;
using Paharamacyapi.Data;

namespace Care.Controllers
{
    public class CategoryController : Controller
    {
        //For reteriving data from database

        //1. CREATE PRIVATE READONLY FIELD
       // private readonly ApplicationDbContext _context;
        private readonly PharamaAPIDbContext _context;


        //2. retrive data using constructor and storing in the object & using Care.Data;

        /*public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }*/
        public CategoryController(PharamaAPIDbContext context)
       {
           _context = context;
       }
        public IActionResult Index()
        {
            //3. writing dbset name to reterive data from database
            //var objCatList=_context.Medecines.ToList(); 

            //we can use  strongly type and using Care.Models;
            //IEnumerable<Category> objCatList = _context.Categories;
            IEnumerable<Drugs> objCatList = _context.drug;

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
        //public IActionResult Create(Category obj)
        public IActionResult Create(Drugs obj)
        {
            //check data is already exists.
            //var medicine = _context.Categories.FirstOrDefault(m => m.CatId == obj.CatId);
            var medicine = _context.drug.FirstOrDefault(m => m.Id == obj.Id);

            if (medicine!=null)
            {
                ModelState.AddModelError("CatId","Batch No. Cannot be changed");
                return View();
            }
            //check validation
            else if(ModelState.IsValid)
            {
                // _context.Categories.Add(obj);
                _context.drug.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

 
        public IActionResult Edit(string? id)
        {
            if(id== null)
            {
                return NotFound();
            }
            var category = _context.drug.Find(id);

            //var category = _context.Categories.Find(id);
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
        public IActionResult Edit(Drugs obj)
        {


            //check validation
            if (ModelState.IsValid)
            {
                _context.drug.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


       public IActionResult Delete(string? id)
        {
            //RETRIEVE THE CATAGORY USING ID
            if(id == null)
            {
                return NotFound();
            }
            var category = _context.drug.Find(id);
            //another method
           // var category = _context.Categories.FirstORDefault(u=>u.Id==id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        //postmethod
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePOST(string? id)
        {

            //find category from db
             Drugs? obj = _context.drug.Find(id);
              if (obj == null)
            {
                return NotFound();
            }
            //check validation
                _context.drug.Remove(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }



        public IActionResult Order()
        {
            IEnumerable<Drugs> objCatList = _context.drug;

            return View(objCatList);
        }
        [HttpPost]
        /*public IActionResult Order(Order model)
        {
           if (ModelState.IsValid)
            {
                // Fetch the medicine from the database by medicine ID
                var medicine = _context.drug.FirstOrDefault(m => m.DrugName == model.CatName)?.DrugName;

                if (medicine == null)
                {
                    ModelState.AddModelError("MedicineId", "Medicine not found in the database.");
                    return View();
                }

                // Update the order quantity
                int? price = (int)(_context.drug.FirstOrDefault(x => x.DrugName == model.CatName)?.Price);
                if (price != null)
                {
                    var order = new Order
                    {
                        CatName = model.CatName,
                        Quantity = model.Quantity,
                        Total = (int)(price * model.Quantity)
                    };
                    _context.Orders.Add(order);
                    _context.SaveChanges();
                    return View("Index");
                }

                // Redirect to a success page
                //return RedirectToAction("OrderAdded", "Orders");
                return View();
            }

            // If ModelState is invalid, return to the form with error messages
            return View(model);
        }*/


        //searching
        [HttpPost]
        public IActionResult Search(string? id)
        {
            //RETRIEVE THE CATAGORY USING ID
            if (id == null)
            {
                return NotFound();
            }
            //var category = _context.Categories.Find(id);
            //another method
             var category = _context.drug.FirstOrDefault(u => u.DrugName == id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

    }
}

