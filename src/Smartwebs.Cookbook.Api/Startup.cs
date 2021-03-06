﻿using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Smartwebs.Cookbook.Ef;
using Smartwebs.Cookbook.Ef.Repositories;
using Smartwebs.Cookbook.Services.Recipes;
using Smartwebs.Domain.Repositories;

namespace Smartwebs.Cookbook
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
            services.AddMvc();
            services.AddScoped(_ => new CookbookDbContext(Configuration.GetConnectionString("Default")));

            services.AddAutoMapper();

            services.AddScoped(typeof(IRepository<>), typeof(EfRepositoryBase<>));
            services.AddScoped(typeof(IRepository<,>), typeof(EfRepositoryBase<,>));

            services.AddTransient<IRecipeService, RecipeService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
