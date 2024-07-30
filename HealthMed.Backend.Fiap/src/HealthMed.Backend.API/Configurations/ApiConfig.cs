using HealthMed.Backend.Infraestrutura.Persistencia;
using Microsoft.EntityFrameworkCore;
using HealthMed.Backend.Infraestrutura;
using HealthMed.Backend.Aplicacao;


namespace HealthMed.Backend.API.Configurations
{
    public static class ApiConfig
    {
        public static void AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HealthMedContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddServicosInfraEstrutura(configuration);
            services.AddServicosAplicacao();

            services.AddCors(options =>
            {
                options.AddPolicy("Total",
                    builder =>
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader());
            });


        }

        public static void UseApiConfiguration(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("Total");
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            //app.MigrateDatabase();
        }
    }
}
