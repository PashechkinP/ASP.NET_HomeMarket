using MainHomeApplication;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IGetHomeIndex, HomeIndexGenerator>();

builder.Services.AddTransient<IAddHome, HomeBuilder>();
builder.Services.AddTransient<IRemoveHome, HomeBuilder>();
builder.Services.AddTransient<IGetHome, HomeBuilder>();
builder.Services.AddTransient<IUpdateHome, HomeBuilder>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => options.LoginPath = "/login");
builder.Services.AddAuthorization();
try
{
    Directory.Delete(Directory.GetCurrentDirectory() + "wwwroot/images", true);
}catch (DirectoryNotFoundException)
{
}


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

app.Run();