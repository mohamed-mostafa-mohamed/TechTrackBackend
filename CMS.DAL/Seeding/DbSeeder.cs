using CMS.DAL.Models.Data;
using CMS.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CMS.DAL.Seed
{
    public class DbSeeder
    {
        private readonly ApplicationDbContext _context;
        private readonly string _seedDataPath;

        public DbSeeder(ApplicationDbContext context)
        {
            _context = context;
            _seedDataPath = Path.Combine(AppContext.BaseDirectory, "jsonFiles"); 
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            await SeedCategoriesAsync();
            await SeedSubCategoriesAsync();
            await SeedTracksAsync();
            await SeedTechnologiesAsync();
            await SeedRoadmapsAsync();
            await SeedRoadmapStepsAsync();
            await SeedCompaniesAsync();
            await SeedCompanyTechnologiesAsync();
            await SeedInterviewQuestionsAsync();
        }

        private async Task SeedCategoriesAsync()
        {
            if (await _context.Categories.AnyAsync()) return;

            string file = Path.Combine(_seedDataPath, "categories.json");
            var categories = JsonSerializer.Deserialize<List<Category>>(await File.ReadAllTextAsync(file));
            if (categories != null)
            {
                await _context.Categories.AddRangeAsync(categories);
                await _context.SaveChangesAsync();
            }
        }

        private async Task SeedSubCategoriesAsync()
        {
            if (await _context.SubCategories.AnyAsync()) return;

            string file = Path.Combine(_seedDataPath, "subcategories.json");
            var subCategories = JsonSerializer.Deserialize<List<SubCategory>>(await File.ReadAllTextAsync(file));
            if (subCategories != null)
            {
                await _context.SubCategories.AddRangeAsync(subCategories);
                await _context.SaveChangesAsync();
            }
        }

        private async Task SeedTracksAsync()
        {
            if (await _context.Tracks.AnyAsync()) return;

            string file = Path.Combine(_seedDataPath, "tracks.json");
            var tracks = JsonSerializer.Deserialize<List<Track>>(await File.ReadAllTextAsync(file));
            if (tracks != null)
            {
                await _context.Tracks.AddRangeAsync(tracks);
                await _context.SaveChangesAsync();
            }
        }

        private async Task SeedTechnologiesAsync()
        {
            if (await _context.Technologies.AnyAsync()) return;

            string file = Path.Combine(_seedDataPath, "technologies.json");
            var technologies = JsonSerializer.Deserialize<List<Technology>>(await File.ReadAllTextAsync(file));
            if (technologies != null)
            {
                await _context.Technologies.AddRangeAsync(technologies);
                await _context.SaveChangesAsync();
            }
        }

        private async Task SeedRoadmapsAsync()
        {
            if (await _context.Roadmaps.AnyAsync()) return;

            string file = Path.Combine(_seedDataPath, "roadmaps.json");
            var roadmaps = JsonSerializer.Deserialize<List<Roadmap>>(await File.ReadAllTextAsync(file));
            if (roadmaps != null)
            {
                await _context.Roadmaps.AddRangeAsync(roadmaps);
                await _context.SaveChangesAsync();
            }
        }

        private async Task SeedRoadmapStepsAsync()
        {
            if (await _context.RoadmapSteps.AnyAsync()) return;

            string file = Path.Combine(_seedDataPath, "roadmapsteps.json");
            var roadmapSteps = JsonSerializer.Deserialize<List<RoadmapStep>>(await File.ReadAllTextAsync(file));
            if (roadmapSteps != null)
            {
                await _context.RoadmapSteps.AddRangeAsync(roadmapSteps);
                await _context.SaveChangesAsync();
            }
        }

        private async Task SeedCompaniesAsync()
        {
            if (await _context.Companies.AnyAsync()) return;

            string file = Path.Combine(_seedDataPath, "companies.json");
            var companies = JsonSerializer.Deserialize<List<Company>>(await File.ReadAllTextAsync(file));
            if (companies != null)
            {
                await _context.Companies.AddRangeAsync(companies);
                await _context.SaveChangesAsync();
            }
        }

        private async Task SeedCompanyTechnologiesAsync()
        {
            if (await _context.CompanyTechnologies.AnyAsync()) return;

            string file = Path.Combine(_seedDataPath, "companytechnologies.json");
            var companyTechs = JsonSerializer.Deserialize<List<CompanyTechnology>>(await File.ReadAllTextAsync(file));
            if (companyTechs != null)
            {
                await _context.CompanyTechnologies.AddRangeAsync(companyTechs);
                await _context.SaveChangesAsync();
            }
        }

        private async Task SeedInterviewQuestionsAsync()
        {
            if (await _context.InterviewQuestions.AnyAsync()) return;

            string file = Path.Combine(_seedDataPath, "interviewquestions.json");
            var questions = JsonSerializer.Deserialize<List<InterviewQuestion>>(await File.ReadAllTextAsync(file));
            if (questions != null)
            {
                await _context.InterviewQuestions.AddRangeAsync(questions);
                await _context.SaveChangesAsync();
            }
        }
    }
}
