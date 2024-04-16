using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticaCuatro.Data;
using PracticaCuatro.Models;


namespace PracticaCuatro.Controllers{
    public class EmpleadosController: Controller{


        public readonly FotoContext _context;

        public EmpleadosController(FotoContext context){
            _context = context;
        }

        public async Task<IActionResult> Index(){
          return View(await _context.Empleados.ToListAsync());

        }

        public async Task<IActionResult> Details(int? id){
            return View(await _context.Empleados.FirstOrDefaultAsync(m => m.Id==id));
        }

          public async Task<IActionResult> DetailsFind(List<int> id){
           var Empleados = await _context.Empleados.Where(u => id.Contains(u.Id)).ToListAsync();

    if (Empleados != null && Empleados.Any())
    {
        return View(Empleados);
    }
    else
    {
        return RedirectToAction("Index");
    }
        }

        public async Task<IActionResult> Delete(int? id){
            var empleado = await _context.Empleados.FindAsync(id);
            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();
            
            return RedirectToAction("Index");

        }

        public IActionResult Create(){


            return View();

        }

        [HttpPost]
        public IActionResult Create(Empleado u){


            _context.Empleados.Add(u);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id){
            return View(await _context.Empleados.FirstOrDefaultAsync(m=> m.Id == id));
        }


        [HttpPost]
        public  IActionResult EditEmpleado(int? id, Empleado u){
             _context.Empleados.Update(u);
             _context.SaveChanges();
             return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Search(string Names){
            var empleado = await _context.Empleados.Where(u => u.Nombres.Contains(Names)).ToListAsync();
           
           
           
            if (empleado != null && empleado.Any())
    {
    
        return RedirectToAction("DetailsFind", new { id = empleado.First().Id });
    }
    else
    {
        return RedirectToAction("Index");
    }
            
            

        }


        
 


    }


}