using Microsoft.EntityFrameworkCore;
using WS_ColineSoft.Domain.Entities;

namespace WS_ColineSoft.DAL.Context
{
    public class ColineSoftContext : DbContext
    {
        public ColineSoftContext(DbContextOptions<ColineSoftContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Necessário para validação dos MAPS
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ColineSoftContext).Assembly);
        }
        public DbSet<TesteEntity> Teste { get;set; }
    }
}
