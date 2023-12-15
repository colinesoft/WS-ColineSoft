using Microsoft.EntityFrameworkCore;
using WS_ColineSoft.Domain.Entities;

namespace WS_ColineSoft.DAL.Context
{
    public class ColineSoftContext : DbContext
    {
        public ColineSoftContext(DbContextOptions<ColineSoftContext> options) : base(options)
        {
            
        }

        public DbSet<TesteEntity> Teste { get;set; }
    }
}
