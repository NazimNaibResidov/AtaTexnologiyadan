using AtaTexnologiyadan.Entityes.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtaTexnologiyadan.Persistence.Configurations
{
    public class ContractConfiguration : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ContractNumber);
            builder.Property(x => x.Department);
            builder.Property(x => x.Position);
            builder.Property(x => x.Salary).HasColumnType("decimal(18,2)"); ;
            builder.HasMany(x => x.Employees)
                .WithOne(x => x.Contract);
        }
    }
}