using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quarantine.Core.Models;

namespace Quarantine.Data.EntityConfiguration
{
    public class BookEntityConfiguration: IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id)
                .ValueGeneratedOnAdd();
        }
    }
}