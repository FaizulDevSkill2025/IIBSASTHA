using Microsoft.EntityFrameworkCore;

namespace IIBSASTHA.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
    }
}
