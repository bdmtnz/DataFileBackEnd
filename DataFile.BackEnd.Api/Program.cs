using DataFile.BackEnd.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApiDependencies(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || true)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler("/error");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors("_myAllowSpecificOrigins");
app.Run();
