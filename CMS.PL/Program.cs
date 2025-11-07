using CMS.DAL.Models.Data;
using CMS.DAL.Seed;
using CMS.DAL.Repo;
using CMS.BL.Service.track;
using CMS.BL.Service.technology;
using CMS.BL.Service.subcategory;
using CMS.BL.Service.roadmastep;
using CMS.BL.Service.roadmap;
using CMS.BL.Service.interviewquestion;
using CMS.BL.Service.companytech;
using CMS.BL.Service.company;
using CMS.BL.Service.category;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using CMS.DAL.Repo.category;
using CMS.DAL.Repo.companytech;
using CMS.DAL.Repo.compnay;
using CMS.DAL.Repo.GenericRepo;
using CMS.DAL.Repo.interviewquestion;
using CMS.DAL.Repo.roadmap;
using CMS.DAL.Repo.roadmapstep;
using CMS.DAL.Repo.subcategory;
using CMS.DAL.Repo.technology;
using CMS.DAL.Repo.track;

namespace CMS.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // -------------------- Database --------------------
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // -------------------- Dependency Injection --------------------
            builder.Services.AddScoped(typeof(IGeneric<>), typeof(Generic<>));

            // Category
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();

            // SubCategory
            builder.Services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
            builder.Services.AddScoped<ISubCategoryService, SubCategoryService>();

            // Track
            builder.Services.AddScoped<ITrackRepository, TrackRepository>();
            builder.Services.AddScoped<ITrackService, TrackService>();

            // Technology
            builder.Services.AddScoped<ITechnologyRepository, TechnologyRepository>();
            builder.Services.AddScoped<ITechnologyService, TechnologyService>();

            // Roadmap
            builder.Services.AddScoped<IRoadmapRepository, RoadmapRepository>();
            builder.Services.AddScoped<IRoadmapService, RoadmapService>();

            // Roadmap Step
            builder.Services.AddScoped<IRoadmapStepRepository, RoadmapStepRepository>();
            builder.Services.AddScoped<IRoadmapStepService, RoadmapStepService>();

            // Company
            builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
            builder.Services.AddScoped<ICompanyService, CompanyService>();

            // CompanyTechnology
            builder.Services.AddScoped<ICompanyTechnologyRepository, CompanyTechnologyRepository>();
            builder.Services.AddScoped<ICompanyTechnologyService, CompanyTechnologyService>();

            // Interview Questions
            builder.Services.AddScoped<IInterviewQuestionRepository, InterviewQuestionRepository>();
            builder.Services.AddScoped<IInterviewQuestionService, InterviewQuestionService>();

            //DbSeeder
            builder.Services.AddScoped<DbSeeder>();


            // -------------------- Controllers --------------------
            builder.Services.AddControllers();

            // -------------------- Swagger --------------------
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "TechPathNavigator API",
                    Version = "v1",
                    Description = "API for managing categories, tracks, and technologies"
                });
            });

            // -------------------- CORS --------------------
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            var app = builder.Build();

            // -------------------- Middleware --------------------
            app.UseCors("AllowAll");
            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();

            // -------------------- Swagger --------------------
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TechPathNavigator API V1");
                c.RoutePrefix = "swagger"; // Access Swagger at /swagger
            });

            // -------------------- Seed Database (Dev Only) --------------------
            if (app.Environment.IsDevelopment())
            {
                using (var scope = app.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var context = services.GetRequiredService<ApplicationDbContext>();

                    var seeder = services.GetRequiredService<DbSeeder>();
                    seeder.SeedAsync().GetAwaiter().GetResult();
                }
            }

            app.Run();
        }
    }
}
