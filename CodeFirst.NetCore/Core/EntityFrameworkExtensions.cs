using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace CodeFirst.NetCore.Core
{
    static class EntityFrameworkExtensions
    {
        internal static EntityTypeBuilder<TEntity> UseTimestampedProperty<TEntity>(this EntityTypeBuilder<TEntity> entity) where TEntity : class, ITimestampedEntity
        {
            entity.Property(d => d.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("TIMESTAMP")
                .ValueGeneratedOnAdd();
            entity.Property(d => d.LastModified)
                .HasColumnName("last_modified")
                .HasColumnType("TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate();

            entity.Property(d => d.CreatedAt).Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
            entity.Property(d => d.CreatedAt).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            entity.Property(d => d.LastModified).Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
            entity.Property(d => d.LastModified).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            return entity;
        }
    }
}
