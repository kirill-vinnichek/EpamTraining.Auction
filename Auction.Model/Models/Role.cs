namespace Auction.Model.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }

        public User Users { get; set; }
    }
}
