using Microsoft.EntityFrameworkCore;
using ProfilesAPI.Models;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore.Sqlite;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Profiles") ?? "Data Source=Profiles.db";

builder.Services.AddControllers();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSqlite<ProfileDb>(connectionString);
builder.Services.AddSwaggerGen(c => 
{
    c.SwaggerDoc("v1", new() {Title = "ProfilesAPI", Version = "v1"});
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
