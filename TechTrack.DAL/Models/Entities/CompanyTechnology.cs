using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.Models.Entities
{
    public class CompanyTechnology
    {
        [Key]
        public int CompanyTechnologyId { get; set; }

        public int CompanyId { get; set; }
        public int TechnologyId { get; set; }

        // Optional additional data in junction table
        public string? UsageLevel { get; set; } // e.g. primary, secondary
        public string? Notes { get; set; }

        // 🔗 Navigation properties
        public Company? Company { get; set; }
        public Technology? Technology { get; set; }
    }

}
