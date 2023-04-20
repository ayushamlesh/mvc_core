using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Paharamacyapi.Data;
using Paharamacyapi.Models;

namespace Paharamacyapi.Controllers
{
    //[ApiController]
    [Route("api/Drugs")]
    public class DrugsController : Controller
    {
        private readonly PharamaAPIDbContext dbcontext;
        public DrugsController(PharamaAPIDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }


        [HttpGet]
        public IActionResult Index()
        {
            //3. writing dbset name to reterive data from database
            //var objCatList=_context.Medecines.ToList(); 

            //we can use  strongly type and using Care.Models;
            IEnumerable<Drugs> objCatList = dbcontext.drug;

            //4. we will pass the value into the view and @view reterive using foreach LOOP.
            return Ok(objCatList);
        }


        [HttpPost]
        public IActionResult Create(Drugs obj)
        {
            //check data is already exists.
            var medicine = dbcontext.drug.FirstOrDefault(m => m.Id == obj.Id);
            if (medicine != null)
            {
                ModelState.AddModelError("CatId", "Batch No. Cannot be changed");
                return NotFound();
            }
            //check validation
            else if (ModelState.IsValid)
            {
                dbcontext.drug.Add(obj);
                dbcontext.SaveChanges();
                return Ok(obj);
            }
            return NotFound();
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult Search(string id)
        {
            //RETRIEVE THE CATAGORY USING ID
            if (id == null)
            {
                return NotFound();
            }
            //var category = dbcontext.drug.Find(id);
            //another method
             var category =  dbcontext.drug.FirstOrDefault(u=>u.DrugName==id);

            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        [Route("{id}")]
        public IActionResult DeletePOST(string? id)
        {

            //find category from db
            Drugs? obj = dbcontext.drug.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            //check validation
            dbcontext.drug.Remove(obj);
            dbcontext.SaveChanges();
            return Ok(id);
        }

       /*  [HttpPost]
         [Route("{id:}")]
        public IActionResult Edit(Drugs obj)
          {
                  dbcontext.drug.Update(obj);
                  dbcontext.SaveChanges();
                  return Ok(obj);
          }*/

    }
}
