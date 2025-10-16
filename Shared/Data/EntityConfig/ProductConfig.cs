using Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shared.Data.EntityConfig;

public class ProductConfig : BaseEntityConfiguration<Products>
{
    public const string ToTable = "PRODUCTS";
    public const string StatusColumnName = "STATUS";

    public static Dictionary<string, string> DataTypes = new Dictionary<string, string>
    {
        {StatusColumnName, "NUMBER(1,0)" }
    };
    public override void Configure(EntityTypeBuilder<Products> builder)
    {
        base.Configure(builder);
        builder.ToTable(ToTable);
        builder.Property(p => p.Status)
            .HasConversion<int>()
            .HasColumnType(DataTypes[StatusColumnName])
            .HasColumnName(StatusColumnName);
    }
}
