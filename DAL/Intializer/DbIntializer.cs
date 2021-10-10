using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DbIntializer : CreateDatabaseIfNotExists<SpeakerModel>
    {
        protected override void Seed(SpeakerModel context)
        {
            base.Seed(context);

            //Create a test account in the database
            Account user1 = context.Accounts.Add(new Account { Login = "Admin", Password = "qwe123", Mail = "roma.pomyanovskiy@gmail.com", Phone = "+380977852315", Name = "Roma", Surname = "Pomianovskiy", PublishDate = Convert.ToDateTime("2003-1-31") });
            context.SaveChanges();
        }
    }
}
