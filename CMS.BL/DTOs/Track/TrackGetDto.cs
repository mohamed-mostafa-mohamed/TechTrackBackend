using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BL.DTOs
{
    public class TrackGetDto
    {
        public int TrackId { get; set; }
        public string? TrackName { get; set; }
        public string? Description { get; set; }
        public string? DifficultyLevel { get; set; }
        public int EstimatedDuration { get; set; }
        public int SubCategoryId { get; set; }
    }
}
