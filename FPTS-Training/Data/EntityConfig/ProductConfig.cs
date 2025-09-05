using FPTS_Training.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FPTS_Training.Data.EntityConfig;

public class ProductConfig : IEntityTypeConfiguration<Products>
{
    public const string ToTable = "PRODUCTS";
    public const string StatusColumnName = "STATUS";

    public static Dictionary<string, string> DataTypes = new Dictionary<string, string>
    {
        {StatusColumnName, "NUMBER(1,0)" }
    };
    public void Configure(EntityTypeBuilder<Products> builder)
    {
        builder.Property(p => p.Status)
            .HasConversion<int>()
            .HasColumnType(DataTypes[StatusColumnName])
            .HasColumnName(StatusColumnName);
    }
}
