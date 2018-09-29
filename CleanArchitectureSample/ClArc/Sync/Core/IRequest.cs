namespace ClArc.Sync.Core
{
    public interface IRequest<out TResponse> where TResponse : IResponse
    {
    }
}
