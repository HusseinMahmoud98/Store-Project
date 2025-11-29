using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Domain.Contract;
using Store.Persistance;
using Store.Persistance.Data.Contexts;
using Store.Persistence;
using Store.Services;
using Store.Services.Mapping.Products;
using Store.Shared.ErrorModels;
using Store.Web.Extensions;
using Store.Web.Middlewares;
using System.Threading.Tasks;


namespace Store.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            //builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();

            //builder.Services.AddDbContext<StoreDbContext>(options =>
            //{
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            //});
            //builder.Services.AddScoped<IDbInitializer, DbInitializer>();
            //builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            //-builder.Services.AddInfrastructureServices(builder.Configuration);

            //builder.Services.AddScoped<IServiceManager, ServiceManager>();
            //builder.Services.AddAutoMapper(M => M.AddProfile(new ProductProfile(builder.Configuration)));
            //-builder.Services.AddApplicationServices(builder.Configuration);


            //builder.Services.Configure<ApiBehaviorOptions>(config =>
            //{
            //    config.InvalidModelStateResponseFactory = (actionContext) =>
            //    {
            //        var errors = actionContext.ModelState.Where(M => M.Value.Errors.Any())
            //                                              .Select(M => new ValidationError()
            //                                              {
            //                                                  Field = M.Key,
            //                                                  Errors = M.Value.Errors.Select(E => E.ErrorMessage)
            //                                              }).ToList();

            //        var response = new ValidationErrorResponse()
            //        {
            //            Errors = errors
            //        };

            //        return new BadRequestObjectResult(response);
            //    };
            //});

            builder.Services.AddAllServices(builder.Configuration);

            var app = builder.Build();


            //using var scope = app.Services.CreateScope();
            //var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>(); //Ask Clr TO Create Object From IDbInitializer
            //await dbInitializer.InitializeAsync();


            //app.UseStaticFiles();
            //app.UseMiddleware<GlobalErrorHandlingMiddleware>();

            //// Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}

            //app.UseHttpsRedirection();

            //app.UseAuthorization();


            //app.MapControllers();

            await app.ConfigureMiddlewares();

            app.Run();
        }
    }
}
