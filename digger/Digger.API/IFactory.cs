namespace Digger.API
{
    public interface IFactory : ISystem
    {
        IRefresher CreateRefresher(IDigger digger, IColorModel model);
    }
}