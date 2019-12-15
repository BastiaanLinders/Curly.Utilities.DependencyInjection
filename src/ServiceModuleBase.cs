using Microsoft.Extensions.DependencyInjection;

namespace Utilities.DependencyInjection
{
	public abstract class ServiceModuleBase
	{
		public abstract void RegisterServices(IServiceCollection serviceCollection);
	}
}