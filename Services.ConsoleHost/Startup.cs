using System;
using Data.LTS.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Services.Infrastructure.Repositories;
using Services.Infrastructure.Services;
using Services.Infrastructure.Services.Reports;

namespace Presentation.ConsoleHost
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnectionString");
        }
        
        private readonly string _connectionString;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();

            services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(_connectionString));

            services.AddScoped<AddressRepository>();
            services.AddScoped<AddressService>();
            
            services.AddScoped<TtnRepository>();
            services.AddScoped<TtnService>();

            services.AddScoped<AgentTypeRepository>();
            services.AddScoped<AgentTypeService>();
            
            services.AddScoped<CategoryRepository>();
            services.AddScoped<CategoryService>();
            
            services.AddScoped<ProductRepository>();
            services.AddScoped<ProductService>();
            
            services.AddScoped<EmployeeRepository>();
            services.AddScoped<EmployeeService>();
            
            services.AddScoped<AgentRepository>();
            services.AddScoped<AgentService>();
            
            services.AddScoped<ProductOrderRepository>();
            services.AddScoped<ProductOrderService>();
            
            services.AddScoped<ProductSupplyRepository>();
            services.AddScoped<ProductSupplyService>();
            
            services.AddScoped<ProductUtilRepository>();
            services.AddScoped<ProductUtilService>();
            
            services.AddScoped<OrderRepository>();
            services.AddScoped<OrderService>();
            
            services.AddScoped<SupplyRepository>();
            services.AddScoped<SupplyService>();
            
            services.AddScoped<ReturnRepository>();
            services.AddScoped<ReturnService>();
            
            services.AddScoped<UtilizationRepository>();
            services.AddScoped<UtilizationService>();

            services.AddScoped<ReportRepository>();
            services.AddScoped<ReportService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            
            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("index.html");

            app.UseDefaultFiles(options);
            app.UseStaticFiles();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(_ => true) 
                .AllowCredentials()); 

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}