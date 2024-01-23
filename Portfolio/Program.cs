using Business.Abstract;
using Business.Concrete;
using Business.Validations;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete.TableModels;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PortfolioDbContext>().AddIdentity<User, Role>().AddEntityFrameworkStores<PortfolioDbContext>();

builder.Services.AddScoped<IPositionDAL, PositionEFDAL>();
builder.Services.AddScoped<IPositionService, PositionManager>();
builder.Services.AddScoped<IPersonDAL, PersonEFDAL>();
builder.Services.AddScoped<IPersonService, PersonManager>();
builder.Services.AddScoped<ISkillDAL, SkillEFDAL>();
builder.Services.AddScoped<ISkillService, SkillManager>();
builder.Services.AddScoped<IAboutSkillDAL, AboutSkillEFDAL>();
builder.Services.AddScoped<IAboutSkillService, AboutSkillManager>();
builder.Services.AddScoped<IWorkCategoryDAL, WorkCategoryEFDAL>();
builder.Services.AddScoped<IWorkCategoryService, WorkCategoryManager>();
builder.Services.AddScoped<IExperienceDAL, ExperienceEFDAL>();
builder.Services.AddScoped<IExperienceService, ExperienceManager>();
builder.Services.AddScoped<IMessageDAL, MessageEFDAL>();
builder.Services.AddScoped<IMessageService, MessageManager>();
builder.Services.AddScoped<IServiceDAL, ServiceEFDAL>();
builder.Services.AddScoped<IServiceService, ServiceManager>();
builder.Services.AddScoped<IPortfolioDAL, PortfolioEFDAL>();
builder.Services.AddScoped<IPortfolioService, PortfolioManager>();
builder.Services.AddScoped<IValidator<Position>, PositionValidator>();
builder.Services.AddScoped<IValidator<Person>, PersonValidator>();
builder.Services.AddScoped<IValidator<Skill>, SkillValidator>();
builder.Services.AddScoped<IValidator<AboutSkill>, AboutSkillValidator>();
builder.Services.AddScoped<IValidator<WorkCategory>, WorkCategoryValidator>();
builder.Services.AddScoped<IValidator<Experience>, ExperienceValidator>();
builder.Services.AddScoped<IValidator<Message>, MessageValidator>();
builder.Services.AddScoped<IValidator<Service>, ServiceValidator>();
builder.Services.AddScoped<IValidator<Portfoli>, PortfolioValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();



app.UseEndpoints(endpoints => {
    endpoints.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
