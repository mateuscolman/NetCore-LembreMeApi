
namespace LembreMeApi.Infra
{
    internal class FactoryService
    {
        private IServiceProvider serviceProvider;

        public FactoryService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
    }
}