using bookClub.Models;
using System.Data.Entity.ModelConfiguration;

namespace bookClub.Mappings
{
    internal class AccountMap : EntityTypeConfiguration<Account>
    {
        public AccountMap()
        {
            ToTable("Accounts");
            HasKey(m => m.ID);
            Property(m => m.Name);
            Property(m => m.Username);
            Property(m => m.Password);
            Property(m => m.Type);
            HasMany(m => m.Reviews);
            HasMany(m => m.Books).WithMany().Map(m => m.MapLeftKey("AccountID").MapRightKey("BookID").ToTable("Accounts_Books"));
        }
    }
}