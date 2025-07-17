using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using TestTask.Exceptions;
using TestTask.Service;
using TestTask.Service.Interface;
using TestTask.Validation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ApiExceptionFilter>();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IUsersService, UsersService>();
builder.Services.AddSingleton<UserValidator>();
builder.Services.AddScoped<ApiExceptionFilter>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.MapControllers();

app.Run();