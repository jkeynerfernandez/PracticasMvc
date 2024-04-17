using System.Data.SqlClient;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using PracticaCuatro.Data;
using PracticaCuatro.Models;

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


        [HttpPost]
        public async Task<IActionResult> Login(Empleado empleado){

            try
            {
                using (SqlConnection con = new(_context.Conexion))
                {
                    using  (SqlCommand cmd= new ("sp_validar_Empleado", con)){
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Nombres",System.Data.SqlDbType.VarChar).Value= empleado.Nombres;
                        cmd.Parameters.Add("@Contrasena",System.Data.SqlDbType.VarChar).Value= empleado.Contrasena;

                        var dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            if (dr["Nombres"] != null && empleado != null)
                            {
                                List<Claim> c = new List<Claim>(){
                                    new Claim(ClaimTypes.NameIdentifier, empleado.Nombres)


                                };

                                ClaimsIdentity  ci = new(c, CookieAuthenticationDefaults.AuthenticationScheme);
                                AuthenticationProperties p = new();


                                p.AllowRefresh = true;
                                p.IsPersistent = empleado.MantenerActivo;


                                if (!empleado.MantenerActivo)
                                    p.ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(1);
                                else
                                    p.ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1);

                                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(ci), p);
                                return RedirectToAction("Index", "Home");
                                
                            } else {
                                ViewBag.Error= "incorrecto";
                            }
                        }
                        con.Close();
                    
                    }
                }
                return View();
            }
            catch (System.Exception e)
            {
               ViewBag.Error = e.Message;
                return View(); 
               
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(){
            return View("Error!");
        }

        

    }

}