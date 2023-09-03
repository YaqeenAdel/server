using YaqeenInfrastructure;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

builder.Services.Configure<ConfigurationKeys>(configuration);

var connectionString = configuration.GetConnectionString(nameof(ConnectionStrings.YaqeenPostgresDb));
builder.Services.ConfigureServices(connectionString);

builder.Services.AddAutoMapper(typeof(YaqeenServices.AutoMapper));

builder.Services.AddControllers();

builder.Services.AddAuth0Services(builder.Configuration);

builder.Services.AddSwaggerDocs();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

builder.Services.AddLogging(builder =>
{
    builder.AddConsole();
    builder.AddDebug();
});

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
