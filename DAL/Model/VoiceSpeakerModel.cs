using System;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class VoiceSpeakerModel : DbContext
    {
        public VoiceSpeakerModel()
            : base("name=VoiceSpeakerModel")
        {
            Database.SetInitializer(new DbIntializer());
        }
        public DbSet<Accaunt> Accaunts { get; set; }
    }
}