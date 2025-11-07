using CMS.BL.DTOs;
using CMS.DAL.Models.Entities;
using CMS.DAL.Repo.interviewquestion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace CMS.BL.Service.interviewquestion
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IInterviewQuestionService
    {
        Task<IEnumerable<GetInterviewQuestionDto>> GetAllAsync();
        Task<GetInterviewQuestionDto?> GetByIdAsync(int id);
        Task<GetInterviewQuestionDto> CreateAsync(CreateInterviewQuestionDto dto);
        Task<GetInterviewQuestionDto?> UpdateAsync(int id, CreateInterviewQuestionDto dto);
        Task<bool> DeleteAsync(int id);
    }
}