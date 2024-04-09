using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Simulacro.Data;
using Simulacro.Models;



namespace Simulacro.Controllers{


    public class SectorsController: Controller{

        public readonly CompContext _context;

        public SectorsController(CompContext context){

            _context= context;
        }

        //vista Index

        public async Task<IActionResult> Index(){
            return View(await _context.Sectors.ToListAsync());
        }

        //Detalles

        public async Task<IActionResult> Details(int? id){

            return View(await _context.Sectors.FirstOrDefaultAsync(m => m.Id == id));
        }

        //Crear
        public  IActionResult Create(){
            return View();
        }

        public IActionResult CreateSector( Sector sect){

            _context.Sectors.Add(sect);
            _context.SaveChanges();
            return RedirectToAction("Index");


        }

        // Editar

        public  async Task<IActionResult> Edit(int? id){
            return View(await _context.Sectors.FirstOrDefaultAsync(m => m.Id ==id));
        }

        public IActionResult EditSector( Sector sect){

            _context.Sectors.Update(sect);
            _context.SaveChanges();
            return RedirectToAction("Index");


        }

        //Eliminar

         public  async Task<IActionResult> Delete(int? Id){

            var sector= await _context.Sectors.FindAsync(Id);
             _context.Sectors.Remove(sector);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }



        
    }


}