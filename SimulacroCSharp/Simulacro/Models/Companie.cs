
using Simulacro.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
namespace Simulacro.Models{

    public class Companie {


        public Int32 Id {get; set;}
        public string? Name {get; set;}
        public string? Nit {get; set;}
        public string? Address {get; set;}
        public  string? Description {get; set;}
        public string? Logo {get; set;}
        public string?Phone {get; set;}
        public string? LegalRepresentative {get; set;}
        public Int32 SectorId {get; set;}


     

    }






}