using DTO.Implement;
using DTO.Interface;
using DTO.single;
using first_net__core.Extands;
using first_net__core.Filter;
using first_net__core.midd;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace first_net__core
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
            services.AddTransient<IMath,Math_B>();
            services.AddSingleton<MySingle>();
            services.AddSession();
            services.AddControllersWithViews();
            services.AddMvc(a => {//扩号里可以接执行顺序
                //a.Filters.Add<actionFilter>(3);
                //a.Filters.Add(new actionFilter());//typeof(IMath)
                a.Filters.Add(new authFilter());
                
            });
            services.AddTransient<actionFilter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            
            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();
            //引入自定义中间件.
            //app.UseMiddleware<RequestIPMyMiddleware>();
            app.UseMyIp();
            //引入自定义路由的中间件
            app.Res();

            //系统自带路由
            app.UseEndpoints(endpoints =>
            {
                //正则约束，555,55,5555格式
                endpoints.MapControllerRoute(
               name: "home",
               pattern: "{controller}/{ssn}",
               constraints: new { ssn = "^\\d{3}-\\d{2}-\\d{4}$", },
               defaults: new { controller = "Home", action = "Index", });

                //固定action
                //endpoints.MapControllerRoute(
                //name: "AA",
                //pattern: "{controller=Home}",
                //defaults: new { controller = "Home", action = "Index" });

                //固定控制器
                //endpoints.MapControllerRoute(
                //   name: "AA",
                //   pattern: "wahaha/{action}",
                //   defaults: new { controller = "Home", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "default",
                    //控制器和action可以交换位置
                    pattern: "{controller=Home}/{action=Index}/{id:int?}");
            });


        }
    }
}
