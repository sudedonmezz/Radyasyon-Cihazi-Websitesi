using Microsoft.EntityFrameworkCore;
using Entities.Models;


using Repositories.Config;
using System.Reflection;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
namespace Repositories
{

        public class RepositoryContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Product>Products{get;set;}
        public DbSet<Category>Categories{get;set;}
        public DbSet<Order>Orders {get;set;}
        public DbSet<SupportMessage>SupportMessages {get;set;}
        public DbSet<ProductAnalysis> productAnalyses {get;set;}
        public DbSet<ContactMessage> ContactMessages { get; set; }



        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.ApplyConfiguration(new ProductAnalysisConfig());
           

        }
    }
}



    

