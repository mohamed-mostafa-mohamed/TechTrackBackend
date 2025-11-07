using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BL.DTOs
{
    public class RoadmapStepGetDto
    {
        public int RoadmapStepId { get; set; }
        public int RoadmapId { get; set; }
        public string? StepTitle { get; set; }
        public string? StepDescription { get; set; }
        public int StepOrder { get; set; }
    }
}
