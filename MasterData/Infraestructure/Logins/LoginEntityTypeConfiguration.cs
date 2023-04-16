using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DDDSample1.Domain.Employees;
using DDDSample1.Domain.Logins;

namespace DDDSample1.Infrastructure.Logins
{
    internal class LoginEntityTypeConfiguration : IEntityTypeConfiguration<Login>
    {
        public void Configure(EntityTypeBuilder<Login> builder)
        {
            builder.HasKey(b => b.Id);
            builder.OwnsOne(u => u.Name);
            builder.OwnsOne(u => u.User);
            builder.OwnsOne(u => u.Date);
builder.OwnsOne(j => j.tipo);
           
        }
    }
}