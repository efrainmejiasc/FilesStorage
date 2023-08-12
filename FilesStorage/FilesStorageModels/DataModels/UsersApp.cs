using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesStorageModels.DataModels
{
    [Table("UsersApp")]
    public class UsersApp
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1, TypeName = "INT")]
        public int Id { get; set; }

        [Column(Order = 2, TypeName = "INT")]
        public int IdRol { get; set; }

        [Column(Order = 3, TypeName = "VARCHAR(50)")]
        public string Nombre { get; set; }

        [Column(Order = 4, TypeName = "VARCHAR(50)")]
        public string Apellido { get; set; }

        [Column(Order = 5, TypeName = "VARCHAR(50)")]
        public string Username { get; set; }

        [Column(Order = 6, TypeName = "VARCHAR(100)")]
        public string Password { get; set; }

        [Key]
        [Column(Order = 8, TypeName = "VARCHAR(50)")]
        public string Email { get; set; }

        [Column(Order = 9, TypeName = "DATETIME")]
        public DateTime Fecha { get; set; }

        [Column(Order = 10, TypeName = "BIT")]
        public bool Activo { get; set; }

    }
}
