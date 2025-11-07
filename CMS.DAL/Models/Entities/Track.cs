using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.Models.Entities
{
    public class Track
    {
        public int TrackId { get; set; }

        // 🔗 Foreign key to SubCategory
        public int SubCategoryId { get; set; }

        // EF creates relationship automatically (1 SubCategory → many Tracks)
        public SubCategory? SubCategory { get; set; }

        // 🔗 One Track → Many Technologies
        public ICollection<Technology>? Technologies { get; set; }

        public string? TrackName { get; set; }
        public string? Description { get; set; }
        public string? DifficultyLevel { get; set; }
        public int EstimatedDuration { get; set; } // in hours
    }
}
