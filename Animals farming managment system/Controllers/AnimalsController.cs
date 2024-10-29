using Animals_farming_managment_system.Data;
using Animals_farming_managment_system.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace Animals_farming_managment_system.Controllers
{
    
    public class AnimalsController : Controller
    {
        private readonly AnimalFarmingDbContext _context;

        public AnimalsController(AnimalFarmingDbContext context)
        {
            this._context = context;
        }

        // GET: AnimalsController
        public async Task<ActionResult> Index()
        {
            var Barns = await _context.Animals.ToListAsync();
            return View(Barns);
        }

        // GET: AnimalsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Barn = await _context.Animals.FindAsync(id);

            if (Barn == null)
            {
                return NotFound();

            }
            else
            {
                return View(Barn);
            }
        }

        // GET: AnimalsController/Create
        public IActionResult Create()
        {
            

             return View();
        }

        // POST: AnimalsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Animal animal)
        {
            
            try
            {

                _context.Animals.Add(animal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));


            }
            catch
            {
                return View();
            }
        }

        // GET: AnimalsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var Animal = await _context.Animals.FindAsync(id);

            if (Animal == null)
            {
                return NotFound();

            }
            else
            {
                return View(Animal);
            }
        }

        // POST: AnimalsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Animal animal)
        {

            try
            {
                _context.Update(animal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AnimalsController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Animal = await _context.Animals.FindAsync(id);

            if (Animal == null)
            {
                return NotFound();

            }
            else
            {
                return View(Animal);
            }
        }

        // POST: AnimalsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var Animal = await _context.Animals.FindAsync(id);
                _context.Animals.Remove(Animal);
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
