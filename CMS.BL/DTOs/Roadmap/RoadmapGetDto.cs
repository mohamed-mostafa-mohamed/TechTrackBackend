using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BL.DTOs
{
    public class RoadmapGetDto
    {
        public int RoadmapId { get; set; }
        public int TrackId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public List<RoadmapStepGetDto>? RoadmapSteps { get; set; }
    }

}
