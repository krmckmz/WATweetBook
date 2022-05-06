using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WATweetBook
{
    public interface IInstaller
    {
        void InstallServices(IServiceCollection services,IConfiguration configuration);
    }
}
