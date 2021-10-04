using AtaTexnologiyadan.Entityes.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtaTexnologiyadan.Persistence.Configurations
{
    public class EmployeePositionConfiguration : IEntityTypeConfiguration<EmployeePosition>
    {
        public void Configure(EntityTypeBuilder<EmployeePosition> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.HasMany(x => x.Employees)
                .WithOne(x => x.EmployeePosition);
        }
    }
}