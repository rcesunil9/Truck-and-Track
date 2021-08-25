using TrucknDriver.Extensions;
using TrucknDriver.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using AutoMapper;
using Exceptionless;
using System;
using Microsoft.AspNetCore.Identity;

using TrucknDriver.Utilities.Model.Settings;
using TrucknDriver.Services.ServiceInterface;
using TrucknDriver.Services.Services;
using TrucknDriver.Entities.Models;
using TrucknDriver.CommonModels;
//using TrucknDriver.Entities.Models;

namespace TrucknDriver
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            //ConnectService(services);
            services.AddDbContext<TrucknDriver_LocalContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:DBString"]), ServiceLifetime.Transient);
            services.ConfigureRepositoryWrapper();
            services.AddControllers();
            // services.AddAutoMapper(typeof(MappingProfile));
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.Configure<DataProtectionTokenProviderOptions>(options => options.TokenLifespan = TimeSpan.FromMinutes(10));
          
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Connect2Heal API", Version = "v1" });
            });

            // Use app setting Value generate one model.
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));

            services.AddIdentity<AspNetUserModel, AspNetRoleModel>(opt=>
             {
                 opt.Password.RequiredLength = 6;
                 opt.Password.RequireDigit = false;
                 opt.Password.RequireUppercase = false;

                 opt.User.RequireUniqueEmail = true;

             })
                    .AddEntityFrameworkStores<TrucknDriver_LocalContext>()
                    .AddDefaultTokenProviders();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IDriverService, DriverService>();
            services.AddScoped<ITruckService, TruckService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseExceptionless(Configuration.GetValue<string>("ExceptionLessApiKey"));
            app.AddCustomSwagger();
            app.UseRouting();
            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        //public void ConnectService(IServiceCollection services)
        //{

        //    services.AddScoped<IAuthService, AuthService>();
        //    services.AddScoped<IAccountService, AccountService>();

        //}
    }
}
