using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MISA.AMIS.Api.Middware;
using MISA.AMIS.Core.Exceptions;
using MISA.AMIS.Core.Interfaces.Repositories;
using MISA.AMIS.Core.Interfaces.Services;
using MISA.AMIS.Core.Services;
using MISA.AMIS.Infrastructure.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MISA.AMIS.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MISA.AMIS.Api", Version = "v1" });
            });
          
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IDepartmentService, DepartmentService>();

           
            services.AddCors(options => options.AddPolicy("MyPolicy", builder =>
                builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                )
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MISA.AMIS.Api v1"));
            }
            app.UseCors("MyPolicy");
            // Hook in the global error-handling middleware
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseExceptionHandler(c => c.Run(async context =>
            {

                var exception = context.Features
                    .Get<IExceptionHandlerPathFeature>()
                    .Error;
                if (exception is EmployeeException)
                {

                    var response = new
                    {
                        devMsg = exception.Message,
                        userMsg = Properties.Resources.userMsg,
                        MISACode = Properties.Resources.MISACode,
                        Data = Properties.Resources.Data,
                    };
                    var result = JsonConvert.SerializeObject(response);
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    //var jsonObject = JsonConvert.SerializeObject(My Custom Model);
                    await context.Response.WriteAsJsonAsync(response);
                }
                else
                {
                    var response = new
                    {
                        devMsg = exception.Message,
                        userMsg = Properties.Resources.userMsg,
                        MISACode = Properties.Resources.MISACode,
                        Data = exception
                    };
                    await context.Response.WriteAsJsonAsync(response);
                }

            }));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
