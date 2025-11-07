using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.Models.Entities
{
    public class Technology
    {
        [Key]
        public int TechnologyId { get; set; }

        [Required]
        public int TrackId { get; set; } // 🔗 Foreign key to Track

        // EF Core detects: One Track → Many Technologies
        public Track Track { get; set; }

        [Required, MaxLength(200)]
        public string TechnologyName { get; set; }

        public string Description { get; set; }
        [MaxLength(500)]
        public string? VideoUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

}
