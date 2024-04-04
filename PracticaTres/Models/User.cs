using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticaTres.Data;

namespace PracticaTres.Models{

    public class User{

        public int Id {get; set;}
        public string? Names {get;set; }
        public string? LastNames {get;set;}
        public string? Email {get;set;}

        public string? Address {get;set;}

        public DateTime? BirthDate {get;set;}
        public string? Phone {get;set;}

    }

}