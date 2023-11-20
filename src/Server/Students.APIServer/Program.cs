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
    options.SchemaFilter<Swagger.ExcludeIdPropertyFilter<EducationProgram>>();
    options.SchemaFilter<Swagger.ExcludeIdPropertyFilter<EducationType>>();
    options.SchemaFilter<Swagger.ExcludeIdPropertyFilter<FEAProgram>>();
    options.SchemaFilter<Swagger.ExcludeIdPropertyFilter<FinancingType>>();
    options.SchemaFilter<Swagger.ExcludeIdPropertyFilter<Group>>();
    options.SchemaFilter<Swagger.ExcludeIdPropertyFilter<Request>>();
    options.SchemaFilter<Swagger.ExcludeIdPropertyFilter<ScopeOfActivity>>();
    options.SchemaFilter<Swagger.ExcludeIdPropertyFilter<Student>>();
    options.SchemaFilter<Swagger.ExcludeIdPropertyFilter<StudentDocument>>();
    options.SchemaFilter<Swagger.ExcludeIdPropertyFilter<StudentEducation>>();
    options.SchemaFilter<Swagger.ExcludeIdPropertyFilter<StudentStatus>>();
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
