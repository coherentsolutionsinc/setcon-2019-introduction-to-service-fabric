﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JokesApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(
            IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public void ConfigureServices(
            IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}