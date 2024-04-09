using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace PracticaCinco.Providers{

    public enum Folders{
        Upload = 0, Images =1, Documents =2, Temp =3
    }


    public class PathProvider{
        private IWebHostEnvironment  hostEnviroment;
        public PathProvider(IWebHostEnvironment hostEnvironment){
            this.hostEnviroment= hostEnviroment;

        }

        public string  MapPath(string fileName, Folders folder){
            string  carpeta = "";
            if (folder == Folders.Upload){
                carpeta ="uploads";
            }else if (folder == Folders.Images){
                carpeta ="images";
            }else if (folder == Folders.Documents){
                carpeta ="documents";
            }

               string path = Path.Combine(this.hostEnviroment.WebRootPath, carpeta, fileName);

            if (folder == Folders.Temp){
                path= Path.Combine(Path.GetTempPath(), fileName);
            }    
            return path;
        }    


     

    }
}