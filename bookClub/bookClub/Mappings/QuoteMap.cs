using bookClub.Models;
using System.Data.Entity.ModelConfiguration;

namespace bookClub.Mappings
{
    internal class QuoteMap : EntityTypeConfiguration<Quote>
    {
        public QuoteMap()
        {
            ToTable("Quotes");
            HasKey(m => m.ID);
            Property(m => m.Text);
            Property(m => m.BookID);
            HasRequired(m => m.Book).WithMany().HasForeignKey(m => m.BookID);
        }
    }
}