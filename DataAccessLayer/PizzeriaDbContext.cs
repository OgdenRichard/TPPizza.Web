using Microsoft.EntityFrameworkCore;

namespace TPPizza.Web.DataAccessLayer
{
    public sealed class PizzeriaDbContext : DbContext
    {
        public PizzeriaDbContext(DbContextOptions<PizzeriaDbContext> options)
        : base(options)
        {
        }
    
    }
}
