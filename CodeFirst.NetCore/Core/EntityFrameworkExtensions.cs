using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;

namespace CodeFirst.NetCore
{
    static class EntityFrameworkExtensions
    {
        //base entity builder
        internal static EntityTypeBuilder<TEntity> UseTimestampedProperty<TEntity>(this EntityTypeBuilder<TEntity> entity) where TEntity : class, ITimestampedEntity
        {
            entity.Property(d => d.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("TIMESTAMP")
                .ValueGeneratedOnAdd();
            entity.Property(d => d.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate();

            entity.Property(d => d.CreatedAt).Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
            entity.Property(d => d.CreatedAt).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            entity.Property(d => d.UpdatedAt).Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
            entity.Property(d => d.UpdatedAt).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            return entity;
        }
        

        /// <summary>
        /// Handles auto migration on startup
        /// </summary>
        /// <param name="app">From configure method on startup</param>
        internal static void CreateMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<UserDBContext>())
                {
                    context.Database.Migrate();
                }
            }
        }

    }
}
