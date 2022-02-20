
using backSisInvestigacion.Common;
using backSisInvestigacion.Models;
using backSisInvestigacion.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backSisInvestigacion
{
  

    public class Startup
    {
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public object ValidateIssuer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        readonly string MiCors = "MiCors";
        public void ConfigureServices(IServiceCollection services)
        {
        
            services.AddCors(options =>
            {
                options.AddPolicy(name: MiCors,
                                  builder =>
                                  {
                                     builder.WithHeaders("*"); 
                                     builder.WithOrigins("*");
                                     builder.WithMethods("*");                                     
                                  });
            });


            services.AddControllers();
            services.AddDbContext<bddSisInvestigacionContext>();
            /*options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("bddSisInvestigaciont"));
            }*/

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            //jwt
            var appSettings = appSettingsSection.Get<AppSettings>();
            var llave = Encoding.ASCII.GetBytes(appSettings.Secreto);
            services.AddAuthentication(d =>
            {
                d.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                d.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(d =>
                {
                    d.RequireHttpsMetadata = false;
                    d.SaveToken = true;
                    d.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(llave),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });


            
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IFacultadService, FacultadService>();
            services.AddScoped<IProyectoService, ProyectoService>();
            services.AddScoped<IRegInvService, RegInvService>();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "backSisInvestigacion", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /*public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {                
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "backSisInvestigacion v1"));
            }
            
            app.UseRouting();
            app.UseCors(MiCors);
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }*/

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if (env.IsProduction() || env.IsStaging())
            {
                //app.UseExceptionHandler("/Error/index.html");
            }
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "swagger/{documentName}/swagger.json";
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "swagger";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
                // custom CSS
                c.InjectStylesheet("/swagger-ui/custom.css");
            });

            app.Use(async (ctx, next) =>
            {
                await next();
                if (ctx.Response.StatusCode == 204)
                {
                    ctx.Response.ContentLength = 0;
                }
            });
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(MiCors);
            app.UseAuthorization();
            app.UseAuthentication();

          
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
           
        }



    }
}
