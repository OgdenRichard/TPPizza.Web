using Microsoft.EntityFrameworkCore;

namespace TPPizza.Web.DataAccessLayer
{
    //Hello from test branch 
    public sealed class PizzeriaDbContext : DbContext
    {
        public PizzeriaDbContext(DbContextOptions<PizzeriaDbContext> options)
        : base(options)
        {
        }
    
    }
}
