using BookStore.DB.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DB
{
    public partial class BookStoreContext:DbContext
    {
        public virtual DbSet<Publisher> Publishers { get; set; }

        private void PublishersConfiguration(ModelBuilder builder)
        {
            builder.Entity<Publisher>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
                entity.Property(e => e.City).HasMaxLength(50);
                entity.Property(e => e.Country).HasMaxLength(50);
            });
        }
    }
}
