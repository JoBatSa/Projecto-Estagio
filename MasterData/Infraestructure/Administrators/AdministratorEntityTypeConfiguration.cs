
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DDDSample1.Domain.Logins;
using DDDSample1.Domain.Administrators;



namespace DDDSample1.Infraestructure.Administrators
{
    
    internal class AdministratorEntityTypeConfiguration : IEntityTypeConfiguration<Administrator>
    {
        public void Configure(EntityTypeBuilder<Administrator> builder)
        {
            
            builder.HasKey(b => b.Id);
            builder.OwnsOne(u => u.user);
            builder.OwnsOne(u => u.password);
          
            builder.OwnsOne(j => j.AdminP);

            //  builder.Property<bool>("_active").HasColumnName("Active");
        }
    }
}
