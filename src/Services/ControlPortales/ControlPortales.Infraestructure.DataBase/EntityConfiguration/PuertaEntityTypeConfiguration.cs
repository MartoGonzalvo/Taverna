using ControlPortales.Domain.AggregatesModel.PuertaAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControlPortales.Infraestructure.DataBase.EntityConfiguration
{
    public class PuertaEntityTypeConfiguration : IEntityTypeConfiguration<Puerta>
    {
        public void Configure(EntityTypeBuilder<Puerta> builder)
        {
            builder.ToContainer("PuertasContainer");
            builder.HasPartitionKey(nameof(Puerta.PuertaName));

            //#region ETag
            //modelBuilder.Entity<Order>()
            //    .UseETagConcurrency();
            //#endregion

            //#region PropertyNames
            //modelBuilder.Entity<Order>().OwnsOne(
            //    o => o.ShippingAddress,
            //    sa =>
            //    {
            //        sa.ToJsonProperty("Address");
            //        sa.Property(p => p.Street).ToJsonProperty("ShipsToStreet");
            //        sa.Property(p => p.City).ToJsonProperty("ShipsToCity");
            //    });
            //#endregion

            //#region OwnsMany
            //modelBuilder.Entity<Distributor>().OwnsMany(p => p.ShippingCenters);
            //#endregion

            //#region ETagProperty
            //modelBuilder.Entity<Distributor>()
            //    .Property(d => d.ETag)
            //    .IsETagConcurrency();
            //#endregion
        }
    }
}
