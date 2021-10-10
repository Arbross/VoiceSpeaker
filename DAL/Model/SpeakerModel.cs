using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public partial class SpeakerModel : DbContext
    {
        public SpeakerModel()
            : base("name=SpeakerModel")
        {
            Database.SetInitializer(new DbIntializer());
        }

        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
