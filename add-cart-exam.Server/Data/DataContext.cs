using Microsoft.EntityFrameworkCore;

namespace add_cart_exam.Server.Data
{
    public class DataContext : DbContext
    {
        public virtual DbSet<Products>? Products { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DataContext()
        {
        }
    }
}
