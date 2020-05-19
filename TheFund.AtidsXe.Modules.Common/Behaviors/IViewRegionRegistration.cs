namespace TheFund.AtidsXe.Modules.Common.Behaviors
{
    public interface IViewRegionRegistration
    {
        string RegionName { get; }
        bool IsActiveOnStartUp { get; }
    }
}
