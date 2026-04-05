var builder = WebApplication.CreateBuilder(args);

//Add services to the container
builder.Services.AddControllers();

var app = builder.Build();

//Configure the HTTP request pipeline
app.UseHttpsRedirection();

//Allows the HTML/CSS/JS in wwwroot to work
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseAuthorization();

//Map your controller so the API routes work
app.MapControllers();

app.Run();