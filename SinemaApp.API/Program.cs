using Microsoft.EntityFrameworkCore;
using SinemaApp.DataAccessLayer.Context;
using SinemaApp.DataAccessLayer.Abstract;
using SinemaApp.DataAccessLayer.Repository;
using SinemaApp.Business.Abstract;
using SinemaApp.Entities.Concrete;
using SinemaApp.Business.Concrete;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));
////builder.Services.AddScoped<IBiletService, BiletManager>();
////builder.Services.AddScoped (typeof(IBiletDal, typeof(GenericRepository<>));
//builder.Services.AddScoped<IKullaniciService, KullaniciManager>();
////builder.Services.AddScoped<IKullaniciDal>(); 
builder.Services.AddScoped<IFilmManager, FilmManager>();
builder.Services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IKullaniciManager, KullaniciManager>();
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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();

