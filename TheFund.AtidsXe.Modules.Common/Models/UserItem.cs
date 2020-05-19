namespace TheFund.AtidsXe.Modules.Common.Models
{
    public class UserItem : IUserItem
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
    }
}