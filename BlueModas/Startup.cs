using AutoMapper;
using BlueModas.Database;
using BlueModas.Libraries.AutoMapper;
using BlueModas.Libraries.CarrinhoCompra;
using BlueModas.Libraries.Cookie;
using BlueModas.Libraries.Login;
using BlueModas.Libraries.Sessao;
using BlueModas.Repositories;
using BlueModas.Repositories.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlueModas
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
            services.AddDistributedMemoryCache();
            services.Configure<CookieTempDataProviderOptions>(options => {
                options.Cookie.IsEssential = true;
            });
            services.AddSession(options=>options.Cookie.IsEssential=true);

            services.AddAutoMapper(config=>config.AddProfile<MappingProfile>(),typeof(Startup));

            services.AddHttpContextAccessor();
            services.AddScoped<LoginCliente>();
            services.AddScoped<GerenciadorCookie>();
            services.AddScoped<CarrinhoCompra>();

            services.AddScoped<IEnderecoEntregaRepository, EnderecoEntregaRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<Sessao>();
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddDbContext<BlueModasContext>(options=>
                options.UseSqlServer(Configuration.GetValue<string>("Database:Connection"),sql=>sql.CommandTimeout(360)));

            services.AddMvc(options =>
            {
                options.ModelBindingMessageProvider.SetValueIsInvalidAccessor(x => "Valor inválido para o campo");
                options.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor((y, x) => "Valor inválido para o campo");
                options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(x => "Valor inválido para o campo");
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
                app.UseStatusCodePagesWithReExecute("/Erro/Erro{0}");
                app.UseExceptionHandler("/Erro/Erro500");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();
            app.UseMvc(routes =>
            {
             routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            );
            routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
