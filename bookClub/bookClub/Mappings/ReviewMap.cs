using bookClub.Models;
using System.Data.Entity.ModelConfiguration;

namespace bookClub.Mappings
{
    internal class ReviewMap : EntityTypeConfiguration<Review>
    {
        public ReviewMap()
        {
            ToTable("Reviews");
            HasKey(m => m.ID);
            Property(m => m.Rating);
            Property(m => m.Text);
            Property(m => m.AccountID);
            Property(m => m.BookID);
            HasRequired(m => m.Book).WithMany().HasForeignKey(m => m.BookID);
            HasRequired(m => m.Account).WithMany().HasForeignKey(m => m.AccountID);
        }
    }
}