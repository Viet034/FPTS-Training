using FPTS_Training.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FPTS_Training.Data.EntityConfig;

public class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{
    public const string IdColumnName = "ID";
    public const string CodeColumnName = "CODE";
    public const string NameColumnName = "NAME";
    public const string CreateDateColumnName = "CREATE_DATE";
    public const string CreateByColumnName = "CREATE_BY";
    public const string UpdateDateColumnName = "UPDATE_DATE";
    public const string UpdateByColumnName = "UPDATE_BY";
    public const string OffsetColumnName = "OFFSETS";
    public const string PartitionColumnName = "PARTITIONS";

    public static Dictionary<string, string> DataTypes = new Dictionary<string, string> 
    {
        {IdColumnName, "VARCHAR2(5 BYTE)"}, 
        {CodeColumnName, "VARCHAR2(5 BYTE)"}, 
        {NameColumnName, "VARCHAR2(20 BYTE)"}, 
        {CreateDateColumnName, "TIMESTAMP(6)"}, 
        {CreateByColumnName, "VARCHAR2(20 BYTE)"}, 
        {UpdateDateColumnName, "TIMESTAMP(6)"}, 
        {UpdateByColumnName, "VARCHAR2(20 BYTE)"}, 
        {OffsetColumnName, "NUMBER(19,0)"}, 
        {PartitionColumnName, "NUMBER(5,0)"}, 
    };

    public void Configure(EntityTypeBuilder<T> builder)
    {
        builder.Property(p => p.Id)
            .HasColumnType(DataTypes[IdColumnName])
            .HasColumnName(IdColumnName);
        builder.Property(p => p.Code)
            .HasColumnType(DataTypes[CodeColumnName])
            .HasColumnName(CodeColumnName);
        builder.Property(p => p.Name)
            .HasColumnType(DataTypes[NameColumnName])
            .HasColumnName(NameColumnName);
        builder.Property(p => p.CreateDate)
            .HasColumnType(DataTypes[CreateDateColumnName])
            .HasColumnName(CreateDateColumnName);
        builder.Property(p => p.CreateBy)
            .HasColumnType(DataTypes[CreateByColumnName])
            .HasColumnName(CreateByColumnName);
        builder.Property(p => p.UpdateDate)
            .HasColumnType(DataTypes[UpdateDateColumnName])
            .HasColumnName(UpdateDateColumnName);
        builder.Property(p => p.UpdateBy)
            .HasColumnType(DataTypes[UpdateByColumnName])
            .HasColumnName(UpdateByColumnName);
        builder.Property(p => p.Offsets)
            .HasColumnType(DataTypes[OffsetColumnName])
            .HasColumnName(OffsetColumnName);
        builder.Property(p => p.Partitions)
            .HasColumnType(DataTypes[PartitionColumnName])
            .HasColumnName(PartitionColumnName);
    }
}
