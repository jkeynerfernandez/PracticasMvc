using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticaCuatro.Data;
using PracticaCuatro.Models;


namespace PracticaCuatro.Controllers{
    public class UsersController: Controller{


        public readonly FotoContext _context;

        public UsersController(FotoContext context){
            _context = context;
        }

        public async Task<IActionResult> Index(){
          return View(await _context.Users.ToListAsync());

        }

        public async Task<IActionResult> Details(int? id){
            return View(await _context.Users.FirstOrDefaultAsync(m => m.Id==id));
        }

          public async Task<IActionResult> DetailsFind(List<int> id){
           var users = await _context.Users.Where(u => id.Contains(u.Id)).ToListAsync();

    if (users != null && users.Any())
    {
        return View(users);
    }
    else
    {
        return RedirectToAction("Index");
    }
        }

        public async Task<IActionResult> Delete(int? id){
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            
            return RedirectToAction("Index");

        }

        public IActionResult Create(){


            return View();

        }

        [HttpPost]
        public IActionResult Create(User u){


            _context.Users.Add(u);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id){
            return View(await _context.Users.FirstOrDefaultAsync(m=> m.Id == id));
        }


        [HttpPost]
        public  IActionResult EditUser(int? id, User u){
             _context.Users.Update(u);
             _context.SaveChanges();
             return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Search(string Names){
            var user = await _context.Users.Where(u => u.Names.Contains(Names)).ToListAsync();
           
           
           
            if (user != null && user.Any())
    {
    
        return RedirectToAction("DetailsFind", new { id = user.First().Id });
    }
    else
    {
        return RedirectToAction("Index");
    }
            
            

        }


        
 


    }


}