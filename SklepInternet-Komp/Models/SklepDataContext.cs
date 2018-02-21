using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SklepInternet_Komp.Models
{
    public class SklepDataContext : DbContext
    {
        public SklepDataContext() : base()
        {
        }

        // "name=nazwa_połączenia"
        public SklepDataContext(String ConnectionString) : base(ConnectionString)
        {

        }

        //Tabele w bazie danych
        public DbSet<Producent> Producents { get; set; }
        public DbSet<Sprzet> Sprzets { get; set; }
        public DbSet<TypSprzetu> TypSprzetus { get; set; }
    }
}