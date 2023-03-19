using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using OnlineOrder.Application.HttpSession;
using OnlineOrder.Domain.DAOs;
using OnlineOrder.Infrastructure.Interfaces;
using OnlineOrder.Infrastructure.Services;


namespace OnlineOrder.Application;

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
        services.AddApiVersioning();

        services.AddVersionedApiExplorer(
            options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

        services.AddEndpointsApiExplorer();

        services.AddControllers();

        /*services.AddControllers(options =>
            options.Filters.Add(new AopExceptionHandlerFilter()));*/
        
        services.AddDbContext<ApplicationDbContext>(opts => 
            opts.UseSqlServer(Configuration["ConnectionStrings:OnlineOrderDB"]));


        // Register the Swagger generator, defining 1 or more Swagger documents 
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Online Order API",
                Description = "ASP.NET Core Web API",
                TermsOfService = new Uri("https://example.com/terms"),
                Contact = new OpenApiContact
                {
                    Name = "Example Contact",
                    Url = new Uri("https://example.com/contact")
                },
                License = new OpenApiLicense
                {
                    Name = "Example License",
                    Url = new Uri("https://example.com/license")
                }
            });

            // Set the comments path for the Swagger JSON and UI.
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        });
        
        services.AddSwaggerDocument();
        
        services.TryAddScoped<IHttpSession, Infrastructure.Services.HttpSession>();
        services.TryAddScoped<IUserSession, UserSession>();
        services.TryAddScoped<IUnitOfWork, UnitOfWork>();

        /*services.AddScoped<IOrderRepository, OrderRepository>();
        //services.AddScoped<IUnitOfWorkFactory, UnitOfWorkFactory>();
        services.AddScoped<IOrderService, OrderService>();*/
        
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        // Enable middleware to serve generated Swagger as a JSON endpoint.
        app.UseSwagger(c => { c.SerializeAsV2 = true; });

        // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
        // specifying the Swagger JSON endpoint.
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Online Order API V1");
            c.RoutePrefix = string.Empty;
        });

        // Enable middleware to serve generated Swagger as a JSON endpoint.
        app.UseSwagger(c => { c.SerializeAsV2 = true; });

        app.UseStaticFiles();

        // Register the Swagger generator and the Swagger UI middlewares
        app.UseOpenApi();

        app.UseSwaggerUi3();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseMiddleware<UnitOfWorkMiddleware>();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}