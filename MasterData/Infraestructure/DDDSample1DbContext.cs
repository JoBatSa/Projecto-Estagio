using Microsoft.EntityFrameworkCore;

using DDDSample1.Infraestructure.Administrators;
using DDDSample1.Domain.Administrators;


using DDDSample1.Infraestructure.Customers;
using DDDSample1.Domain.Customers;

using DDDSample1.Infraestructure.Employees;
using DDDSample1.Domain.Employees;

using DDDSample1.Infraestructure.Reports;
using DDDSample1.Domain.Reports;

using DDDSample1.Domain.WorkOrders;
using DDDSample1.Infraestructure.WorkOrders;

using DDDSample1.Domain.WorkAuthorizations;
using DDDSample1.Infraestructure.WorkAuthorizations;

using DDDSample1.Domain.VisualAids;
using DDDSample1.Infraestructure.VisualAids;

using DDDSample1.Domain.Logins;
using DDDSample1.Infrastructure.Logins;


namespace DDDSample1.Infrastructure
{
    public class DDDSample1DbContext : DbContext
    {
        public DbSet<Administrator> Administrators { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Report> Reports { get; set; }

        public DbSet<WorkOrder> WorkOrders { get; set; }

        public DbSet<WorkAuthorization> WorkAuthorizations { get; set; }

        public DbSet<VisualAid> VisualAids { get; set; }


          public DbSet<Login> Logins { get; set; }

        public DDDSample1DbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        base.OnModelCreating(modelBuilder);
        //    //modelBuilder.Entity<User>();

       
            modelBuilder.ApplyConfiguration(new LoginEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new AdministratorEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ReportEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new WorkOrderEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new WorkAuthorizationEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new VisualAidEntityTypeConfiguration());
        }
    }
}