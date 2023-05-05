namespace zv_practica.Contracts
{
    public class CreateAdressRequest
    {
        public string? City { get; set; }

        public string? Country { get; set; }

        public string? Street { get; set; }

        public string? House { get; set; }

        public string? Appartments { get; set; }

        public string Login { get; set; } = null!;

        public bool IsDeleted { get; set; }
    }
}
