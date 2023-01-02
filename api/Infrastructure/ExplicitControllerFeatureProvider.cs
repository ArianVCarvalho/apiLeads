using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace api.Infrastructure;

public class ExplicitControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
{
    private readonly List<Type> _controllers = new();

    public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature) =>
        _controllers.ForEach(ctrl => feature.Controllers.Add(ctrl.GetTypeInfo()));

    public void Register<T>() where T : ControllerBase => _controllers.Add(typeof(T));
}