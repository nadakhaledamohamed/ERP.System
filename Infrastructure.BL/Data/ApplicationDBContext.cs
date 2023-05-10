

namespace Infrastructure.BL.Data
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {
                
        }


        protected override void OnModelCreating(ModelBuilder builder) //change names of Identity of DataBase 
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().ToTable("Users" , "Security");
            builder.Entity<IdentityRole>().ToTable("Roles", "Security");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "Security");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim", "Security");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim", "Security");
            

        }

        public DbSet<Branch> Branches { get; set; }
        public DbSet<Brand> Brands  { get; set; }
        public DbSet<Category> Categories  { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<MailSetting> MailSettings { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Unit> Units { get; set; }





    }
}
