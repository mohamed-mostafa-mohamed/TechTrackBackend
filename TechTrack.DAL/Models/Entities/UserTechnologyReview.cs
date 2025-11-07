using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.Models.Entities
{
    public class UserTechnologyReview
    {
        [Key]
        public int ReviewId { get; set; }

        public int UserId { get; set; } // 🔗 FK
        public int TechnologyId { get; set; } // 🔗 FK

        public int Rating { get; set; }
        public string? ReviewText { get; set; }

        // Navigation
        public Technology? Technology { get; set; }
        public User? User { get; set; }
    }

}
