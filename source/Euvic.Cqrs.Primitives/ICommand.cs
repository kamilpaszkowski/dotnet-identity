namespace Euvic.Cqrs.Primitives
{
    public interface ICommand : MediatR.IRequest { }
    public interface ICommand<out TResult> : MediatR.IRequest<TResult> { }
}
