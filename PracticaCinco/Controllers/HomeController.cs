using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PracticaCinco.Models;

using Microsoft.AspNetCore.Http;
using PracticaCinco.Helpers;
using PracticaCinco.Providers;

namespace PracticaCinco.Controllers;

public class HomeController : Controller
{

    private HelperUploadFiles helperUpload;

    public HomeController(HelperUploadFiles helperUpload){
        this.helperUpload=helperUpload;
    }

    public IActionResult Index(){
        return View();
    }

    [HttpPost]


    public async  Task<IActionResult> Index (IFormFile imagen, int ubicacion){
        string nombreImagen = imagen.FileName;
        string path= "";

        switch (ubicacion){
            case 0: 
               path = await this.helperUpload.UploadFilesAsync(imagen, nombreImagen, Folders.Upload);
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


        ViewBag.Mensaje= "Fichero"+ nombreImagen +"subido a"+ path;
        return View();
    }


    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }



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
