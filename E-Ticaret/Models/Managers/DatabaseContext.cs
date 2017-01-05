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
                kullanici.KULLANICIADI = FakeData.NameData.GetFullName();
                kullanici.SIFRE = FakeData.NumberData.GetNumber(10000000, 99999999).ToString();
                kullanici.AD = FakeData.NameData.GetFirstName();
                kullanici.SOYAD = FakeData.NameData.GetSurname();
                kullanici.EPOSTA = FakeData.NetworkData.GetEmail();
                //kullanici.CEPTELEFONU = FakeData.PhoneNumberData.GetPhoneNumber();

                context.Kullanici.Add(kullanici);
            }

            context.SaveChanges();

        }


    }
}