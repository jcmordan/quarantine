using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quarantine.Core.Models;

namespace Quarantine.Data.EntityConfiguration
{
    public class AuthorEntityConfiguration: IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id)
                .ValueGeneratedOnAdd();

            builder.HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}