using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using DomainModel.Models.Mapping;

namespace DomainModel.Models
{
    public partial class ChatAppContext : DbContext
    {
        static ChatAppContext()
        {
            Database.SetInitializer<ChatAppContext>(null);
        }

        public ChatAppContext()
            : base("Name=ChatAppContext")
        {
        }

        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<tblMessage> tblMessages { get; set; }
        public DbSet<tblRoom> tblRooms { get; set; }
        public DbSet<tblRoomUser> tblRoomUsers { get; set; }
        public DbSet<tblUser> tblUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new tblMessageMap());
            modelBuilder.Configurations.Add(new tblRoomMap());
            modelBuilder.Configurations.Add(new tblRoomUserMap());
            modelBuilder.Configurations.Add(new tblUserMap());
        }
    }
}
