using Microsoft.AspNetCore.Builder;
using SWAPI;
using SWAPI.Middlware;
using SWAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IStarWarsMovie, StarWarsMovie>();

builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseMyMiddleware();
app.UseEndpoints(endpoints =>
{
    app.MapControllers();
});
app.Run();
