using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesStorageShared.Models
{
   public class AzureActiveDirectorySettings
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string TenantId { get; set; }
        public string Expire { get; set; }
        public string UrlInstanceLogin { get; set; }
    }
}
