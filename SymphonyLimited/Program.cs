﻿using Data_DAL;
using Data_DAL.Data;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.IRepositoryMain;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConn"),
        b => b.MigrationsAssembly("SymphonyLimited")));  // Chỉ định tên assembly chứa migrations



//****----- đăng ký repositorty ------****
builder.Services.AddScoped<IContactRepository, ContactRepository>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "Areas",
    pattern: "{area:exists}/{controller=HomeAdmin}/{action=Index}/{id?}");


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseStatusCodePagesWithRedirects("/Home/Error?statuscode={0}");
app.Run();
