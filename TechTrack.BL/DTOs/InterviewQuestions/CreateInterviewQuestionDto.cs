using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BL.DTOs
{
    public class CreateInterviewQuestionDto
    {
        public int TechnologyId { get; set; }
        public string QuestionText { get; set; } = string.Empty;
        public string? DifficultyLevel { get; set; }
        public string? QuestionType { get; set; }
        public string? SampleAnswer { get; set; }
    }
}