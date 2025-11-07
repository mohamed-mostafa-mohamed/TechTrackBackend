using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BL.DTOs
{
    public class CreateCompanyTechnologyDto
    {
        public int CompanyId { get; set; }
        public int TechnologyId { get; set; }
        public string? UsageLevel { get; set; }
        public string? Notes { get; set; }
    }
}