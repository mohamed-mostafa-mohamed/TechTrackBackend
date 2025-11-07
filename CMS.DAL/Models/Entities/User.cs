using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.Models.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }

        // 🔗 One User → Many Reviews
        public ICollection<UserTechnologyReview>? Reviews { get; set; }
    }
}
