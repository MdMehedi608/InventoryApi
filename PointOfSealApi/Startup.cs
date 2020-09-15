using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pos.Context.EfConnection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using System.Text;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;
using JobRecrutmentApi.Helpers;
using Pos.Service.Interfaces;
using Pos.Service;
using Pizza.Domain.Interfaces;
using Pos.Infrastructure.Data;

namespace PointOfSealApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IServiceCollection _services { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            _services = services;
            RegisterCorsPolicies();
            services.AddMvc();
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ValidateModelStateAttribute));
            });
            services.AddDbContext<SqlServerContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:MsSqlConnection"]));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new Info
                {
                    Version = "v1.0",
                    Title = "Point Of Seal API",
                    Description = "Point Of Seal Api ASP.NET Core 2.0",
                    TermsOfService = "None",
                    Contact = new Contact()
                    {
                        Name = "Personal Software",
                        Email = "mdmehedi608@gmail.com",
                        Url = "www.test.net"
                    },
                    License = new License
                    {
                        Name = "Personal Software",
                        Url = "www.test.net"
                    },
                });            
                
            });
            // Use GzipCompression.
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = System.IO.Compression.CompressionLevel.Optimal);
            services.AddResponseCompression(options =>
            {
                options.MimeTypes = new[]
                {
                    // Default
                    "text/plain",
                    "text/css",
                    "application/javascript",
                    "text/html",
                    "application/xml",
                    "text/xml",
                    "application/json",
                    "text/json",
                    // Custom
                    "image/svg+xml"
                };
            });

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // Or you can also register as follows
            services.AddHttpContextAccessor();
            services.AddTransient<IBrandService, BrandService>();
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<IUnitService, UnitService>();
            services.AddTransient<IUnitRepository, UnitRepository>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ISupplierService, SupplierService>();
            services.AddTransient<ISupplierRepository, SupplierRepository>();
            
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseCors("DevelopmentCorsPolicy");
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {

                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Point Of Seal Api v1.0");
                //add here another api version
            });

            app.UseCors("LiveCorsPolicy");
            //app.UseHttpsRedirection();
            app.UseResponseCompression();
            app.UseMvc();
            app.UseStaticFiles();
            app.UseDeveloperExceptionPage();
            
        }
        private void RegisterCorsPolicies()
        {
            string[] localHostOrigins = new string[] {
                "http://localhost:4200",
            };

            string[] liveCorsPolicy = new string[] {
               "http://localhost:4200",
            };

            _services.AddCors(options =>    // CORS middleware must precede any defined endpoints
            {
                options.AddPolicy("DevelopmentCorsPolicy", builder =>
                {
                    builder.WithOrigins(localHostOrigins)
                            .AllowAnyHeader().AllowAnyMethod().AllowCredentials();
                });
                options.AddPolicy("LiveCorsPolicy", builder =>
                {
                    builder.WithOrigins(liveCorsPolicy)
                            .AllowAnyHeader().AllowAnyMethod().AllowCredentials();
                });
            });
        }
    }
}
