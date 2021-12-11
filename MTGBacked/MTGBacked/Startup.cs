using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MTGBacked.Models;

namespace MTGBacked
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
            services.AddDbContext<MagicTheGatheringCardDbContext>(option => option.UseInMemoryDatabase(Configuration.GetConnectionString("InMemoryDB")));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MTGBacked", Version = "v1" });
            });
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Allow Cross Origin Resource Sharing from http://localhost:4200
            app.UseCors(options =>
            options.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MTGBacked v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //load startup data 
            var scope = app.ApplicationServices.CreateScope();
            MagicTheGatheringCardDbContext context = scope.ServiceProvider.GetService<MagicTheGatheringCardDbContext>();
            loadInitialData(context);
        }

        //Loads initial data in the in-Memory database
        private static void loadInitialData(MagicTheGatheringCardDbContext context)
        {
            MagicTheGatheringCard cardOne = new MagicTheGatheringCard
            {
                CardName = "Pack's Betrayal",
                CardType = "Sorcery",
                CardDiscription = "Gain control of creature until end of turn"
            };

            MagicTheGatheringCard cardTwo = new MagicTheGatheringCard
            {
                CardName = "Manticore",
                CardType = "Creature",
                CardDiscription = "When manticore enters the battlefield, destroy target creature an opponent controls that was damage this turn"
            };

            MagicTheGatheringCard cardThree = new MagicTheGatheringCard
            {
                CardName = "Grim Bounty",
                CardType = "Sorcery",
                CardDiscription = "Destroy target creature or planeswalker"
            };

            context.MagicTheGatheringCards.Add(cardOne);
            context.MagicTheGatheringCards.Add(cardTwo);
            context.MagicTheGatheringCards.Add(cardThree);
            context.SaveChanges();

        }
    }
}
