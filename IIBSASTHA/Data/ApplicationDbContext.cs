using IIBSASTHA.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace IIBSASTHA.Data
{
    public class ApplicationDbContext:IdentityDbContext<Users>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
    }
}
