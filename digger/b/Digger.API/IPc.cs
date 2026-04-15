namespace Digger.API
{
    public interface IPc
    {
        int GetWidth();

        int GetHeight();

        int[] GetPixels();

        IRefresher GetCurrentSource();
    }
}