
using System.ComponentModel.DataAnnotations.Schema;
using PracticaCuatro.Data;
namespace PracticaCuatro.Models{
    public class Empleado{

        
        public int Id {get; set;}
        public string? Nombres {get;set; }
        public string? Apellidos {get;set;}
        public string? Correo {get;set;}

        public string? Contrasena {get;set;}

        public DateTime? HoraIngreso {get;set;}
        public DateTime? HoraSalida {get;set;}
        public string? Posicion {get;set;}
        public int NivelPermisos {get; set;}


        [NotMapped]
        public bool MantenerActivo{get; set;}


    }



}