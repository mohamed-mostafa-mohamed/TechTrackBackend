using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.Models.Entities
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        public string? CompanyName { get; set; }
        public string? Industry { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? Description { get; set; }

        // 🔗 Many-to-Many through CompanyTechnology
        public ICollection<CompanyTechnology>? CompanyTechnologies { get; set; }
    }
}
