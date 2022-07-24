namespace Euvic.Cqrs.Primitives
{
    public interface IQuery<out TResult> : MediatR.IRequest<TResult> { }
}
