using System.Text;
using CoreWCF.Channels;
using CoreWCF.Configuration;
using CoreWCF.Description;
using CoreWCF.Dispatcher;
using CoreWCF.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CoreWCF.Web.Middleware;
using CoreWCF.WebService;
using CoreWCF.WebService.Configuration;

namespace CoreWCF.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CoreWCFSettings>(Configuration.GetSection(nameof(CoreWCFSettings)));

            // services.PostConfigure<CoreWCFSettings>(CoreWCFSettingsExtensions.PostConfigure);
            // services.AddHttpClient("http-client", (serviceProvider, client) =>
            // {
            //     var settings = serviceProvider.GetRequiredService<IOptionsMonitor<CoreWCFSettings>>().CurrentValue;
            //     client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //     client.BaseAddress = settings.Api;
            // })
            // .ConfigurePrimaryHttpMessageHandler((serviceProvider) =>
            // {
            //     var settings = serviceProvider.GetRequiredService<IOptionsMonitor<CoreWCFSettings>>().CurrentValue;
            //     var handler = new HttpClientHandler
            //     {
            //         ClientCertificateOptions = ClientCertificateOption.Manual,
            //     };
            //     handler.ClientCertificates.Add(settings.Certificate);
            //     return handler;
            // });
            // services.AddHttpClient<TypedHttpClient1>("http-client");
            // services.AddHttpClient<TypedHttpClient2>("http-client");

            services.AddScoped<TheService>();
            services.AddScoped<ITheService>(serviceProvider =>
            {
                return serviceProvider.GetRequiredService<TheService>();
            });
            services.AddScoped<ITheServiceAsync>(serviceProvider =>
            {
                return serviceProvider.GetRequiredService<TheService>();
            });

            services.AddServiceModelServices();
            services.AddServiceModelMetadata();
            services.AddSingleton<IServiceBehavior, UseRequestHeadersForMetadataAddressBehavior>();
            services.AddSingleton<IErrorHandler, ErrorHandler>();
            services.AddSingleton<UserNamePasswordValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment webHostEnvironment)
        {
            if (!webHostEnvironment.IsDevelopment())
            {
                app.UseHttpsRedirection();
                app.UseHsts();
            }

            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseServiceModel(serviceBuilder =>
            {
                var security = SecurityBindingElement.CreateUserNameOverTransportBindingElement();
                security.SecurityHeaderLayout = SecurityHeaderLayout.Lax;

                var customBinding = new CustomBinding
                {
                    Namespace = Namespaces.Service,
                };

                customBinding.Elements.Add(security);
                customBinding.Elements.Add(new TextMessageEncodingBindingElement(MessageVersion.Soap12, Encoding.UTF8));
                customBinding.Elements.Add(new HttpsTransportBindingElement());

                serviceBuilder.AddService<ITheService>(options =>
                {
                    options.DebugBehavior.IncludeExceptionDetailInFaults = webHostEnvironment.IsDevelopment();
                });
                serviceBuilder.AddServiceEndpoint<ITheService, ITheService>(
                    customBinding, "/TheService.svc");

                serviceBuilder.ConfigureServiceHostBase<ITheService>((host) =>
                {
                    var srvCredentials = new ServiceCredentials();
                    srvCredentials.UserNameAuthentication.UserNamePasswordValidationMode = UserNamePasswordValidationMode.Custom;
                    srvCredentials.UserNameAuthentication.CustomUserNamePasswordValidator = app.ApplicationServices.GetRequiredService<UserNamePasswordValidator>();

                    host.Description.Behaviors.Add(srvCredentials);
                });

                serviceBuilder.AddService<ITheServiceAsync>(options =>
                {
                    options.DebugBehavior.IncludeExceptionDetailInFaults = webHostEnvironment.IsDevelopment();
                });
                serviceBuilder.AddServiceEndpoint<ITheServiceAsync, ITheServiceAsync>(
                    customBinding, "/TheServiceAsync.svc");

                serviceBuilder.ConfigureServiceHostBase<ITheServiceAsync>((host) =>
                {
                    var srvCredentials = new ServiceCredentials();
                    srvCredentials.UserNameAuthentication.UserNamePasswordValidationMode = UserNamePasswordValidationMode.Custom;
                    srvCredentials.UserNameAuthentication.CustomUserNamePasswordValidator = app.ApplicationServices.GetRequiredService<UserNamePasswordValidator>();

                    host.Description.Behaviors.Add(srvCredentials);
                });

                var serviceMetadataBehavior = app.ApplicationServices.GetRequiredService<ServiceMetadataBehavior>();
                serviceMetadataBehavior.HttpsGetEnabled = true;
            });
        }
    }
}
