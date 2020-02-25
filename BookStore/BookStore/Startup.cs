using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.API.Interfaces;
using BookStore.API.Repository;
using BookStore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.HttpOnly = true;
                // Make the session cookie essential
                options.Cookie.IsEssential = true;
            });
            //services.AddDbContext<BookStoreContext>(options => options.UseInMemoryDatabase("BookStore"));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<BookStoreContext>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IStateRepository, StateRepository>();
            services.AddTransient<IPublisherRepository, PublisherRepository>();
            services.AddTransient<ILanguageRepository, LanguageRepository>();
            services.AddTransient<ITypeRepository, TypeRepository>();
            services.AddTransient<IPenaltyRepository, PenaltyRepository>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IShiftRepository, ShiftRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IRentRepository, RentRepository>();
            services.AddTransient<IPayRepository, PayRepository>();
            services.AddTransient<IRentDetailRepository, RentDetailRepository>();
            services.AddTransient<IPayDetailRepository, PayDetailRepository>();
            services.AddTransient<IReportRepository, ReportRepository>();
            services.AddTransient<IAccountRepository, AccountRepository>();

            //var connection = @"Server=.\\;Database=BookStore;Trusted_Connection=True;";
            //services.AddDbContext<BookStoreContext>(options => options.UseSqlServer(connection));
            //services.AddTransient<ICategoryRepository, CategoryRepository>();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Admin}/{action=Index}/{id?}");
            });
        }
    }
}
