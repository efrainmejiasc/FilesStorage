using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesStorageModels.DataModels
{
    public class FilesStorageContext : DbContext
    {
        public FilesStorageContext(DbContextOptions<FilesStorageContext> options)
         : base(options)
        {
        }

        //public virtual DbSet<Roles> Roles { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer(EngineData.ConnectionDb);
        //    }

        //}
    }
}
