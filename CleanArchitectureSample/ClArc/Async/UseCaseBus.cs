using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClArc.Async.Core;
using ClArc.Async.Invoker;

namespace ClArc.Async
{
    public class UseCaseBus {
        private readonly Dictionary<Type, Type> handlerTypes = new Dictionary<Type, Type>();
        private readonly ConcurrentDictionary<Type, UseCaseInvoker> invokers = new ConcurrentDictionary<Type, UseCaseInvoker>();

        private IServiceProvider provider;

        public void Setup(IServiceProvider provider) {
            this.provider = provider;
        }

        public void Register<TRequest, TUseCase>()
            where TRequest : IRequest
            where TUseCase : IUseCase<TRequest> {
            handlerTypes.Add(typeof(TRequest), typeof(TUseCase));
        }

        public void Handle(IRequest request)
        {
            var invoker = Invoker(request);
            invoker.Invoke(request);
        }

        public async Task HandleAync(IRequest request)
        {
            var invoker = Invoker(request);
            await Task.Run(() => invoker.Invoke(request));
        }

        private UseCaseInvoker Invoker(IRequest request)
        {
            var requestType = request.GetType();
            if (invokers.TryGetValue(requestType, out var searchedInvoker)) {
                return searchedInvoker;
            }

            if (!handlerTypes.TryGetValue(requestType, out var handlerType)) {
                throw new Exception($"No registered any usecase for this request(RequestType : {request.GetType().Name}");
            }

            var invoker = invokers.GetOrAdd(requestType, _ => {
                var handlerInstance = provider.GetService(handlerType);
                return new UseCaseInvoker(handlerType, handlerInstance.GetType(), provider);
            });

            return invoker;
        }
    }
}
