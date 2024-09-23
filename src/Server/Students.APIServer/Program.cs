using System.Text.Json.Serialization;
using Students.APIServer.Extension;
using Students.APIServer.Repository;
using Students.DBCore.Contexts;
using Students.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StudentContext, PgContext>();
//builder.Services.AddDbContext<StudentContext, InMemoryContext>();
//builder.Services.AddScoped<InMemoryContext>();
//builder.Services.AddScoped<StudentContext>();
builder.Services.AddScoped<PgContext>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IGroupRepository, GroupRepository>();
builder.Services.AddScoped<IGroupStudentRepository, GroupStudentRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IRequestRepository, RequestRepository>();
builder.Services.AddScoped<IReportRepository, CSVReportRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddSwaggerGen(options =>
{
    var basePath = AppContext.BaseDirectory;

    var apiDoc = Path.Combine(basePath, "Students.APIServer.xml");
    var modelsDoc = Path.Combine(basePath, "Students.Models.xml");
    options.IncludeXmlComments(apiDoc);
    options.IncludeXmlComments(modelsDoc);
    options.SchemaFilter<Swagger.ExcludeIdPropertyFilter<EducationForm>>();
    options.SchemaFilter<Swagger.ExcludeIdPropertyFilter<EducationProgram>>();
    options.SchemaFilter<Swagger.ExcludeIdPropertyFilter<FEAProgram>>();
    options.SchemaFilter<Swagger.ExcludeIdPropertyFilter<StatusRequest>>();
    options.SchemaFilter<Swagger.ExcludeIdPropertyFilter<FinancingType>>();
    options.SchemaFilter<Swagger.ExcludeIdPropertyFilter<Group>>();
    options.SchemaFilter<Swagger.ExcludeIdPropertyFilter<Request>>();
    options.SchemaFilter<Swagger.ExcludeIdPropertyFilter<ScopeOfActivity>>();
    options.SchemaFilter<Swagger.ExcludeIdPropertyFilter<Student>>();
    //options.SchemaFilter<Swagger.ExcludeIdPropertyFilter<StudentDocument>>();
    options.SchemaFilter<Swagger.ExcludeIdPropertyFilter<TypeEducation>>();
    options.SchemaFilter<Swagger.ExcludeIdPropertyFilter<StudentStatus>>();
    options.SchemaFilter<Swagger.ExcludeIdPropertyFilter<KindDocumentRiseQualification>>();
    options.SchemaFilter<Swagger.ExcludeIdPropertyFilter<DocumentRiseQualification>>();
    options.SchemaFilter<Swagger.ExcludeIdPropertyFilter<KindOrder>>();
    options.SchemaFilter<Swagger.ExcludeIdPropertyFilter<Order>>();
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder
         .SetIsOriginAllowed(e => true)
         .AllowAnyMethod()
         .AllowAnyHeader()
         .AllowCredentials());
});
 

builder.Services.AddApiVersioning();
builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

app.UseCors(builder => builder
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader());

 if (app.Environment.IsDevelopment())
 {
    app.UseSwagger();
    app.UseSwaggerUI();
 }

app.UseCors("CorsPolicy");
app.UseAuthorization();

app.MapControllers();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
app.Run();
