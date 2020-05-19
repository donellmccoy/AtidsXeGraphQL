namespace TheFund.AtidsXe.Server.Providers
{
    public interface IContextProvider<T>
    {
        T Get();
    }
}