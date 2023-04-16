using DDDSample1.Domain.Employees;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDSample1.Infraestructure.Employees
{
    public class EmployeeEntityTypeConfiguration: IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            // cf. https://www.entityframeworktutorial.net/efcore/fluent-api-in-entity-framework-core.aspx
            
            //builder.ToTable("Categories", SchemaNames.DDDSample1);


            builder.OwnsOne(j => j.Job_Position).Property(pn => pn.job_Position);
            builder.OwnsOne(u => u.UserPhoneNumber, phoneNumber => { phoneNumber.Property(pn => pn.PhoneNumber).IsRequired(); });
            builder.OwnsOne(u => u.UserEmail, email => { email.HasIndex(e => e.Email).IsUnique(); });
            builder.HasKey(b => b.Id);
           
            //builder.Property<bool>("_active").HasColumnName("Active");
        }
    }
}