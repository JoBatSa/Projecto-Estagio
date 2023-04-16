using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DDDSample1.Domain.Customers;

namespace DDDSample1.Infraestructure.Customers
{
    public class CustomerEntityTypeConfiguration: IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            // cf. https://www.entityframeworktutorial.net/efcore/fluent-api-in-entity-framework-core.aspx
            
            //builder.ToTable("Categories", SchemaNames.DDDSample1);

            builder.OwnsOne(pn => pn.CustomerPhoneNumber, phoneNumber => { phoneNumber.Property(p => p.PhoneNumber).IsRequired(); });
            builder.OwnsOne(em => em.CustomerEmail, email => { email.HasIndex(e => e.Email).IsUnique(); });
            builder.HasKey(b => b.Id);

             builder.OwnsOne(c => c.CustPosition);
           

           // builder.OwnsOne(u => u.Company, company => { Company.HasIndex(e => e.company).IsUnique(); });
            //builder.Property<bool>("_active").HasColumnName("Active");
        }
    }
}