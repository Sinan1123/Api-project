namespace Ders26_Api.Models
{
    public class DummyUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class DummyUserResponse
    {
        public List<DummyUser> Users { get; set; }
    }
}
