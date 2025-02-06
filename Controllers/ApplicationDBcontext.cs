
using assignment1C_.Models;
using Microsoft.EntityFrameworkCore;

namespace assignment1C_.Controllers
{
    public class ApplicationDBcontext : DbContext

    {
        public DbSet<Manager> Manager { get; set; } = null!;


        public static implicit operator ApplicationDBcontext(ContactController v)
        {
            throw new NotImplementedException();
        }
    }
}