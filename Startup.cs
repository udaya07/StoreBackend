using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using StoreBackEnd.Models;
using StoreBackEnd.Services;

namespace StoreBackEnd
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
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<IOrdersService, OrdersService >();

            ConfigureSwagger(services);



            services.AddCors(o => o.AddPolicy("StorePolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddDbContext<AppDbContext>();
            services.AddDbContext<AppDbContext>(option =>
       option.UseSqlServer(connectionString: Configuration.GetConnectionString("StoreDemo1")));
            services.AddMvc();

            /*  services.AddDbContext<AppDbContext>(options => {
                  options.UseSqlServer(Configuration.GetConnectionString("SqlServerConnection"));
              });*/
           services.AddCors();
            var key = "Experion.CabO,CabBookingSystemDevelepedByFreshersBatch";
            var symmetricToken = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ValidIssuer = "StoreAdmin",
                        ValidAudience = "StoreUser",
                        IssuerSigningKey = symmetricToken


                    };
                });



        }

        private static void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("StorePolicy");

            /*  app.UseAuthentication();*/

            app.UseAuthorization();
            /*  app.UseRouting();

              app.UseAuthorization();*/

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
