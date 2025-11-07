using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.Models.Entities
{
    public class RoadmapStep
    {
        public int RoadmapStepId { get; set; }

        public int RoadmapId { get; set; } // 🔗 Foreign key

        // EF Core maps: One Roadmap → Many Steps
        public Roadmap? Roadmap { get; set; }

        public string? StepTitle { get; set; }
        public string? StepDescription { get; set; }
        public int StepOrder { get; set; }
    }
}
