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
            services.AddMvc(a => {//��������Խ�ִ��˳��
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
            //�����Զ����м��.
            //app.UseMiddleware<RequestIPMyMiddleware>();
            app.UseMyIp();
            //�����Զ���·�ɵ��м��
            app.Res();

            //ϵͳ�Դ�·��
            app.UseEndpoints(endpoints =>
            {
                //����Լ����555,55,5555��ʽ
                endpoints.MapControllerRoute(
               name: "home",
               pattern: "{controller}/{ssn}",
               constraints: new { ssn = "^\\d{3}-\\d{2}-\\d{4}$", },
               defaults: new { controller = "Home", action = "Index", });

                //�̶�action
                //endpoints.MapControllerRoute(
                //name: "AA",
                //pattern: "{controller=Home}",
                //defaults: new { controller = "Home", action = "Index" });

                //�̶�������
                //endpoints.MapControllerRoute(
                //   name: "AA",
                //   pattern: "wahaha/{action}",
                //   defaults: new { controller = "Home", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "default",
                    //��������action���Խ���λ��
                    pattern: "{controller=Home}/{action=Index}/{id:int?}");
            });


        }
    }
}
