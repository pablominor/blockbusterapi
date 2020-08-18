namespace BlockbusterApp.src.Application.UseCase.User.Response
{
    public class User
    {
        public string Type { get; set; } = "user";
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string CountryCode { get; set; }
    }
}
