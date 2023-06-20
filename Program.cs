using CLI.Models;
using CLI.Repositories;
using CLI.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEntityFrameworkSqlite()
.AddDbContext<TaskManagerContext>((o)=> o.UseSqlite(String.Format("Filename=D:/CLI/TaskManager.db", AppDomain.CurrentDomain.BaseDirectory)));

builder.Services.AddScoped<IDataRepository<TaskList>, TaskListRepository>();
builder.Services.AddScoped<ITaskItemRepository, TaskItemRepository>();
builder.Services.AddScoped<ITaskListService, TaskListService>();
builder.Services.AddScoped<ITaskItemService, TaskItemService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("DefaultCorsPolicy",
                      policy  =>
                      {
                          policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                                 
                      });
});
builder.Services.AddControllers();

var app = builder.Build();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=TaskManager.db";

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
//app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

app.Run();
