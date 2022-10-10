using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Database.Configuration;
public class ConfigDebtor
{
    public ConfigDebtor(EntityTypeBuilder<Debtor> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(x => x.DebtorCode);
        entityTypeBuilder.Property(x => x.DebtorCode).ValueGeneratedOnAdd();
        entityTypeBuilder.Property(x => x.Document).IsRequired().HasMaxLength(15);
        entityTypeBuilder.HasIndex(x => x.Document);
        entityTypeBuilder.Property(x => x.DocumentType).IsRequired().HasMaxLength(10);
        entityTypeBuilder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        entityTypeBuilder.HasIndex(x => x.Name);
        entityTypeBuilder.Property(x => x.CreatorUser).IsRequired().HasMaxLength(10);
        entityTypeBuilder.Property(x => x.Status).IsRequired();
        
    }
}
