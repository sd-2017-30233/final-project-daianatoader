using bookClub.Models;
using System.Data.Entity.ModelConfiguration;

namespace bookClub.Mappings
{
    internal class AuthorMap : EntityTypeConfiguration<Author>
    {
        public AuthorMap()
        {
            ToTable("Authors");
            HasKey(m => m.ID);
            Property(m => m.Name);
        }
    }
}