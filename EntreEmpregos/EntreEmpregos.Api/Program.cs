using System.Text.Json.Serialization;
using EntreEmpregos.Domain.Interfaces;
using EntreEmpregos.Repository.Context;
using EntreEmpregos.Repository.Repositories;
using EntreEmpregos.Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.Converters.Add
        (new JsonStringEnumConverter()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration["API_EE_CONNSTRING"];
builder.Services.AddDbContextPool<AppDbContext>(opt =>
    opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


builder.Services.AddScoped<IJobRegionRepository, JobRegionRepository>();
builder.Services.AddScoped<IJobRegionService, JobRegionService>();
builder.Services.AddScoped<IJobLevelRepository, JobLevelRepository>();
builder.Services.AddScoped<IJobLevelService, JobLevelService>();
builder.Services.AddScoped<IEmployerService, EmployerService>();
builder.Services.AddScoped<IEmployerRepository, EmployerRepository>();
builder.Services.AddScoped<ITransGroupService, TransGroupService>();
builder.Services.AddScoped<ITransGroupRepository, TransGroupRepository>();
builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<IJobRepository, JobRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserLoginService, UserLoginService>();
builder.Services.AddTransient<TokenService>();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        policyBuilder =>
            policyBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");
app.UseAuthorization();


app.MapControllers();

app.Run();