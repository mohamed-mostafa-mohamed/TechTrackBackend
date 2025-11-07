using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.Models.Entities
{
    public class SubCategory
    {
        public int SubCategoryId { get; set; }

        // 🔗 Foreign key linking to Category
        public int CategoryId { get; set; }

        // EF Core uses this navigation property to complete the relationship
        public Category? Category { get; set; }

        // 🔗 One SubCategory → Many Tracks
        public ICollection<Track>? Tracks { get; set; }

        public string? SubCategoryName { get; set; }
        public string? Description { get; set; }
        public string? DifficultyLevel { get; set; }
        public int EstimatedDuration { get; set; }
    }
}
