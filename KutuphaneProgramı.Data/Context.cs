﻿using KutuphaneProgramı.Data.Migrations;
using KutuphaneProgrami.Data.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace KutuphaneProgramı.Data
{
    public class Context:DbContext
    {
        public Context():base("Context")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Configuration>("Context"));
        }

        public DbSet<Kategori> Kategoriler { get; set; }

        public DbSet<Kitap> Kitaplar { get; set; }

        public DbSet<OduncKitap> OduncKitaplar { get; set; }

        public DbSet<Uye> Uyeler { get; set; }

        public DbSet<Yazar> Yazarlar { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //s takısı kaldırma 
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();   
            base.OnModelCreating(modelBuilder);
        }
    }
}
