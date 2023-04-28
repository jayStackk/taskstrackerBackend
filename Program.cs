
// using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using tasktrackerBackend.Services;
using tasktrackerBackend.Services.Context;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<TaskService>();
builder.Services.AddScoped<PasswordServices>();


var connectionString = builder.Configuration.GetConnectionString("MyBlogString");


builder.Services.AddCors(options => {
    options.AddPolicy("BlogPolicy",
    builder => {
        builder.WithOrigins("http://localhost:3000", "http://localhost:3001", "https://tasktrackersprint.azurewebsites.net")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
// Add services to the container.


builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

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

// app.UseHttpsRedirection();
app.UseCors("BlogPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
