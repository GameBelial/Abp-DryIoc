﻿using System;
using Abp.AspNetCore;
using AspNetCoreApp.Application.ScopeTest;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreApp
{
    public class Startup
    {
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            
            // Scope 生命周期对象测试
            services.AddScoped(typeof(ScopeClass));
            
            return services.AddAbp<AspNetCoreAppModule>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();
            app.UseAbp(op=>op.UseCastleLoggerFactory = false);
        }
    }
}