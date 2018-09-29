using System;
using System.Reflection;

namespace ClArc.Async.Invoker
{
    internal class UseCaseInvoker : IUseCaseInvoker {
        private readonly Type usecaseType;
        private readonly IServiceProvider provider;
        private readonly MethodInfo handleMethod;

        public UseCaseInvoker(Type usecaseType, Type implementsType, IServiceProvider provider) {
            this.usecaseType = usecaseType;
            this.provider = provider;

            handleMethod = implementsType.GetMethod("Handle");
        }

        public void Invoke(object request) {
            var instance = provider.GetService(usecaseType);

            try {
                handleMethod.Invoke(instance, new[] { request });
            } catch (TargetInvocationException e) {
                throw e.InnerException;
            }
        }
    }
}
