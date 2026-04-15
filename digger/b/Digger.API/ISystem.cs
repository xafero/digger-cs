namespace Digger.API
{
    public interface ISystem
    {
        string GetSubmitParameter();

        int GetSpeedParameter();

        void RequestFocus();
    }
}