using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DomainModel.Models.Mapping
{
    public class tblRoomMap : EntityTypeConfiguration<tblRoom>
    {
        public tblRoomMap()
        {
            // Primary Key
            this.HasKey(t => t.RoomID);

            // Properties
            this.Property(t => t.RoomName)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.Link)
                .IsFixedLength()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("tblRoom");
            this.Property(t => t.RoomID).HasColumnName("RoomID");
            this.Property(t => t.RoomName).HasColumnName("RoomName");
            this.Property(t => t.Picture).HasColumnName("Picture");
            this.Property(t => t.Link).HasColumnName("Link");
        }
    }
}
