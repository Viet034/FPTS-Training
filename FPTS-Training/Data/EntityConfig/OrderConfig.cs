using FPTS_Training.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FPTS_Training.Data.EntityConfig;

public class OrderConfig : BaseEntityConfiguration<Orders>
{
    public const string ToTable = "ORDERS";
    public const string BuyerIdColumnName = "BUYER_ID";
    public const string AddressIdColumnName = "ADDRESS";
    public const string StatusColumnName = "STATUS";

    public static Dictionary<string, string> DataTypes = new Dictionary<string, string>
    {
        {BuyerIdColumnName, "VARCHAR2(5 BYTE)" },
        {AddressIdColumnName, "VARCHAR2(20 BYTE)" },
        {StatusColumnName, "NUMBER(1,0)" },
    };
    public override void Configure(EntityTypeBuilder<Orders> builder)
    {
        base.Configure(builder);
        builder.ToTable(ToTable);
        builder.Property(p => p.BuyerId)
            .HasColumnType(DataTypes[BuyerIdColumnName])
            .HasColumnName(BuyerIdColumnName);
        builder.Property(p => p.Address)
            .HasColumnType(DataTypes[AddressIdColumnName])
            .HasColumnName(AddressIdColumnName);
        builder.Property(p => p.Status)
            .HasConversion<int>()
            .HasColumnType(DataTypes[StatusColumnName])
            .HasColumnName(StatusColumnName);
    }
}
