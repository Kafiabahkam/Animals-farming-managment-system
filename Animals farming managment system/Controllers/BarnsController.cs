using Animals_farming_managment_system.Data;
using Animals_farming_managment_system.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Animals_farming_managment_system.Controllers
{
    public class BarnsController : Controller
    {
        private readonly AnimalFarmingDbContext _context;

        public BarnsController (AnimalFarmingDbContext context)
        {
            this._context = context;
        }
        // GET: BarnsController
        public async Task<ActionResult> Index()
        {
            var Barns=await _context.Barns.ToListAsync();
            return View(Barns);
        }

        // GET: BarnsController/Details/5
        public async Task< ActionResult> Details(int id)
        {
            if(id == null )
            {
                return NotFound();
            }
           
           var Barn=await _context.Barns.FindAsync(id);

           if(Barn == null)
           {
             return NotFound();

           }
           else
           {
              return View(Barn);
           }
            
         
            
        }

        // GET: BarnsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BarnsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< ActionResult> Create(Barn barn)
        {
            try
            {
               _context.Barns.Add(barn);
                await _context.SaveChangesAsync();
               return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BarnsController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Barn = await _context.Barns.FindAsync(id);

            if (Barn == null)
            {
                return NotFound();

            }
            else
            {
                return View(Barn);
            }
        }

        // POST: BarnsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< ActionResult> Edit(int id, Barn barn)
        {
            try
            {
                _context.Update(barn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BarnsController/Delete/5
        
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Barn = await _context.Barns.FindAsync(id);

            if (Barn == null)
            {
                return NotFound();

            }
            else
            {
                return View(Barn);
            }


        }

        // POST: BarnsController/Delete/5
        [HttpPost]

        [ValidateAntiForgeryToken]
        public async  Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var Barn = await _context.Barns.FindAsync(id);
               _context.Barns.Remove(Barn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

              
            }
            catch
            {
                return View();
            }
        }
    }
}
