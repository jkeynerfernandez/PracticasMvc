
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticaTres.Data;


namespace PracticaTres.Controllers{

    public class UsersController : Controller{

        public readonly DataContext _context;

        public UsersController(DataContext context){

        _context = context;

        }

        public async Task<IActionResult> Index(){
          return View(await _context.Users.ToListAsync());

        }

        

     


    }

}