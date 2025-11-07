using System.ComponentModel.DataAnnotations;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BL.DTOs
{
    public class TechnologyPostDto
    {
        [Required, MaxLength(200)]
        public string TechnologyName { get; set; }

        public string? Description { get; set; }

        [MaxLength(500)]
        public string? VideoUrl { get; set; }

        [Required]
        public int TrackId { get; set; }
    }
}
