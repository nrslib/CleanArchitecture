using ClArc.Async;
using ClArc.Async.Core;
using Microsoft.Extensions.DependencyInjection;

namespace ClArc.Builder
{
    public class AsyncUseCaseBusBuilder 
    {
        private readonly IServiceCollection services;
        private readonly UseCaseBus bus = new UseCaseBus();

        public AsyncUseCaseBusBuilder(IServiceCollection services) {
            this.services = services;
        }

        public UseCaseBus Build() {
            var provider = services.BuildServiceProvider();
            bus.Setup(provider);
            return bus;
        }

        public void RegisterUseCase<TRequest, TImplement>()
            where TRequest : IRequest
            where TImplement : class, IUseCase<TRequest> {
            services.AddSingleton<TImplement>();
            bus.Register<TRequest, TImplement>();
        }
    }
}
