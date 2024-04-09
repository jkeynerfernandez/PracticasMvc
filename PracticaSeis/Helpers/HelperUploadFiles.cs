using PracticaSeis.Providers;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace PracticaSeis.Helpers{
    public class HelperUploadFiles{
        
        public PathProvider pathProvider;

        public HelperUploadFiles(PathProvider pathProvider){

            this.pathProvider = pathProvider;
        }

        public async Task<string> UploadFilesAsync(IFormFile formFile, string nombreImagen, Folders folder){

            string path =  this.pathProvider.MapPath(nombreImagen, folder);

            using  (Stream stream =new FileStream(path, FileMode.Create)){
                await  formFile.CopyToAsync(stream);
            }

            return path;



        }

    }

}