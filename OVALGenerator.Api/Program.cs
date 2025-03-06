using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OVALGenerator.Application.Clients.Implementations;
using OVALGenerator.Application.Clients.Interfaces;
using OVALGenerator.Application.MappingProfile;
using OVALGenerator.Application.Repositoryes.Implementations;
using OVALGenerator.Application.Repositoryes.Interfaces;
using OVALGenerator.Application.Services.Implementations;
using OVALGenerator.Application.Services.Interfaces;
using OVALGenerator.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OvalDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpClient<ICveApiClient, CveApiClient>();
builder.Services.AddScoped<IOvalReportRepository, OvalReportRepository>();
builder.Services.AddScoped<IOvalGeneratorService, OvalGeneratorService>();

builder.Services.AddAutoMapper(typeof(CveMappingProfile));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "OVAL Generator API", Version = "v1" });
    c.EnableAnnotations();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CalendarReminder API V1");
        c.RoutePrefix = string.Empty;
    });
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<OvalDbContext>();
    dbContext.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();