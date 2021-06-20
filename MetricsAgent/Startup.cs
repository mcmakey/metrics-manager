using MetricsAgent.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Data.SQLite;

namespace MetricsAgent
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            ConfigureSqlLiteConnection(services);
            services.AddScoped<ICpuMetricsRepository, CpuMetricsRepository>();
            services.AddScoped<IDotNetMetricsRepository, DotNetMetricsRepository>();
            services.AddScoped<IHddMetricsRepository, HddMetricsRepository>();
            services.AddScoped<INetworkMetricsRepository, NetworkMetricsRepository>();
            services.AddScoped<IRamMetricsRepository, RamMetricsRepository>();
        }

        private void ConfigureSqlLiteConnection(IServiceCollection services)
        {
            const string connectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";
            var connection = new SQLiteConnection(connectionString);
            connection.Open();
            PrepareSchema(connection);
        }

        private void PrepareSchema(SQLiteConnection connection)
        {
            using (var command = new SQLiteCommand(connection))
            {
                // cpumetrics
                command.CommandText = @"CREATE TABLE IF NOT EXISTS cpumetrics(id INTEGER PRIMARY KEY, value INT, time INT)";
                command.ExecuteNonQuery();

                // dotnetmetrics
                command.CommandText = @"CREATE TABLE IF NOT EXISTS dotnetmetrics(id INTEGER PRIMARY KEY, value INT, time INT)";
                command.ExecuteNonQuery();

                // hddmetrics
                command.CommandText = @"CREATE TABLE IF NOT EXISTS hddmetrics(id INTEGER PRIMARY KEY, value INT, time INT)";
                command.ExecuteNonQuery();

                // networkmetrics
                command.CommandText = @"CREATE TABLE IF NOT EXISTS networkmetrics(id INTEGER PRIMARY KEY, value INT, time INT)";
                command.ExecuteNonQuery();

                // rammetrics
                command.CommandText = @"CREATE TABLE IF NOT EXISTS rammetrics(id INTEGER PRIMARY KEY, value INT, time INT)";
                command.ExecuteNonQuery();
            }
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}