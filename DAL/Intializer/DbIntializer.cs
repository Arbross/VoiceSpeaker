using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DbIntializer : CreateDatabaseIfNotExists<VoiceSpeakerModel>
    {
        protected override void Seed(VoiceSpeakerModel context)
        {
            base.Seed(context);

            //Create a test account in the database
            Accaunt user1 = context.Accaunts.Add(new Accaunt { Login = "Admin", Password = "qwe123", Mail = "roma.pomyanovskiy@gmail.com", Phone = "+380977852315", Name = "Roma", Surname = "Pomianovskiy", PublishDate = Convert.ToDateTime("2003-1-31") });
            context.SaveChanges();
        }
    }
}
