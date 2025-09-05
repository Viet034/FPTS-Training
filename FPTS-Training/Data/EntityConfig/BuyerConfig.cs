using FPTS_Training.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FPTS_Training.Data.EntityConfig;

public class BuyerConfig : IEntityTypeConfiguration<Buyers>
{
    public const string ToTable = "BUYERS";
    public const string PaymentColumnName = "PAYMENT_METHOD";


    public static Dictionary<string, string> DataTypes = new Dictionary<string, string>
    {

        {PaymentColumnName, "VARCHAR2(25 BYTE)" },

    };
    public void Configure(EntityTypeBuilder<Buyers> builder)
    {
        builder.ToTable(ToTable);
        builder.Property(p => p.PaymentMethod)
            .HasColumnType(DataTypes[PaymentColumnName])
            .HasColumnName(PaymentColumnName);
    }
}
