using CMS.DAL.Models.Entities;
using CMS.DAL.Repo.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CMS.DAL.Models.Data;

namespace CMS.DAL.Repo.interviewquestion
{
    public class InterviewQuestionRepository : IGeneric<InterviewQuestion>, IInterviewQuestionRepository
    {
        private readonly ApplicationDbContext _context;

        public InterviewQuestionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InterviewQuestion>> GetAllAsync()
        {
            return await _context.InterviewQuestions
                .Include(q => q.Technology)
                .ToListAsync();
        }

        public async Task<InterviewQuestion?> GetByIdAsync(int id)
        {
            return await _context.InterviewQuestions
                .Include(q => q.Technology)
                .FirstOrDefaultAsync(q => q.QuestionId == id);
        }

        public async Task<InterviewQuestion> AddAsync(InterviewQuestion question)
        {
            _context.InterviewQuestions.Add(question);
            await _context.SaveChangesAsync();
            return question;
        }

        public async Task<InterviewQuestion> UpdateAsync(InterviewQuestion question)
        {
            _context.InterviewQuestions.Update(question);
            await _context.SaveChangesAsync();
            return question;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.InterviewQuestions.FindAsync(id);
            _context.InterviewQuestions.Remove(entity!);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
