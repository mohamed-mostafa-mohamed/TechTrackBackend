using System.ComponentModel.DataAnnotations;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BL.DTOs
{
    public class TrackPostDto
    {
        [Required, MaxLength(200)]
        public string TrackName { get; set; }

        public string? Description { get; set; }

        [MaxLength(50)]
        public string? DifficultyLevel { get; set; }

        [Range(1, int.MaxValue)]
        public int EstimatedDuration { get; set; }

        [Required]
        public int SubCategoryId { get; set; }
    }
}
