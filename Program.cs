using InnovationAPI.DatabaseSettings;
using InnovationAPI.Services;
using InnovationAPI.Services.FeedbackServices;
using InnovationAPI.Services.IdeaServices;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Database setting and mongo client settings

builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection(nameof(DatabaseSettings)));

builder.Services.AddSingleton<IDatabaseSettings>(sp =>
sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);
// Add mongoclient to connect the mongo database
builder.Services.AddSingleton<IMongoClient>(s =>
        new MongoClient(builder.Configuration.GetValue<string>("DatabaseSettings:ConnectionStrings")));
// Add scope of the Ideascollections
builder.Services.AddScoped<IIdeaServices, IdeaServices>();
// Add scope of the Feedbackscollections
builder.Services.AddScoped<IFeedbackServices, FeedbackServices>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
