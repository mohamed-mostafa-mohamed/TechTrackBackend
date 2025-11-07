using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BL.DTOs
{
    public class TechnologyGetDto
    {
        public int TechnologyId { get; set; }
        public string TechnologyName { get; set; }
        public string? Description { get; set; }
        public string? VideoUrl { get; set; }
        public int TrackId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
