using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DomainModel.Models.Mapping
{
    public class tblRoomUserMap : EntityTypeConfiguration<tblRoomUser>
    {
        public tblRoomUserMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("tblRoomUser");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.RoomID).HasColumnName("RoomID");
            this.Property(t => t.UserID).HasColumnName("UserID");

            // Relationships
            this.HasRequired(t => t.tblRoom)
                .WithMany(t => t.tblRoomUsers)
                .HasForeignKey(d => d.RoomID);
            this.HasRequired(t => t.tblUser)
                .WithMany(t => t.tblRoomUsers)
                .HasForeignKey(d => d.UserID);

        }
    }
}
