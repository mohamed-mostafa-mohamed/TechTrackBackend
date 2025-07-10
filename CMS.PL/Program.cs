
using CMS.DAL.Models;
using CMS.DAL.Models.Data;
using CMS.DAL.Models.Entities;
using CMS.DAL.Repo;
using CMS.BL.Service;
using CMS.DAL.Repo.SenderInfoRepo;
using CMS.BL.Service.SenderInfoService;
using CMS.BL.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Migrations;
using CMS.BL.Service.OrderInfoService;
using CMS.DAL.Repo.OrderInfoRepo;
using CMS.BL.Service.SendEmailService;




namespace CMS.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer
           (builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<ISenderInfoService, SenderInfoService>();
            builder.Services.AddScoped<ISenderInfoRepo, SenderInfoRepo>();
            builder.Services.AddScoped<IOrderInfoService,OrderInfoService>();
            builder.Services.AddScoped<IOrderInfoRepo, OrderInfoRepo>();
            builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
            builder.Services.AddTransient<ISendEmailService, SendEmailService>();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
