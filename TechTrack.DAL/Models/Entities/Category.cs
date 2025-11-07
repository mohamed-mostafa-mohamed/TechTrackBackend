using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.Models.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required, MaxLength(200)]
        public string CategoryName { get; set; }

        public string Description { get; set; }

        // 🔗 One Category → Many SubCategories
        // EF Core sees ICollection<SubCategory> and automatically creates
        // a foreign key `CategoryId` in the SubCategory table.
        public ICollection<SubCategory> SubCategories { get; set; }
    }
}
