using KanbanBoard.Api.Interfaces;
using KanbanBoard.Api.Models;
using KanbanBoard.Api.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using KanbanBoard.Api.Services;
using Microsoft.IdentityModel.Tokens;

namespace KanbanBoard.Api
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
            services.Configure<GoalstoreDatabaseSettings>(
                Configuration.GetSection(nameof(GoalstoreDatabaseSettings)));

            services.AddSingleton<IGoalstoreDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<GoalstoreDatabaseSettings>>().Value);
            
            services.AddSingleton<GoalsService>();

            services.AddTransient<IGoalsRepository, GoalsRepository>();
            services.AddControllers();

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
            {
                options.Authority = "https://localhost:5001";

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
