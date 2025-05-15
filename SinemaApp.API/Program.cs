using Microsoft.EntityFrameworkCore;
using SinemaApp.DataAccessLayer.Context;
using SinemaApp.DataAccessLayer.Abstract;
using SinemaApp.DataAccessLayer.Repository;
using SinemaApp.Business.Abstract;
using SinemaApp.Entities.Concrete;
using SinemaApp.Business.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;



var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IFilmManager, FilmManager>();
builder.Services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IKullaniciManager, KullaniciManager>();
builder.Services.AddScoped<ISalonManager, SalonManager>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IKoltukManager, KoltukManager>();
builder.Services.AddScoped<ISeansManager, SeansManager>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
    options.TokenValidationParameters = new
    Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ClockSkew = TimeSpan.Zero,
        
    };
    options.Events = new JwtBearerEvents
    {
        OnChallenge = context =>
        {
           
            context.Response.StatusCode = 401;
            return Task.CompletedTask;
        }
    };
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
});

builder.Services.AddDbContext<SinemaAppContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SinemaAppConnection"));
});
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();

app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

