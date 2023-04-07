namespace zv_practica.Contracts
{
    public class CreateUserRequest
    {
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public DateTime Birthday { get; set; } 
        public bool IsDeleted { get; set; }
        public bool IsAdmin { get; set; } 
    }
}
