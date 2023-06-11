using Bazar.Luiz.Application.Service;
using Bazar.Luiz.Domain.Interfaces.Repository;
using Bazar.Luiz.Domain.Interfaces.Service;
using Bazar.Luiz.Infrastructure.Context;
using Bazar.Luiz.Infrastructure.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Bazar.Luiz.WebApi
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
            string urlbanco = Configuration.GetConnectionString("Server=AFONSOMEIRELES\\SQLEXPRESS;Database=BazarLuiz;Trusted_Connection=True;");
            services.AddControllers();
            services.AddScoped<ISetorService, SetorService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IVendaService, VendaService>();

            services.AddScoped<ISetorRepository, SetorRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IVendaRepository, VendaRepository>();

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IDbContext, DbContext>(provider => new DbContext("Server=AFONSOMEIRELES\\SQLEXPRESS;Database=BazarLuiz;Trusted_Connection=True;"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
