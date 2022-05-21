namespace UserService.Dtos
{
    public class UserPublishedDto
    {
        public int Id { get; set; }
        public string KeyCloakIdentifier { get; set; } 
        public bool isPrivate { get; set; }
        public string FirstName { get; set; }   
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Event { get; set; }
    }
}