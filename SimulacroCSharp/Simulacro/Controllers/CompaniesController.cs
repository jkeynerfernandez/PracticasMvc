using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Simulacro.Data;
using Simulacro.Helpers;
using Simulacro.Models;
using Simulacro.Providers;


namespace Simulacro.Controllers{


    public class CompaniesController: Controller{

        public readonly CompContext _context;
        private readonly HelperUploadFiles helperUploadFiles;

        public CompaniesController(HelperUploadFiles helperUpload, CompContext context){

            _context= context;
            this.helperUploadFiles= helperUpload;
        }

        //vista Index
      

        public async Task<IActionResult> Index(string SearchString){

            var comp = from find in _context.Companies select find;

            if (!string.IsNullOrEmpty(SearchString)){
                comp= comp.Where(c => c.Name.Contains(SearchString));
            }

            return View(await comp.ToListAsync());
        }

        //Detalles

        public async Task<IActionResult> Details(int? id){

            return View(await _context.Companies.FirstOrDefaultAsync(m => m.Id == id));
        }

        //Crear
        public  IActionResult Create(){
            return View();
        }

        
        public async Task<IActionResult> CreateCompanie(IFormFile archivo, int ubicacion, Companie comp){


            string nombreArchivo = archivo.FileName;
            string path ="";

            switch(ubicacion){
                case 0:
                    path= await this.helperUploadFiles.UploadFilesAsync(archivo, nombreArchivo, Folders.Uploads);
                break;

                case 1:
                    path= await this.helperUploadFiles.UploadFilesAsync(archivo, nombreArchivo, Folders.Images);
                break;

                case 2:
                    path= await this.helperUploadFiles.UploadFilesAsync(archivo, nombreArchivo, Folders.Documents);
                break;

                case 3:
                    path= await this.helperUploadFiles.UploadFilesAsync(archivo, nombreArchivo, Folders.Temp);
                break;

                
            }

            comp.Logo = nombreArchivo;
           // comp.Logo = path;

            _context.Companies.Add(comp);
            _context.SaveChanges();
            return RedirectToAction("Index");




        }

        // Editar

        public  async Task<IActionResult> Edit(int? id){
            return View(await _context.Companies.FirstOrDefaultAsync(m => m.Id ==id));
        }

        public IActionResult EditCompanie( Companie comp){

            _context.Companies.Update(comp);
            _context.SaveChanges();
            return RedirectToAction("Index");


        }

        //Eliminar

         public  async Task<IActionResult> Delete(int? Id){

            var companie= await _context.Companies.FindAsync(Id);
             _context.Companies.Remove(companie);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        

      


        
    }


}