using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.BL.DTOs;
using CMS.DAL.Models.Entities;

namespace CMS.BL.Extensions.MappingExtensions
{
    public static class InterviewQuestionMappingExtensions
    {
        public static InterviewQuestion ToEntity(this CreateInterviewQuestionDto dto)
        {
            return new InterviewQuestion
            {
                TechnologyId = dto.TechnologyId,
                QuestionText = dto.QuestionText,
                DifficultyLevel = dto.DifficultyLevel,
                QuestionType = dto.QuestionType,
                SampleAnswer = dto.SampleAnswer
            };
        }

        public static GetInterviewQuestionDto ToGetDto(this InterviewQuestion entity)
        {
            return new GetInterviewQuestionDto
            {
                QuestionId = entity.QuestionId,
                TechnologyId = entity.TechnologyId,
                TechnologyName = entity.Technology?.TechnologyName,
                QuestionText = entity.QuestionText,
                DifficultyLevel = entity.DifficultyLevel,
                QuestionType = entity.QuestionType,
                SampleAnswer = entity.SampleAnswer
            };
        }

        public static void UpdateFromDto(this InterviewQuestion entity, CreateInterviewQuestionDto dto)
        {
            entity.TechnologyId = dto.TechnologyId;
            entity.QuestionText = dto.QuestionText;
            entity.DifficultyLevel = dto.DifficultyLevel;
            entity.QuestionType = dto.QuestionType;
            entity.SampleAnswer = dto.SampleAnswer;
        }
    }
}
