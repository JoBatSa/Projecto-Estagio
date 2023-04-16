
using DDDSample1.Domain.Reports;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDSample1.Infraestructure.Reports
{
    public class ReportEntityTypeConfiguration : IEntityTypeConfiguration<Report>
    {
      public void Configure(EntityTypeBuilder<Report> builder)
        {
            // cf. https://www.entityframeworktutorial.net/efcore/fluent-api-in-entity-framework-core.aspx
            
            //builder.ToTable("Categories", SchemaNames.DDDSample1);



          //  builder.OwnsMany(u=> u.OkParts).Property(ok =>ok.number);
           // builder.OwnsMany(u=> u.NokParts).Property(nok =>nok.number);;
           // builder.OwnsMany(u=> u.PartNumber).Property(pn =>pn.frase);;
            builder.HasKey(b => b.Id);
            //builder.Property<bool>("_active").HasColumnName("Active");
        }
    }
}