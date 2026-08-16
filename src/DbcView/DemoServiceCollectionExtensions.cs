using Atlas.Blazor.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace DbcView;

/// <summary>
/// Registers the Atlas services the Demo needs at startup. Only the workspace
/// factory is registered here; every content panel (the DBC explorer, editor,
/// and properties views) is a Host-local AtlasContentRoute contribution
/// declared by DbcViewWorkspace.
/// </summary>
public static class DemoServiceCollectionExtensions
{
    public static IServiceCollection AddDbcViewServices(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);
        services.AddAtlasWorkspace();
        return services;
    }
}
