namespace LawApp.Rep.SqlContext
{
    internal interface IAppContextFactory
    {
        LowAppContext CreateContext();
    }
}
