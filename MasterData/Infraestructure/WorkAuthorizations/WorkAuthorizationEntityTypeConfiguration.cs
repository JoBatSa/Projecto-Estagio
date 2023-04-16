using DDDSample1.Domain.WorkAuthorizations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDSample1.Infraestructure.WorkAuthorizations
{
    public class WorkAuthorizationEntityTypeConfiguration: IEntityTypeConfiguration<WorkAuthorization>
    {
  public void Configure(EntityTypeBuilder<WorkAuthorization> builder)
        {
            // cf. https://www.entityframeworktutorial.net/efcore/fluent-api-in-entity-framework-core.aspx
            
            //builder.ToTable("Categories", SchemaNames.DDDSample1);


 
           // builder.OwnsMany(u=> u.EmployeeId); 
            builder.OwnsMany(u=> u.EmployeeNumber); 
            builder.HasKey(b => b.Id);
            //builder.Property<bool>("_active").HasColumnName("Active");
        }
        
    }

}