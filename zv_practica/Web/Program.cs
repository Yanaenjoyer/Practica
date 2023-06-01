using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Web.Data;
using Domain.Models;
using Domain.Interfaces;
using DataAccess.Models;
using DataAccess.Wrapper;
using Domain;
using BusinessLogic.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Authorization;
using Web.Auth;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using MudBlazor.Services;

namespace Web
{
    public class Program
    {
        public static void Main ( string[] args )
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<MyDbContext>(optionsAction: options => options.UseSqlServer(connectionString: "Data Source=(local);Initial Catalog=магазин;Integrated Security=True;MultipleActiveResultSets=True;Encrypt=false;TrustServerCertificate=true;Trust Server Certificate=true"));
            builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddScoped<IRepositoryWrapperOrder, RepositoryWrapperOrder>();
            builder.Services.AddScoped<IOrderService, OrderService>();

            builder.Services.AddScoped<IRepositoryWrapperProduct, RepositoryWrapperProduct>();
            builder.Services.AddScoped<IProductService, ProductService>();


            builder.Services.AddScoped<IRepositoryWrapperAdress, RepositoryWrapperAdress>();
            builder.Services.AddScoped<IAdressService, AdressService>();

            builder.Services.AddScoped<IRepositoryWrapperOrderProduct, RepositoryWrapperOrderProduct>();
            builder.Services.AddScoped<IOrderProductService, OrderProductService>();
          


            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSingleton<WeatherForecastService>();
            builder.Services.AddAuthenticationCore();
            builder.Services.AddScoped <AuthenticationStateProvider, CistomAuthenticationStateProvider>();
            builder.Services.AddScoped<ProtectedSessionStorage>();
            builder.Services.AddScoped<ProtectedLocalStorage>();

            builder.Services.AddMudServices();
           

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

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}