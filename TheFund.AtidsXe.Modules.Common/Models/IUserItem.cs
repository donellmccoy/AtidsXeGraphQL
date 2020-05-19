namespace TheFund.AtidsXe.Modules.Common.Models
{
    public interface IUserItem
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string UserName { get; set; }
        int UserId { get; set; }
    }
}