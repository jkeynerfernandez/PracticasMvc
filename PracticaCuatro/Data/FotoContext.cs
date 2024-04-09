using PracticaCuatro.Models;
using Microsoft.EntityFrameworkCore;

namespace PracticaCuatro.Data{

    public class FotoContext : DbContext{

        public FotoContext(DbContextOptions<FotoContext> options) : base(options){


        }

        public DbSet<User> Users {get; set;}


    }



}