using gerenciadorTarefa.Controller;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace gerenciadorTarefa
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "gerenciadoTarefa", Description = "Teste com Minimal APIs", Version = "v1" });
            });
             
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

            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {    
                c.SwaggerEndpoint("./swagger/v1/swagger.json", "gerenciadoTarefa");
                c.RoutePrefix = "";
            });
           
            app.MapRazorPages();

            app.Run();
        }
    }
}