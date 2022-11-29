using MyPortfolioWebsite.Services;
using MyPortfolioWebsite.Services.Resume;
using Microsoft.AspNetCore.Mvc;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
// Add services to fetch data from DB.
builder.Services.AddTransient<EducationService>();
builder.Services.AddTransient<HobbyInterestService>();
builder.Services.AddTransient<SkillService>();
builder.Services.AddTransient<WorkExperienceService>();
builder.Services.AddTransient<ArticleService>();
builder.Services.AddTransient<ProjectService>();
// Add controllers for REST APIs
builder.Services.AddControllers();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// User auth will not be used for this website.
//app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();