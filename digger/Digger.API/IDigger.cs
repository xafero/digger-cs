namespace Digger.API
{
    public interface IDigger
    {
        IPc GetPc();

        bool KeyDown(int key);

        bool KeyUp(int key);
    }
}