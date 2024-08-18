using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace BasicAuthorization.Data

{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //Esse comando aplica a configuração definida em uma classe separada, UserConfiguration. UserConfiguration é provavelmente uma classe que implementa a interface IEntityTypeConfiguration<User>, onde você pode definir configurações detalhadas para a entidade User, como chaves primárias, relacionamentos, restrições de campo, etc.
        //    modelBuilder.ApplyConfiguration(new UserConfiguration());
        //}

        public DbSet<Products> Products { get; set; }
    }
}
