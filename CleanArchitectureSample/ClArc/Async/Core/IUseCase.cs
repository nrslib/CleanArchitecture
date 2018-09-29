namespace ClArc.Async.Core
{
    /// <summary>
    /// Interface for business logick.
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public interface IUseCase<in TRequest> 
        where TRequest : IRequest 
    {
        void Handle(TRequest request);
    }
}
