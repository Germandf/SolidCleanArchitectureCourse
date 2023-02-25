using Serilog;
using SolidCleanArchitectureCourse.Api.Middlewares;
using SolidCleanArchitectureCourse.Application;
using SolidCleanArchitectureCourse.Identity;
using SolidCleanArchitectureCourse.Infrastructure;
using SolidCleanArchitectureCourse.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) => loggerConfig
    .WriteTo.Console()
    .ReadFrom.Configuration(context.Configuration));

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddCors(options => options.AddPolicy("all", builder => 
    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
app.UseSwagger();
app.UseSwaggerUI();
app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseCors("all");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
