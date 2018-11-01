using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DomainModel.Models.Mapping
{
    public class tblUserMap : EntityTypeConfiguration<tblUser>
    {
        public tblUserMap()
        {
            // Primary Key
            this.HasKey(t => t.user_id);

            // Properties
            this.Property(t => t.username)
                .HasMaxLength(50);

            this.Property(t => t.password)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("tblUser");
            this.Property(t => t.user_id).HasColumnName("user_id");
            this.Property(t => t.role_id).HasColumnName("role_id");
            this.Property(t => t.username).HasColumnName("username");
            this.Property(t => t.password).HasColumnName("password");
            this.Property(t => t.status).HasColumnName("status");
        }
    }
}
