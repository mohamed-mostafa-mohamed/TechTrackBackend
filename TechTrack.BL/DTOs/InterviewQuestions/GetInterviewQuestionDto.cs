using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BL.DTOs
{
    public class GetInterviewQuestionDto
    {
        public int QuestionId { get; set; }
        public int TechnologyId { get; set; }
        public string? TechnologyName { get; set; }
        public string? QuestionText { get; set; }
        public string? DifficultyLevel { get; set; }
        public string? QuestionType { get; set; }
        public string? SampleAnswer { get; set; }
    }
}