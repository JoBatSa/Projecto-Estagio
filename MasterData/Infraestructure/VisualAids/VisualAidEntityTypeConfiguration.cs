
using DDDSample1.Domain.VisualAids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDSample1.Infraestructure.VisualAids
{
    public class VisualAidEntityTypeConfiguration: IEntityTypeConfiguration<VisualAid>
    {
     public void Configure(EntityTypeBuilder<Domain.VisualAids.VisualAid> builder)
        {
            // cf. https://www.entityframeworktutorial.net/efcore/fluent-api-in-entity-framework-core.aspx
            
            //builder.ToTable("Categories", SchemaNames.DDDSample1);



              
            builder.HasKey(b => b.Id);
            //builder.Property<bool>("_active").HasColumnName("Active");
        }
    }
}