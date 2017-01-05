using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace E_Ticaret.Models.Managers
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Kullanici> Kullanici { get; set; }

        public DatabaseContext()
        {
            Database.SetInitializer(new VeritabaniOlusturucu());
        }
    }

    public class VeritabaniOlusturucu : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            for (int i = 0; i < 120; i++)
            {
                Kullanici kullanici = new Kullanici();
                kullanici.KullaniciAdi = FakeData.NameData.GetFirstName();
                kullanici.Sifre = FakeData.NumberData.GetNumber(10000, 99999).ToString();

                context.Kullanici.Add(kullanici);
            }

            context.SaveChanges();

        }


    }
}