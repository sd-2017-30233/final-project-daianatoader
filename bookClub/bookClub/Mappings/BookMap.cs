using bookClub.Models;
using System.Data.Entity.ModelConfiguration;

namespace bookClub.Mappings
{
    internal class BookMap : EntityTypeConfiguration<Book>
    {
        public BookMap()
        {
            ToTable("Books");
            HasKey(m => m.ID);
            Property(m => m.Name);
            Property(m => m.Description);
            Property(m => m.Genre);
            Property(m => m.AuthorID);
            HasMany(m => m.Quotes);
            HasMany(m => m.Reviews);
            HasRequired(m => m.Author).WithMany().HasForeignKey(m => m.AuthorID);
        }
    }
}
