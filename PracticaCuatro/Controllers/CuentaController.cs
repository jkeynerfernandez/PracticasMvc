using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using PracticaCuatro.Data;

namespace PracticaCuatro.Controllers
{



    public class CuentaController : Controller
    {
        private readonly FotoContext _context;

        public CuentaController(FotoContext context)
        {

            _context = context;

        }

        public IActionResult Login()
        {
            ClaimsPrincipal c  = HttpContext.User;
            if (c.Identity != null){
                if (c.Identity.IsAuthenticated)
                return RedirectToAction("Index","Home");
            }

            return View();
        }

    }

}