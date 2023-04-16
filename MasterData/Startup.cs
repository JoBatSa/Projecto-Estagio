using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using DDDSample1.Infrastructure;

using DDDSample1.Infrastructure.Shared;
using DDDSample1.Domain.Shared;

using DDDSample1.Domain.Administrators;
using DDDSample1.Infraestructure.Administrators;

using DDDSample1.Domain.Customers;
using DDDSample1.Infraestructure.Customers;

using DDDSample1.Infraestructure.Employees;
using DDDSample1.Domain.Employees;

using DDDSample1.Domain.Reports;
using DDDSample1.Infraestructure.Reports;

using DDDSample1.Domain.WorkOrders;
using DDDSample1.Infraestructure.WorkOrders;

using DDDSample1.Domain.WorkAuthorizations;
using DDDSample1.Infraestructure.WorkAuthorizations;


using DDDSample1.Infraestructure.VisualAids;
using DDDSample1.Domain.VisualAids;


using DDDSample1.Infrastructure.Logins;
using DDDSample1.Domain.Logins;



namespace DDDSample1
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
           /* services.AddDbContext<DDDSample1DbContext>(opt =>
                opt.UseInMemoryDatabase("DDDSample1DB")
                .ReplaceService<IValueConverterSelector, StronglyEntityIdValueConverterSelector>());
        */

        services.AddDbContext<DDDSample1DbContext>(opt =>
                            opt.UseSqlServer(Configuration.GetConnectionString("LocalHostConnection"))
                            .ReplaceService<IValueConverterSelector, StronglyEntityIdValueConverterSelector>());
            ConfigureMyServices(services);
            
            

            services.AddControllers().AddNewtonsoftJson();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureMyServices(IServiceCollection services)
        {
           
 services.AddTransient<IUnitOfWork, UnitOfWork>();

            
            services.AddTransient<IAdministratorRepository,AdministratorRepository>();
            services.AddTransient<AdministratorService>();
            
            
            services.AddTransient<IEmployeeRepository,EmployeeRepository>();
            services.AddTransient<EmployeeService>();

            services.AddTransient<ICustomerRepository,CustomerRepository>();
            services.AddTransient<CustomerService>();

            services.AddTransient<IReportRepository,ReportRepository>();
            services.AddTransient<ReportService>();

            services.AddTransient<IWorkOrderRepository,WorkOrderRepository>();
            services.AddTransient<WorkOrderService>();

            services.AddTransient<IWorkAuthorizationRepository,WorkAuthorizationRepository>();
            services.AddTransient<WorkAuthorizationService>();

            services.AddTransient<IVisualAidRepository,VisualAidRepository>();
            services.AddTransient<VisualAidService>();

            services.AddTransient<ILoginRepository,LoginRepository>();
            services.AddTransient<LoginService>();


        }
    }
}
