using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using SampleSchoolApi;
using System;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IStudentsRepository, StudentsRepository>();
builder.Services.AddRouting();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.MapControllers();
app.UseRouting();
app.MapGet("/", (Func<string>)(() => "Hello World!"));

app.Run();
