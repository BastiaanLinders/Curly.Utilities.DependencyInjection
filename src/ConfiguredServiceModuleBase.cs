using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Utilities.DependencyInjection
{
	public abstract class ConfiguredServiceModuleBase
	{
		public abstract void RegisterServices(IServiceCollection serviceCollection, IConfiguration configuration);
	}
}