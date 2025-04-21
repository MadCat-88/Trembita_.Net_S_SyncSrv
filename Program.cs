using CoreWCF;
using CoreWCF.Channels;
using CoreWCF.Configuration;
using CoreWCF.Description;

namespace PersonApi_sync_SOAP
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddServiceModelServices();
            builder.Services.AddServiceModelMetadata();
            builder.Services.AddSingleton<IServiceBehavior, UseRequestHeadersForMetadataAddressBehavior>();

            var app = builder.Build();

            app.UseServiceModel(serviceBuilder =>
            {
                serviceBuilder.AddService<PersonService>();
                serviceBuilder.AddServiceEndpoint<PersonService, IPersonService>(new BasicHttpBinding(), "/Service.svc");
                // serviceBuilder.AddServiceEndpoint<PersonService, IPersonService>(new BasicHttpBinding(BasicHttpSecurityMode.Transport), "/Service.svc");
                var serviceMetadataBehavior = app.Services.GetRequiredService<ServiceMetadataBehavior>();
                serviceMetadataBehavior.HttpGetEnabled = true;
                // serviceMetadataBehavior.HttpsGetEnabled = true;
            });

            app.Run();

        }
    }
}