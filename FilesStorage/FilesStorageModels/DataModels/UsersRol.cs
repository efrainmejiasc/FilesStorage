﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesStorageModels.DataModels
{
    [Table("UsersRol")]
    public class UsersRol
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1, TypeName = "INT")]
        public int Id { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "VARCHAR(50)")]
        public string Rol { get; set; }
    }
}
