using MetroPass.Application.Configurations;
using MetroPass.Presentation.Register;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.RegisterAutoMapper();
builder.Services.RegisterApplication();
builder.Services.RegisterRepository();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtSetting"));
builder.Services.AddSingleton(sp =>
    sp.GetRequiredService<IOptions<JwtConfig>>().Value);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
