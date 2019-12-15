using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Utilities.DependencyInjection
{
	public static class ServiceRegistrationExtensions
	{
		public static void AddModule<T>(this IServiceCollection serviceCollection) where T : ServiceModuleBase, new()
		{
			new T().RegisterServices(serviceCollection);
		}

		public static void AddModule<T>(this IServiceCollection serviceCollection, IConfiguration configuration) where T : ConfiguredServiceModuleBase, new()
		{
			new T().RegisterServices(serviceCollection, configuration);
		}

		public static IServiceCollection AddTransientAsImplementedInterfaces<T>(this IServiceCollection serviceCollection)
		{
			RegisterAsImplementedInterfaces(typeof(T), serviceCollection.AddTransient);
			return serviceCollection;
		}

		public static IServiceCollection AddSingletonAsImplementedInterfaces<T>(this IServiceCollection serviceCollection)
		{
			RegisterAsImplementedInterfaces(typeof(T), serviceCollection.AddSingleton);
			return serviceCollection;
		}

		public static IServiceCollection AddScopedAsImplementedInterfaces<T>(this IServiceCollection serviceCollection)
		{
			RegisterAsImplementedInterfaces(typeof(T), serviceCollection.AddScoped);
			return serviceCollection;
		}

		private static void RegisterAsImplementedInterfaces(Type typeToRegister, Func<Type, Type, IServiceCollection> scopedRegistration)
		{
			var implementedInterfaces = typeToRegister.GetInterfaces();
			foreach (var implementedInterface in implementedInterfaces)
			{
				scopedRegistration.Invoke(implementedInterface, typeToRegister);
			}
		}
	}
}
