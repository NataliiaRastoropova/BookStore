using System;
using System.Collections.Generic;
using System.Text;
using BookStore.DB.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DB
{
    public partial class BookStoreContext : DbContext
    {
        public virtual DbSet<Author> Authors { get; set; }

        private void AuthorsConfiguration(ModelBuilder builder)
        {
            builder.Entity<Author>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.PhoneNumber).HasMaxLength(20);
                entity.Property(e => e.Birthday);
            });
        }
    }
}
