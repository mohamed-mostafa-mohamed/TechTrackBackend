using CMS.BL.Constants;
using CMS.BL.DTOs;
using CMS.BL.Extensions.MappingExtensions;
using CMS.DAL.Repo.interviewquestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.BL.Service.interviewquestion
{
    public class InterviewQuestionService : IInterviewQuestionService
    {
        private readonly IInterviewQuestionRepository _repo;

        public InterviewQuestionService(IInterviewQuestionRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<GetInterviewQuestionDto>> GetAllAsync()
        {
            try
            {
                var list = await _repo.GetAllAsync();
                return list.Select(q => q.ToGetDto());
            }
            catch (Exception)
            {
                throw new ApplicationException(string.Format(ErrorMessages.GetAllFailed, EntityNames.InterviewQuestion));
            }
        }

        public async Task<GetInterviewQuestionDto?> GetByIdAsync(int id)
        {
            try
            {
                var q = await _repo.GetByIdAsync(id);
                if (q == null)
                    throw new ApplicationException(string.Format(ErrorMessages.NotFound, EntityNames.InterviewQuestion, id));

                return q.ToGetDto();
            }
            catch (Exception)
            {
                throw new ApplicationException(string.Format(ErrorMessages.GetByIdFailed, EntityNames.InterviewQuestion, id));
            }
        }

        public async Task<GetInterviewQuestionDto> CreateAsync(CreateInterviewQuestionDto dto)
        {
            try
            {
                var entity = dto.ToEntity();
                var created = await _repo.AddAsync(entity);
                return created.ToGetDto();
            }
            catch (Exception)
            {
                throw new ApplicationException(string.Format(ErrorMessages.CreateFailed, EntityNames.InterviewQuestion));
            }
        }

        public async Task<GetInterviewQuestionDto?> UpdateAsync(int id, CreateInterviewQuestionDto dto)
        {
            try
            {
                var existing = await _repo.GetByIdAsync(id);
                if (existing == null)
                    throw new ApplicationException(string.Format(ErrorMessages.NotFound, EntityNames.InterviewQuestion, id));

                existing.UpdateFromDto(dto);
                var updated = await _repo.UpdateAsync(existing);
                return updated.ToGetDto();
            }
            catch (Exception)
            {
                throw new ApplicationException(string.Format(ErrorMessages.UpdateFailed, EntityNames.InterviewQuestion, id));
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var deleted = await _repo.DeleteAsync(id);
                if (!deleted)
                    throw new ApplicationException(string.Format(ErrorMessages.NotFound, EntityNames.InterviewQuestion, id));

                return deleted;
            }
            catch (Exception)
            {
                throw new ApplicationException(string.Format(ErrorMessages.DeleteFailed, EntityNames.InterviewQuestion, id));
            }
        }
    }
}
