using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DomainModel.Models.Mapping
{
    public class tblMessageMap : EntityTypeConfiguration<tblMessage>
    {
        public tblMessageMap()
        {
            // Primary Key
            this.HasKey(t => t.message_id);

            // Properties
            // Table & Column Mappings
            this.ToTable("tblMessage");
            this.Property(t => t.message_id).HasColumnName("message_id");
            this.Property(t => t.user_id).HasColumnName("user_id");
            this.Property(t => t.receiver_id).HasColumnName("receiver_id");
            this.Property(t => t.message_text).HasColumnName("message_text");
            this.Property(t => t.date).HasColumnName("date");
            this.Property(t => t.type).HasColumnName("type");

            // Relationships
            this.HasOptional(t => t.tblUser)
                .WithMany(t => t.tblMessages)
                .HasForeignKey(d => d.user_id);

        }
    }
}
