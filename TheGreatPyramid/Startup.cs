using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using TheGreatPyramid.Configuration;
using TheGreatPyramid.Repositories;
using TheGreatPyramid.Services.Implementation;
using TheGreatPyramid.Services.Interface;

namespace TheGreatPyramid
{
    public class Startup
    {
        private readonly string defaultBasePath;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            defaultBasePath = Path.Combine(Directory.GetCurrentDirectory(), "Storage");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var configuration = Configuration.GetSection("FileRepository").Get<FileRepositoryConfiguration>();

            if (string.IsNullOrEmpty(configuration.BasePath))
            {
                configuration.BasePath = defaultBasePath;
            }

            services.AddSingleton(configuration);
            services.AddScoped<IFileRepository, FileRepository>();
            services.AddScoped<IPyramidValueCalculator, PyramidValueCalculator>();
            services.AddScoped<IPyramidCreator, PyramidCreator>();
            services.AddScoped<IPyramidPathFinder, PyramidPathFinder>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
