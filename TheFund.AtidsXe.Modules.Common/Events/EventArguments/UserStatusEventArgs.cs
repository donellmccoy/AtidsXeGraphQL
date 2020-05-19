namespace TheFund.AtidsXe.Modules.Common.Events.EventArguments
{
    public sealed class UserStatusEventArgs : IUserStatusEventArgs
    {
        public string Status { get; set; }
    }
}