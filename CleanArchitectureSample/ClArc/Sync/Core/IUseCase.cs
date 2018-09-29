namespace ClArc.Sync.Core
{
    /// <summary>
    /// Interface for business logick.
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public interface IUseCase<in TRequest, out TResponse> 
        where TRequest : IRequest<TResponse> 
        where TResponse : IResponse
    {
        TResponse Handle(TRequest request);
    }
}
