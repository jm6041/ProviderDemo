using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Tongfang.DAU
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDAU<ModbusAcquireOptions>((serviceProvider, options) =>
            {
                ModbusAcquireOptions mopt1 = new ModbusAcquireOptions()
                {
                    ProviderName = typeof(ModbusAcquireProvider).AssemblyQualifiedName,
                    Equipment = new ModbusEquipment(),
                    Channel = new ModbusAcquireChannel()
                };
                ModbusAcquireOptions mopt2 = new ModbusAcquireOptions()
                {
                    ProviderName = typeof(ModbusAcquireProvider).AssemblyQualifiedName,
                    Equipment = new ModbusEquipment(),
                    Channel = new ModbusAcquireChannel()
                };
                options.Add(mopt1);
                options.Add(mopt2);
            });

            services.AddDAU<OpcAcquireOptions>((serviceProvider, options) =>
            {
                OpcAcquireOptions oopt = new OpcAcquireOptions()
                {
                    ProviderName = typeof(OpcAcquireProvider).AssemblyQualifiedName,
                    Equipment = new OpcEquipment(),
                    Channel = new OpcAcquireChannel()
                };
                options.Add(oopt);
            });

            services.AddDAUCore();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var b = app.ApplicationServices.GetRequiredService<IDauCore>();
            b.Start();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
