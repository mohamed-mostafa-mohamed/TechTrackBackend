using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BL.DTOs
{
    public class GetCompanyTechnologyDto
    {
        public int CompanyTechnologyId { get; set; }
        public int CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public int TechnologyId { get; set; }
        public string? TechnologyName { get; set; }
        public string? UsageLevel { get; set; }
        public string? Notes { get; set; }
    }
}