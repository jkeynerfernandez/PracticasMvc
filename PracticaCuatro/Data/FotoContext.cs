using PracticaCuatro.Models;
using Microsoft.EntityFrameworkCore;

namespace PracticaCuatro.Data{

    public class FotoContext : DbContext{


        public string Conexion { get; }

        public FotoContext(string valor)
        {
            Conexion = valor;
        }
        

    }



}