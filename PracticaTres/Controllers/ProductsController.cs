
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PracticaTres.Data;

namespace PracticaTres. Controlles{

    public class ProductsController:Controller{ 

        public readonly DataContext _context;

        public ProductsController(DataContext context){

            _context=context;


        }

         public async Task<IActionResult> Index(){
          return View(await _context.Products.ToListAsync());

        }


          public async Task<IActionResult> Details(int? Id){
          return View(await _context.Products.FirstOrDefaultAsync(m=> m.Id == Id));

        }










    }

}