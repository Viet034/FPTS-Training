using FPTS_Training.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FPTS_Training.Data.EntityConfig;

public class BuyerConfig : BaseEntityConfiguration<Buyers>
{
    public const string ToTable = "BUYERS";
    public const string PaymentColumnName = "PAYMENT_METHOD";


    public static Dictionary<string, string> 
        
        DataTypes = new Dictionary<string, string>
    {

        {PaymentColumnName, "VARCHAR2(25 BYTE)" },

    };
    public override void Configure(EntityTypeBuilder<Buyers> builder)
    {
        base.Configure(builder);
        builder.ToTable(ToTable);
        builder.Property(p => p.PaymentMethod)
            .HasColumnType(DataTypes[PaymentColumnName])
            .HasColumnName(PaymentColumnName);
    }
}
