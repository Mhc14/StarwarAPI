using SWAPI;
using SWAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IStarWarsMovieService, StarWarsMovieService>();

builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseMyMiddleware();
app.UseEndpoints(endpoints =>
{
    app.MapControllers();
});
app.Run();
