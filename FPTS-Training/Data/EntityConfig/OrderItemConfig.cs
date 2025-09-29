using FPTS_Training.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FPTS_Training.Data.EntityConfig;

public class OrderItemConfig : BaseEntityConfiguration<OrderItems>
{
    public const string ToTable = "ORDER_ITEMS";
    public const string UnitColumnName = "UNITS";
    public const string UnitPriceColumnName = "UNIT_PRICE";
    public const string ProductIdColumnName = "PRODUCT_ID";
    public const string OrderIdColumnName = "ORDER_ID";

    public static Dictionary<string, string> DataTypes = new Dictionary<string, string>
    {
        {UnitColumnName, "VARCHAR2(5 BYTE)" },
        {UnitPriceColumnName, "NUMBER(18,2)" },
        {ProductIdColumnName, "VARCHAR2(5 BYTE)" },
        {OrderIdColumnName, "VARCHAR2(5 BYTE)" },
    };
    public override void Configure(EntityTypeBuilder<OrderItems> builder)
    {
        base.Configure(builder);
        builder.ToTable(ToTable);
        builder.Property(p => p.Units)
            .HasColumnType(DataTypes[UnitColumnName])
            .HasColumnName(UnitColumnName);
        builder.Property(p => p.UnitPrice)
            .HasColumnType(DataTypes[UnitPriceColumnName])
            .HasColumnName(UnitPriceColumnName);
        builder.Property(p => p.ProductId)
            .HasColumnType(DataTypes[ProductIdColumnName])
            .HasColumnName(ProductIdColumnName);
        builder.Property(p => p.OrderId)
            .HasColumnType(DataTypes[OrderIdColumnName])
            .HasColumnName(OrderIdColumnName);
    }
}
