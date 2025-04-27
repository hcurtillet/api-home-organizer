using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace HomeOrganizer.Infrastructure.Extensions;

public class AutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var assembly = Assembly.GetExecutingAssembly();

        builder.RegisterAssemblyTypes(assembly)
            .Where(t =>
                t.IsClass && t.IsAbstract == false && t.FullName.EndsWith("Dao")
            )
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
    }
}