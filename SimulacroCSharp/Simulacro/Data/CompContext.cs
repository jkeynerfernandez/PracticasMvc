
using Microsoft.EntityFrameworkCore;
using Simulacro.Models;

namespace Simulacro.Data{

    public class CompContext :DbContext{

        public CompContext(DbContextOptions<CompContext> options) : base(options){

        }

        public DbSet<Companie> Companies {get; set;}
        public DbSet<Sector> Sectors {get; set;}


    }


}