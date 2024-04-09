using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PracticaSeis.Helpers;
using PracticaSeis.Providers;
using PracticaSeis.Models;

namespace PracticaSeis.Controllers;

public class HomeController : Controller
{
    private HelperUploadFiles helperUpload;
     private readonly ILogger<HomeController> _logger;

    public HomeController(HelperUploadFiles helperUpload){
        this.helperUpload = helperUpload;
        //_logger = logger;
    }

      public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(IFormFile imagen, int ubicacion){
        string nombreImagen = imagen.FileName;
        string path= "";

        switch(ubicacion){


            case 0:
            path = await this.helperUpload.UploadFilesAsync(imagen, nombreImagen, Folders.Uploads);
            break;

            case 1:
            path = await this.helperUpload.UploadFilesAsync(imagen, nombreImagen, Folders.Images);
            break;

            case 2:
            path = await this.helperUpload.UploadFilesAsync(imagen, nombreImagen, Folders.Documents);
            break;

            case 3:
            path = await this.helperUpload.UploadFilesAsync(imagen, nombreImagen, Folders.Temp);
            break;
        }


        ViewBag.Mensaje = "Fichero" + nombreImagen + "subido a " + path;

        return View();

    }





   

//    public HomeController(ILogger<HomeController> logger)
//     {
//         _logger = logger;
//     } 

  

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
