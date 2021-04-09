using Data.Concrete.EfCore.Mapping;
using DTOs.Concrete.YaziDtoS;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Concrete.EfCore.Context
{
    public class BlogContext : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-NLFNOIV\SQLEXPRESS; Database=myDataBase; User Id=mustafa;Password=78235;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AppRoleMap());
            builder.ApplyConfiguration(new AppUserMap());
            builder.ApplyConfiguration(new KategoriMap());
            builder.ApplyConfiguration(new TagMap());
            builder.ApplyConfiguration(new YaziKategoriMap());
            builder.ApplyConfiguration(new YaziMap());
            builder.ApplyConfiguration(new YaziTagMap());
            builder.ApplyConfiguration(new YaziYorumMap());
            builder.ApplyConfiguration(new YorumMap());
            base.OnModelCreating(builder);
        }

        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Kategori> Kategoris{ get; set; }
        public DbSet<Tag> Tags{ get; set; }
        public DbSet<YaziKategori> YaziKategoris { get; set; }
        public DbSet<Yazi> Yazis { get; set; }
        public DbSet<YaziTag> YaziTags { get; set; }
        public DbSet<YaziYorum> YaziYorums { get; set; }
        public DbSet<Yorum> Yorums { get; set; }
    }
}
