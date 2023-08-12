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

        public virtual DbSet<UsersApp> UsersApp { get; set; }
        public virtual DbSet<UsersRol> UsersRol{ get; set; }
        public virtual DbSet<FilesCategorie> FilesCategorie { get; set; }

    }
}
