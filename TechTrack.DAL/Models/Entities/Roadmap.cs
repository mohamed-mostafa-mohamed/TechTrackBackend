using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.Models.Entities
{
    public class Roadmap
    {
        public int RoadmapId { get; set; }

        public int TrackId { get; set; } // 🔗 Foreign key to Track
        public string? Title { get; set; }
        public string? Description { get; set; }

        // EF Core creates: One Track → Many Roadmaps
        public Track? Track { get; set; }

        // 🔗 One Roadmap → Many RoadmapSteps
        public ICollection<RoadmapStep>? RoadmapSteps { get; set; }
    }
}
