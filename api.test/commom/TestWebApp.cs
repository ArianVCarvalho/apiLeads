using api.Apis;
using api.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace api.test.commom;

public class TestWebApp : WebApplicationFactory<TestWebApp.Startup>

{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(c =>
            {
                
                c.JsonSerializerOptions.WriteIndented = true;
                
            }).ConfigureApplicationPartManager(c =>
            {
                foreach (var cfp in c.FeatureProviders.OfType<ControllerFeatureProvider>().ToList())
                    c.FeatureProviders.Remove(cfp);
                var provider = new ExplicitControllerFeatureProvider();

                provider.Register<HelloWorldApi>();
                
                c.FeatureProviders.Add(provider);
            });
            
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseEndpoints(c => { c.MapControllers(); });
        }
    }
}