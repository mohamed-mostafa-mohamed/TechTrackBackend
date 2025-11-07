using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BL.DTOs
{
    public class SubCategoryGetDto
    {
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public string Description { get; set; }
        public string DifficultyLevel { get; set; }
        public int EstimatedDuration { get; set; }

        // Optional: Include Category info
        public int CategoryId { get; set; }
    }
}