using Asp.Versioning;
using Microsoft.OpenApi.Models;
using Students.APIServer.Extension;
using Students.DBCore.Contexts;
using Students.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<StudentContext, PgContext>();
builder.Services.AddSingleton<StudentContext, InMemoryContext>();
builder.Services.AddSwaggerGen(options =>
{
    var basePath = AppContext.BaseDirectory;

    var xmlPath = Path.Combine(basePath, "Students.APIServer.xml");
    options.IncludeXmlComments(xmlPath);
    options.SchemaFilter<Swagger.ExcludeIdPropertyFilter<EducationForm>>();
});
builder.Services.AddApiVersioning();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
