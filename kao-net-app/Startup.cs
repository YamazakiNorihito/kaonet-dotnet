using kao_net_app.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace kao_net_app
{
    public class Startup
    {
        private static string GOOGLE_CREDENTIALS = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                                                                "kao-net-firebase-secret.json");

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
                {
                    options.AddPolicy("EnableCROS", builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
                }
            );

            // jwt auth
            services.Configure<FireBaseConfig>(Configuration.GetSection(nameof(FireBaseConfig)));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "kao_net_app", Version = "v1" });
            });

            // jwt auth
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwt =>
            {
                var firebaseProjectId = Configuration[$"{nameof(FireBaseConfig)}:{nameof(FireBaseConfig.ProjectId)}"];

                jwt.Authority = $"https://securetoken.google.com/{firebaseProjectId}";
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = $"https://securetoken.google.com/{firebaseProjectId}",
                    ValidateIssuer = false,
                    ValidateAudience = true,
                    ValidAudience = firebaseProjectId,
                    ValidateLifetime = true,
                    RequireExpirationTime = false,

                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "kao_net_app v1"));
            }

            app.UseRouting();


            app.UseCors("EnableCROS");

            // jwt auth
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", GOOGLE_CREDENTIALS);
        }
    }
}
