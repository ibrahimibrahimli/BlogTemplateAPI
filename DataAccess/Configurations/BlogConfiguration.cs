using Core.DefaultValues;
using Entity.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DataAccess.Configurations
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.ToTable("Testimonials");

            builder.Property(x => x.Id)
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_SEED_VALUE, increment: 1);

            builder.Property(x => x.Title)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.AuthorName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.AuthorSurname)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.PhotoUrl)
                .HasMaxLength(200)
                .IsRequired();

            builder.HasIndex(x => x.AuthorName);

            builder.HasIndex(x => new { x.AuthorName, x.Deleted })
                .IsUnique()
                .HasDatabaseName("idx_CustomerName_Deleted");
        }
    }
}
