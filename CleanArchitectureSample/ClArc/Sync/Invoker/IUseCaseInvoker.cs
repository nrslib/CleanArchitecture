using ClArc.Sync.Core;

namespace ClArc.Sync.Invoker
{
    public interface IUseCaseInvoker
    {
        TResponse Invoke<TResponse>(object request) where TResponse : IResponse;
    }
}
