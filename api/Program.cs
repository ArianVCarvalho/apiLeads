using api.Apis;
using api.Infrastructure;
using Microsoft.AspNetCore.Mvc.Controllers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc().ConfigureApplicationPartManager(c =>
{
    foreach (var cfp in c.FeatureProviders.OfType<ControllerFeatureProvider>().ToList())
        c.FeatureProviders.Remove(cfp);
    var provider = new ExplicitControllerFeatureProvider();
    provider.Register<HelloWorldApi>();
    c.FeatureProviders.Add(provider);
});

var app = builder.Build();
app.UseRouting();
app.UseEndpoints(b =>
{
    b.MapControllers();
});

//app.MapGet("/", () => "Hello World!");
app.Run();