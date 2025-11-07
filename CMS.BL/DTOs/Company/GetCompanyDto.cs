using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BL.DTOs
{
    public class GetCompanyDto
    {
        public int CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public string? Industry { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? Description { get; set; }
    }
}
