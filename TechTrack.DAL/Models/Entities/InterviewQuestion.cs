using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.Models.Entities
{
    public class InterviewQuestion
    {
        [Key]
        public int QuestionId { get; set; }

        public int TechnologyId { get; set; } // 🔗 Foreign key

        // EF Core creates: One Technology → Many InterviewQuestions
        public Technology? Technology { get; set; }

        public string? QuestionText { get; set; }
        public string? DifficultyLevel { get; set; }
        public string? QuestionType { get; set; }
        public string? SampleAnswer { get; set; }
    }
}
